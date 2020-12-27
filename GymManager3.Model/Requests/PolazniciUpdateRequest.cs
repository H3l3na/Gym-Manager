using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymManager3.Model.Requests
{
    public class PolazniciUpdateRequest
    {
        [Required]
        //[MinLength(3)]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [EmailAddress]
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public string JMBG { get; set; }
        public string Adresa { get; set;  }
        public string KorisnickoIme { get; set; }
    }
}
