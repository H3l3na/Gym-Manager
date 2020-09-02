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
    public partial class TreningDetaljiPage : ContentPage
    {
        private TreningDetaljiVM model = null;
        public TreningDetaljiPage()
        {
            InitializeComponent();
        }
        public TreningDetaljiPage(int polaznikId, Model.Trening t)
        {
            InitializeComponent();
            BindingContext = model = new TreningDetaljiVM(polaznikId, t);
        }
    }
}