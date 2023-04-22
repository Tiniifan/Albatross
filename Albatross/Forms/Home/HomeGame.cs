using System;
using System.IO;
using Albatross.Tool;
using System.Windows.Forms;
using Albatross.Yokai_Watch;
using Albatross.Yokai_Watch.Games;
using Albatross.Yokai_Watch.Games.YW2;

namespace Albatross
{
    public partial class HomeGame : Form
    {
        private IGame Game;

        public HomeGame(string projectName, IGame game)
        {
            InitializeComponent();

            this.Text = projectName;
            Game = game;
        }

        private void SaveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Game.Save();
            MessageBox.Show("Saved!");
        }

        private void YokaisButton_Click(object sender, EventArgs e)
        {
            YokaiWindow yokaiWindow = new YokaiWindow(Game);
            yokaiWindow.Show();
        }

        private void ItemsButton_Click(object sender, EventArgs e)
        {
            ItemWindow itemwindow = new ItemWindow(Game);
            itemwindow.ShowDialog();
        }

        private void HomeGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Call Close Event
        }
    }
}
