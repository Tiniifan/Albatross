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
            this.experienceCurveFlatNumericUpDown = new Albatross.UI.FlatNumericUpDown();
            this.flatNumericUpDown1 = new Albatross.UI.FlatNumericUpDown();
            this.flatNumericUpDown2 = new Albatross.UI.FlatNumericUpDown();
            this.flatNumericUpDown3 = new Albatross.UI.FlatNumericUpDown();
            this.flatNumericUpDown4 = new Albatross.UI.FlatNumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.characterContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facePictureBox)).BeginInit();
            this.characterGroupBox.SuspendLayout();
            this.baseGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.experienceCurveFlatNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flatNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flatNumericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flatNumericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flatNumericUpDown4)).BeginInit();
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
            // 
            // characterContextMenuStrip
            // 
            this.characterContextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.characterContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.characterContextMenuStrip.Name = "characterContextMenuStrip";
            this.characterContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.characterContextMenuStrip.Size = new System.Drawing.Size(108, 48);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.insertToolStripMenuItem.Text = "Insert";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
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
            this.baseGroupBox.Controls.Add(this.label7);
            this.baseGroupBox.Controls.Add(this.label6);
            this.baseGroupBox.Controls.Add(this.label4);
            this.baseGroupBox.Controls.Add(this.label3);
            this.baseGroupBox.Controls.Add(this.label2);
            this.baseGroupBox.Controls.Add(this.flatNumericUpDown4);
            this.baseGroupBox.Controls.Add(this.flatNumericUpDown3);
            this.baseGroupBox.Controls.Add(this.flatNumericUpDown2);
            this.baseGroupBox.Controls.Add(this.flatNumericUpDown1);
            this.baseGroupBox.Controls.Add(this.experienceCurveFlatNumericUpDown);
            this.baseGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.baseGroupBox.Location = new System.Drawing.Point(20, 110);
            this.baseGroupBox.Name = "baseGroupBox";
            this.baseGroupBox.Size = new System.Drawing.Size(255, 181);
            this.baseGroupBox.TabIndex = 78;
            this.baseGroupBox.TabStop = false;
            this.baseGroupBox.Text = "Scale";
            // 
            // experienceCurveFlatNumericUpDown
            // 
            this.experienceCurveFlatNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.experienceCurveFlatNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.experienceCurveFlatNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.experienceCurveFlatNumericUpDown.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.experienceCurveFlatNumericUpDown.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.experienceCurveFlatNumericUpDown.Location = new System.Drawing.Point(79, 41);
            this.experienceCurveFlatNumericUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.experienceCurveFlatNumericUpDown.Name = "experienceCurveFlatNumericUpDown";
            this.experienceCurveFlatNumericUpDown.Size = new System.Drawing.Size(130, 20);
            this.experienceCurveFlatNumericUpDown.TabIndex = 69;
            // 
            // flatNumericUpDown1
            // 
            this.flatNumericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.flatNumericUpDown1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.flatNumericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flatNumericUpDown1.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.flatNumericUpDown1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.flatNumericUpDown1.Location = new System.Drawing.Point(79, 67);
            this.flatNumericUpDown1.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.flatNumericUpDown1.Name = "flatNumericUpDown1";
            this.flatNumericUpDown1.Size = new System.Drawing.Size(130, 20);
            this.flatNumericUpDown1.TabIndex = 70;
            // 
            // flatNumericUpDown2
            // 
            this.flatNumericUpDown2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.flatNumericUpDown2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.flatNumericUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flatNumericUpDown2.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.flatNumericUpDown2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.flatNumericUpDown2.Location = new System.Drawing.Point(79, 93);
            this.flatNumericUpDown2.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.flatNumericUpDown2.Name = "flatNumericUpDown2";
            this.flatNumericUpDown2.Size = new System.Drawing.Size(130, 20);
            this.flatNumericUpDown2.TabIndex = 71;
            // 
            // flatNumericUpDown3
            // 
            this.flatNumericUpDown3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.flatNumericUpDown3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.flatNumericUpDown3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flatNumericUpDown3.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.flatNumericUpDown3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.flatNumericUpDown3.Location = new System.Drawing.Point(79, 119);
            this.flatNumericUpDown3.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.flatNumericUpDown3.Name = "flatNumericUpDown3";
            this.flatNumericUpDown3.Size = new System.Drawing.Size(130, 20);
            this.flatNumericUpDown3.TabIndex = 72;
            // 
            // flatNumericUpDown4
            // 
            this.flatNumericUpDown4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.flatNumericUpDown4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.flatNumericUpDown4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flatNumericUpDown4.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.flatNumericUpDown4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.flatNumericUpDown4.Location = new System.Drawing.Point(79, 145);
            this.flatNumericUpDown4.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.flatNumericUpDown4.Name = "flatNumericUpDown4";
            this.flatNumericUpDown4.Size = new System.Drawing.Size(130, 20);
            this.flatNumericUpDown4.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "Scale 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "Scale 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "Scale 3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 77;
            this.label6.Text = "Scale 4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 78;
            this.label7.Text = "Scale 5";
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
            this.characterContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.facePictureBox)).EndInit();
            this.characterGroupBox.ResumeLayout(false);
            this.characterGroupBox.PerformLayout();
            this.baseGroupBox.ResumeLayout(false);
            this.baseGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.experienceCurveFlatNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flatNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flatNumericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flatNumericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flatNumericUpDown4)).EndInit();
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
        private UI.FlatNumericUpDown flatNumericUpDown4;
        private UI.FlatNumericUpDown flatNumericUpDown3;
        private UI.FlatNumericUpDown flatNumericUpDown2;
        private UI.FlatNumericUpDown flatNumericUpDown1;
        private UI.FlatNumericUpDown experienceCurveFlatNumericUpDown;
    }
}