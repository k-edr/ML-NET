using Lab2Try2.ML.Base;
using Lab2Try2.ML.Models;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Try2.ML.Training.Classification
{
    class AveragedPerceptronTrainer : BaseML, ITrainer<CancerModel>
    {
        public void Train(ICollection<CancerModel> models, string saveModelPath)
        {
            var trainingDataView = MLContext.Data.LoadFromEnumerable(models);

            var dataSplit = MLContext.Data.TrainTestSplit(trainingDataView, testFraction: 0.1f);

            IEstimator<ITransformer> dataProcessPipeline = MLContext.Transforms.CopyColumns("Label", nameof(CancerModel.Cancer));

            var propertyNames = typeof(CancerModel).GetProperties().Select(prop => prop.Name).Where(prop => prop != "Cancer");

            foreach (var propertyName in propertyNames)
            {
                var estimator = MLContext.Transforms.Categorical.OneHotEncoding(propertyName, propertyName);
                dataProcessPipeline = dataProcessPipeline.Append(estimator);
            }

            dataProcessPipeline = dataProcessPipeline.Append(MLContext.Transforms.Concatenate("Features", propertyNames.ToArray()));

            var trainer = MLContext.BinaryClassification.Trainers.SdcaNonCalibrated();

            var trainingPipeline = dataProcessPipeline.Append(trainer);

            ITransformer trainedModel = trainingPipeline.Fit(dataSplit.TrainSet);

            MLContext.Model.Save(trainedModel, dataSplit.TrainSet.Schema, saveModelPath);

            var testSetTransform = trainedModel.Transform(dataSplit.TestSet);

            //var metrics = MLContext.BinaryClassification
            //    .EvaluateNonCalibrated(testSetTransform);

            //PrintMetrics(metrics);
        }

        private static void PrintMetrics(BinaryClassificationMetrics metrics)
        {
            Console.WriteLine($"Accuracy: {metrics.Accuracy:F2}");
            Console.WriteLine($"AUC: {metrics.AreaUnderRocCurve:F2}");
            Console.WriteLine($"F1 Score: {metrics.F1Score:F2}");
            Console.WriteLine($"Negative Precision: " +
                $"{metrics.NegativePrecision:F2}");

            Console.WriteLine($"Negative Recall: {metrics.NegativeRecall:F2}");
            Console.WriteLine($"Positive Precision: " +
                $"{metrics.PositivePrecision:F2}");

            Console.WriteLine($"Positive Recall: {metrics.PositiveRecall:F2}\n");
            Console.WriteLine(metrics.ConfusionMatrix.GetFormattedConfusionTable());
        }
    }
}
