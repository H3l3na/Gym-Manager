﻿using GymManager3.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class LoginAsTrainerVM: BaseViewModel
    {
        private readonly APIService _service = new APIService("Treneri");
        private readonly APIService _serviceAuth = new APIService("AuthTrener");
        public LoginAsTrainerVM()
        {
            LoginCommand = new Command(async () => await Login());
            NazadCommand = new Command( () => Nazad());

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
            try
            {
                //await _service.Get<dynamic>(null);
                long t = await _serviceAuth.Auth<long>(Username, Password);
                int id = unchecked((int)t);
                if (id != 0)
                {
                    Application.Current.MainPage = new TrenerMainPage(id);
                }else
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Neispravni podaci", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
            }
        }
    }
}
