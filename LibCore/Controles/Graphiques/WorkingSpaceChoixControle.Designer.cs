namespace LibCore.Controles.Graphiques
{
    partial class WorkingSpaceChoixControle
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
            this.graphCourbe1 = new LibCore.Controles.Graphiques.GraphCourbe();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelRougeV = new System.Windows.Forms.Label();
            this.labelRougeT = new System.Windows.Forms.Label();
            this.labelVertT = new System.Windows.Forms.Label();
            this.labelBleuT = new System.Windows.Forms.Label();
            this.labelVertV = new System.Windows.Forms.Label();
            this.labelBleuV = new System.Windows.Forms.Label();
            this.panelRouge = new System.Windows.Forms.Panel();
            this.panelVert = new System.Windows.Forms.Panel();
            this.panelBleu = new System.Windows.Forms.Panel();
            this.labelBlancV = new System.Windows.Forms.Label();
            this.labelBlancT = new System.Windows.Forms.Label();
            this.panelBlanc = new System.Windows.Forms.Panel();
            this.labelGammaV = new System.Windows.Forms.Label();
            this.labelGammaT = new System.Windows.Forms.Label();
            this.labelRef = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // graphCourbe1
            // 
            this.graphCourbe1.AxeX = false;
            this.graphCourbe1.AxeY = false;
            this.graphCourbe1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.graphCourbe1.Cadre = false;
            this.graphCourbe1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.graphCourbe1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.graphCourbe1.Format = "N0";
            this.graphCourbe1.Location = new System.Drawing.Point(14, 44);
            this.graphCourbe1.Marge = 0F;
            this.graphCourbe1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphCourbe1.MaxX = 100F;
            this.graphCourbe1.MaxY = 100F;
            this.graphCourbe1.MinX = 0F;
            this.graphCourbe1.MinY = 0F;
            this.graphCourbe1.Name = "graphCourbe1";
            this.graphCourbe1.NameTheme = "Default";
            this.graphCourbe1.PositionX = LibCore.TypePosition.Bas;
            this.graphCourbe1.PositionY = LibCore.TypePosition.Gauche;
            this.graphCourbe1.PrimaireX = true;
            this.graphCourbe1.PrimaireY = true;
            this.graphCourbe1.SecondaireX = true;
            this.graphCourbe1.SecondaireY = true;
            this.graphCourbe1.Size = new System.Drawing.Size(300, 300);
            this.graphCourbe1.TabIndex = 0;
            this.graphCourbe1.TertiaireX = true;
            this.graphCourbe1.TertiaireY = true;
            this.graphCourbe1.TexteX = false;
            this.graphCourbe1.TexteY = false;
            this.graphCourbe1.Theme = LibCore.TypeGraphTheme.WorkingSpace;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // labelRougeV
            // 
            this.labelRougeV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelRougeV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelRougeV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelRougeV.Location = new System.Drawing.Point(104, 351);
            this.labelRougeV.Margin = new System.Windows.Forms.Padding(3);
            this.labelRougeV.Name = "labelRougeV";
            this.labelRougeV.Size = new System.Drawing.Size(238, 22);
            this.labelRougeV.TabIndex = 2;
            this.labelRougeV.Text = "label1";
            this.labelRougeV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRougeT
            // 
            this.labelRougeT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelRougeT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelRougeT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelRougeT.Location = new System.Drawing.Point(13, 351);
            this.labelRougeT.Margin = new System.Windows.Forms.Padding(3);
            this.labelRougeT.Name = "labelRougeT";
            this.labelRougeT.Size = new System.Drawing.Size(85, 22);
            this.labelRougeT.TabIndex = 2;
            this.labelRougeT.Text = "label1";
            this.labelRougeT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVertT
            // 
            this.labelVertT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelVertT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelVertT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelVertT.Location = new System.Drawing.Point(13, 379);
            this.labelVertT.Margin = new System.Windows.Forms.Padding(3);
            this.labelVertT.Name = "labelVertT";
            this.labelVertT.Size = new System.Drawing.Size(85, 22);
            this.labelVertT.TabIndex = 2;
            this.labelVertT.Text = "label1";
            this.labelVertT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBleuT
            // 
            this.labelBleuT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelBleuT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelBleuT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelBleuT.Location = new System.Drawing.Point(13, 407);
            this.labelBleuT.Margin = new System.Windows.Forms.Padding(3);
            this.labelBleuT.Name = "labelBleuT";
            this.labelBleuT.Size = new System.Drawing.Size(85, 22);
            this.labelBleuT.TabIndex = 2;
            this.labelBleuT.Text = "label1";
            this.labelBleuT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVertV
            // 
            this.labelVertV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelVertV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelVertV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelVertV.Location = new System.Drawing.Point(104, 379);
            this.labelVertV.Margin = new System.Windows.Forms.Padding(3);
            this.labelVertV.Name = "labelVertV";
            this.labelVertV.Size = new System.Drawing.Size(238, 22);
            this.labelVertV.TabIndex = 2;
            this.labelVertV.Text = "label1";
            this.labelVertV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBleuV
            // 
            this.labelBleuV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelBleuV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelBleuV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelBleuV.Location = new System.Drawing.Point(104, 407);
            this.labelBleuV.Margin = new System.Windows.Forms.Padding(3);
            this.labelBleuV.Name = "labelBleuV";
            this.labelBleuV.Size = new System.Drawing.Size(238, 22);
            this.labelBleuV.TabIndex = 2;
            this.labelBleuV.Text = "label1";
            this.labelBleuV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelRouge
            // 
            this.panelRouge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panelRouge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panelRouge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelRouge.Location = new System.Drawing.Point(319, 44);
            this.panelRouge.Name = "panelRouge";
            this.panelRouge.Size = new System.Drawing.Size(23, 71);
            this.panelRouge.TabIndex = 3;
            // 
            // panelVert
            // 
            this.panelVert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panelVert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panelVert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelVert.Location = new System.Drawing.Point(319, 121);
            this.panelVert.Name = "panelVert";
            this.panelVert.Size = new System.Drawing.Size(23, 71);
            this.panelVert.TabIndex = 3;
            // 
            // panelBleu
            // 
            this.panelBleu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panelBleu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panelBleu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelBleu.Location = new System.Drawing.Point(319, 198);
            this.panelBleu.Name = "panelBleu";
            this.panelBleu.Size = new System.Drawing.Size(23, 71);
            this.panelBleu.TabIndex = 3;
            // 
            // labelBlancV
            // 
            this.labelBlancV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelBlancV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelBlancV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelBlancV.Location = new System.Drawing.Point(104, 435);
            this.labelBlancV.Margin = new System.Windows.Forms.Padding(3);
            this.labelBlancV.Name = "labelBlancV";
            this.labelBlancV.Size = new System.Drawing.Size(238, 46);
            this.labelBlancV.TabIndex = 2;
            this.labelBlancV.Text = "label1";
            this.labelBlancV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBlancT
            // 
            this.labelBlancT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelBlancT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelBlancT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelBlancT.Location = new System.Drawing.Point(13, 435);
            this.labelBlancT.Margin = new System.Windows.Forms.Padding(3);
            this.labelBlancT.Name = "labelBlancT";
            this.labelBlancT.Size = new System.Drawing.Size(85, 22);
            this.labelBlancT.TabIndex = 2;
            this.labelBlancT.Text = "label1";
            this.labelBlancT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelBlanc
            // 
            this.panelBlanc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panelBlanc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panelBlanc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelBlanc.Location = new System.Drawing.Point(319, 275);
            this.panelBlanc.Name = "panelBlanc";
            this.panelBlanc.Size = new System.Drawing.Size(23, 69);
            this.panelBlanc.TabIndex = 3;
            // 
            // labelGammaV
            // 
            this.labelGammaV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelGammaV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelGammaV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelGammaV.Location = new System.Drawing.Point(104, 487);
            this.labelGammaV.Margin = new System.Windows.Forms.Padding(3);
            this.labelGammaV.Name = "labelGammaV";
            this.labelGammaV.Size = new System.Drawing.Size(238, 22);
            this.labelGammaV.TabIndex = 2;
            this.labelGammaV.Text = "label1";
            this.labelGammaV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelGammaT
            // 
            this.labelGammaT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelGammaT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelGammaT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelGammaT.Location = new System.Drawing.Point(13, 487);
            this.labelGammaT.Margin = new System.Windows.Forms.Padding(3);
            this.labelGammaT.Name = "labelGammaT";
            this.labelGammaT.Size = new System.Drawing.Size(85, 22);
            this.labelGammaT.TabIndex = 2;
            this.labelGammaT.Text = "label1";
            this.labelGammaT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRef
            // 
            this.labelRef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelRef.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelRef.Location = new System.Drawing.Point(169, 13);
            this.labelRef.Margin = new System.Windows.Forms.Padding(3);
            this.labelRef.Name = "labelRef";
            this.labelRef.Size = new System.Drawing.Size(173, 24);
            this.labelRef.TabIndex = 4;
            this.labelRef.Text = "label1";
            this.labelRef.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WorkingSpaceChoixControle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.labelRef);
            this.Controls.Add(this.panelBlanc);
            this.Controls.Add(this.panelBleu);
            this.Controls.Add(this.panelVert);
            this.Controls.Add(this.panelRouge);
            this.Controls.Add(this.labelGammaT);
            this.Controls.Add(this.labelBlancT);
            this.Controls.Add(this.labelBleuT);
            this.Controls.Add(this.labelVertT);
            this.Controls.Add(this.labelBlancV);
            this.Controls.Add(this.labelRougeT);
            this.Controls.Add(this.labelGammaV);
            this.Controls.Add(this.labelBleuV);
            this.Controls.Add(this.labelVertV);
            this.Controls.Add(this.labelRougeV);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.graphCourbe1);
            this.Name = "WorkingSpaceChoixControle";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(355, 522);
            this.ResumeLayout(false);

        }

        #endregion

        private GraphCourbe graphCourbe1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelRougeV;
        private System.Windows.Forms.Label labelRougeT;
        private System.Windows.Forms.Label labelVertT;
        private System.Windows.Forms.Label labelBleuT;
        private System.Windows.Forms.Label labelVertV;
        private System.Windows.Forms.Label labelBleuV;
        private System.Windows.Forms.Panel panelRouge;
        private System.Windows.Forms.Panel panelVert;
        private System.Windows.Forms.Panel panelBleu;
        private System.Windows.Forms.Label labelBlancV;
        private System.Windows.Forms.Label labelBlancT;
        private System.Windows.Forms.Panel panelBlanc;
        private System.Windows.Forms.Label labelGammaV;
        private System.Windows.Forms.Label labelGammaT;
        private System.Windows.Forms.Label labelRef;
    }
}
