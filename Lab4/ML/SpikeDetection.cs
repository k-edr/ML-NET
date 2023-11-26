using Lab4.ML.Base;
using Lab4.ML.Models;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.ML
{
    class SpikeDetection:BaseML
    {
        public void DetectSpike(int size, ICollection<DayBikeShareModel> models)
        {
             
            var estimator = MLContext.Transforms.DetectIidSpike(outputColumnName: nameof(DayBikeShareModelPrediction.Prediction), inputColumnName: nameof(DayBikeShareModel.ShareCount), confidence: 95, pvalueHistoryLength: size / 4);
            
            ITransformer tansformedModel = estimator.Fit(CreateEmptyDataView());

            var dataView = MLContext.Data.LoadFromEnumerable(models);

            IDataView transformedData = tansformedModel.Transform(dataView);

            var predictions = MLContext.Data.CreateEnumerable<DayBikeShareModelPrediction>(transformedData, reuseRowObject: false);

            Console.WriteLine("Alert\tScore\tP-Value");
            foreach (var p in predictions)
            {
                if (p.Prediction[0] == 1)
                {
                    Console.Write("\t");
                }
                Console.WriteLine("{0}\t{1:0.00}\t{2:0.00}", p.Prediction[0], p.Prediction[1], p.Prediction[2]);
                Console.ResetColor();
            }
            Console.WriteLine("");
        }

        private void DetectChangepoint(int size, IDataView dataView)
        {     
            var estimator = MLContext.Transforms.DetectIidChangePoint(outputColumnName: nameof(DayBikeShareModelPrediction.Prediction), inputColumnName: nameof(DayBikeShareModel.ShareCount), confidence: 95, changeHistoryLength: size / 4);
         
            ITransformer tansformedModel = estimator.Fit(CreateEmptyDataView());
           
            IDataView transformedData = tansformedModel.Transform(dataView);
            var predictions = MLContext.Data.CreateEnumerable<DayBikeShareModelPrediction>(transformedData, reuseRowObject: false);

            Console.WriteLine($"{nameof(DayBikeShareModelPrediction.Prediction)} column obtained post-transformation.");
            Console.WriteLine("Alert\tScore\tP-Value\tMartingale value");

            foreach (var p in predictions)
            {
                if (p.Prediction[0] == 1)
                {
                    Console.WriteLine("{0}\t{1:0.00}\t{2:0.00}\t{3:0.00}  <-- alert is on, predicted changepoint", p.Prediction[0], p.Prediction[1], p.Prediction[2], p.Prediction[3]);
                }
                else
                {
                    Console.WriteLine("{0}\t{1:0.00}\t{2:0.00}\t{3:0.00}", p.Prediction[0], p.Prediction[1], p.Prediction[2], p.Prediction[3]);
                }
            }
            Console.WriteLine("");

            DetectChangepoint(size, dataView);
        }

        private string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;

            string fullPath = Path.Combine(assemblyFolderPath, relativePath);

            return fullPath;
        }

        private IDataView CreateEmptyDataView()
        {
            IEnumerable<DayBikeShareModel> enumerableData = new List<DayBikeShareModel>();
            var dv = MLContext.Data.LoadFromEnumerable(enumerableData);
            return dv;
        }

    }
}
