﻿using GymManager3.Model;
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
    public partial class TreninziDodajWindow : Window
    {
        APIService _service = new APIService("Treninzi");
        APIService _trenerService = new APIService("Treneri");
        APIService _vrstaTreningaService = new APIService("VrstaTreninga");
        public  TreninziDodajWindow()
        {

            InitializeComponent();
            LoadTreneri();
            LoadVrsteTreninga();
            TreneriList = new ObservableCollection<string>();
            TreneriList.Add("test 1");
            TreneriList.Add("test 2");
            cmbTreneri.ItemsSource = TreneriList;
            VrsteList = new ObservableCollection<string>();
            VrsteList.Add("test");
            cmbVrsteTreninga.ItemsSource = VrsteList;
        }
        
        private void btnNazad_click(object sender, RoutedEventArgs e)
        {
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
            
            if (textBoxNaziv.Text == "" || textBoxOpis.Text == "" || textBoxCijena.Text == "" || textBoxPreduvjeti.Text == "" || textBoxTezina.Text == "")
            {
                errormessage.Text = "Molimo unesite sva polja";
            }
            else
            {
                MessageBox.Show(cmbTreneri.SelectedValue.ToString());
                TreninziInsertRequest request = new TreninziInsertRequest()
                {
                    Cijena=double.Parse(textBoxCijena.Text),
                    Naziv=textBoxNaziv.Text,
                    Opis=textBoxOpis.Text,
                    Preduvjeti=textBoxPreduvjeti.Text,
                    Tezina=textBoxTezina.Text,
                    TrenerId=(int)cmbTreneri.SelectedValue
                };
                await _service.Insert<Model.Trening>(request);
                Application.Current.MainWindow = new MainWindow();
                Application.Current.MainWindow.Show();
                Close();
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
