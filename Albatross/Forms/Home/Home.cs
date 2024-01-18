using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Albatross.Yokai_Watch.Games;
using Albatross.Yokai_Watch.Games.YW1;
using Albatross.Yokai_Watch.Games.YW2;
using Albatross.Yokai_Watch.Games.YW3;
using Albatross.Yokai_Watch.Games.YWB;
using Albatross.Yokai_Watch.Games.YWB2;

namespace Albatross
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

            LoadGame();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProjectWindow newProjectWindow = new NewProjectWindow();

            if (newProjectWindow.ShowDialog() == DialogResult.OK)
            {
                LoadGame();
            }
        }

        private void LoadGame()
        {
            gameDataGridView.Rows.Clear();

            if (File.Exists("./AlbatrosTemp.txt"))
            {
                var lines = File.ReadAllLines("./AlbatrosTemp.txt");
                for (var i = 0; i < lines.Length; i += 1)
                {
                    List<string> gameData = lines[i].Split('|').ToList();
                    gameDataGridView.Rows.Add(gameData[0], gameData[1], gameData[2], gameData[3]);
                }
            }

            openToolStripMenuItem.Enabled = gameDataGridView.RowCount > 0;
            deleteToolStripMenuItem.Enabled = gameDataGridView.RowCount > 0;
        }

        private void OpenGame()
        {
            IGame game = null;

            int selectedIndex = gameDataGridView.CurrentCell.RowIndex;
            string projectName = gameDataGridView.Rows[selectedIndex].Cells[0].Value.ToString();
            string projectGame = gameDataGridView.Rows[selectedIndex].Cells[1].Value.ToString();
            string projectLanguage = gameDataGridView.Rows[selectedIndex].Cells[2].Value.ToString();
            string projectFolder = gameDataGridView.Rows[selectedIndex].Cells[3].Value.ToString();

            switch (projectGame)
            {
                case "yw1":
                    game = new YW1(projectFolder, projectLanguage);
                    break;
                case "yw2":
                    game = new YW2(projectFolder, projectLanguage);
                    break;
                case "yw3":
                    game = new YW3(projectFolder, projectLanguage);
                    break;
                case "ywb":
                    game = new YWB(projectFolder, projectLanguage);
                    break;
                case "ywb2":
                    game = new YWB2(projectFolder, projectLanguage);
                    break;
                default:
                    MessageBox.Show("Can't open this project because the game isn't supported", "Unsupported game", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            if (game != null)
            {
                HomeGame homeGame = new HomeGame(projectName, game);
                homeGame.Show();
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenGame();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = gameDataGridView.CurrentCell.RowIndex;
            string projectName = gameDataGridView.Rows[selectedIndex].Cells[0].Value.ToString();
            string search = gameDataGridView.Rows[selectedIndex].Cells[0].Value.ToString() + "|" + gameDataGridView.Rows[selectedIndex].Cells[1].Value.ToString() + "|" + gameDataGridView.Rows[selectedIndex].Cells[2].Value.ToString() + "|" + gameDataGridView.Rows[selectedIndex].Cells[3].Value.ToString();

            DialogResult dialogResult = MessageBox.Show("Do you want to delete " + projectName + "?", "Delete Project", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                List<string> lines = File.ReadAllLines("./AlbatrosTemp.txt").ToList();
                for (int i = 0; i < lines.Count; i++)
                {
                   if (lines[i] == search) 
                   {
                        lines.RemoveAt(i);
                        break;
                    }
                }

                File.WriteAllLines("./AlbatrosTemp.txt", lines.ToArray());
            }

            LoadGame();
        }

        private void GameDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenGame();
        }
    }
}
