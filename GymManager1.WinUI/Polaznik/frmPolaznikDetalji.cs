using GymManager3.Model;
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

namespace GymManager3.WinUI.Polaznik
{
    public partial class frmPolaznikDetalji : Form
    {
        private readonly APIService _service = new APIService("Polaznik");
        private readonly APIService _serviceGrad = new APIService("Grad");
        private readonly APIService _serviceUloge = new APIService("Uloga");
        private int? _id = null;
        public frmPolaznikDetalji(int? polaznikId=null)
        {
            InitializeComponent();
            _id = polaznikId;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
           
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var request = new PolazniciInsertRequest()
                {
                    Mail = txtEmail.Text,
                    Telefon = txtPhone.Text,
                    Ime = txtName.Text,
                    Prezime = txtSurname.Text,
                    Password = txtPswrd.Text,
                    PasswordPotvrda = txtPswrdConfirmation.Text,
                    GradId=(int)cboGrad.SelectedValue,
                    Uloga=cboUloge.SelectedItem.ToString(),
                    KorisnickoIme=txtUsername.Text
                };
                if (_id.HasValue)
                {
                    await _service.Update<Model.Polaznik>(_id, request);
                }
                else
                {
                    await _service.Insert<Model.Polaznik>(request);
                }
            }
            MessageBox.Show("Unos uspješan");
        }

        private async void frmPolaznikDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var polaznik = await _service.GetById<Model.Polaznik>(_id);
                txtName.Text = polaznik.Ime;
                txtSurname.Text = polaznik.Prezime;
                txtEmail.Text = polaznik.Mail;
                txtPhone.Text = polaznik.Telefon;
                txtUsername.Text = polaznik.KorisnickoIme;
                cboUloge.SelectedItem = polaznik.Uloga; //questionable code
            }
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

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider.SetError(txtName, null);
            }
        }

        private void txtSurname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSurname.Text))
            {
                errorProvider.SetError(txtSurname, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider.SetError(txtSurname, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                errorProvider.SetError(txtPhone, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider.SetError(txtPhone, null);
            }
        }
    }
}
