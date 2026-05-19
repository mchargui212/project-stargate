using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace projetStarGate
{
    public partial class frmAccueil : Form
    {
        public frmAccueil()
        {
            InitializeComponent();
        }

        private void frmAccueil_Load(object sender, EventArgs e)
        {
            try{
                MessageBox.Show(Connexion.Connec.State.ToString());
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login fe = new Login();
            DialogResult fr = fe.ShowDialog();
            if (fr == DialogResult.Cancel)
            {
                MessageBox.Show("Opération annluée");
            }
        }
    }
}
