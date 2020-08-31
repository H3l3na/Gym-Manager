using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using GymManager3.Model;
using GymManager3.Model.Requests;
using GymManager3.WinUI;
using GymManager3.WinUI.Polaznik;

namespace GymManager1.WinUI.Polaznik
{
    public partial class frmPolaznikPrikaz : Form
    {
        private readonly APIService _apiService = new APIService("Polaznik");
        public frmPolaznikPrikaz()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new PolazniciSearchRequest() {
                Ime = txtPretraga.Text
            };
            //var result = "https://localhost:44314/api/Polaznik".GetJsonAsync<List<GymManager3.Model.Polaznik>>().Result;
            var result = await _apiService.Get<List<GymManager3.Model.Polaznik>>(search);
            dgvPolaznik.DataSource = result;
        }

        private void dgvPolaznik_DoubleClick(object sender, EventArgs e)
        {
            var id = dgvPolaznik.SelectedRows[0].Cells[0].Value;
            frmPolaznikDetalji frm = new frmPolaznikDetalji(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
