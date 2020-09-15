using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Database
{
    public class RezervacijaTrenera
    { 
        public int RezervacijaTreneraID { get; set; }
        public int? TrenerID { get; set; }
        public int? PolaznikID { get; set; }
        public int? SlobodniTerminiID { get; set; }
        public virtual Polaznik Polaznik { get; set; }
        public virtual Trener Trener{ get; set; }
    }
}
