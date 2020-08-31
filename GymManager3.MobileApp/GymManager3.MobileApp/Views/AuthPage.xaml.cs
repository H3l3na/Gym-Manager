using GymManager3.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymManager3.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage
    {
        private readonly AuthViewModel model = null;
        public AuthPage()
        {
            InitializeComponent();
            BindingContext = model = new AuthViewModel();
        }
        protected override async void OnAppearing()
        {


            base.OnAppearing();
            await model.LoadRole();
        }
    }
}