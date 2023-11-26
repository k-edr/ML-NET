using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.ML.Models
{
    class CancerModelLoader
    {
        public static ICollection<CancerModel> RawLoad(string path, string separator)
        {
            var result = new List<CancerModel>();

            using (StreamReader reader = new StreamReader(path))
            {
                reader.ReadLine();//ignore names

                string? line = "NA";

                while ((line = reader.ReadLine()) != null)
                {
                    var data = line.Split(separator);

                    var model = new CancerModel()
                    {
                        Cancer = data[0] == "Y" ? 1f : 0f,
                        Year = data[1] == "NA" ? null : data[1],
                        Month = data[2] == "NA" ? null : data[2],
                        Bleed = data[3] == "NA" ? null : data[3],
                        Mode_Presentation = data[4] == "NA" ? null : data[4],
                        Age = float.TryParse(data[5], out float age) ? age : 0,
                        Gender = data[6] == "NA" ? null : data[6],
                        Etiology = data[7] == "NA" ? null : data[7],
                        Cirrhosis = data[8] == "NA" ? null : data[8],
                        Size = float.TryParse(data[9], out float size) ? size : 0,
                        HCC_TNM_Stage = data[10] == "NA" ? null : data[10],
                        HCC_BCLC_Stage = data[11] == "NA" ? null : data[11],
                        ICC_TNM_Stage = data[12] == "NA" ? null : data[12],
                        Treatment_grps = data[13] == "NA" ? null : data[13],
                        Survival_fromMDM = float.TryParse(data[14], out float survival) ? survival : 0.0f,
                        Alive_Dead = data[15] == "NA" ? null : data[15],
                        Type_of_incidental_finding = data[16] == "NA" ? null : data[16],
                        Surveillance_programme = data[17] == "NA" ? null : data[17],
                        Surveillance_effectiveness = data[18] == "NA" ? null : data[18],
                        Mode_of_surveillance_detection = data[19] == "NA" ? null : data[19],
                        Time_diagnosis_1st_Tx = float.TryParse(data[20], out float diagnosisTime) ? diagnosisTime : 0.0f,
                        Date_incident_surveillance_scan = data[21] == "NA" ? null : data[21],
                        PS = data[22] == "NA" ? null : data[22],
                        Time_MDM_1st_treatment = float.TryParse(data[23], out float mdmTime) ? mdmTime : 0.0f,
                        Time_decisiontotreat_1st_treatment = float.TryParse(data[24], out float decisionToTreatTime) ? decisionToTreatTime : 0.0f,
                        Prev_known_cirrhosis = data[25] == "NA" ? null : data[25],
                        Months_from_last_surveillance = float.TryParse(data[26], out float lastSurveillance) ? lastSurveillance : 0.0f
                    };

                    result.Add(model);
                }

                return result;
            }
        }

        public static ICollection<CancerModel> LoadFromFile(string path, string separator)
        {
            var result = new List<CancerModel>();

            using (StreamReader reader = new StreamReader(path))
            {
                reader.ReadLine();//ignore names

                string? line = "NA";

                while ((line = reader.ReadLine()) != null)
                {
                    var data = line.Split(separator);

                    var model = new CancerModel()
                    {
                        Cancer = data[0] == "Y" ? 1f : 0f,
                        Year = data[1] == "NA" ? default : data[1],
                        Month = data[2] == "NA" ? default : data[2],
                        Bleed = data[3] == "NA" ? default : data[3],
                        Mode_Presentation = data[4] == "NA" ? default : data[4],
                        Age = int.TryParse(data[5], out int age) ? age : 0,
                        Gender = data[6] == "NA" ? default : data[6],
                        Etiology = data[7] == "NA" ? default : data[7],
                        Cirrhosis = data[8] == "NA" ? default : data[8],
                        Size = int.TryParse(data[9], out int size) ? size : 0,
                        HCC_TNM_Stage = data[10] == "NA" ? default : data[10],
                        HCC_BCLC_Stage = data[11] == "NA" ? default : data[11],
                        ICC_TNM_Stage = data[12] == "NA" ? default : data[12],
                        Treatment_grps = data[13] == "NA" ? default : data[13],
                        Survival_fromMDM = float.TryParse(data[14], out float survival) ? survival : 0.0f,
                        Alive_Dead = data[15] == "NA" ? default : data[15],
                        Type_of_incidental_finding = data[16] == "NA" ? default : data[16],
                        Surveillance_programme = data[17] == "NA" ? default : data[17],
                        Surveillance_effectiveness = data[18] == "NA" ? default : data[18],
                        Mode_of_surveillance_detection = data[19] == "NA" ? default : data[19],
                        Time_diagnosis_1st_Tx = float.TryParse(data[20], out float diagnosisTime) ? diagnosisTime : 0.0f,
                        Date_incident_surveillance_scan = data[21] == "NA" ? default : data[21],
                        PS = data[22] == "NA" ? default : data[22],
                        Time_MDM_1st_treatment = float.TryParse(data[23], out float mdmTime) ? mdmTime : 0.0f,
                        Time_decisiontotreat_1st_treatment = float.TryParse(data[24], out float decisionToTreatTime) ? decisionToTreatTime : 0.0f,
                        Prev_known_cirrhosis = data[25] == "NA" ? default : data[25],
                        Months_from_last_surveillance = float.TryParse(data[26], out float lastSurveillance) ? lastSurveillance : 0.0f
                    };

                    result.Add(model);
                }

                return result;
            }
        }

    }
}
