using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetStarGate
{
    public partial class Membre : UserControl
    {
        public Membre()
        {
            InitializeComponent();
        }
        public Membre(string nom, string metier, string nomImage)
        {
            InitializeComponent();
            this.lblMetier.Text = metier;
            this.lblNom.Text = nom;

            if (nomImage != string.Empty)
            {
                pictureBox1.Image = Image.FromFile(nomImage);
            }

            if (metier == "militaire")
            {
                this.lblBadge.Text = "🎖️​";
            }
        }
    }
}
