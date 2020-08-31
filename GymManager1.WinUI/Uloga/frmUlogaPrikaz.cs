using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManager3.WinUI.Uloga
{
    public partial class frmUlogaPrikaz : Form
    {
        private readonly APIService _service= new APIService("Uloga");
        public frmUlogaPrikaz()
        {
            InitializeComponent();
        }

        private async void frmUlogaPrikaz_Load(object sender, EventArgs e)
        {
            var result = await _service.Get<List<GymManager3.Model.Uloge>>();
            dgvUloga.DataSource = result;
        }
    }
}
