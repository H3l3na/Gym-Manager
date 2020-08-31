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
    public class PolazniciViewModel
    {
        private readonly APIService _polazniciService = new APIService("Polaznik");
        public PolazniciViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Polaznik> PolazniciList { get; set; } = new ObservableCollection<Polaznik>();
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            var list = await _polazniciService.Get<IEnumerable<Polaznik>>(null);
            PolazniciList.Clear();
            foreach(var polaznik in list)
            {
                PolazniciList.Add(polaznik);
            }
        }
    }
}
