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
    public partial class TrenerMojiTerminiPage : ContentPage
    {
        private readonly TrenerMojiTerminiVM model = null;
        int _trenerId;
        public TrenerMojiTerminiPage()
        {
            InitializeComponent();
        }
        public TrenerMojiTerminiPage(int trenerId, List<Model.Termin> listaTermina)
        {
            InitializeComponent();
            BindingContext = model = new TrenerMojiTerminiVM(trenerId, listaTermina);

            _trenerId = trenerId;
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Model.Termin v = (Model.Termin)e.SelectedItem;

            Application.Current.MainPage = new TrenerTerminDetaljiPage(_trenerId, v);
        }
    }
}