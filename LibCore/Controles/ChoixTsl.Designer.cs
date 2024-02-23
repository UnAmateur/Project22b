using LibCore.Controles.Graphiques;

namespace LibCore.Controles
{
    partial class ChoixTsl
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
            this.graphGradientLum = new LibCore.Controles.Graphiques.GraphGradient();
            this.graphGradientSat = new LibCore.Controles.Graphiques.GraphGradient();
            this.graphTsl1 = new LibCore.Controles.Graphiques.GraphTsl();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // graphGradientLum
            // 
            this.graphGradientLum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.graphGradientLum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphGradientLum.Couleur = System.Drawing.Color.White;
            this.graphGradientLum.CouleurMax = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.graphGradientLum.CouleurMin = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.graphGradientLum.Curseur = LibCore.TypeCurseur.Carre;
            this.graphGradientLum.DefaultTaille = new System.Drawing.SizeF(10F, 10F);
            this.graphGradientLum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.graphGradientLum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.graphGradientLum.Location = new System.Drawing.Point(4, 59);
            this.graphGradientLum.Marge = 2F;
            this.graphGradientLum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphGradientLum.MaxX = 100F;
            this.graphGradientLum.MaxY = 100F;
            this.graphGradientLum.MinX = 0F;
            this.graphGradientLum.MinY = 0F;
            this.graphGradientLum.Name = "graphGradientLum";
            this.graphGradientLum.NameTheme = "Default";
            this.graphGradientLum.Sens = LibCore.TypeSens.Horizontale;
            this.graphGradientLum.Size = new System.Drawing.Size(365, 16);
            this.graphGradientLum.TabIndex = 0;
            this.graphGradientLum.ValeurX = 50F;
            this.graphGradientLum.ValeurY = 50F;
            // 
            // graphGradientSat
            // 
            this.graphGradientSat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.graphGradientSat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphGradientSat.Couleur = System.Drawing.Color.Black;
            this.graphGradientSat.CouleurMax = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.graphGradientSat.CouleurMin = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.graphGradientSat.Curseur = LibCore.TypeCurseur.Carre;
            this.graphGradientSat.DefaultTaille = new System.Drawing.SizeF(10F, 10F);
            this.graphGradientSat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.graphGradientSat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.graphGradientSat.Location = new System.Drawing.Point(4, 35);
            this.graphGradientSat.Marge = 2F;
            this.graphGradientSat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphGradientSat.MaxX = 100F;
            this.graphGradientSat.MaxY = 100F;
            this.graphGradientSat.MinX = 0F;
            this.graphGradientSat.MinY = 0F;
            this.graphGradientSat.Name = "graphGradientSat";
            this.graphGradientSat.NameTheme = "Default";
            this.graphGradientSat.Sens = LibCore.TypeSens.Horizontale;
            this.graphGradientSat.Size = new System.Drawing.Size(365, 16);
            this.graphGradientSat.TabIndex = 0;
            this.graphGradientSat.ValeurX = 50F;
            this.graphGradientSat.ValeurY = 50F;
            // 
            // graphTsl1
            // 
            this.graphTsl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.graphTsl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphTsl1.Couleur = System.Drawing.Color.White;
            this.graphTsl1.Curseur = LibCore.TypeCurseur.Carre;
            this.graphTsl1.DefaultTaille = new System.Drawing.SizeF(10F, 10F);
            this.graphTsl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.graphTsl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.graphTsl1.Location = new System.Drawing.Point(4, 7);
            this.graphTsl1.Marge = 2F;
            this.graphTsl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphTsl1.MaxX = 360F;
            this.graphTsl1.MaxY = 100F;
            this.graphTsl1.MinX = 0F;
            this.graphTsl1.MinY = 0F;
            this.graphTsl1.Name = "graphTsl1";
            this.graphTsl1.NameTheme = "Default";
            this.graphTsl1.Sens = LibCore.TypeSens.Horizontale;
            this.graphTsl1.Size = new System.Drawing.Size(367, 22);
            this.graphTsl1.TabIndex = 1;
            this.graphTsl1.ValeurX = 180F;
            this.graphTsl1.ValeurY = 50F;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(4, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(273, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(98, 25);
            this.panel1.TabIndex = 3;
            // 
            // ChoixTsl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.graphTsl1);
            this.Controls.Add(this.graphGradientLum);
            this.Controls.Add(this.graphGradientSat);
            this.Name = "ChoixTsl";
            this.Size = new System.Drawing.Size(375, 111);
            this.ResumeLayout(false);

        }

        #endregion

        private GraphGradient graphGradientSat;
        private GraphGradient graphGradientLum;
        private GraphTsl graphTsl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}
