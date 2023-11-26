using Lab1.ML.Base;
using Lab1.ML.Models;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ML
{
    class Trainer:BaseML
    {
        public void Train(ICollection<PurchaseModel> data, string saveTrainModelPath)
        {
            var trainingDataView = MlContext.Data.LoadFromEnumerable(data);

            var dataSplit = MlContext.Data.TrainTestSplit(trainingDataView, testFraction: 0.1f);

            var dataProcessPipeline = MlContext.Transforms.CopyColumns("Label", nameof(PurchaseModel.Purchase))
                .Append(MlContext.Transforms.Categorical.OneHotEncoding("Product_ID", nameof(PurchaseModel.Product_ID)))
                .Append(MlContext.Transforms.Categorical.OneHotEncoding("Gender", nameof(PurchaseModel.Gender)))
                .Append(MlContext.Transforms.Categorical.OneHotEncoding("Age", nameof(PurchaseModel.Age)))
                .Append(MlContext.Transforms.Categorical.OneHotEncoding("City_Category", nameof(PurchaseModel.City_Category)))
                .Append(MlContext.Transforms.Categorical.OneHotEncoding("Stay_In_Current_City_Years", nameof(PurchaseModel.Stay_In_Current_City_Years)))
                .Append(MlContext.Transforms.Concatenate("Features",
                    typeof(PurchaseModel).GetProperties().Select(prop => prop.Name).Where(name => name != nameof(PurchaseModel.Purchase)).ToArray()));


            var trainer = MlContext.Regression.Trainers.FastTree(labelColumnName: "Label", featureColumnName: "Features");

            var trainingPipeline = dataProcessPipeline.Append(trainer);

            ITransformer trainedModel = trainingPipeline.Fit(dataSplit.TrainSet);
            MlContext.Model.Save(trainedModel, dataSplit.TrainSet.Schema, saveTrainModelPath);

            var testSetTransform = trainedModel.Transform(dataSplit.TestSet);

            var modelMetrics = MlContext.Regression.Evaluate(testSetTransform);

            Console.WriteLine($"Loss Function: {modelMetrics.LossFunction:0.##}{Environment.NewLine}" +
                              $"Mean Absolute Error: {modelMetrics.MeanAbsoluteError:#.##}{Environment.NewLine}" +
                              $"Mean Squared Error: {modelMetrics.MeanSquaredError:#.##}{Environment.NewLine}" +
                              $"RSquared: {modelMetrics.RSquared:0.0000000}{Environment.NewLine}" +
                              $"Root Mean Squared Error: {modelMetrics.RootMeanSquaredError:#.##}");
        }
    }
}
