using AutoMapper;
using GymManager3.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public class RezervacijaTreningaService: IRezervacijaTreningaService
    {
        private readonly GymManager1Context _context;
        private readonly IMapper _mapper;
        public RezervacijaTreningaService(GymManager1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.RezervacijaTreninga> Get()
        {
            var query = _context.RezervacijaTreninga.AsQueryable();

            var list = query.ToList();
            return _mapper.Map<List<Model.RezervacijaTreninga>>(list);
        }
    }
}
