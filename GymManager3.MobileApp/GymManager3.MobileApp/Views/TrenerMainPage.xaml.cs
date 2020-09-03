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
    public partial class TrenerMainPage : ContentPage
    {
        private readonly TrenerMainVM model = null;
        public TrenerMainPage()
        {
            InitializeComponent();
            BindingContext = model = new TrenerMainVM(/*polaznikId, uloga*/);
        }
        public TrenerMainPage(int id)
        {
            InitializeComponent();
            BindingContext = model = new TrenerMainVM(id);
            model.TrenerID = id;
        }
    }
}