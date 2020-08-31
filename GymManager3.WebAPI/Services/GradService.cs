using AutoMapper;
using GymManager3.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public class GradService : IGradService
    {
        private readonly GymManager1Context _context;
        private readonly IMapper _mapper;
        public GradService(GymManager1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Grad> Get()
        {
            var list = _context.Grad.ToList();
            return _mapper.Map<List<Model.Grad>>(list);
        }
    }
}
