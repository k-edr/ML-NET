using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.ML.Base
{
    class BaseML
    {
        protected MLContext MLContext { get; set; }

        public BaseML()
        {
            MLContext = new MLContext();
        }
    }
}
