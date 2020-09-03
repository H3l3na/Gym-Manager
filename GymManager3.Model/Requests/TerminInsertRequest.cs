using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager3.Model.Requests
{
    public class TerminInsertRequest
    {
        //public int TerminID { get; set; }
        public DateTime? TerminOdrzavanja { get; set; }
        public int? MaxBrPolaznika { get; set; }
        public string Sala { get; set; }
        public int? TreningId { get; set; }
       // public string Trening { get; set; }
        public int? TrenerId { get; set; }
       /// public string Trener { get; set; }
    }
}
