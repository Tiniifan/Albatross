namespace Albatross.Forms.Characters
{
    partial class CharascaleWindow
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
            this.components = new System.ComponentModel.Container();
            this.characterListBox = new System.Windows.Forms.ListBox();
            this.characterContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.hashTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.facePictureBox = new System.Windows.Forms.PictureBox();
            this.characterGroupBox = new System.Windows.Forms.GroupBox();
            this.baseGroupBox = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.scaleFlatNumericUpDown5 = new Albatross.UI.FlatNumericUpDown();
            this.scaleFlatNumericUpDown4 = new Albatross.UI.FlatNumericUpDown();
            this.scaleFlatNumericUpDown3 = new Albatross.UI.FlatNumericUpDown();
            this.scaleFlatNumericUpDown2 = new Albatross.UI.FlatNumericUpDown();
            this.scaleFlatNumericUpDown1 = new Albatross.UI.FlatNumericUpDown();
            this.scaleText6 = new System.Windows.Forms.Label();
            this.scaleFlatNumericUpDown6 = new Albatross.UI.FlatNumericUpDown();
            this.characterContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facePictureBox)).BeginInit();
            this.characterGroupBox.SuspendLayout();
            this.baseGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleFlatNumericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleFlatNumericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleFlatNumericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleFlatNumericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleFlatNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleFlatNumericUpDown6)).BeginInit();
            this.SuspendLayout();
            // 
            // characterListBox
            // 
            this.characterListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.characterListBox.ContextMenuStrip = this.characterContextMenuStrip;
            this.characterListBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.characterListBox.FormattingEnabled = true;
            this.characterListBox.Location = new System.Drawing.Point(12, 38);
            this.characterListBox.Name = "characterListBox";
            this.characterListBox.Size = new System.Drawing.Size(185, 303);
            this.characterListBox.TabIndex = 9;
            this.characterListBox.SelectedIndexChanged += new System.EventHandler(this.CharacterListBox_SelectedIndexChanged);
            // 
            // characterContextMenuStrip
            // 
            this.characterContextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.characterContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.characterContextMenuStrip.Name = "characterContextMenuStrip";
            this.characterContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.characterContextMenuStrip.Size = new System.Drawing.Size(202, 48);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.insertToolStripMenuItem.Text = "Insert from unused base";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.InsertToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.deleteToolStripMenuItem.Text = "Remove unused scale";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTextBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.searchTextBox.Location = new System.Drawing.Point(12, 12);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(185, 13);
            this.searchTextBox.TabIndex = 8;
            this.searchTextBox.Text = "Search...";
            this.searchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // hashTextBox
            // 
            this.hashTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.hashTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hashTextBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.hashTextBox.Location = new System.Drawing.Point(162, 49);
            this.hashTextBox.Name = "hashTextBox";
            this.hashTextBox.ReadOnly = true;
            this.hashTextBox.Size = new System.Drawing.Size(113, 13);
            this.hashTextBox.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Hash";
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTextBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.nameTextBox.Location = new System.Drawing.Point(162, 68);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(113, 13);
            this.nameTextBox.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(96, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Name";
            // 
            // facePictureBox
            // 
            this.facePictureBox.Location = new System.Drawing.Point(20, 31);
            this.facePictureBox.Name = "facePictureBox";
            this.facePictureBox.Size = new System.Drawing.Size(64, 64);
            this.facePictureBox.TabIndex = 28;
            this.facePictureBox.TabStop = false;
            // 
            // characterGroupBox
            // 
            this.characterGroupBox.Controls.Add(this.hashTextBox);
            this.characterGroupBox.Controls.Add(this.label5);
            this.characterGroupBox.Controls.Add(this.baseGroupBox);
            this.characterGroupBox.Controls.Add(this.nameTextBox);
            this.characterGroupBox.Controls.Add(this.label12);
            this.characterGroupBox.Controls.Add(this.facePictureBox);
            this.characterGroupBox.Enabled = false;
            this.characterGroupBox.ForeColor = System.Drawing.Color.White;
            this.characterGroupBox.Location = new System.Drawing.Point(203, 32);
            this.characterGroupBox.Name = "characterGroupBox";
            this.characterGroupBox.Size = new System.Drawing.Size(297, 310);
            this.characterGroupBox.TabIndex = 10;
            this.characterGroupBox.TabStop = false;
            this.characterGroupBox.Text = "Character";
            // 
            // baseGroupBox
            // 
            this.baseGroupBox.Controls.Add(this.scaleText6);
            this.baseGroupBox.Controls.Add(this.scaleFlatNumericUpDown6);
            this.baseGroupBox.Controls.Add(this.label7);
            this.baseGroupBox.Controls.Add(this.label6);
            this.baseGroupBox.Controls.Add(this.label4);
            this.baseGroupBox.Controls.Add(this.label3);
            this.baseGroupBox.Controls.Add(this.label2);
            this.baseGroupBox.Controls.Add(this.scaleFlatNumericUpDown5);
            this.baseGroupBox.Controls.Add(this.scaleFlatNumericUpDown4);
            this.baseGroupBox.Controls.Add(this.scaleFlatNumericUpDown3);
            this.baseGroupBox.Controls.Add(this.scaleFlatNumericUpDown2);
            this.baseGroupBox.Controls.Add(this.scaleFlatNumericUpDown1);
            this.baseGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.baseGroupBox.Location = new System.Drawing.Point(20, 110);
            this.baseGroupBox.Name = "baseGroupBox";
            this.baseGroupBox.Size = new System.Drawing.Size(255, 181);
            this.baseGroupBox.TabIndex = 78;
            this.baseGroupBox.TabStop = false;
            this.baseGroupBox.Text = "Scale";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 78;
            this.label7.Text = "Scale 5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 77;
            this.label6.Text = "Scale 4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "Scale 3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "Scale 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "Scale 1";
            // 
            // scaleFlatNumericUpDown5
            // 
            this.scaleFlatNumericUpDown5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.scaleFlatNumericUpDown5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.scaleFlatNumericUpDown5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scaleFlatNumericUpDown5.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.scaleFlatNumericUpDown5.DecimalPlaces = 1;
            this.scaleFlatNumericUpDown5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.scaleFlatNumericUpDown5.Location = new System.Drawing.Point(79, 125);
            this.scaleFlatNumericUpDown5.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.scaleFlatNumericUpDown5.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.scaleFlatNumericUpDown5.Name = "scaleFlatNumericUpDown5";
            this.scaleFlatNumericUpDown5.Size = new System.Drawing.Size(130, 20);
            this.scaleFlatNumericUpDown5.TabIndex = 73;
            this.scaleFlatNumericUpDown5.ValueChanged += new System.EventHandler(this.ScaleFlatNumericUpDown5_ValueChanged);
            // 
            // scaleFlatNumericUpDown4
            // 
            this.scaleFlatNumericUpDown4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.scaleFlatNumericUpDown4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.scaleFlatNumericUpDown4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scaleFlatNumericUpDown4.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.scaleFlatNumericUpDown4.DecimalPlaces = 1;
            this.scaleFlatNumericUpDown4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.scaleFlatNumericUpDown4.Location = new System.Drawing.Point(79, 99);
            this.scaleFlatNumericUpDown4.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.scaleFlatNumericUpDown4.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.scaleFlatNumericUpDown4.Name = "scaleFlatNumericUpDown4";
            this.scaleFlatNumericUpDown4.Size = new System.Drawing.Size(130, 20);
            this.scaleFlatNumericUpDown4.TabIndex = 72;
            this.scaleFlatNumericUpDown4.ValueChanged += new System.EventHandler(this.ScaleFlatNumericUpDown4_ValueChanged);
            // 
            // scaleFlatNumericUpDown3
            // 
            this.scaleFlatNumericUpDown3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.scaleFlatNumericUpDown3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.scaleFlatNumericUpDown3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scaleFlatNumericUpDown3.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.scaleFlatNumericUpDown3.DecimalPlaces = 1;
            this.scaleFlatNumericUpDown3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.scaleFlatNumericUpDown3.Location = new System.Drawing.Point(79, 73);
            this.scaleFlatNumericUpDown3.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.scaleFlatNumericUpDown3.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.scaleFlatNumericUpDown3.Name = "scaleFlatNumericUpDown3";
            this.scaleFlatNumericUpDown3.Size = new System.Drawing.Size(130, 20);
            this.scaleFlatNumericUpDown3.TabIndex = 71;
            this.scaleFlatNumericUpDown3.ValueChanged += new System.EventHandler(this.ScaleFlatNumericUpDown3_ValueChanged);
            // 
            // scaleFlatNumericUpDown2
            // 
            this.scaleFlatNumericUpDown2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.scaleFlatNumericUpDown2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.scaleFlatNumericUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scaleFlatNumericUpDown2.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.scaleFlatNumericUpDown2.DecimalPlaces = 1;
            this.scaleFlatNumericUpDown2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.scaleFlatNumericUpDown2.Location = new System.Drawing.Point(79, 47);
            this.scaleFlatNumericUpDown2.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.scaleFlatNumericUpDown2.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.scaleFlatNumericUpDown2.Name = "scaleFlatNumericUpDown2";
            this.scaleFlatNumericUpDown2.Size = new System.Drawing.Size(130, 20);
            this.scaleFlatNumericUpDown2.TabIndex = 70;
            this.scaleFlatNumericUpDown2.ValueChanged += new System.EventHandler(this.ScaleFlatNumericUpDown2_ValueChanged);
            // 
            // scaleFlatNumericUpDown1
            // 
            this.scaleFlatNumericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.scaleFlatNumericUpDown1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.scaleFlatNumericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scaleFlatNumericUpDown1.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.scaleFlatNumericUpDown1.DecimalPlaces = 1;
            this.scaleFlatNumericUpDown1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.scaleFlatNumericUpDown1.Location = new System.Drawing.Point(79, 21);
            this.scaleFlatNumericUpDown1.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.scaleFlatNumericUpDown1.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.scaleFlatNumericUpDown1.Name = "scaleFlatNumericUpDown1";
            this.scaleFlatNumericUpDown1.Size = new System.Drawing.Size(130, 20);
            this.scaleFlatNumericUpDown1.TabIndex = 69;
            this.scaleFlatNumericUpDown1.ValueChanged += new System.EventHandler(this.ScaleFlatNumericUpDown1_ValueChanged);
            // 
            // scaleText6
            // 
            this.scaleText6.AutoSize = true;
            this.scaleText6.Location = new System.Drawing.Point(30, 151);
            this.scaleText6.Name = "scaleText6";
            this.scaleText6.Size = new System.Drawing.Size(43, 13);
            this.scaleText6.TabIndex = 80;
            this.scaleText6.Text = "Scale 6";
            // 
            // scaleFlatNumericUpDown6
            // 
            this.scaleFlatNumericUpDown6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.scaleFlatNumericUpDown6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.scaleFlatNumericUpDown6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scaleFlatNumericUpDown6.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.scaleFlatNumericUpDown6.DecimalPlaces = 1;
            this.scaleFlatNumericUpDown6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.scaleFlatNumericUpDown6.Location = new System.Drawing.Point(79, 149);
            this.scaleFlatNumericUpDown6.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.scaleFlatNumericUpDown6.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.scaleFlatNumericUpDown6.Name = "scaleFlatNumericUpDown6";
            this.scaleFlatNumericUpDown6.Size = new System.Drawing.Size(130, 20);
            this.scaleFlatNumericUpDown6.TabIndex = 79;
            this.scaleFlatNumericUpDown6.ValueChanged += new System.EventHandler(this.ScaleFlatNumericUpDown6_ValueChanged);
            // 
            // CharascaleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(516, 352);
            this.Controls.Add(this.characterListBox);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.characterGroupBox);
            this.Name = "CharascaleWindow";
            this.Text = "CharascaleWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CharascaleWindow_FormClosed);
            this.characterContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.facePictureBox)).EndInit();
            this.characterGroupBox.ResumeLayout(false);
            this.characterGroupBox.PerformLayout();
            this.baseGroupBox.ResumeLayout(false);
            this.baseGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleFlatNumericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleFlatNumericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleFlatNumericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleFlatNumericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleFlatNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleFlatNumericUpDown6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox characterListBox;
        private System.Windows.Forms.ContextMenuStrip characterContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TextBox hashTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox facePictureBox;
        private System.Windows.Forms.GroupBox characterGroupBox;
        private System.Windows.Forms.GroupBox baseGroupBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private UI.FlatNumericUpDown scaleFlatNumericUpDown5;
        private UI.FlatNumericUpDown scaleFlatNumericUpDown4;
        private UI.FlatNumericUpDown scaleFlatNumericUpDown3;
        private UI.FlatNumericUpDown scaleFlatNumericUpDown2;
        private UI.FlatNumericUpDown scaleFlatNumericUpDown1;
        private System.Windows.Forms.Label scaleText6;
        private UI.FlatNumericUpDown scaleFlatNumericUpDown6;
    }
}