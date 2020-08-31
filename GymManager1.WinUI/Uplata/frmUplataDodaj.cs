using Flurl.Util;
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
    public partial class frmUplataDodaj : Form
    {
        private readonly APIService _apiService = new APIService("Polaznik");
        private readonly APIService _apiServiceAdmin = new APIService("Administracija");
        private readonly APIService _apiServiceSub = new APIService("VrstaSubskripcije");
        private readonly APIService _apiServiceUplata = new APIService("Uplata");
        public frmUplataDodaj()
        {
            InitializeComponent();
        }

        private async void frmUplataDodaj_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gymManager1DataSet1.Polaznik' table. You can move, or remove it, as needed.
            this.polaznikTableAdapter1.Fill(this.gymManager1DataSet1.Polaznik);
            // TODO: This line of code loads data into the 'gymManager1DataSet.Polaznik' table. You can move, or remove it, as needed.
            this.polaznikTableAdapter.Fill(this.gymManager1DataSet.Polaznik);
            List<KeyValuePair<int, string>> data = new List<KeyValuePair<int, string>>();
            IEnumerable<Model.Polaznik> polazniciList = await _apiService.Get<IEnumerable<Model.Polaznik>>();
            foreach (var x in polazniciList)
            {
                data.Add(new KeyValuePair<int, string>(x.PolaznikId, x.Ime + " " + x.Prezime));
            }
            // Clear the combobox
            cboPolaznici.DataSource = null;
            cboPolaznici.Items.Clear();
            // Bind the combobox
            cboPolaznici.DataSource = new BindingSource(data, null);
            cboPolaznici.DisplayMember = "Value";
            cboPolaznici.ValueMember = "Key";

            //Lista administratora
            List<KeyValuePair<int, string>> adminData = new List<KeyValuePair<int, string>>();
            IEnumerable<Model.Administracija> adminList = await _apiServiceAdmin.Get<IEnumerable<Model.Administracija>>();
            foreach(var x in adminList)
            {
                adminData.Add(new KeyValuePair<int, string>(x.AdministracijaID, x.Ime + " " + x.Prezime));
            }
            cboAdmin.DataSource = null;
            cboAdmin.Items.Clear();
            cboAdmin.DataSource = new BindingSource(adminData, null);
            cboAdmin.DisplayMember = "Value";
            cboAdmin.ValueMember = "Key";

            //Lista vrsta subskripcija
            List<KeyValuePair<int, string>> vrstaSubData = new List<KeyValuePair<int, string>>();
            IEnumerable<Model.VrstaSubskripcije> vrstaSubList = await _apiServiceSub.Get<IEnumerable<Model.VrstaSubskripcije>>();
            foreach (var x in vrstaSubList)
            {
                vrstaSubData.Add(new KeyValuePair<int, string>(x.VrstaSubskripcijeId, x.Vrsta));
            }
            cboSub.DataSource = null;
            cboSub.Items.Clear();
            cboSub.DataSource = new BindingSource(vrstaSubData, null);
            cboSub.DisplayMember = "Value";
            cboSub.ValueMember = "Key";
        }

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var request = new UplataInsertRequest
                {
                    DatumUplate = DateTime.Parse(txtDatum.Text),
                    Svrha = txtSvrha.Text,
                    Iznos=double.Parse(txtIznos.Text),
                    AdministracijaId=(int)cboAdmin.SelectedValue,
                    PolaznikId=(int)cboPolaznici.SelectedValue,
                    SubskripcijaId=(int)cboSub.SelectedValue
                };
                await _apiServiceUplata.Insert<Model.Uplata>(request);
            }
            MessageBox.Show("Unos uspješan");
        }

        private void txtIznos_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIznos.Text))
            {
                errorProvider1.SetError(txtIznos, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider1.SetError(txtIznos, null);
            }
        }

        private void txtSvrha_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSvrha.Text))
            {
                errorProvider1.SetError(txtSvrha, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider1.SetError(txtSvrha, null);
            }
        }

        private void txtDatum_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDatum.Text))
            {
                errorProvider1.SetError(txtDatum, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider1.SetError(txtDatum, null);
            }
        }

        private void cboAdmin_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cboAdmin.Text))
            {
                errorProvider1.SetError(cboAdmin, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider1.SetError(cboAdmin, null);
            }
        }

        private void cboPolaznici_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cboPolaznici.Text))
            {
                errorProvider1.SetError(cboPolaznici, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider1.SetError(cboPolaznici, null);
            }
        }

        private void cboSub_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cboSub.Text))
            {
                errorProvider1.SetError(cboSub, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider1.SetError(cboSub, null);
            }
        }
    }
}
