using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4.ML.Models;

namespace Lab4.Data
{

    class BikeShareLoader
    {
        public static ICollection<RawBikeShareModel> Load(string path)
        {
            var bikeDataList = new List<RawBikeShareModel>();

            using (var reader = new StreamReader(path))
            {
                // Skip header line
                reader.ReadLine();

                CultureInfo cultureInfo = CultureInfo.InvariantCulture;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var values = line.Split(',');

                    if (values.Length == 16) // Assuming 16 columns in the CSV
                    {
                        var bikeData = new RawBikeShareModel
                        {
                            Instant = float.Parse(values[0], cultureInfo),
                            Dteday = DateTime.Parse(values[1], cultureInfo),
                            Season = float.Parse(values[2], cultureInfo),
                            Year = float.Parse(values[3], cultureInfo),
                            Month = float.Parse(values[4], cultureInfo),
                            Holiday = float.Parse(values[5], cultureInfo),
                            Weekday = float.Parse(values[6], cultureInfo),
                            Workingday = float.Parse(values[7], cultureInfo),
                            Weathersit = float.Parse(values[8], cultureInfo),
                            Temp = float.Parse(values[9], cultureInfo),
                            Atemp = float.Parse(values[10], cultureInfo),
                            Hum = float.Parse(values[11], cultureInfo),
                            Windspeed = float.Parse(values[12], cultureInfo),
                            Casual = float.Parse(values[13], cultureInfo),
                            Registered = float.Parse(values[14], cultureInfo),
                            Count = float.Parse(values[15], cultureInfo)
                        };

                        bikeDataList.Add(bikeData);
                    }
                    else
                    {                      
                        Console.WriteLine("Incomplete data or incorrect format in the CSV file.");
                    }
                }
                return bikeDataList;
            }
        }
    }
}
