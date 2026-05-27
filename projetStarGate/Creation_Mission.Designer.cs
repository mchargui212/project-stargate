using System.Windows.Forms;

namespace projetStarGate
{
    partial class Creation_Mission
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEtape1 = new System.Windows.Forms.Label();
            this.btnValiderPlanete = new System.Windows.Forms.Button();
            this.grpEtape1 = new System.Windows.Forms.GroupBox();
            this.lblNomMission = new System.Windows.Forms.Label();
            this.cboPlanete = new System.Windows.Forms.ComboBox();
            this.dtpRetour = new System.Windows.Forms.DateTimePicker();
            this.dtpDepart = new System.Windows.Forms.DateTimePicker();
            this.lblDepart = new System.Windows.Forms.Label();
            this.lblRetour = new System.Windows.Forms.Label();
            this.lblEtape2 = new System.Windows.Forms.Label();
            this.cboChef = new System.Windows.Forms.ComboBox();
            this.grpEtape2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnValiderMission = new System.Windows.Forms.Button();
            this.txtFeuille = new System.Windows.Forms.RichTextBox();
            this.txtBudget = new System.Windows.Forms.TextBox();
            this.txtDataBaz = new System.Windows.Forms.TextBox();
            this.txtEquipage = new System.Windows.Forms.TextBox();
            this.lblBudget = new System.Windows.Forms.Label();
            this.lblDataBaz = new System.Windows.Forms.Label();
            this.lblEquipage = new System.Windows.Forms.Label();
            this.lblFeuille = new System.Windows.Forms.Label();
            this.lblEtape3 = new System.Windows.Forms.Label();
            this.grpEtape3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnModifier = new System.Windows.Forms.Button();
            this.grpEtape1.SuspendLayout();
            this.grpEtape2.SuspendLayout();
            this.grpEtape3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEtape1
            // 
            this.lblEtape1.AutoSize = true;
            this.lblEtape1.Font = new System.Drawing.Font("Rubik", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtape1.ForeColor = System.Drawing.SystemColors.Info;
            this.lblEtape1.Location = new System.Drawing.Point(35, 57);
            this.lblEtape1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEtape1.Name = "lblEtape1";
            this.lblEtape1.Size = new System.Drawing.Size(241, 23);
            this.lblEtape1.TabIndex = 0;
            this.lblEtape1.Text = "1 - Planête de destination";
            // 
            // btnValiderPlanete
            // 
            this.btnValiderPlanete.BackColor = System.Drawing.SystemColors.Info;
            this.btnValiderPlanete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnValiderPlanete.Font = new System.Drawing.Font("Impact", 18F);
            this.btnValiderPlanete.ForeColor = System.Drawing.Color.DimGray;
            this.btnValiderPlanete.Location = new System.Drawing.Point(657, 365);
            this.btnValiderPlanete.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnValiderPlanete.Name = "btnValiderPlanete";
            this.btnValiderPlanete.Size = new System.Drawing.Size(148, 50);
            this.btnValiderPlanete.TabIndex = 5;
            this.btnValiderPlanete.Text = "Suivant";
            this.btnValiderPlanete.UseVisualStyleBackColor = false;
            this.btnValiderPlanete.Click += new System.EventHandler(this.btnValiderPlanete_Click);
            // 
            // grpEtape1
            // 
            this.grpEtape1.BackColor = System.Drawing.Color.Transparent;
            this.grpEtape1.Controls.Add(this.btnModifier);
            this.grpEtape1.Controls.Add(this.lblNomMission);
            this.grpEtape1.Controls.Add(this.cboPlanete);
            this.grpEtape1.Controls.Add(this.lblEtape1);
            this.grpEtape1.Controls.Add(this.dtpRetour);
            this.grpEtape1.Controls.Add(this.dtpDepart);
            this.grpEtape1.Controls.Add(this.lblDepart);
            this.grpEtape1.Controls.Add(this.lblRetour);
            this.grpEtape1.Font = new System.Drawing.Font("Rubik", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEtape1.ForeColor = System.Drawing.SystemColors.Info;
            this.grpEtape1.Location = new System.Drawing.Point(-5, 176);
            this.grpEtape1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpEtape1.Name = "grpEtape1";
            this.grpEtape1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpEtape1.Size = new System.Drawing.Size(847, 294);
            this.grpEtape1.TabIndex = 0;
            this.grpEtape1.TabStop = false;
            this.grpEtape1.Text = "Nouvelle mission";
            // 
            // lblNomMission
            // 
            this.lblNomMission.AutoSize = true;
            this.lblNomMission.Font = new System.Drawing.Font("Rubik", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomMission.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblNomMission.Location = new System.Drawing.Point(117, 108);
            this.lblNomMission.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNomMission.Name = "lblNomMission";
            this.lblNomMission.Size = new System.Drawing.Size(209, 25);
            this.lblNomMission.TabIndex = 6;
            this.lblNomMission.Text = "Nom de la mission :";
            // 
            // cboPlanete
            // 
            this.cboPlanete.BackColor = System.Drawing.SystemColors.Control;
            this.cboPlanete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPlanete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPlanete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.cboPlanete.FormattingEnabled = true;
            this.cboPlanete.Location = new System.Drawing.Point(305, 56);
            this.cboPlanete.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboPlanete.Name = "cboPlanete";
            this.cboPlanete.Size = new System.Drawing.Size(172, 28);
            this.cboPlanete.TabIndex = 3;
            this.cboPlanete.SelectedIndexChanged += new System.EventHandler(this.cboPlanete_SelectedIndexChanged);
            this.cboPlanete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_KeyPress);
            // 
            // dtpRetour
            // 
            this.dtpRetour.CalendarFont = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRetour.CalendarForeColor = System.Drawing.SystemColors.Info;
            this.dtpRetour.CalendarMonthBackground = System.Drawing.Color.Gray;
            this.dtpRetour.CalendarTitleBackColor = System.Drawing.SystemColors.Info;
            this.dtpRetour.CalendarTitleForeColor = System.Drawing.SystemColors.Info;
            this.dtpRetour.CalendarTrailingForeColor = System.Drawing.SystemColors.Info;
            this.dtpRetour.CustomFormat = "yyyy-MM-dd";
            this.dtpRetour.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRetour.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRetour.Location = new System.Drawing.Point(187, 212);
            this.dtpRetour.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtpRetour.Name = "dtpRetour";
            this.dtpRetour.Size = new System.Drawing.Size(139, 26);
            this.dtpRetour.TabIndex = 13;
            // 
            // dtpDepart
            // 
            this.dtpDepart.CalendarFont = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDepart.CalendarForeColor = System.Drawing.SystemColors.Info;
            this.dtpDepart.CalendarMonthBackground = System.Drawing.Color.Gray;
            this.dtpDepart.CalendarTitleBackColor = System.Drawing.SystemColors.Info;
            this.dtpDepart.CalendarTitleForeColor = System.Drawing.SystemColors.Info;
            this.dtpDepart.CalendarTrailingForeColor = System.Drawing.SystemColors.Info;
            this.dtpDepart.CustomFormat = "yyyy-MM-dd";
            this.dtpDepart.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDepart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDepart.Location = new System.Drawing.Point(188, 157);
            this.dtpDepart.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtpDepart.Name = "dtpDepart";
            this.dtpDepart.Size = new System.Drawing.Size(139, 26);
            this.dtpDepart.TabIndex = 6;
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepart.ForeColor = System.Drawing.SystemColors.Info;
            this.lblDepart.Location = new System.Drawing.Point(57, 163);
            this.lblDepart.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(121, 19);
            this.lblDepart.TabIndex = 7;
            this.lblDepart.Text = "Date de départ";
            // 
            // lblRetour
            // 
            this.lblRetour.AutoSize = true;
            this.lblRetour.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetour.ForeColor = System.Drawing.SystemColors.Info;
            this.lblRetour.Location = new System.Drawing.Point(56, 218);
            this.lblRetour.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRetour.Name = "lblRetour";
            this.lblRetour.Size = new System.Drawing.Size(117, 19);
            this.lblRetour.TabIndex = 8;
            this.lblRetour.Text = "Date de retour";
            // 
            // lblEtape2
            // 
            this.lblEtape2.AutoSize = true;
            this.lblEtape2.Font = new System.Drawing.Font("Rubik", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtape2.ForeColor = System.Drawing.SystemColors.Info;
            this.lblEtape2.Location = new System.Drawing.Point(32, 50);
            this.lblEtape2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEtape2.Name = "lblEtape2";
            this.lblEtape2.Size = new System.Drawing.Size(205, 23);
            this.lblEtape2.TabIndex = 1;
            this.lblEtape2.Text = "2 - Chef de la mission";
            // 
            // cboChef
            // 
            this.cboChef.BackColor = System.Drawing.SystemColors.Control;
            this.cboChef.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboChef.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.cboChef.FormattingEnabled = true;
            this.cboChef.Location = new System.Drawing.Point(302, 46);
            this.cboChef.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboChef.Name = "cboChef";
            this.cboChef.Size = new System.Drawing.Size(274, 27);
            this.cboChef.TabIndex = 4;
            this.cboChef.SelectedIndexChanged += new System.EventHandler(this.cboChef_SelectedIndexChanged);
            this.cboChef.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_KeyPress);
            // 
            // grpEtape2
            // 
            this.grpEtape2.BackColor = System.Drawing.Color.Transparent;
            this.grpEtape2.Controls.Add(this.cboChef);
            this.grpEtape2.Controls.Add(this.label3);
            this.grpEtape2.Controls.Add(this.lblEtape2);
            this.grpEtape2.Controls.Add(this.label2);
            this.grpEtape2.Controls.Add(this.label1);
            this.grpEtape2.Controls.Add(this.btnValiderMission);
            this.grpEtape2.Controls.Add(this.txtFeuille);
            this.grpEtape2.Controls.Add(this.txtBudget);
            this.grpEtape2.Controls.Add(this.txtDataBaz);
            this.grpEtape2.Controls.Add(this.txtEquipage);
            this.grpEtape2.Controls.Add(this.lblBudget);
            this.grpEtape2.Controls.Add(this.lblDataBaz);
            this.grpEtape2.Controls.Add(this.lblEquipage);
            this.grpEtape2.Controls.Add(this.lblFeuille);
            this.grpEtape2.Controls.Add(this.lblEtape3);
            this.grpEtape2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpEtape2.ForeColor = System.Drawing.SystemColors.Info;
            this.grpEtape2.Location = new System.Drawing.Point(-2, 432);
            this.grpEtape2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpEtape2.Name = "grpEtape2";
            this.grpEtape2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpEtape2.Size = new System.Drawing.Size(844, 536);
            this.grpEtape2.TabIndex = 23;
            this.grpEtape2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(251, 472);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 19);
            this.label3.TabIndex = 21;
            this.label3.Text = "€";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(251, 431);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 20;
            this.label2.Text = "tonnes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(251, 391);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "personnes";
            // 
            // btnValiderMission
            // 
            this.btnValiderMission.BackColor = System.Drawing.SystemColors.Info;
            this.btnValiderMission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValiderMission.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValiderMission.ForeColor = System.Drawing.Color.DimGray;
            this.btnValiderMission.Location = new System.Drawing.Point(659, 441);
            this.btnValiderMission.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnValiderMission.Name = "btnValiderMission";
            this.btnValiderMission.Size = new System.Drawing.Size(148, 50);
            this.btnValiderMission.TabIndex = 18;
            this.btnValiderMission.Text = "Valider";
            this.btnValiderMission.UseVisualStyleBackColor = false;
            this.btnValiderMission.Click += new System.EventHandler(this.btnValiderMission_Click);
            // 
            // txtFeuille
            // 
            this.txtFeuille.BackColor = System.Drawing.SystemColors.Control;
            this.txtFeuille.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFeuille.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFeuille.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.txtFeuille.Location = new System.Drawing.Point(167, 205);
            this.txtFeuille.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtFeuille.Name = "txtFeuille";
            this.txtFeuille.Size = new System.Drawing.Size(640, 163);
            this.txtFeuille.TabIndex = 17;
            this.txtFeuille.Text = "";
            // 
            // txtBudget
            // 
            this.txtBudget.BackColor = System.Drawing.SystemColors.Control;
            this.txtBudget.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBudget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.txtBudget.Location = new System.Drawing.Point(165, 471);
            this.txtBudget.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtBudget.Name = "txtBudget";
            this.txtBudget.Size = new System.Drawing.Size(76, 19);
            this.txtBudget.TabIndex = 16;
            this.txtBudget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Infos_KeyPress);
            // 
            // txtDataBaz
            // 
            this.txtDataBaz.BackColor = System.Drawing.SystemColors.Control;
            this.txtDataBaz.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDataBaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataBaz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.txtDataBaz.Location = new System.Drawing.Point(165, 430);
            this.txtDataBaz.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDataBaz.Name = "txtDataBaz";
            this.txtDataBaz.Size = new System.Drawing.Size(76, 19);
            this.txtDataBaz.TabIndex = 15;
            this.txtDataBaz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Infos_KeyPress);
            // 
            // txtEquipage
            // 
            this.txtEquipage.BackColor = System.Drawing.SystemColors.Control;
            this.txtEquipage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEquipage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.txtEquipage.Location = new System.Drawing.Point(165, 390);
            this.txtEquipage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtEquipage.Name = "txtEquipage";
            this.txtEquipage.Size = new System.Drawing.Size(76, 19);
            this.txtEquipage.TabIndex = 14;
            this.txtEquipage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Infos_KeyPress);
            // 
            // lblBudget
            // 
            this.lblBudget.AutoSize = true;
            this.lblBudget.ForeColor = System.Drawing.SystemColors.Info;
            this.lblBudget.Location = new System.Drawing.Point(84, 472);
            this.lblBudget.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBudget.Name = "lblBudget";
            this.lblBudget.Size = new System.Drawing.Size(65, 19);
            this.lblBudget.TabIndex = 12;
            this.lblBudget.Text = "Budget";
            // 
            // lblDataBaz
            // 
            this.lblDataBaz.AutoSize = true;
            this.lblDataBaz.ForeColor = System.Drawing.SystemColors.Info;
            this.lblDataBaz.Location = new System.Drawing.Point(14, 430);
            this.lblDataBaz.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDataBaz.Name = "lblDataBaz";
            this.lblDataBaz.Size = new System.Drawing.Size(135, 19);
            this.lblDataBaz.TabIndex = 11;
            this.lblDataBaz.Text = "Objectif DataBaz";
            // 
            // lblEquipage
            // 
            this.lblEquipage.AutoSize = true;
            this.lblEquipage.ForeColor = System.Drawing.SystemColors.Info;
            this.lblEquipage.Location = new System.Drawing.Point(77, 390);
            this.lblEquipage.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEquipage.Name = "lblEquipage";
            this.lblEquipage.Size = new System.Drawing.Size(80, 19);
            this.lblEquipage.TabIndex = 10;
            this.lblEquipage.Text = "Equipage";
            // 
            // lblFeuille
            // 
            this.lblFeuille.AutoSize = true;
            this.lblFeuille.ForeColor = System.Drawing.SystemColors.Info;
            this.lblFeuille.Location = new System.Drawing.Point(32, 206);
            this.lblFeuille.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFeuille.Name = "lblFeuille";
            this.lblFeuille.Size = new System.Drawing.Size(125, 19);
            this.lblFeuille.TabIndex = 9;
            this.lblFeuille.Text = "Feuille de route";
            // 
            // lblEtape3
            // 
            this.lblEtape3.AutoSize = true;
            this.lblEtape3.Font = new System.Drawing.Font("Rubik", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtape3.ForeColor = System.Drawing.SystemColors.Info;
            this.lblEtape3.Location = new System.Drawing.Point(32, 118);
            this.lblEtape3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEtape3.Name = "lblEtape3";
            this.lblEtape3.Size = new System.Drawing.Size(265, 23);
            this.lblEtape3.TabIndex = 2;
            this.lblEtape3.Text = "3 - Paramêtres de la mission";
            // 
            // grpEtape3
            // 
            this.grpEtape3.BackColor = System.Drawing.Color.Transparent;
            this.grpEtape3.Controls.Add(this.flowLayoutPanel1);
            this.grpEtape3.Controls.Add(this.flowLayoutPanel2);
            this.grpEtape3.Controls.Add(this.btnSupprimer);
            this.grpEtape3.Controls.Add(this.button4);
            this.grpEtape3.Controls.Add(this.button2);
            this.grpEtape3.Controls.Add(this.comboBox2);
            this.grpEtape3.Controls.Add(this.label4);
            this.grpEtape3.Controls.Add(this.button1);
            this.grpEtape3.Controls.Add(this.comboBox1);
            this.grpEtape3.Controls.Add(this.label13);
            this.grpEtape3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpEtape3.ForeColor = System.Drawing.SystemColors.Info;
            this.grpEtape3.Location = new System.Drawing.Point(841, 181);
            this.grpEtape3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpEtape3.Name = "grpEtape3";
            this.grpEtape3.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpEtape3.Size = new System.Drawing.Size(844, 770);
            this.grpEtape3.TabIndex = 25;
            this.grpEtape3.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(44, 127);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(740, 180);
            this.flowLayoutPanel1.TabIndex = 29;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(44, 500);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(740, 180);
            this.flowLayoutPanel2.TabIndex = 28;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.Gray;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSupprimer.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.ForeColor = System.Drawing.SystemColors.Info;
            this.btnSupprimer.Location = new System.Drawing.Point(673, 323);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(111, 38);
            this.btnSupprimer.TabIndex = 7;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Info;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.DimGray;
            this.button4.Location = new System.Drawing.Point(636, 691);
            this.button4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(148, 50);
            this.button4.TabIndex = 26;
            this.button4.Text = "Valider";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Rubik", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Info;
            this.button2.Location = new System.Drawing.Point(673, 451);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 38);
            this.button2.TabIndex = 25;
            this.button2.Text = "Ajouter";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(124, 454);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(274, 27);
            this.comboBox2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rubik", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(40, 399);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 23);
            this.label4.TabIndex = 23;
            this.label4.Text = "5 - Objectifs de capture";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Rubik", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Info;
            this.button1.Location = new System.Drawing.Point(673, 81);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 38);
            this.button1.TabIndex = 9;
            this.button1.Text = "Ajouter";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(124, 90);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(461, 27);
            this.comboBox1.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Rubik", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.Info;
            this.label13.Location = new System.Drawing.Point(40, 42);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(269, 23);
            this.label13.TabIndex = 2;
            this.label13.Text = "4 - Affectation des membres";
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.Gray;
            this.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModifier.Font = new System.Drawing.Font("Rubik", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.ForeColor = System.Drawing.SystemColors.Info;
            this.btnModifier.Location = new System.Drawing.Point(699, 49);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(111, 37);
            this.btnModifier.TabIndex = 30;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            // 
            // Creation_Mission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.BackgroundImage = global::projetStarGate.Properties.Resources.Logo_Stargate2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1682, 946);
            this.Controls.Add(this.grpEtape3);
            this.Controls.Add(this.btnValiderPlanete);
            this.Controls.Add(this.grpEtape2);
            this.Controls.Add(this.grpEtape1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Creation_Mission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Création d\'une nouvelle mission";
            this.Load += new System.EventHandler(this.Creation_Mission_Load);
            this.grpEtape1.ResumeLayout(false);
            this.grpEtape1.PerformLayout();
            this.grpEtape2.ResumeLayout(false);
            this.grpEtape2.PerformLayout();
            this.grpEtape3.ResumeLayout(false);
            this.grpEtape3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblEtape1;
        private System.Windows.Forms.Button btnValiderPlanete;
        private System.Windows.Forms.GroupBox grpEtape1;
        private System.Windows.Forms.Label lblEtape2;
        private System.Windows.Forms.ComboBox cboChef;
        private System.Windows.Forms.GroupBox grpEtape2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnValiderMission;
        private System.Windows.Forms.RichTextBox txtFeuille;
        private System.Windows.Forms.TextBox txtBudget;
        private System.Windows.Forms.TextBox txtDataBaz;
        private System.Windows.Forms.TextBox txtEquipage;
        private System.Windows.Forms.DateTimePicker dtpRetour;
        private System.Windows.Forms.Label lblBudget;
        private System.Windows.Forms.Label lblDataBaz;
        private System.Windows.Forms.Label lblEquipage;
        private System.Windows.Forms.Label lblFeuille;
        private System.Windows.Forms.Label lblRetour;
        private System.Windows.Forms.Label lblDepart;
        private System.Windows.Forms.DateTimePicker dtpDepart;
        private System.Windows.Forms.Label lblEtape3;
        private System.Windows.Forms.ComboBox cboPlanete;
        private System.Windows.Forms.Label lblNomMission;
        private GroupBox grpEtape3;
        private Label label13;
        private ComboBox comboBox1;
        private Button button1;
        private Label label4;
        private Button btnSupprimer;
        private Button button4;
        private Button button2;
        private ComboBox comboBox2;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnModifier;
    }
}