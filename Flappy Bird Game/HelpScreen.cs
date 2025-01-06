using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Game
{
    public partial class HelpScreen : Form
    {
        private Form1 mainForm;
        public HelpScreen(Form1 form)
        {
            InitializeComponent();
            mainForm = form;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            mainForm.Show();
        }
    }
}
