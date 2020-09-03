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
    public partial class TrenerMojiTreninziPage : ContentPage
    {
        private readonly TrenerMojiTreninziVM model = null;
        int _trenerId;
        public TrenerMojiTreninziPage()
        {
            InitializeComponent();
        }
        public TrenerMojiTreninziPage(int trenerId, List<Model.Trening> listaTreninga)
        {
            InitializeComponent();
            BindingContext = model = new TrenerMojiTreninziVM(trenerId, listaTreninga);
            
            _trenerId=trenerId;
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Model.Trening v = (Model.Trening)e.SelectedItem;

            Application.Current.MainPage = new TrenerTreningDetaljiPage(_trenerId, v);
        }
    }
}