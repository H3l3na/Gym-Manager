using GymManager3.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class TrenerTerminDetaljiVM: BaseViewModel
    {
        private readonly APIService _service = new APIService("Termin");

        public TrenerTerminDetaljiVM()
        {

        }
        public TrenerTerminDetaljiVM(int _userid, Model.Termin t)
        {
            NazadCmd = new Command(async () =>
            {
                List<Model.Termin> source = await _service.Get<List<Model.Termin>>(null);
                List<Model.Termin> lista = new List<Model.Termin>();

                foreach (var x in source)
                {
                    if (x.TrenerId == _userid)
                    {
                        lista.Add(new Model.Termin
                        {
                            MaxBrPolaznika=x.MaxBrPolaznika,
                            Sala=x.Sala,
                            TerminID=x.TerminID,
                            TerminOdrzavanja=x.TerminOdrzavanja,
                            Trener=x.Trener,
                            TrenerId=x.TrenerId,
                            Trening=x.Trening,
                            TreningId=x.TreningId
                        });
                    }
                }

                Application.Current.MainPage = new TrenerMojiTerminiPage(_userid, lista);
            });

            IzmijeniCommand = new Command(async () =>
              {
                  List<Model.Termin> source = await _service.Get<List<Model.Termin>>(null);
                  List<Model.Termin> lista = new List<Model.Termin>();

                  foreach (var x in source)
                  {
                      if (x.TrenerId == _userid)
                      {
                          lista.Add(new Model.Termin
                          {
                              MaxBrPolaznika = x.MaxBrPolaznika,
                              Sala = x.Sala,
                              TerminID = x.TerminID,
                              TerminOdrzavanja = x.TerminOdrzavanja,
                              Trener = x.Trener,
                              TrenerId = x.TrenerId,
                              Trening = x.Trening,
                              TreningId = x.TreningId
                          });
                      }
                  }
                  Application.Current.MainPage = new TrenerTerminIzmjenaPage(_userid, lista, t.TerminID);
              });

            Datum = t.TerminOdrzavanja;
            Sala = t.Sala;
            TerminID = t.TerminID;
            TreningID = t.TreningId;
            MaxBrPolaznika = t.MaxBrPolaznika;
            TrenerID = t.TrenerId;
            Trener = t.Trener;
            Trening = t.Trening;
        }

        public ICommand NazadCmd { get; set; }
        public ICommand IzmijeniCommand { get; set; }
       

        DateTime? _datum;
        public DateTime? Datum { get { return _datum; } set { SetProperty(ref _datum, value); } }

        string _sala;
        public string Sala { get { return _sala; } set { SetProperty(ref _sala, value); } }

        string _trener;
        public string Trener { get { return _trener; } set { SetProperty(ref _trener, value); } }

        string _trening;
        public string Trening { get { return _trening; } set { SetProperty(ref _trening, value); } }

        int? _maxBrPolaznika;
        public int? MaxBrPolaznika { get { return _maxBrPolaznika; } set { SetProperty(ref _maxBrPolaznika, value); } }

        int? _trenerId;
        public int? TrenerID { get { return _trenerId; } set { SetProperty(ref _trenerId, value); } }

        int? _treningId;
        public int? TreningID { get { return _treningId; } set { SetProperty(ref _treningId, value); } }

        int _terminId;
        public int TerminID { get { return _terminId; } set { SetProperty(ref _terminId, value); } }

    }
}
