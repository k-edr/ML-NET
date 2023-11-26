using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Try2.ML.Training
{
    interface ITrainer<TData> where TData : class
    {
        public void Train(ICollection<TData> models, string saveModelPath);
    }
}
