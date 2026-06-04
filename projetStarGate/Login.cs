using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace projetStarGate
{
    public partial class Login : Form
    {
        private GroupBox groupBoxLoading;
        private Label lblLoading;
        private Timer timerLoading;
        private int dotCount = 0;
        private int maxDots = 3;

        public Login()
        {
            InitializeComponent();
            CreateLoadingUI();
        }

        private void CreateLoadingUI()
        {
            groupBoxLoading = new GroupBox();
            groupBoxLoading.Text = "";
            groupBoxLoading.Location = new System.Drawing.Point(215, 112);
            groupBoxLoading.Name = "groupBox1";
            groupBoxLoading.ForeColor = System.Drawing.SystemColors.Info;
            groupBoxLoading.Size = new System.Drawing.Size(210, 69);
            groupBoxLoading.Visible = false;

            lblLoading = new Label();
            lblLoading.Text = "Loading";
            lblLoading.AutoSize = true;
            lblLoading.Font = new Font("Rubik", 12, FontStyle.Bold);
            lblLoading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            lblLoading.Location = new Point(50, 40);

            groupBoxLoading.Controls.Add(lblLoading);
            this.Controls.Add(groupBoxLoading);

            timerLoading = new Timer();
            timerLoading.Interval = 500;
            timerLoading.Tick += TimerLoading_Tick;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            StartLoading();
        }

        private void StartLoading()
        {
            dotCount = 0;
            lblLoading.Text = "Loading";
            groupBoxLoading.Visible = true;
            groupBoxLoading.BringToFront();
            btnValider.Enabled = false;

            timerLoading.Start();
        }

        private void TimerLoading_Tick(object sender, EventArgs e)
        {
            dotCount++;
            if (dotCount > maxDots)
            {
                dotCount = 0;
            }

            lblLoading.Text = "Loading" + new string('.', dotCount);

            if (dotCount == 0)
            {
                StopLoading();
                ValiderLogin();
            }
        }

        private void StopLoading()
        {
            timerLoading.Stop();
            groupBoxLoading.Visible = false;
            btnValider.Enabled = true;
        }

        private void ValiderLogin()
        {
            try
            {
                string sql = $"SELECT mdp FROM Admin WHERE login = '{txtLogin.Text}'";
                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                object resultat = cmd.ExecuteScalar();

                if (resultat != DBNull.Value && resultat != null)
                {
                    string mdpStocke = resultat.ToString();
                    bool valide = BCrypt.Net.BCrypt.Verify(txtMdp.Text, mdpStocke);

                    if (valide)
                    {
                        MessageBox.Show("Accès autorisé", "Authentification");
                        Creation_Mission fe = new Creation_Mission();
                        fe.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Accès refusé", "Authentification");
                    }
                }
                else
                {
                    MessageBox.Show("Accès refusé : vérifier votre login", "Authentification");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}