using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymManager3.Model.Requests
{
    public class TrenerUpdateRequest
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        [EmailAddress]
        public string Mail { get; set; }
        public string Adresa { get; set; }
        public string Jmbg { get; set; }
        public DateTime? DatumZaposlenja { get; set; }
        //public string Spol { get; set; }
        public string Opis { get; set; }
    }
}
