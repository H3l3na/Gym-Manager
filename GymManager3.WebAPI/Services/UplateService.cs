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
                    Uplatio = _context.Polaznik.Where(a => a.PolaznikId== x.PolaznikId).Select(b => b.Ime + " " + b.Prezime).FirstOrDefault()
                });
            }

            return result;
        }
    }
}
