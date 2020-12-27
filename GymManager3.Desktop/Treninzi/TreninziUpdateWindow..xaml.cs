using GymManager3.Model;
using GymManager3.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace GymManager3.Desktop.Treninzi
{
    /// <summary>
    /// Interaction logic for TreninziDodajWindow.xaml
    /// </summary>
    public partial class TreninziUpdateWindow : Window
    {
        APIService _service = new APIService("Treninzi");
        APIService _trenerService = new APIService("Treneri");
        APIService _vrstaTreningaService = new APIService("VrstaTreninga");
        APIService _terminService = new APIService("Termin");
        int? id = null;
        public  TreninziUpdateWindow(int? treningId = null)
        {

            InitializeComponent();
            id = treningId;
            LoadTreneri();
            LoadVrsteTreninga();
            TreneriList = new ObservableCollection<string>();
            TreneriList.Add("test 1");
            TreneriList.Add("test 2");
            cmbTreneri.ItemsSource = TreneriList;
            VrsteList = new ObservableCollection<string>();
            VrsteList.Add("test");
            cmbVrsteTreninga.ItemsSource = VrsteList;
            LoadData(treningId);
        }
        
        private void btnNazad_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new TreninziPrikazWindow();
            Application.Current.MainWindow.Show();
            Close();
        }

        private async void btnDelete_click(object sender, RoutedEventArgs e)
        {
            Model.Trening trening = await _service.Delete(id);
            Application.Current.MainWindow = new TreninziPrikazWindow();
            Application.Current.MainWindow.Show();
            Close();
        }
        private async void LoadTreneri()
        {
            var listaTrenera = await _trenerService.Get<IEnumerable<Model.Trener>>(null);
            //cmbTreneri.ItemsSource = listaTrenera;
            //List<KeyValuePair<int, string>> lista = new List<KeyValuePair<int, string>>();
            //foreach (var x in listaTrenera)
            //{
            //    lista.Add(new KeyValuePair<int, string>(x.TrenerId, x.Ime + " " + x.Prezime));
            //}
            
            cmbTreneri.ItemsSource = listaTrenera;
        }
        private async void LoadVrsteTreninga()
        {
            var listaVrsti = await _vrstaTreningaService.Get<IEnumerable<Model.VrstaTreninga>>(null);
            cmbVrsteTreninga.ItemsSource = listaVrsti;
        }
        private async void btnSacuvaj_click(object sender, RoutedEventArgs e)
        {
            double value1;
            int value2;
            if (dtmTermin.SelectedDate==null || cmbTreneri.SelectedValue==null || cmbVrsteTreninga.SelectedValue==null  || textBoxNaziv.Text == "" || textBoxOpis.Text == "" || textBoxPreduvjeti.Text == "" || textBoxTezina.Text == "" || textBoxKapacitet.Text == "" || textBoxCijena.Text == "")
            {
                errormessage.Text = "Sva polja su obavezna";
            }
            else if (!(double.TryParse(textBoxCijena.Text, out value1)))
            {
                errormessage.Text = "Polje cijena mora biti broj";
            }
            else if (double.TryParse(textBoxCijena.Text, out value1) && (double.Parse(textBoxCijena.Text) < 50 || double.Parse(textBoxCijena.Text) > 1000))
            {
                errormessage.Text = "Polje cijena mora biti broj izmedju 50 i 1000";
            }
            else if (!(int.TryParse(textBoxKapacitet.Text, out value2)))
            {
                errormessage.Text = "Polje kapacitet mora biti broj";
            }
            else if ((int.TryParse(textBoxKapacitet.Text, out value2)) && ((int.Parse(textBoxKapacitet.Text) < 0) || (int.Parse(textBoxKapacitet.Text) > 30)))
            {
                errormessage.Text = "Polje kapacitet mora biti u rasponu od 0 do 30";
            }
            else
            {
                TreningUpdateRequest request = new TreningUpdateRequest()
                {
                    Naziv = textBoxNaziv.Text,
                    Opis = textBoxOpis.Text,
                    Preduvjeti = textBoxPreduvjeti.Text,
                    Kapacitet = int.Parse(textBoxKapacitet.Text),
                    Cijena = double.Parse(textBoxCijena.Text),
                    Tezina = textBoxTezina.Text,
                    TerminOdrzavanja=dtmTermin.SelectedDate,
                    TrenerId=int.Parse(cmbTreneri.SelectedValue.ToString()),
                    VrstaTreningaId = int.Parse(cmbVrsteTreninga.SelectedValue.ToString()),
                };
                await _service.Update<Model.Trening>(id, request);
                Application.Current.MainWindow = new MainWindow();
                Application.Current.MainWindow.Show();
                Close();
            }
            /*
            if (textBoxNaziv.Text == "" || textBoxOpis.Text == "" || textBoxCijena.Text == "" || textBoxPreduvjeti.Text == "" || textBoxTezina.Text == "" || dtmTermin.Text=="")
            {
                errormessage.Text = "Molimo unesite sva polja";
            }
            else
            {
                //MessageBox.Show(cmbTreneri.SelectedValue.ToString());
                string sala = "";
                if (int.Parse(cmbVrsteTreninga.SelectedValue.ToString()) == 1)
                {
                    sala = "Sala 1";
                }else if (int.Parse(cmbVrsteTreninga.SelectedValue.ToString()) == 2)
                {
                    sala = "Sala 2";
                }else if (int.Parse(cmbVrsteTreninga.SelectedValue.ToString()) == 3)
                {
                    sala = "Sala 3";
                }else if (int.Parse(cmbVrsteTreninga.SelectedValue.ToString()) == 4)
                {
                    sala = "Sala 4";
                }
                TreninziInsertRequest request = new TreninziInsertRequest()
                {
                    Cijena=double.Parse(textBoxCijena.Text),
                    Naziv=textBoxNaziv.Text,
                    Opis=textBoxOpis.Text,
                    Preduvjeti=textBoxPreduvjeti.Text,
                    Tezina=textBoxTezina.Text,
                    TrenerId=(int)cmbTreneri.SelectedValue,
                    TerminOdrzavanja=DateTime.Parse(dtmTermin.ToString()),
                    VrstaTreningaId=int.Parse(cmbVrsteTreninga.SelectedValue.ToString()),
                    Kapacitet=int.Parse(textBoxKapacitet.Text)
                    
                };
                await _service.Insert<Model.Trening>(request);
                List<Model.Trening> lista =await _service.Get<List<Model.Trening>>();
                Model.Trening trening = lista.Last();
                TerminInsertRequest terminRequest = new TerminInsertRequest()
                {
                    TerminOdrzavanja= DateTime.Parse(dtmTermin.ToString()),
                    Sala=sala,
                    TrenerId= (int)cmbTreneri.SelectedValue,
                    TreningId=trening.TreningId,
                };
                await _terminService.Insert<Model.Termin>(terminRequest);
               
               // await _service.Insert<Model.Trening>(request);
                Application.Current.MainWindow = new MainWindow();
                Application.Current.MainWindow.Show();
                Close();
            }*/
        }

        private async void LoadData(int? treningId)
        {
            if (treningId != null)
            {
                Model.Trening trening = await _service.GetById<Model.Trening>(treningId);
                if (trening != null)
                {
                    textBoxNaziv.Text = trening.Naziv;
                    textBoxOpis.Text = trening.Opis;
                    textBoxTezina.Text = trening.Tezina;
                    textBoxOpis.Text = trening.Opis;
                    textBoxKapacitet.Text = trening.Kapacitet.ToString();
                    textBoxPreduvjeti.Text = trening.Preduvjeti;
                    textBoxCijena.Text = trening.Cijena.ToString();
                    dtmTermin.SelectedDate = trening.TerminOdrzavanja;
                    cmbTreneri.SelectedValue = trening.TrenerId;
                    cmbVrsteTreninga.SelectedValue = trening.VrstaTreningaId;
                }
            }
        }

        //private async void cmbTreneri_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
            

        //    var listaTrenera = await _trenerService.Get<IEnumerable<Model.Trener>>(null);
        //    cmbTreneri.ItemsSource = listaTrenera;
        //}
        public ObservableCollection<string> TreneriList { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> VrsteList { get; set; } = new ObservableCollection<string>();

    }
}
