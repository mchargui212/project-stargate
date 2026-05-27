using appliPandora;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetStarGate
{
    public partial class frmTableauDeBord : Form
    {
        private FlowLayoutPanel flplMission;
        private ComboBox cmbStatusMission;
        private List<MissionItems> allMissions = new List<MissionItems>();
        public frmTableauDeBord()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void frmTableauDeBord_Load(object sender, EventArgs e)
        {
            clearFillDB();

            filtreMission();
            completeFlpl();
            fillFlpl();
            afficherMissions();

            Button btnExit = new Button();
            btnExit.Location = new Point(ClientSize.Width - 260, ClientSize.Height - 54);
            btnExit.Size = new Size(50, 50);
            btnExit.AutoSize = true;
            btnExit.Name = "btnExit";
            btnExit.Text = "Retourn à la page d'accueil";
            Controls.Add(btnExit);
            btnExit.Click += buttonExit_Click;

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public class MissionItems
        {
            public int numGlobal { get; set; }
            public int numParPlanete { get; set; }
            public string nomPlanete { get; set; }
            public string dtDepart { get; set; }
            public string dtRetour { get; set; }
            public string chef { get; set; }
            public int numMission { get; set; }
            public string matChef { get; set; }
        }

        private string dateNormilzed(string date)
        {
            DateTime dt;
            if (DateTime.TryParseExact(date, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out dt))
            {
                return dt.ToString("dd/MM/yyyy");
            }
            else
            {
                return date;
            }
        }

        private void filtreMission()
        {
            cmbStatusMission = new ComboBox();
            cmbStatusMission.Location = new Point(12, 25);
            cmbStatusMission.Name = "cmbStatusMission";
            cmbStatusMission.Size = new Size(500, 20);
            cmbStatusMission.Items.Add("Choisissez - vous l'etat des missions...");
            cmbStatusMission.Items.Add("Active");
            cmbStatusMission.Items.Add("Terminée");
            cmbStatusMission.Items.Add("Toutes");
            cmbStatusMission.SelectedIndex = 0;
            cmbStatusMission.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbStatusMission.SelectedIndexChanged += cmbStatusMission_SelectedIndexChanged;
            Controls.Add(cmbStatusMission);
        }
        private void cmbStatusMission_SelectedIndexChanged(object sender, EventArgs e)
        {
            afficherMissions();
        }

        private void completeFlpl()
        {
            flplMission = new FlowLayoutPanel();
            flplMission.AutoScroll = true;
            flplMission.FlowDirection = FlowDirection.TopDown;
            flplMission.Location = new System.Drawing.Point(12, 68);
            flplMission.Name = "flpMissions";
            flplMission.Size = new System.Drawing.Size(500, ClientSize.Height - 24);
            flplMission.WrapContents = false;
            flplMission.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;

            Controls.Add(flplMission);
        }

        private void fillFlpl()
        {
            try
            {
                string sql = @"select mi.nomPlanete, mi.dateDepart, mi.dateRetour, mem.nom, mem.prenom, mi.numero, mi.matriculeChef
                               from mission mi
                               join membre mem on mem.matricule = mi.matriculeChef
                               Order by mi.dateDepart, mi.nomPlanete, mi.numero";
                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int numGloabl = 0;
                    Dictionary<string, int> numParPl = new Dictionary<string, int>();
                    while (dr.Read())
                    {
                        numGloabl++;
                        string planet = dr.GetString(0);

                        if (!numParPl.ContainsKey(planet))
                        {
                            numParPl[planet] = 0;
                        }
                        numParPl[planet]++;

                        MissionItems mission = new MissionItems();
                        mission.numGlobal = numGloabl;
                        mission.numParPlanete = numParPl[planet];
                        mission.nomPlanete = planet;

                        mission.dtDepart = dateNormilzed(dr.GetString(1));
                        mission.dtRetour = dateNormilzed(dr.GetString(2));
                        mission.chef = dr.GetString(3) + " " + dr.GetString(4);
                        mission.numMission = dr.GetInt32(5);
                        mission.matChef = dr.GetString(6);

                        allMissions.Add(mission);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void afficherMissions()
        {
            if (flplMission == null)
            {
                MessageBox.Show("Error : flplMission is null");
            }
            flplMission.Controls.Clear();
            foreach (MissionItems mission in allMissions)
            {
                bool afficher = true;

                DateTime dtRetour;

                if (DateTime.TryParse(mission.dtRetour, out dtRetour))
                {
                    if (cmbStatusMission.SelectedIndex == 1) //active
                    {
                        afficher = dtRetour > DateTime.Today;
                    }
                    else if (cmbStatusMission.SelectedIndex == 2)//terminée
                    {
                        afficher = dtRetour <= DateTime.Today;
                    }
                    else
                    {
                        afficher = true;
                    }
                }
                if (afficher)
                {
                    GroupBox grp = insertInfoMission(mission);
                    flplMission.Controls.Add(grp);
                }
            }
        }

        public GroupBox insertInfoMission(MissionItems mission)
        {
            int xGrpSize = 490;
            int yGrpSize = 290;
            // 
            // groupBox1
            // 
            GroupBox grp = new GroupBox();
            grp.Name = "grpMissionInfo_" + mission.numGlobal;
            grp.Size = new System.Drawing.Size(xGrpSize, yGrpSize);
            grp.TabStop = false;
            grp.Text = "Mission : " + mission.numGlobal;
            grp.Margin = new Padding(5);
            grp.Font = new Font(grp.Font.FontFamily, 20);
            // 
            // label1 - Planete name
            // 
            Label lblPlName = new Label();
            lblPlName.AutoSize = true;
            lblPlName.Location = new System.Drawing.Point(20, 30);
            lblPlName.Name = "lblPlaneteName_" + mission.numGlobal;
            lblPlName.Size = new System.Drawing.Size(35, 13);
            lblPlName.Text = mission.nomPlanete + " (" + mission.numParPlanete + ")";
            lblPlName.Font = new Font(lblPlName.Font.FontFamily, 18);
            // 
            // pictureBox1 - Image of mision/planet
            // 
            PictureBox pctrPl = new PictureBox();
            pctrPl.Location = new System.Drawing.Point(xGrpSize / 2 - 75, 60);
            pctrPl.Name = "pctrMission_" + mission.numGlobal;
            pctrPl.Size = new System.Drawing.Size(150, 150);
            pctrPl.Image = Image.FromFile("img/" + mission.nomPlanete + ".png");
            pctrPl.SizeMode = PictureBoxSizeMode.Zoom;
            pctrPl.TabStop = false;
            // 
            // label2 - Date Start
            // 
            Label lblDtDep = new Label();
            lblDtDep.AutoSize = true;
            lblDtDep.Location = new System.Drawing.Point(xGrpSize - 390, 210);
            lblDtDep.Name = "lblMissionDateStart_" + mission.numGlobal;
            lblDtDep.Size = new System.Drawing.Size(35, 13);
            lblDtDep.Text = mission.dtDepart + "    -";
            lblDtDep.Font = new Font(lblDtDep.Font.FontFamily, 16);
            // 
            // label3 - Date End
            // 
            Label lblDtFin = new Label();
            lblDtFin.AutoSize = true;
            lblDtFin.Location = new System.Drawing.Point(xGrpSize - 235, 210);
            lblDtFin.Name = "lblMissionDateEnd_" + mission.numGlobal;
            lblDtFin.Size = new System.Drawing.Size(35, 13);
            lblDtFin.Text = mission.dtRetour;
            lblDtFin.Font = new Font(lblDtFin.Font.FontFamily, 16);
            // 
            // label4 - Chef Name
            // 
            Label lblChefName = new Label();
            lblChefName.AutoSize = true;
            lblChefName.Location = new System.Drawing.Point(20, yGrpSize - 43);
            lblChefName.Name = "lblMissionChef_" + mission.numGlobal;
            lblChefName.Size = new System.Drawing.Size(35, 13);
            lblChefName.Text = "Chef : " + mission.chef;
            lblChefName.Font = new Font(lblChefName.Font.FontFamily, 18);
            // 
            // button1 - Information detaillee
            // 
            Button btnInfo = new Button();
            btnInfo.AutoSize = true;
            btnInfo.Location = new System.Drawing.Point(xGrpSize - 85, yGrpSize - 43);
            btnInfo.Name = "btnMissionInfo_" + mission.numGlobal;
            btnInfo.Size = new System.Drawing.Size(75, 23);
            btnInfo.Text = "Details";
            btnInfo.Tag = mission.nomPlanete + ";" + mission.numMission + ";" + mission.matChef + ";" + mission.numGlobal;
            btnInfo.Font = new Font(btnInfo.Font.FontFamily, 14);
            btnInfo.Click += buttonInflo_Click;

            grp.Controls.Add(lblChefName);
            grp.Controls.Add(lblDtFin);
            grp.Controls.Add(lblDtDep);
            grp.Controls.Add(pctrPl);
            grp.Controls.Add(lblPlName);
            grp.Controls.Add(btnInfo);

            return (grp);
        }

        private void clearFillDB()
        {
            MesDatas.DsGlobal.Tables.Clear();

            try
            {
                string sql = "select name from sqlite_master where type = 'table' order by name";

                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                SQLiteDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string nomTab = dr.GetString(0);
                        addTab(nomTab);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("clearFillDB : " + err.Message);
            }
        }

        private void addTab(string nomTab)
        {
            try
            {
                string sql = "select * from " + nomTab;

                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, Connexion.Connec);
                da.Fill(MesDatas.DsGlobal, nomTab);
            }
            catch (Exception err)
            {
                MessageBox.Show("addTab : " + err.Message);
            }
        }

        private void buttonInflo_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tag = btn.Tag.ToString();
            string[] parts = tag.Split(';');

            string planet = parts[0];
            int numMission = int.Parse(parts[1]);
            string matChef = parts[2];
            string idPl = parts[3];

            suprimmerAncienGroups();

            GroupBox grpDetails = createGroupDetails(planet, numMission);
            Controls.Add(grpDetails);

            chargerInfoMission(grpDetails, planet, numMission, matChef, idPl);
            chargerObjectif(grpDetails, planet, numMission);
            chargerMembers(grpDetails, planet, numMission);
        }

        private void suprimmerAncienGroups()
        {
            Control oldDetails = Controls["grpDetails"];
            if (oldDetails != null)
            {
                Controls.Remove(oldDetails);
                oldDetails.Dispose();
            }

            Control oldMod = Controls["grpModification"];
            if (oldMod != null)
            {
                Controls.Remove(oldMod);
                oldMod.Dispose();
            }

            Control oldLbl = Controls["lblNotChangable"];
            if (oldLbl != null)
            {
                Controls.Remove(oldLbl);
                oldLbl.Dispose();
            }
        }

        private GroupBox createGroupDetails(string planet, int numMission)
        {
            Control oldDetails = Controls["grpDetails"];
            if (oldDetails != null)
            {
                Controls.Remove(oldDetails);
                oldDetails.Dispose();
            }

            int xGrpSize = 820;

            GroupBox grpDetails = new GroupBox();
            grpDetails.Name = "grpDetails";
            grpDetails.Location = new Point(522, 17);
            grpDetails.Size = new Size(xGrpSize, ClientSize.Height - 24);
            grpDetails.TabStop = false;
            grpDetails.Font = new Font(grpDetails.Font.FontFamily, 20);
            grpDetails.Text = "Details pour mission " + numMission + " sur la planete " + planet;

            return grpDetails;
        }

        private void chargerInfoMission(GroupBox grpDetails, string planet, int numMission, string matChef, string idPl)
        {
            string sql = @"select nbMembreRequis,dateDepart,dateRetour,feuilleDeRoute,objectifDatabaz,budget
                   from mission
                   where nomPlanete = @planet and numero = @numMission and matriculeChef = @matChef;";
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);

                cmd.Parameters.AddWithValue("@planet", planet);
                cmd.Parameters.AddWithValue("@numMission", numMission);
                cmd.Parameters.AddWithValue("@matChef", matChef);

                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int nbMembers = dr.GetInt32(0);
                        string dtStart = dateNormilzed(dr.GetString(1));
                        string dtEnd = dateNormilzed(dr.GetString(2));
                        string feuille = dr.GetString(3);
                        int objectifDatabaz = dr.GetInt32(4);
                        int budget = dr.GetInt32(5);

                        int xGrpSize = grpDetails.Width;
                        int yGrpSize = grpDetails.Height;

                        PictureBox pctrPl = new PictureBox();
                        pctrPl.Location = new Point(xGrpSize / 2 - 40, 30);
                        pctrPl.Name = "pctrPlanet";
                        pctrPl.Size = new System.Drawing.Size(150, 160);
                        pctrPl.SizeMode = PictureBoxSizeMode.Zoom;
                        pctrPl.Image = Image.FromFile("img/" + planet + ".png");
                        pctrPl.TabStop = false;
                        grpDetails.Controls.Add(pctrPl);

                        Label lblPlanetDetails = new Label();
                        lblPlanetDetails.Location = new Point(xGrpSize / 2 - 40, 105);
                        lblPlanetDetails.AutoSize = true;
                        lblPlanetDetails.Name = "lblPlanetDetails";
                        lblPlanetDetails.Text = planet;
                        lblPlanetDetails.Font = new Font(lblPlanetDetails.Font.FontFamily, 18);
                        grpDetails.Controls.Add(lblPlanetDetails);

                        Label lblDtStart = new Label();
                        lblDtStart.Location = new Point(10, 128);
                        lblDtStart.AutoSize = true;
                        lblDtStart.Name = "lblDtStart";
                        lblDtStart.Text = "Date de départ : " + dtStart;
                        lblDtStart.Font = new Font(lblDtStart.Font.FontFamily, 16);
                        grpDetails.Controls.Add(lblDtStart);

                        Label lblDtEnd = new Label();
                        lblDtEnd.Location = new Point(10, 151);
                        lblDtEnd.AutoSize = true;
                        lblDtEnd.Name = "lblDtEnd";
                        lblDtEnd.Text = "Date de retour : " + dtEnd;
                        lblDtEnd.Font = new Font(lblDtEnd.Font.FontFamily, 16);
                        grpDetails.Controls.Add(lblDtEnd);

                        Label lblBudget = new Label();
                        lblBudget.Location = new Point(xGrpSize - 235, 128);
                        lblBudget.AutoSize = true;
                        lblBudget.Name = "lblBudget";
                        lblBudget.Text = "Budget : " + budget + "€";
                        lblBudget.Font = new Font(lblBudget.Font.FontFamily, 16);
                        grpDetails.Controls.Add(lblBudget);

                        Label lblBudgetReste = new Label();
                        lblBudgetReste.Location = new Point(xGrpSize - 235, 151);
                        lblBudgetReste.AutoSize = true;
                        lblBudgetReste.Name = "lblBudgetReste";
                        lblBudgetReste.Text = "Budget restant : " + (budget - 100) + "€";
                        lblBudgetReste.Font = new Font(lblBudgetReste.Font.FontFamily, 16);
                        grpDetails.Controls.Add(lblBudgetReste);

                        Label lblNbMembers = new Label();
                        lblNbMembers.Location = new Point(10, ClientSize.Height - 40 - 390);
                        lblNbMembers.AutoSize = true;
                        lblNbMembers.Name = "lblNbMembers";
                        lblNbMembers.Text = "Membres requis : " + nbMembers;
                        lblNbMembers.Font = new Font(lblNbMembers.Font.FontFamily, 16);
                        grpDetails.Controls.Add(lblNbMembers);


                        /*
                        Label lblObjectifDatabaz = new Label();
                        lblObjectifDatabaz.Location = new Point(xGrpSize - 170, 164);
                        lblObjectifDatabaz.AutoSize = true;
                        lblObjectifDatabaz.Name = "lblObjectifDatabaz";
                        lblObjectifDatabaz.Text = "Objectif Databaz : " + objectifDatabaz;
                        grpDetails.Controls.Add(lblObjectifDatabaz);
                        */

                        RichTextBox rtxtFeuille = new RichTextBox();
                        rtxtFeuille.Location = new Point(10, 220);
                        rtxtFeuille.Name = "rtxtFeuille";
                        rtxtFeuille.Size = new Size(xGrpSize - 30, yGrpSize - 650);
                        rtxtFeuille.Text = "Feuille de route :\n" + feuille;
                        rtxtFeuille.ReadOnly = true;
                        rtxtFeuille.TabStop = false;
                        rtxtFeuille.WordWrap = true;
                        rtxtFeuille.ScrollBars = RichTextBoxScrollBars.Vertical;
                        rtxtFeuille.Font = new Font(rtxtFeuille.Font.FontFamily, 14);
                        grpDetails.Controls.Add(rtxtFeuille);

                        DateTime dtRet = DateTime.Parse(dtEnd);
                        if (dtRet > DateTime.Today)
                        {
                            createGroupModification();
                        }
                        else
                        {
                            Label lblNotChangable = new Label();
                            lblNotChangable.Text = "Pas possible à changer l'information\ncar mission est déja fini.";
                            lblNotChangable.Font = new Font(lblNotChangable.Font.FontFamily, 20);
                            lblNotChangable.Location = new Point(ClientSize.Width - 500, ClientSize.Height / 2);
                            lblNotChangable.AutoSize = true;
                            lblNotChangable.Name = "lblNotChangable";
                            Controls.Add(lblNotChangable);
                        }
                    }
                }
            }
            catch (SQLiteException err)
            {
                MessageBox.Show("chargerInfoMission\n" + err.Message);
            }
        }

        private void chargerMembers(GroupBox grpDetails, string planet, int numMission)
        {
            FlowLayoutPanel flplMembers = new FlowLayoutPanel();

            flplMembers.AutoScroll = true;
            flplMembers.FlowDirection = FlowDirection.LeftToRight;
            flplMembers.Location = new Point(10, ClientSize.Height - 40 - 360);
            flplMembers.Name = "flpMembers";
            flplMembers.Size = new Size(grpDetails.Width - 30, 245);
            flplMembers.WrapContents = false;
            flplMembers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;

            string sql = @"select mem.nom,mem.prenom,civ.specialite,mil.grade
                   from Composer com
                    join membre mem on mem.matricule = com.matriculeMembre
                    left join civil civ on civ.matriculeMembre = mem.matricule
                    left join militaire mil on mil.matriculeMembre = mem.matricule
                    where com.nomPlanete = @planet and com.numeroMission = @numMission
                    order by mem.nom, mem.prenom;";

            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);

                cmd.Parameters.AddWithValue("@planet", planet);
                cmd.Parameters.AddWithValue("@numMission", numMission);

                SQLiteDataReader dr = cmd.ExecuteReader();
                {
                    if (dr.HasRows)
                    {
                        int i = 0;
                        while (dr.Read())
                        {
                            i++;

                            string membreName = dr.GetString(0) + " " + dr.GetString(1);
                            string specialite = dr.IsDBNull(2) ? "" : dr.GetString(2);
                            string grade = dr.IsDBNull(3) ? "" : dr.GetString(3);

                            GroupBox grpMember = new GroupBox();
                            grpMember.Name = "grpMember_" + i;
                            grpMember.Size = new Size(257, 220);
                            grpMember.TabStop = false;
                            grpMember.Font = new Font(grpMember.Font.FontFamily, 18);

                            PictureBox pctrMembre = new PictureBox();
                            pctrMembre.Location = new Point(180 / 2 - 40, 20);
                            pctrMembre.Name = "pctrMembre_" + i;
                            pctrMembre.Size = new Size(120, 120);
                            pctrMembre.TabStop = false;
                            grpMember.Controls.Add(pctrMembre);

                            Label lblMembreName = new Label();
                            lblMembreName.Location = new Point(10, 170);
                            lblMembreName.AutoSize = true;
                            lblMembreName.Name = "lblMembre_" + i;
                            lblMembreName.Text = membreName;
                            lblMembreName.Font = new Font(lblMembreName.Font.FontFamily, 14);
                            grpMember.Controls.Add(lblMembreName);

                            Label lblMembreSpecification = new Label();
                            lblMembreSpecification.Location = new Point(10, 190);
                            lblMembreSpecification.AutoSize = true;
                            lblMembreSpecification.Font = new Font(lblMembreSpecification.Font.FontFamily, 14);
                            lblMembreSpecification.Name = "lblMembreSpecification_" + i;

                            if (!string.IsNullOrEmpty(specialite))
                            {
                                lblMembreSpecification.Text = "Spécialité : " + specialite;
                            }
                            else if (!string.IsNullOrEmpty(grade))
                            {
                                lblMembreSpecification.Text = "Grade : " + grade;
                            }
                            else
                            {
                                lblMembreSpecification.Text = "Type inconnu";
                            }

                            grpMember.Controls.Add(lblMembreSpecification);

                            flplMembers.Controls.Add(grpMember);
                        }
                    }
                }
            }
            catch (SQLiteException err)
            {
                MessageBox.Show("chargerMembers" + err.Message);
            }
            grpDetails.Controls.Add(flplMembers);
        }

        private void chargerObjectif(GroupBox grpDetails, string planet, int numMission)
        {
            RichTextBox rtxtObjectif = new RichTextBox();

            rtxtObjectif.Location = new Point(10, ClientSize.Height - 110 - 30);
            rtxtObjectif.Name = "rtxtObjectif";
            rtxtObjectif.Size = new Size(grpDetails.Width - 130, 110);
            rtxtObjectif.Font = new Font(rtxtObjectif.Font.FontFamily, 14);
            rtxtObjectif.ReadOnly = true;
            rtxtObjectif.TabStop = false;

            Button btnOpenJournal = new Button();
            btnOpenJournal.Location = new Point(grpDetails.Width - 105, ClientSize.Height - 130);
            btnOpenJournal.Name = "btnopenJournal";
            btnOpenJournal.Text = "Journal";
            btnOpenJournal.Size = new Size(90, 90);
            btnOpenJournal.Font = new Font(btnOpenJournal.Font.FontFamily, 14);

            rtxtObjectif.Text = "Objectifs de capture :\n";

            string sql = @"select obCap.objectif, ifnull(cap.nombre, 0), esp.nom,esp.couleur
                           from ObjectifCapture obCap
                           left join Capturer cap on cap.nomPlanete = obCap.nomPlanete and cap.numeroMission = obCap.numeroMission and cap.idEspeceEnnemi = obCap.idEspeceEnnemi
                           left join espece esp on esp.id = obCap.idEspeceEnnemi
                           where obCap.nomPlanete = @planet and obCap.numeroMission = @numMission
                           order by esp.nom;";
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                cmd.Parameters.AddWithValue("@planet", planet);
                cmd.Parameters.AddWithValue("@numMission", numMission);

                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int objectif = dr.GetInt32(0);
                        int capture = dr.GetInt32(1);
                        string espece = dr.GetString(2);
                        string couleur = dr.GetString(3);

                        rtxtObjectif.Text +=
                            "- " + espece;

                        if (!string.IsNullOrEmpty(couleur))
                        {
                            rtxtObjectif.Text += " (" + couleur + ")";
                        }

                        rtxtObjectif.Text += " : " + capture + " / " + objectif + "\n";
                    }
                }
            }
            catch (SQLiteException err)
            {
                MessageBox.Show("chargerObjectif" + err.Message);
            }
            grpDetails.Controls.Add(rtxtObjectif);
            grpDetails.Controls.Add(btnOpenJournal);
        }

        private void createGroupModification()
        {
            Control oldMod = Controls["grpModification"];
            if (oldMod != null)
            {
                Controls.Remove(oldMod);
                oldMod.Dispose();
            }

            GroupBox grpModification = new GroupBox();
            grpModification.Location = new Point(ClientSize.Width - 550 - 10, 17);
            grpModification.Size = new Size(550, ClientSize.Height - 84);
            grpModification.Name = "grpModification";
            grpModification.Font = new Font(grpModification.Font.FontFamily, 20);
            grpModification.Text = "Modification de la mission";

            Controls.Add(grpModification);

            GroupBox grpEdition = new GroupBox();
            grpEdition.Location = new Point(10, 35);
            grpEdition.Size = new Size(grpModification.Width - 20, 90);
            grpEdition.Name = "grpEdition";
            grpEdition.Text = "Mode d'edition";
            grpEdition.Font = new Font(grpEdition.Font.FontFamily, 18);
            grpModification.Controls.Add(grpEdition);

            Button btnContact = new Button();
            btnContact.Location = new Point(10, 30);
            btnContact.Size = new Size(50, 50);
            btnContact.AutoSize = true;
            btnContact.Name = "btnContact";
            btnContact.Text = "Contact";
            btnContact.Font = new Font(btnContact.Font.FontFamily, 14);
            btnContact.Click += buttonContact_Click;
            grpEdition.Controls.Add(btnContact);

            Button btnDepends = new Button();
            btnDepends.Location = new Point(170, 30);
            btnDepends.Size = new Size(50, 50);
            btnDepends.AutoSize = true;
            btnDepends.Name = "btnDepends";
            btnDepends.Text = "Dépendances";
            btnDepends.Font = new Font(btnDepends.Font.FontFamily, 14);
            btnDepends.Click += buttonDepends_Click;
            grpEdition.Controls.Add(btnDepends);

            Button btnEvent = new Button();
            btnEvent.Location = new Point(grpModification.Width - 155, 30);
            btnEvent.Size = new Size(50, 50);
            btnEvent.AutoSize = true;
            btnEvent.Name = "btnEvent";
            btnEvent.Text = "Événements";
            btnEvent.Font = new Font(btnEvent.Font.FontFamily, 14);
            btnEvent.Click += buttonEvent_Click;
            grpEdition.Controls.Add(btnEvent);

        }

        private void buttonContact_Click(object sender, EventArgs e)
        {
            Control grpModification = Controls["grpModification"];
            Control grpEdition = grpModification.Controls["grpEdition"];

            Control old = grpModification.Controls["grpAddContact"];
            if (old != null)
            {
                grpModification.Controls.Remove(old);
                old.Dispose();
            }

            if (grpModification != null && grpEdition != null)
            {
                GroupBox grpAddContact = new GroupBox();
                grpAddContact.Location = new Point(10, grpEdition.Height + 50);
                grpAddContact.Size = new Size(grpEdition.Width, grpModification.Height - grpEdition.Height - 60);
                grpAddContact.Name = "grpAddContact";
                grpAddContact.Text = "Nouveue contact";
                grpAddContact.Font = new Font(grpAddContact.Font.FontFamily, 16);
                grpModification.Controls.Add(grpAddContact);

                Label lblDate = new Label();
                lblDate.Location = new Point(10, 40);
                lblDate.AutoSize = true;
                lblDate.Name = "lblDate";
                lblDate.Text = "Date :";
                lblDate.Font = new Font(lblDate.Font.FontFamily, 14);
                grpAddContact.Controls.Add(lblDate);

                DateTimePicker dtmContact = new DateTimePicker();
                dtmContact.Location = new Point(100, 40);
                dtmContact.Name = "dtmContact";
                dtmContact.Size = new Size(200, 20);
                dtmContact.Font = new Font(dtmContact.Font.FontFamily, 14);
                grpAddContact.Controls.Add(dtmContact);

                Label lblSomme = new Label();
                lblSomme.Location = new Point(10, 90);
                lblSomme.AutoSize = true;
                lblSomme.Name = "lblSomme";
                lblSomme.Text = "Somme :";
                lblSomme.Font = new Font(lblSomme.Font.FontFamily, 14);
                grpAddContact.Controls.Add(lblSomme);

                TextBox txtSomme = new TextBox();
                txtSomme.Location = new Point(100, 90);
                txtSomme.Name = "txtSomme";
                txtSomme.Size = new Size(200, 20);
                txtSomme.Font = new Font(txtSomme.Font.FontFamily, 14);
                //txtSomme.KeyPress += 
                grpAddContact.Controls.Add(txtSomme);

                Label lblAppr = new Label();
                lblAppr.Location = new Point(10, 140);
                lblAppr.AutoSize = true;
                lblAppr.Name = "lblAppr";
                lblAppr.Text = "Appréciatopn :";
                lblAppr.Font = new Font(lblAppr.Font.FontFamily, 14);
                grpAddContact.Controls.Add(lblAppr);

                TextBox txtAppr = new TextBox();
                txtAppr.Location = new Point(145, 140);
                txtAppr.Size = new Size(250, 200);
                txtAppr.Name = "txtAppr";
                txtAppr.Font = new Font(txtAppr.Font.FontFamily, 14);
                grpAddContact.Controls.Add(txtAppr);

                Button btnValider = new Button();
                btnValider.Location = new Point(grpAddContact.Width - 90, grpAddContact.Height - 60);
                btnValider.Size = new Size(50, 50);
                btnValider.AutoSize = true;
                btnValider.Name = "btnValider";
                btnValider.Font = new Font(btnValider.Font.FontFamily, 14);
                btnValider.Text = "Valider";
                grpAddContact.Controls.Add(btnValider);

                Button btnAnnuler = new Button();
                btnAnnuler.Location = new Point(grpAddContact.Width - 90 * 2, grpAddContact.Height - 60);
                btnAnnuler.Size = new Size(50, 50);
                btnAnnuler.AutoSize = true;
                btnAnnuler.Name = "btnAnnuler";
                btnAnnuler.Font = new Font(btnValider.Font.FontFamily, 14);
                btnAnnuler.Text = "Annuler";
                grpAddContact.Controls.Add(btnAnnuler);
            }
        }

        private void buttonDepends_Click(object sender, EventArgs e)
        {
            Control grpModification = Controls["grpModification"];
            Control grpEdition = grpModification.Controls["grpEdition"];

            Control old = grpModification.Controls["grpAddContact"];
            if (old != null)
            {
                grpModification.Controls.Remove(old);
                old.Dispose();
            }

            if (grpModification != null && grpEdition != null)
            {
                GroupBox grpAddContact = new GroupBox();
                grpAddContact.Location = new Point(10, grpEdition.Height + 40);
                grpAddContact.Size = new Size(grpEdition.Width, grpModification.Height - grpEdition.Height - 50);
                grpAddContact.Name = "grpAddContact";
                grpAddContact.Text = "Nouveue contact";
                grpAddContact.Font = new Font(grpAddContact.Font.FontFamily, 16);
                grpModification.Controls.Add(grpAddContact);

                Button btnValider = new Button();
                btnValider.Location = new Point(grpAddContact.Width - 90, grpAddContact.Height - 60);
                btnValider.Size = new Size(50, 50);
                btnValider.AutoSize = true;
                btnValider.Name = "btnValider";
                btnValider.Font = new Font(btnValider.Font.FontFamily, 14);
                btnValider.Text = "Valider";
                grpAddContact.Controls.Add(btnValider);

                Button btnAnnuler = new Button();
                btnAnnuler.Location = new Point(grpAddContact.Width - 90 * 2, grpAddContact.Height - 60);
                btnAnnuler.Size = new Size(50, 50);
                btnAnnuler.AutoSize = true;
                btnAnnuler.Name = "btnAnnuler";
                btnAnnuler.Font = new Font(btnValider.Font.FontFamily, 14);
                btnAnnuler.Text = "Annuler";
                grpAddContact.Controls.Add(btnAnnuler);
            }
        }

        private void buttonEvent_Click(object sender, EventArgs e)
        {
            Control grpModification = Controls["grpModification"];
            Control grpEdition = grpModification.Controls["grpEdition"];

            Control old = grpModification.Controls["grpAddContact"];
            if (old != null)
            {
                grpModification.Controls.Remove(old);
                old.Dispose();
            }

            if (grpModification != null && grpEdition != null)
            {
                GroupBox grpAddContact = new GroupBox();
                grpAddContact.Location = new Point(10, grpEdition.Height + 40);
                grpAddContact.Size = new Size(grpEdition.Width, grpModification.Height - grpEdition.Height - 50);
                grpAddContact.Name = "grpAddContact";
                grpAddContact.Text = "Nouveue contact";
                grpAddContact.Font = new Font(grpAddContact.Font.FontFamily, 16);
                grpModification.Controls.Add(grpAddContact);

                Button btnValider = new Button();
                btnValider.Location = new Point(grpAddContact.Width - 90, grpAddContact.Height - 60);
                btnValider.Size = new Size(50, 50);
                btnValider.AutoSize = true;
                btnValider.Name = "btnValider";
                btnValider.Font = new Font(btnValider.Font.FontFamily, 14);
                btnValider.Text = "Valider";
                grpAddContact.Controls.Add(btnValider);

                Button btnAnnuler = new Button();
                btnAnnuler.Location = new Point(grpAddContact.Width - 90 * 2, grpAddContact.Height - 60);
                btnAnnuler.Size = new Size(50, 50);
                btnAnnuler.AutoSize = true;
                btnAnnuler.Name = "btnAnnuler";
                btnAnnuler.Font = new Font(btnValider.Font.FontFamily, 14);
                btnAnnuler.Text = "Annuler";
                grpAddContact.Controls.Add(btnAnnuler);
            }
        }
    }
}
