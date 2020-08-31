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
    public class TreninziViewModel
    {
        private readonly APIService _treninziService = new APIService("Treninzi");
        public TreninziViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Trening> TreninziList { get; set; } = new ObservableCollection<Trening>();
        public ICommand InitCommand { get; set; }
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
