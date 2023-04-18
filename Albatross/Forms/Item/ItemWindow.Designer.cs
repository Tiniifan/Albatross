
namespace Albatross
{
    partial class ItemWindow
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
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.itemListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.paramIDTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.quantityFlatNumericUpDown = new Albatross.UI.FlatNumericUpDown();
            this.soldFlatCheckBox = new Albatross.UI.FlatCheckBox();
            this.boughtFlatCheckBox = new Albatross.UI.FlatCheckBox();
            this.priceFlatNumericUpDown = new Albatross.UI.FlatNumericUpDown();
            this.modelFlatComboBox = new Albatross.UI.FlatComboBox();
            this.vsTabControl1 = new Albatross.UI.VSTabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.conditionViewButton = new System.Windows.Forms.Button();
            this.condFlatComboBox = new Albatross.UI.FlatComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.minStatFlatNumericUpDown1 = new Albatross.UI.FlatNumericUpDown();
            this.minStatFlatNumericUpDown4 = new Albatross.UI.FlatNumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.minStatFlatNumericUpDown3 = new Albatross.UI.FlatNumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.minStatFlatNumericUpDown2 = new Albatross.UI.FlatNumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.effectFlatComboBox1 = new Albatross.UI.FlatComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.effectFlatComboBox2 = new Albatross.UI.FlatComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityFlatNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceFlatNumericUpDown)).BeginInit();
            this.vsTabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minStatFlatNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minStatFlatNumericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minStatFlatNumericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minStatFlatNumericUpDown2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTextBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.searchTextBox.Location = new System.Drawing.Point(12, 12);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(185, 13);
            this.searchTextBox.TabIndex = 3;
            this.searchTextBox.Text = "Search...";
            // 
            // itemListBox
            // 
            this.itemListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.itemListBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.itemListBox.FormattingEnabled = true;
            this.itemListBox.Location = new System.Drawing.Point(12, 38);
            this.itemListBox.Name = "itemListBox";
            this.itemListBox.Size = new System.Drawing.Size(185, 407);
            this.itemListBox.TabIndex = 2;
            this.itemListBox.SelectedIndexChanged += new System.EventHandler(this.ItemListBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.quantityFlatNumericUpDown);
            this.groupBox1.Controls.Add(this.soldFlatCheckBox);
            this.groupBox1.Controls.Add(this.boughtFlatCheckBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.priceFlatNumericUpDown);
            this.groupBox1.Controls.Add(this.modelFlatComboBox);
            this.groupBox1.Controls.Add(this.paramIDTextBox);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.vsTabControl1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(203, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 413);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Can be";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Max Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Price";
            // 
            // paramIDTextBox
            // 
            this.paramIDTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.paramIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.paramIDTextBox.Enabled = false;
            this.paramIDTextBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.paramIDTextBox.Location = new System.Drawing.Point(352, 40);
            this.paramIDTextBox.Name = "paramIDTextBox";
            this.paramIDTextBox.ReadOnly = true;
            this.paramIDTextBox.Size = new System.Drawing.Size(121, 13);
            this.paramIDTextBox.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(310, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "ID";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(101, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Model";
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTextBox.Enabled = false;
            this.nameTextBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.nameTextBox.Location = new System.Drawing.Point(176, 40);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(121, 13);
            this.nameTextBox.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(101, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(17, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // quantityFlatNumericUpDown
            // 
            this.quantityFlatNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.quantityFlatNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.quantityFlatNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quantityFlatNumericUpDown.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.quantityFlatNumericUpDown.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.quantityFlatNumericUpDown.Location = new System.Drawing.Point(176, 115);
            this.quantityFlatNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.quantityFlatNumericUpDown.Name = "quantityFlatNumericUpDown";
            this.quantityFlatNumericUpDown.Size = new System.Drawing.Size(121, 20);
            this.quantityFlatNumericUpDown.TabIndex = 63;
            this.quantityFlatNumericUpDown.ValueChanged += new System.EventHandler(this.QuantityFlatNumericUpDown_ValueChanged);
            // 
            // soldFlatCheckBox
            // 
            this.soldFlatCheckBox.AutoSize = true;
            this.soldFlatCheckBox.CheckMarkColor = System.Drawing.Color.White;
            this.soldFlatCheckBox.Location = new System.Drawing.Point(426, 119);
            this.soldFlatCheckBox.Name = "soldFlatCheckBox";
            this.soldFlatCheckBox.Size = new System.Drawing.Size(47, 17);
            this.soldFlatCheckBox.TabIndex = 62;
            this.soldFlatCheckBox.Text = "Sold";
            this.soldFlatCheckBox.UseVisualStyleBackColor = true;
            this.soldFlatCheckBox.CheckedChanged += new System.EventHandler(this.SoldFlatCheckBox_CheckedChanged);
            // 
            // boughtFlatCheckBox
            // 
            this.boughtFlatCheckBox.AutoSize = true;
            this.boughtFlatCheckBox.CheckMarkColor = System.Drawing.Color.White;
            this.boughtFlatCheckBox.Location = new System.Drawing.Point(352, 119);
            this.boughtFlatCheckBox.Name = "boughtFlatCheckBox";
            this.boughtFlatCheckBox.Size = new System.Drawing.Size(60, 17);
            this.boughtFlatCheckBox.TabIndex = 61;
            this.boughtFlatCheckBox.Text = "Bought";
            this.boughtFlatCheckBox.UseVisualStyleBackColor = true;
            this.boughtFlatCheckBox.CheckedChanged += new System.EventHandler(this.BoughtFlatCheckBox_CheckedChanged);
            // 
            // priceFlatNumericUpDown
            // 
            this.priceFlatNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.priceFlatNumericUpDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.priceFlatNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.priceFlatNumericUpDown.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.priceFlatNumericUpDown.DecimalPlaces = 2;
            this.priceFlatNumericUpDown.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.priceFlatNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.priceFlatNumericUpDown.Location = new System.Drawing.Point(352, 78);
            this.priceFlatNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            131072});
            this.priceFlatNumericUpDown.Name = "priceFlatNumericUpDown";
            this.priceFlatNumericUpDown.Size = new System.Drawing.Size(121, 20);
            this.priceFlatNumericUpDown.TabIndex = 59;
            this.priceFlatNumericUpDown.ValueChanged += new System.EventHandler(this.PriceFlatNumericUpDown_ValueChanged);
            // 
            // modelFlatComboBox
            // 
            this.modelFlatComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.modelFlatComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.modelFlatComboBox.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.modelFlatComboBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.modelFlatComboBox.FormattingEnabled = true;
            this.modelFlatComboBox.Location = new System.Drawing.Point(176, 77);
            this.modelFlatComboBox.Name = "modelFlatComboBox";
            this.modelFlatComboBox.Size = new System.Drawing.Size(121, 21);
            this.modelFlatComboBox.Sorted = true;
            this.modelFlatComboBox.TabIndex = 28;
            this.modelFlatComboBox.SelectedIndexChanged += new System.EventHandler(this.ModelFlatComboBox_SelectedIndexChanged);
            // 
            // vsTabControl1
            // 
            this.vsTabControl1.ActiveIndicator = System.Drawing.Color.White;
            this.vsTabControl1.ActiveTab = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.vsTabControl1.ActiveText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.vsTabControl1.Background = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.vsTabControl1.BackgroundTab = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.vsTabControl1.Border = System.Drawing.Color.White;
            this.vsTabControl1.Controls.Add(this.tabPage3);
            this.vsTabControl1.Controls.Add(this.tabPage2);
            this.vsTabControl1.Controls.Add(this.tabPage1);
            this.vsTabControl1.Controls.Add(this.tabPage4);
            this.vsTabControl1.Controls.Add(this.tabPage5);
            this.vsTabControl1.Divider = System.Drawing.Color.White;
            this.vsTabControl1.Font = new System.Drawing.Font("Leelawadee UI", 8.25F);
            this.vsTabControl1.InActiveIndicator = System.Drawing.Color.White;
            this.vsTabControl1.InActiveTab = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.vsTabControl1.InActiveText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.vsTabControl1.Location = new System.Drawing.Point(17, 153);
            this.vsTabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.vsTabControl1.Name = "vsTabControl1";
            this.vsTabControl1.Padding = new System.Drawing.Point(0, 0);
            this.vsTabControl1.SelectedIndex = 0;
            this.vsTabControl1.Size = new System.Drawing.Size(495, 249);
            this.vsTabControl1.TabIndex = 4;
            this.vsTabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.VsTabControl1_Selecting);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(487, 220);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Equipment";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.conditionViewButton);
            this.groupBox4.Controls.Add(this.condFlatComboBox);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox4.Location = new System.Drawing.Point(19, 158);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(452, 55);
            this.groupBox4.TabIndex = 78;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Yo-Kai Restriction";
            // 
            // conditionViewButton
            // 
            this.conditionViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conditionViewButton.Font = new System.Drawing.Font("Leelawadee UI", 7.25F);
            this.conditionViewButton.Location = new System.Drawing.Point(235, 21);
            this.conditionViewButton.Name = "conditionViewButton";
            this.conditionViewButton.Size = new System.Drawing.Size(198, 21);
            this.conditionViewButton.TabIndex = 65;
            this.conditionViewButton.Text = "View";
            this.conditionViewButton.UseVisualStyleBackColor = true;
            this.conditionViewButton.Click += new System.EventHandler(this.ConditionViewButton_Click);
            // 
            // condFlatComboBox
            // 
            this.condFlatComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.condFlatComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.condFlatComboBox.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.condFlatComboBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.condFlatComboBox.FormattingEnabled = true;
            this.condFlatComboBox.Location = new System.Drawing.Point(50, 21);
            this.condFlatComboBox.Name = "condFlatComboBox";
            this.condFlatComboBox.Size = new System.Drawing.Size(179, 21);
            this.condFlatComboBox.TabIndex = 63;
            this.condFlatComboBox.SelectedIndexChanged += new System.EventHandler(this.CondFlatComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 64;
            this.label6.Text = "Cond.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.minStatFlatNumericUpDown1);
            this.groupBox2.Controls.Add(this.minStatFlatNumericUpDown4);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.minStatFlatNumericUpDown3);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.minStatFlatNumericUpDown2);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(19, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(452, 72);
            this.groupBox2.TabIndex = 77;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stats";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(70, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 65;
            this.label16.Text = "Strength";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(262, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 66;
            this.label15.Text = "Defense";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(17, 35);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(27, 13);
            this.label20.TabIndex = 75;
            this.label20.Text = "Stat";
            // 
            // minStatFlatNumericUpDown1
            // 
            this.minStatFlatNumericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.minStatFlatNumericUpDown1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.minStatFlatNumericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minStatFlatNumericUpDown1.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.minStatFlatNumericUpDown1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.minStatFlatNumericUpDown1.Location = new System.Drawing.Point(50, 33);
            this.minStatFlatNumericUpDown1.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.minStatFlatNumericUpDown1.Minimum = new decimal(new int[] {
            2147483647,
            0,
            0,
            -2147483648});
            this.minStatFlatNumericUpDown1.Name = "minStatFlatNumericUpDown1";
            this.minStatFlatNumericUpDown1.Size = new System.Drawing.Size(90, 22);
            this.minStatFlatNumericUpDown1.TabIndex = 67;
            this.minStatFlatNumericUpDown1.ValueChanged += new System.EventHandler(this.MinStatValueChanged);
            // 
            // minStatFlatNumericUpDown4
            // 
            this.minStatFlatNumericUpDown4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.minStatFlatNumericUpDown4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.minStatFlatNumericUpDown4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minStatFlatNumericUpDown4.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.minStatFlatNumericUpDown4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.minStatFlatNumericUpDown4.Location = new System.Drawing.Point(338, 33);
            this.minStatFlatNumericUpDown4.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.minStatFlatNumericUpDown4.Minimum = new decimal(new int[] {
            2147483647,
            0,
            0,
            -2147483648});
            this.minStatFlatNumericUpDown4.Name = "minStatFlatNumericUpDown4";
            this.minStatFlatNumericUpDown4.Size = new System.Drawing.Size(90, 22);
            this.minStatFlatNumericUpDown4.TabIndex = 73;
            this.minStatFlatNumericUpDown4.ValueChanged += new System.EventHandler(this.MinStatValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(176, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 68;
            this.label17.Text = "Spirit";
            // 
            // minStatFlatNumericUpDown3
            // 
            this.minStatFlatNumericUpDown3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.minStatFlatNumericUpDown3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.minStatFlatNumericUpDown3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minStatFlatNumericUpDown3.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.minStatFlatNumericUpDown3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.minStatFlatNumericUpDown3.Location = new System.Drawing.Point(242, 33);
            this.minStatFlatNumericUpDown3.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.minStatFlatNumericUpDown3.Minimum = new decimal(new int[] {
            2147483647,
            0,
            0,
            -2147483648});
            this.minStatFlatNumericUpDown3.Name = "minStatFlatNumericUpDown3";
            this.minStatFlatNumericUpDown3.Size = new System.Drawing.Size(90, 22);
            this.minStatFlatNumericUpDown3.TabIndex = 72;
            this.minStatFlatNumericUpDown3.ValueChanged += new System.EventHandler(this.MinStatValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(364, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 13);
            this.label18.TabIndex = 69;
            this.label18.Text = "Speed";
            // 
            // minStatFlatNumericUpDown2
            // 
            this.minStatFlatNumericUpDown2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.minStatFlatNumericUpDown2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.minStatFlatNumericUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minStatFlatNumericUpDown2.ButtonHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.minStatFlatNumericUpDown2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.minStatFlatNumericUpDown2.Location = new System.Drawing.Point(146, 33);
            this.minStatFlatNumericUpDown2.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.minStatFlatNumericUpDown2.Minimum = new decimal(new int[] {
            2147483647,
            0,
            0,
            -2147483648});
            this.minStatFlatNumericUpDown2.Name = "minStatFlatNumericUpDown2";
            this.minStatFlatNumericUpDown2.Size = new System.Drawing.Size(90, 22);
            this.minStatFlatNumericUpDown2.TabIndex = 71;
            this.minStatFlatNumericUpDown2.ValueChanged += new System.EventHandler(this.MinStatValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.effectFlatComboBox1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.effectFlatComboBox2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Location = new System.Drawing.Point(19, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(452, 55);
            this.groupBox3.TabIndex = 76;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Effects";
            // 
            // effectFlatComboBox1
            // 
            this.effectFlatComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.effectFlatComboBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.effectFlatComboBox1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.effectFlatComboBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.effectFlatComboBox1.FormattingEnabled = true;
            this.effectFlatComboBox1.Location = new System.Drawing.Point(50, 21);
            this.effectFlatComboBox1.Name = "effectFlatComboBox1";
            this.effectFlatComboBox1.Size = new System.Drawing.Size(160, 21);
            this.effectFlatComboBox1.TabIndex = 61;
            this.effectFlatComboBox1.SelectedIndexChanged += new System.EventHandler(this.EffectFlatComboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Effect 1";
            // 
            // effectFlatComboBox2
            // 
            this.effectFlatComboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.effectFlatComboBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.effectFlatComboBox2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.effectFlatComboBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.effectFlatComboBox2.FormattingEnabled = true;
            this.effectFlatComboBox2.Location = new System.Drawing.Point(284, 21);
            this.effectFlatComboBox2.Name = "effectFlatComboBox2";
            this.effectFlatComboBox2.Size = new System.Drawing.Size(160, 21);
            this.effectFlatComboBox2.TabIndex = 63;
            this.effectFlatComboBox2.SelectedIndexChanged += new System.EventHandler(this.EffectFlatComboBox2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "Effect 2";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(487, 220);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Consumable";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(487, 220);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Key Item";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(487, 220);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Creature";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(487, 220);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "Soul";
            // 
            // ItemWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(741, 452);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.itemListBox);
            this.Name = "ItemWindow";
            this.Text = "ItemWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ItemWindow_FormClosed);
            this.Load += new System.EventHandler(this.ItemWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityFlatNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceFlatNumericUpDown)).EndInit();
            this.vsTabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minStatFlatNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minStatFlatNumericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minStatFlatNumericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minStatFlatNumericUpDown2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ListBox itemListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private UI.FlatComboBox modelFlatComboBox;
        private System.Windows.Forms.TextBox paramIDTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label12;
        private UI.VSTabControl vsTabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label1;
        private UI.FlatNumericUpDown priceFlatNumericUpDown;
        private UI.FlatCheckBox soldFlatCheckBox;
        private UI.FlatCheckBox boughtFlatCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private UI.FlatNumericUpDown quantityFlatNumericUpDown;
        private System.Windows.Forms.Label label5;
        private UI.FlatComboBox effectFlatComboBox2;
        private System.Windows.Forms.Label label4;
        private UI.FlatComboBox effectFlatComboBox1;
        private System.Windows.Forms.Label label20;
        private UI.FlatNumericUpDown minStatFlatNumericUpDown4;
        private UI.FlatNumericUpDown minStatFlatNumericUpDown3;
        private UI.FlatNumericUpDown minStatFlatNumericUpDown2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private UI.FlatNumericUpDown minStatFlatNumericUpDown1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private UI.FlatComboBox condFlatComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button conditionViewButton;
    }
}