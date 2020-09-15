using GymManager3.MobileApp.Views;
using GymManager3.Model;
using GymManager3.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class PolaznikRezervacijaTreneraVM: BaseViewModel
    {
        private readonly APIService _treneriService = new APIService("Treneri");
        private readonly APIService _terminiService = new APIService("SlobodniTermini");
        private readonly APIService _rezervacijaService = new APIService("RezervacijaTrenera");
        public PolaznikRezervacijaTreneraVM()
        {

        }
        public PolaznikRezervacijaTreneraVM(int id)
        {
            InitCommand = new Command(async () => await Init());
            NazadCmd = new Command(() =>
              {
                  Application.Current.MainPage = new PolaznikMainPage(id);
              });
            RezervisiCmd = new Command(() =>
              {
                  Rezervisi(id);
              });
        }
        public ObservableCollection<Trener> TreneriList { get; set; } = new ObservableCollection<Trener>();
        public ObservableCollection<SlobodniTermini> TerminiList { get; set; } = new ObservableCollection<SlobodniTermini>();
        public ICommand InitCommand { get; set; }
        public ICommand NazadCmd { get; set; }
        public ICommand RezervisiCmd { get; set; }
        private Trener _selectedTrener;
        public Trener SelectedTrener
        {
            get
            {
                return _selectedTrener;
            }
            set
            {
                SetProperty(ref _selectedTrener, value);
                //put here your code  
                
            }
        }
        private SlobodniTermini _selectedTermin;
        public SlobodniTermini SelectedTermin
        {
            get
            {
                return _selectedTermin; 
            }
            set
            {
                SetProperty(ref _selectedTermin, value);
                //put here your code  

            }
        }
        //private string _selectedTrainer = ;
        //public string SelectedDepartment
        //{
        //    get { return _selectedDepartment; }
        //    set
        //    {

        //        _selectedDepartment = value;
        //        OnPropertyChanged();

        //    }
        //}


        public async void Rezervisi(int polaznikId)
        {
            List<RezervacijaTrenera> listaRezervacija =  await _rezervacijaService.Get<List<Model.RezervacijaTrenera>>();
            bool var1 = false;
            bool var2 = false;
            try
            {
                if (SelectedTrener == null || SelectedTermin == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Greska", "Niste unijeli sva polja", "OK");
                    Application.Current.MainPage = new PolaznikRezervacijaTreneraPage(polaznikId);
                }
                else
                {
                    foreach(var x in listaRezervacija)
                    {
                        SlobodniTermini termin = await _terminiService.GetById<Model.SlobodniTermini>(x.SlobodniTerminiID);
                        if(x.PolaznikID==polaznikId && SelectedTrener.TrenerId==x.TrenerID && SelectedTermin.Termin == termin.Termin)
                        {
                           await Application.Current.MainPage.DisplayAlert("Greska", "Odabrani termin ste vec rezervisali sa datim trenerom. Molimo odaberite drugi termin", "OK");
                            var1 = true;
                            //Application.Current.MainPage = new PolaznikRezervacijaTreneraPage(polaznikId);
                            break;
                        }else if (SelectedTrener.TrenerId == x.TrenerID && SelectedTermin.Termin == termin.Termin)
                        {
                            var2 = true;
                            await Application.Current.MainPage.DisplayAlert("Greska", "Odabrani trener je u datom terminu zauzet. Odaberite novog trenera ili novi termin", "OK");
                           // Application.Current.MainPage = new PolaznikRezervacijaTreneraPage(polaznikId);
                            break;
                        }
                        
                    }

                    if (var1 == false && var2 == false)
                    {
                        RezervacijaTreneraInsertRequest request = new RezervacijaTreneraInsertRequest()
                        {
                            TrenerID = SelectedTrener.TrenerId,
                            PolaznikID = polaznikId,
                            SlobodniTerminiID = SelectedTermin.SlobodniTerminiID
                        };
                        await _rezervacijaService.Insert<Model.RezervacijaTrenera>(request);
                        await Application.Current.MainPage.DisplayAlert("", "Rezervacija uspješna", "OK");
                        Application.Current.MainPage = new PolaznikMainPage(polaznikId);
                    }else
                    {
                        
                        Application.Current.MainPage = new PolaznikRezervacijaTreneraPage(polaznikId);
                    }
                   
                }
                
            }
            catch (Exception ex)
            {
               await Application.Current.MainPage.DisplayAlert("Greska", ex.Message, "OK");
                Application.Current.MainPage = new PolaznikMainPage(polaznikId);
            }
        }
        public async Task Init()
        {
            var list = await _treneriService.Get<IEnumerable<Trener>>(null);
            var list1 = await _terminiService.Get<IEnumerable<SlobodniTermini>>(null);
            TreneriList.Clear();
            TerminiList.Clear();
            foreach (var trener in list)
            {
                TreneriList.Add(trener);
            }
            foreach(var termin in list1)
            {
                TerminiList.Add(termin);
            }
        }
    }
}
