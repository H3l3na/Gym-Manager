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
    public partial class PolaznikRezervacijaOtkaziPage : ContentPage
    {
        private readonly PolaznikRezervacijaOtkaziVM model = null;
        public PolaznikRezervacijaOtkaziPage()
        {
            InitializeComponent();
        }
        public PolaznikRezervacijaOtkaziPage(int _userid, Model.RezervacijaTreninga v)
        {
            InitializeComponent();
            BindingContext = model = new PolaznikRezervacijaOtkaziVM(_userid, v);
        }
    }
}