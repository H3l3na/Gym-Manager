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
    public partial class PolaznikRezervacijaTreneraPage : ContentPage
    {
        private  PolaznikRezervacijaTreneraVM model = null;
        int polaznikId;
        public PolaznikRezervacijaTreneraPage()
        {
            InitializeComponent();
        }
        public PolaznikRezervacijaTreneraPage(int id)
        {
            InitializeComponent();
            BindingContext = model = new PolaznikRezervacijaTreneraVM(id);
            polaznikId = id;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = model = new PolaznikRezervacijaTreneraVM(polaznikId);
            await model.Init();
        }
    }
}