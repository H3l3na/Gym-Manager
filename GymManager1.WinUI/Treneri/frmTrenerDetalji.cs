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
    public partial class frmTrenerDetalji : Form
    {
        private readonly APIService _apiService = new APIService("Treneri");
        private int? _id = null;
        public frmTrenerDetalji(int? trenerId=null)
        {
            InitializeComponent();
            _id = trenerId;
        }

        private async void frmTrenerDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var trener = await _apiService.GetById<Model.Trener>(_id);
                txtPrezime.Text = trener.Prezime;
                txtIme.Text = trener.Ime;
                txtEmail.Text = trener.Mail;
                txtAdresa.Text = trener.Adresa;
                txtTelefon.Text = trener.Telefon;
            }
        }
    }
}
