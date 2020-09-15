using GymManager3.MobileApp.Views;
using GymManager3.Model;
using GymManager3.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class TrenerTerminIzmjenaVM: BaseViewModel
    {
        private readonly APIService _service= new APIService("Termin");
        private readonly APIService _treningService = new APIService("Treninzi");
        private readonly APIService _rezervacijaService = new APIService("RezervacijaTreninga");
        public TrenerTerminIzmjenaVM()
        {

        }
        public TrenerTerminIzmjenaVM(int trenerId, List<Model.Termin> lista, int terminId)
        {
            
            NazadCommand = new Command(() => Nazad(trenerId, lista));
            SacuvajCommand = new Command(() => Sacuvaj(terminId, trenerId));

        }
        public ICommand NazadCommand { get; set; }
        public ICommand SacuvajCommand { get; set; }

        string _terminOdrz = string.Empty;
        public string TerminOdrz
        {
            get { return _terminOdrz; }
            set { SetProperty(ref _terminOdrz, value); }
        }
        public async void Sacuvaj(int terminId, int trenerId)
        {
            Model.Termin t = await _service.GetById<Model.Termin>(terminId);
          
            TerminInsertRequest request = new TerminInsertRequest()
            {
                Sala=t.Sala,
                MaxBrPolaznika=t.MaxBrPolaznika,
                TrenerId=t.TrenerId,
                TreningId=t.TreningId,
                TerminOdrzavanja=DateTime.Parse(TerminOdrz.ToString())
            };
            List<Model.Trening> listaTreninga = await _treningService.Get<List<Model.Trening>>();
            int TreningId=0;
            foreach (var x in listaTreninga)
            {
                if (x.TrenerId == trenerId && x.TerminOdrzavanja == t.TerminOdrzavanja)
                {
                    TreninziInsertRequest treningRequest = new TreninziInsertRequest()
                    {
                        Cijena = x.Cijena,
                        Naziv = x.Naziv,
                        Opis = x.Opis,
                        Preduvjeti = x.Preduvjeti,
                        TerminOdrzavanja = DateTime.Parse(TerminOdrz),
                        Tezina = x.Tezina,
                        TrenerId = x.TrenerId,
                        VrstaTreningaId = x.VrstaTreningaId,

                    };
                    TreningId = x.TreningId;
                    try
                    {
                        //await Application.Current.MainPage.DisplayAlert("", TreningId.ToString()+" " + x.Cijena, "OK");
                        await _treningService.Update<Model.Trening>(TreningId, treningRequest);
                        int id = (int)t.TrenerId;
                        Application.Current.MainPage = new TreneriPage(id);
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Greska", ex.Message, "OK");
                    }
                }
            }
            List<Model.RezervacijaTreninga> listaRezervacija = await _rezervacijaService.Get<List<Model.RezervacijaTreninga>>();
            foreach(var x in listaRezervacija)
            {
                if (x.TreningID == TreningId)
                {
                    RezervacijaTreningaInsertRequest rezervacijaRequest = new RezervacijaTreningaInsertRequest()
                    {
                        DatumVrijeme= DateTime.Parse(TerminOdrz),
                        PolaznikID=x.PolaznikID,
                        TreningID=x.TreningID
                    };
                    try
                    {
                        await _rezervacijaService.Update<Model.RezervacijaTreninga>(x.RezervacijaTreningaID, rezervacijaRequest);
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
                    }
                }
            }
            try
            {
                await _service.Update<Model.Termin>(terminId, request);
                int id = (int)t.TrenerId;
                Application.Current.MainPage = new TrenerMainPage(id);
            }catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greska", ex.Message, "Ok");
            }
        }
        public void Nazad(int trenerId, List<Model.Termin> lista)
        {
            Application.Current.MainPage = new TrenerMojiTerminiPage(trenerId, lista);
        }

    }
}
