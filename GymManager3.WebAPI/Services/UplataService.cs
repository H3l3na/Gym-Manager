using AutoMapper;
using GymManager3.Model;
using GymManager3.Model.Requests;
using GymManager3.WebAPI.Database;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public class UplataService: IUplataService
    {
        private readonly GymManager1Context _context;
        private readonly IMapper _mapper;
        public UplataService(GymManager1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Uplata> Get(UplataSearchRequest request)
        {
            var query = _context.Uplata.AsQueryable();
            if (!string.IsNullOrEmpty(request?.Svrha))
            {
                query = query.Where(x => x.Svrha.StartsWith(request.Svrha));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Uplata>>(list);
        }
        public Model.Uplata GetById(int id)
        {
            var entity = _context.Uplata.Find(id);
            return _mapper.Map<Model.Uplata>(entity);
        }

        public Model.Uplata Insert (UplataInsertRequest request)
        {
            var entity = _mapper.Map<Database.Uplata>(request);
            _context.Uplata.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Uplata>(entity);
        }
    }
}
