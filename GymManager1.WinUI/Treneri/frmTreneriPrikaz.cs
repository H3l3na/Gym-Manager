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

namespace GymManager3.WinUI.Treneri
{
    public partial class frmTreneriPrikaz : Form
    {
        private readonly APIService _apiService = new APIService("Treneri");
        public frmTreneriPrikaz()
        {
            InitializeComponent();
        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            var search = new TreneriSearchRequest()
            {
                Ime = txtPretraga.Text,
            };
            var result = await _apiService.Get<List<Model.Trener>>(search);
            dgvTreneri.DataSource = result;
        }

        private void dgvTreneri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmTreneriPrikaz_Load(object sender, EventArgs e)
        {

        }
        

        private void dgvTreneri_DoubleClick_1(object sender, EventArgs e)
        {
            var id = dgvTreneri.SelectedRows[0].Cells[1].Value;
            frmTrenerDetalji frm = new frmTrenerDetalji(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
