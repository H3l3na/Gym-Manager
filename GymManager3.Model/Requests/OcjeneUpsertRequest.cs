using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymManager3.Model.Requests
{
    public class OcjeneUpsertRequest
    {
        [Required]
        public int PolaznikID { get; set; }
        [Required]
        public int TrenerID { get; set; }
        [Required]
        public int Ocjena { get; set; }
    }
}
