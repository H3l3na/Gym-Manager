using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManager3.WinUI.RezervacijaTreninga
{
    public partial class frmRezervacijaTreninga : Form
    {
        private readonly APIService _service = new APIService("RezervacijaTreninga");
        public frmRezervacijaTreninga()
        {
            InitializeComponent();
        }

        private async void frmRezervacijaTreninga_Load(object sender, EventArgs e)
        {
            var result = await _service.Get<List<Model.RezervacijaTreninga>>();
            dgvRezervacijaTermina.DataSource = result;
        }
    }
}
