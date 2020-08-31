using System;
using System.Collections.Generic;

namespace GymManager3.WebAPI.Database
{
    public partial class Termin
    {
        public Termin()
        {
            Pohadja = new HashSet<Pohadja>();
        }

        public int TerminId { get; set; }
        public DateTime? TerminOdrzavanja { get; set; }
        public int? MaxBrPolaznika { get; set; }
        public string Sala { get; set; }

        public virtual ICollection<Pohadja> Pohadja { get; set; }
    }
}
