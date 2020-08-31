
using AutoMapper;
using GymManager3.Model.Requests;
using GymManager3.WebAPI.Database;
using GymManager3.WebAPI.Exceptions;
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
    }
}
