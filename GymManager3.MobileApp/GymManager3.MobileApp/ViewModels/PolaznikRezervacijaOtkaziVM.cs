using GymManager3.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class PolaznikRezervacijaOtkaziVM: BaseViewModel
    {
        private readonly APIService _service = new APIService("RezervacijaTreninga");

        public PolaznikRezervacijaOtkaziVM()
        {

        }
        public PolaznikRezervacijaOtkaziVM(int _userid, Model.RezervacijaTreninga v)
        {
            NazadCmd = new Command(async () =>
            {
                List<Model.RezervacijaTreninga> source = await _service.Get<List<Model.RezervacijaTreninga>>(null);
                List<Model.RezervacijaTreninga> lista = new List<Model.RezervacijaTreninga>();

                foreach (var x in source)
                {
                    if (x.PolaznikID == _userid)
                    {
                        lista.Add(new Model.RezervacijaTreninga
                        {
                           DatumVrijeme=x.DatumVrijeme,
                           PolaznikID=x.PolaznikID,
                           RezervacijaTreningaID=x.RezervacijaTreningaID,
                           Trening=x.Trening,
                           TreningID=x.TreningID
                        });
                    }
                }

                Application.Current.MainPage = new PolaznikMojiTerminiPage(_userid, lista);
            });
            OtkaziCmd = new Command(async () =>
            {
                try
                {
                    int id = v.RezervacijaTreningaID;
                    DateTime datumDanas = DateTime.Now;
                    DateTime datum = DateTime.Parse(v.DatumVrijeme.ToString());
                    List<Model.RezervacijaTreninga> listaRezervacija = new List<Model.RezervacijaTreninga>();
                    listaRezervacija = await _service.Get<List<Model.RezervacijaTreninga>>();
                    if (datumDanas.Day == datum.Day && datumDanas.Month == datum.Month && datumDanas.Year == datum.Year)
                    {
                        await Application.Current.MainPage.DisplayAlert("Upozorenje", "Ne možete otkazati rezervaciju za isti dan", "OK");
                        Application.Current.MainPage = new PolaznikMojiTerminiPage(_userid, listaRezervacija);
                    }
                    else
                    {
                        List<Model.RezervacijaTreninga> azuriranaLista = await _service.Get<List<Model.RezervacijaTreninga>>();
                        await _service.Delete(id);
                        await Application.Current.MainPage.DisplayAlert("", "Uspješno ste otkazali rezervaciju", "OK");
                        Application.Current.MainPage = new PolaznikMainPage(_userid);
                    }
                }catch(Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
                }
            });

            TerminOdrzavanja = v.DatumVrijeme;
            Trening = v.Trening;
        }

        public ICommand NazadCmd { get; set; }
        public ICommand OtkaziCmd { get; set; }

        DateTime? _terminOdrzavanja;
        public DateTime? TerminOdrzavanja { get { return _terminOdrzavanja; } set { SetProperty(ref _terminOdrzavanja, value); } }

        string _trening;
        public string Trening { get { return _trening; } set { SetProperty(ref _trening, value); } }
    }
}
