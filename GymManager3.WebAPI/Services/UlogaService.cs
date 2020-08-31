using AutoMapper;
using GymManager3.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public class UlogaService: IUlogaService
    {
        private readonly GymManager1Context _context;
        private readonly IMapper _mapper;
        public UlogaService(GymManager1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Uloge> Get()
        {
            var query = _context.Uloge.AsQueryable();
            
            var list = query.ToList();
            return _mapper.Map<List<Model.Uloge>>(list);
        }
        public Model.Uloge GetById(int id)
        {
            var entity = _context.Uloge.Find(id);
            return _mapper.Map<Model.Uloge>(entity);
        }
    }
}
