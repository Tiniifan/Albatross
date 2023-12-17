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
            this.faceIconPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.faceIconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // faceIconPictureBox
            // 
            this.faceIconPictureBox.Location = new System.Drawing.Point(12, 27);
            this.faceIconPictureBox.Name = "faceIconPictureBox";
            this.faceIconPictureBox.Size = new System.Drawing.Size(512, 256);
            this.faceIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.faceIconPictureBox.TabIndex = 0;
            this.faceIconPictureBox.TabStop = false;
            this.faceIconPictureBox.Click += new System.EventHandler(this.FaceIconPictureBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(232, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose your medal!";
            // 
            // MedalWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(536, 297);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.faceIconPictureBox);
            this.Name = "MedalWindow";
            this.Text = "MedalWindow";
            ((System.ComponentModel.ISupportInitialize)(this.faceIconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox faceIconPictureBox;
        private System.Windows.Forms.Label label1;
    }
}