using Lab3.Common;
using Lab3.ML.Base;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.ML.Models
{
    class Predictor:BaseML
    {
        public ICollection<(ResolutionTweet Tweet, ResolutionTweetPrediction Prediction)> Predict(ICollection<ResolutionTweet> tweets)
        {
            ITransformer mlModel;

            using (var stream = new FileStream(Constants.MODEL_PATH, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                mlModel = MLContext.Model.Load(stream, out _);
            }

            if (mlModel == null)
            {
                Console.WriteLine("Failed to load model");

                return null!;
            }

            var result = new List<(ResolutionTweet Original, ResolutionTweetPrediction Prediction)>();

            foreach (var dataModel in tweets)
            {
                var prediction = MLContext.Model.CreatePredictionEngine<ResolutionTweet, ResolutionTweetPrediction>(mlModel);

                result.Add((Original: dataModel, Prediction: prediction.Predict(dataModel)));
            }

            return result;
        }
    }
}
