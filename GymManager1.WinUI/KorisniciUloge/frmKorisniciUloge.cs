using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManager3.WinUI.KorisniciUloge
{
    public partial class frmKorisniciUloge : Form
    {
        private readonly APIService _service = new APIService("KorisniciUloge");
        public frmKorisniciUloge()
        {
            InitializeComponent();
        }

        private async void frmKorisniciUloge_Load(object sender, EventArgs e)
        {
            var result = await _service.Get<List<Model.KorisniciUloge>>();
            dgvKorisniciUloge.DataSource = result;
        }
    }
}
