using System;
using System.Collections.Generic;

namespace GymManager3.WebAPI.Database
{
    public partial class VrstaSubskripcije
    {
        public VrstaSubskripcije()
        {
            Subskripcija = new HashSet<Subskripcija>();
        }

        public int VrstaSubskripcijeId { get; set; }
        public string Vrsta { get; set; }
        public string Detalji { get; set; }

        public virtual ICollection<Subskripcija> Subskripcija { get; set; }
    }
}
