using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager3.Model
{
    public class Subskripcija
    {
        public int SubskripcijaId { get; set; }
        public int? TreningId { get; set; }
        public int? VrstaSubskripcijeId { get; set; }
        public string Opis { get; set; }
        public string Vrsta { get; set; }
        public string Trajanje { get; set; }
        public bool? Otkazano { get; set; }
    }
}
