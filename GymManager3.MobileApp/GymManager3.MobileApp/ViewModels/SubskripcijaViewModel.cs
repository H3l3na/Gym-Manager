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
    public class SubskripcijaViewModel
    {
        private readonly APIService _subskripcijaService = new APIService("Subskripcija");
        public SubskripcijaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Subskripcija> SubskripcijaList { get; set; } = new ObservableCollection<Subskripcija>();
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            var list = await _subskripcijaService.Get<IEnumerable<Subskripcija>>(null);
            SubskripcijaList.Clear();
            foreach (var subskripcija in list)
            {
                SubskripcijaList.Add(subskripcija);
            }
        }
    }
}
