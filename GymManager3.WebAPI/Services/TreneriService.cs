
using AutoMapper;
using GymManager3.Model.Requests;
using GymManager3.WebAPI.Database;
using GymManager3.WebAPI.Exceptions;
using GymManager3.WebAPI.ML;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public class TreneriService: ITreneriService
    {
        private readonly GymManager1Context _context;
        private readonly IMapper _mapper;
       // static MLContext mlContext = null;
        public TreneriService(GymManager1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Trener> Get(TreneriSearchRequest request)
        {
            var query = _context.Trener.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime));
            }
            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime));
            }
            
            var list = query.ToList();
            return _mapper.Map<List<Model.Trener>>(list);
        }
        public Model.Trener GetById(int id)
        {
            var entity = _context.Trener.Find(id);
            return _mapper.Map<Model.Trener>(entity);
        }
        public Model.Trener Insert(TreneriInsertRequest request)
        {
            var entity = _mapper.Map<Database.Trener>(request);
            if (request.Password != request.PasswordConfirmation)
            {
                throw new UserException("Passwordi se ne slazu");
            }
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            _context.Trener.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Trener>(entity);
        }
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        public Model.Trener Authenticiraj(string username, string pass)
        {
            var user = _context.Trener.FirstOrDefault(x => x.KorisnickoIme == username);
            // var user2 = _context.Administracija.Include(x => x.KorisniciUloge).Where(x => x.AdministracijaId == user.AdministracijaId).SingleOrDefault();
            // var user = _context.Administracija.Include(x=>x.KorisniciUloge).ThenInclude(w=>w.Uloga).Where(x => x.KorisnickoIme == username).FirstOrDefault();
            //if (user == null)
            //{
            //    user = _context.Administracija.FirstOrDefault(x => x.KorisnickoIme == username);
            //}

            if (user != null)
            {
                var hashedPass = GenerateHash(user.LozinkaSalt, pass);

                if (hashedPass == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Trener>(user);
                }
            }

            return null;
        }
        public Model.Trener Update(int id, TrenerUpdateRequest request)
        {
            var entity = _context.Trener.Find(id);
            _context.Trener.Attach(entity);
            _context.Trener.Update(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Trener>(entity);
        }

        public Model.Trener Delete(int id)
        {
            var trener = _context.Trener.Find(id);
            Model.Trener t = _mapper.Map<Model.Trener>(trener);
            if (trener != null)
            {
                _context.Trener.Remove(trener);
                _context.SaveChanges();
            }
            return t;
        }
        //public List<Model.Trener> Recommend (int id)
        //{
        //    if (mlContext == null)
        //    {
        //        //STEP 2: Read the trained data using TextLoader by defining the schema for reading the product co-purchase dataset
        //        //        Do remember to replace amazon0302.txt with dataset from https://snap.stanford.edu/data/amazon0302.html
        //        //var traindata = mlContext.Data.LoadFromTextFile(path: TrainingDataLocation,
        //        //                                                  columns: new[]
        //        //                                                            {
        //        //                                                    new TextLoader.Column("Label", DataKind.Single, 0),
        //        //                                                    new TextLoader.Column(name:nameof(ProductEntry.ProductID), dataKind:DataKind.UInt32, source: new [] { new TextLoader.Range(0) }, keyCount: new KeyCount(262111)),
        //        //                                                    new TextLoader.Column(name:nameof(ProductEntry.CoPurchaseProductID), dataKind:DataKind.UInt32, source: new [] { new TextLoader.Range(1) }, keyCount: new KeyCount(262111))
        //        //                                                            },
        //        //                                                  hasHeader: true,
        //        //                                                  separatorChar: '\t');
        //        var tmpData = _context.
        //        //STEP 3: Your data is already encoded so all you need to do is specify options for MatrxiFactorizationTrainer with a few extra hyperparameters
        //        //        LossFunction, Alpa, Lambda and a few others like K and C as shown below and call the trainer. 
        //        MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
        //        options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
        //        options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
        //        options.LabelColumnName = "Label";
        //        options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
        //        options.Alpha = 0.01;
        //        options.Lambda = 0.025;
        //        // For better results use the following parameters
        //        //options.K = 100;
        //        options.C = 0.00001;

        //        //Step 4: Call the MatrixFactorization trainer by passing options.
        //        var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);
        //        ITransformer model = est.Fit(traindata);
        //    }
        //    var predictionengine = mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
        //    var prediction = predictionengine.Predict(
        //                             new ProductEntry()
        //                             {
        //                                 ProductID = 3,
        //                                 CoPurchaseProductID = 63
        //                             });
        //}
    }
}
