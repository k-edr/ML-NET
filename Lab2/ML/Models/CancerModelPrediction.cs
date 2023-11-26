using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.ML.Models
{
    internal class CancerModelPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Cancer { get; set; } 
    }
}
