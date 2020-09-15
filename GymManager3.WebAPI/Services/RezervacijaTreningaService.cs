using AutoMapper;
using GymManager3.Model.Requests;
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

        //public List<Model.RezervacijaTreninga> Get()
        //{
        //    var query = _context.RezervacijaTreninga.AsQueryable();

        //    var list = query.ToList();
        //    return _mapper.Map<List<Model.RezervacijaTreninga>>(list);
        //}
        public List<Model.RezervacijaTreninga> Get()
        {
            var query = _context.RezervacijaTreninga.AsQueryable();

            var list = query.ToList();
            List<Model.RezervacijaTreninga> result = new List<Model.RezervacijaTreninga>();

            foreach (var x in list)
            {
                result.Add(new Model.RezervacijaTreninga
                {
                    DatumVrijeme=x.DatumVrijeme,
                    PolaznikID=x.PolaznikID,
                    TreningID=x.TreningID,
                    RezervacijaTreningaID=x.RezervacijaTreningaID,
                    Trening=_context.Trening.Where(t=>t.TreningId==x.TreningID).Select(t=>t.Naziv).FirstOrDefault()
                    
                });
            }

            return result;
        }
       
        public Model.RezervacijaTreninga Insert(RezervacijaTreningaInsertRequest request)
        {
            var entity = _mapper.Map<Database.RezervacijaTreninga>(request);


            _context.RezervacijaTreninga.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.RezervacijaTreninga>(entity);
        }

        public virtual bool Delete(int id)
        {
            var item = _context.RezervacijaTreninga.Find(id);

            if (item != null) { 

                _context.RezervacijaTreninga.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public Model.RezervacijaTreninga Update(int id, RezervacijaTreningaInsertRequest request)
        {
            var entity = _context.RezervacijaTreninga.Find(id);
            _context.RezervacijaTreninga.Attach(entity);
            _context.RezervacijaTreninga.Update(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.RezervacijaTreninga>(entity);
        }

    }
}
