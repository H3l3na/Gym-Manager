using GymManager3.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public class AuthTrenerService: IAuthTrenerService
    {
        private readonly GymManager1Context _context;

        public AuthTrenerService(GymManager1Context context)
        {
            _context = context;
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
        public int Auth(string username, string password)
        {
            //int polaznik = _context.Uloge.Where(a => a.Naziv == "Polaznik").Select(v => v.UlogaId).FirstOrDefault();
            //int administracija = _context.Uloge.Where(a => a.Naziv == "Administracija").Select(v => v.UlogaId).FirstOrDefault();
            //int trener = _context.Uloge.Where(a => a.Naziv == "Trener").Select(v => v.UlogaId).FirstOrDefault();

           
            int? _Trener = null;
            
            var lista_trener = _context.Trener.ToList();

         

            foreach (var x in lista_trener)
            {
                if (username == x.KorisnickoIme)
                {
                    _Trener = x.TrenerId;

                    break;
                }
            }

            //if (_Polaznik == null)
            //{
            //    var lista_admin = _context.Administracija.ToList();
            //    foreach (var x in lista_admin)
            //    {
            //        if (username == x.KorisnickoIme)
            //        {
            //            _Administracija = x.AdministracijaId;

            //            break;
            //        }
            //    }
            //}
            //if (_Administracija == null)
            //{
            //    var lista_trener = _context.Trener.ToList();

            //    foreach (var x in lista_trener)
            //    {
            //        if (username == x.KorisnickoIme)
            //        {
            //            _Trener = x.TrenerId;
            //            break;
            //        }
            //    }
            //}
            //if (_Polaznik == null && _Trener == null && _Administracija == null)
            //{
            //    return null;
            //}
            //if (_Polaznik != null)
            //{
            //    var pol = _context.Polaznik.Where(x => x.PolaznikId == _Polaznik).FirstOrDefault();
            //    string sifra = GenerateHash(pol.LozinkaSalt, password);
            //    if (pol.LozinkaHash == sifra)
            //    {
            //        int id = pol.PolaznikId;
            //        Polaznik p = _context.Polaznik.Where(x => x.PolaznikId == id).FirstOrDefault();
            //        string usrname = p.KorisnickoIme;
            //        return usrname;
            //    }
            //}
            // //else if (_Trener != null)
            //{
            //    var tren = _context.Trener.Where(x => x.TrenerId == _Trener).FirstOrDefault();
            //    string sifra = GenerateHash(tren.LozinkaSalt, password);
            //    if (tren.LozinkaHash == sifra)
            //    {
            //        int id = tren.TrenerId;
            //        Trener t= _context.Trener.Where(x => x.TrenerId == id).FirstOrDefault();
            //        string usrname = t.KorisnickoIme;
            //        return usrname;
            //    }
            //}else if (_Administracija != null)
            //{
            //    var admin = _context.Administracija.Where(x => x.AdministracijaId == _Administracija).FirstOrDefault();
            //    string sifra = GenerateHash(admin.LozinkaSalt, password);
            //    if (admin.LozinkaHash == sifra)
            //    {
            //        int id = admin.AdministracijaId;
            //        Administracija a = _context.Administracija.Where(x => x.AdministracijaId == id).FirstOrDefault();
            //        string usrname = a.KorisnickoIme;
            //        return usrname;
            //    }
            //}
            
            if (_Trener != null)
            {
                return (int)_Trener;
            }
           
            return 0;
        }
    }
}
