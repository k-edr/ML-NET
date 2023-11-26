using Lab2Try2.ML.Base;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Try2.ML.Prediction
{
    class Predictor<TData, TPrediction> : BaseML, IPredictor<TData, TPrediction>
        where TData : class, new()
        where TPrediction : class, new()
    {
        public ICollection<TPrediction> Predict(ICollection<TData> dataModels, string modelPath)
        {
            ITransformer mlModel;

            using (var stream = new FileStream(modelPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                mlModel = MLContext.Model.Load(stream, out _);
            }

            if (mlModel == null)
            {
                Console.WriteLine("Failed to load model");
                return null!;
            }

            var predictionEngine = MLContext.Model.CreatePredictionEngine<TData, TPrediction>(mlModel);

            var result = new List<TPrediction>();

            foreach (var model in dataModels)
            {
                result.Add(predictionEngine.Predict(model));
            }

            return result;
        }
    }
}
