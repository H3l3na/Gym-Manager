using System;
using System.Collections.Generic;

namespace GymManager3.WebAPI.Database
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

        public virtual Administracija Administracija { get; set; }
        public virtual Polaznik Polaznik { get; set; }
        public virtual Subskripcija Subskripcija { get; set; }
    }
}
