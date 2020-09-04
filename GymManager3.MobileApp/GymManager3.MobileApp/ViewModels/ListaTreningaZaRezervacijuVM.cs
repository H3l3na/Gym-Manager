using GymManager3.MobileApp.Views;
using GymManager3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class ListaTreningaZaRezervacijuVM: BaseViewModel
    {
        private readonly APIService _treninziService = new APIService("Treninzi");
        public ListaTreningaZaRezervacijuVM()
        {

        }
        public ListaTreningaZaRezervacijuVM(int polaznikId)
        {
            InitCommand = new Command(async () => await Init());
            NazadCommand = new Command(() =>
            {
                Nazad(polaznikId);

            });
        }
        public ObservableCollection<Trening> TreninziList { get; set; } = new ObservableCollection<Trening>();
        public ICommand InitCommand { get; set; }
        public ICommand NazadCommand { get; set; }
        public void Nazad(int polaznikId)
        {
            Application.Current.MainPage = new PolaznikMainPage(polaznikId);
        }
        public async Task Init()
        {
            var list = await _treninziService.Get<IEnumerable<Trening>>(null);
            TreninziList.Clear();
            foreach (var trening in list)
            {
                TreninziList.Add(trening);
            }
        }
    }
}
