
namespace Albatross
{
    partial class HomeGame
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeGame));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.charaparamButton = new System.Windows.Forms.Button();
            this.charabaseButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.featureListBox = new System.Windows.Forms.ListBox();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.charaparamButton);
            this.groupBox1.Controls.Add(this.charabaseButton);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(234, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 407);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Character";
            // 
            // charaparamButton
            // 
            this.charaparamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.charaparamButton.Location = new System.Drawing.Point(6, 52);
            this.charaparamButton.Name = "charaparamButton";
            this.charaparamButton.Size = new System.Drawing.Size(200, 23);
            this.charaparamButton.TabIndex = 1;
            this.charaparamButton.Text = "Charaparam";
            this.charaparamButton.UseVisualStyleBackColor = true;
            this.charaparamButton.Click += new System.EventHandler(this.CharaparamButton_Click);
            // 
            // charabaseButton
            // 
            this.charabaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.charabaseButton.Location = new System.Drawing.Point(6, 19);
            this.charabaseButton.Name = "charabaseButton";
            this.charabaseButton.Size = new System.Drawing.Size(200, 23);
            this.charabaseButton.TabIndex = 0;
            this.charabaseButton.Text = "Charabase";
            this.charabaseButton.UseVisualStyleBackColor = true;
            this.charabaseButton.Click += new System.EventHandler(this.CharabaseButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.featureListBox);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 407);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "All Features";
            // 
            // featureListBox
            // 
            this.featureListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.featureListBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.featureListBox.FormattingEnabled = true;
            this.featureListBox.Items.AddRange(new object[] {
            "Charabase",
            "Charaparam"});
            this.featureListBox.Location = new System.Drawing.Point(6, 19);
            this.featureListBox.Name = "featureListBox";
            this.featureListBox.Size = new System.Drawing.Size(204, 381);
            this.featureListBox.TabIndex = 4;
            this.featureListBox.SelectedIndexChanged += new System.EventHandler(this.FeatureListBox_SelectedIndexChanged);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Enabled = false;
            this.optionsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Enabled = false;
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(462, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click_1);
            // 
            // HomeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(462, 442);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(478, 481);
            this.MinimumSize = new System.Drawing.Size(478, 481);
            this.Name = "HomeGame";
            this.Text = "Albatross";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HomeGame_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button charabaseButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox featureListBox;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Button charaparamButton;
    }
}

