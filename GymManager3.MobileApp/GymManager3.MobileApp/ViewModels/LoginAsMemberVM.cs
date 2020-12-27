using GymManager3.MobileApp.Views;
using GymManager3.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class LoginAsMemberVM: BaseViewModel
    {
        private readonly APIService _service = new APIService("Polaznik");
        private readonly APIService _serviceAuth = new APIService("Auth");
        private readonly APIService _serviceAuthTrener = new APIService("AuthTrener");
        public LoginAsMemberVM()
        {
            LoginCommand = new Command(async () => await Login());
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
        public ICommand LoginCommand { get; set; }
        public ICommand NazadCommand { get; set; }
        public void Nazad()
        {
            Application.Current.MainPage = new NewLoginPage();
        }
        async Task Login()
        {
            IsBusy = true;
            APIService.Username = Username;
            APIService.Password = Password;
            if (Username == "" || Password == "")
            {
                Application.Current.MainPage.DisplayAlert("Greška", "Molimo popunite sva polja", "OK");
            }
            else
            {
                try
                {
                    //PolaznikUsernameSearchRequest request = new PolaznikUsernameSearchRequest()
                    //{
                    //    KorisnickoIme = Username
                    //};
                    //PolazniciSearchRequest request = new PolazniciSearchRequest()
                    //{
                    //    KorisnickoIme=Username
                    //};
                    //await _service.Get<dynamic>(null);
                    //await _service.Get<dynamic>();
                    long t = await _serviceAuth.Auth<long>(Username, Password);
                    int id = unchecked((int)t);
                    // await Application.Current.MainPage.DisplayAlert("wait", id.ToString(), "ok");
                    //  int id = int.Parse(t);
                    // var entity = _service.Get<dynamic>(request);//await _service.Get<dynamic>(null);
                    /*await _service.Get<dynamic>(request)*/
                    ;

                    if (id != 0)
                    {
                        Application.Current.MainPage = new PolaznikMainPage(id);
                    }
                    else
                    {
                        t = await _serviceAuthTrener.Auth<long>(Username, Password);
                        id = unchecked((int)t);
                        if (id != 0)
                        {
                            Application.Current.MainPage = new TrenerMainPage(id);
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Greška", "Neispravni su podaci", "OK");
                        }
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
                }
            }
        }
    }
}
