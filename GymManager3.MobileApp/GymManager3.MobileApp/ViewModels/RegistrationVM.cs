using GymManager3.MobileApp.Views;
using GymManager3.Model;
using GymManager3.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class RegistrationVM: BaseViewModel
    {
        private readonly APIService _service = new APIService("Polaznik");
        private readonly APIService _treneriService = new APIService("Treneri");
        public RegistrationVM()
        {
            RegisterCommand = new Command(async () => await Register());
            NazadCommand = new Command(() => Nazad());

        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        string _passwordPotvrda = string.Empty;
        public string PasswordPotvrda
        {
            get { return _passwordPotvrda; }
            set { SetProperty(ref _passwordPotvrda, value); }
        }
        string _ime = string.Empty;
        public string Ime
        {
            get { return _ime; }
            set { SetProperty(ref _ime, value); }
        }
        string _prezime = string.Empty;
        public string Prezime
        {
            get { return _prezime; }
            set { SetProperty(ref _prezime, value); }
        }
        string _mail = string.Empty;
        public string Mail
        {
            get { return _mail; }
            set { SetProperty(ref _mail, value); }
        }
        string _telefon = string.Empty;
        public string Telefon
        {
            get { return _telefon; }
            set { SetProperty(ref _telefon, value); }
        }
        string _adresa = string.Empty;
        public string Adresa
        {
            get { return _adresa; }
            set { SetProperty(ref _adresa, value); }
        }
        string _uloga = string.Empty;
        public string Uloga
        {
            get { return _uloga; }
            set { SetProperty(ref _uloga, value); }
        }
        public ICommand RegisterCommand { get; set; }
        public ICommand NazadCommand { get; set; }
        public void Nazad()
        {
            Application.Current.MainPage = new NewLoginPage();
        }
        async Task Register()
        {
            List<Model.Polaznik> listaPolaznika = await _service.Get<List<Model.Polaznik>>();
            List<Model.Trener> listaTrenera = await _treneriService.Get<List<Model.Trener>>();
            bool pronasaoPolaznika = false;
            bool pronasaoTrenera = false;
            IsBusy = true;
            //APIService.Username = Username;
            //APIService.Password = Password;
            if (Ime=="" || Prezime == "" || Username=="" || Password=="" || PasswordPotvrda=="" || Mail=="" || Telefon=="" )
            {
               await  Application.Current.MainPage.DisplayAlert("Upozorenje", "Molimo unesite sva polja", "OK");
            }
            else if (Password != PasswordPotvrda)
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Passwordi se ne slazu", "OK");
            }
            else if (Uloga!=null && Uloga!="Trener" && Uloga != "Polaznik")
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Neispravan unos za polje 'Uloga'", "Pokusajte ponovo");
            }
            else if (!(IsValidEmail(Mail)))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Email adresa nije validna", "OK");
            }
            else if (Uloga == "Polaznik")
            {
                foreach(Model.Polaznik p in listaPolaznika)
                {
                    if (p.KorisnickoIme == Username)
                    {
                        pronasaoPolaznika = true;
                    }
                }
                if (pronasaoPolaznika)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Username je već u upotrebi", "OK");
                }
                else
                {
                    PolazniciInsertRequest request = new PolazniciInsertRequest()
                    {
                        Ime = Ime,
                        Prezime = Prezime,
                        KorisnickoIme = Username,
                        Password = Password,
                        PasswordPotvrda = PasswordPotvrda,
                        Mail = Mail,
                        Telefon = Telefon,
                        Uloga = "Polaznik",
                        //GradId = 1,
                        //DatumRodjenja = DateTime.Now
                    };
                    try
                    {
                        await _service.Insert<Model.Polaznik>(request);
                        Application.Current.MainPage = new NewLoginPage();
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
                    }
                }
            }else if (Uloga == "Trener")
            {
                foreach(Model.Trener t in listaTrenera)
                {
                    if (t.KorisnickoIme == Username)
                    {
                        pronasaoTrenera = true;
                    }
                }
                if (pronasaoTrenera)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Username je već u upotrebi", "OK");
                }
                else
                {
                    TreneriInsertRequest trenerRequest = new TreneriInsertRequest()
                    {
                        Ime = Ime,
                        Prezime = Prezime,
                        KorisnickoIme = Username,
                        Password = Password,
                        PasswordConfirmation = PasswordPotvrda,
                        Mail = Mail,
                        Telefon = Telefon,
                        Uloga = "Trener"
                    };
                    try
                    {
                        await _treneriService.Insert<Model.Trener>(trenerRequest);
                        Application.Current.MainPage = new NewLoginPage();
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
                    }
                }
            }
        }

 
        public bool IsValidEmail(string source)
        {
            return new EmailAddressAttribute().IsValid(source);
        }
    }
}
