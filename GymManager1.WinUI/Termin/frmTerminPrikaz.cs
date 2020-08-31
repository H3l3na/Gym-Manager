using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManager3.WinUI.Termin
{
    public partial class frmTerminPrikaz : Form
    {
        private readonly APIService _service = new APIService("Termin");
        public frmTerminPrikaz()
        {
            InitializeComponent();
        }

        private async void TerminPrikaz_Load(object sender, EventArgs e)
        {
            var result = await _service.Get<List<Model.Termin>>();
            dgvTermini.DataSource = result;
        }
    }
}
