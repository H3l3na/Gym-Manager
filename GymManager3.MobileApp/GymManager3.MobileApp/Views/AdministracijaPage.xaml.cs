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
    public partial class AdministracijaPage : ContentPage
    {
        private AdministracijaViewModel model = null;
        public AdministracijaPage()
        {
            InitializeComponent();
            //BindingContext = model = new AdministracijaViewModel();
        }
        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    await model.Init();
        //}
        public AdministracijaPage(int admin, int uloga)
        {
            InitializeComponent();

            BindingContext = model = new AdministracijaViewModel(admin, uloga);
            model.AdminID = admin;
            model.Uloga = uloga;
        }
    }
}