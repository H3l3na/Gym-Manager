using GymManager3.MobileApp.Views;
using GymManager3.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class PolaznikMainVM: BaseViewModel
    {
        private readonly APIService _polaznikService = new APIService("Polaznik");
        private readonly APIService _uplateService = new APIService("Uplate");
        private readonly APIService _rezervacijeService = new APIService("RezervacijaTreninga");
        public PolaznikMainVM()
        {
            Command_Odjava = new Command(() =>
            {
                Odjava();
            });

        }
        public PolaznikMainVM(int id)
        {
            Command_Odjava = new Command(() =>
            {
                Odjava();
            });
            PolaznikID = id;
            Command_MojiPodaci = new Command(() =>
            {
                LoadMyData(id);
            });
            Command_MojeUplate = new Command(() =>
            {
                LoadUplate(id);
            });
            Command_Treneri = new Command(() =>
             {
                 LoadTreneri();
             });
            Command_Treninzi = new Command(() =>
              {
                  LoadTreninge(id);
              });
            Command_Rezervacija_Grupni_Trening = new Command(() =>
            {
                Rezervisi(id);
            });
            Command_Moje_Rezervacije = new Command(async () =>
              {
                  listaRezervacija = await _rezervacijeService.Get<List<Model.RezervacijaTreninga>>();
                  Application.Current.MainPage=new PolaznikMojiTerminiPage(id, listaRezervacija);
              });
            Command_Rezervacija_Individualni_Trening = new Command(() =>
              {
                  RezervisiIndividualni(id);
              });
        }
        //public PolaznikMainVM(/*int polaznikId, int uloga*/)
        //{
        //    //PolaznikID = polaznikId;
        //    //Uloga = uloga;
        //    Command_Odjava = new Command( () =>
        //    {
        //         Odjava();
        //    });

        //    //Command_MojiPodaci = new Command(() =>
        //    //{
        //    //    LoadMyData(polaznikId);
        //    //});
        //}
        public List<Model.Trening> listaTreninga = new List<Model.Trening>();
        public List<Model.RezervacijaTreninga> listaRezervacija = new List<Model.RezervacijaTreninga>();
        public void LoadTreninge(int id)
        {
            Application.Current.MainPage = new TreninziPage(id);
        }
        public void Rezervisi(int id)
        {
            Application.Current.MainPage = new ListaTreningaZaRezervacijuPage(id);
        }
        public List<Model.Trener> listaTrenera = new List<Model.Trener>();
        public  void LoadTreneri()
        {
            Application.Current.MainPage = new TreneriPage(PolaznikID);
        }
        public List<uplate> listaUplata { get; set; } = new List<uplate>();

        public async void LoadUplate(int userId)
        {
            List<uplate> t = await _uplateService.Get<List<uplate>>(null);

            foreach (var x in t)
            {
                if (x.PolaznikId == userId)
                {
                    listaUplata.Add(new uplate
                    {
                        AdministracijaId = x.AdministracijaId,
                        DatumUplate = x.DatumUplate,
                        Evidentirao = x.Evidentirao,
                        PolaznikId = x.PolaznikId,
                        Svrha = x.Svrha,
                        UplataId = x.UplataId,
                        Uplatio = x.Uplatio
                    });
                }
            }

            Application.Current.MainPage = new PolaznikMojeUplatePage(userId, listaUplata);

        }

        public async void LoadMyData(int polaznikId)
        {
            var t = await _polaznikService.GetById<Polaznik>(polaznikId);

            Application.Current.MainPage = new PolaznikMojiPodaciPage(polaznikId, t);
        }

        public  void Odjava()
        {
            ///var t =  Application.Current.MainPage.DisplayAlert("Upozorenje", "Da li ste sigurni da se želite odjaviti?", "Da", "Ne");

            
            Application.Current.MainPage = new NewLoginPage();
            
        }

        public void RezervisiIndividualni(int id)
        {
            Application.Current.MainPage = new PolaznikRezervacijaTreneraPage(id);
        }
        public ICommand Command_MojiPodaci { get; set; }
        public ICommand Command_Odjava { get; set; }
        public ICommand Command_MojeUplate { get; set; }
        public ICommand Command_Treneri { get; set; }
        public ICommand Command_Treninzi { get; set; }
        public ICommand Command_Rezervacija_Grupni_Trening { get; set; }
        public ICommand Command_Moje_Rezervacije { get; set; }
        public ICommand Command_Rezervacija_Individualni_Trening { get; set; }
        int _polaznikId;
        public int PolaznikID { get { return _polaznikId; } set { SetProperty(ref _polaznikId, value); } }
        int uloga;
        public int Uloga { get { return uloga; } set { SetProperty(ref uloga, value); } }
    }
}
