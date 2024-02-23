namespace LibCore.Formulaires
{
    partial class ChoixWorkingSpace
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
            this.workingSpaceChoixControle1 = new LibCore.Controles.Graphiques.WorkingSpaceChoixControle();
            this.buttonAnnule = new System.Windows.Forms.Button();
            this.buttonValide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // workingSpaceChoixControle1
            // 
            this.workingSpaceChoixControle1.AutoSize = true;
            this.workingSpaceChoixControle1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.workingSpaceChoixControle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.workingSpaceChoixControle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.workingSpaceChoixControle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.workingSpaceChoixControle1.Location = new System.Drawing.Point(13, 13);
            this.workingSpaceChoixControle1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.workingSpaceChoixControle1.Name = "workingSpaceChoixControle1";
            this.workingSpaceChoixControle1.NameTheme = "Default";
            this.workingSpaceChoixControle1.Padding = new System.Windows.Forms.Padding(10);
            this.workingSpaceChoixControle1.Size = new System.Drawing.Size(355, 522);
            this.workingSpaceChoixControle1.TabIndex = 0;
            // 
            // buttonAnnule
            // 
            this.buttonAnnule.AutoSize = true;
            this.buttonAnnule.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAnnule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonAnnule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAnnule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonAnnule.Location = new System.Drawing.Point(13, 542);
            this.buttonAnnule.Name = "buttonAnnule";
            this.buttonAnnule.Size = new System.Drawing.Size(66, 27);
            this.buttonAnnule.TabIndex = 1;
            this.buttonAnnule.Text = "button1";
            this.buttonAnnule.UseVisualStyleBackColor = false;
            this.buttonAnnule.Click += new System.EventHandler(this.ButtonAnnule_Click);
            // 
            // buttonValide
            // 
            this.buttonValide.AutoSize = true;
            this.buttonValide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonValide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonValide.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonValide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonValide.Location = new System.Drawing.Point(302, 542);
            this.buttonValide.Name = "buttonValide";
            this.buttonValide.Size = new System.Drawing.Size(66, 27);
            this.buttonValide.TabIndex = 1;
            this.buttonValide.Text = "button1";
            this.buttonValide.UseVisualStyleBackColor = false;
            this.buttonValide.Click += new System.EventHandler(this.ButtonValide_Click);
            // 
            // ChoixWorkingSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 727);
            this.ControlBox = false;
            this.Controls.Add(this.buttonValide);
            this.Controls.Add(this.buttonAnnule);
            this.Controls.Add(this.workingSpaceChoixControle1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChoixWorkingSpace";
            this.Text = "ChoixWorkingSpace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.Graphiques.WorkingSpaceChoixControle workingSpaceChoixControle1;
        private System.Windows.Forms.Button buttonAnnule;
        private System.Windows.Forms.Button buttonValide;
    }
}