using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Try2.ML.Prediction
{
    interface IPredictor<TData, TPrediction>
        where TData : class, new()
        where TPrediction : class, new()
    {
        public ICollection<TPrediction> Predict(ICollection<TData> dataModels, string modelPath);
    }
}
