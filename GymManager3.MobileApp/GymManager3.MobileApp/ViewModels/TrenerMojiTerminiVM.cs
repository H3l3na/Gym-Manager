using GymManager3.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class TrenerMojiTerminiVM: BaseViewModel
    {
        private readonly APIService _service = new APIService("Termin");
        public TrenerMojiTerminiVM()
        {

        }

        public TrenerMojiTerminiVM(int trenerId, List<Model.Termin> lista)
        {
            Load(trenerId, lista);

            Nazad_Command = new Command(() =>
            {
                Application.Current.MainPage = new TrenerMainPage(trenerId);
            });
           // Izmijeni_Command = new Command(() =>
           //{
           //    Application.Current.MainPage = new TrenerTerminIzmjenaPage(trenerId, lista);
           //});
        }

        public List<Model.Termin> listaTermina { get; set; } = new List<Model.Termin>();

        public ICommand Nazad_Command { get; set; }
        public ICommand Izmijeni_Command { get; set; }

        public void Load(int userId, List<Model.Termin> lista)
        {
            foreach (var x in lista)
            {
                if (x.TrenerId == userId)
                {
                    listaTermina.Add(new Model.Termin
                    {
                        MaxBrPolaznika=x.MaxBrPolaznika,
                        Sala=x.Sala,
                        TerminID=x.TerminID,
                        TerminOdrzavanja=x.TerminOdrzavanja,
                        TrenerId=x.TrenerId,
                        Trener=x.Trener,
                        Trening=x.Trening,
                        TreningId=x.TreningId
                    });
                }
            }
        }
    }
    
}
