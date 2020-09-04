using System;
using System.Collections.Generic;

namespace GymManager3.WebAPI.Database
{
    public partial class Trening
    {
        public Trening()
        {
            Pohadja = new HashSet<Pohadja>();
            Subskripcija = new HashSet<Subskripcija>();
            RezervacijaTreninga = new HashSet<RezervacijaTreninga>();
        }

        public int TreningId { get; set; }
        public int? TrenerId { get; set; }
        public int? VrstaTreningaId { get; set; }
        public string Naziv { get; set; }
        public string Tezina { get; set; }
        public string Opis { get; set; }
        public string Preduvjeti { get; set; }
        public double? Cijena { get; set; }
        public DateTime? TerminOdrzavanja { get; set; }

        public virtual Trener Trener { get; set; }
        public virtual VrstaTreninga VrstaTreninga { get; set; }
        public virtual ICollection<Pohadja> Pohadja { get; set; }
        public virtual ICollection<Subskripcija> Subskripcija { get; set; }
        public virtual ICollection<RezervacijaTreninga> RezervacijaTreninga { get; set; }
    }
}
