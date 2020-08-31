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
    public class PolaznikService : IPolaznikService
    {
        private readonly GymManager1Context _context;
        private readonly IMapper _mapper;
        public PolaznikService(GymManager1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Polaznik> Get(PolazniciSearchRequest request)
        {
            var query = _context.Polaznik.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime));
            }
            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Polaznik>>(list);
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
        public Model.Polaznik Insert(PolazniciInsertRequest request)
        {
            var entity = _mapper.Map<Database.Polaznik>(request);
            if (request.Password != request.PasswordPotvrda)
            {
                throw new UserException("Passwordi se ne slazu"); 
            }
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            _context.Polaznik.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Polaznik>(entity);
        }
        public Model.Polaznik GetById(int id)
        {
            var entity = _context.Polaznik.Find(id);
            return _mapper.Map<Model.Polaznik>(entity);
        }
        public int GetByUsername(string username)
        {
            var entity = _context.Polaznik.Where(x => x.KorisnickoIme == username).FirstOrDefault();
            return entity.PolaznikId;
        }
        public Model.Polaznik Update(int id, PolazniciInsertRequest request)
        {
            var entity = _context.Polaznik.Find(id);
            _context.Polaznik.Attach(entity);
            _context.Polaznik.Update(entity);
            _mapper.Map(request, entity);
            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordPotvrda)
                {
                    throw new UserException("Passwordi se ne slazu!");
                }
            }
            _context.SaveChanges();
            return _mapper.Map<Model.Polaznik>(entity);
        }
        public Model.Polaznik Authenticiraj(string username, string pass)
        {
            var user = _context.Polaznik.FirstOrDefault(x => x.KorisnickoIme == username);

            if (user != null)
            {
                var hashedPass = GenerateHash(user.LozinkaSalt, pass);

                if (hashedPass == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Polaznik>(user);
                }
            }

            return null;
        }
    }
}
