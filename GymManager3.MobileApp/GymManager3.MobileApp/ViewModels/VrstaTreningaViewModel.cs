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
    public class VrstaTreningaViewModel
    {
        private readonly APIService _vrstaTreningaService = new APIService("VrstaTreninga");
        public VrstaTreningaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<VrstaTreninga> VrstaTreningaList { get; set; } = new ObservableCollection<VrstaTreninga>();
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            var list = await _vrstaTreningaService.Get<IEnumerable<VrstaTreninga>>(null);
            VrstaTreningaList.Clear();
            foreach (var vrsta in list)
            {
                VrstaTreningaList.Add(vrsta);
            }
        }
    }
}
