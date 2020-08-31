using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager3.Model
{
    public partial class KorisniciUloge
    {
        public int KorisnikUlogaID { get; set; }
        public int? AdministracijaID { get; set; }
        public int? PolaznikID { get; set; }
        public int? TrenerID { get; set; }
        public int UlogaID{ get; set; }
        public DateTime DatumIzmjene { get; set; }

        //public Administracija Administracija { get; set; }
        //public Polaznik Polaznik { get; set; }
        //public Trener Trener { get; set; }
        //public Uloge Uloga { get; set; }
    }
}
