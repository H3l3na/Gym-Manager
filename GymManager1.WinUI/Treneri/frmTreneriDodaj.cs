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
using System.Xml.Linq;

namespace GymManager3.WinUI.Treneri
{
    public partial class frmTreneriDodaj : Form
    {
        private readonly APIService _apiService = new APIService("Treneri");
        private readonly APIService _apiServiceGrad = new APIService("Grad");
        private readonly APIService _serviceUloge = new APIService("Uloga");
        public frmTreneriDodaj()
        {
            InitializeComponent();
        }

        private async void frmTreneriDodaj_Load(object sender, EventArgs e)
        {
            List<KeyValuePair<int, string>> data = new List<KeyValuePair<int, string>>();
            IEnumerable<Model.Grad> gradList = await _apiServiceGrad.Get<IEnumerable<Model.Grad>>();
            foreach( var x in gradList)
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
            foreach (var x in ulogeList)
            {
                dataUloge.Add(new KeyValuePair<int, string>(x.UlogaID, x.Naziv));
            }
            cboUloge.DataSource = null;
            cboUloge.Items.Clear();
            //cboUloge.DataSource = new BindingSource(dataUloge, null);
            //cboUloge.DisplayMember = "Value";
            //cboUloge.ValueMember = "Key";

            //cboUloge.DataSource = null;
            //cboUloge.Items.Clear();
            cboUloge.Items.Add("Administrator");
            cboUloge.Items.Add("Polaznik");
            cboUloge.Items.Add("Trener");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtIme_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var request = new TreneriInsertRequest()
               {
                   Ime=txtIme.Text,
                   Prezime=txtPrezime.Text,
                   Adresa=txtAdresa.Text,
                   Telefon=txtTelefon.Text,
                   Jmbg=txtJMBG.Text,
                   Mail=txtEmail.Text,
                   Opis=txtOpis.Text,
                   GradId=(int)cboGrad.SelectedValue,
                   DatumZaposlenja=DateTime.Parse(txtDatum.Text),
                   Uloga=cboUloge.SelectedItem.ToString(),
                   KorisnickoIme=txtUsername.Text,
                   Password=txtPassword.Text, 
                   PasswordConfirmation=txtPassConfirmation.Text
                   //Spol=bool.Parse(txtSpol.Text)
               };
                await _apiService.Insert<Model.Trener>(request);
            }
            MessageBox.Show("Unos uspješan");
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider1.SetError(txtIme, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider1.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrezime.Text))
            {
                errorProvider1.SetError(txtPrezime, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider1.SetError(txtPrezime, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTelefon.Text))
            {
                errorProvider1.SetError(txtTelefon, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider1.SetError(txtTelefon, null);
            }
        }

        private void txtAdresa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdresa.Text))
            {
                errorProvider1.SetError(txtAdresa, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider1.SetError(txtAdresa, null);
            }
        }
    }
}
