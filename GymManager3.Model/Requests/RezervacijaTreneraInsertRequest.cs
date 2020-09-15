using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager3.Model.Requests
{
    public class RezervacijaTreneraInsertRequest
    {
        public int? PolaznikID { get; set; }
        public int? TrenerID { get; set; }
        public int? SlobodniTerminiID { get; set; }
    }
}
