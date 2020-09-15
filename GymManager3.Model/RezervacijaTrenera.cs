using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager3.Model
{
    public class RezervacijaTrenera
    {
        public int RezervacijaTreneraID { get; set; }
        public int? PolaznikID { get; set; }
        public int? TrenerID { get; set; }
        public int? SlobodniTerminiID { get; set; }
        //public string Polaznik { get; set; }
        //public string Trener { get; set; }
    }
}
