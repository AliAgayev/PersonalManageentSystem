using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalManagamentSystem.Models
{
    public class WorkTime
    {
        public int PersonalNum { get; set; }
        public Personal PersonalNumber { get; set; }
        public int Date { get; set; }
        public int EntryHour { get; set; }
        public int EntryMinute { get; set; }
        public int Exithour { get; set; }
        public int ExitMinute { get; set; }

        //public override string ToString()
        //{
        //    return $"İşçi nömrəsi: {PersonalNumber} \n Tarix:{Date} \n Giriş saati: {EntryHour} \n Giris deqiqesi:{EntryMinute} \n Cıxış saatı:{Exithour} \n Cıxış dəqiqəsi:{ExitMinute}";
        //}

    }
}
