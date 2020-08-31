using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager3.Model
{
    public class Administracija
    {
        public int AdministracijaID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public bool StalanZaposlenik { get; set; }
        public int Staz { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public DateTime? DatumZaposlenja { get; set; }
        public string Uloga { get; set; }
        public string JMBG { get; set; }
        public int? GradId { get; set; }
        public string KorisnickoIme { get; set; }
        public byte[] Slika { get; set; }

        public ICollection<KorisniciUloge> KorisniciUloge { get; set; }
    }
}
