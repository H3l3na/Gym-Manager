using GymManager3.MobileApp.Views;
using GymManager3.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class TrenerMainVM: BaseViewModel
    {
        private readonly APIService _treninziService = new APIService("Treninzi");
        private readonly APIService _treneriService = new APIService("Treneri");
        private readonly APIService _terminiService = new APIService("Termin");
        public TrenerMainVM()
        {
            Command_Odjava = new Command(() =>
            {
                Odjava();
            });

        }
        public TrenerMainVM(int id)
        {
            Command_Odjava = new Command(() =>
            {
                Odjava();
            });
            TrenerID = id;
            Command_MojiPodaci = new Command(() =>
            {
                LoadMyData(id);
            });
            
            Command_Treninzi = new Command(() =>
            {
                LoadTreninge(id);
            });
            Command_Termini = new Command(() =>
              {
                  LoadTermine(id);
              });
        }
     
        public List<Model.Trening> listaTreninga = new List<Model.Trening>();
        public List<Model.Termin> listaTermina = new List<Model.Termin>();
       
        public async void LoadTreninge(int userId)
        {
            var t = await _treninziService.Get<List<Model.Trening>>(null);

            foreach (var x in t)
            {
                if (x.TrenerId == userId)
                {
                    listaTreninga.Add(new Model.Trening
                    {
                        Naziv = x.Naziv,
                        Cijena = x.Cijena,
                        Opis = x.Opis,
                        Preduvjeti = x.Preduvjeti,
                        Tezina = x.Tezina,
                        TrenerId = x.TrenerId,
                        TreningId = x.TreningId,
                        VrstaTreningaId = x.VrstaTreningaId
                    });
                }
            }

            Application.Current.MainPage = new TrenerMojiTreninziPage(userId, listaTreninga);

        }
        
        public async void LoadTermine(int trenerId)
        {
            listaTermina = await _terminiService.Get<List<Model.Termin>>(null);
            //foreach (var x in t)
            //{
            //    if (x.TrenerId == trenerId)
            //    {
            //        listaTermina.Add(new Model.Termin
            //        {
            //            Sala=x.Sala,
            //            MaxBrPolaznika=x.MaxBrPolaznika,
            //            TerminID=x.TerminID,
            //            TerminOdrzavanja=x.TerminOdrzavanja,
            //            Trener=x.Trener,
            //            TrenerId=x.TrenerId,
            //            Trening=x.Trening,
            //            TreningId=x.TreningId
            //        });
            //    }
            //}
            Application.Current.MainPage = new TrenerMojiTerminiPage(trenerId, listaTermina);
        }

        public async void LoadMyData(int trenerId)
        {
            var t = await _treneriService.GetById<Model.Trener>(trenerId);

            Application.Current.MainPage = new TrenerMojiPodaciPage(trenerId, t);
        }

        public void Odjava()
        {
            ///var t =  Application.Current.MainPage.DisplayAlert("Upozorenje", "Da li ste sigurni da se želite odjaviti?", "Da", "Ne");


            Application.Current.MainPage = new NewLoginPage();

        }
        public ICommand Command_MojiPodaci { get; set; }
        public ICommand Command_Odjava { get; set; }
        public ICommand Command_Treninzi { get; set; }
        public ICommand Command_Termini { get; set; }
        int _trenerId;
        public int TrenerID { get { return _trenerId; } set { SetProperty(ref _trenerId, value); } }
        
    }
}
