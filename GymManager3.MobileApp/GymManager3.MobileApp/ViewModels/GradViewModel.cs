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
    public class GradViewModel
    {
        private readonly APIService _gradService = new APIService("Grad");
        public GradViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Grad> GradoviList { get; set; } = new ObservableCollection<Grad>();
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            var list = await _gradService.Get<IEnumerable<Grad>>(null);
            GradoviList.Clear();
            foreach (var grad in list)
            {
                GradoviList.Add(grad);
            }
        }
    }
}
