using GymManager3.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class TrenerMojiPodaciVM: BaseViewModel
    {
        private readonly APIService _service = new APIService("Treneri");
        public TrenerMojiPodaciVM()
        {

        }

        public TrenerMojiPodaciVM(int trenerId, Model.Trener t)
        {
            LoadData(trenerId, t);
            InitCommand = new Command(async () => await Init(trenerId));
            NazadCommand = new Command(() =>
            {
                Nazad(trenerId);
            });
           

            //IzmijeniCommand = new Command(() =>
            //{
            //    Izmijeni(userId, role, t);
            //});
        }
        public Model.Trener t { get; set; } = new Model.Trener();
        public ICommand NazadCommand { get; set; }
        public ICommand InitCommand { get; set; }

        public void Nazad(int trenerId)
        {
            Application.Current.MainPage = new TrenerMainPage(trenerId);
        }
        public void LoadData(int trenerId, Model.Trener t)
        {
             _trenerID= trenerId;
            _ime = t.Ime;
            _prezime = t.Prezime;
            _mail = t.Mail;
            _telefon = t.Telefon;
            _adresa = t.Adresa;
            _uloga = t.Uloga;
            _username = t.KorisnickoIme;
            _jmbg = t.JMBG;
        }
        public async Task Init(int id)
        {
            var t = await _service.GetById<Model.Trener>(id);

        }
        int _trenerID;
        public int TrenerID
        {
            get { return _trenerID; }
            set { SetProperty(ref _trenerID, value); }
        }

        string _ime;
        public string Ime { get { return _ime; } set { SetProperty(ref _ime, value); } }

        string _prezime;
        public string Prezime { get { return _prezime; } set { SetProperty(ref _prezime, value); } }

        string _telefon;
        public string Telefon { get { return _telefon; } set { SetProperty(ref _telefon, value); } }

        string _mail;
        public string Mail { get { return _mail; } set { SetProperty(ref _mail, value); } }

        string _adresa;
        public string Adresa { get { return _adresa; } set { SetProperty(ref _adresa, value); } }

        string _uloga;
        public string Uloga { get { return _uloga; } set { SetProperty(ref _uloga, value); } }

        string _username;
        public string Username { get { return _prezime; } set { SetProperty(ref _username, value); } }

        string _jmbg;
        public string Jmbg { get { return _jmbg; } set { SetProperty(ref _jmbg, value); } }
    }
}
