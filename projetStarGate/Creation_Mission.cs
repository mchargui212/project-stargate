using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace projetStarGate
{
    public partial class Creation_Mission : Form
    {
        string nomPlanete;
        int numero;
        string matriculeChef;

        List<string> membres = new List<string>();
        Dictionary<string, int> capture = new Dictionary<string, int>();

        public Creation_Mission()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void Infos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar));
        }

        private void cbo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Creation_Mission_Load(object sender, EventArgs e)
        {
            grpEtape2.Enabled = false;
            grpEtape3.Enabled = false;
            btnSuppriemrMembre.Enabled = false;
            btnModifier.Visible = false;

            try
            {
                string sql = "SELECT nom FROM Planete;";
                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                SQLiteDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                    cboPlanete.Items.Add(dr.GetString(0));

                dr.Close();
            }
            catch (SQLiteException err)
            {
                MessageBox.Show(err.Message);
            }

            txtBudget.Text = "0";
            txtDataBaz.Text = "0";
            txtEquipage.Text = "1";
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            grpEtape1.Enabled = true;
            grpEtape2.Enabled = false;
            grpEtape3.Enabled = false;
            btnSuppriemrMembre.Enabled = false;
            btnModifier.Visible = false;
        }

        private void cboPlanete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPlanete.SelectedIndex >= 0)
            {
                string sql = @"SELECT IFNULL(MAX(numero), 0) FROM Mission WHERE nomPlanete = @nomPlanete";
                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                cmd.Parameters.AddWithValue("@nomPlanete", cboPlanete.SelectedItem.ToString());

                numero = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                lblNomMission.Text = "Nom de la mission : " + cboPlanete.SelectedItem + " " + numero;
                nomPlanete = cboPlanete.SelectedItem.ToString();
            }
        }

        private void cboChef_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChef.SelectedValue != null && !(cboChef.SelectedValue is DataRowView))
                matriculeChef = cboChef.SelectedValue.ToString();
        }

        private void btnValiderPlanete_Click(object sender, EventArgs e)
        {
            if (lblNomMission.Text != "Nom de la mission :")
            {
                grpEtape1.Enabled = false;
                grpEtape2.Enabled = true;

                // Initialisation des listes et FlowLayoutPanel
                membres.Clear();
                capture.Clear();
                flpMembres.Controls.Clear();
                flpCaptures.Controls.Clear();

                try
                {
                    // Chargement du chef disponible
                    string sql = @"SELECT DISTINCT a.matricule AS matricule, a.nom || ' ' || a.prenom AS nomComplet
                                   FROM Membre a
                                   LEFT JOIN Composer c ON c.matriculeMembre = a.matricule
                                   LEFT JOIN Mission m ON c.numeroMission = m.numero AND m.nomPlanete = c.nomPlanete
                                   WHERE a.matricule LIKE 'M%'
                                   AND (m.numero IS NULL OR NOT (m.dateDepart <= @dateRetour AND m.dateRetour >= @dateDepart));";
                    SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                    cmd.Parameters.AddWithValue("@dateDepart", dtpDepart.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@dateRetour", dtpRetour.Value.ToString("yyyy-MM-dd"));

                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    cboChef.DataSource = dt;
                    cboChef.DisplayMember = "nomComplet";
                    cboChef.ValueMember = "matricule";
                }
                catch (SQLiteException err)
                {
                    MessageBox.Show(err.Message);
                }

                try
                {
                    // Chargement des espèces ennemies
                    string sql = @"SELECT e.id AS id, e.nom AS nom
                                   FROM Espece e
                                   JOIN Habiter h ON e.id = h.idEspece
                                   JOIN Ennemi en ON en.idEspece = e.id
                                   WHERE h.nomPlanete = @nomPlanete;";
                    SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                    cmd.Parameters.AddWithValue("@nomPlanete", nomPlanete);

                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    cboCapture.DataSource = dt;
                    cboCapture.DisplayMember = "nom";
                    cboCapture.ValueMember = "id";

                    if (cboPlanete.Items.Count == 0 && cboPlanete.Items[0].ToString() == "")
                    {
                        lblObjectifs.Visible = false;
                        cboCapture.Visible = false;
                        lblNBAlien.Visible = false;
                        txtObjectif.Visible = false;
                        btnAjouterCapture.Visible = false;
                        flpCaptures.Visible = false;
                        btnSuppriemrAlien.Visible = false;
                        btnValider.Location = new System.Drawing.Point(382, 619);
                    } 

                }
                catch (SQLiteException err)
                {
                    MessageBox.Show(err.Message);
                }

                try
                {
                    // Chargement des membres disponibles
                    string sql = @"SELECT DISTINCT a.matricule AS matricule, a.nom || ' ' || a.prenom AS nomComplet
                                   FROM Membre a
                                   LEFT JOIN Composer c ON c.matriculeMembre = a.matricule
                                   LEFT JOIN Mission m ON c.numeroMission = m.numero AND m.nomPlanete = c.nomPlanete
                                   WHERE (m.numero IS NULL OR NOT (m.dateDepart <= @dateRetour AND m.dateRetour >= @dateDepart));";
                    SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                    cmd.Parameters.AddWithValue("@dateDepart", dtpDepart.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@dateRetour", dtpRetour.Value.ToString("yyyy-MM-dd"));

                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    cboMembres.DataSource = dt;
                    cboMembres.DisplayMember = "nomComplet";
                    cboMembres.ValueMember = "matricule";
                }
                catch (SQLiteException err)
                {
                    MessageBox.Show(err.Message);
                }
                btnModifier.Visible = true;
                btnModifier.Enabled = true;
            }
        }

        private void btnAjouterMembre_Click(object sender, EventArgs e)
        {
            if (cboMembres.SelectedItem != null)
            {
                string matricule = cboMembres.SelectedValue.ToString();
                if (!membres.Contains(matricule))
                {
                    string nomComplet = cboMembres.Text;
                    string metier = "Militaire";

                    if (matricule[0] != 'M')
                    {
                        string sql = "SELECT specialite FROM Civil WHERE matriculeMembre = @matricule";
                        SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                        cmd.Parameters.AddWithValue("@matricule", matricule);
                        SQLiteDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                            metier = dr.GetString(0);
                        dr.Close();
                    }
                    Membre nouveauMembre = new Membre(nomComplet, metier, "img/Terre.png");
                    nouveauMembre.Name = matricule;

                    flpMembres.Controls.Add(nouveauMembre);
                    membres.Add(matricule);

                    btnSuppriemrMembre.Enabled = true;
                }
            }
        }

        private void btnAjouterCapture_Click(object sender, EventArgs e)
        {
            if (cboCapture.SelectedItem != null && !string.IsNullOrEmpty(txtObjectif.Text) && txtObjectif.Text != "0")
            {
                string idEspece = cboCapture.SelectedValue.ToString();
                if (!capture.ContainsKey(idEspece))
                {
                    try
                    {
                        string sql = "SELECT typeArme FROM Ennemi WHERE idEspece = @id;";
                        SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                        cmd.Parameters.AddWithValue("@id", idEspece);

                        SQLiteDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            string nom = cboCapture.Text;
                            string arme = dr.GetString(0);
                            int nb = int.Parse(txtObjectif.Text);

                            Alien newAlien = new Alien(nom, arme, nb.ToString(), "img/Terre.png");
                            flpCaptures.Controls.Add(newAlien);
                            capture.Add(idEspece, nb);

                            grpEtape3.Enabled = true;
                        }
                        dr.Close();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
            }
        }

        private void btnSuppriemrAlien_Click(object sender, EventArgs e)
        {
            var aSupprimer = flpCaptures.Controls.OfType<Alien>()
                               .Where(a => a.Selectionne)
                               .ToList();

            foreach (var alien in aSupprimer)
            {
                // retirer de capture
                var key = capture.Keys.FirstOrDefault(k => k == cboCapture.SelectedValue.ToString());
                if (key != null)
                    capture.Remove(key);

                flpCaptures.Controls.Remove(alien);
                alien.Dispose();
            }
        }

        private void btnSupprimerMembre_Click(object sender, EventArgs e)
        {
            var aSupprimer = flpMembres.Controls.OfType<Membre>()
                               .Where(m => m.Selectionne)
                               .ToList();

            foreach (var membre in aSupprimer)
            {
                // retirer de membres
                membres.Remove(membre.Name);
                flpMembres.Controls.Remove(membre);
                membre.Dispose();
            }

            btnSuppriemrMembre.Enabled = flpMembres.Controls.Count > 0;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                // Insert Mission
                string sql = @"INSERT INTO Mission 
                               (nomPlanete, numero, nbMembreRequis, dateDepart, dateRetour, matriculeChef, feuilleDeRoute, objectifDatabaz, budget)
                               VALUES (@nomPlanete, @numero, @nbMembreRequis, @dateDepart, @dateRetour, @matriculeChef, @feuilleDeRoute, @objectifDatabaz, @budget)";
                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);

                cmd.Parameters.AddWithValue("@nomPlanete", nomPlanete);
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@nbMembreRequis", txtEquipage.Text);
                cmd.Parameters.AddWithValue("@dateDepart", dtpDepart.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@dateRetour", dtpRetour.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@matriculeChef", matriculeChef);
                cmd.Parameters.AddWithValue("@feuilleDeRoute", txtFeuille.Text);
                cmd.Parameters.AddWithValue("@objectifDatabaz", txtDataBaz.Text);
                cmd.Parameters.AddWithValue("@budget", txtBudget.Text);

                int ajout = cmd.ExecuteNonQuery();
                if (ajout == 1)
                    MessageBox.Show("Mission ajoutée avec succès!", "Création réussie");
                else
                    MessageBox.Show("Nous n'avons pas réussi à créer votre mission. Veuillez réessayer.", "OUPS!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            try
            {
                // Insert membres dans Composer
                foreach (string matricule in membres)
                {
                    string sql = "INSERT INTO Composer VALUES(@nomPlanete, @numero, @matriculeMembre)";
                    SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                    cmd.Parameters.AddWithValue("@nomPlanete", nomPlanete);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.Parameters.AddWithValue("@matriculeMembre", matricule);
                    cmd.ExecuteNonQuery();
                }

                // Insert captures
                foreach (var kv in capture)
                {
                    string sql = "INSERT INTO Capturer (nomPlanete, numeroMission, idEspeceEnnemi, nombre) " +
                                 "VALUES(@nomPlanete, @numero, @idEspeceEnnemi, @nb)";
                    SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                    cmd.Parameters.AddWithValue("@nomPlanete", nomPlanete);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.Parameters.AddWithValue("@idEspeceEnnemi", kv.Key);
                    cmd.Parameters.AddWithValue("@nb", kv.Value);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnValiderMission_Click(object sender, EventArgs e)
        {
            grpEtape2.Enabled = false;
            grpEtape3.Enabled = true;
        }
    }
}