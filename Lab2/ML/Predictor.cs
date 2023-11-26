using Lab2.ML.Base;
using Lab2.ML.Models;
using Microsoft.ML;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.ML
{
    class Predictor:BaseML
    {
        public ICollection<bool> Predict(ICollection<CancerModel> models, string modelPath)
        {
            ITransformer mlModel;

            using (var stream = new FileStream(modelPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                mlModel = MlContext.Model.Load(stream, out _);
            }

            if (mlModel == null)
            {
                Console.WriteLine("Failed to load model");

                return null!;
            }

            var predictionEngine = MlContext.Model.CreatePredictionEngine<CancerModel, CancerModelPrediction>(mlModel);

            var result = new List<bool>();

            foreach (var model in models)
            {
                var prediction = predictionEngine.Predict(model);

                result.Add(prediction.Cancer);
            }

            return result;
        }
    }
}
