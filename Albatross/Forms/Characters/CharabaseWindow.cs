using System;
using System.IO;
using System.Text;
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
using Albatross.Yokai_Watch.Common;

namespace Albatross.Forms.Characters
{
    public partial class CharabaseWindow : Form
    {
        private IGame GameOpened;

        private List<ICharabase> Charabases;

        private List<ICharabase> CharabasesFiltred;

        private ICharabase SelectedCharabase;

        private T2bþ Charanames;

        private T2bþ Charadesc;

        private Bitmap FaceIcon;

        public CharabaseWindow(IGame game)
        {
            GameOpened = game;

            Charabases = new List<ICharabase>();
            CharabasesFiltred = new List<ICharabase>();

            InitializeComponent();
            LoadCharabase();
        }

        private string[] GetNames(ICharabase[] charabases)
        {
            return charabases
                .Select((charabase, index) =>
                {
                    return Charanames.Nouns.TryGetValue(charabase.NameHash, out var noun) && noun.Strings.Count > 0
                        ? noun.Strings[0].Text
                        : "Name " + index;
                })
                .ToArray();
        }

        private void SetComboBox(int itemID, Dictionary<int, string> dict, ComboBox comboBox)
        {
            if (dict.ContainsKey(itemID))
            {
                comboBox.SelectedIndex = comboBox.Items.IndexOf(dict[itemID]);
            }
            else
            {
                comboBox.SelectedIndex = -1;
                comboBox.Text = "";
            }
        }

        private void SetPictureBox(PictureBox picturebox, string filename)
        {
            using (Stream imgStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(filename))
            {
                var image = new Bitmap(imgStream);
                picturebox.Image = image;
            }
        }

        private Bitmap CropMedal(int x, int y, int size)
        {
            // Define the region to crop.
            Rectangle cropRect = new Rectangle(x * size, y * size, size, size);

            // Ensure that the crop region is within the bounds of the FaceIcon image.
            if (cropRect.X >= FaceIcon.Width || cropRect.Y >= FaceIcon.Height)
            {
                // If the crop region is outside the image bounds, return a transparent bitmap.
                return new Bitmap(size, size);
            }

            // Adjust the crop region to fit within the image bounds.
            cropRect.Intersect(new Rectangle(0, 0, FaceIcon.Width, FaceIcon.Height));

            // Create a new bitmap based on the adjusted region.
            Bitmap croppedBitmap = new Bitmap(cropRect.Width, cropRect.Height);

            // Use Graphics to draw the desired region into the new bitmap.
            using (Graphics g = Graphics.FromImage(croppedBitmap))
            {
                g.DrawImage(FaceIcon, new Rectangle(0, 0, cropRect.Width, cropRect.Height), cropRect, GraphicsUnit.Pixel);
            }

            return croppedBitmap;
        }

        private void SetMedal(bool draw)
        {
            if (draw)
            {
                int x = Convert.ToInt32(medalXFlatNumericUpDown.Value);
                int y = Convert.ToInt32(medalYFlatNumericUpDown.Value);

                // Set medal
                if (GameOpened.Name == "Yo-Kai Watch 1")
                {
                    medalPictureBox.Image = CropMedal(x, y, 44);
                } else if (GameOpened.Name == "Yo-Kai Watch 2")
                {
                    medalPictureBox.Image = CropMedal(x, y, 44);
                }
                else if (GameOpened.Name == "Yo-Kai Watch 3")
                {
                    medalPictureBox.Image = CropMedal(x, y, 32);
                }
                else if (GameOpened.Name == "Yo-Kai Watch Blaster")
                {
                    medalPictureBox.Image = CropMedal(x, y, 44);
                }
            } else
            {
                medalPictureBox.Image = null;
            }
        }

        private void LoadCharabase()
        {
            // Reset form
            FaceIcon = null;
            tribeFlatComboBox.Items.Clear();
            rankFlatComboBox.Items.Clear();
            hatedFoodFlatComboBox.Items.Clear();
            modelFlatComboBox.Items.Clear();
            characterListBox.Items.Clear();
            facePictureBox.Image = null;
            characterGroupBox.Enabled = false;

            // Get icons
            byte[] faceIconData = GameOpened.Files["face_icon"].File.Directory.GetFileFromFullPath(GameOpened.Files["face_icon"].Path + "/face_icon.xi");
            FaceIcon = IMGC.ToBitmap(faceIconData);

            // Get resources
            Charabases.AddRange(GameOpened.GetCharacterbase(false));
            Charabases.AddRange(GameOpened.GetCharacterbase(true));

            // Get names
            Charanames = new T2bþ(GameOpened.Files["chara_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["chara_text"].Path));

            // Prepare combobox 
            tribeFlatComboBox.Items.AddRange(GameOpened.Tribes.Values.ToArray());
            rankFlatComboBox.Items.AddRange(Ranks.YW.Values.ToArray());
            roleFlatComboBox.Items.AddRange(Roles.YWB.Values.ToArray());
            favoritefoodFlatComboBox.Items.AddRange(GameOpened.FoodsType.Values.ToArray());
            hatedFoodFlatComboBox.Items.AddRange(GameOpened.FoodsType.Values.ToArray());
            modelFlatComboBox.Items.AddRange(GameOpened.Files["model"].File.Directory.GetFolderFromFullPath(GameOpened.Files["model"].Path).Folders.Select(x => x.Name).ToArray());

            // Update name according to hash
            characterListBox.Items.AddRange(GetNames(Charabases.ToArray()).ToArray());

            if (GameOpened.Name == "Yo-Kai Watch 1")
            {
                label8.Enabled = false;
                tribePictureBox.Enabled = false;
                tribeFlatComboBox.Enabled = false;
                isClassicFlatCheckBox.Enabled = false;
                isMericanFlatCheckBox.Enabled = false;
                isDevaFlatCheckBox.Enabled = false;
                isMysteryFlatCheckBox.Enabled = false;
                isTreasureFlatCheckBox.Enabled = false;
                isPionnerFlatCheckBox.Enabled = false;
                isCommandantFlatCheckBox.Enabled = false;
                label9.Enabled = false;
                rolePictureBox.Enabled = false;
                roleFlatComboBox.Enabled = false;
                foodGroupBox.Enabled = true;
            }
            else if (GameOpened.Name == "Yo-Kai Watch 2")
            {
                label8.Enabled = false;
                tribePictureBox.Enabled = true;
                tribeFlatComboBox.Enabled = true;
                isClassicFlatCheckBox.Enabled = true;
                isMericanFlatCheckBox.Enabled = false;
                isDevaFlatCheckBox.Enabled = false;
                isMysteryFlatCheckBox.Enabled = false;
                isTreasureFlatCheckBox.Enabled = false;
                isPionnerFlatCheckBox.Enabled = false;
                isCommandantFlatCheckBox.Enabled = false;
                label9.Enabled = false;
                rolePictureBox.Enabled = false;
                roleFlatComboBox.Enabled = false;
                foodGroupBox.Enabled = true;
            } else if (GameOpened.Name == "Yo-Kai Watch 3")
            {
                label8.Enabled = false;
                tribePictureBox.Enabled = true;
                tribeFlatComboBox.Enabled = true;
                isClassicFlatCheckBox.Enabled = true;
                isMericanFlatCheckBox.Enabled = true;
                isDevaFlatCheckBox.Enabled = true;
                isMysteryFlatCheckBox.Enabled = true;
                isTreasureFlatCheckBox.Enabled = true;
                isPionnerFlatCheckBox.Enabled = true;
                isCommandantFlatCheckBox.Enabled = true;
                label9.Enabled = false;
                rolePictureBox.Enabled = true;
                roleFlatComboBox.Enabled = true;
                foodGroupBox.Enabled = true;
                Charadesc = new T2bþ(GameOpened.Files["chara_desc_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["chara_desc_text"].Path));
            }
            else if (GameOpened.Name == "Yo-Kai Watch Blaster")
            {
                label8.Enabled = false;
                tribePictureBox.Enabled = true;
                tribeFlatComboBox.Enabled = true;
                isClassicFlatCheckBox.Enabled = true;
                isMericanFlatCheckBox.Enabled = false;
                isDevaFlatCheckBox.Enabled = false;
                isMysteryFlatCheckBox.Enabled = false;
                isTreasureFlatCheckBox.Enabled = false;
                isPionnerFlatCheckBox.Enabled = false;
                isCommandantFlatCheckBox.Enabled = false;
                label9.Enabled = false;
                rolePictureBox.Enabled = true;
                roleFlatComboBox.Enabled = true;
                foodGroupBox.Enabled = true;
            }
        }

        private void CharabaseWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameOpened.SaveCharaBase(Charabases.ToArray());
            GameSupport.SaveTextFile(GameOpened.Files["chara_text"], Charanames);
        }

        private void InsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NewCharabaseWindow newCharabaseWindow = new NewCharabaseWindow(GameOpened, Charanames, modelFlatComboBox.Items.OfType<string>().ToArray()))
            {
                DialogResult result = newCharabaseWindow.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.Focus();
                    characterGroupBox.Enabled = false;
                    
                    Charanames = newCharabaseWindow.Charanames;
                    GameOpened = newCharabaseWindow.GameOpened;
                    ICharabase newCharabase = newCharabaseWindow.NewCharabase;

                    // Generate a base name with a random number
                    string baseName = "base_" + RandomNumber.Next().ToString();
                    uint baseHashUInt = Crc32.Compute(Encoding.GetEncoding("Shift-JIS").GetBytes(baseName));
                    int baseHash = unchecked((int)baseHashUInt);

                    // Check if the generated base hash already exists, generate a new base name if needed
                    while (Charabases.Any(x => x.BaseHash == baseHash))
                    {
                        baseName = "base_" + RandomNumber.Next().ToString();
                        baseHashUInt = Crc32.Compute(Encoding.GetEncoding("Shift-JIS").GetBytes(baseName));
                        baseHash = unchecked((int)baseHashUInt);
                    }

                    newCharabase.BaseHash = baseHash;

                    int lastIndex = Charabases.FindLastIndex(x => x.IsYokai == newCharabase.IsYokai) + 1;
                    Charabases.Insert(lastIndex, newCharabase);

                    // Update available model
                    modelFlatComboBox.Items.Clear();
                    modelFlatComboBox.Items.AddRange(GameOpened.Files["model"].File.Directory.GetFolderFromFullPath(GameOpened.Files["model"].Path).Folders.Select(x => x.Name).ToArray());

                    // Update all names
                    characterListBox.Items.Clear();
                    characterListBox.Items.AddRange(GetNames(Charabases.ToArray()).ToArray());

                    // Select the added charabase
                    characterListBox.Focus();
                    characterListBox.SelectedIndex = lastIndex;
                }
            }

        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (characterListBox.SelectedIndex == -1) return;

            DialogResult dialogResult = MessageBox.Show("Do you want to delete " + characterListBox.SelectedItem.ToString() + "?", "Delete character", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                characterGroupBox.Enabled = false;

                Charabases.Remove(SelectedCharabase);
                facePictureBox.Image = null;

                MessageBox.Show(characterListBox.SelectedItem.ToString() + " has been removed!");

                if (CharabasesFiltred != null && CharabasesFiltred.Count > 0)
                {
                    CharabasesFiltred.Remove(SelectedCharabase);

                    string[] names = GetNames(CharabasesFiltred.ToArray());

                    string focusedText = characterListBox.Text;

                    characterListBox.Items.Clear();
                    characterListBox.Items.AddRange(names);

                    if (names.Contains(focusedText))
                    {
                        characterListBox.SelectedIndex = Array.IndexOf(names, focusedText);
                    }
                }
                else
                {
                    characterListBox.Items.Clear();
                    characterListBox.Items.AddRange(GetNames(Charabases.ToArray()).ToArray());
                }
            }
        }

        private void CharacterListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CharabasesFiltred != null && CharabasesFiltred.Count > 0)
            {
                SelectedCharabase = CharabasesFiltred[characterListBox.SelectedIndex];
            }
            else
            {
                SelectedCharabase = Charabases[characterListBox.SelectedIndex];
            }

            hashTextBox.Text = SelectedCharabase.BaseHash.ToString("X8");

            if (Charanames.Nouns.ContainsKey(SelectedCharabase.NameHash))
            {
                nameTextBox.Text = Charanames.Nouns[SelectedCharabase.NameHash].Strings[0].Text;
            }
            else
            {
                nameTextBox.Clear();
            }

            if (GameOpened.Name == "Yo-Kai Watch 3" && Charadesc.Texts.ContainsKey(SelectedCharabase.DescriptionHash))
            {
                string characterDescription = Charadesc.Texts[SelectedCharabase.DescriptionHash].Strings[0].Text;
                characterDescription = characterDescription.Replace("\\n", Environment.NewLine);
                descriptionTextBox.Text = characterDescription;
            }
            else if (Charanames.Texts.ContainsKey(SelectedCharabase.DescriptionHash))
            {
                string characterDescription = Charanames.Texts[SelectedCharabase.DescriptionHash].Strings[0].Text;
                characterDescription = characterDescription.Replace("\\n", Environment.NewLine);
                descriptionTextBox.Text = characterDescription;
            }
            else
            {
                descriptionTextBox.Clear();
            }

            string fileName = GameSupport.GetFileModelText(SelectedCharabase.FileNamePrefix, SelectedCharabase.FileNameNumber, SelectedCharabase.FileNameVariant);

            if (modelFlatComboBox.Items.IndexOf(fileName) == -1)
            {
                modelFlatComboBox.SelectedIndex = -1;
                modelFlatComboBox.Text = "";
                facePictureBox.Image = null;
            }
            else
            {
                modelFlatComboBox.SelectedItem = fileName;
            }

            baseGroupBox.Enabled = SelectedCharabase.IsYokai;
            foodGroupBox.Enabled = SelectedCharabase.IsYokai && GameOpened.Name != "Yo-Kai Watch Blaster";
            descriptionGroupBox.Enabled = SelectedCharabase.IsYokai;

            if (SelectedCharabase.MedalPosX > -1 && SelectedCharabase.MedalPosY > -1)
            {
                medalXFlatNumericUpDown.Value = SelectedCharabase.MedalPosX;
                medalYFlatNumericUpDown.Value = SelectedCharabase.MedalPosY;
                medalXFlatNumericUpDown.Enabled = true;
                medalYFlatNumericUpDown.Enabled = true;
                SetMedal(true);
            } 
            else
            {
                medalXFlatNumericUpDown.Enabled = false;
                medalYFlatNumericUpDown.Enabled = false;
                medalXFlatNumericUpDown.Value = 0;
                medalYFlatNumericUpDown.Value = 0;
                SetMedal(false);
            }

            if (SelectedCharabase.IsYokai)
            {
                isRareFlatCheckBox.Checked = SelectedCharabase.IsRare;
                isLegendaryFlatCheckBox.Checked = SelectedCharabase.IsLegend;
                isClassicFlatCheckBox.Checked = SelectedCharabase.IsClassic;
                isMericanFlatCheckBox.Checked = SelectedCharabase.IsMerican;
                isDevaFlatCheckBox.Checked = SelectedCharabase.IsDeva;
                isMysteryFlatCheckBox.Checked = SelectedCharabase.IsLegendaryMystery;
                isTreasureFlatCheckBox.Checked = SelectedCharabase.IsTreasure;
                isPionnerFlatCheckBox.Checked = SelectedCharabase.IsPionner;
                isCommandantFlatCheckBox.Checked = SelectedCharabase.IsCommandant;
                SetComboBox(SelectedCharabase.Tribe, GameOpened.Tribes, tribeFlatComboBox);
                SetComboBox(SelectedCharabase.Rank, Ranks.YW, rankFlatComboBox);
                SetComboBox(SelectedCharabase.Role, Roles.YWB, roleFlatComboBox);
                SetComboBox(SelectedCharabase.FavoriteFoodHash, GameOpened.FoodsType, favoritefoodFlatComboBox);
                SetComboBox(SelectedCharabase.HatedFoodHash, GameOpened.FoodsType, hatedFoodFlatComboBox);
            }

            characterGroupBox.Enabled = true;
        }

        private void CharacterListBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = characterListBox.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    characterListBox.SelectedIndex = index;
                }
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!searchTextBox.Focused || searchTextBox.Text == "Search...") return;

            if (searchTextBox.Text == null || searchTextBox.Text == "")
            {
                characterListBox.Items.Clear();
                characterListBox.Items.AddRange(GetNames(Charabases.ToArray()).ToArray());
                CharabasesFiltred = null;
                searchTextBox.Text = "Search...";
            }
            else
            {
                CharabasesFiltred = Charabases
                    .Where(x =>
                        Charanames.Nouns.ContainsKey(x.NameHash) &&
                        Charanames.Nouns[x.NameHash].Strings.Any(s => s.Text.ToLower().Contains(searchTextBox.Text.ToLower())))
                    .ToList();

                string[] names = GetNames(CharabasesFiltred.ToArray());

                string focusedText = characterListBox.Text;

                characterListBox.Items.Clear();
                characterListBox.Items.AddRange(names);

                if (names.Contains(focusedText))
                {
                    characterListBox.SelectedIndex = Array.IndexOf(names, focusedText);
                }
            }
        }

        private void NameTextBox_Click(object sender, EventArgs e)
        {
            Nyanko.Nyanko nyanko = new Nyanko.Nyanko(Path.GetFileName(GameOpened.Files["chara_text"].Path), Charanames, false, true, SelectedCharabase.NameHash);
            nyanko.ShowDialog();
            Charanames = nyanko.T2bþFileOpened;

            // Update current name
            if (nyanko.SelectedHash != 0)
            {
                SelectedCharabase.NameHash = nyanko.SelectedHash;
            }

            // Update all name
            int selectedIndex = characterListBox.SelectedIndex;
            characterListBox.Items.Clear();
            characterListBox.Items.AddRange(GetNames(Charabases.ToArray()));
            characterListBox.SelectedIndex = selectedIndex;
        }

        private void ModelFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modelFlatComboBox.SelectedIndex != -1)
            {
                try
                {
                    byte[] imageData = GameOpened.Files["face_icon"].File.Directory.GetFileFromFullPath(GameOpened.Files["face_icon"].Path + "/" + modelFlatComboBox.SelectedItem.ToString() + ".xi");
                    facePictureBox.Image = IMGC.ToBitmap(imageData);
                }
                catch
                {
                    facePictureBox.Image = null;
                }
            }
            else
            {
                facePictureBox.Image = null;
            }

            if (modelFlatComboBox.Focused && modelFlatComboBox.SelectedIndex != -1)
            {
                (int,int,int) fileName = GameSupport.GetFileModelValue(modelFlatComboBox.SelectedItem.ToString());
                SelectedCharabase.FileNamePrefix = fileName.Item1;
                SelectedCharabase.FileNameNumber = fileName.Item2;
                SelectedCharabase.FileNameVariant = fileName.Item2;
            }
        }

        private void MedalXFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!medalXFlatNumericUpDown.Focused) return;

            SelectedCharabase.MedalPosX = Convert.ToInt32(medalXFlatNumericUpDown.Value);

            SetMedal(true);
        }

        private void MedalYFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!medalYFlatNumericUpDown.Focused) return;

            SelectedCharabase.MedalPosY = Convert.ToInt32(medalYFlatNumericUpDown.Value);

            SetMedal(true);
        }

        private void MedalPictureBox_Click(object sender, EventArgs e)
        {
            int medalSize = -1;

            if (GameOpened.Name == "Yo-Kai Watch 1")
            {
                medalSize = 44;
            } else if (GameOpened.Name == "Yo-Kai Watch 2")
            {
                    medalSize = 44;
            }
            else if (GameOpened.Name == "Yo-Kai Watch 3")
            {
                medalSize = 32;
            }
            else if (GameOpened.Name == "Yo-Kai Watch Blaster")
            {
                medalSize = 44;
            }

            MedalWindow medalWindow = new MedalWindow(FaceIcon, medalSize);
            medalWindow.ShowDialog();

            if (medalWindow.X > -1 && medalWindow.Y > -1)
            {
                SelectedCharabase.MedalPosX = medalWindow.X;
                SelectedCharabase.MedalPosY = medalWindow.Y;
                medalXFlatNumericUpDown.Value = medalWindow.X;
                medalYFlatNumericUpDown.Value = medalWindow.Y;

                SetMedal(true);
            }
        }

        private void IsRareFlatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!isRareFlatCheckBox.Focused) return;

            SelectedCharabase.IsRare = isRareFlatCheckBox.Checked;
        }

        private void IsLegendaryFlatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLegendaryFlatCheckBox.Focused) return;

            SelectedCharabase.IsLegend = isLegendaryFlatCheckBox.Checked;
        }

        private void IsClassicFlatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!isClassicFlatCheckBox.Focused) return;

            SelectedCharabase.IsClassic = isClassicFlatCheckBox.Checked;
        }

        private void IsMericanFlatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!isMericanFlatCheckBox.Focused) return;

            SelectedCharabase.IsMerican = isMericanFlatCheckBox.Checked;
        }

        private void IsDevaFlatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!isDevaFlatCheckBox.Focused) return;

            SelectedCharabase.IsDeva = isDevaFlatCheckBox.Checked;
        }

        private void IsMysteryFlatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!isMysteryFlatCheckBox.Focused) return;

            SelectedCharabase.IsLegendaryMystery = isMysteryFlatCheckBox.Checked;
        }

        private void IsTreasureFlatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!isTreasureFlatCheckBox.Focused) return;

            SelectedCharabase.IsTreasure = isTreasureFlatCheckBox.Checked;
        }

        private void IsPionnerFlatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!isPionnerFlatCheckBox.Focused) return;

            SelectedCharabase.IsPionner = isPionnerFlatCheckBox.Checked;
        }

        private void IsCommandantFlatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!isCommandantFlatCheckBox.Focused) return;

            SelectedCharabase.IsCommandant = isCommandantFlatCheckBox.Checked;
        }

        private void TribeFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tribeFlatComboBox.SelectedIndex == -1)
            {
                tribePictureBox.Image = null;
            }
            else
            {
                string tribeFile = tribeFlatComboBox.SelectedItem.ToString().ToLower().Replace(" ", "_");
                SetPictureBox(tribePictureBox, "Albatross.Resources.Tribe_Icon." + tribeFile + ".png");
            }

            if (!tribeFlatComboBox.Focused) return;

            if (tribeFlatComboBox.SelectedIndex != -1)
            {
                SelectedCharabase.Tribe = GameOpened.Tribes.Values.ToList().IndexOf(tribeFlatComboBox.SelectedItem.ToString());
            }
            else
            {
                SelectedCharabase.Tribe = 0;
            }
        }

        private void RankFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rankFlatComboBox.SelectedIndex == -1)
            {
                rankPictureBox.Image = null;
            } else
            {
                SetPictureBox(rankPictureBox, "Albatross.Resources.Rank_Icon.Rank_" + rankFlatComboBox.SelectedItem.ToString() + ".png");
            }

            if (!rankFlatComboBox.Focused) return;

            if (rankFlatComboBox.SelectedIndex != -1)
            {
                SelectedCharabase.Rank = Ranks.YW.Values.ToList().IndexOf(rankFlatComboBox.SelectedItem.ToString());
            }
            else
            {
                SelectedCharabase.Rank = 0;
            }
        }

        private void RoleFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (roleFlatComboBox.SelectedIndex == -1)
            {
                rolePictureBox.Image = null;
            }
            else
            {
                // To do
            }

            if (!roleFlatComboBox.Focused) return;

            if (roleFlatComboBox.SelectedIndex != -1)
            {
                SelectedCharabase.Role = Roles.YWB.Values.ToList().IndexOf(roleFlatComboBox.SelectedItem.ToString());
            }
            else
            {
                SelectedCharabase.Role = 0;
            }
        }

        private void FavoritefoodFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (favoritefoodFlatComboBox.SelectedIndex == -1)
            {
                favoriteFoodPictureBox.Image = null;
            }
            else
            {
                if (SelectedCharabase.FavoriteFoodHash != 0)
                {
                    string foodType = favoritefoodFlatComboBox.SelectedItem.ToString().Replace(" ", "_").ToLower();
                    SetPictureBox(favoriteFoodPictureBox, "Albatross.Resources.Food_Icon." + foodType + ".png");
                } else
                {
                    SetPictureBox(favoriteFoodPictureBox, "Albatross.Resources.Food_Icon.no_food.png");
                }
            }

            if (!favoritefoodFlatComboBox.Focused) return;

            if (favoritefoodFlatComboBox.SelectedIndex != -1)
            {
                SelectedCharabase.FavoriteFoodHash = GameOpened.FoodsType.Values.ToList().IndexOf(favoritefoodFlatComboBox.SelectedItem.ToString());
            }
            else
            {
                SelectedCharabase.FavoriteFoodHash = 0;
            }
        }

        private void HatedFoodFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hatedFoodFlatComboBox.SelectedIndex == -1)
            {
                hatedFoodPictureBox.Image = null;
            }
            else
            {
                if (SelectedCharabase.HatedFoodHash != 0)
                {
                    string foodType = hatedFoodFlatComboBox.SelectedItem.ToString().Replace(" ", "_").ToLower();
                    SetPictureBox(hatedFoodPictureBox, "Albatross.Resources.Food_Icon." + foodType + ".png");
                }
                else
                {
                    SetPictureBox(hatedFoodPictureBox, "Albatross.Resources.Food_Icon.no_food.png");
                }
            }

            if (!hatedFoodFlatComboBox.Focused) return;

            if (hatedFoodFlatComboBox.SelectedIndex != -1)
            {
                SelectedCharabase.HatedFoodHash = GameOpened.FoodsType.Values.ToList().IndexOf(hatedFoodFlatComboBox.SelectedItem.ToString());
            }
            else
            {
                SelectedCharabase.HatedFoodHash = 0;
            }
        }

        private void DescriptionTextBox_Click(object sender, EventArgs e)
        {
            string fileName = "";

            if (GameOpened.Name == "Yo-Kai Watch 3")
            {
                fileName = "chara_desc_text";
            } else
            {
                fileName = "chara_text";
            }

            Nyanko.Nyanko nyanko = new Nyanko.Nyanko(Path.GetFileName(GameOpened.Files[fileName].Path), Charanames, true, false, SelectedCharabase.DescriptionHash);
            nyanko.ShowDialog();
            Charanames = nyanko.T2bþFileOpened;

            // Update current description
            if (nyanko.SelectedHash != 0)
            {
                SelectedCharabase.DescriptionHash = nyanko.SelectedHash;

                if (Charanames.Texts.ContainsKey(SelectedCharabase.DescriptionHash))
                {
                    string description = Charanames.Texts[SelectedCharabase.DescriptionHash].Strings[0].Text;
                    descriptionTextBox.Text = description.Replace("\\n", Environment.NewLine);
                }
                else
                {
                    descriptionTextBox.Clear();
                }
            }
        }
    }
}
