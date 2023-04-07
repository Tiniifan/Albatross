using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Albatross.Yokai_Watch.Games.YW2;

namespace Albatross
{
    public partial class NewProjectWindow : Form
    {
        public NewProjectWindow()
        {
            InitializeComponent();
        }

        private string GetLanguageCode(string language)
        {
            // Yokai Watch 2
            if (gameFlatComboBox1.SelectedIndex == 0)
            {
                return YW2Support.AvailableLanguages[language];
            } else
            {
                return null;
            }
        }

        private void ProjectCanBeCreated()
        {
            if (nameTextBox.Text != string.Empty && languageFlatComboBox.SelectedIndex != -1 && gameFlatComboBox1.SelectedIndex != -1 && pathTextBox.Text != string.Empty)
            {
                saveButton.Enabled = true;
                saveButton.ForeColor = Color.White;
            } else
            {
                saveButton.Enabled = false;
                saveButton.ForeColor = Color.Black;
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            ProjectCanBeCreated();
        }

        private void LanguageFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectCanBeCreated();
        }

        private void GameFlatComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gameFlatComboBox1.SelectedIndex != -1)
            {
                languageFlatComboBox.Items.Clear();

                // Yokai Watch 2
                if (gameFlatComboBox1.SelectedIndex == 0)
                {
                    languageFlatComboBox.Items.AddRange(YW2Support.AvailableLanguages.Keys.ToArray());
                }

                ProjectCanBeCreated();
            }
        }

        private void NameTextBox_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                pathTextBox.Text = ofd.SelectedPath;
            }

            ProjectCanBeCreated();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (gameFlatComboBox1.SelectedIndex == 0)
            {
                string languageCode = GetLanguageCode(languageFlatComboBox.Text);

                // Yokai Watch 2
                if (gameFlatComboBox1.SelectedIndex == 0)
                {
                    if (File.Exists(pathTextBox.Text + @"\yw2_a.fa") && File.Exists(pathTextBox.Text + @"\yw2_lg_" + languageCode + @".fa"))
                    {
                        using (StreamWriter sw = File.AppendText("./AlbatrosTemp.txt"))
                        {
                            sw.WriteLine(nameTextBox.Text.Replace("|", "") + "|yw2|" + languageCode + "|" + pathTextBox.Text);
                        }

                        MessageBox.Show("Project successful created!");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Cannot open this extractedromfs folder due to a missing folder.");
                    }
                }
            }
        }

        private void NewProjectWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Home home = (Home)Application.OpenForms["Home"];
            home.Home_Load(sender, e);
        }
    }
}
