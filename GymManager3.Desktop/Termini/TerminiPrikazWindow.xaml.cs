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

namespace GymManager3.Desktop.Termini
{
    /// <summary>
    /// Interaction logic for TerminiPrikazWindow.xaml
    /// </summary>
    public partial class TerminiPrikazWindow : Window
    {
        private APIService _service = new APIService("Termin");
        public TerminiPrikazWindow()
        {
            InitializeComponent();
        }
        private async void btnPrikazi_click(object sender, RoutedEventArgs e)
        {
            ListView1.Items.Clear();
            var listaTermina = await _service.Get<List<Model.Termin>>(null);

            ListView1.ItemsSource = listaTermina;
        }
        private void btnNazad_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();
            Close();
        }
    }
}
