using GymManager3.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace GymManager3.Desktop.Polaznici
{
    /// <summary>
    /// Interaction logic for PolazniciDodajWindow.xaml
    /// </summary>
    public partial class PolazniciUpdateWindow : Window
    {
        APIService _service = new APIService("Polaznik");
        APIService _serviceGradovi = new APIService("Grad");
        private int? id = null;
        public PolazniciUpdateWindow(int? polaznikId = null)
        {
            InitializeComponent();
            id = polaznikId;
            /* txtUserName.Text = APIService.User.KorisnickoIme;
             txtFirstName.Text = APIService.User.Ime;
             txtLastName.Text = APIService.User.Prezime;
             txtEmail.Text = APIService.User.Email;
             txtPhoneNumber.Text = APIService.User.Telefon;*/
            LoadData(polaznikId);
        }
        
        private async void btnSacuvaj_click(object sender, RoutedEventArgs e)
        {
            List<Model.Polaznik> listaPolaznika = await _service.Get<List<Model.Polaznik>>();
            bool postojiUsername = false;
            foreach (Model.Polaznik p in listaPolaznika)
            {
                if (textBoxUsername.Text != "" && textBoxUsername.Text == p.KorisnickoIme)
                {
                    postojiUsername = true;
                }
            }
            if (textBoxUsername.Text=="" || textBoxIme.Text == "" || textBoxJMBG.Text == "" || textBoxAdresa.Text == "" || textBoxPrezime.Text == "" || textBoxTelefon.Text == "" || textBoxMail.Text == "")
            {
                errormessage.Text = "Sva polja su obavezna";
            }
             else if (textBoxTelefon.Text.Length > 12 || textBoxTelefon.Text.Length < 9) {
                    errormessage.Text = "Polje Telefon mora biti u rasponu od 9 do 12";
              }
            else if (textBoxUsername.Text.Length > 10)
            {
                errormessage.Text = "Polje Username ne smije biti duze od 10 karaktera";
            }
            else if (textBoxJMBG.Text.Length != 13)
            {
                errormessage.Text = "Polje JMBG mora imati 13 brojeva";
            }else if (postojiUsername)
            {
                errormessage.Text = "Polaznik sa datim korisnickim imenom vec postoji";
            }else if (!(IsValidEmail(textBoxMail.Text)))
            {
                errormessage.Text = "Email nije u validnom formatu";
            }
            else
            {
                PolazniciUpdateRequest request = new PolazniciUpdateRequest()
                {
                    Ime = textBoxIme.Text,
                    Prezime = textBoxPrezime.Text,
                    Mail = textBoxMail.Text,
                    Telefon = textBoxTelefon.Text,
                    JMBG = textBoxJMBG.Text,
                    Adresa = textBoxAdresa.Text,
                    KorisnickoIme = textBoxUsername.Text
                };
                await _service.Update<Model.Polaznik>(id, request);
                Application.Current.MainWindow = new MainWindow();
                Application.Current.MainWindow.Show();
                Close();
            }

            /*
            if (textBoxAdresa.Text == "" || textBoxIme.Text == "" || textBoxPrezime.Text == "" || textBoxMail.Text == "" || textBoxTelefon.Text == "" || textBoxUsername.Text == "" || passwordBoxPassPotvrda.Password == "" || passwordBoxPassword.Password == "")
            {
                errormessage.Text = "Molimo popunite sva polja";
            }
            else if (textBoxTelefon.Text.Length > 12 || textBoxTelefon.Text.Length < 9)
            {
                errormessage.Text = "Polje Telefon mora biti u rasponu od 9 do 12";
            }
            else if (textBoxUsername.Text.Length > 10)
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
            else
            {
                PolazniciInsertRequest request = new PolazniciInsertRequest()
                {
                    Ime = textBoxIme.Text,
                    Prezime = textBoxPrezime.Text,
                    GradId = (int)cmbGradovi.SelectedValue,
                    KorisnickoIme = textBoxUsername.Text,
                    Password = passwordBoxPassword.Password,
                    PasswordPotvrda = passwordBoxPassPotvrda.Password,
                    Telefon = textBoxTelefon.Text,
                    Mail = textBoxMail.Text,
                    Uloga = "Polaznik",
                    DatumRodjenja = DateTime.Parse(dtmRodjenja.ToString()),
                    JMBG = textBoxJMBG.Text
                    //DatumRodjenja= DateTime.ParseExact(textBoxDatumRodjenja.Text, "dd/MM/yyyy", null),
                };
                await _service.Insert<Model.Polaznik>(request);
                Application.Current.MainWindow = new MainWindow();
                Application.Current.MainWindow.Show();
                Close();
            }*/
        }
        private void btnNazad_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new PolazniciPrikazWindow();
            Application.Current.MainWindow.Show();
            Close();
        }

        public bool IsValidEmail(string source)
        {
            return new EmailAddressAttribute().IsValid(source);
        }

        private async void btnDelete_click(object sender, RoutedEventArgs e)
        {
            Model.Polaznik polaznik = await _service.Delete(id);
            Application.Current.MainWindow = new PolazniciPrikazWindow();
            Application.Current.MainWindow.Show();
            Close();
        }

        private async void LoadData(int? polaznikId=null)
        {
            if (polaznikId != null)
            {
                Model.Polaznik polaznik = await _service.GetById<Model.Polaznik>(polaznikId);
                if (polaznik != null)
                {
                    textBoxIme.Text = polaznik.Ime;
                    textBoxPrezime.Text = polaznik.Prezime;
                    textBoxUsername.Text = polaznik.KorisnickoIme;
                    textBoxTelefon.Text = polaznik.Telefon;
                    textBoxMail.Text = polaznik.Mail;
                    textBoxJMBG.Text = polaznik.JMBG;
                    textBoxAdresa.Text = polaznik.Adresa;
                }
            }
        }
    }
}
