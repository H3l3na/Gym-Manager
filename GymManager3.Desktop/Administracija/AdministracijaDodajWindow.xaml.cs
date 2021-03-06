﻿using GymManager3.Model.Requests;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace GymManager3.Desktop.Administracija
{
    /// <summary>
    /// Interaction logic for AdministracijaDodajWindow.xaml
    /// </summary>
    public partial class AdministracijaDodajWindow : Window
    {
        APIService _service = new APIService("Administracija");
        APIService _serviceGrad = new APIService("Grad");
        public AdministracijaDodajWindow()
        {
            InitializeComponent();
            LoadGradovi();
        }
        private async void btnSacuvaj_click(object sender, RoutedEventArgs e)
        {
            List<Model.Administracija> listaAdmina = await _service.Get<List<Model.Administracija>>();
            bool postojiUsername = false;
            foreach (Model.Administracija a in listaAdmina)
            {
                if (textBoxUsername.Text != "" && textBoxUsername.Text == a.KorisnickoIme)
                {
                    postojiUsername = true;
                }
            }
            int value;
            if (textBoxAdresa.Text=="" || textBoxIme.Text=="" || textBoxPrezime.Text=="" || textBoxMail.Text=="" || textBoxTelefon.Text=="" || textBoxUsername.Text=="" || passwordBoxPassPotvrda.Password=="" || passwordBoxPassword.Password == "")
            {
                errormessage.Text = "Sva polja su obavezna";
            }
            else if(textBoxTelefon.Text.Length<9 || textBoxTelefon.Text.Length > 12)
            {
                errormessage.Text = "Polje Telefon mora biti u rasponu od 9 do 12";
            }else if (textBoxUsername.Text.Length > 10)
            {
                errormessage.Text = "Polje Username ne smije biti duze od 10 karaktera";
            }
            else if (textBoxJMBG.Text.Length != 13)
            {
                errormessage.Text = "Polje JMBG mora imati 13 brojeva";
            }
            else if (passwordBoxPassword.Password != passwordBoxPassPotvrda.Password)
            {
                errormessage.Text = "Passwordi se ne slažu";
                passwordBoxPassPotvrda.Focus();
            }
            else if (!(int.TryParse(textBoxStaz.Text, out value))){
                errormessage.Text = "Polje staz mora biti broj";
            }
            else if (int.Parse(textBoxStaz.Text) > 40 || int.Parse(textBoxStaz.Text)<0)
            {
                errormessage.Text = "Staz ne moze biti veci od 40 ili manji od 0";
            }else if (postojiUsername)
            {
                errormessage.Text = "Admin sa datim korisnickim imenom vec postoji";
            }else if (!(IsValidEmail(textBoxMail.Text)))
            {
                errormessage.Text = "Email nije u validnom formatu";
            }
            else
            {
                AdministracijaInsertRequest request = new AdministracijaInsertRequest()
                {
                    Ime = textBoxIme.Text,
                    Prezime = textBoxPrezime.Text,
                    Adresa = textBoxAdresa.Text,
                    GradId = (int)cmbGradovi.SelectedValue,
                    KorisnickoIme = textBoxUsername.Text,
                    Password = passwordBoxPassword.Password,
                    PasswordConfirmation = passwordBoxPassPotvrda.Password,
                    Telefon = textBoxTelefon.Text,
                    Mail = textBoxMail.Text,
                    Uloga = "Administrator",
                    Staz = int.Parse(textBoxStaz.Text),
                    DatumRodjenja= DateTime.Parse(dtmRodjenja.ToString()),
                    DatumZaposlenja= DateTime.Parse(dtmZaposlenja.ToString()),
                    JMBG=textBoxJMBG.Text,
                   // DatumRodjenja = DateTime.ParseExact(textBoxDatumRodj.Text, "dd/MM/yyyy", null),
                   // DatumZaposlenja = DateTime.ParseExact(textBoxDatumZaposlenja.Text, "dd/MM/yyyy", null),
                    Slika = _imageBytes,
                    Spol = cmbSpol.SelectedValue.ToString(),
                };
                await _service.Insert<Model.Administracija>(request);
                Application.Current.MainWindow = new MainWindow();
                Application.Current.MainWindow.Show();
                Close();
            }
        }
        private void btnNazad_click(object sender, RoutedEventArgs e)
        {
           
            Application.Current.MainWindow = new AdministracijaPrikazWindow();
            Application.Current.MainWindow.Show();
            Close();
        }

        public bool IsValidEmail(string source)
        {
            return new EmailAddressAttribute().IsValid(source);
        }
        private async void LoadGradovi()
        {
            var listaGradovi = await _serviceGrad.Get<IEnumerable<Model.Grad>>(null);
            cmbGradovi.ItemsSource = listaGradovi;
            cmbSpol.Items.Add("M");
            cmbSpol.Items.Add("Ž");
        }
        //private void BtnLoadFromFile_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        Uri fileUri = new Uri(openFileDialog.FileName);
        //        imgDynamic.Source = new BitmapImage(fileUri);
        //    }
        //}
        //public byte[] imageToByteArray(System.Drawing.Image imageIn)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        //    return ms.ToArray();
        //}

        //novi kod
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
