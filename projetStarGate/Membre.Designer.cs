namespace projetStarGate
{
    partial class Membre
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBadge = new System.Windows.Forms.Label();
            this.lblMetier = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBadge
            // 
            this.lblBadge.AutoSize = true;
            this.lblBadge.BackColor = System.Drawing.Color.Transparent;
            this.lblBadge.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBadge.Location = new System.Drawing.Point(114, 0);
            this.lblBadge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBadge.Name = "lblBadge";
            this.lblBadge.Size = new System.Drawing.Size(0, 42);
            this.lblBadge.TabIndex = 16;
            // 
            // lblMetier
            // 
            this.lblMetier.AutoSize = true;
            this.lblMetier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetier.Location = new System.Drawing.Point(4, 203);
            this.lblMetier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMetier.Name = "lblMetier";
            this.lblMetier.Size = new System.Drawing.Size(68, 20);
            this.lblMetier.TabIndex = 15;
            this.lblMetier.Text = "lblMetier";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.Location = new System.Drawing.Point(4, 179);
            this.lblNom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(57, 20);
            this.lblNom.TabIndex = 14;
            this.lblNom.Text = "lblNom";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Membre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblBadge);
            this.Controls.Add(this.lblMetier);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Membre";
            this.Size = new System.Drawing.Size(161, 225);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBadge;
        private System.Windows.Forms.Label lblMetier;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
