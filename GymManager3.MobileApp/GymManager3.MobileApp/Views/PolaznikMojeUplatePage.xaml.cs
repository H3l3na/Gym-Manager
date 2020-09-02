using GymManager3.MobileApp.ViewModels;
using GymManager3.Model;
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
    public partial class PolaznikMojeUplatePage : ContentPage
    {
        private readonly PolaznikMojeUplateVM model = null;
        int _polaznikId;
        public PolaznikMojeUplatePage()
        {
            InitializeComponent();
        }
        public PolaznikMojeUplatePage(int polaznikId, List<uplate> listaUplata)
        {
            InitializeComponent();
            BindingContext = model = new PolaznikMojeUplateVM(polaznikId, listaUplata);
            _polaznikId = polaznikId;
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            uplate v = (uplate)e.SelectedItem;

            Application.Current.MainPage = new PolaznikUplateDetaljiPage(_polaznikId, v);
        }
    }
}