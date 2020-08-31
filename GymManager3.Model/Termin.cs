using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager3.Model
{
    public class Termin
    {
        public int TerminID { get; set; }
        public DateTime? TerminOdrzavanja { get; set; }
        public int? MaxBrPolaznika { get; set; }
        public string Sala { get; set; }
    }
}
