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
    public partial class PolaznikUplateDetaljiPage : ContentPage
    {
        private readonly PolaznikUplateDetaljiVM model = null;
        public PolaznikUplateDetaljiPage()
        {
            InitializeComponent();
        }
        public PolaznikUplateDetaljiPage(int _userid, uplate v)
        {
            InitializeComponent();
            BindingContext = model = new PolaznikUplateDetaljiVM(_userid, v);
        }
    }
}