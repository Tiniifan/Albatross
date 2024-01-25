namespace Albatross.Forms.Encounters
{
    partial class EncounterWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncounterWindow));
            this.mapListBox = new System.Windows.Forms.ListBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.encounterDataGridView = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hashTextBox = new System.Windows.Forms.TextBox();
            this.hashLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mapGroupBox = new System.Windows.Forms.GroupBox();
            this.tableFlatComboBox = new Albatross.UI.FlatComboBox();
            this.charaContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.encounterDataGridView)).BeginInit();
            this.mapGroupBox.SuspendLayout();
            this.charaContextMenuStrip.SuspendLayout();
            this.tableContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapListBox
            // 
            this.mapListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.mapListBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mapListBox.FormattingEnabled = true;
            this.mapListBox.Location = new System.Drawing.Point(12, 38);
            this.mapListBox.Name = "mapListBox";
            this.mapListBox.Size = new System.Drawing.Size(237, 355);
            this.mapListBox.Sorted = true;
            this.mapListBox.TabIndex = 9;
            this.mapListBox.SelectedIndexChanged += new System.EventHandler(this.MapListBox_SelectedIndexChanged);
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTextBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.searchTextBox.Location = new System.Drawing.Point(12, 12);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(237, 13);
            this.searchTextBox.TabIndex = 8;
            this.searchTextBox.Text = "Search...";
            // 
            // encounterDataGridView
            // 
            this.encounterDataGridView.AllowUserToAddRows = false;
            this.encounterDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.encounterDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.encounterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.encounterDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.encounterDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.encounterDataGridView.Enabled = false;
            this.encounterDataGridView.EnableHeadersVisualStyles = false;
            this.encounterDataGridView.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.encounterDataGridView.Location = new System.Drawing.Point(20, 69);
            this.encounterDataGridView.Name = "encounterDataGridView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.encounterDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.encounterDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.encounterDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.encounterDataGridView.Size = new System.Drawing.Size(403, 278);
            this.encounterDataGridView.TabIndex = 49;
            this.encounterDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.EncounterDataGridView_CellValueChanged);
            this.encounterDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.EncounterDataGridView_CurrentCellDirtyStateChanged);
            this.encounterDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EncounterDataGridView_MouseDown);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Picture";
            this.Column3.Name = "Column3";
            // 
            // Column1
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Yokai";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Level";
            this.Column2.Name = "Column2";
            // 
            // hashTextBox
            // 
            this.hashTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.hashTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hashTextBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.hashTextBox.Location = new System.Drawing.Point(310, 32);
            this.hashTextBox.Name = "hashTextBox";
            this.hashTextBox.ReadOnly = true;
            this.hashTextBox.Size = new System.Drawing.Size(113, 13);
            this.hashTextBox.TabIndex = 61;
            // 
            // hashLabel
            // 
            this.hashLabel.AutoSize = true;
            this.hashLabel.Enabled = false;
            this.hashLabel.Location = new System.Drawing.Point(272, 32);
            this.hashLabel.Name = "hashLabel";
            this.hashLabel.Size = new System.Drawing.Size(32, 13);
            this.hashLabel.TabIndex = 60;
            this.hashLabel.Text = "Hash";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Table";
            // 
            // mapGroupBox
            // 
            this.mapGroupBox.Controls.Add(this.encounterDataGridView);
            this.mapGroupBox.Controls.Add(this.hashTextBox);
            this.mapGroupBox.Controls.Add(this.label6);
            this.mapGroupBox.Controls.Add(this.hashLabel);
            this.mapGroupBox.Controls.Add(this.tableFlatComboBox);
            this.mapGroupBox.Enabled = false;
            this.mapGroupBox.ForeColor = System.Drawing.Color.White;
            this.mapGroupBox.Location = new System.Drawing.Point(257, 32);
            this.mapGroupBox.Name = "mapGroupBox";
            this.mapGroupBox.Size = new System.Drawing.Size(438, 362);
            this.mapGroupBox.TabIndex = 63;
            this.mapGroupBox.TabStop = false;
            this.mapGroupBox.Text = "Map";
            // 
            // tableFlatComboBox
            // 
            this.tableFlatComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.tableFlatComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.tableFlatComboBox.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.tableFlatComboBox.ContextMenuStrip = this.tableContextMenuStrip;
            this.tableFlatComboBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableFlatComboBox.FormattingEnabled = true;
            this.tableFlatComboBox.Location = new System.Drawing.Point(59, 29);
            this.tableFlatComboBox.Name = "tableFlatComboBox";
            this.tableFlatComboBox.Size = new System.Drawing.Size(143, 21);
            this.tableFlatComboBox.TabIndex = 62;
            this.tableFlatComboBox.SelectedIndexChanged += new System.EventHandler(this.TableFlatComboBox_SelectedIndexChanged);
            // 
            // charaContextMenuStrip
            // 
            this.charaContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.charaContextMenuStrip.Name = "charaContextMenuStrip";
            this.charaContextMenuStrip.Size = new System.Drawing.Size(118, 26);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // tableContextMenuStrip
            // 
            this.tableContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem1});
            this.tableContextMenuStrip.Name = "tableContextMenuStrip";
            this.tableContextMenuStrip.Size = new System.Drawing.Size(118, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            this.removeToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem1.Text = "Remove";
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.RemoveToolStripMenuItem1_Click);
            // 
            // EncounterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(706, 404);
            this.Controls.Add(this.mapGroupBox);
            this.Controls.Add(this.mapListBox);
            this.Controls.Add(this.searchTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EncounterWindow";
            this.Text = "Encounter";
            ((System.ComponentModel.ISupportInitialize)(this.encounterDataGridView)).EndInit();
            this.mapGroupBox.ResumeLayout(false);
            this.mapGroupBox.PerformLayout();
            this.charaContextMenuStrip.ResumeLayout(false);
            this.tableContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox mapListBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.DataGridView encounterDataGridView;
        private System.Windows.Forms.TextBox hashTextBox;
        private System.Windows.Forms.Label hashLabel;
        private System.Windows.Forms.Label label6;
        private UI.FlatComboBox tableFlatComboBox;
        private System.Windows.Forms.GroupBox mapGroupBox;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ContextMenuStrip charaContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip tableContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
    }
}