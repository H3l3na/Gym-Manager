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
    public class UplateViewModel
    {
        private readonly APIService _uplateService = new APIService("Uplata");
        public UplateViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Uplata> UplateList { get; set; } = new ObservableCollection<Uplata>();
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            var list = await _uplateService.Get<IEnumerable<Uplata>>(null);
            UplateList.Clear();
            foreach (var uplata in list)
            {
                UplateList.Add(uplata);
            }
        }
    }
}
