using Lab3.Common;
using Lab3.ML.Base;
using Lab3.ML.Models;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.ML
{
    class Trainer:BaseML
    {
        public void Train(ICollection<ResolutionTweet> models)
        {
            IDataView dataView = MLContext.Data.LoadFromEnumerable(models);

            var dataSplit = MLContext.Data.TrainTestSplit(dataView);

            var pipeline =MLContext.Transforms.Categorical.OneHotEncoding("ResolutionCategory",nameof(ResolutionTweet.ResolutionCategory))
                .Append(MLContext.Transforms.Categorical.OneHotEncoding("ResolutionTopics",nameof(ResolutionTweet.ResolutionTopics)))
                //.Append(MLContext.Transforms.Categorical.OneHotEncoding("Text",nameof(ResolutionTweet.Text)))
                .Append(MLContext.Transforms.Concatenate("Features",
                nameof(ResolutionTweet.ResolutionCategory),
                //nameof(ResolutionTweet.Text) ,
                nameof(ResolutionTweet.ResolutionTopics)))
                .Append(MLContext.Clustering.Trainers.KMeans(featureColumnName: "Features", numberOfClusters: 5));

            ITransformer trainedModel = pipeline.Fit(dataSplit.TrainSet);

            var testSetTransform = trainedModel.Transform(dataSplit.TestSet);

            var modelMetrics = MLContext.Clustering.Evaluate(testSetTransform);

            using (var fileStream = new FileStream(Constants.MODEL_PATH, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                MLContext.Model.Save(trainedModel, dataView.Schema, fileStream);
            }
        }
        //DBSCAN
    }
}
