namespace Albatross.Forms.Nyanko
{
    partial class SearchWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchWindow));
            this.vsTabControl1 = new Albatross.UI.VSTabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchedTextBox = new System.Windows.Forms.TextBox();
            this.foundListBox = new System.Windows.Forms.ListBox();
            this.vsTabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
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
            this.vsTabControl1.Divider = System.Drawing.Color.White;
            this.vsTabControl1.Font = new System.Drawing.Font("Leelawadee UI", 8.25F);
            this.vsTabControl1.InActiveIndicator = System.Drawing.Color.White;
            this.vsTabControl1.InActiveTab = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.vsTabControl1.InActiveText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.vsTabControl1.Location = new System.Drawing.Point(9, 9);
            this.vsTabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.vsTabControl1.Name = "vsTabControl1";
            this.vsTabControl1.Padding = new System.Drawing.Point(0, 0);
            this.vsTabControl1.SelectedIndex = 0;
            this.vsTabControl1.Size = new System.Drawing.Size(464, 366);
            this.vsTabControl1.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.tabPage3.Controls.Add(this.searchButton);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.searchedTextBox);
            this.tabPage3.Controls.Add(this.foundListBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(456, 337);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Search";
            // 
            // searchButton
            // 
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.ForeColor = System.Drawing.Color.White;
            this.searchButton.Location = new System.Drawing.Point(372, 8);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 6;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Text";
            // 
            // searchedTextBox
            // 
            this.searchedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.searchedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchedTextBox.ForeColor = System.Drawing.Color.White;
            this.searchedTextBox.Location = new System.Drawing.Point(39, 13);
            this.searchedTextBox.Name = "searchedTextBox";
            this.searchedTextBox.Size = new System.Drawing.Size(326, 15);
            this.searchedTextBox.TabIndex = 5;
            // 
            // foundListBox
            // 
            this.foundListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.foundListBox.ForeColor = System.Drawing.Color.White;
            this.foundListBox.FormattingEnabled = true;
            this.foundListBox.Location = new System.Drawing.Point(9, 41);
            this.foundListBox.Name = "foundListBox";
            this.foundListBox.Size = new System.Drawing.Size(438, 290);
            this.foundListBox.TabIndex = 4;
            // 
            // SearchWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(482, 384);
            this.Controls.Add(this.vsTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchWindow";
            this.Text = "Search";
            this.vsTabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.VSTabControl vsTabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchedTextBox;
        private System.Windows.Forms.ListBox foundListBox;
    }
}