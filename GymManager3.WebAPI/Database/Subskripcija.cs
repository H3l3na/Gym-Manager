using System;
using System.Collections.Generic;

namespace GymManager3.WebAPI.Database
{
    public partial class Subskripcija
    {
        public Subskripcija()
        {
            Uplata = new HashSet<Uplata>();
        }

        public int SubskripcijaId { get; set; }
        public int? TreningId { get; set; }
        public int? VrstaSubskripcijeId { get; set; }
        public string Opis { get; set; }
        public string Vrsta { get; set; }
        public string Trajanje { get; set; }
        public bool? Otkazano { get; set; }

        public virtual Trening Trening { get; set; }
        public virtual VrstaSubskripcije VrstaSubskripcije { get; set; }
        public virtual ICollection<Uplata> Uplata { get; set; }
    }
}
