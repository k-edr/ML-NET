﻿using Lab1.ML.Base;
using Lab1.ML.Models;
using Microsoft.ML;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ML
{
    class Predictor:BaseML
    {
        public ICollection<float> Predict(ICollection<PurchaseModel> models, string modelPath)
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

            var predictionEngine = MlContext.Model.CreatePredictionEngine<PurchaseModel, PurchaseModelPrediction>(mlModel);

            var result = new List<float>();

            foreach (var model in models)
            {
                var prediction = predictionEngine.Predict(model);

                result.Add((int)prediction.Purchase);
            }

            return result;
        }
    }
}
