using projetStarGate;
using System;
using System.Collections;
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

            try
            {
                SQLiteConnection connection = Connexion.Connec;

                string requete = "SELECT mb.nom || ' ' || mb.prenom AS Coéquipier, " +
                    "IIF(mil.matriculeMembre IS NOT NULL, 'Militaire', 'Civil') AS Metier " +
                    "FROM Membre mb " +
                    "JOIN Composer c1 ON mb.matricule = c1.matriculeMembre " +
                    "JOIN Composer c2 ON c1.nomPlanete = c2.nomPlanete AND c1.numeroMission = c2.numeroMission " +
                    "LEFT JOIN Militaire mil ON mb.matricule = mil.matriculeMembre " +
                    "WHERE c2.matriculeMembre = @matricule AND mb.matricule != @matricule";

                SQLiteCommand cmd = new SQLiteCommand(requete, connection);
                cmd.Parameters.AddWithValue("@matricule", matricule);
                SQLiteDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception err)
            {
                MessageBox.Show("Req 1 : " + err.Message);
            }

            return table;
        }

        public DataTable Req2()
        {
            DataTable table = new DataTable();
            try
            {
                SQLiteConnection connection = Connexion.Connec;

                string requete = "SELECT m.nomPlanete || '-' || m.numero AS Mission, m.budget AS \"Budget initial\", " +
                    "IFNULL(dep.TotalDepenses, 0) AS Dépenses, m.budget - IFNULL(dep.TotalDepenses, 0) AS \"Budget actuel\" " +
                    "FROM Mission m " +
                    "LEFT JOIN ( " +
                    "SELECT nomPlanete, numeroMission, SUM(montant) AS TotalDepenses " +
                    "FROM Depense " +
                    "GROUP BY nomPlanete, numeroMission ) " +
                    "dep ON dep.nomPlanete = m.nomPlanete AND dep.numeroMission = m.numero " +
                    "WHERE ( SELECT COUNT(*) " +
                    "FROM Composer c " +
                    "WHERE c.nomPlanete = m.nomPlanete " +
                    "AND c.numeroMission = m.numero); ";

                SQLiteCommand command = new SQLiteCommand(requete, connection);
                SQLiteDataReader re = command.ExecuteReader();
                table.Load(re);
            }
            catch (Exception err) 
            {
                MessageBox.Show(err.Message);
            }
            return table;
        }

        public DataTable Req3()
        {
            DataTable table = new DataTable();

           try{ 
                SQLiteConnection connection = Connexion.Connec;

                string requete = "SELECT p.nom as Planete, COUNT(*) AS \"Nombre total de missions\" "+
                    "FROM Planete p " +
                    "LEFT JOIN Mission m ON p.nom = m.nomPlanete " +
                    "GROUP BY p.nom; ";

                SQLiteCommand command = new SQLiteCommand(requete, connection);
                SQLiteDataReader re = command.ExecuteReader();
                table.Load(re);
            }
            catch(Exception err) 
            {
                MessageBox.Show(err.Message);
            }
            return table;
        }

        public DataTable Req4()
        {
            DataTable table = new DataTable();
            try
            {
                SQLiteConnection connection = Connexion.Connec;

                string requete = " SELECT d.dateD || ' - ' || d.motif || ' - ' || d.montant || '€' AS 'Dépenses les plus importantes', " +
                    "m.nomPlanete || '-' || m.numero AS Mission, " +
                    "chef.prenom || ' ' || chef.nom AS Chef " +
                    "FROM Depense d " +
                    "JOIN Mission m ON d.nomPlanete = m.nomPlanete AND d.numeroMission = m.numero " +
                    "JOIN Membre chef ON m.matriculeChef = chef.matricule " +
                    "WHERE d.montant = (" +
                    "SELECT MAX(montant) " +
                    "FROM Depense d2 " +
                    "WHERE d2.nomPlanete = d.nomPlanete AND d2.numeroMission = d.numeroMission) " +
                    "AND m.nbMembreRequis > 10;";
                SQLiteCommand command = new SQLiteCommand(requete, connection);
                SQLiteDataReader re = command.ExecuteReader();
                table.Load(re);
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }

            return table;
        }

        private void Statistiques_Load(object sender, EventArgs e)
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

                SQLiteCommand cmd = new SQLiteCommand(reqMembres, Connexion.Connec);
                SQLiteDataReader r = cmd.ExecuteReader();
                membres.Load(r);

                cboReq1.DisplayMember = "NomComplet";
                cboReq1.ValueMember = "matricule";
                cboReq1.DataSource = membres;

                string reqMissions = "SELECT nomPlanete || '-' || numero AS NomMission, nomPlanete, numero " +
                    "FROM Mission ORDER BY nomPlanete, numero";
                DataTable missions = new DataTable();
                cmd = new SQLiteCommand(reqMissions, Connexion.Connec);
                r = cmd.ExecuteReader();
                missions.Load(r);
                
                cboReq5.DisplayMember = "NomMission";
                cboReq5.ValueMember = "NomMission";
                cboReq5.DataSource = missions;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        public DataTable Req5(string nomPlanete, int numeroMission)
        {
            DataTable table = new DataTable();
            try
            {
                SQLiteConnection connection = Connexion.Connec;

                string requete = "SELECT i.nomCode AS \"Nom de code\", e.nom AS Espèce, SUM(co.sommeVersee) AS Total " +
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

                SQLiteCommand command = new SQLiteCommand(requete, connection);
                command.Parameters.AddWithValue("@nomPlanete", nomPlanete);
                command.Parameters.AddWithValue("@numeroMission", numeroMission);
                SQLiteDataReader reader = command.ExecuteReader();
                table.Load(reader);

            }
            catch (Exception err) 
            {
                MessageBox.Show(err.Message);
            }
            return table;
        }

        private void cboReq1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvReq1.Visible = false;
            if (cboReq1.SelectedValue == null)
            {
                return;
            }

            DataTable dt = Req1(cboReq1.SelectedValue.ToString());
            dgvReq1.DataSource = dt;

            Control oldLbl = Page1.Controls["lblAucuneInfo"];
            if (oldLbl != null)
                Page1.Controls.Remove(oldLbl);

            if (dt.Rows.Count == 0)
            {
                Label lbl = new Label();
                lbl.Name = "lblAucuneInfo";
                lbl.Text = "Aucune information disponible";
                lbl.ForeColor = SystemColors.Info;
                lbl.Font = new Font("Rubik", 22, FontStyle.Bold);
                lbl.AutoSize = true;
                lbl.Location = new Point(170, 120);

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

            Control oldLbl = Page5.Controls["lblAucuneInfo"];
            if (oldLbl != null)
                Page5.Controls.Remove(oldLbl);

            if (dt.Rows.Count == 0)
            {
                
                Label lbl = new Label();
                lbl.Name = "lblAucuneInfo";
                lbl.Text = "Aucune information disponible";
                lbl.ForeColor = SystemColors.Info;
                lbl.Font = new Font("Rubik", 22, FontStyle.Bold);
                lbl.AutoSize = true;
                lbl.Location = new Point(170, 120);

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
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Rubik", 16, FontStyle.Bold);

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(56, 56, 56);
            dgv.DefaultCellStyle.ForeColor = SystemColors.Info;

            dgv.DefaultCellStyle.SelectionBackColor = SystemColors.Info;
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(56, 56, 56);

            dgv.GridColor = Color.FromArgb(80, 80, 80);
        }

        private void cboReq1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
