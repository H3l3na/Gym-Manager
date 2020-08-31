using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Database
{
    public partial class KorisniciUloge
    {
        public int KorisnikUlogaID { get; set; }
        public int? PolaznikID { get; set; }
        public int? TrenerID { get; set; }
        public int? AdministracijaID { get; set; }
        public DateTime? DatumIzmjene { get; set; }
        public int? UlogaID { get; set; }

        public Administracija Administracija { get; set; }
        public Polaznik Polaznik { get; set; }
        public Trener Trener { get; set; }
        public Uloge Uloga { get; set; }
    }
}
