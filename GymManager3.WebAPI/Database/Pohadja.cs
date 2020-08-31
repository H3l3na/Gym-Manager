using System;
using System.Collections.Generic;

namespace GymManager3.WebAPI.Database
{
    public partial class Pohadja
    {
        public int PohadjaId { get; set; }
        public int? PolaznikId { get; set; }
        public int? TreningId { get; set; }
        public int? TerminId { get; set; }
        public bool? Odrzano { get; set; }
        public string Opis { get; set; }

        public virtual Polaznik Polaznik { get; set; }
        public virtual Termin Termin { get; set; }
        public virtual Trening Trening { get; set; }
    }
}
