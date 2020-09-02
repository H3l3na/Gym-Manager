using GymManager3.MobileApp.Views;
using GymManager3.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class PolaznikUplateDetaljiVM: BaseViewModel
    {
        private readonly APIService _service = new APIService("Uplate");

        public PolaznikUplateDetaljiVM()
        {

        }
        public PolaznikUplateDetaljiVM(int _userid, uplate v)
        {
            NazadCmd = new Command(async () =>
            {
                List<uplate> source = await _service.Get<List<uplate>>(null);
                List<uplate> lista = new List<uplate>();

                foreach (var x in source)
                {
                    if (x.PolaznikId == _userid)
                    {
                        lista.Add(new uplate
                        {
                            AdministracijaId = x.AdministracijaId,
                            DatumUplate = x.DatumUplate,
                            PolaznikId=x.PolaznikId,
                            Evidentirao = x.Evidentirao,
                            Iznos = x.Iznos,
                            Svrha = x.Svrha,
                            UplataId = x.UplataId,
                            Uplatio = x.Uplatio
                        });
                    }
                }

                Application.Current.MainPage = new PolaznikMojeUplatePage(_userid, lista);
            });

            Iznos = v.Iznos;
            Svrha = v.Svrha;
            Datum = v.DatumUplate.Value;
            Evidentirao = v.Evidentirao;
        }

        public ICommand NazadCmd { get; set; }

        double? _iznos;
        public double? Iznos { get { return _iznos; } set { SetProperty(ref _iznos, value); } }

        string _svrha;
        public string Svrha { get { return _svrha; } set { SetProperty(ref _svrha, value); } }


        DateTime _datum;
        public DateTime Datum { get { return _datum; } set { SetProperty(ref _datum, value); } }

        string _evidentirao;
        public string Evidentirao { get { return _evidentirao; } set { SetProperty(ref _evidentirao, value); } }
    }
}
