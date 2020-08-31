using GymManager3.Model.Requests;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public partial class frmAdminDodaj : Form
    {
        private readonly APIService _service = new APIService("Administracija");
        private readonly APIService _serviceGrad = new APIService("Grad");
        private readonly APIService _serviceUloge = new APIService("Uloga");
        private int? _id = null;
        public frmAdminDodaj(int? adminId=null)
        {
            InitializeComponent();
            _id = adminId;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
           if (this.ValidateChildren())
            {
                var request = new AdministracijaInsertRequest()
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Adresa = txtAdresa.Text,
                    Telefon = txtTelefon.Text,
                    Mail = txtMail.Text,
                    Uloga = cboUloge.SelectedItem.ToString(),
                    GradId=(int)cboGrad.SelectedValue,
                    KorisnickoIme=txtUsername.Text,
                    Password=txtPassword.Text, 
                    PasswordConfirmation=txtPassConfirmation.Text
                };
                if (_id.HasValue) {
                    await _service.Update<Model.Administracija>(_id, request);
                } else {
                    await _service.Insert<Model.Administracija>(request);
                }
            }
            
            MessageBox.Show("Unos uspjesan");
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider.SetError(txtIme, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider.SetError(txtPrezime, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider.SetError(txtPrezime, null);
            }
        }

        private void txtUloga_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUloga.Text))
            {
                errorProvider.SetError(txtUloga, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider.SetError(txtUloga, null);
            }
        }

        private void txtMail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMail.Text))
            {
                errorProvider.SetError(txtMail, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider.SetError(txtMail, null);
            }
        }

        private void txtTelefon_Validated(object sender, EventArgs e)
        {

        }

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                errorProvider.SetError(txtTelefon, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider.SetError(txtTelefon, null);
            }
        }

        private void txtAdresa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdresa.Text))
            {
                errorProvider.SetError(txtAdresa, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider.SetError(txtAdresa, null);
            }
        }

        private async void frmAdminDodaj_Load(object sender, EventArgs e)
        {
            List<KeyValuePair<int, string>> data = new List<KeyValuePair<int, string>>();
            IEnumerable<Model.Grad> gradList = await _serviceGrad.Get<IEnumerable<Model.Grad>>();
            foreach(var x in gradList)
            {
                data.Add(new KeyValuePair<int, string>(x.GradId, x.Naziv));
            }
            cboGrad.DataSource = null;
            cboGrad.Items.Clear();
            cboGrad.DataSource = new BindingSource(data, null);
            cboGrad.DisplayMember = "Value";
            cboGrad.ValueMember = "Key";

            IEnumerable<Model.Uloge> ulogeList = await _serviceUloge.Get<IEnumerable<Model.Uloge>>();
            List<KeyValuePair<int, string>> dataUloge = new List<KeyValuePair<int, string>>();
            foreach(var x in ulogeList)
            {
                dataUloge.Add(new KeyValuePair<int, string>(x.UlogaID, x.Naziv));
            }
            cboUloge.DataSource = null;
            cboUloge.Items.Clear();
            //cboUloge.DataSource = new BindingSource(dataUloge, null);
            //cboUloge.DisplayMember = "Value";
            //cboUloge.ValueMember = "Key";
            cboUloge.Items.Add("Administrator");
            cboUloge.Items.Add("Trener");
            cboUloge.Items.Add("Polaznik");
        }
    }
}
