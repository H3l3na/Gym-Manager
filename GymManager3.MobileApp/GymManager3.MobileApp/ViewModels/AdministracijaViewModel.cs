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
    public class AdministracijaViewModel: BaseViewModel
    {
        private readonly APIService _administracijaService = new APIService("Administracija");
        public AdministracijaViewModel() { }
        public AdministracijaViewModel(int admin, int uloga)
        {
            InitCommand = new Command(async () => await Init());
            AdminID = admin;
            Uloga = uloga;
        }
        public ObservableCollection<Administracija> AdministracijaList { get; set; } = new ObservableCollection<Administracija>();
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            var list = await _administracijaService.Get<IEnumerable<Administracija>>(null);
            AdministracijaList.Clear();
            foreach (var admin in list)
            {
                AdministracijaList.Add(admin);
            }
        }
        int _adminId;
        public int AdminID { get { return _adminId; } set { SetProperty(ref _adminId, value); } }

        int _uloga;
        public int Uloga { get { return _uloga; } set { SetProperty(ref _uloga, value); } }
    }
}
