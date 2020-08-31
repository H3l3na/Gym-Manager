using System;
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=GymManager1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Uloge>().ToTable("Uloge");
            modelBuilder.Entity<KorisniciUloge>().ToTable("KorisniciUloge");
            modelBuilder.Entity<RezervacijaTreninga>().ToTable("RezervacijaTreninga");

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

                entity.Property(e => e.Jmbg)
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
            });

            modelBuilder.Entity<Trener>(entity =>
            {
                entity.Property(e => e.TrenerId).HasColumnName("TrenerID");

                entity.Property(e => e.DatumZaposlenja).HasColumnType("date");

                entity.Property(e => e.GradId).HasColumnName("GradID");

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
                    .HasConstraintName("AdministracijaID_FK");

                entity.HasOne(d => d.Polaznik)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.PolaznikID)
                    .HasConstraintName("PolaznikID_FK");

                entity.HasOne(d => d.Trener)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.TrenerID)
                    .HasConstraintName("TrenerID_FK");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.UlogaID)
                    .HasConstraintName("UlogaID_FK");
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
                    .HasConstraintName("PolaznikID_FK");

                entity.HasOne(d => d.Trening)
                    .WithMany(p => p.RezervacijaTreninga)
                    .HasForeignKey(d => d.TreningID)
                    .HasConstraintName("TreningID_FK");

                entity.Property(e => e.DatumVrijeme).HasColumnType("datetime");

            });


        }
    }
}
