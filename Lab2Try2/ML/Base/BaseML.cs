using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Try2.ML.Base
{
    abstract class BaseML
    {
        protected MLContext MLContext;

        protected BaseML()
        {
            MLContext = new MLContext(0);
        }
    }
}
