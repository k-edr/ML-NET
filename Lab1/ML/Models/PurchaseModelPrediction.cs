using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ML.Models
{
    class PurchaseModelPrediction
    {
        [ColumnName("Score")]
        public float Purchase { get; set; }
    }
}
