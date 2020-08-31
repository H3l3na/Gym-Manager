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
        public PolaznikMainVM()
        {
            Command_Odjava = new Command(() =>
            {
                Odjava();
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

        public async void LoadMyData(int polaznikId)
        {
            var t = await _polaznikService.GetById<Polaznik>(polaznikId);

            //Application.Current.MainPage = new StudMojiPodaciPrikazPage(t, userId, role);
        }

        public  void Odjava()
        {
            ///var t =  Application.Current.MainPage.DisplayAlert("Upozorenje", "Da li ste sigurni da se želite odjaviti?", "Da", "Ne");

            
            Application.Current.MainPage = new NewLoginPage();
            
        }
        public ICommand Command_MojiPodaci { get; set; }
        public ICommand Command_Odjava { get; set; }
        int _polaznikId;
        public int PolaznikID { get { return _polaznikId; } set { SetProperty(ref _polaznikId, value); } }
        int uloga;
        public int Uloga { get { return uloga; } set { SetProperty(ref uloga, value); } }
    }
}
