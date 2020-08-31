using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManager3.WinUI
{
    public partial class frmLogin : Form
    {
        APIService _service = new APIService("Administracija");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                APIService.Username = txtUsername.Text;
                APIService.Password = txtPassword.Text;
                await _service.Get<dynamic>(null);

                frmIndex frm = new frmIndex();
                frm.Show();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Autentikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
