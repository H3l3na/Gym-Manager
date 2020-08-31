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
    public partial class frmUplataDetalji : Form
    {
        private readonly APIService _apiService = new APIService("Uplata");
        private readonly APIService apiService = new APIService("Polaznik");
        private readonly APIService apiService1 = new APIService("Administracija");
        private int? _id = null;
        public frmUplataDetalji(int? _uplataId=null)
        {
            InitializeComponent();
            _id = _uplataId;
        }

        private async void frmUplataDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var uplata = await _apiService.GetById<Model.Uplata>(_id);
                txtDatum.Text = uplata.DatumUplate.ToString();
                txtIznos.Text = uplata.Iznos.ToString();
                var polaznik = await apiService.GetById<Model.Polaznik>(uplata.PolaznikId);
                txtPolaznik.Text = polaznik.Ime + " " + polaznik.Prezime;
                txtSvrha.Text = uplata.Svrha;
                var admin = await apiService1.GetById<Model.Administracija>(uplata.AdministracijaId);
                txtAdmin.Text = admin.Ime + " " + admin.Prezime;
            }
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
