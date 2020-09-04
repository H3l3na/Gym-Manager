using GymManager3.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class PolaznikMojiTerminiVM: BaseViewModel
    {
        private readonly APIService _service = new APIService("RezervacijaTreninga");
        public PolaznikMojiTerminiVM()
        {

        }

        public PolaznikMojiTerminiVM(int polaznikId, List<Model.RezervacijaTreninga> lista)
        {
            Load(polaznikId, lista);

            Nazad_Command = new Command(() =>
            {
                Application.Current.MainPage = new PolaznikMainPage(polaznikId);
            });
        }

        public List<Model.RezervacijaTreninga> listaRezervacija { get; set; } = new List<Model.RezervacijaTreninga>();

        public ICommand Nazad_Command { get; set; }

        public void Load(int userId, List<Model.RezervacijaTreninga> lista)
        {
            foreach (var x in lista)
            {
                if (x.PolaznikID == userId)
                {
                    listaRezervacija.Add(new Model.RezervacijaTreninga
                    {
                        DatumVrijeme=x.DatumVrijeme,
                        PolaznikID=x.PolaznikID,
                        RezervacijaTreningaID=x.RezervacijaTreningaID,
                        TreningID=x.TreningID,
                        Trening=x.Trening
                    });
                }
            }
        }
    }
}
