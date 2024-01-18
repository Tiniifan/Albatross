namespace Albatross.Forms.Nyanko
{
    partial class Nyanko
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nyanko));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.textTextBox = new System.Windows.Forms.TextBox();
            this.textTreeView = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textKeyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textItemContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textTypeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nounTypeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nounTypeAddTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.textKeyContextMenuStrip.SuspendLayout();
            this.textItemContextMenuStrip.SuspendLayout();
            this.textTypeContextMenuStrip.SuspendLayout();
            this.nounTypeContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.confirmButton);
            this.groupBox1.Controls.Add(this.textTextBox);
            this.groupBox1.Location = new System.Drawing.Point(463, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 315);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // confirmButton
            // 
            this.confirmButton.Enabled = false;
            this.confirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmButton.ForeColor = System.Drawing.Color.White;
            this.confirmButton.Location = new System.Drawing.Point(11, 280);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(296, 23);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "Select This Text";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // textTextBox
            // 
            this.textTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.textTextBox.Enabled = false;
            this.textTextBox.ForeColor = System.Drawing.Color.White;
            this.textTextBox.Location = new System.Drawing.Point(11, 14);
            this.textTextBox.Multiline = true;
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.Size = new System.Drawing.Size(296, 260);
            this.textTextBox.TabIndex = 2;
            this.textTextBox.TextChanged += new System.EventHandler(this.TextTextBox_TextChanged);
            // 
            // textTreeView
            // 
            this.textTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.textTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTreeView.ForeColor = System.Drawing.Color.White;
            this.textTreeView.Location = new System.Drawing.Point(3, 3);
            this.textTreeView.Name = "textTreeView";
            this.textTreeView.Size = new System.Drawing.Size(454, 315);
            this.textTreeView.TabIndex = 6;
            this.textTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TextTreeView_AfterSelect);
            this.textTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TextTreeView_NodeMouseClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.15032F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.84967F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textTreeView, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(779, 325);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // textKeyContextMenuStrip
            // 
            this.textKeyContextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.textKeyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTextToolStripMenuItem,
            this.renameKeyToolStripMenuItem,
            this.removeKeyToolStripMenuItem});
            this.textKeyContextMenuStrip.Name = "textKeyContextMenuStrip";
            this.textKeyContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.textKeyContextMenuStrip.Size = new System.Drawing.Size(140, 70);
            // 
            // addTextToolStripMenuItem
            // 
            this.addTextToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.addTextToolStripMenuItem.Name = "addTextToolStripMenuItem";
            this.addTextToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.addTextToolStripMenuItem.Text = "Add Text";
            // 
            // renameKeyToolStripMenuItem
            // 
            this.renameKeyToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.renameKeyToolStripMenuItem.Name = "renameKeyToolStripMenuItem";
            this.renameKeyToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.renameKeyToolStripMenuItem.Text = "Rename Key";
            // 
            // removeKeyToolStripMenuItem
            // 
            this.removeKeyToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.removeKeyToolStripMenuItem.Name = "removeKeyToolStripMenuItem";
            this.removeKeyToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.removeKeyToolStripMenuItem.Text = "Remove Key";
            // 
            // textItemContextMenuStrip
            // 
            this.textItemContextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.textItemContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeTextToolStripMenuItem});
            this.textItemContextMenuStrip.Name = "textItemContextMenuStrip";
            this.textItemContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.textItemContextMenuStrip.Size = new System.Drawing.Size(142, 26);
            // 
            // removeTextToolStripMenuItem
            // 
            this.removeTextToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.removeTextToolStripMenuItem.Name = "removeTextToolStripMenuItem";
            this.removeTextToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.removeTextToolStripMenuItem.Text = "Remove Text";
            this.removeTextToolStripMenuItem.Click += new System.EventHandler(this.RemoveTextToolStripMenuItem_Click);
            // 
            // textTypeContextMenuStrip
            // 
            this.textTypeContextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.textTypeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addKeyToolStripMenuItem});
            this.textTypeContextMenuStrip.Name = "contextMenuStrip1";
            this.textTypeContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.textTypeContextMenuStrip.Size = new System.Drawing.Size(121, 26);
            // 
            // addKeyToolStripMenuItem
            // 
            this.addKeyToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.addKeyToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.addKeyToolStripMenuItem.Name = "addKeyToolStripMenuItem";
            this.addKeyToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.addKeyToolStripMenuItem.Text = "Add Text";
            this.addKeyToolStripMenuItem.Click += new System.EventHandler(this.AddKeyToolStripMenuItem_Click);
            // 
            // nounTypeContextMenuStrip
            // 
            this.nounTypeContextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.nounTypeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nounTypeAddTextToolStripMenuItem});
            this.nounTypeContextMenuStrip.Name = "contextMenuStrip1";
            this.nounTypeContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.nounTypeContextMenuStrip.Size = new System.Drawing.Size(121, 26);
            // 
            // nounTypeAddTextToolStripMenuItem
            // 
            this.nounTypeAddTextToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.nounTypeAddTextToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.nounTypeAddTextToolStripMenuItem.Name = "nounTypeAddTextToolStripMenuItem";
            this.nounTypeAddTextToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.nounTypeAddTextToolStripMenuItem.Text = "Add Text";
            this.nounTypeAddTextToolStripMenuItem.Click += new System.EventHandler(this.NounTypeAddTextToolStripMenuItem_Click);
            // 
            // Nyanko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(803, 344);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Nyanko";
            this.Text = "Nyanko";
            this.Load += new System.EventHandler(this.Nyanko_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.textKeyContextMenuStrip.ResumeLayout(false);
            this.textItemContextMenuStrip.ResumeLayout(false);
            this.textTypeContextMenuStrip.ResumeLayout(false);
            this.nounTypeContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.TextBox textTextBox;
        private System.Windows.Forms.TreeView textTreeView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip textKeyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeKeyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip textItemContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeTextToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip textTypeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addKeyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip nounTypeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem nounTypeAddTextToolStripMenuItem;
    }
}