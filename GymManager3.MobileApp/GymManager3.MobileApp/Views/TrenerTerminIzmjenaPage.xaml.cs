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
    public partial class TrenerTerminIzmjenaPage : ContentPage
    {
        private readonly TrenerTerminIzmjenaVM model = null;
        public TrenerTerminIzmjenaPage()
        {
            InitializeComponent();
        }
        public TrenerTerminIzmjenaPage(int trenerId, List<Model.Termin> lista, int terminId)
        {
            InitializeComponent();
            BindingContext = model = new TrenerTerminIzmjenaVM(trenerId, lista, terminId);
        }
    }
}