using GymManager3.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManager3.WinUI.Administracija
{
    public partial class frmAdministracijaPrikaz : Form
    {
        private readonly APIService _service = new APIService("Administracija");
        public frmAdministracijaPrikaz()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            var search = new AdministracijaSearchRequest()
            {
                Ime = txtAdmin.Text,
            };
            var result = await _service.Get<List<Model.Administracija>>(search);
            dgvAdmin.DataSource = result;

        }

        private void dgvAdmin_DoubleClick(object sender, EventArgs e)
        {
            var id = dgvAdmin.SelectedRows[0].Cells[1].Value;
            frmAdminDetalji frm = new frmAdminDetalji(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
