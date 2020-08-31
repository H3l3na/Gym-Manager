using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymManager3.Model.Requests
{
    public class TreneriInsertRequest
    {
        //public int? GradId { get; set; }
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
        public bool? Spol { get; set; }
        public string Opis { get; set; }
        
        public int? GradId { get; set; }
        public string KorisnickoIme { get; set; }
        public string Uloga { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public byte[] Slika { get; set; }
    }
}
