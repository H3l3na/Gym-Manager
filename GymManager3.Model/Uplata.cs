using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager3.Model
{
    public partial class Uplata
    {
        public int UplataId { get; set; }
        public int? AdministracijaId { get; set; }
        public int? PolaznikId { get; set; }
        public int? SubskripcijaId { get; set; }
        public double? Iznos { get; set; }
        public string Svrha { get; set; }
        public DateTime? DatumUplate { get; set; }

    }
}
