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

namespace GymManager3.WinUI.Treninzi
{
    public partial class frmTreninziPrikaz : Form
    {
        private readonly APIService _apiService = new APIService("Treninzi");
        public frmTreninziPrikaz()
        {
            InitializeComponent();
        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            var search = new TreninziSearchRequest()
            {
                Naziv = txtPretraga.Text
            };
            var result = await _apiService.Get<List<Model.Trening>>(search);
            dgvTreninzi.DataSource = result;
        }

        private void dgvTreninzi_DoubleClick(object sender, EventArgs e)
        {
            var id = dgvTreninzi.SelectedRows[0].Cells[1].Value;
            frmTreninziDetalji frm = new frmTreninziDetalji(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
