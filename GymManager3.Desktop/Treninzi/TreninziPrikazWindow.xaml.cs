﻿using System;
using System.Collections.Generic;
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
    /// Interaction logic for TreninziPrikazWindow.xaml
    /// </summary>
    public partial class TreninziPrikazWindow : Window
    {
        APIService _service = new APIService("Treninzi");
        public TreninziPrikazWindow()
        {
            InitializeComponent();
        }
        private async void btnPrikazi_click(object sender, RoutedEventArgs e)
        {
            ListView1.ClearValue(ItemsControl.ItemsSourceProperty);
            var listaTreninga = await _service.Get<List<Model.Trening>>(null);

            ListView1.ItemsSource = listaTreninga;
        }
        private void btnNazad_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();
            Close();
        }
        private void btnDodaj_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new TreninziDodajWindow();
            Application.Current.MainWindow.Show();
            Close();
        }

        private void ListView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListView1_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            var id = ListView1.SelectedValue;
            Model.Trening trening = (Model.Trening)id;
            Application.Current.MainWindow = new TreninziUpdateWindow(trening.TreningId);
            Application.Current.MainWindow.Show();
            Close();
        }
    }
}
