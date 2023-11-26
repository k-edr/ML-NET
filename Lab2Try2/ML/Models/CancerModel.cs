using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Try2.ML.Models
{
    class CancerModel
    {
        public bool Cancer { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Bleed { get; set; }
        public string Mode_Presentation { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Etiology { get; set; }
        public string Cirrhosis { get; set; }
        public string Size { get; set; }
        public string HCC_TNM_Stage { get; set; }
        public string HCC_BCLC_Stage { get; set; }
        //public string ICC_TNM_Stage { get; set; }
        public string Treatment_grps { get; set; }
        public string Survival_fromMDM { get; set; }
        public string Alive_Dead { get; set; }
        public string Type_of_incidental_finding { get; set; }
        public string Surveillance_programme { get; set; }
        public string Surveillance_effectiveness { get; set; }
        public string Mode_of_surveillance_detection { get; set; }
        //public string Time_diagnosis_1st_Tx { get; set; }
        //public string Date_incident_surveillance_scan { get; set; }
        public string PS { get; set; }
        //public string Time_MDM_1st_treatment { get; set; }
        //public string Time_decisiontotreat_1st_treatment { get; set; }
        public string Prev_known_cirrhosis { get; set; }
        //public string Months_from_last_surveillance { get; set; }

    }
}
