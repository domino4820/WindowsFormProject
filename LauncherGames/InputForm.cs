using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PayPal.Api;

namespace LauncherGames
{
    public partial class InputForm : Form
    {
        public string PayerId { get; private set; }
        public InputForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            PayerId = txtPayerId.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
