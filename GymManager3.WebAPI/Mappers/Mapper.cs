using AutoMapper;
using Microsoft.AspNetCore.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManager3.Model.Requests;

namespace GymManager3.WebAPI.Mappers
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Database.Polaznik, Model.Polaznik>();
            CreateMap<Database.Grad, Model.Grad>();
            CreateMap<Database.Uplata, Model.Uplata>();
            CreateMap<Database.Polaznik, PolazniciInsertRequest>().ReverseMap();
            CreateMap<Database.Administracija, Model.Administracija>();
            CreateMap<Database.Administracija, AdministracijaInsertRequest>().ReverseMap();
            CreateMap<Database.Trener, Model.Trener>();
            CreateMap<Database.Trening, Model.Trening>();
            CreateMap<Database.Trener, TreneriInsertRequest>().ReverseMap();
            CreateMap<Database.Trening, TreninziInsertRequest>().ReverseMap();
            CreateMap<Database.VrstaSubskripcije, Model.VrstaSubskripcije>();
            CreateMap<Database.Uplata, UplataInsertRequest>().ReverseMap();
            CreateMap<Database.VrstaTreninga, Model.VrstaTreninga>();
            CreateMap<Database.Uloge, Model.Uloge>();
            CreateMap<Database.Termin, Model.Termin>();
            CreateMap<Database.KorisniciUloge, Model.KorisniciUloge>();
            CreateMap<Database.RezervacijaTreninga, Model.RezervacijaTreninga>();
            CreateMap<Database.Subskripcija, Model.Subskripcija>();
            CreateMap<Database.Termin, TerminInsertRequest>().ReverseMap();
            CreateMap<Database.RezervacijaTreninga, RezervacijaTreningaInsertRequest>().ReverseMap();
            CreateMap<Database.RezervacijaTrenera, Model.RezervacijaTrenera>();
            CreateMap<Database.RezervacijaTrenera, RezervacijaTreneraInsertRequest>().ReverseMap();
            CreateMap<Database.SlobodniTermini, Model.SlobodniTermini>();
            CreateMap<Database.Trener, RecommendedSearchRequest>().ReverseMap();
            CreateMap<Database.Ocjene, Model.Ocjene>();
            CreateMap<Database.Ocjene, OcjeneUpsertRequest>().ReverseMap();
            CreateMap<Database.Trener, Model.treneri>();
            CreateMap<Database.Polaznik, PolazniciUpdateRequest>();
            CreateMap<Database.Polaznik, PolazniciUpdateRequest>().ReverseMap();
            CreateMap<Database.Administracija, AdministracijaUpdateRequest>();
            CreateMap<Database.Administracija, AdministracijaUpdateRequest>().ReverseMap();
            CreateMap<Database.Trener, TrenerUpdateRequest>();
            CreateMap<Database.Trener, TrenerUpdateRequest>().ReverseMap();
            CreateMap<Database.Trening, TreningUpdateRequest>();
            CreateMap<Database.Trening, TreningUpdateRequest>().ReverseMap();
            CreateMap<Database.Uplata, UplataUpdateRequest>();
            CreateMap<Database.Uplata, UplataUpdateRequest>().ReverseMap();
            CreateMap<Database.Uplata, Model.uplate>();
        }
    }
}
