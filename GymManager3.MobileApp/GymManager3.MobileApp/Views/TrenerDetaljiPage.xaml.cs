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
    public partial class TrenerDetaljiPage : ContentPage
    {
        private TrenerDetaljiVM model = null;
        public int TrenerID;
        public TrenerDetaljiPage()
        {
            InitializeComponent();
        }
        public TrenerDetaljiPage(int polaznikId, Model.treneri t)
        {
            InitializeComponent();
            BindingContext = model = new TrenerDetaljiVM(polaznikId, t);
            TrenerID = t.TrenerId;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadTrainers(TrenerID);
        }
    }
}