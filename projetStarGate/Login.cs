using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetStarGate
{
    public partial class Authentification : Form
    {
        public Authentification()
        {
            InitializeComponent();

            try
            {
                //Récupération du mot de passe en fonction du login
                string sql = $"SELECT mdp FROM Admin WHERE login = '{txtLogin.Text}'";
                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                object resultat = cmd.ExecuteScalar();
                //Test si la requête a renvoyé un résultat non null
                if (resultat != DBNull.Value && resultat != null)
                {
                    string mdpStocke = resultat.ToString();
                    //Vérification du mot de passe
                    bool valide = BCrypt.Net.BCrypt.Verify(txtMdp.Text, mdpStocke);
                    //Résultat de l'authentification
                    if (valide)
                    {
                        MessageBox.Show("Accès autorisé", "Authentification");
                    }
                    else
                    {
                        MessageBox.Show("Accès refusé", "Authentification");
                    }
                }
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            txtLogin.Text = "";
            txtMdp.Text = "";
        }
    }
}
