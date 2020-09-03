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
    public partial class TrenerTreningDetaljiPage : ContentPage
    {
        private readonly TrenerTreningDetaljiVM model = null;
        public TrenerTreningDetaljiPage()
        {
            InitializeComponent();
        }
        public TrenerTreningDetaljiPage(int _userid, Model.Trening t)
        {
            InitializeComponent();
            BindingContext = model = new TrenerTreningDetaljiVM(_userid, t);
        }
    }
}