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
    public partial class frmTreninziDetalji : Form
    {
        private readonly APIService _apiService = new APIService("Treninzi");
        private int? _id= null;
        public frmTreninziDetalji(int? _treningId=null)
        {
            InitializeComponent();
            _id = _treningId;
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {

        }

        private async void frmTreninziDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var trening = await _apiService.GetById<Model.Trening>(_id);
                txtCijena.Text = trening.Cijena.ToString();
                txtNaziv.Text = trening.Naziv;
                txtOpis.Text = trening.Opis;
                txtPreduvjeti.Text = trening.Preduvjeti;
                txtTezina.Text = trening.Tezina;
            }
        }
    }
}
