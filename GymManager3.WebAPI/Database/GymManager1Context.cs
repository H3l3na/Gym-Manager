using System;
using System.IO;
using GymManager3.Model;
using GymManager3.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GymManager3.WebAPI.Database
{
    public partial class GymManager1Context : DbContext
    {
        public GymManager1Context()
        {
        }

        public GymManager1Context(DbContextOptions<GymManager1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Administracija> Administracija { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Pohadja> Pohadja { get; set; }
        public virtual DbSet<Polaznik> Polaznik { get; set; }
        public virtual DbSet<Subskripcija> Subskripcija { get; set; }
        public virtual DbSet<Termin> Termin { get; set; }
        public virtual DbSet<Trener> Trener { get; set; }
        public virtual DbSet<Trening> Trening { get; set; }
        public virtual DbSet<Uplata> Uplata { get; set; }
        public virtual DbSet<VrstaSubskripcije> VrstaSubskripcije { get; set; }
        public virtual DbSet<VrstaTreninga> VrstaTreninga { get; set; }
        public virtual DbSet<Uloge> Uloge { get; set; }
        public virtual DbSet<KorisniciUloge> KorisniciUloge { get; set; }
        public virtual DbSet<RezervacijaTreninga> RezervacijaTreninga { get; set; }
        public virtual DbSet<RezervacijaTrenera> RezervacijaTrenera { get; set; }
        public virtual DbSet<SlobodniTermini> SlobodniTermini { get; set; }
        public virtual DbSet<Ocjene> Ocjene { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(local);Database=GymManager13;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Uloge>().ToTable("Uloge");
            modelBuilder.Entity<KorisniciUloge>().ToTable("KorisniciUloge");
            modelBuilder.Entity<RezervacijaTreninga>().ToTable("RezervacijaTreninga");
           // modelBuilder.Entity<Termin>().ToTable("Termin");

            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Administracija>(entity =>
            {
                entity.HasIndex(e => e.Mail)
                    .HasName("UQ__Administ__2724B2D1E46225C0")
                    .IsUnique();

                entity.Property(e => e.AdministracijaId).HasColumnName("AdministracijaID");

                entity.Property(e => e.DatumRodjenja).HasColumnType("date");

                entity.Property(e => e.DatumZaposlenja).HasColumnType("date");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Jmbg)
                    .HasColumnName("JMBG")
                    .HasMaxLength(13);

                entity.Property(e => e.Mail).HasMaxLength(100);

                entity.Property(e => e.Telefon).HasMaxLength(12);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Administracija)
                    .HasForeignKey(d => d.GradId)
                    .HasConstraintName("FK__Administr__GradI__1367E606");
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.Property(e => e.GradId).HasColumnName("GradID");
            });
            modelBuilder.Entity<SlobodniTermini>(entity =>
            {
                entity.Property(e => e.SlobodniTerminiID).HasColumnName("SlobodniTerminiID");
                entity.Property(e => e.Termin).HasColumnType("datetime");
            });

            modelBuilder.Entity<Pohadja>(entity =>
            {
                entity.Property(e => e.PohadjaId).HasColumnName("PohadjaID");

                entity.Property(e => e.PolaznikId).HasColumnName("PolaznikID");

                entity.Property(e => e.TerminId).HasColumnName("TerminID");

                entity.Property(e => e.TreningId).HasColumnName("TreningID");

                entity.HasOne(d => d.Polaznik)
                    .WithMany(p => p.Pohadja)
                    .HasForeignKey(d => d.PolaznikId)
                    .HasConstraintName("FK__Pohadja__Polazni__267ABA7A");

                entity.HasOne(d => d.Termin)
                    .WithMany(p => p.Pohadja)
                    .HasForeignKey(d => d.TerminId)
                    .HasConstraintName("FK__Pohadja__TerminI__286302EC");

                entity.HasOne(d => d.Trening)
                    .WithMany(p => p.Pohadja)
                    .HasForeignKey(d => d.TreningId)
                    .HasConstraintName("FK__Pohadja__Trening__276EDEB3");
            });

            modelBuilder.Entity<Polaznik>(entity =>
            {
                entity.HasIndex(e => e.Mail)
                    .HasName("UQ__Polaznik__2724B2D12A306324")
                    .IsUnique();

                entity.Property(e => e.PolaznikId).HasColumnName("PolaznikID");

                entity.Property(e => e.DatumRodjenja).HasColumnType("date");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.JMBG)
                    .HasColumnName("JMBG")
                    .HasMaxLength(13);

                entity.Property(e => e.Mail).HasMaxLength(100);

                entity.Property(e => e.Telefon).HasMaxLength(12);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Polaznik)
                    .HasForeignKey(d => d.GradId)
                    .HasConstraintName("FK__Polaznik__GradID__1B0907CE");
            });

            modelBuilder.Entity<Subskripcija>(entity =>
            {
                entity.Property(e => e.SubskripcijaId).HasColumnName("SubskripcijaID");

                entity.Property(e => e.TreningId).HasColumnName("TreningID");

                entity.Property(e => e.VrstaSubskripcijeId).HasColumnName("VrstaSubskripcijeID");

                entity.HasOne(d => d.Trening)
                    .WithMany(p => p.Subskripcija)
                    .HasForeignKey(d => d.TreningId)
                    .HasConstraintName("FK__Subskripc__Treni__2B3F6F97");

                entity.HasOne(d => d.VrstaSubskripcije)
                    .WithMany(p => p.Subskripcija)
                    .HasForeignKey(d => d.VrstaSubskripcijeId)
                    .HasConstraintName("FK__Subskripc__Vrsta__2C3393D0");
            });

            modelBuilder.Entity<Termin>(entity =>
            {
                entity.Property(e => e.TerminId).HasColumnName("TerminID");

                entity.Property(e => e.TerminOdrzavanja).HasColumnType("datetime");
                entity.Property(e => e.MaxBrPolaznika).HasColumnType("int");
                entity.Property(e => e.TrenerId).HasColumnName("TrenerID");
                entity.Property(e => e.TreningId).HasColumnName("TreningID");
                entity.HasOne(d => d.Trening);
                entity.HasOne(d => d.Trener);
                     //.WithMany(p => p.Subskripcija)
                     //.HasForeignKey(d => d.TreningId)
                     //.HasConstraintName("FK__Subskripc__Treni__2B3F6F97");
                //.WithMany(p => p.Pohadja)
                //   .HasForeignKey(d => d.TreningId)
                //   .HasConstraintName("FK__Trening");
            });

            modelBuilder.Entity<Trener>(entity =>
            {
                entity.Property(e => e.TrenerId).HasColumnName("TrenerID");

                entity.Property(e => e.DatumZaposlenja).HasColumnType("date");

                entity.Property(e => e.GradId).HasColumnName("GradID");
                //entity.Property(e => e.BrojOcjena).HasColumnName("BrojOcjena");

                entity.Property(e => e.Jmbg)
                    .HasColumnName("JMBG")
                    .HasMaxLength(13);

                entity.Property(e => e.Mail).HasMaxLength(100);

                entity.Property(e => e.Telefon).HasMaxLength(12);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Trener)
                    .HasForeignKey(d => d.GradId)
                    .HasConstraintName("FK__Trener__GradID__1DE57479");
            });

            modelBuilder.Entity<Trening>(entity =>
            {
                entity.Property(e => e.TreningId).HasColumnName("TreningID");

                entity.Property(e => e.Tezina).HasMaxLength(50);

                entity.Property(e => e.TrenerId).HasColumnName("TrenerID");

                entity.Property(e => e.VrstaTreningaId).HasColumnName("VrstaTreningaID");
                entity.Property(e => e.TerminOdrzavanja).HasColumnName("TerminOdrzavanja");

                entity.HasOne(d => d.Trener)
                    .WithMany(p => p.Trening)
                    .HasForeignKey(d => d.TrenerId)
                    .HasConstraintName("FK__Trening__TrenerI__22AA2996");

                entity.HasOne(d => d.VrstaTreninga)
                    .WithMany(p => p.Trening)
                    .HasForeignKey(d => d.VrstaTreningaId)
                    .HasConstraintName("FK__Trening__VrstaTr__239E4DCF");
            });

            modelBuilder.Entity<Uplata>(entity =>
            {
                entity.Property(e => e.UplataId).HasColumnName("UplataID");

                entity.Property(e => e.AdministracijaId).HasColumnName("AdministracijaID");

                entity.Property(e => e.DatumUplate).HasColumnType("date");

                entity.Property(e => e.PolaznikId).HasColumnName("PolaznikID");

                entity.Property(e => e.SubskripcijaId).HasColumnName("SubskripcijaID");

                entity.HasOne(d => d.Administracija)
                    .WithMany(p => p.Uplata)
                    .HasForeignKey(d => d.AdministracijaId)
                    .HasConstraintName("FK__Uplata__Administ__2F10007B");

                entity.HasOne(d => d.Polaznik)
                    .WithMany(p => p.Uplata)
                    .HasForeignKey(d => d.PolaznikId)
                    .HasConstraintName("FK__Uplata__Polaznik__300424B4");

                entity.HasOne(d => d.Subskripcija)
                    .WithMany(p => p.Uplata)
                    .HasForeignKey(d => d.SubskripcijaId)
                    .HasConstraintName("FK__Uplata__Subskrip__30F848ED");
            });

            modelBuilder.Entity<VrstaSubskripcije>(entity =>
            {
                entity.Property(e => e.VrstaSubskripcijeId).HasColumnName("VrstaSubskripcijeID");
            });

            modelBuilder.Entity<VrstaTreninga>(entity =>
            {
                entity.Property(e => e.VrstaTreningaId).HasColumnName("VrstaTreningaID");
            });
            modelBuilder.Entity<KorisniciUloge>(entity =>
            {
                entity.HasKey(e => e.KorisnikUlogaID);

                entity.Property(e => e.KorisnikUlogaID).HasColumnName("KorisnikUlogaID");

                entity.Property(e => e.AdministracijaID).HasColumnName("AdministracijaID");

                entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

                entity.Property(e => e.PolaznikID).HasColumnName("PolaznikID");

                entity.Property(e => e.TrenerID).HasColumnName("TrenerID");

                entity.Property(e => e.UlogaID).HasColumnName("UlogaID");

                entity.HasOne(d => d.Administracija)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.AdministracijaID)
                    .HasConstraintName("AdministracijaID_FK_23242431");

                entity.HasOne(d => d.Polaznik)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.PolaznikID)
                    .HasConstraintName("PolaznikID_FK_5");

                entity.HasOne(d => d.Trener)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.TrenerID)
                    .HasConstraintName("TrenerID_FK_5");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.UlogaID)
                    .HasConstraintName("UlogaID_FK_2");
            });
            modelBuilder.Entity<Uloge>(entity =>
            {
                entity.HasKey(e => e.UlogaId);

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Opis).HasMaxLength(200);
            });
            modelBuilder.Entity<RezervacijaTreninga>(entity =>
            {
                entity.HasKey(e => e.RezervacijaTreningaID);
                entity.Property(e => e.RezervacijaTreningaID).HasColumnName("RezervacijaTreningaID");
                entity.Property(e => e.PolaznikID).HasColumnName("PolaznikID");

                entity.Property(e => e.TreningID).HasColumnName("TreningID");
                entity.HasOne(d => d.Polaznik)
                    .WithMany(p => p.RezervacijaTreninga)
                    .HasForeignKey(d => d.PolaznikID)
                    .HasConstraintName("PolaznikID_FK_2");

                entity.HasOne(d => d.Trening)
                    .WithMany(p => p.RezervacijaTreninga)
                    .HasForeignKey(d => d.TreningID)
                    .HasConstraintName("TreningID_FK_1");

                entity.Property(e => e.DatumVrijeme).HasColumnType("datetime");

            });
            modelBuilder.Entity<RezervacijaTrenera>(entity =>
            {
                entity.HasKey(e => e.RezervacijaTreneraID);
                entity.Property(e => e.RezervacijaTreneraID).HasColumnName("RezervacijaTreneraID");
                entity.Property(e => e.PolaznikID).HasColumnName("PolaznikID");

                entity.Property(e => e.TrenerID).HasColumnName("TrenerID");
                entity.Property(e => e.SlobodniTerminiID).HasColumnName("SlobodniTerminiID");
                entity.HasOne(d => d.Polaznik)
                    .WithMany(p => p.RezervacijaTrenera)
                    .HasForeignKey(d => d.PolaznikID)
                    .HasConstraintName("PolaznikID_FK");

                entity.HasOne(d => d.Trener)
                    .WithMany(p => p.RezervacijaTrenera)
                    .HasForeignKey(d => d.TrenerID)
                    .HasConstraintName("TrenerID_FK_21232");

                

            });
            modelBuilder.Entity<Ocjene>(entity =>
            {
                entity.HasKey(e => e.OcjeneID);
                entity.Property(e => e.OcjeneID).HasColumnName("OcjeneID");
                entity.Property(e => e.PolaznikID).HasColumnName("PolaznikID");

                entity.Property(e => e.TrenerID).HasColumnName("TrenerID");
                entity.Property(e => e.Ocjena).HasColumnName("Ocjena");
                entity.HasOne(d => d.Polaznik)
                    .WithMany(p => p.Ocjene)
                    .HasForeignKey(d => d.PolaznikID)
                    .HasConstraintName("PolaznikID_FK_3");

                entity.HasOne(d => d.Trener)
                    .WithMany(p => p.Ocjene)
                    .HasForeignKey(d => d.TrenerID)
                    .HasConstraintName("TrenerID_FK_4");



            });
            InitialiseData(modelBuilder);

        }
        void InitialiseData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grad>().HasData(new Grad()
            {
                GradId=1,
                Naziv="Gračanica",
                PostanskiBr=75320,
                Skracenica="Gr"
            });
            modelBuilder.Entity<Grad>().HasData(new Grad()
            {
                GradId = 2,
                Naziv = "Sarajevo",
                PostanskiBr = 71000,
                Skracenica = "SA"
            });
            modelBuilder.Entity<Grad>().HasData(new Grad()
            {
                GradId = 3,
                Naziv = "Mostar",
                PostanskiBr = 88000,
                Skracenica = "MO"
            });
            Polaznik p = new Polaznik
            {
                Ime="Alma",
                Prezime="Djedovic",
                Spol="Ž",
                Adresa="Olovska 103A",
                GradId=2,
                DatumRodjenja=DateTime.Parse("2020-04-25"),
                JMBG="2504996127155",
                Mail="alma@gmail.com",
                PolaznikId=1,
                Telefon="062365144",
                Uloga="Polaznik",
                KorisnickoIme="alma123"
            };
            p.LozinkaSalt = PolaznikService.GenerateSalt();
            p.LozinkaHash = PolaznikService.GenerateHash(p.LozinkaSalt, "alma");
            modelBuilder.Entity<Polaznik>().HasData(p);

            Polaznik p1 = new Polaznik
            {
                Ime = "Amela",
                Prezime = "Cosic",
                Spol = "Ž",
                Adresa = "Olovska 103B",
                GradId = 2,
                DatumRodjenja = DateTime.Parse("2020-09-20"),
                JMBG = "2009996127155",
                Mail = "amela@gmail.com",
                PolaznikId = 2,
                Telefon = "062341184",
                Uloga = "Polaznik",
                KorisnickoIme = "amela123"
            };
            p1.LozinkaSalt = PolaznikService.GenerateSalt();
            p1.LozinkaHash = PolaznikService.GenerateHash(p1.LozinkaSalt, "amela");
            modelBuilder.Entity<Polaznik>().HasData(p1);

            Administracija a = new Administracija
            {
                Ime = "Admin",
                Prezime = "Admin",
                Spol = "M",
                Staz=1,
                AdministracijaId=1,
                Adresa="Dzemala Bijedica 100",
                GradId=2,
                DatumRodjenja=DateTime.Parse("2020-02-02"),
                DatumZaposlenja=DateTime.Parse("2020-01-01"),
                Jmbg="1002003004001",
                Mail="admin@gmail.com",
                Telefon="061834223",
                Uloga="Administrator",
                KorisnickoIme="admin",
            };
            a.LozinkaSalt = AdministracijaService.GenerateSalt();
            a.LozinkaHash = AdministracijaService.GenerateHash(a.LozinkaSalt, "admin");
            modelBuilder.Entity<Administracija>().HasData(a);

            Trener t = new Trener
            {
                Ime = "Dwayne",
                Prezime = "Johnson",
                Spol = "M",
                Adresa = "Olovska 105",
                GradId = 2,
                DatumZaposlenja = DateTime.Parse("2020-04-04"),
                Jmbg = "1112223334441",
                Mail="dwayne@gmail.com",
                Opis="Professional fitness trainer",
                KorisnickoIme="therock",
                Telefon="061724122",
                TrenerId=1,
                Uloga="Trener",
                Slika= File.ReadAllBytes("img/therock.jpg")
            };
            t.LozinkaSalt = TreneriService.GenerateSalt();
            t.LozinkaHash = TreneriService.GenerateHash(t.LozinkaSalt, "dwayne");
            modelBuilder.Entity<Trener>().HasData(t);

            Trener t1 = new Trener
            {
                Ime="Arnold",
                Prezime="Schwarzeneger",
                Spol = "M",
                Adresa = "Olovska 106",
                GradId = 2,
                DatumZaposlenja = DateTime.Parse("2020-08-08"),
                Jmbg = "1112223334442",
                Mail = "arnold@gmail.com",
                Opis = "Professional fitness trainer",
                KorisnickoIme = "arnie",
                Telefon = "061724552",
                TrenerId = 2,
                Uloga="Trener",
                Slika= File.ReadAllBytes("img/therock.jpg")
            };
            t1.LozinkaSalt = TreneriService.GenerateSalt();
            t1.LozinkaHash = TreneriService.GenerateHash(t1.LozinkaSalt, "arnold");
            modelBuilder.Entity<Trener>().HasData(t1);

            Trener t2 = new Trener
            {
                Ime = "Gal",
                Prezime = "Gadot",
                Spol = "Ž",
                Adresa = "Olovska 107",
                GradId = 2,
                DatumZaposlenja = DateTime.Parse("2020-03-09"),
                Jmbg = "1112223334222",
                Mail = "gal@gmail.com",
                Opis = "Professional fitness trainer",
                KorisnickoIme = "gal123",
                Telefon = "061724332",
                TrenerId = 3,
                Uloga="Trener",
                Slika= File.ReadAllBytes("img/gal.jpg")
            };
            t2.LozinkaSalt = TreneriService.GenerateSalt();
            t2.LozinkaHash = TreneriService.GenerateHash(t2.LozinkaSalt, "gal");
            modelBuilder.Entity<Trener>().HasData(t2);

            modelBuilder.Entity<VrstaTreninga>().HasData(new VrstaTreninga()
            {
                VrstaTreningaId = 1,
                Naziv = "Weightlifting",
                Vrsta = "Strength training",
                Tezina = "Srednja"
            });
            modelBuilder.Entity<VrstaTreninga>().HasData(new VrstaTreninga()
            {
                VrstaTreningaId = 2,
                Naziv = "Yoga",
                Vrsta = "Cardio training",
                Tezina = "Mala"
            });
            modelBuilder.Entity<VrstaTreninga>().HasData(new VrstaTreninga()
            {
                VrstaTreningaId = 3,
                Naziv = "Fitness",
                Vrsta = "Fitness training",
                Tezina = "Srednja"
            });

            modelBuilder.Entity<Trening>().HasData(new WebAPI.Database.Trening()
            {
                TreningId = 1,
                Naziv = "Weightlifting 101",
                Cijena = 500,
                Kapacitet = 30,
                Opis = "Weight lifting intermediate",
                Preduvjeti = "Intro to weightlifting",
                TrenerId = 1,
                VrstaTreningaId = 1,
                Tezina = "Intermediate",
                TerminOdrzavanja = DateTime.Parse("2020-09-10"),
            });
            modelBuilder.Entity<Trening>().HasData(new WebAPI.Database.Trening()
            {
                TreningId = 2,
                Naziv = "Pro weightlifting",
                Cijena = 1000,
                Kapacitet = 15,
                Opis = "Competitive weightlifting course",
                Preduvjeti = "Weightlifting intermediate",
                TrenerId = 2,
                VrstaTreningaId = 1,
                Tezina = "Advanced",
                TerminOdrzavanja = DateTime.Parse("2020-09-12"),
            });
            modelBuilder.Entity<Trening>().HasData(new WebAPI.Database.Trening()
            {
                TreningId = 3,
                Naziv = "Fitness training",
                Cijena = 150,
                Kapacitet = 20,
                Opis = "Fitness training intermediate",
                Preduvjeti = "Fitness for beginners",
                TrenerId = 3,
                VrstaTreningaId = 3,
                Tezina = "Intermediate",
                TerminOdrzavanja = DateTime.Parse("2020-09-11"),
            });
            modelBuilder.Entity<VrstaSubskripcije>().HasData(new VrstaSubskripcije()
            {
                VrstaSubskripcijeId=1,
                Vrsta="Mjesecna",
                Detalji="Monthly subscription package"
            });
            modelBuilder.Entity<VrstaSubskripcije>().HasData(new VrstaSubskripcije()
            {
                VrstaSubskripcijeId = 2,
                Vrsta = "Godisnja",
                Detalji = "Yearly subscription package"
            });
            modelBuilder.Entity<Subskripcija>().HasData(new WebAPI.Database.Subskripcija()
            {
                SubskripcijaId=1,
                VrstaSubskripcijeId=1,
                Opis="Subscription",
                Trajanje="30",
                TreningId=1,
                Vrsta="Mjesecna"
            });

            modelBuilder.Entity<Uplata>().HasData(new WebAPI.Database.Uplata()
            {
                UplataId = 1,
                AdministracijaId = 1,
                PolaznikId = 1,
                SubskripcijaId = 1,
                Svrha = "Uplata za trening",
                Iznos = 200,
                DatumUplate = DateTime.Parse("2020-05-05")
            });
            modelBuilder.Entity<Uplata>().HasData(new WebAPI.Database.Uplata()
            {
                UplataId = 2,
                AdministracijaId = 1,
                PolaznikId = 2,
                SubskripcijaId = 1,
                Svrha = "Uplata za koristenje svlacionice",
                Iznos = 50,
                DatumUplate = DateTime.Parse("2020-06-05")
            });
            modelBuilder.Entity<SlobodniTermini>().HasData(new WebAPI.Database.SlobodniTermini()
            {
                SlobodniTerminiID = 1,
                Termin = DateTime.Parse("2020-05-05")
            });
            modelBuilder.Entity<SlobodniTermini>().HasData(new WebAPI.Database.SlobodniTermini()
            {
                SlobodniTerminiID = 2,
                Termin = DateTime.Parse("2020-05-06")
            });
            modelBuilder.Entity<SlobodniTermini>().HasData(new WebAPI.Database.SlobodniTermini()
            {
                SlobodniTerminiID = 3,
                Termin = DateTime.Parse("2020-05-07")
            });
            modelBuilder.Entity<SlobodniTermini>().HasData(new WebAPI.Database.SlobodniTermini()
            {
                SlobodniTerminiID = 4,
                Termin = DateTime.Parse("2020-05-08")
            });
            modelBuilder.Entity<SlobodniTermini>().HasData(new WebAPI.Database.SlobodniTermini()
            {
                SlobodniTerminiID = 5,
                Termin = DateTime.Parse("2020-05-09")
            });
            modelBuilder.Entity<Termin>().HasData(new WebAPI.Database.Termin()
            {
                TerminId=1,
                Sala="Sala 1",
                TrenerId=1,
                TreningId=1,
                TerminOdrzavanja= DateTime.Parse("2020-09-10"),
                MaxBrPolaznika=30
            });
            modelBuilder.Entity<Termin>().HasData(new WebAPI.Database.Termin()
            {
                TerminId = 2,
                Sala = "Sala 2",
                TrenerId = 2,
                TreningId = 2,
                TerminOdrzavanja = DateTime.Parse("2020-09-12"),
                MaxBrPolaznika = 15
            });
            modelBuilder.Entity<Termin>().HasData(new WebAPI.Database.Termin()
            {
                TerminId = 3,
                Sala = "Sala 3",
                TrenerId = 3,
                TreningId = 3,
                TerminOdrzavanja = DateTime.Parse("2020-09-11"),
                MaxBrPolaznika = 20
            });
            modelBuilder.Entity<RezervacijaTreninga>().HasData(new WebAPI.Database.RezervacijaTreninga()
            {
                RezervacijaTreningaID=1,
                PolaznikID=1,
                TreningID=1,
                DatumVrijeme= DateTime.Parse("2020-09-10")
            });
            modelBuilder.Entity<RezervacijaTreninga>().HasData(new WebAPI.Database.RezervacijaTreninga()
            {
                RezervacijaTreningaID = 2,
                PolaznikID = 1,
                TreningID = 2,
                DatumVrijeme = DateTime.Parse("2020-09-12")
            });
            modelBuilder.Entity<RezervacijaTreninga>().HasData(new WebAPI.Database.RezervacijaTreninga()
            {
                RezervacijaTreningaID = 3,
                PolaznikID = 2,
                TreningID = 3,
                DatumVrijeme = DateTime.Parse("2020-09-11")
            });
            modelBuilder.Entity<RezervacijaTrenera>().HasData(new WebAPI.Database.RezervacijaTrenera()
            {
                RezervacijaTreneraID=1,
                SlobodniTerminiID=1,
                PolaznikID=1,
                TrenerID=1
            });
            modelBuilder.Entity<Ocjene>().HasData(new WebAPI.Database.Ocjene()
            {
                OcjeneID = 1,
                Ocjena = 10,
                PolaznikID = 1,
                TrenerID = 1
            });
            modelBuilder.Entity<Ocjene>().HasData(new WebAPI.Database.Ocjene()
            {
                OcjeneID = 2,
                Ocjena = 10,
                PolaznikID = 1,
                TrenerID = 2
            });
        }
     }
}
