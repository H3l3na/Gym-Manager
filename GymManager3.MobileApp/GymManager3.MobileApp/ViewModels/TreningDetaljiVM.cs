using GymManager3.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class TreningDetaljiVM: BaseViewModel
    {
        private readonly APIService _service = new APIService("Treninzi");

        public TreningDetaljiVM()
        {

        }
        public TreningDetaljiVM(int trenerId, Model.Trening v)
        {
            NazadCmd = new Command( () =>
            {
               // List<Model.Trening> source = await _service.Get<List<Model.Trening>>(null);
               

                Application.Current.MainPage = new TreninziPage(trenerId);
            });

            Naziv = v.Naziv;
            Opis = v.Opis;
            Tezina = v.Tezina;
            Cijena = v.Cijena;
            Preduvjeti = v.Preduvjeti;
            TerminOdrzavanja = v.TerminOdrzavanja;
        }

        public ICommand NazadCmd { get; set; }

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
