using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ML.Base
{
    abstract class BaseML
    {
        protected readonly MLContext MlContext;

        protected BaseML()
        {
            MlContext = new MLContext();
        }

        protected BaseML(int seed)
        {
            MlContext = new MLContext(seed);
        }

    }
}
