using GymManager3.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class TrenerTreningDetaljiVM: BaseViewModel
    {
        private APIService _service = new APIService("Treneri");
        private APIService _treninziService = new APIService("Treninzi");
        public TrenerTreningDetaljiVM()
        {

        }
        public TrenerTreningDetaljiVM(int _userid, Model.Trening t)
        {
            NazadCmd = new Command(async () =>
            {
                List<Model.Trening> source = await _treninziService.Get<List<Model.Trening>>(null);
                List<Model.Trening> lista = new List<Model.Trening>();

                foreach (var x in source)
                {
                    if (x.TrenerId == _userid)
                    {
                        lista.Add(new Model.Trening
                        {
                            Cijena=x.Cijena,
                            Naziv=x.Naziv,
                            Opis=x.Opis,
                            Preduvjeti=x.Preduvjeti,
                            Tezina=x.Tezina,
                            TrenerId=x.TrenerId,
                            TreningId=x.TreningId,
                            VrstaTreningaId=x.VrstaTreningaId
                            
                        });
                    }
                }

                Application.Current.MainPage = new TrenerMojiTreninziPage(_userid, lista);
            });

            _naziv = t.Naziv;
            _opis = t.Opis;
            _preduvjeti = t.Preduvjeti;
            _cijena = t.Cijena;
            _tezina = t.Tezina;
        }
        public ICommand NazadCmd { get; set; }

        string _naziv;
        public string Naziv { get { return _naziv; } set { SetProperty(ref _naziv, value); } }

        string _opis;
        public string Opis { get { return _opis; } set { SetProperty(ref _opis, value); } }


        string _tezina;
        public string Tezina { get { return _tezina; } set { SetProperty(ref _tezina, value); } }

        double? _cijena;
        public double? Cijena { get { return _cijena; } set { SetProperty(ref _cijena, value); } }
        string _preduvjeti;
        public string Preduvjeti { get { return _preduvjeti; } set { SetProperty(ref _preduvjeti, value); } }
    }
}
