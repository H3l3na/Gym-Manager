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
    public partial class TreneriPage : ContentPage
    {
        private TreneriViewModel model = null;
        public TreneriPage()
        {
            InitializeComponent();
        }
        int PolaznikID;
        public TreneriPage(int polaznikId)
        {
            InitializeComponent();
            BindingContext = model = new TreneriViewModel(polaznikId);
            PolaznikID = polaznikId;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = model = new TreneriViewModel(PolaznikID);
            await model.Init();
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Model.Trener t = (Model.Trener)e.SelectedItem;
            

            Application.Current.MainPage = new TrenerDetaljiPage(PolaznikID, t);
        }
    }
}