using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager3.Model
{
    public class treneri
    {
        public int TrenerId { get; set; }
        public int? GradID { get; set; }
        public string Ime { get; set; }
       // public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Adresa { get; set; }
        public string JMBG { get; set; }
        public DateTime? DatumZaposlenja { get; set; }
        public string Spol { get; set; }
        public string Opis { get; set; }
        public int? BrojOcjena { get; set; }

        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public string KorisnickoIme { get; set; }
        public string Uloga { get; set; }
        public byte[] Slika { get; set; }
    }
}
