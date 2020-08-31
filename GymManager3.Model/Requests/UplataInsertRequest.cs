using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymManager3.Model.Requests
{
    public class UplataInsertRequest
    {
        [Required]
        public int? AdministracijaId { get; set; }
        [Required]
        public int? PolaznikId { get; set; }
        [Required]
        public int? SubskripcijaId { get; set; }
        [Required]
        public double? Iznos { get; set; }
        [Required]
        public string Svrha { get; set; }
        [Required]
        public DateTime? DatumUplate { get; set; }
    }
}
