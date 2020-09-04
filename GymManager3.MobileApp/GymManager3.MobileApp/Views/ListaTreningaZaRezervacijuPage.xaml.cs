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
    public partial class ListaTreningaZaRezervacijuPage : ContentPage
    {
        private ListaTreningaZaRezervacijuVM model = null;
        int Id;
        public ListaTreningaZaRezervacijuPage()
        {
            InitializeComponent();
        }
        public ListaTreningaZaRezervacijuPage(int id)
        {
            InitializeComponent();
            BindingContext = model = new ListaTreningaZaRezervacijuVM(id);
            Id = id;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = model = new ListaTreningaZaRezervacijuVM(Id);
            await model.Init();
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Model.Trening t = (Model.Trening)e.SelectedItem;

            Application.Current.MainPage = new RezervacijaTreningaPage(Id, t);
        }
    }
}