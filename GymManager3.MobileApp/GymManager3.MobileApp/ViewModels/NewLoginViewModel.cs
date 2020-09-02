using GymManager3.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class NewLoginViewModel: BaseViewModel
    {
        private readonly APIService _serviceTrener = new APIService("Treneri");
        private readonly APIService _servicePolaznik = new APIService("Polaznik");
        public NewLoginViewModel()
        {
            LoginTrenerCommand = new Command(() => LoginTrener());
            LoginPolaznikCommand = new Command( () => LoginPolaznik());
            RegisterCommand = new Command(() => Register());
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
        public ICommand LoginTrenerCommand { get; set; }
        public ICommand LoginPolaznikCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
         public void LoginTrener()
        {
            Application.Current.MainPage = new LoginAsTrainerPage();
            //IsBusy = true;
            //APIService.Username = Username;
            //APIService.Password = Password;
            //try
            //{
            //    await _serviceTrener.Get<dynamic>(null);
            //    Application.Current.MainPage = new TrenerMainPage();
            //}
            //catch (Exception ex)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
            //}
        }
        public void LoginPolaznik()
        {
            Application.Current.MainPage = new LoginAsMemberPage();
            //IsBusy = true;
            //APIService.Username = Username;
            //APIService.Password = Password;
            //try
            //{
            //    await _servicePolaznik.Get<dynamic>(null);
            //    Application.Current.MainPage = new PolaznikMainPage();
            //}
            //catch (Exception ex)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
            //}
        }
        public void Register()
        {
            Application.Current.MainPage = new RegistrationPage();
        }
    }
}
