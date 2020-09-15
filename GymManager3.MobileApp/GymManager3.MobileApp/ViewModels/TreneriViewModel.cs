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
    public class TreneriViewModel
    {
        private readonly APIService _treneriService = new APIService("Trener");
        public TreneriViewModel()
        {

        }
        public TreneriViewModel(int polaznikId)
        {
            InitCommand = new Command(async () => await Init());
            NazadCommand = new Command(() =>
              {
                  Nazad(polaznikId);
  
              });
        }
        public ObservableCollection<treneri> TreneriList { get; set; } = new ObservableCollection<treneri>();
        public ICommand InitCommand { get; set; }
        public ICommand NazadCommand { get; set; }
        public void Nazad(int polaznikId)
        {
            Application.Current.MainPage = new PolaznikMainPage(polaznikId);
        }
        public async Task Init()
        {
            var list = await _treneriService.Get<IEnumerable<treneri>>(null);
            TreneriList.Clear();
            foreach (var trener in list)
            {
                TreneriList.Add(trener);
            }
        }
    }
}
