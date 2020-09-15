using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager3.WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    PostanskiBr = table.Column<int>(nullable: true),
                    Skracenica = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                });

            migrationBuilder.CreateTable(
                name: "SlobodniTermini",
                columns: table => new
                {
                    SlobodniTerminiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Termin = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlobodniTermini", x => x.SlobodniTerminiID);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    UlogaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false),
                    Opis = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.UlogaID);
                });

            migrationBuilder.CreateTable(
                name: "VrstaSubskripcije",
                columns: table => new
                {
                    VrstaSubskripcijeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vrsta = table.Column<string>(nullable: true),
                    Detalji = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaSubskripcije", x => x.VrstaSubskripcijeID);
                });

            migrationBuilder.CreateTable(
                name: "VrstaTreninga",
                columns: table => new
                {
                    VrstaTreningaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Vrsta = table.Column<string>(nullable: true),
                    Tezina = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaTreninga", x => x.VrstaTreningaID);
                });

            migrationBuilder.CreateTable(
                name: "Administracija",
                columns: table => new
                {
                    AdministracijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GradID = table.Column<int>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Uloga = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(maxLength: 12, nullable: true),
                    Mail = table.Column<string>(maxLength: 100, nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    LozinkaHash = table.Column<string>(nullable: true),
                    LozinkaSalt = table.Column<string>(nullable: true),
                    DatumZaposlenja = table.Column<DateTime>(type: "date", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "date", nullable: true),
                    Spol = table.Column<string>(nullable: true),
                    Staz = table.Column<int>(nullable: true),
                    StalanZaposlenik = table.Column<bool>(nullable: true),
                    JMBG = table.Column<string>(maxLength: 13, nullable: true),
                    Slika = table.Column<byte[]>(nullable: true),
                    KorisnickoIme = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administracija", x => x.AdministracijaID);
                    table.ForeignKey(
                        name: "FK__Administr__GradI__1367E606",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Polaznik",
                columns: table => new
                {
                    PolaznikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GradID = table.Column<int>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(maxLength: 12, nullable: true),
                    Uloga = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(maxLength: 100, nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(maxLength: 13, nullable: true),
                    Spol = table.Column<string>(nullable: true),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    LozinkaHash = table.Column<string>(nullable: true),
                    LozinkaSalt = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polaznik", x => x.PolaznikID);
                    table.ForeignKey(
                        name: "FK__Polaznik__GradID__1B0907CE",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trener",
                columns: table => new
                {
                    TrenerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GradID = table.Column<int>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(maxLength: 12, nullable: true),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(maxLength: 100, nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(maxLength: 13, nullable: true),
                    BrojOcjena = table.Column<int>(nullable: true),
                    DatumZaposlenja = table.Column<DateTime>(type: "date", nullable: true),
                    Spol = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Slika = table.Column<byte[]>(nullable: true),
                    LozinkaHash = table.Column<string>(nullable: true),
                    LozinkaSalt = table.Column<string>(nullable: true),
                    Uloga = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trener", x => x.TrenerID);
                    table.ForeignKey(
                        name: "FK__Trener__GradID__1DE57479",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KorisniciUloge",
                columns: table => new
                {
                    KorisnikUlogaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PolaznikID = table.Column<int>(nullable: true),
                    TrenerID = table.Column<int>(nullable: true),
                    AdministracijaID = table.Column<int>(nullable: true),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime", nullable: true),
                    UlogaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisniciUloge", x => x.KorisnikUlogaID);
                    table.ForeignKey(
                        name: "AdministracijaID_FK",
                        column: x => x.AdministracijaID,
                        principalTable: "Administracija",
                        principalColumn: "AdministracijaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PolaznikID_FK",
                        column: x => x.PolaznikID,
                        principalTable: "Polaznik",
                        principalColumn: "PolaznikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "TrenerID_FK",
                        column: x => x.TrenerID,
                        principalTable: "Trener",
                        principalColumn: "TrenerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "UlogaID_FK",
                        column: x => x.UlogaID,
                        principalTable: "Uloge",
                        principalColumn: "UlogaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ocjene",
                columns: table => new
                {
                    OcjeneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PolaznikID = table.Column<int>(nullable: false),
                    TrenerID = table.Column<int>(nullable: false),
                    Ocjena = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjene", x => x.OcjeneID);
                    table.ForeignKey(
                        name: "PolaznikID_FK",
                        column: x => x.PolaznikID,
                        principalTable: "Polaznik",
                        principalColumn: "PolaznikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "TrenerID_FK",
                        column: x => x.TrenerID,
                        principalTable: "Trener",
                        principalColumn: "TrenerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RezervacijaTrenera",
                columns: table => new
                {
                    RezervacijaTreneraID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TrenerID = table.Column<int>(nullable: true),
                    PolaznikID = table.Column<int>(nullable: true),
                    SlobodniTerminiID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervacijaTrenera", x => x.RezervacijaTreneraID);
                    table.ForeignKey(
                        name: "PolaznikID_FK",
                        column: x => x.PolaznikID,
                        principalTable: "Polaznik",
                        principalColumn: "PolaznikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "TrenerID_FK",
                        column: x => x.TrenerID,
                        principalTable: "Trener",
                        principalColumn: "TrenerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trening",
                columns: table => new
                {
                    TreningID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TrenerID = table.Column<int>(nullable: true),
                    VrstaTreningaID = table.Column<int>(nullable: true),
                    Naziv = table.Column<string>(nullable: true),
                    Tezina = table.Column<string>(maxLength: 50, nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Preduvjeti = table.Column<string>(nullable: true),
                    Cijena = table.Column<double>(nullable: true),
                    TerminOdrzavanja = table.Column<DateTime>(nullable: true),
                    Kapacitet = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trening", x => x.TreningID);
                    table.ForeignKey(
                        name: "FK__Trening__TrenerI__22AA2996",
                        column: x => x.TrenerID,
                        principalTable: "Trener",
                        principalColumn: "TrenerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Trening__VrstaTr__239E4DCF",
                        column: x => x.VrstaTreningaID,
                        principalTable: "VrstaTreninga",
                        principalColumn: "VrstaTreningaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RezervacijaTreninga",
                columns: table => new
                {
                    RezervacijaTreningaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PolaznikID = table.Column<int>(nullable: true),
                    TreningID = table.Column<int>(nullable: true),
                    DatumVrijeme = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervacijaTreninga", x => x.RezervacijaTreningaID);
                    table.ForeignKey(
                        name: "PolaznikID_FK",
                        column: x => x.PolaznikID,
                        principalTable: "Polaznik",
                        principalColumn: "PolaznikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "TreningID_FK",
                        column: x => x.TreningID,
                        principalTable: "Trening",
                        principalColumn: "TreningID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subskripcija",
                columns: table => new
                {
                    SubskripcijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TreningID = table.Column<int>(nullable: true),
                    VrstaSubskripcijeID = table.Column<int>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Vrsta = table.Column<string>(nullable: true),
                    Trajanje = table.Column<string>(nullable: true),
                    Otkazano = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subskripcija", x => x.SubskripcijaID);
                    table.ForeignKey(
                        name: "FK__Subskripc__Treni__2B3F6F97",
                        column: x => x.TreningID,
                        principalTable: "Trening",
                        principalColumn: "TreningID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Subskripc__Vrsta__2C3393D0",
                        column: x => x.VrstaSubskripcijeID,
                        principalTable: "VrstaSubskripcije",
                        principalColumn: "VrstaSubskripcijeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Termin",
                columns: table => new
                {
                    TerminID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TerminOdrzavanja = table.Column<DateTime>(type: "datetime", nullable: true),
                    TreningID = table.Column<int>(nullable: true),
                    TrenerID = table.Column<int>(nullable: true),
                    MaxBrPolaznika = table.Column<int>(type: "int", nullable: true),
                    Sala = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termin", x => x.TerminID);
                    table.ForeignKey(
                        name: "FK_Termin_Trener_TrenerID",
                        column: x => x.TrenerID,
                        principalTable: "Trener",
                        principalColumn: "TrenerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Termin_Trening_TreningID",
                        column: x => x.TreningID,
                        principalTable: "Trening",
                        principalColumn: "TreningID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uplata",
                columns: table => new
                {
                    UplataID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdministracijaID = table.Column<int>(nullable: true),
                    PolaznikID = table.Column<int>(nullable: true),
                    SubskripcijaID = table.Column<int>(nullable: true),
                    Iznos = table.Column<double>(nullable: true),
                    Svrha = table.Column<string>(nullable: true),
                    DatumUplate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplata", x => x.UplataID);
                    table.ForeignKey(
                        name: "FK__Uplata__Administ__2F10007B",
                        column: x => x.AdministracijaID,
                        principalTable: "Administracija",
                        principalColumn: "AdministracijaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Uplata__Polaznik__300424B4",
                        column: x => x.PolaznikID,
                        principalTable: "Polaznik",
                        principalColumn: "PolaznikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Uplata__Subskrip__30F848ED",
                        column: x => x.SubskripcijaID,
                        principalTable: "Subskripcija",
                        principalColumn: "SubskripcijaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pohadja",
                columns: table => new
                {
                    PohadjaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PolaznikID = table.Column<int>(nullable: true),
                    TreningID = table.Column<int>(nullable: true),
                    TerminID = table.Column<int>(nullable: true),
                    Odrzano = table.Column<bool>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pohadja", x => x.PohadjaID);
                    table.ForeignKey(
                        name: "FK__Pohadja__Polazni__267ABA7A",
                        column: x => x.PolaznikID,
                        principalTable: "Polaznik",
                        principalColumn: "PolaznikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Pohadja__TerminI__286302EC",
                        column: x => x.TerminID,
                        principalTable: "Termin",
                        principalColumn: "TerminID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Pohadja__Trening__276EDEB3",
                        column: x => x.TreningID,
                        principalTable: "Trening",
                        principalColumn: "TreningID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "GradID", "Naziv", "PostanskiBr", "Skracenica" },
                values: new object[,]
                {
                    { 1, "Gračanica", 75320, "Gr" },
                    { 2, "Sarajevo", 71000, "SA" },
                    { 3, "Mostar", 88000, "MO" }
                });

            migrationBuilder.InsertData(
                table: "SlobodniTermini",
                columns: new[] { "SlobodniTerminiID", "Termin" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2020, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "VrstaSubskripcije",
                columns: new[] { "VrstaSubskripcijeID", "Detalji", "Vrsta" },
                values: new object[,]
                {
                    { 1, "Monthly subscription package", "Mjesecna" },
                    { 2, "Yearly subscription package", "Godisnja" }
                });

            migrationBuilder.InsertData(
                table: "VrstaTreninga",
                columns: new[] { "VrstaTreningaID", "Naziv", "Tezina", "Vrsta" },
                values: new object[,]
                {
                    { 1, "Weightlifting", "Srednja", "Strength training" },
                    { 2, "Yoga", "Mala", "Cardio training" },
                    { 3, "Fitness", "Srednja", "Fitness training" }
                });

            migrationBuilder.InsertData(
                table: "Administracija",
                columns: new[] { "AdministracijaID", "Adresa", "DatumRodjenja", "DatumZaposlenja", "GradID", "Ime", "JMBG", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Mail", "Prezime", "Slika", "Spol", "StalanZaposlenik", "Staz", "Telefon", "Uloga" },
                values: new object[] { 1, "Dzemala Bijedica 100", new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Admin", "1002003004001", "admin", "LvCr58p6/ZB3Oaz7lygL5SybYts=", "uiYGY+Qpm2yTIhvujwlV/g==", "admin@gmail.com", "Admin", null, "M", null, 1, "061834223", "Administrator" });

            migrationBuilder.InsertData(
                table: "Polaznik",
                columns: new[] { "PolaznikID", "Adresa", "DatumRodjenja", "GradID", "Ime", "JMBG", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Mail", "Prezime", "Spol", "Telefon", "Uloga" },
                values: new object[,]
                {
                    { 1, "Olovska 103A", new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Alma", "2504996127155", "alma123", "bhHfxO25pXvENGAFZPNpLUPhKLk=", "XkhJjWKutng9gwGqnM5HWg==", "alma@gmail.com", "Djedovic", "Ž", "062365144", "Polaznik" },
                    { 2, "Olovska 103B", new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Amela", "2009996127155", "amela123", "kaZyh4G4+pbffB7BcFpwrmTC7Fc=", "p02YvvPpqDzctCrIlXFn0Q==", "amela@gmail.com", "Cosic", "Ž", "062341184", "Polaznik" }
                });

            migrationBuilder.InsertData(
                table: "Trener",
                columns: new[] { "TrenerID", "Adresa", "BrojOcjena", "DatumZaposlenja", "GradID", "Ime", "JMBG", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Mail", "Opis", "Prezime", "Slika", "Spol", "Telefon", "Uloga" },
                values: new object[,]
                {
                    { 1, "Olovska 105", null, new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Dwayne", "1112223334441", "therock", "Hu3I566U63IfB7wpBIWSgPvrocA=", "aRfWAJofJsXOrAqdy5J3Eg==", "dwayne@gmail.com", "Professional fitness trainer", "Johnson", null, "M", "061724122", null },
                    { 2, "Olovska 106", null, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Arnold", "1112223334442", "arnie", "29Fh/de/6g6xOFFl3NLxDuUSKYM=", "a7kYMehoouvW29lxo6KIoA==", "arnold@gmail.com", "Professional fitness trainer", "Schwarzeneger", null, "M", "061724552", null },
                    { 3, "Olovska 107", null, new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Gal", "1112223334222", "gal123", "0fWcLjR5shgqfj52FNLZqrZuqHE=", "+itG6dytdkHc0I9sXnk2ag==", "gal@gmail.com", "Professional fitness trainer", "Gadot", null, "Ž", "061724332", null }
                });

            migrationBuilder.InsertData(
                table: "Ocjene",
                columns: new[] { "OcjeneID", "Ocjena", "PolaznikID", "TrenerID" },
                values: new object[,]
                {
                    { 1, 10, 1, 1 },
                    { 2, 10, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "RezervacijaTrenera",
                columns: new[] { "RezervacijaTreneraID", "PolaznikID", "SlobodniTerminiID", "TrenerID" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Trening",
                columns: new[] { "TreningID", "Cijena", "Kapacitet", "Naziv", "Opis", "Preduvjeti", "TerminOdrzavanja", "Tezina", "TrenerID", "VrstaTreningaID" },
                values: new object[,]
                {
                    { 1, 500.0, 30, "Weightlifting 101", "Weight lifting intermediate", "Intro to weightlifting", new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intermediate", 1, 1 },
                    { 2, 1000.0, 15, "Pro weightlifting", "Competitive weightlifting course", "Weightlifting intermediate", new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Advanced", 2, 1 },
                    { 3, 150.0, 20, "Fitness training", "Fitness training intermediate", "Fitness for beginners", new DateTime(2020, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intermediate", 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "RezervacijaTreninga",
                columns: new[] { "RezervacijaTreningaID", "DatumVrijeme", "PolaznikID", "TreningID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, new DateTime(2020, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Subskripcija",
                columns: new[] { "SubskripcijaID", "Opis", "Otkazano", "Trajanje", "TreningID", "Vrsta", "VrstaSubskripcijeID" },
                values: new object[] { 1, "Subscription", null, "30", 1, "Mjesecna", 1 });

            migrationBuilder.InsertData(
                table: "Termin",
                columns: new[] { "TerminID", "MaxBrPolaznika", "Sala", "TerminOdrzavanja", "TrenerID", "TreningID" },
                values: new object[,]
                {
                    { 1, 30, "Sala 1", new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 15, "Sala 2", new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, 20, "Sala 3", new DateTime(2020, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Uplata",
                columns: new[] { "UplataID", "AdministracijaID", "DatumUplate", "Iznos", "PolaznikID", "SubskripcijaID", "Svrha" },
                values: new object[] { 1, 1, new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.0, 1, 1, "Uplata za trening" });

            migrationBuilder.InsertData(
                table: "Uplata",
                columns: new[] { "UplataID", "AdministracijaID", "DatumUplate", "Iznos", "PolaznikID", "SubskripcijaID", "Svrha" },
                values: new object[] { 2, 1, new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.0, 2, 1, "Uplata za koristenje svlacionice" });

            migrationBuilder.CreateIndex(
                name: "IX_Administracija_GradID",
                table: "Administracija",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "UQ__Administ__2724B2D1E46225C0",
                table: "Administracija",
                column: "Mail",
                unique: true,
                filter: "[Mail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_AdministracijaID",
                table: "KorisniciUloge",
                column: "AdministracijaID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_PolaznikID",
                table: "KorisniciUloge",
                column: "PolaznikID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_TrenerID",
                table: "KorisniciUloge",
                column: "TrenerID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_UlogaID",
                table: "KorisniciUloge",
                column: "UlogaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_PolaznikID",
                table: "Ocjene",
                column: "PolaznikID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_TrenerID",
                table: "Ocjene",
                column: "TrenerID");

            migrationBuilder.CreateIndex(
                name: "IX_Pohadja_PolaznikID",
                table: "Pohadja",
                column: "PolaznikID");

            migrationBuilder.CreateIndex(
                name: "IX_Pohadja_TerminID",
                table: "Pohadja",
                column: "TerminID");

            migrationBuilder.CreateIndex(
                name: "IX_Pohadja_TreningID",
                table: "Pohadja",
                column: "TreningID");

            migrationBuilder.CreateIndex(
                name: "IX_Polaznik_GradID",
                table: "Polaznik",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "UQ__Polaznik__2724B2D12A306324",
                table: "Polaznik",
                column: "Mail",
                unique: true,
                filter: "[Mail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaTrenera_PolaznikID",
                table: "RezervacijaTrenera",
                column: "PolaznikID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaTrenera_TrenerID",
                table: "RezervacijaTrenera",
                column: "TrenerID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaTreninga_PolaznikID",
                table: "RezervacijaTreninga",
                column: "PolaznikID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaTreninga_TreningID",
                table: "RezervacijaTreninga",
                column: "TreningID");

            migrationBuilder.CreateIndex(
                name: "IX_Subskripcija_TreningID",
                table: "Subskripcija",
                column: "TreningID");

            migrationBuilder.CreateIndex(
                name: "IX_Subskripcija_VrstaSubskripcijeID",
                table: "Subskripcija",
                column: "VrstaSubskripcijeID");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_TrenerID",
                table: "Termin",
                column: "TrenerID");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_TreningID",
                table: "Termin",
                column: "TreningID");

            migrationBuilder.CreateIndex(
                name: "IX_Trener_GradID",
                table: "Trener",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Trening_TrenerID",
                table: "Trening",
                column: "TrenerID");

            migrationBuilder.CreateIndex(
                name: "IX_Trening_VrstaTreningaID",
                table: "Trening",
                column: "VrstaTreningaID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_AdministracijaID",
                table: "Uplata",
                column: "AdministracijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_PolaznikID",
                table: "Uplata",
                column: "PolaznikID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_SubskripcijaID",
                table: "Uplata",
                column: "SubskripcijaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisniciUloge");

            migrationBuilder.DropTable(
                name: "Ocjene");

            migrationBuilder.DropTable(
                name: "Pohadja");

            migrationBuilder.DropTable(
                name: "RezervacijaTrenera");

            migrationBuilder.DropTable(
                name: "RezervacijaTreninga");

            migrationBuilder.DropTable(
                name: "SlobodniTermini");

            migrationBuilder.DropTable(
                name: "Uplata");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "Termin");

            migrationBuilder.DropTable(
                name: "Administracija");

            migrationBuilder.DropTable(
                name: "Polaznik");

            migrationBuilder.DropTable(
                name: "Subskripcija");

            migrationBuilder.DropTable(
                name: "Trening");

            migrationBuilder.DropTable(
                name: "VrstaSubskripcije");

            migrationBuilder.DropTable(
                name: "Trener");

            migrationBuilder.DropTable(
                name: "VrstaTreninga");

            migrationBuilder.DropTable(
                name: "Grad");
        }
    }
}
