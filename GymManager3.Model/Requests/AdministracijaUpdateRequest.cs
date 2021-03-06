﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymManager3.Model.Requests
{
    public class AdministracijaUpdateRequest
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [EmailAddress]
        public string Mail { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public int Staz { get; set; }
        public string JMBG { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public DateTime? DatumZaposlenja { get; set; }
        public string Username { get; set; }
    }
}
