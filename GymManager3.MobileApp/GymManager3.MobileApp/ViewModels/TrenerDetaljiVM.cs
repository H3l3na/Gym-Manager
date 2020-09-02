using GymManager3.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class TrenerDetaljiVM: BaseViewModel
    {
        private readonly APIService _service = new APIService("Treneri");

        public TrenerDetaljiVM()
        {

        }
        public TrenerDetaljiVM(int polaznikId, Model.Trener v)
        {
            NazadCmd = new Command(() =>
            {
                Application.Current.MainPage = new TreneriPage(polaznikId);
            });
            Ime = v.Ime;
            Prezime = v.Prezime;
            Email = v.Mail;
            Telefon = v.Telefon;
            Adresa = v.Adresa;
            Opis = v.Opis;
            Datum = v.DatumZaposlenja;
        }

        public ICommand NazadCmd { get; set; }

        string _ime;
        public string Ime { get { return _ime; } set { SetProperty(ref _ime, value); } }

        string _prezime;
        public string Prezime { get { return _prezime; } set { SetProperty(ref _prezime, value); } }


        DateTime? _datum;
        public DateTime? Datum { get { return _datum; } set { SetProperty(ref _datum, value); } }

        string _email;
        public string Email { get { return _email; } set { SetProperty(ref _email, value); } }

        string _telefon;
        public string Telefon { get { return _telefon; } set { SetProperty(ref _telefon, value); } }

        string _adresa;
        public string Adresa { get { return _adresa; } set { SetProperty(ref _adresa, value); } }

        string _opis;
        public string Opis { get { return _opis; } set { SetProperty(ref _opis, value); } }
    }
}
