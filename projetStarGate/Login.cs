using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetStarGate
{
    public partial class Login : Form
    {
        private Label lblLoading;
        private bool _loading;

        public Login()
        {
            InitializeComponent();
            CreateLoadingUI();
        }

        private void CreateLoadingUI()
        {
            lblLoading = new Label
            {
                Text = "Connexion",
                Font = new Font("Rubik", 32, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Visible = false
            };

            lblLoading.Location = new Point(176, 197);
            this.Controls.Add(lblLoading);
            lblLoading.BringToFront();
        }

        // Animation "Connexion..."
        private async Task ShowLoading()
        {
            int dots = 0;
            while (_loading)
            {
                dots = (dots + 1) % 4;
                lblLoading.Text = "Connexion" + new string('.', dots);
                await Task.Delay(300);
            }
        }

        private async void btnValider_Click(object sender, EventArgs e)
        {
            if (ValiderLogin())
            {
                lblLoading.Visible = true;
                _loading = true;

                // Lancer l'animation sans bloquer l'UI
                var loadingTask = ShowLoading();

                // Simulation d'un temps de chargement (ou remplace par tes opérations)
                await Task.Delay(1200);

                // Arrêter l'animation
                _loading = false;
                lblLoading.Visible = false;
                await loadingTask; // attendre fin boucle proprement

                new Creation_Mission().Show();
                this.Hide();
            }
            else
            {
                await Vibrer();
            }
        }

        private bool ValiderLogin()
        {
            try
            {
                if (Connexion.Connec.State != ConnectionState.Open)
                    Connexion.Connec.Open();

                string sql = "SELECT mdp FROM Admin WHERE login = @login";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec))
                {
                    cmd.Parameters.AddWithValue("@login", txtLogin.Text.Trim());
                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                        return false;

                    string mdpStocke = result.ToString();
                    return BCrypt.Net.BCrypt.Verify(txtMdp.Text, mdpStocke);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la connexion : " + ex.Message);
                return false;
            }
        }

        private async Task Vibrer()
        {
            var originalLocation = this.Location;
            int pixels = 10;
            int count = 6;

            for (int i = 0; i < count; i++)
            {
                this.Location = new Point(originalLocation.X + pixels, originalLocation.Y);
                await Task.Delay(30);
                this.Location = new Point(originalLocation.X - pixels, originalLocation.Y);
                await Task.Delay(30);
            }

            this.Location = originalLocation;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}