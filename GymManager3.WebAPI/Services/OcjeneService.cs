using AutoMapper;
using GymManager3.Model.Requests;
using GymManager3.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public class OcjeneService: IOcjeneService
    {
        protected GymManager1Context _context;
        protected IMapper _mapper;

        public OcjeneService(GymManager1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Ocjene> Get(OcjeneSearchRequest request)
        {
            var query = _context.Ocjene
                .Include(x => x.Trener)
                .Include(x => x.Trener.Ocjene)
                .AsQueryable();

            if (request.TrenerID != 0)
            {
                query = query.Where(x => x.TrenerID== request.TrenerID);
            }
            if (request.PolaznikID != 0)
            {
                query = query.Where(x => x.PolaznikID== request.PolaznikID);
            }

            return _mapper.Map<List<Model.Ocjene>>(query.ToList());
        }

        public Model.Ocjene InsertRatingByUser(OcjeneUpsertRequest request)
        {
            var x = _context.Ocjene.Where(w => w.PolaznikID== request.PolaznikID && w.TrenerID == request.TrenerID).SingleOrDefault();
            if (x != null)
            {
                x.Ocjena = request.Ocjena;
                _context.SaveChanges();
                return _mapper.Map<Model.Ocjene>(x);
            }
            else
            {
                var entity = _mapper.Map<Database.Ocjene>(request);
                _context.Ocjene.Add(entity);
              //  _context.Trener.Where(w => w.TrenerId== request.TrenerID).SingleOrDefault();
                _context.SaveChanges();
                return _mapper.Map<Model.Ocjene>(entity);
            }
        }
    }
}
