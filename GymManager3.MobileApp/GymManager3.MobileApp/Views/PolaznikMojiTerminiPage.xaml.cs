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
    public partial class PolaznikMojiTerminiPage : ContentPage
    {
         private readonly PolaznikMojiTerminiVM model = null;
        int _polaznikId;
        public PolaznikMojiTerminiPage()
        {
            InitializeComponent();
        }
        public PolaznikMojiTerminiPage(int polaznikId, List<Model.RezervacijaTreninga> listaRezervacija)
        {
            InitializeComponent();
            BindingContext = model = new PolaznikMojiTerminiVM(polaznikId, listaRezervacija);
            _polaznikId = polaznikId;
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Model.RezervacijaTreninga v = (Model.RezervacijaTreninga)e.SelectedItem;

            Application.Current.MainPage = new PolaznikRezervacijaOtkaziPage(_polaznikId, v);
        }
    }
}