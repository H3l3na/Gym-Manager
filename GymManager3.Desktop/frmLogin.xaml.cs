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
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        APIService _service = new APIService("Administracija");
        public frmLogin()
        {
            InitializeComponent();
        }
        RegisterWindow register = new RegisterWindow();
        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                APIService.Username = textBoxUsername.Text;
                APIService.Password = passwordBox1.Password;
                await _service.Get<dynamic>(null);
                

                Application.Current.MainWindow = new MainWindow();
                Application.Current.MainWindow.Show();
                Close();
            }
            catch (Exception exception)
            {
                errormessage.Text = "Invalid input.";
            }
        }
        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            register.Show();
            Close();
        }
    }
}
