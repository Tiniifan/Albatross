
namespace Albatross
{
    partial class NewProjectWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProjectWindow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gameFlatComboBox1 = new Albatross.UI.FlatComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.languageFlatComboBox = new Albatross.UI.FlatComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.gameFlatComboBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pathTextBox);
            this.groupBox1.Controls.Add(this.languageFlatComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "My Project";
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTextBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.nameTextBox.Location = new System.Drawing.Point(130, 25);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(200, 13);
            this.nameTextBox.TabIndex = 35;
            this.nameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "ExtractedRomfs Path";
            // 
            // gameFlatComboBox1
            // 
            this.gameFlatComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.gameFlatComboBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.gameFlatComboBox1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.gameFlatComboBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gameFlatComboBox1.FormattingEnabled = true;
            this.gameFlatComboBox1.Items.AddRange(new object[] {
            "Yo-Kai Watch 2"});
            this.gameFlatComboBox1.Location = new System.Drawing.Point(130, 81);
            this.gameFlatComboBox1.Name = "gameFlatComboBox1";
            this.gameFlatComboBox1.Size = new System.Drawing.Size(200, 21);
            this.gameFlatComboBox1.TabIndex = 33;
            this.gameFlatComboBox1.SelectedIndexChanged += new System.EventHandler(this.GameFlatComboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Game";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Language";
            // 
            // pathTextBox
            // 
            this.pathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.pathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pathTextBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pathTextBox.Location = new System.Drawing.Point(130, 115);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(200, 13);
            this.pathTextBox.TabIndex = 30;
            this.pathTextBox.Click += new System.EventHandler(this.NameTextBox_Click);
            // 
            // languageFlatComboBox
            // 
            this.languageFlatComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.languageFlatComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.languageFlatComboBox.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.languageFlatComboBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.languageFlatComboBox.FormattingEnabled = true;
            this.languageFlatComboBox.Location = new System.Drawing.Point(130, 54);
            this.languageFlatComboBox.Name = "languageFlatComboBox";
            this.languageFlatComboBox.Size = new System.Drawing.Size(200, 21);
            this.languageFlatComboBox.TabIndex = 29;
            this.languageFlatComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageFlatComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.saveButton.Enabled = false;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(12, 159);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(341, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // NewProjectWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(364, 193);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(380, 232);
            this.MinimumSize = new System.Drawing.Size(380, 232);
            this.Name = "NewProjectWindow";
            this.Text = "NewProjectWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NewProjectWindow_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private UI.FlatComboBox languageFlatComboBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label4;
        private UI.FlatComboBox gameFlatComboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button saveButton;
    }
}