using AutoMapper;
using GymManager3.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public class KorisniciUlogeService: IKorisniciUlogeService
    {
        private readonly GymManager1Context _context;
        private readonly IMapper _mapper;
        public KorisniciUlogeService(GymManager1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.KorisniciUloge> Get()
        {
            var query = _context.KorisniciUloge.AsQueryable();

            var list = query.ToList();
            return _mapper.Map<List<Model.KorisniciUloge>>(list);
        }
    }
}
