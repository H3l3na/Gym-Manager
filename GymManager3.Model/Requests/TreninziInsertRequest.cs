using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymManager3.Model.Requests
{
    public class TreninziInsertRequest
    {
        [Required]
        public string Naziv { get; set; }
        public string Tezina { get; set; }
        public string Opis { get; set; }
        public string Preduvjeti { get; set; }
        [Required]
        public double? Cijena { get; set; }
        public int? TrenerId { get; set; }
        public int? VrstaTreningaId { get; set; }
        public DateTime? TerminOdrzavanja { get; set; }
    }
}
