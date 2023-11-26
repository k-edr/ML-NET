using Lab2Try2.Loading.Models;
using Lab2Try2.ML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Try2.Loading
{
    class CancerModelLoader
    {
        public static ICollection<RawCancerModel> LoadFromFile(string dataPath, string separator, bool skipFirstLine = true)
        {
            var result = new List<RawCancerModel>();

            using (var reader = new StreamReader(dataPath))
            {
                if (skipFirstLine) reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var data = reader.ReadLine()!.Split(separator);

                    result.Add(new RawCancerModel
                    {
                        Cancer = data[0] == "Y" ? true : false,
                        Year = GetStringOrEmpty(data[1]),
                        Month = GetStringOrEmpty(data[2]),
                        Bleed = GetStringOrEmpty(data[3]),
                        Mode_Presentation = GetStringOrEmpty(data[4]),
                        Age = GetStringOrEmpty(data[5]),
                        Gender = GetStringOrEmpty(data[6]),
                        Etiology = GetStringOrEmpty(data[7]),
                        Cirrhosis = GetStringOrEmpty(data[8]),
                        Size = GetStringOrEmpty(data[9]),
                        HCC_TNM_Stage = GetStringOrEmpty(data[10]),
                        HCC_BCLC_Stage = GetStringOrEmpty(data[11]),
                        ICC_TNM_Stage = GetStringOrEmpty(data[12]),
                        Treatment_grps = GetStringOrEmpty(data[13]),
                        Survival_fromMDM = GetStringOrEmpty(data[14]),
                        Alive_Dead = GetStringOrEmpty(data[15]),
                        Type_of_incidental_finding = GetStringOrEmpty(data[16]),
                        Surveillance_programme = GetStringOrEmpty(data[17]),
                        Surveillance_effectiveness = GetStringOrEmpty(data[18]),
                        Mode_of_surveillance_detection = GetStringOrEmpty(data[19]),
                        Time_diagnosis_1st_Tx = GetStringOrEmpty(data[20]),
                        Date_incident_surveillance_scan = GetStringOrEmpty(data[21]),
                        PS = GetStringOrEmpty(data[22]),
                        Time_MDM_1st_treatment = GetStringOrEmpty(data[23]),
                        Time_decisiontotreat_1st_treatment = GetStringOrEmpty(data[24]),
                        Prev_known_cirrhosis = GetStringOrEmpty(data[25]),
                        Months_from_last_surveillance = GetStringOrEmpty(data[26])
                    });
                }

                return result;
            }
        }

        private static string GetStringOrEmpty(string str)
        {
            str = str.Trim('\"');

            if (str.Equals("NA"))
            {
                return str;
            }

            if (string.IsNullOrEmpty(str))
            {
                return "NA";
            }

            return str;
        }

        public static ICollection<CancerModel> ConvertFromRawToMLModel(ICollection<RawCancerModel> rawModels)
        {
            var result = new List<CancerModel>();

            foreach (var rawModel in rawModels)
            {
                result.Add(new CancerModel()
                {
                    Cancer = rawModel.Cancer,
                    Year = rawModel.Year,
                    Month = rawModel.Month,
                    Bleed = rawModel.Bleed,
                    Mode_Presentation = rawModel.Mode_Presentation,
                    Age = rawModel.Age,
                    Gender = rawModel.Gender,
                    Etiology = rawModel.Etiology,
                    Cirrhosis = rawModel.Cirrhosis,
                    Size = rawModel.Size,
                    HCC_TNM_Stage = rawModel.HCC_TNM_Stage,
                    HCC_BCLC_Stage = rawModel.HCC_BCLC_Stage,
                    Treatment_grps = rawModel.Treatment_grps,
                    Survival_fromMDM = rawModel.Survival_fromMDM,
                    Alive_Dead = rawModel.Alive_Dead,
                    Type_of_incidental_finding = rawModel.Type_of_incidental_finding,
                    Surveillance_programme = rawModel.Surveillance_programme,
                    Surveillance_effectiveness = rawModel.Surveillance_effectiveness,
                    Mode_of_surveillance_detection = rawModel.Mode_of_surveillance_detection,
                    PS = rawModel.PS,
                    Prev_known_cirrhosis = rawModel.Prev_known_cirrhosis,
                });
            }

            return result;
        }

    }
}
