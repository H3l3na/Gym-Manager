using System;
using System.Collections.Generic;
using System.Text;


namespace GymManager3.Model
{
    public partial class Polaznik
    {

        public int PolaznikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Adresa { get; set; }
        public string Jmbg { get; set; }
        public bool? Spol { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public int? GradId { get; set; }
        public string Uloga { get; set; }
        public string KorisnickoIme { get; set; }

    }
        
    }
