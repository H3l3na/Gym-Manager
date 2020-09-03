using AutoMapper;
using GymManager3.Model.Requests;
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
            //var query = _context.Termin.AsQueryable();
            //var list = query.ToList();
            //return _mapper.Map<List<Model.Termin>>(list);
            var query = _context.Termin.AsQueryable();

            var list = query.ToList();
            List<Model.Termin> result = new List<Model.Termin>();

            foreach (var x in list)
            {
                result.Add(new Model.Termin
                {
                    TerminOdrzavanja=x.TerminOdrzavanja,
                    Sala=x.Sala,
                    MaxBrPolaznika=x.MaxBrPolaznika,
                    TerminID=x.TerminId,
                    TrenerId=x.TrenerId,
                    TreningId=x.TreningId,
                    Trening=_context.Trening.Where(t=>t.TreningId==x.TreningId).Select(t=>t.Naziv).FirstOrDefault(),
                    Trener=_context.Trener.Where(t=>t.TrenerId==x.TrenerId).Select(t=>t.Ime+" "+t.Prezime).FirstOrDefault()
                });
            }

            return result;
        }
        public Model.Termin Update(int id, TerminInsertRequest request)
        {
            var entity = _context.Termin.Find(id);
            _context.Termin.Attach(entity);
            _context.Termin.Update(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Termin>(entity);
        }
        public Model.Termin Insert(TerminInsertRequest request)
        {
            var entity = _mapper.Map<Database.Termin>(request);
           
            
            _context.Termin.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Termin>(entity);
        }
        public Model.Termin GetById(int id)
        {
            var entity = _context.Termin.Find(id);
            return _mapper.Map<Model.Termin>(entity);
        }
    }
}
