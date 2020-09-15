using AutoMapper;
using GymManager3.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public class RecommendService: IRecommendService
    {
        protected GymManager1Context _context;
        protected IMapper _mapper;

        public RecommendService(GymManager1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.treneri> RecommendTrainer(int id)
        {
            var x = LoadSimilar(id);
            List<Model.treneri> result = new List<Model.treneri>();
            foreach (var item in x)
            {
                result.Add(new Model.treneri()
                {
                    Slika=item.Slika,
                    Spol=item.Spol,
                    Ime=item.Ime+" "+ item.Prezime,
                    LozinkaSalt=item.LozinkaSalt,
                    Adresa=item.Adresa,
                    BrojOcjena=item.BrojOcjena,
                    DatumZaposlenja=item.DatumZaposlenja,
                    GradID=item.GradId,
                    JMBG=item.Jmbg,
                    KorisnickoIme=item.KorisnickoIme,
                    LozinkaHash=item.LozinkaHash,
                    Mail=item.Mail,
                    Opis=item.Opis,
                    Telefon=item.Telefon,
                    TrenerId=item.TrenerId,
                    Uloga=item.Uloga
                });
            }
            return result;
            //return _mapper.Map<List<Model.treneri>>(x);
        }

        Dictionary<int, List<Database.Ocjene>> treneri = new Dictionary<int, List<Database.Ocjene>>();

        public List<Database.Trener> LoadSimilar(int trenerId)
        {
            LoadTreneri(trenerId);
            List<Database.Ocjene> ratingsOfThis = _context.Ocjene.Where(x => x.TrenerID == trenerId).OrderBy(x => x.PolaznikID).ToList();

            List<Database.Ocjene> ratings1 = new List<Database.Ocjene>();
            List<Database.Ocjene> ratings2 = new List<Database.Ocjene>();
            List<Database.Trener> recomendedTrainers = new List<Database.Trener>();

            foreach (var item in treneri)
            {
                foreach (Database.Ocjene rating in ratingsOfThis)
                {
                    if (item.Value.Where(x => x.PolaznikID == rating.PolaznikID).Count() > 0)
                    {
                        ratings1.Add(rating);
                        ratings2.Add(item.Value.Where(x => x.PolaznikID == rating.PolaznikID).First());
                    }
                }
                double similarity = GetSimilarity(ratings1, ratings2);
                if (similarity > 0.5)
                {
                    recomendedTrainers.Add(_context.Trener.Where(x => x.TrenerId == item.Key).FirstOrDefault());
                }
                ratings1.Clear();
                ratings2.Clear();
            }

            return recomendedTrainers;
        }

        private double GetSimilarity(List<Database.Ocjene> ratings1, List<Database.Ocjene> ratings2)
        {
            if (ratings1.Count != ratings2.Count)
            {
                return 0;
            }

            double x = 0, y1 = 0, y2 = 0;
            for (int i = 0; i < ratings1.Count; i++)
            {
                x = ratings1[i].Ocjena * ratings2[i].Ocjena;
                y1 = ratings1[i].Ocjena * ratings1[i].Ocjena;
                y2 = ratings2[i].Ocjena * ratings2[i].Ocjena;
            }
            y1 = Math.Sqrt(y1);
            y2 = Math.Sqrt(y2);

            double y = y1 * y2;
            if (y == 0)
                return 0;
            return x / y;
        }

        private void LoadTreneri(int trenerId)
        {
            List<Database.Trener> trainers = _context.Trener.Where(x => x.TrenerId != trenerId).ToList();
            List<Database.Ocjene> ratings = new List<Database.Ocjene>();
            foreach (Database.Trener item in trainers)
            {
                ratings = _context.Ocjene.Include(x => x.Polaznik).Where(x => x.TrenerID == item.TrenerId).OrderBy(x => x.PolaznikID).ToList();
                if (ratings.Count > 0)
                    treneri.Add(item.TrenerId, ratings);
            }
        }
    }
}
