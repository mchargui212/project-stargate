using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetStarGate
{
    public partial class Creation_Mission : Form
    {        string nomPlanete;
        int numero;
        string matriculeChef;
        public Creation_Mission()
        {
            InitializeComponent();
        }

        private void Infos_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            e.Handled = true;

            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void cbo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            e.Handled = true;
        }

        private void Creation_Mission_Load(object sender, EventArgs e)
        {
            grpEtape2.BackColor = SystemColors.ControlLight;
            grpEtape2.Enabled = false;
            grpEtape3.Enabled = false;

            try
            {
                string sql = "SELECT nom from Planete;";
                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                SQLiteDataReader dr = cmd.ExecuteReader();

                int compt = 0;
                while (dr.Read())
                {
                    cboPlanete.Items.Add(dr.GetString(0));
                }
                dr.Close();
            }catch (SQLiteException err){
                MessageBox.Show(err.Message);
            }

            try
            {
                string sql = "select a.matriculeMembre as matricule, m.nom || ' ' || m.prenom as nomComplet  from Militaire a join Membre m on a.matriculeMembre = m.matricule;";
                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                cboChef.DataSource = dt;
                cboChef.DisplayMember = "nomComplet";
                cboChef.ValueMember = "matricule";
            }catch (SQLiteException err){
                MessageBox.Show(err.Message);
            }
            txtBudget.Text = "0";
            txtDataBaz.Text = "0";
            txtEquipage.Text = "1";
        }

        private void btnValiderPlanete_Click(object sender, EventArgs e)
        {
            if (lblNomMission.Text != "Nom de la mission :")
            {
                grpEtape1.Enabled = false;
                grpEtape2.Enabled = true;

            }       
        }
        private void btnValiderChef_Click(object sender, EventArgs e)
        {
            matriculeChef = cboChef.SelectedValue.ToString();

            grpEtape2.Enabled = false;
            grpEtape3.Enabled = true;
        }

        private void btnValiderMission_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = "Insert into Mission (nomPlanete, numero, nbMembreRequis, dateDepart, dateRetour, matriculeChef, feuilleDeRoute, objectifDatabaz, budget)" +
                    "VALUES (@nomPlanete, @numero, @nbMembreRequis, @dateDepart, @dateRetour, @matriculeChef, @feuilleDeRoute, @objectifDatabaz, @budget);";
                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);

                cmd.Parameters.AddWithValue("@nomPlanete", nomPlanete);
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@nbMembreRequis", txtEquipage.Text);
                cmd.Parameters.AddWithValue("@dateDepart", dtpDepart.Text);
                cmd.Parameters.AddWithValue("@dateRetour", dtpRetour.Text);
                cmd.Parameters.AddWithValue("@matriculeChef", matriculeChef);
                cmd.Parameters.AddWithValue("@feuilleDeRoute", txtFeuille.Text);
                cmd.Parameters.AddWithValue("@objectifDatabaz", txtDataBaz.Text);
                cmd.Parameters.AddWithValue("@budget", txtBudget.Text);

                int ajout = cmd.ExecuteNonQuery();
                if (ajout == 1) {
                    MessageBox.Show("Mission ajoutée avec succés!", "Création réussie");
                }
                else
                {
                    MessageBox.Show("Nous n'avons pas réussi à créer votre mission..\nVeillez reéssayer.", "OUPS!");
                }
            }
            catch (Exception err) {
                MessageBox.Show(err.Message);
            }
        }

        private void cboPlanete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPlanete.SelectedIndex >= 0)
            {
                string sql = "select max(numero) from Mission where nomPlanete = '" + cboPlanete.SelectedItem + "';";
                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                try
                {
                    int nb = Convert.ToInt32(cmd.ExecuteScalar());

                    lblNomMission.Text = "Nom de la mission :    " + cboPlanete.SelectedItem + " " + nb.ToString();

                    nomPlanete = cboPlanete.SelectedItem.ToString();
                    numero = nb;
                }
                catch
                {
                    lblNomMission.Text = "Nom de la mission :    " + cboPlanete.SelectedItem + " 1";

                    nomPlanete = cboPlanete.SelectedItem.ToString();
                    numero = 1;
                }
            }
        }
    }
}
