using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager3.Model
{
    public class Trening
    {
        public int TreningId { get; set; }
        public string Naziv { get; set; }
        public string Tezina { get; set; }
        public string Opis { get; set; }
        public string Preduvjeti { get; set; }
        public double? Cijena { get; set; }
        public int? TrenerId { get; set; }
        public int? VrstaTreningaId { get; set; }
        public DateTime? TerminOdrzavanja { get; set; }
        public int Kapacitet { get; set; }
    }
}
