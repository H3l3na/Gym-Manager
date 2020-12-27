using AutoMapper;
using GymManager3.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public class UplateService: IUplateService
    {
        private readonly GymManager1Context _context;
        private readonly IMapper _mapper;
        public UplateService(GymManager1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.uplate> Get()
        {
            var query = _context.Uplata.AsQueryable();
           
            var list = query.ToList();
            List<Model.uplate> result = new List<Model.uplate>();

            foreach (var x in list)
            {
                result.Add(new Model.uplate
                {
                    AdministracijaId = x.AdministracijaId,
                    PolaznikId=x.PolaznikId,
                    UplataId = x.UplataId,
                    Svrha = x.Svrha,
                    DatumUplate = x.DatumUplate,
                    Evidentirao = _context.Administracija.Where(a => a.AdministracijaId == x.AdministracijaId).Select(b => b.Ime + " " + b.Prezime).FirstOrDefault(),
                    Iznos = x.Iznos,
                    Uplatio = _context.Polaznik.Where(a => a.PolaznikId== x.PolaznikId).Select(b => b.Ime + " " + b.Prezime).FirstOrDefault(),
                    Subskripcija=_context.Subskripcija.Where(s=>s.SubskripcijaId==x.SubskripcijaId).Select(s=>s.Vrsta).FirstOrDefault()
                });
            }

            return result;
        }
        public Model.uplate GetById(int id)
        {
            var entity = _context.Uplata.Find(id);
            Model.uplate uplata = new Model.uplate
            {
                UplataId = entity.UplataId,
                Subskripcija = _context.Subskripcija.Where(x => x.SubskripcijaId == entity.SubskripcijaId).Select(x => x.Vrsta).FirstOrDefault(),
                DatumUplate = entity.DatumUplate,
                Svrha = entity.Svrha,
                Iznos = entity.Iznos,
                Uplatio = _context.Polaznik.Where(x => x.PolaznikId == entity.PolaznikId).Select(x => x.Ime + " " + x.Prezime).FirstOrDefault(),
                Evidentirao = _context.Administracija.Where(x=>x.AdministracijaId== entity.AdministracijaId).Select(x=>x.Ime+" "+x.Prezime).FirstOrDefault()
            };
            return _mapper.Map<Model.uplate>(entity);
        }
    }
}
