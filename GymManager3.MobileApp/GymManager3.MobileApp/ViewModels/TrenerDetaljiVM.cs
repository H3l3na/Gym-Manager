using GymManager3.MobileApp.Views;
using GymManager3.Model;
using GymManager3.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class TrenerDetaljiVM: BaseViewModel
    {
        private readonly APIService _service = new APIService("Treneri");
        private readonly APIService _ocjeneService = new APIService("Ocjene");
        private readonly APIService _recommendService = new APIService("Recommend");

        public TrenerDetaljiVM()
        {

        }
        public TrenerDetaljiVM(int polaznikId, Model.treneri v)
        {
            NazadCmd = new Command(() =>
            {
                Application.Current.MainPage = new TreneriPage(polaznikId);
            });
            
            RatingCommand = new Command(async () => await SetNewRating(polaznikId, v.TrenerId));
            
            Ime = v.Ime;
            //Prezime = v.Prezime;
            if (v.Slika != null)
            {
                Slika = ImageSource.FromStream(() => new MemoryStream(v.Slika));
            }
         
            Email = v.Mail;
            Telefon = v.Telefon;
            Adresa = v.Adresa;
            Opis = v.Opis;
            Datum = v.DatumZaposlenja;
        }

        public ObservableCollection<Model.treneri> RecommendedTrainersList { get; set; } = new ObservableCollection<Model.treneri>();
        public async Task LoadTrainers(int trenerId)
        {
            List<Model.treneri> rec = await _recommendService.Get<List<Model.treneri>>(new RecommendedSearchRequest()
            {
                TrenerID = trenerId,
            });

            RecommendedTrainersList.Clear();
            foreach (var t in rec)
            {
                RecommendedTrainersList.Add(t);
            }
        }
        public ICommand NazadCmd { get; set; }
        public ICommand RatingCommand { get; set; }

        private string _userRating = string.Empty;
        ImageSource _slika;
        public ImageSource Slika { get { return _slika; } set { SetProperty(ref _slika, value); } }
        public string UserRating
        {
            get { return _userRating; }
            set { SetProperty(ref _userRating, value); }
        }
        public async Task SetNewRating(int polaznikId, int trenerId)
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Alert", "Da li želite dodati ocjenu?", "Da", "Ne");
            if (answer)
            {
                if (int.TryParse(UserRating, out int val))
                {
                    if (val < 0 || val > 10)
                    {
                        await Application.Current.MainPage.DisplayAlert("Alert", "Ocjena mora biti u rasponu od 1 do 10", "OK");
                        return;
                    }
                    await _ocjeneService.Insert<Model.Ocjene>(new OcjeneUpsertRequest
                    {
                        PolaznikID = polaznikId,
                        TrenerID = trenerId,
                        Ocjena = int.Parse(UserRating)
                    });

                    await Application.Current.MainPage.DisplayAlert("Success", "Uspješno ste dodali ocjenu.", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", "Pogrešan unos.", "Pokušajte ponovo");
                }
            }
        }

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
