using AutoMapper;
using GymManager3.Model.Requests;
using GymManager3.WebAPI.Controllers;
using GymManager3.WebAPI.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public class TreninziService: ITreninziService
    {
        private readonly GymManager1Context _context;
        private readonly IMapper _mapper;
        public TreninziService(GymManager1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Trening> Get(TreninziSearchRequest request)
        {
            var query = _context.Trening.AsQueryable();
            if (!string.IsNullOrEmpty(request?.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(request.Naziv));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Trening>>(list);
        }
        public Model.Trening Insert (TreninziInsertRequest request)
        {
            var entity = _mapper.Map<Database.Trening>(request);
            _context.Trening.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Trening>(entity);
        }
        public Model.Trening GetById(int id)
        {
            var entity = _context.Trening.Find(id);
            return _mapper.Map<Model.Trening>(entity);
        }
        public Model.Trening Update(int id, TreninziInsertRequest request)
        {
            var entity = _context.Trening.Find(id);
            _context.Trening.Attach(entity);
            _context.Trening.Update(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Trening>(entity);
        }
        
        public Model.Trening Delete(int id)
        {
            var trening = _context.Trening.Find(id);
            Model.Trening t = _mapper.Map<Model.Trening>(trening);
            if (trening != null)
            {
                _context.Trening.Remove(trening);
                _context.SaveChanges();
            }
            return t;
        }
    }
}
