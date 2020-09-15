using GymManager3.MobileApp.Views;
using GymManager3.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class PolaznikMojiPodaciVM: BaseViewModel
    {
        private readonly APIService _service = new APIService("Polaznik");
        private readonly APIService _serviceUplata = new APIService("Uplate");
        public PolaznikMojiPodaciVM()
        {

        }

        public PolaznikMojiPodaciVM(int polaznikId, Model.Polaznik p)
        {
             LoadData(polaznikId, p);
            InitCommand = new Command(async () => await Init(polaznikId));
            NazadCommand = new Command(() =>
            {
                Nazad(polaznikId);
            });
            Command_MojeUplate = new Command(() =>
            {
                LoadUplate(polaznikId);
            });

            //IzmijeniCommand = new Command(() =>
            //{
            //    Izmijeni(userId, role, t);
            //});
        }
        public Model.Polaznik p { get; set; } = new Model.Polaznik();
        public ICommand NazadCommand { get; set; }
        public ICommand InitCommand { get; set; }
        public ICommand Command_MojeUplate { get; set; }

        public List<uplate> listaUplata { get; set; } = new List<uplate>();

        public async void LoadUplate(int polaznikId)
        {
            List<uplate> t = await _serviceUplata.Get<List<uplate>>(null);

            foreach (var x in t)
            {
                if (x.PolaznikId == polaznikId)
                {
                    listaUplata.Add(new uplate
                    {
                        AdministracijaId = x.AdministracijaId,
                        DatumUplate = x.DatumUplate,
                        Evidentirao = x.Evidentirao,
                        Iznos = x.Iznos,
                        PolaznikId=x.PolaznikId,
                        Svrha = x.Svrha,
                        UplataId = x.UplataId,
                        Uplatio = x.Uplatio
                    });
                }
            }

            Application.Current.MainPage = new PolaznikMojeUplatePage(polaznikId, listaUplata);

        }

        public void Nazad(int polaznikId)
        {
            Application.Current.MainPage = new PolaznikMainPage(polaznikId);
        }
        public void LoadData(int polaznikId, Model.Polaznik p)
        {
            PolaznikID = polaznikId;
            _ime = p.Ime;
            _prezime = p.Prezime;
            _mail = p.Mail;
            _telefon = p.Telefon;
            _adresa = p.Adresa;
            _uloga = p.Uloga;
            _username = p.KorisnickoIme;
            _jmbg = p.JMBG;
        }
        public  async  Task Init(int id)
        {
            p= await _service.GetById<Model.Polaznik>(id);
           
        }
        int PolaznikID;
        public int _polaznikID
        {
            get { return PolaznikID; }
            set { SetProperty(ref PolaznikID, value); }
        }

        string _ime;
        public string Ime { get { return _ime; } set { SetProperty(ref _ime, value); } }

        string _prezime;
        public string Prezime { get { return _prezime; } set { SetProperty(ref _prezime, value); } }

        string _telefon;
        public string Telefon{ get { return _telefon; } set { SetProperty(ref _telefon, value); } }

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
