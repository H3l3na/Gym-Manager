using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymManager3.Model.Requests
{
    public class AdministracijaInsertRequest
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Uloga { get; set; }
        [Required]
        [EmailAddress]
        public string Mail { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public DateTime? DatumZaposlenja { get; set; }
        public int Staz { get; set; }
        public bool StalanZaposlenik { get; set; }
        public string JMBG { get; set; }
        public int? GradId { get; set; }
        public string KorisnickoIme { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public byte[] Slika { get; set; }

    }
}
