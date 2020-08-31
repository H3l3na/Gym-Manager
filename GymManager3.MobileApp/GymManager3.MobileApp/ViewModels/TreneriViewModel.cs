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
        private readonly APIService _treneriService = new APIService("Treneri");
        public TreneriViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Trener> TreneriList { get; set; } = new ObservableCollection<Trener>();
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            var list = await _treneriService.Get<IEnumerable<Trener>>(null);
            TreneriList.Clear();
            foreach (var trener in list)
            {
                TreneriList.Add(trener);
            }
        }
    }
}
