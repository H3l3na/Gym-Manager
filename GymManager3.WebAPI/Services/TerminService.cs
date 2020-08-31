using AutoMapper;
using GymManager3.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public class TerminService: ITerminService
    {
        private readonly GymManager1Context _context;
        private readonly IMapper _mapper;
        public TerminService(GymManager1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Termin> Get()
        {
            var query = _context.Termin.AsQueryable();
            var list = query.ToList();
            return _mapper.Map<List<Model.Termin>>(list);
        }
    }
}
