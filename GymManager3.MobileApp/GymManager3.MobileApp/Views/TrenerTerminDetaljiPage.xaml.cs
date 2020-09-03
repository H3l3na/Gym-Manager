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
    public partial class TrenerTerminDetaljiPage : ContentPage
    {
        private readonly TrenerTerminDetaljiVM model = null;
        public TrenerTerminDetaljiPage()
        {
            InitializeComponent();
        }
        public TrenerTerminDetaljiPage(int _userid, Model.Termin t)
        {
            InitializeComponent();
            BindingContext = model = new TrenerTerminDetaljiVM(_userid, t);
        }
    }
}