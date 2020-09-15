using AutoMapper;
using GymManager3.Model.Requests;
using GymManager3.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public class TrenerService: ITrenerService
    {
        private readonly GymManager1Context _context;
        private readonly IMapper _mapper;
        // static MLContext mlContext = null;
        public TrenerService(GymManager1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.treneri> Get()
        {
            var query = _context.Trener.AsQueryable();

            var list = query.ToList();
            List<Model.treneri> result = new List<Model.treneri>();

            foreach (var x in list)
            {
                result.Add(new Model.treneri
                {
                    Uloga=x.Uloga,
                    Adresa=x.Adresa,
                    BrojOcjena=x.BrojOcjena,
                    DatumZaposlenja=x.DatumZaposlenja,
                    Spol=x.Spol,
                    LozinkaSalt=x.LozinkaSalt,
                    Ime=x.Ime + " " + x.Prezime,
                    GradID=x.GradId,
                    JMBG=x.Jmbg,
                    KorisnickoIme=x.KorisnickoIme,
                    LozinkaHash=x.LozinkaHash,
                    Mail=x.Mail,
                    Opis=x.Opis,
                    Slika=x.Slika,
                    Telefon=x.Telefon,
                    TrenerId=x.TrenerId
                    
                });
            }

            return result;
        }
    }
}
