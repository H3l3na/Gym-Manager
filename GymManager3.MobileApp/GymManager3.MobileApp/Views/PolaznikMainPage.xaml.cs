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
    public partial class PolaznikMainPage : ContentPage
    {
        private readonly PolaznikMainVM model = null;
        public PolaznikMainPage()
        {
            InitializeComponent();
            BindingContext = model = new PolaznikMainVM(/*polaznikId, uloga*/);
        }
        public PolaznikMainPage(int polaznikId, int uloga)
        {
            InitializeComponent();
            BindingContext = model = new PolaznikMainVM(/*polaznikId, uloga*/);
            model.PolaznikID = polaznikId;
            model.Uloga = uloga;
        }
    }
}