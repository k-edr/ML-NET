using Lab2.ML.Base;
using Lab2.ML.Models;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.ML
{
    class Trainer:BaseML
    {
        public void Train(ICollection<CancerModel> data, string saveTrainModelPath)
        {
            var trainingDataView = MlContext.Data.LoadFromEnumerable(data);
            trainingDataView = MlContext.Data.ShuffleRows(trainingDataView);

            var dataSplit = MlContext.Data.TrainTestSplit(trainingDataView, testFraction: 0.1f);

            //var dataProcessPipeline = MlContext.Transforms.CopyColumns("Label", nameof(CancerModel.Cancer))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("Year", nameof(CancerModel.Year)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("Month", nameof(CancerModel.Month)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("Bleed", nameof(CancerModel.Bleed)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("Mode_Presentation", nameof(CancerModel.Mode_Presentation)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("Gender", nameof(CancerModel.Gender)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("Etiology", nameof(CancerModel.Etiology)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("Cirrhosis", nameof(CancerModel.Cirrhosis)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("HCC_TNM_Stage", nameof(CancerModel.HCC_TNM_Stage)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("HCC_BCLC_Stage", nameof(CancerModel.HCC_BCLC_Stage)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("ICC_TNM_Stage", nameof(CancerModel.ICC_TNM_Stage)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("Treatment_grps", nameof(CancerModel.Treatment_grps)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("Alive_Dead", nameof(CancerModel.Alive_Dead)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("Type_of_incidental_finding", nameof(CancerModel.Type_of_incidental_finding)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("Surveillance_programme", nameof(CancerModel.Surveillance_programme)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("Surveillance_effectiveness", nameof(CancerModel.Surveillance_effectiveness)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("Mode_of_surveillance_detection", nameof(CancerModel.Mode_of_surveillance_detection)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("Date_incident_surveillance_scan", nameof(CancerModel.Date_incident_surveillance_scan)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("PS", nameof(CancerModel.PS)))
            //    .Append(MlContext.Transforms.Categorical.OneHotEncoding("Prev_known_cirrhosis", nameof(CancerModel.Prev_known_cirrhosis)))            
            //    .Append(MlContext.Transforms.Concatenate("Features",
            //        typeof(CancerModel).GetProperties().Select(prop => prop.Name).Where(name => name != nameof(CancerModel.Cancer)).ToArray()));

            var dataProcessPipeline = MlContext.Transforms.CopyColumns("Label", nameof(CancerModel.Cancer))
               .Append(MlContext.Transforms.Categorical.OneHotEncoding("Month", nameof(CancerModel.Month)))
               .Append(MlContext.Transforms.Categorical.OneHotEncoding("PS", nameof(CancerModel.PS)))
               .Append(MlContext.Transforms.Concatenate("Features",
               nameof(CancerModel.Month),
               nameof(CancerModel.Age),
               nameof(CancerModel.Size),
               nameof(CancerModel.Survival_fromMDM),
               nameof(CancerModel.PS)));

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
