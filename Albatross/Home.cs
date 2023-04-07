using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Albatross.Yokai_Watch;
using Albatross.Yokai_Watch.Games;
using Albatross.Yokai_Watch.Games.YW2;
using Albatross.Level5.Image;

namespace Albatross
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProjectWindow newProjectWindow = new NewProjectWindow();
            newProjectWindow.ShowDialog();
        }

        private void LoadGame()
        {
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

        public void Home_Load(object sender, EventArgs e)
        {
            LoadGame();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IGame game = null;

            int selectedIndex = gameDataGridView.CurrentCell.RowIndex;
            string projectName = gameDataGridView.Rows[selectedIndex].Cells[0].Value.ToString();
            string projectGame = gameDataGridView.Rows[selectedIndex].Cells[1].Value.ToString();
            string projectLanguage = gameDataGridView.Rows[selectedIndex].Cells[2].Value.ToString();
            string projectFolder = gameDataGridView.Rows[selectedIndex].Cells[3].Value.ToString();

            if (projectGame == "yw2")
            {
                game = new YW2(projectFolder, projectLanguage);
            }

            HomeGame homeGame = new HomeGame(projectName, game);
            homeGame.Show();
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
                gameDataGridView.Rows.RemoveAt(selectedIndex);

                LoadGame();
            }
        }
    }
}
