using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.ML.Models
{
    class RawBikeShareModel
    {
        [LoadColumn(0)]
        public float Instant { get; set; }

        [LoadColumn(1)]
        public DateTime Dteday { get; set; }

        [LoadColumn(2)]
        public float Season { get; set; }

        [LoadColumn(3)]
        public float Year { get; set; }

        [LoadColumn(4)]
        public float Month { get; set; }

        [LoadColumn(5)]
        public float Holiday { get; set; }

        [LoadColumn(6)]
        public float Weekday { get; set; }

        [LoadColumn(7)]
        public float Workingday { get; set; }

        [LoadColumn(8)]
        public float Weathersit { get; set; }

        [LoadColumn(9)]
        public float Temp { get; set; }

        [LoadColumn(10)]
        public float Atemp { get; set; }

        [LoadColumn(11)]
        public float Hum { get; set; }

        [LoadColumn(12)]
        public float Windspeed { get; set; }

        [LoadColumn(13)]
        public float Casual { get; set; }

        [LoadColumn(14)]
        public float Registered { get; set; }

        [LoadColumn(15)]
        public float Count { get; set; }
    }
}
