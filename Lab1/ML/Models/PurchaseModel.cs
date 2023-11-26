using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ML.Models
{
    public class PurchaseModel
    {
        public required float User_ID { get; set; }

        public required string Product_ID { get; set; }
        
        public required string Gender { get; set; }

        public required string Age { get; set; }

        public required float Occupation { get; set; }

        public required string City_Category { get; set; }

        public required string Stay_In_Current_City_Years { get; set; }

        public required float Marital_Status { get; set; }

        public required float Product_Category_1 { get; set; }

        public required float Product_Category_2 { get; set; }

        public required float Product_Category_3 { get; set; }

        public float Purchase { get; set; }

        public override string? ToString()
        {
            return
                $" User_ID: {User_ID}," +
                $" Product_ID: {Product_ID}," +
                $" Gender: {Gender}," +
                $" Age: {Age}," +
                $" Occupation: {Occupation}," +
                $" City_Category: {City_Category}," +
                $" Stay_In_Current_City_Years: {Stay_In_Current_City_Years}," +
                $" Marital_Status: {Marital_Status}," +
                $" Product_Category_1: {Product_Category_1}," +
                $" Product_Category_2: {Product_Category_2}," +
                $" Product_Category_3: {Product_Category_3}," +
                $" Purchase: {Purchase}";
        }
    }
}
