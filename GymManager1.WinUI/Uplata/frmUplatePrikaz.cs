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

namespace GymManager3.WinUI.Uplata
{
    public partial class frmUplatePrikaz : Form
    {
        private readonly APIService _apiService = new APIService("Uplata");
        public frmUplatePrikaz()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new UplataSearchRequest()
            {
                Svrha = txtPretraga.Text
            };
            var result = await _apiService.Get<List<Model.Uplata>>(search);
            dgvUplate.DataSource = result;
        }

        private void dgvUplate_DoubleClick(object sender, EventArgs e)
        {
            var id = dgvUplate.SelectedRows[0].Cells[1].Value;
            frmUplataDetalji frm = new frmUplataDetalji(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
