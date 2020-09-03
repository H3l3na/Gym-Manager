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
        public TrenerTerminIzmjenaVM()
        {

        }
        public TrenerTerminIzmjenaVM(int trenerId, List<Model.Termin> lista, int terminId)
        {
            
            NazadCommand = new Command(() => Nazad(trenerId, lista));
            SacuvajCommand = new Command(() => Sacuvaj(terminId));

        }
        public ICommand NazadCommand { get; set; }
        public ICommand SacuvajCommand { get; set; }

        string _terminOdrz = string.Empty;
        public string TerminOdrz
        {
            get { return _terminOdrz; }
            set { SetProperty(ref _terminOdrz, value); }
        }
        public async void Sacuvaj(int terminId)
        {
            Model.Termin t = await _service.GetById<Model.Termin>(terminId);
            TerminInsertRequest request = new TerminInsertRequest()
            {
                Sala=t.Sala,
                MaxBrPolaznika=t.MaxBrPolaznika,
                TrenerId=t.TrenerId,
                TreningId=t.TreningId,
                TerminOdrzavanja=DateTime.Parse(TerminOdrz)
            };
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
