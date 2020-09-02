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
    public partial class PolaznikMojiPodaciPage : ContentPage
    {
        private readonly PolaznikMojiPodaciVM model = null;
        
       // public int Id;
        public PolaznikMojiPodaciPage()
        {
            InitializeComponent();
        }
        public  PolaznikMojiPodaciPage(int polaznikId, Model.Polaznik p)
        {
            InitializeComponent();
            BindingContext = model = new PolaznikMojiPodaciVM(polaznikId, p);
           
            //model.LoadData(polaznikId, p);
            //Id = polaznikId;
        }

        //novi kod below
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    model.LoadData(polaznikId, p);
        //}
    }
}