using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager3.Model.Requests
{
    public class RezervacijaTreningaInsertRequest
    {
        public int? PolaznikID { get; set; }
        public int? TreningID { get; set; }
        public DateTime? DatumVrijeme { get; set; }
    }
}
