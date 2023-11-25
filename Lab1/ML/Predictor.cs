using Lab1.ML.Base;
using Lab1.ML.Models;
using Microsoft.ML;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ML
{
    class Predictor:BaseML
    {
        public float Predict(PurchaseModel model, string modelPath)
        {
            ITransformer mlModel;

            using (var stream = new FileStream(modelPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                mlModel = MlContext.Model.Load(stream, out _);
            }

            if (mlModel == null)
            {
                Console.WriteLine("Failed to load model");

                return 0f;
            }

            var predictionEngine = MlContext.Model.CreatePredictionEngine<PurchaseModel, PurchaseModelPrediction>(mlModel);

            var prediction = predictionEngine.Predict(model);

            return prediction.Purchase;
        }
    }
}
