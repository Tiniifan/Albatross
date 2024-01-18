namespace Albatross.Forms.Characters
{
    partial class MedalWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedalWindow));
            this.faceIconPictureBox = new System.Windows.Forms.PictureBox();
            this.medalText = new System.Windows.Forms.Label();
            this.medalPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.faceIconPictureBox)).BeginInit();
            this.medalPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // faceIconPictureBox
            // 
            this.faceIconPictureBox.Location = new System.Drawing.Point(4, 3);
            this.faceIconPictureBox.Name = "faceIconPictureBox";
            this.faceIconPictureBox.Size = new System.Drawing.Size(512, 256);
            this.faceIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.faceIconPictureBox.TabIndex = 0;
            this.faceIconPictureBox.TabStop = false;
            this.faceIconPictureBox.Click += new System.EventHandler(this.FaceIconPictureBox_Click);
            // 
            // medalText
            // 
            this.medalText.AutoSize = true;
            this.medalText.ForeColor = System.Drawing.Color.White;
            this.medalText.Location = new System.Drawing.Point(232, 5);
            this.medalText.Name = "medalText";
            this.medalText.Size = new System.Drawing.Size(100, 13);
            this.medalText.TabIndex = 1;
            this.medalText.Text = "Choose your medal!";
            // 
            // medalPanel
            // 
            this.medalPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.medalPanel.AutoScroll = true;
            this.medalPanel.Controls.Add(this.faceIconPictureBox);
            this.medalPanel.Location = new System.Drawing.Point(12, 30);
            this.medalPanel.Name = "medalPanel";
            this.medalPanel.Size = new System.Drawing.Size(519, 263);
            this.medalPanel.TabIndex = 2;
            // 
            // MedalWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(543, 305);
            this.Controls.Add(this.medalPanel);
            this.Controls.Add(this.medalText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MedalWindow";
            this.Text = "Medal";
            this.SizeChanged += new System.EventHandler(this.MedalWindow_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.faceIconPictureBox)).EndInit();
            this.medalPanel.ResumeLayout(false);
            this.medalPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox faceIconPictureBox;
        private System.Windows.Forms.Label medalText;
        private System.Windows.Forms.Panel medalPanel;
    }
}