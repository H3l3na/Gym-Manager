using GymManager3.MobileApp.Views;
using GymManager3.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class TrenerMojiTreninziVM: BaseViewModel
    {
        private readonly APIService _service = new APIService("Treneri");
        public TrenerMojiTreninziVM()
        {

        }

        public TrenerMojiTreninziVM(int trenerId, List<Model.Trening> lista)
        {
            Load(trenerId, lista);

            Nazad_Command = new Command(() =>
            {
                Application.Current.MainPage = new TrenerMainPage(trenerId);
            });
        }

        public List<Model.Trening> listaTreninga { get; set; } = new List<Model.Trening>();

        public ICommand Nazad_Command { get; set; }

        public void Load(int userId, List<Model.Trening> lista)
        {
            foreach (var x in lista)
            {
                if (x.TrenerId== userId)
                {
                    listaTreninga.Add(new Model.Trening
                    {
                        Naziv=x.Naziv,
                        Cijena=x.Cijena,
                        Opis=x.Opis,
                        Preduvjeti=x.Preduvjeti,
                        Tezina=x.Tezina,
                        TrenerId=x.TrenerId,
                        TreningId=x.TreningId,
                        VrstaTreningaId=x.VrstaTreningaId
                    });
                }
            }
        }
    }
}
