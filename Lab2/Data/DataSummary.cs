using Lab2.ML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Data
{
    class DataSummary
    {
        public static void ShowNullVariables(ICollection<CancerModel> models)
        {
            var properties = typeof(CancerModel).GetProperties();

            var dict = new Dictionary<string, int>();

            foreach (var property in properties)
            {
                dict.Add(property.Name, 0);
            }

            foreach (var model in models)
            {
                foreach (var property in properties)
                {
                    var value = property.GetValue(model);

                    if (value == null || string.IsNullOrEmpty(value.ToString()))
                    {
                        dict[property.Name]++;
                    }
                }
            }

            Console.WriteLine("Properties that have null");

            foreach (var keyValuePair in dict)
            {
                Console.WriteLine($"{keyValuePair.Key}: {(keyValuePair.Value > 0 ? "True" : "False")}");
            }

            Console.WriteLine("Null count");

            foreach (var keyValuePair in dict)
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}");
            }

        }
    }
}
