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
    public partial class frmAdminDetalji : Form
    {
        private readonly APIService _service = new APIService("Administracija");
        private int? _id = null;
        public frmAdminDetalji(int? adminId=null)
        {
            InitializeComponent();
            _id = adminId;
        }

        private async void frmAdminDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var admin = await _service.GetById<Model.Administracija>(_id);
                txtIme.Text = admin.Ime;
                txtPrezime.Text = admin.Prezime;
                txtTelefon.Text = admin.Telefon;
                txtMail.Text = admin.Mail;
                txtAdresa.Text = admin.Adresa;
            }
        }

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            var request = new AdministracijaInsertRequest()
            {
                Mail = txtMail.Text,
                Ime = txtIme.Text,
                Prezime=txtPrezime.Text,
                Adresa=txtAdresa.Text,
                Telefon=txtTelefon.Text,
                Uloga=txtUloga.Text
            };

            if (_id.HasValue)
            {
                await _service.Update<Model.Administracija>(_id, request);
            }else
            {
                await _service.Insert<Model.Administracija>(request);
            }
            MessageBox.Show("Unos uspješan");
        }
    }
}
