using System;
using System.Collections.Generic;

namespace GymManager3.WebAPI.Database
{
    public partial class Polaznik
    {
        public Polaznik()
        {
            Pohadja = new HashSet<Pohadja>();
            Uplata = new HashSet<Uplata>();
            KorisniciUloge = new HashSet<KorisniciUloge>();
            RezervacijaTreninga = new HashSet<RezervacijaTreninga>();
        }

        public int PolaznikId { get; set; }
        public int? GradId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Uloga { get; set; }
        public string Mail { get; set; }
        public string Adresa { get; set; }
        public string Jmbg { get; set; }
        public bool? Spol { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public DateTime? DatumRodjenja { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual ICollection<Pohadja> Pohadja { get; set; }
        public virtual ICollection<Uplata> Uplata { get; set; }
        public virtual ICollection<KorisniciUloge> KorisniciUloge { get; set; }
        public virtual ICollection<RezervacijaTreninga> RezervacijaTreninga { get; set; }
    }
}
