using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager3.Model
{
    public class RezervacijaTreninga
    {
        public int RezervacijaTreningaID { get; set; }
        public int? PolaznikID { get; set; }
        public int? TreningID { get; set; }
        public string Trening { get; set; }
        public DateTime? DatumVrijeme { get; set; }
    }
}
