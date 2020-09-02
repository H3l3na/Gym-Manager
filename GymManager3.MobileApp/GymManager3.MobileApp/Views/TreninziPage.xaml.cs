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
    public partial class TreninziPage : ContentPage
    {
        private TreninziViewModel model = null;
        int Id;
        public TreninziPage()
        {
            InitializeComponent();
        }
        public TreninziPage(int id)
        {
            InitializeComponent();
            BindingContext = model = new TreninziViewModel(id);
            Id = id;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = model = new TreninziViewModel(Id);
            await model.Init();
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Model.Trening t = (Model.Trening)e.SelectedItem;

            Application.Current.MainPage = new TreningDetaljiPage(Id, t);
        }
    }
}