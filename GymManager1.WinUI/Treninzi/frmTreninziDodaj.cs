using GymManager3.Model.Requests;
using GymManager3.WinUI.Properties;
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

namespace GymManager3.WinUI.Treninzi
{
    public partial class frmTreninziDodaj : Form
    {
        private readonly APIService _apiService = new APIService("Treninzi");
        private readonly APIService _apiServiceTrener = new APIService("Treneri");
        private readonly APIService _apiServiceVrstaTreninga = new APIService("VrstaTreninga");
        public frmTreninziDodaj()
        {
            InitializeComponent();
        }

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var request = new TreninziInsertRequest
                {
                    Naziv = txtNaziv.Text,
                    Cijena = double.Parse(txtCijena.Text),
                    Opis = txtOpis.Text,
                    Preduvjeti = txtPreduvjeti.Text,
                    Tezina = txtTezina.Text,
                    TrenerId=(int)cboTrener.SelectedValue,
                    VrstaTreningaId=(int)cboVrstaTreninga.SelectedValue
                };
                await _apiService.Insert<Model.Trening>(request);
            }
            MessageBox.Show("Unos uspješan");
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNaziv, null);
            }
        }

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCijena.Text))
            {
                errorProvider1.SetError(txtCijena, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }else
            {
                errorProvider1.SetError(txtCijena, null);
            }
        }

        private async void frmTreninziDodaj_Load(object sender, EventArgs e)
        {
            List<KeyValuePair<int, string>> data = new List<KeyValuePair<int, string>>();
            IEnumerable<Model.Trener> trenerList = await _apiServiceTrener.Get<IEnumerable<Model.Trener>>();
            foreach(var x in trenerList)
            {
                data.Add(new KeyValuePair<int, string>(x.TrenerId, x.Ime + " " + x.Prezime));
            }
            cboTrener.DataSource = null;
            cboTrener.Items.Clear();
            cboTrener.DataSource = new BindingSource(data, null);
            cboTrener.DisplayMember = "Value";
            cboTrener.ValueMember = "Key";

            List<KeyValuePair<int, string>> dataVrstaTreninga = new List<KeyValuePair<int, string>>();
            IEnumerable<Model.VrstaTreninga> vrstaTreningaList = await _apiServiceVrstaTreninga.Get<IEnumerable<Model.VrstaTreninga>>();
            foreach(var x in vrstaTreningaList)
            {
                dataVrstaTreninga.Add(new KeyValuePair<int, string>(x.VrstaTreningaId, x.Naziv));
            }
            cboVrstaTreninga.DataSource = null;
            cboVrstaTreninga.Items.Clear();
            cboVrstaTreninga.DataSource = new BindingSource(dataVrstaTreninga, null);
            cboVrstaTreninga.DisplayMember = "Value";
            cboVrstaTreninga.ValueMember = "Key";
        }
    }
}
