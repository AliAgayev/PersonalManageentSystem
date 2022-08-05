using PersonalManagamentSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalManagamentSystem.DAL
{
   public class DataOperations
    {
        public static List<Personal> Personals { get; set; }


        public static List<WorkTime> WorkTimes { get; set; }

        static DataOperations()
        {
            Personals = new List<Personal>();
            WorkTimes = new List<WorkTime>();
        }
    }
}
