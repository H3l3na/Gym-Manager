using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GymManager3.MobileApp.Services;
using GymManager3.MobileApp.Views;

namespace GymManager3.MobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            // MainPage = new LoginPage();             THE INITIAL CODE
            MainPage = new NewLoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
