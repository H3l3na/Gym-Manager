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
    public class VrstaSubskripcijeViewModel
    {
        private readonly APIService _vrstaSubskripcijeService = new APIService("VrstaSubskripcije");
        public VrstaSubskripcijeViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<VrstaSubskripcije> VrstaSubskripcijeList { get; set; } = new ObservableCollection<VrstaSubskripcije>();
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            var list = await _vrstaSubskripcijeService.Get<IEnumerable<VrstaSubskripcije>>(null);
            VrstaSubskripcijeList.Clear();
            foreach (var vrsta in list)
            {
                VrstaSubskripcijeList.Add(vrsta);
            }
        }
    }
}
