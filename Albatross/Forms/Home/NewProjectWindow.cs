using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Albatross.Yokai_Watch.Games.YW1;
using Albatross.Yokai_Watch.Games.YW2;
using Albatross.Yokai_Watch.Games.YW3;

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
            switch (gameFlatComboBox1.SelectedIndex)
            {
                case 0:
                    return YW1Support.AvailableLanguages[language];
                case 1:
                    return YW2Support.AvailableLanguages[language];
                case 2:
                    return YW3Support.AvailableLanguages[language];
                default:
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

                switch (gameFlatComboBox1.SelectedIndex)
                {
                    case 0:
                        languageFlatComboBox.Items.AddRange(YW1Support.AvailableLanguages.Keys.ToArray());
                        break;
                    case 1:
                        languageFlatComboBox.Items.AddRange(YW2Support.AvailableLanguages.Keys.ToArray());
                        break;
                    case 2:
                        languageFlatComboBox.Items.AddRange(YW3Support.AvailableLanguages.Keys.ToArray());
                        break;
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
            bool projectCreated = false;

            string languageCode = GetLanguageCode(languageFlatComboBox.Text);

            if (gameFlatComboBox1.SelectedIndex == 0)
            {
                projectCreated = File.Exists(pathTextBox.Text + @"\yw1_a.fa");
                if (projectCreated)
                {
                    using (StreamWriter sw = File.AppendText("./AlbatrosTemp.txt"))
                    {
                        sw.WriteLine(nameTextBox.Text.Replace("|", "") + "|yw1|" + languageCode + "|" + pathTextBox.Text);
                    }
                }
            }
            else if (gameFlatComboBox1.SelectedIndex == 1)
            {
                projectCreated = File.Exists(pathTextBox.Text + @"\yw2_a.fa") && File.Exists(pathTextBox.Text + @"\yw2_lg_" + languageCode + @".fa");
                if (projectCreated)
                {
                    using (StreamWriter sw = File.AppendText("./AlbatrosTemp.txt"))
                    {
                        sw.WriteLine(nameTextBox.Text.Replace("|", "") + "|yw2|" + languageCode + "|" + pathTextBox.Text);
                    }
                }
            }
            else if (gameFlatComboBox1.SelectedIndex == 2)
            {
                projectCreated = File.Exists(pathTextBox.Text + @"\yw_a.fa") && File.Exists(pathTextBox.Text + @"\yw_lg_" + languageCode + @".fa");
                if (projectCreated)
                {
                    using (StreamWriter sw = File.AppendText("./AlbatrosTemp.txt"))
                    {
                        sw.WriteLine(nameTextBox.Text.Replace("|", "") + "|yw3|" + languageCode + "|" + pathTextBox.Text);
                    }
                }
            }

            if (projectCreated)
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Project successful created!");
                Close();
            } else
            {
                MessageBox.Show("Cannot open this ExtractedRomfs folder due to a missing file.");
            }
        }
    }
}
