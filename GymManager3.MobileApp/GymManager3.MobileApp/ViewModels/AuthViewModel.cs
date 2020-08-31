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
    public class AuthViewModel: BaseViewModel
    {
        private readonly APIService _service = new APIService("Auth");
        private readonly APIService _service_uloga = new APIService("Uloga");
        private readonly APIService _servicePolaznik = new APIService("Polaznik");
        private readonly APIService _serviceAdmin = new APIService("Administracija");
        public AuthViewModel()
        {
            //LoadRole();

            AuthCommand = new Command(async () =>
            {
                try
                {
                    await Auth();
                }
                catch (Exception e)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste unijeli ispravne podatke", "OK");
                };
            });
        }
            public ObservableCollection<Uloge> ListaUloga { get; set; } = new ObservableCollection<Uloge>();
        public ICommand AuthCommand { get; set; }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        int _role;
        public int Role
        {
            get { return _role; }
            set { SetProperty(ref _role, value); }
        }
        public async Task LoadRole()
        {
            if (ListaUloga.Count == 0)
            {
                var listaSource = await _service_uloga.Get<List<Uloge>>(null);
                foreach (var role in listaSource)
                {
                    ListaUloga.Add(role);
                }
            }
        }
        Uloge _selectedUloga = null;

        public Uloge SelectedUloga
        {
            get { return _selectedUloga; }
            set
            {
                SetProperty(ref _selectedUloga, value);
            }
        }
         async Task Auth()
        {
            //try
            //{
                //string usrname = await _service.Auth(/*Username, Password, _selectedUloga.UlogaID*/);


            int roleId = 1;
            int userId = 1;
            var listaPolaznika = await _servicePolaznik.Get<List<Polaznik>>(null);
            var listaAdministratora = await _serviceAdmin.Get<List<Administracija>>(null);
            //    foreach(var x in listaPolaznika)
            //    {
            //        if (x.KorisnickoIme == usrname)
            //        {
            //            Application.Current.MainPage = new PolaznikMainPage(x.PolaznikId, 3);
            //        }
            //    }
            //    foreach (var x in listaAdministratora)
            //    {
            //        if (x.KorisnickoIme == usrname)
            //        {
            //            Application.Current.MainPage = new AdministracijaPage(x.AdministracijaID, 1);
            //        }
            //    }

            //    //Uloge u = await _service_uloga.GetById<Uloge>(roleId);

            //    //if (u.Naziv == "Administrator")
            //    //    Application.Current.MainPage = new AdministracijaPage(userId, roleId);
            //    //else if (u.Naziv == "Student")
            //    //    Application.Current.MainPage = new PolaznikMainPage(userId, roleId);
            //    //else if (u.Naziv == "Profesor")
            //    //    Application.Current.MainPage = new TreneriPage();

            //}
            //catch (NullReferenceException e)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Greška", "Niste unijeli ispravne podatke", "OK");
            //}
        }
    }
  }

