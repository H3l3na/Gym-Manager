using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Database
{
    public class RezervacijaTreninga
    {
        public int RezervacijaTreningaID { get; set; }
        public int? PolaznikID { get; set; }
        public int? TreningID { get; set; }
        public DateTime? DatumVrijeme { get; set; }
        public virtual Polaznik Polaznik { get; set; }
        public virtual Trening Trening { get; set; }
    }
}
