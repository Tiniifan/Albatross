using System;
using System.Drawing;
using System.Windows.Forms;

namespace Albatross.Forms.Characters
{
    public partial class MedalWindow : Form
    {
        public int X = -1;
        public int Y = -1;
        public int MedalSize;

        public MedalWindow(Bitmap faceIcon, int medalSize)
        {
            InitializeComponent();

            MedalSize = medalSize;

            // Set the image and size of the PictureBox
            faceIconPictureBox.Image = faceIcon;
            faceIconPictureBox.Size = new Size(faceIcon.Width, faceIcon.Height);

            // Calculate the desired form size based on the screen size and image size
            int desiredWidth = faceIconPictureBox.Width + 70;
            int desiredHeight = faceIconPictureBox.Height + 20;

            // Set the form size to the maximum available height and width
            this.Size = new Size(Math.Min(desiredWidth, Screen.PrimaryScreen.WorkingArea.Width),
                                 Math.Min(desiredHeight, Screen.PrimaryScreen.WorkingArea.Height));

            this.MaximumSize = this.Size;
        }


        private void FaceIconPictureBox_Click(object sender, EventArgs e)
        {
            // Get the mouse coordinates relative to the PictureBox
            Point mousePosition = faceIconPictureBox.PointToClient(MousePosition);

            // Calculate x and y positions based on the medal size
            X = mousePosition.X / MedalSize;
            Y = mousePosition.Y / MedalSize;

            this.Close();
        }

        private void MedalWindow_SizeChanged(object sender, EventArgs e)
        {
            medalText.Location = new Point(Convert.ToInt32(((Point)this.Size).X / 2.2), medalText.Location.Y);
        }
    }
}
