using AutoMapper;
using GymManager3.Model.Requests;
using GymManager3.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public class RezervacijaTreneraService: IRezervacijaTreneraService
    {
        private readonly GymManager1Context _context;
        private readonly IMapper _mapper;
        public RezervacijaTreneraService(GymManager1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      
        public List<Model.RezervacijaTrenera> Get()
        {
            var query = _context.RezervacijaTrenera.AsQueryable();

            var list = query.ToList();
            List<Model.RezervacijaTrenera> result = new List<Model.RezervacijaTrenera>();

            foreach (var x in list)
            {
                result.Add(new Model.RezervacijaTrenera
                {
                    RezervacijaTreneraID = x.RezervacijaTreneraID,
                    PolaznikID = x.PolaznikID,
                    TrenerID = x.TrenerID,
                    SlobodniTerminiID=x.SlobodniTerminiID
                   // Polaznik = _context.Polaznik.Where(e => e.PolaznikId == x.PolaznikID).Select(e => e.Ime + " " + e.Prezime).FirstOrDefault(),
                   // Trener=_context.Trener.Where(e=>e.TrenerId==x.TrenerID).Select(e=>e.Ime+" "+e.Prezime).FirstOrDefault(),
                    
                }) ;
            }

            return result;
        }
        public Model.RezervacijaTrenera Insert(RezervacijaTreneraInsertRequest request)
        {
            var entity = _mapper.Map<Database.RezervacijaTrenera>(request);


            _context.RezervacijaTrenera.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.RezervacijaTrenera>(entity);
        }

        public virtual bool Delete(int id)
        {
            var item = _context.RezervacijaTrenera.Find(id);

            if (item != null)
            {

                _context.RezervacijaTrenera.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
