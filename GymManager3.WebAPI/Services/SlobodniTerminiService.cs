using AutoMapper;
using GymManager3.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public class SlobodniTerminiService: ISlobodniTerminiService
    {
        private readonly GymManager1Context _context;
        private readonly IMapper _mapper;
        public SlobodniTerminiService(GymManager1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.SlobodniTermini> Get()
        {
            var list = _context.SlobodniTermini.ToList();
            return _mapper.Map<List<Model.SlobodniTermini>>(list);
        }
        public Model.SlobodniTermini GetById(int id)
        {
            var entity = _context.SlobodniTermini.Find(id);
            return _mapper.Map<Model.SlobodniTermini>(entity);
        }
    }
}
