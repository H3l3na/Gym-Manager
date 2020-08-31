using System;
using System.Collections.Generic;

namespace GymManager3.WebAPI.Database
{
    public partial class Trener
    {
        public Trener()
        {
            Trening = new HashSet<Trening>();
            KorisniciUloge = new HashSet<KorisniciUloge>();
        }

        public int TrenerId { get; set; }
        public int? GradId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public string Mail { get; set; }
        public string Adresa { get; set; }
        public string Jmbg { get; set; }
        public DateTime? DatumZaposlenja { get; set; }
        public bool? Spol { get; set; }
        public string Opis { get; set; }
        public byte[] Slika { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }

        public string Uloga { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual ICollection<Trening> Trening { get; set; }
        public ICollection<KorisniciUloge> KorisniciUloge { get; set; }
    }
}
