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
            faceIconPictureBox.Image = faceIcon;
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
    }
}
