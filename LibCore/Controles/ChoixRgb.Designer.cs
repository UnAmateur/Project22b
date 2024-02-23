namespace LibCore.Controles
{
    partial class ChoixRgb
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
            this.graphGradient1 = new LibCore.Controles.Graphiques.GraphGradient();
            this.graphRgb1 = new LibCore.Controles.Graphiques.GraphRgb();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // graphGradient1
            // 
            this.graphGradient1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.graphGradient1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphGradient1.Couleur = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.graphGradient1.CouleurMax = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.graphGradient1.CouleurMin = System.Drawing.Color.Blue;
            this.graphGradient1.Curseur = LibCore.TypeCurseur.None;
            this.graphGradient1.DefaultTaille = new System.Drawing.SizeF(10F, 10F);
            this.graphGradient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.graphGradient1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.graphGradient1.Location = new System.Drawing.Point(274, 4);
            this.graphGradient1.Marge = 2F;
            this.graphGradient1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphGradient1.MaxX = 255F;
            this.graphGradient1.MaxY = 255F;
            this.graphGradient1.MinX = 0F;
            this.graphGradient1.MinY = 0F;
            this.graphGradient1.Name = "graphGradient1";
            this.graphGradient1.NameTheme = "Default";
            this.graphGradient1.Sens = LibCore.TypeSens.Verticale;
            this.graphGradient1.Size = new System.Drawing.Size(26, 299);
            this.graphGradient1.TabIndex = 0;
            this.graphGradient1.ValeurX = 127.5F;
            this.graphGradient1.ValeurY = 127.5F;
            // 
            // graphRgb1
            // 
            this.graphRgb1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.graphRgb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphRgb1.Couleur = System.Drawing.Color.White;
            this.graphRgb1.Curseur = LibCore.TypeCurseur.Carre;
            this.graphRgb1.DefaultTaille = new System.Drawing.SizeF(10F, 10F);
            this.graphRgb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.graphRgb1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.graphRgb1.Location = new System.Drawing.Point(4, 4);
            this.graphRgb1.Marge = 2F;
            this.graphRgb1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphRgb1.MaxX = 255F;
            this.graphRgb1.MaxY = 255F;
            this.graphRgb1.MinX = 0F;
            this.graphRgb1.MinY = 0F;
            this.graphRgb1.Name = "graphRgb1";
            this.graphRgb1.NameTheme = "Default";
            this.graphRgb1.Sens = LibCore.TypeSens.None;
            this.graphRgb1.Size = new System.Drawing.Size(263, 263);
            this.graphRgb1.TabIndex = 1;
            this.graphRgb1.ValeurX = 127.5F;
            this.graphRgb1.ValeurY = 127.5F;
            this.graphRgb1.ValeurZ = 128F;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(5, 274);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(173, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Location = new System.Drawing.Point(184, 274);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(83, 25);
            this.panel1.TabIndex = 3;
            // 
            // ChoixRgb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.graphRgb1);
            this.Controls.Add(this.graphGradient1);
            this.Name = "ChoixRgb";
            this.Size = new System.Drawing.Size(304, 307);
            this.ResumeLayout(false);

        }

        #endregion

        private Graphiques.GraphGradient graphGradient1;
        private Graphiques.GraphRgb graphRgb1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}
