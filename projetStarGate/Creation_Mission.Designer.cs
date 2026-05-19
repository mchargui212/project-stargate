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
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblEtape1 = new System.Windows.Forms.Label();
            this.btnValiderPlanete = new System.Windows.Forms.Button();
            this.grpEtape1 = new System.Windows.Forms.GroupBox();
            this.lblNomMission = new System.Windows.Forms.Label();
            this.cboPlanete = new System.Windows.Forms.ComboBox();
            this.lblEtape2 = new System.Windows.Forms.Label();
            this.cboChef = new System.Windows.Forms.ComboBox();
            this.grpEtape2 = new System.Windows.Forms.GroupBox();
            this.btnValiderChef = new System.Windows.Forms.Button();
            this.grpEtape3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnValiderMission = new System.Windows.Forms.Button();
            this.txtFeuille = new System.Windows.Forms.RichTextBox();
            this.txtBudget = new System.Windows.Forms.TextBox();
            this.txtDataBaz = new System.Windows.Forms.TextBox();
            this.txtEquipage = new System.Windows.Forms.TextBox();
            this.dtpRetour = new System.Windows.Forms.DateTimePicker();
            this.lblBudget = new System.Windows.Forms.Label();
            this.lblDataBaz = new System.Windows.Forms.Label();
            this.lblEquipage = new System.Windows.Forms.Label();
            this.lblFeuille = new System.Windows.Forms.Label();
            this.lblRetour = new System.Windows.Forms.Label();
            this.lblDepart = new System.Windows.Forms.Label();
            this.dtpDepart = new System.Windows.Forms.DateTimePicker();
            this.lblEtape3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.grpEtape1.SuspendLayout();
            this.grpEtape2.SuspendLayout();
            this.grpEtape3.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.picLogo.BackgroundImage = global::projetStarGate.Properties.Resources.Logo_Stargate2;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Location = new System.Drawing.Point(254, 12);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(140, 117);
            this.picLogo.TabIndex = 2;
            this.picLogo.TabStop = false;
            // 
            // lblEtape1
            // 
            this.lblEtape1.AutoSize = true;
            this.lblEtape1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtape1.ForeColor = System.Drawing.SystemColors.Info;
            this.lblEtape1.Location = new System.Drawing.Point(34, 39);
            this.lblEtape1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEtape1.Name = "lblEtape1";
            this.lblEtape1.Size = new System.Drawing.Size(157, 16);
            this.lblEtape1.TabIndex = 0;
            this.lblEtape1.Text = "1 - Planête de destination";
            // 
            // btnValiderPlanete
            // 
            this.btnValiderPlanete.BackColor = System.Drawing.Color.Gray;
            this.btnValiderPlanete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnValiderPlanete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValiderPlanete.ForeColor = System.Drawing.SystemColors.Info;
            this.btnValiderPlanete.Location = new System.Drawing.Point(486, 31);
            this.btnValiderPlanete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnValiderPlanete.Name = "btnValiderPlanete";
            this.btnValiderPlanete.Size = new System.Drawing.Size(144, 26);
            this.btnValiderPlanete.TabIndex = 5;
            this.btnValiderPlanete.Text = "Valider le choix";
            this.btnValiderPlanete.UseVisualStyleBackColor = false;
            this.btnValiderPlanete.Click += new System.EventHandler(this.btnValiderPlanete_Click);
            // 
            // grpEtape1
            // 
            this.grpEtape1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.grpEtape1.Controls.Add(this.lblNomMission);
            this.grpEtape1.Controls.Add(this.btnValiderPlanete);
            this.grpEtape1.Controls.Add(this.cboPlanete);
            this.grpEtape1.Controls.Add(this.lblEtape1);
            this.grpEtape1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEtape1.ForeColor = System.Drawing.SystemColors.Info;
            this.grpEtape1.Location = new System.Drawing.Point(-4, 135);
            this.grpEtape1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpEtape1.Name = "grpEtape1";
            this.grpEtape1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpEtape1.Size = new System.Drawing.Size(664, 112);
            this.grpEtape1.TabIndex = 0;
            this.grpEtape1.TabStop = false;
            this.grpEtape1.Text = "Nouvelle mission";
            // 
            // lblNomMission
            // 
            this.lblNomMission.AutoSize = true;
            this.lblNomMission.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomMission.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblNomMission.Location = new System.Drawing.Point(101, 76);
            this.lblNomMission.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomMission.Name = "lblNomMission";
            this.lblNomMission.Size = new System.Drawing.Size(160, 19);
            this.lblNomMission.TabIndex = 6;
            this.lblNomMission.Text = "Nom de la mission :";
            // 
            // cboPlanete
            // 
            this.cboPlanete.BackColor = System.Drawing.SystemColors.Control;
            this.cboPlanete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPlanete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboPlanete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.cboPlanete.FormattingEnabled = true;
            this.cboPlanete.Location = new System.Drawing.Point(226, 36);
            this.cboPlanete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboPlanete.Name = "cboPlanete";
            this.cboPlanete.Size = new System.Drawing.Size(140, 21);
            this.cboPlanete.TabIndex = 3;
            this.cboPlanete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_KeyPress);
            // 
            // lblEtape2
            // 
            this.lblEtape2.AutoSize = true;
            this.lblEtape2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtape2.ForeColor = System.Drawing.SystemColors.Info;
            this.lblEtape2.Location = new System.Drawing.Point(34, 29);
            this.lblEtape2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEtape2.Name = "lblEtape2";
            this.lblEtape2.Size = new System.Drawing.Size(133, 16);
            this.lblEtape2.TabIndex = 1;
            this.lblEtape2.Text = "2 - Chef de la mission";
            // 
            // cboChef
            // 
            this.cboChef.BackColor = System.Drawing.SystemColors.Control;
            this.cboChef.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboChef.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.cboChef.FormattingEnabled = true;
            this.cboChef.Location = new System.Drawing.Point(226, 26);
            this.cboChef.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboChef.Name = "cboChef";
            this.cboChef.Size = new System.Drawing.Size(214, 21);
            this.cboChef.TabIndex = 4;
            this.cboChef.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_KeyPress);
            // 
            // grpEtape2
            // 
            this.grpEtape2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.grpEtape2.Controls.Add(this.btnValiderChef);
            this.grpEtape2.Controls.Add(this.cboChef);
            this.grpEtape2.Controls.Add(this.lblEtape2);
            this.grpEtape2.ForeColor = System.Drawing.SystemColors.Info;
            this.grpEtape2.Location = new System.Drawing.Point(-4, 243);
            this.grpEtape2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpEtape2.Name = "grpEtape2";
            this.grpEtape2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpEtape2.Size = new System.Drawing.Size(664, 65);
            this.grpEtape2.TabIndex = 22;
            this.grpEtape2.TabStop = false;
            // 
            // btnValiderChef
            // 
            this.btnValiderChef.BackColor = System.Drawing.Color.Gray;
            this.btnValiderChef.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnValiderChef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValiderChef.ForeColor = System.Drawing.SystemColors.Info;
            this.btnValiderChef.Location = new System.Drawing.Point(486, 24);
            this.btnValiderChef.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnValiderChef.Name = "btnValiderChef";
            this.btnValiderChef.Size = new System.Drawing.Size(144, 26);
            this.btnValiderChef.TabIndex = 7;
            this.btnValiderChef.Text = "Valider le choix";
            this.btnValiderChef.UseVisualStyleBackColor = false;
            this.btnValiderChef.Click += new System.EventHandler(this.btnValiderChef_Click);
            // 
            // grpEtape3
            // 
            this.grpEtape3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.grpEtape3.Controls.Add(this.label3);
            this.grpEtape3.Controls.Add(this.label2);
            this.grpEtape3.Controls.Add(this.label1);
            this.grpEtape3.Controls.Add(this.btnValiderMission);
            this.grpEtape3.Controls.Add(this.txtFeuille);
            this.grpEtape3.Controls.Add(this.txtBudget);
            this.grpEtape3.Controls.Add(this.txtDataBaz);
            this.grpEtape3.Controls.Add(this.txtEquipage);
            this.grpEtape3.Controls.Add(this.dtpRetour);
            this.grpEtape3.Controls.Add(this.lblBudget);
            this.grpEtape3.Controls.Add(this.lblDataBaz);
            this.grpEtape3.Controls.Add(this.lblEquipage);
            this.grpEtape3.Controls.Add(this.lblFeuille);
            this.grpEtape3.Controls.Add(this.lblRetour);
            this.grpEtape3.Controls.Add(this.lblDepart);
            this.grpEtape3.Controls.Add(this.dtpDepart);
            this.grpEtape3.Controls.Add(this.lblEtape3);
            this.grpEtape3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpEtape3.ForeColor = System.Drawing.SystemColors.Info;
            this.grpEtape3.Location = new System.Drawing.Point(-2, 299);
            this.grpEtape3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpEtape3.Name = "grpEtape3";
            this.grpEtape3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpEtape3.Size = new System.Drawing.Size(657, 334);
            this.grpEtape3.TabIndex = 23;
            this.grpEtape3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(290, 294);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "€";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(290, 264);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "tonnes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(290, 231);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "personnes";
            // 
            // btnValiderMission
            // 
            this.btnValiderMission.BackColor = System.Drawing.Color.Gray;
            this.btnValiderMission.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnValiderMission.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValiderMission.ForeColor = System.Drawing.SystemColors.Info;
            this.btnValiderMission.Location = new System.Drawing.Point(485, 287);
            this.btnValiderMission.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnValiderMission.Name = "btnValiderMission";
            this.btnValiderMission.Size = new System.Drawing.Size(144, 26);
            this.btnValiderMission.TabIndex = 18;
            this.btnValiderMission.Text = "Valider et créer";
            this.btnValiderMission.UseVisualStyleBackColor = false;
            this.btnValiderMission.Click += new System.EventHandler(this.btnValiderMission_Click);
            // 
            // txtFeuille
            // 
            this.txtFeuille.BackColor = System.Drawing.SystemColors.Control;
            this.txtFeuille.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFeuille.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.txtFeuille.Location = new System.Drawing.Point(224, 130);
            this.txtFeuille.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFeuille.Name = "txtFeuille";
            this.txtFeuille.Size = new System.Drawing.Size(405, 78);
            this.txtFeuille.TabIndex = 17;
            this.txtFeuille.Text = "";
            // 
            // txtBudget
            // 
            this.txtBudget.BackColor = System.Drawing.SystemColors.Control;
            this.txtBudget.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBudget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.txtBudget.Location = new System.Drawing.Point(224, 294);
            this.txtBudget.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBudget.Name = "txtBudget";
            this.txtBudget.Size = new System.Drawing.Size(59, 14);
            this.txtBudget.TabIndex = 16;
            this.txtBudget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Infos_KeyPress);
            // 
            // txtDataBaz
            // 
            this.txtDataBaz.BackColor = System.Drawing.SystemColors.Control;
            this.txtDataBaz.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDataBaz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.txtDataBaz.Location = new System.Drawing.Point(224, 261);
            this.txtDataBaz.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDataBaz.Name = "txtDataBaz";
            this.txtDataBaz.Size = new System.Drawing.Size(59, 14);
            this.txtDataBaz.TabIndex = 15;
            this.txtDataBaz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Infos_KeyPress);
            // 
            // txtEquipage
            // 
            this.txtEquipage.BackColor = System.Drawing.SystemColors.Control;
            this.txtEquipage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEquipage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.txtEquipage.Location = new System.Drawing.Point(224, 228);
            this.txtEquipage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEquipage.Name = "txtEquipage";
            this.txtEquipage.Size = new System.Drawing.Size(59, 14);
            this.txtEquipage.TabIndex = 14;
            this.txtEquipage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Infos_KeyPress);
            // 
            // dtpRetour
            // 
            this.dtpRetour.CalendarForeColor = System.Drawing.SystemColors.Info;
            this.dtpRetour.CalendarMonthBackground = System.Drawing.Color.Gray;
            this.dtpRetour.CalendarTitleBackColor = System.Drawing.SystemColors.Info;
            this.dtpRetour.CalendarTitleForeColor = System.Drawing.SystemColors.Info;
            this.dtpRetour.CalendarTrailingForeColor = System.Drawing.SystemColors.Info;
            this.dtpRetour.Format = DateTimePickerFormat.Custom;
            this.dtpRetour.CustomFormat = "yyyy-MM-dd";
            this.dtpRetour.Location = new System.Drawing.Point(224, 94);
            this.dtpRetour.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpRetour.Name = "dtpRetour";
            this.dtpRetour.Size = new System.Drawing.Size(109, 21);
            this.dtpRetour.TabIndex = 13;
            // 
            // lblBudget
            // 
            this.lblBudget.AutoSize = true;
            this.lblBudget.ForeColor = System.Drawing.SystemColors.Info;
            this.lblBudget.Location = new System.Drawing.Point(141, 294);
            this.lblBudget.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBudget.Name = "lblBudget";
            this.lblBudget.Size = new System.Drawing.Size(45, 13);
            this.lblBudget.TabIndex = 12;
            this.lblBudget.Text = "Budget";
            // 
            // lblDataBaz
            // 
            this.lblDataBaz.AutoSize = true;
            this.lblDataBaz.ForeColor = System.Drawing.SystemColors.Info;
            this.lblDataBaz.Location = new System.Drawing.Point(88, 264);
            this.lblDataBaz.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataBaz.Name = "lblDataBaz";
            this.lblDataBaz.Size = new System.Drawing.Size(93, 13);
            this.lblDataBaz.TabIndex = 11;
            this.lblDataBaz.Text = "Objectif DataBaz";
            // 
            // lblEquipage
            // 
            this.lblEquipage.AutoSize = true;
            this.lblEquipage.ForeColor = System.Drawing.SystemColors.Info;
            this.lblEquipage.Location = new System.Drawing.Point(128, 231);
            this.lblEquipage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEquipage.Name = "lblEquipage";
            this.lblEquipage.Size = new System.Drawing.Size(57, 13);
            this.lblEquipage.TabIndex = 10;
            this.lblEquipage.Text = "Equipage";
            // 
            // lblFeuille
            // 
            this.lblFeuille.AutoSize = true;
            this.lblFeuille.ForeColor = System.Drawing.SystemColors.Info;
            this.lblFeuille.Location = new System.Drawing.Point(100, 133);
            this.lblFeuille.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFeuille.Name = "lblFeuille";
            this.lblFeuille.Size = new System.Drawing.Size(87, 13);
            this.lblFeuille.TabIndex = 9;
            this.lblFeuille.Text = "Feuille de route";
            // 
            // lblRetour
            // 
            this.lblRetour.AutoSize = true;
            this.lblRetour.ForeColor = System.Drawing.SystemColors.Info;
            this.lblRetour.Location = new System.Drawing.Point(106, 96);
            this.lblRetour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRetour.Name = "lblRetour";
            this.lblRetour.Size = new System.Drawing.Size(81, 13);
            this.lblRetour.TabIndex = 8;
            this.lblRetour.Text = "Date de retour";
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.ForeColor = System.Drawing.SystemColors.Info;
            this.lblDepart.Location = new System.Drawing.Point(102, 61);
            this.lblDepart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(84, 13);
            this.lblDepart.TabIndex = 7;
            this.lblDepart.Text = "Date de départ";
            // 
            // dtpDepart
            // 
            this.dtpDepart.CalendarForeColor = System.Drawing.SystemColors.Info;
            this.dtpDepart.CalendarMonthBackground = System.Drawing.Color.Gray;
            this.dtpDepart.CalendarTitleBackColor = System.Drawing.SystemColors.Info;
            this.dtpDepart.CalendarTitleForeColor = System.Drawing.SystemColors.Info;
            this.dtpDepart.CalendarTrailingForeColor = System.Drawing.SystemColors.Info;
            this.dtpDepart.Format = DateTimePickerFormat.Custom;
            this.dtpDepart.CustomFormat = "yyyy-MM-dd";
            this.dtpDepart.Location = new System.Drawing.Point(224, 57);
            this.dtpDepart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpDepart.Name = "dtpDepart";
            this.dtpDepart.Size = new System.Drawing.Size(109, 21);
            this.dtpDepart.TabIndex = 6;
            // 
            // lblEtape3
            // 
            this.lblEtape3.AutoSize = true;
            this.lblEtape3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtape3.ForeColor = System.Drawing.SystemColors.Info;
            this.lblEtape3.Location = new System.Drawing.Point(31, 29);
            this.lblEtape3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEtape3.Name = "lblEtape3";
            this.lblEtape3.Size = new System.Drawing.Size(176, 16);
            this.lblEtape3.TabIndex = 2;
            this.lblEtape3.Text = "3 - Paramêtres de la mission";
            // 
            // Creation_Mission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(651, 628);
            this.Controls.Add(this.grpEtape3);
            this.Controls.Add(this.grpEtape2);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.grpEtape1);
            this.Font = new System.Drawing.Font("Rubik", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Creation_Mission";
            this.Text = "Création d\'une nouvelle mission";
            this.Load += new System.EventHandler(this.Creation_Mission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.grpEtape1.ResumeLayout(false);
            this.grpEtape1.PerformLayout();
            this.grpEtape2.ResumeLayout(false);
            this.grpEtape2.PerformLayout();
            this.grpEtape3.ResumeLayout(false);
            this.grpEtape3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblEtape1;
        private System.Windows.Forms.Button btnValiderPlanete;
        private System.Windows.Forms.GroupBox grpEtape1;
        private System.Windows.Forms.Label lblEtape2;
        private System.Windows.Forms.ComboBox cboChef;
        private System.Windows.Forms.GroupBox grpEtape2;
        private System.Windows.Forms.GroupBox grpEtape3;
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
        private System.Windows.Forms.Button btnValiderChef;
    }
}