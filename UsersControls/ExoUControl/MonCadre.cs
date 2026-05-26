using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExoUControl
{
    public partial class MonCadre: UserControl
    {
        public MonCadre()
        {
            InitializeComponent();
        }
        public MonCadre(string nomEtu, string commentaire, string nomImage)
        {
            InitializeComponent();
            this.lblComment.Text = commentaire;
            this.lblNom.Text = nomEtu;

            if (nomImage != string.Empty)
            {
                pictureBox1.Image = Image.FromFile(nomImage);
            }
        }

        private void btnInfos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fiche de "+lblNom.Text, "Infos");
        }
    }
}
