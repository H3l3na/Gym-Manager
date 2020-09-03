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
    public partial class TrenerMojiPodaciPage : ContentPage
    {
        private readonly TrenerMojiPodaciVM model = null;

        // public int Id;
        public TrenerMojiPodaciPage()
        {
            InitializeComponent();
        }
        public TrenerMojiPodaciPage(int trenerId, Model.Trener t)
        {
            InitializeComponent();
            BindingContext = model = new TrenerMojiPodaciVM(trenerId, t);

            //model.LoadData(polaznikId, p);
            //Id = polaznikId;
        }
    }
}