using Lab1.ML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ML
{
    class PurchaseModelLoader
    {

        public static ICollection<PurchaseModel> LoadFromFile(string path, char separator)
        {
            var result = new List<PurchaseModel>();

            using (StreamReader reader = new StreamReader(path))
            {
                reader.ReadLine();//ignore names

                string? line = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    var data = line.Split(separator);

                    result.Add(new()
                    {
                        User_ID = float.Parse(data[0]),
                        Product_ID = data[1],
                        Gender = data[2],
                        Age = data[3],
                        Occupation = float.Parse(data[4]),
                        City_Category = data[5],
                        Stay_In_Current_City_Years = float.Parse(data[6]),
                        Marital_Status = float.Parse(data[7]),
                        Product_Category_1 = data[8] == "" ? 0 : float.Parse(data[8]),
                        Product_Category_2 = data[9] == "" ? 0 : float.Parse(data[9]),
                        Product_Category_3 = data[10] == "" ? 0 : float.Parse(data[10]),
                        Purchase = data[11] == "" ? 0 : float.Parse(data[11])
                    });

                }

                return result;
            }
        }

    }
}
