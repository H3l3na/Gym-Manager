using System;
using System.Collections.Generic;

namespace GymManager3.WebAPI.Database
{
    public partial class VrstaTreninga
    {
        public VrstaTreninga()
        {
            Trening = new HashSet<Trening>();
        }

        public int VrstaTreningaId { get; set; }
        public string Naziv { get; set; }
        public string Vrsta { get; set; }
        public string Tezina { get; set; }

        public virtual ICollection<Trening> Trening { get; set; }
    }
}
