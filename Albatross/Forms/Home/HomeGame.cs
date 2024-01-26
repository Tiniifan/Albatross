using System;
using System.IO;
using Albatross.Tools;
using System.Windows.Forms;
using Albatross.Yokai_Watch;
using Albatross.Yokai_Watch.Games;
using Albatross.Yokai_Watch.Games.YW2;
using Albatross.Forms.Characters;
using Albatross.Forms.Encounters;
using Albatross.Forms.Shops;

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

        private void HomeGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Game.Game != null)
            {
                Game.Game.Close();
            }

            if (Game.Language != null)
            {
                Game.Language.Close();
            }
        }

        private void FeatureListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (featureListBox.SelectedIndex == -1) return;

            switch (featureListBox.SelectedItem.ToString())
            {
                case "Charabase":
                    CharabaseButton_Click(sender, e);
                    break;
                case "Charascale":
                    CharascaleButton_Click(sender, e);
                    break;
                case "Charaparam":
                    CharaparamButton_Click(sender, e);
                    break;
                case "Encounters":
                    EncounterWindow encounterWindow = new EncounterWindow(Game);
                    encounterWindow.ShowDialog();
                    break;
                case "Shops":
                    ShopWindow shopWindow = new ShopWindow(Game);
                    shopWindow.ShowDialog();
                    break;
            }
        }

        private void CharabaseButton_Click(object sender, EventArgs e)
        {
            CharabaseWindow charabaseWindow = new CharabaseWindow(Game);
            charabaseWindow.ShowDialog();
        }

        private void CharaparamButton_Click(object sender, EventArgs e)
        {
            CharaparamWindow charaparamWindow = new CharaparamWindow(Game);
            charaparamWindow.ShowDialog();
        }

        private void CharascaleButton_Click(object sender, EventArgs e)
        {
            CharascaleWindow charascaleWindow = new CharascaleWindow(Game);
            charascaleWindow.ShowDialog();
        }
    }
}
