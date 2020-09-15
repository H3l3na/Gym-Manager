using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymManager3.Model.Requests
{
    public class PolazniciInsertRequest
    {
        [Required]
        //[MinLength(3)]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [EmailAddress]
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public string Password { get; set; }
        public string PasswordPotvrda { get; set; }
        public int? GradId { get; set; }
        public string Uloga { get; set; }
        public string KorisnickoIme { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string JMBG { get; set; }
    }
}
