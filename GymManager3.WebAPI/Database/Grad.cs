using System;
using System.Collections.Generic;

namespace GymManager3.WebAPI.Database
{
    public partial class Grad
    {
        public Grad()
        {
            Administracija = new HashSet<Administracija>();
            Polaznik = new HashSet<Polaznik>();
            Trener = new HashSet<Trener>();
        }

        public int GradId { get; set; }
        public string Naziv { get; set; }
        public int? PostanskiBr { get; set; }
        public string Skracenica { get; set; }

        public virtual ICollection<Administracija> Administracija { get; set; }
        public virtual ICollection<Polaznik> Polaznik { get; set; }
        public virtual ICollection<Trener> Trener { get; set; }
    }
}
