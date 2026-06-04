using projetStarGate;
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
    public partial class Statistiques : Form
    {
        public Statistiques()
        {
            InitializeComponent();
        }

        public DataTable Req1(string matricule)
        {
            DataTable table = new DataTable();
            SQLiteConnection connection = Connexion.Connec;

            string requete = @"
                SELECT DISTINCT mb.nom, mb.prenom,
                CASE WHEN mil.matriculeMembre IS NOT NULL THEN 'Militaire' ELSE 'Civil' END AS Type
                FROM Membre mb
                JOIN Composer c1 ON mb.matricule = c1.matriculeMembre
                JOIN Composer c2 ON c1.nomPlanete = c2.nomPlanete AND c1.numeroMission = c2.numeroMission
                LEFT JOIN Militaire mil ON mb.matricule = mil.matriculeMembre
                WHERE c2.matriculeMembre = @matricule AND mb.matricule != @matricule";


            using (SQLiteCommand command = new SQLiteCommand(requete, connection))
            {
                command.Parameters.AddWithValue("@matricule", matricule);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    table.Load(reader);
                }
            }
            return table;
        }

        public DataTable Req2()
        {
            DataTable table = new DataTable();
            SQLiteConnection connection = Connexion.Connec;

            string requete = @"SELECT m.nomPlanete || '-' || m.numero AS NomMission, " +
                "d.dateD, d.motif, d.montant, m.budget AS BudgetInitial, m.budget - COALESCE(dep.TotalDepenses,0) AS BudgetActuel " +
                "FROM Mission m " + 
                "LEFT JOIN Depense d ON m.nomPlanete = d.nomPlanete AND m.numero = d.numeroMission " + 
                "LEFT JOIN ( " +
                "SELECT nomPlanete, numeroMission, SUM(montant) AS TotalDepenses " +
                "FROM Depense " +
                "GROUP BY nomPlanete, numeroMission ) " +
                "dep ON dep.nomPlanete = m.nomPlanete " +
                "AND dep.numeroMission = m.numero " +
                "WHERE ( " +
                "SELECT COUNT(*) " +
                "FROM Composer c " +
                "WHERE c.nomPlanete = m.nomPlanete " +
                "AND c.numeroMission = m.numero ) > 10;";

            using (SQLiteCommand command = new SQLiteCommand(requete, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    table.Load(reader);
                }
            }

            return table;
        }

        public DataTable Req3()
        {
            DataTable table = new DataTable();
            SQLiteConnection connection = Connexion.Connec;

            string requete = "SELECT p.nom, COUNT(*) AS NombreMissions " +
                "FROM Planete p " +
                "LEFT JOIN Mission m ON p.nom = m.nomPlanete " +
                "GROUP BY p.nom; ";

            using (SQLiteCommand command = new SQLiteCommand(requete, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    table.Load(reader);
                }
            }

            return table;
        }

        public DataTable Req4()
        {
            DataTable table = new DataTable();
            SQLiteConnection connection = Connexion.Connec;

            string requete = @"
                SELECT d.dateD || ' - ' || d.motif || ' - ' || d.montant || '€' AS 'Dépenses les plus importantes',
                       m.nomPlanete || '-' || m.numero AS NomMission,
                       chef.prenom, chef.nom
                FROM Depense d
                JOIN Mission m ON d.nomPlanete = m.nomPlanete AND d.numeroMission = m.numero
                JOIN Membre chef ON m.matriculeChef = chef.matricule
                WHERE d.montant = (
                    SELECT MAX(montant)
                    FROM Depense d2
                    WHERE d2.nomPlanete = d.nomPlanete AND d2.numeroMission = d.numeroMission
                )";

            using (SQLiteCommand command = new SQLiteCommand(requete, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    table.Load(reader);
                }
            }

            return table;
        }

        private void Stats_Load(object sender, EventArgs e)
        {
            StyleDGV(dgvReq1);
            StyleDGV(dgvReq2);
            StyleDGV(dgvReq3);
            StyleDGV(dgvReq4);
            StyleDGV(dgvReq5);

            try
            {
                dgvReq2.DataSource = Req2();
                dgvReq3.DataSource = Req3();
                dgvReq4.DataSource = Req4();

                string reqMembres = "SELECT matricule, nom || ' ' || prenom AS NomComplet FROM Membre ORDER BY nom";
                DataTable membres = new DataTable();
                using (SQLiteCommand cmd = new SQLiteCommand(reqMembres, Connexion.Connec))
                using (SQLiteDataReader r = cmd.ExecuteReader())
                    membres.Load(r);

                cboReq1.DisplayMember = "NomComplet";
                cboReq1.ValueMember = "matricule";
                cboReq1.DataSource = membres;

                string reqMissions = @"SELECT nomPlanete || '-' || numero AS NomMission, 
                                      nomPlanete, numero 
                               FROM Mission ORDER BY nomPlanete, numero";
                DataTable missions = new DataTable();
                using (SQLiteCommand cmd = new SQLiteCommand(reqMissions, Connexion.Connec))
                using (SQLiteDataReader r = cmd.ExecuteReader())
                    missions.Load(r);
                
                cboReq5.DisplayMember = "NomMission";
                cboReq5.ValueMember = "NomMission";
                cboReq5.DataSource = missions;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataTable Req5(string nomPlanete, int numeroMission)
        {
            DataTable table = new DataTable();
            SQLiteConnection connection = Connexion.Connec;

            string requete = "SELECT i.nomCode, e.nom AS EspeceOrigine, SUM(co.sommeVersee) AS TotalRecu " +
                "FROM Contact co " +
                "JOIN Informateur i ON co.nomCodeInformateur = i.nomCode " +
                "JOIN Espece e ON i.idEspeceEnnemi = e.id " +
                "WHERE co.nomPlanete = @nomPlanete " +
                "AND co.numeroMission = @numeroMission " +
                "GROUP BY i.nomCode, e.nom " +
                "HAVING SUM(co.sommeVersee) = ( " +
                "SELECT MIN(Total) " +
                "FROM ( " +
                "SELECT SUM(sommeVersee) AS Total " +
                "FROM Contact " +
                "WHERE nomPlanete = @nomPlanete " +
                "AND numeroMission = @numeroMission " +
                "GROUP BY nomCodeInformateur)); ";

            using (SQLiteCommand command = new SQLiteCommand(requete, connection))
            {
                command.Parameters.AddWithValue("@nomPlanete", nomPlanete);
                command.Parameters.AddWithValue("@numeroMission", numeroMission);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    table.Load(reader);
                }
            }
            return table;
        }

        private void cboReq1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvReq1.Visible = false;
            if (cboReq1.SelectedValue == null || cboReq1.SelectedValue is DataRowView)
                return;

            DataTable dt = Req1(cboReq1.SelectedValue.ToString());
            dgvReq1.DataSource = dt;

            Control ancienLabel = Page1.Controls["lblAucuneInfo"];
            if (ancienLabel != null)
                Page1.Controls.Remove(ancienLabel);

            if (dt.Rows.Count == 0)
            {
                Label lbl = new Label();
                lbl.Name = "lblAucuneInfo";
                lbl.Text = "Aucune information disponible";
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Rubik", 12, FontStyle.Bold);
                lbl.AutoSize = true;
                lbl.Location = new Point(
                    (Page1.Width - lbl.PreferredWidth) / 2,
                    (Page1.Height - lbl.PreferredHeight) / 2);

                Page1.Controls.Add(lbl);
            }
            else
            {
                dgvReq1.Visible = true;
            }
        }

        private void cboReq5_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvReq5.Visible = false;
            if (!(cboReq5.SelectedItem is DataRowView row))
                return;

            string nomPlanete = row["nomPlanete"].ToString();
            int numeroMission = Convert.ToInt32(row["numero"]);

            DataTable dt = Req5(nomPlanete, numeroMission);
            dgvReq5.DataSource = dt;

            Control ancienLabel = Page5.Controls["lblAucuneInfo"];
            if (ancienLabel != null)
                Page5.Controls.Remove(ancienLabel);

            if (dt.Rows.Count == 0)
            {
                
                Label lbl = new Label();
                lbl.Name = "lblAucuneInfo";
                lbl.Text = "Aucune information disponible";
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Rubik", 12, FontStyle.Bold);
                lbl.AutoSize = true;
                lbl.Location = new Point(
                    (Page5.Width - lbl.PreferredWidth) / 2,
                    (Page5.Height - lbl.PreferredHeight) / 2);

                Page5.Controls.Add(lbl);
            }
            else
            {
                dgvReq5.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void StyleDGV(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.Info;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Rubik", 10, FontStyle.Bold);

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(56, 56, 56);
            dgv.DefaultCellStyle.ForeColor = Color.White;

            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(65, 65, 65);

            dgv.GridColor = Color.FromArgb(80, 80, 80);
        }

    }
}
