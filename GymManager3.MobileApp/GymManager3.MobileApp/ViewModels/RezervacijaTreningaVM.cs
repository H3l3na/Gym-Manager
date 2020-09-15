using GymManager3.MobileApp.Views;
using GymManager3.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class RezervacijaTreningaVM: BaseViewModel
    {
        private readonly APIService _service = new APIService("Treninzi");
        private readonly APIService _rezervacijaService = new APIService("RezervacijaTreninga");

        public RezervacijaTreningaVM()
        {

        }
        public RezervacijaTreningaVM(int polaznikId, Model.Trening v)
        {
            NazadCmd = new Command(() =>
            {
                // List<Model.Trening> source = await _service.Get<List<Model.Trening>>(null);


                Application.Current.MainPage = new ListaTreningaZaRezervacijuPage(polaznikId);
            });
            RezervisiCmd = new Command(async () =>
              {
                  List<Model.RezervacijaTreninga> lista = await _rezervacijaService.Get<List<Model.RezervacijaTreninga>>();
                  bool pronasao = false;
                  foreach(var x in lista)
                  {
                      if (x.PolaznikID == polaznikId && x.TreningID == v.TreningId)
                      {
                          //await Application.Current.MainPage.DisplayAlert("Upozorenje", "Odabrani trening ste vec rezervisali", "OK");
                          pronasao = true;
                          //Application.Current.MainPage = new ListaTreningaZaRezervacijuPage(polaznikId);
                      }
                  }
                  if (pronasao == true)
                  {
                      await Application.Current.MainPage.DisplayAlert("Upozorenje", "Odabrani trening ste vec rezervisali", "OK");
                      Application.Current.MainPage = new ListaTreningaZaRezervacijuPage(polaznikId);
                  }
                  else if (pronasao == false)
                  {
                      int brojac = 1;
                      List<Model.RezervacijaTreninga> listaTreninga = await _rezervacijaService.Get<List<Model.RezervacijaTreninga>>();
                      foreach(var x in listaTreninga)
                      {
                          if (x.TreningID == v.TreningId)
                          {
                              brojac++;
                          }
                      }
                      if (brojac == v.Kapacitet || brojac > v.Kapacitet)
                      {
                          await Application.Current.MainPage.DisplayAlert("Upozorenje", "Mjesta su popunjena. Odaberite drugi trening", "OK");
                          Application.Current.MainPage = new ListaTreningaZaRezervacijuPage(polaznikId);
                      }
                      else
                      {
                          RezervacijaTreningaInsertRequest request = new RezervacijaTreningaInsertRequest()
                          {
                              DatumVrijeme = v.TerminOdrzavanja,
                              PolaznikID = polaznikId,
                              TreningID = v.TreningId
                          };
                          await _rezervacijaService.Insert<Model.RezervacijaTreninga>(request);
                          await Application.Current.MainPage.DisplayAlert("", "Uspješno ste rezervisali trening", "OK");
                          Application.Current.MainPage = new PolaznikMainPage(polaznikId);
                      }
                      
                  }

              }); 

            Naziv = v.Naziv;
            Opis = v.Opis;
            Tezina = v.Tezina;
            Cijena = v.Cijena;
            Preduvjeti = v.Preduvjeti;
            TerminOdrzavanja = v.TerminOdrzavanja;





            
        }

        public ICommand NazadCmd { get; set; }
        public ICommand RezervisiCmd { get; set; }

        string _naziv;
        public string Naziv { get { return _naziv; } set { SetProperty(ref _naziv, value); } }

        DateTime? _terminOdrzavanja;
        public DateTime? TerminOdrzavanja { get { return _terminOdrzavanja; } set { SetProperty(ref _terminOdrzavanja, value); } }

        string _opis;
        public string Opis { get { return _opis; } set { SetProperty(ref _opis, value); } }


        string _tezina;
        public string Tezina { get { return _tezina; } set { SetProperty(ref _tezina, value); } }

        double? _cijena;
        public double? Cijena { get { return _cijena; } set { SetProperty(ref _cijena, value); } }
        string _preduvjeti;
        public string Preduvjeti { get { return _preduvjeti; } set { SetProperty(ref _preduvjeti, value); } }
    }
}
