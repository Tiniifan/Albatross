using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using Albatross.Tools;
using Albatross.Level5.Text;
using Albatross.Level5.Image;
using Albatross.Yokai_Watch.Logic;
using Albatross.Yokai_Watch.Games;
using YKW1 = Albatross.Yokai_Watch.Games.YW1.Logic;
using YKW2 = Albatross.Yokai_Watch.Games.YW2.Logic;
using YKW3 = Albatross.Yokai_Watch.Games.YW3.Logic;
using YKWB = Albatross.Yokai_Watch.Games.YWB.Logic;

namespace Albatross.Forms.Characters
{
    public partial class NewCharabaseWindow : Form
    {
        public IGame GameOpened;

        int NameHash;

        public ICharabase NewCharabase;

        public T2bþ Charanames;

        public NewCharabaseWindow(IGame game, T2bþ charanames, string[] availableModels)
        {
            GameOpened = game;
            Charanames = charanames;

            InitializeComponent();
            modelFlatComboBox.Items.AddRange(availableModels);
            newNameFlatComboBox.Items.AddRange(GameSupport.PrefixLetter.Values.Select(x => x.ToString()).ToArray());    
        }

        private void NewModelTextBox_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                newModelTextBox.Text = ofd.SelectedPath;
            }
        }

        private void NewIconTextBox_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Configure the dialog box
                openFileDialog.Title = "Select an image";
                //openFileDialog.Filter = "Images|*.png;*.jpg;*.xi|All Files|*.*";
                openFileDialog.Filter = "Level 5 Image|*.xi";
                openFileDialog.FilterIndex = 1;

                // Show the dialog box
                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    // Check the extension of the selected file
                    string[] supportedExtensions = { ".png", ".jpg", ".xi" };
                    string fileExtension = Path.GetExtension(selectedFilePath).ToLower();

                    if (Array.IndexOf(supportedExtensions, fileExtension) != -1)
                    {
                        newIconTextBox.Text = selectedFilePath;
                    }
                    else
                    {
                        MessageBox.Show("Unsupported image format. Please select an image in .png, .jpg, or .xi format.");
                    }
                }
            }
        }

        private void NameTextBox_Click(object sender, EventArgs e)
        {
            Nyanko.Nyanko nyanko = new Nyanko.Nyanko(Path.GetFileName(GameOpened.Files["chara_text"].Path), Charanames, false, true, NameHash);
            nyanko.ShowDialog();
            Charanames = nyanko.T2bþFileOpened;

            // Update current name
            if (nyanko.SelectedHash != 0)
            {
                NameHash = nyanko.SelectedHash;
                nameTextBox.Text = Charanames.Nouns[NameHash].Strings[0].Text;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Gets the logic and creates the charabase
            if (isYokaiFlatCheckBox.Checked)
            {
                switch (GameOpened.Name)
                {
                    case "Yo-Kai Watch 1":
                        NewCharabase = GameSupport.GetLogic<YKW1.YokaiCharabase>();
                        break;
                    case "Yo-Kai Watch 2":
                        NewCharabase = GameSupport.GetLogic<YKW2.YokaiCharabase>();
                        break;
                    case "Yo-Kai Watch 3":
                        NewCharabase = GameSupport.GetLogic<YKW3.YokaiCharabase>();
                        break;
                    case "Yo-Kai Watch Blaster":
                        NewCharabase = GameSupport.GetLogic<YKWB.YokaiCharabase>();
                        break;
                }
            }
            else
            {
                switch (GameOpened.Name)
                {
                    case "Yo-Kai Watch 1":
                        NewCharabase = GameSupport.GetLogic<YKW1.NPCCharabase>();
                        break;
                    case "Yo-Kai Watch 2":
                        NewCharabase = GameSupport.GetLogic<YKW2.NPCCharabase>();
                        break;
                    case "Yo-Kai Watch 3":
                        NewCharabase = GameSupport.GetLogic<YKW3.NPCCharabase>();
                        break;
                    case "Yo-Kai Watch Blaster":
                        NewCharabase = GameSupport.GetLogic<YKWB.NPCCharabase>();
                        break;
                }
            }

            NewCharabase.NameHash = NameHash;
            NewCharabase.IsYokai = isYokaiFlatCheckBox.Checked;
            NewCharabase.MedalPosX = isYokaiFlatCheckBox.Checked ? 0 : -1;
            NewCharabase.MedalPosY = isYokaiFlatCheckBox.Checked ? 0 : -1;

            if (modelTypeVSTabControl.SelectedIndex == 0)
            {
                // Existing Model
                if (modelFlatComboBox.SelectedIndex != -1)
                {
                    (int, int, int) fileName = GameSupport.GetFileModelValue(modelFlatComboBox.SelectedItem.ToString());
                    NewCharabase.FileNamePrefix = fileName.Item1;
                    NewCharabase.FileNameNumber = fileName.Item2;
                    NewCharabase.FileNameVariant = fileName.Item2;
                }
            }
            else
            {
                string prefix = newNameFlatComboBox.SelectedItem.ToString();
                string number = newNumberFlatNumericUpDown.Value.ToString().PadLeft(3, '0');
                string variance = newNumberFlatNumericUpDown.Value.ToString().PadLeft(3, '0');
                string fileName = prefix + number + variance;

                (int, int, int) fileNameSplited = GameSupport.GetFileModelValue(variance);
                NewCharabase.FileNamePrefix = fileNameSplited.Item1;
                NewCharabase.FileNameNumber = fileNameSplited.Item2;
                NewCharabase.FileNameVariant = fileNameSplited.Item2;

                // Check if model path is valid
                VirtualDirectory modelPath = null;
                if (newModelTextBox.Text != null)
                {
                    modelPath = GameOpened.Files["model"].File.Directory.GetFolder(GameOpened.Files["model"].Path);

                    if (modelPath.Folders.Any(x => x.Name == fileName))
                    {
                        MessageBox.Show("The model name already exists, please enter another name");
                        return;
                    }
                }

                // Check if icon path is valid
                VirtualDirectory iconPath = null;
                if (newIconTextBox.Text != null)
                {
                    iconPath = GameOpened.Files["iconPath"].File.Directory.GetFolderFromFullPath(GameOpened.Files["iconPath"].Path);

                    if (iconPath.Files.Any(x => x.Key == fileName + ".xi"))
                    {
                        MessageBox.Show("The icon name already exists, please enter another name");
                        return;
                    }
                }

                // Insert new models and animations
                if (newModelTextBox.Text != null)
                {         
                    modelPath.AddFolder(fileName);
                    modelPath = modelPath.GetFolder(fileName);

                    int index = 0;
                    string[] files = Directory.GetFiles(newModelTextBox.Text);
                    foreach (string file in files)
                    {
                        if (Path.GetExtension(file) == ".xc")
                        {
                            // Get the name of model
                            string modelFileName = fileName + "_" + index.ToString().PadLeft(2, '0') + ".xc";

                            // Read file data
                            SubMemoryStream fileData = new SubMemoryStream(File.ReadAllBytes(file));
                            fileData.Size = fileData.ByteContent.Length;
                            fileData.Color = Color.Orange;

                            // Insert new file
                            modelPath.AddFile(modelFileName, fileData);

                            index += 10;
                        }
                    }
                }

                // Insert new icon
                if (newIconTextBox.Text != null)
                {
                    byte[] imageData = new byte[] { };

                    if (Path.GetExtension(newIconTextBox.Text) != ".xi")
                    {
                        // Convert JPEG.PNG to .IMGC
                        // Need to write
                    } else
                    {
                        imageData = File.ReadAllBytes(newIconTextBox.Text);
                    }

                    // Get the name of icon
                    string modelFileName = fileName + ".xi";

                    // Read file data
                    SubMemoryStream fileData = new SubMemoryStream(imageData);
                    fileData.Size = fileData.ByteContent.Length;
                    fileData.Color = Color.Orange;

                    // Insert new file
                    iconPath.AddFile(modelFileName, fileData);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
