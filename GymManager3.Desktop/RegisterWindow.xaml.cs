using GymManager3.Model;
using GymManager3.Model.Requests;
using System;
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

namespace GymManager3.Desktop
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        APIService _service = new APIService("Administracija");
        public RegisterWindow()
        {
            InitializeComponent();
        }
        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            AdministracijaInsertRequest request = new AdministracijaInsertRequest();
            request.Ime = textBoxFirstName.Text;
            request.Prezime = textBoxLastName.Text;
            request.Mail = textBoxEmail.Text;
            request.Password = passwordBox1.Password;
            request.PasswordConfirmation = passwordBoxConfirm.Password;
            request.GradId = 1;
            request.KorisnickoIme = "xxx123";
            request.Uloga = "Administrator";
            request.Adresa = "Sarajevo";
            request.Telefon = "062356212";
            if (passwordBox1.Password != passwordBoxConfirm.Password)
            {
                errormessage.Text = "Confirm password must be same as password.";
                passwordBoxConfirm.Focus();
            }else
            {
                try
                {
                    await _service.Insert<Model.Administracija>(request);
                    Application.Current.MainWindow = new MainWindow();
                    Application.Current.MainWindow.Show();

                }catch(Exception exception)
                {
                    errormessage.Text = "Invalid request";
                }
            }
        }
    }
}
