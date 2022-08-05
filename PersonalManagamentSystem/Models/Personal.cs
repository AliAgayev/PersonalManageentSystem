using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalManagamentSystem.Models
{
    public class Personal
    {
        public int PersonalNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime EntryTime { get; set; }
        public string Position { get; set; }
        public decimal WageRate { get; set; }
        public int TotalWorkingTimeinMonth { get; set; }
        //public override string ToString()
        //{
        //    return $"İşçi nömrəsi: {PersonalNumber} \n Adı: {Name} \n Soyadı: {Surname} \n İşe giriş tarixi: {EntryTime} \n Vezifesi:{Position} \n Emek haqqı emsali: {WageRate} \n Bir ayda calisdigi umumi vaxt: {TotalWorkingTimeinMonth}";
        //}
    }
}
