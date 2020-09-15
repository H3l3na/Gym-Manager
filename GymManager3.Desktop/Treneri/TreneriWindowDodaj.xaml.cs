using GymManager3.Model.Requests;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace GymManager3.Desktop.Treneri
{
    /// <summary>
    /// Interaction logic for TreneriWindowDodaj.xaml
    /// </summary>
    public partial class TreneriWindowDodaj : Window
    {
        APIService _service = new APIService("Treneri");
        APIService _serviceGrad = new APIService("Grad");
        public TreneriWindowDodaj()
        {
            InitializeComponent();
            LoadGradovi();
        }
        private async void btnSacuvaj_click(object sender, RoutedEventArgs e)
        {
            if (textBoxIme.Text=="" || textBoxPrezime.Text=="" || textBoxMail.Text=="" || textBoxAdresa.Text=="" || textBoxTelefon.Text=="" || textBoxUsername.Text=="" || passwordBoxPassword.Password=="" || passwordBoxPassPotvrda.Password == "")
            {
                errormessage.Text = "Molimo popunite sva polja";
            }
            else if (passwordBoxPassword.Password != passwordBoxPassPotvrda.Password)
            {
                errormessage.Text = "Passwordi se ne slažu";
                passwordBoxPassPotvrda.Focus();
            }
            else
            {
                TreneriInsertRequest request = new TreneriInsertRequest()
                {
                    Ime = textBoxIme.Text,
                    Prezime = textBoxPrezime.Text,
                    GradId = (int)cmbGradovi.SelectedValue,
                    KorisnickoIme = textBoxUsername.Text,
                    Password = passwordBoxPassword.Password,
                    PasswordConfirmation = passwordBoxPassPotvrda.Password,
                    Telefon = textBoxTelefon.Text,
                    Mail = textBoxMail.Text,
                    Uloga = "Trener",
                    Opis = textBoxOpis.Text,
                    DatumZaposlenja = DateTime.ParseExact(textBoxDatumZaposlenja.Text, "dd/MM/yyyy", null),
                    Adresa = textBoxAdresa.Text,
                    Slika=_imageBytes,
                    Spol=cmbSpol.SelectedValue.ToString()
                };
                await _service.Insert<Model.Trener>(request);

                Application.Current.MainWindow = new MainWindow();
                Application.Current.MainWindow.Show();
                Close();
            }
        }
        private void btnNazad_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new TreneriPrikazWindow();
            Application.Current.MainWindow.Show();
            Close();
        }
        private async void LoadGradovi()
        {
            cmbSpol.Items.Add("M");
            cmbSpol.Items.Add("Ž");
            var listaGradova = await _serviceGrad.Get<IEnumerable<Model.Grad>>(null);
            cmbGradovi.ItemsSource = listaGradova;
        }
        private byte[] _imageBytes = null;

        // Browse for an image on your computer
        private void BrowseButton_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Multiselect = false,
                Filter = "Images (*.jpg,*.png)|*.jpg;*.png|All Files(*.*)|*.*"
            };

            if (dialog.ShowDialog() != true) { return; }

            ImagePath.Text = dialog.FileName;
            MyImage.Source = new BitmapImage(new Uri(ImagePath.Text));

            using (var fs = new FileStream(ImagePath.Text, FileMode.Open, FileAccess.Read))
            {
                _imageBytes = new byte[fs.Length];
                fs.Read(_imageBytes, 0, System.Convert.ToInt32(fs.Length));
            }
        }
    }
}
