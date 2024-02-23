using LibCore.Controles;

namespace LibCore.Formulaires
{
    partial class ChoixCouleurs
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
            this.choixRgb1 = new LibCore.Controles.ChoixRgb();
            this.choixTsl1 = new LibCore.Controles.ChoixTsl();
            this.choixCmjk1 = new LibCore.Controles.ChoixCmjk();
            this.buttonAnnule = new System.Windows.Forms.Button();
            this.buttonValide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // choixRgb1
            // 
            this.choixRgb1.AutoSize = true;
            this.choixRgb1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.choixRgb1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.choixRgb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.choixRgb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.choixRgb1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.choixRgb1.Location = new System.Drawing.Point(4, 4);
            this.choixRgb1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.choixRgb1.Name = "choixRgb1";
            this.choixRgb1.NameTheme = "Default";
            this.choixRgb1.Size = new System.Drawing.Size(306, 309);
            this.choixRgb1.TabIndex = 0;
            // 
            // choixTsl1
            // 
            this.choixTsl1.AutoSize = true;
            this.choixTsl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.choixTsl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.choixTsl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.choixTsl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.choixTsl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.choixTsl1.Location = new System.Drawing.Point(318, 4);
            this.choixTsl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.choixTsl1.Name = "choixTsl1";
            this.choixTsl1.NameTheme = "Default";
            this.choixTsl1.Size = new System.Drawing.Size(377, 113);
            this.choixTsl1.TabIndex = 3;
            // 
            // choixCmjk1
            // 
            this.choixCmjk1.AutoSize = true;
            this.choixCmjk1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.choixCmjk1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.choixCmjk1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.choixCmjk1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.choixCmjk1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.choixCmjk1.Location = new System.Drawing.Point(318, 125);
            this.choixCmjk1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.choixCmjk1.Name = "choixCmjk1";
            this.choixCmjk1.NameTheme = "Default";
            this.choixCmjk1.Size = new System.Drawing.Size(377, 146);
            this.choixCmjk1.TabIndex = 4;
            // 
            // buttonAnnule
            // 
            this.buttonAnnule.AutoSize = true;
            this.buttonAnnule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonAnnule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAnnule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonAnnule.Location = new System.Drawing.Point(499, 286);
            this.buttonAnnule.Name = "buttonAnnule";
            this.buttonAnnule.Size = new System.Drawing.Size(95, 27);
            this.buttonAnnule.TabIndex = 5;
            this.buttonAnnule.Text = "button1";
            this.buttonAnnule.UseVisualStyleBackColor = false;
            this.buttonAnnule.Click += new System.EventHandler(this.ButtonAnnule_Click);
            // 
            // buttonValide
            // 
            this.buttonValide.AutoSize = true;
            this.buttonValide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonValide.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonValide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonValide.Location = new System.Drawing.Point(600, 286);
            this.buttonValide.Name = "buttonValide";
            this.buttonValide.Size = new System.Drawing.Size(95, 27);
            this.buttonValide.TabIndex = 5;
            this.buttonValide.Text = "button1";
            this.buttonValide.UseVisualStyleBackColor = false;
            this.buttonValide.Click += new System.EventHandler(this.ButtonValide_Click);
            // 
            // ChoixCouleurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1019, 478);
            this.Controls.Add(this.buttonValide);
            this.Controls.Add(this.buttonAnnule);
            this.Controls.Add(this.choixCmjk1);
            this.Controls.Add(this.choixTsl1);
            this.Controls.Add(this.choixRgb1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChoixCouleurs";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChoixRgb choixRgb1;
        private ChoixTsl choixTsl1;
        private ChoixCmjk choixCmjk1;
        private System.Windows.Forms.Button buttonAnnule;
        private System.Windows.Forms.Button buttonValide;
    }
}
