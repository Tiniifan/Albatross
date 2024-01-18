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
using YKW1 = Albatross.Yokai_Watch.Games.YW1.Logic;
using YKW2 = Albatross.Yokai_Watch.Games.YW2.Logic;
using YKW3 = Albatross.Yokai_Watch.Games.YW3.Logic;
using YKWB = Albatross.Yokai_Watch.Games.YWB.Logic;

namespace Albatross.Forms.Characters
{
    public partial class CharascaleWindow : Form
    {
        private IGame GameOpened;

        private List<ICharabase> Charabases;

        private List<ICharascale> Charascales;

        private List<ICharascale> CharascalesFiltred;

        private ICharascale SelectedCharascale;

        private T2bþ Charanames;

        public CharascaleWindow(IGame game)
        {
            GameOpened = game;

            Charabases = new List<ICharabase>();
            Charascales = new List<ICharascale>();
            CharascalesFiltred = new List<ICharascale>();

            InitializeComponent();
            LoadCharascale();
        }

        private string[] GetNames(ICharascale[] charascales)
        {
            return charascales
                .Select((charascale, index) =>
                {
                    var searchCharabase = Charabases.FirstOrDefault(x => x.BaseHash == charascale.BaseHash);

                    if (searchCharabase != null && Charanames.Nouns.TryGetValue(searchCharabase.NameHash, out var noun) && noun.Strings.Count > 0)
                    {
                        return noun.Strings[0].Text;
                    }

                    return "Scale " + index;
                })
                .ToArray();
        }

        private void LoadCharascale()
        {
            // Reset form
            characterListBox.Items.Clear();
            facePictureBox.Image = null;
            characterGroupBox.Enabled = false;

            // Get resources
            Charabases.Clear();
            Charabases.AddRange(GameOpened.GetCharacterbase(true));
            Charascales = GameOpened.GetCharascale().ToList();

            // Get names
            Charanames = new T2bþ(GameOpened.Files["chara_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["chara_text"].Path));

            // Prepare combobox 
            characterListBox.Items.AddRange(GetNames(Charascales.ToArray()).ToArray());

            if (GameOpened.Name == "Yo-Kai Watch 1")
            {
                scaleText6.Enabled = false;
                scaleFlatNumericUpDown6.Enabled = false;
            }
            else if (GameOpened.Name == "Yo-Kai Watch 2")
            {
                scaleText6.Enabled = true;
                scaleFlatNumericUpDown6.Enabled = true;
            }
            else if (GameOpened.Name == "Yo-Kai Watch Blaster")
            {
                scaleText5.Enabled = false;
                scaleFlatNumericUpDown5.Enabled = false;
                scaleText6.Enabled = false;
                scaleFlatNumericUpDown6.Enabled = false;
            }
        }

        private void CharascaleWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameOpened.SaveCharascale(Charascales.ToArray());
        }

        private void InsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get all charabase that haven't scale
            foreach (ICharabase charabase in Charabases.Where(x => Charascales.Any(y => y.BaseHash == x.BaseHash) == false).ToArray())
            {
                ICharascale newCharascale = null;

                switch (GameOpened.Name)
                {
                    case "Yo-Kai Watch 1":
                        newCharascale = GameSupport.GetLogic<YKW1.Charascale>();
                        break;
                    case "Yo-Kai Watch 2":
                        newCharascale = GameSupport.GetLogic<YKW2.Charascale>();
                        break;
                    case "Yo-Kai Watch 3":
                        newCharascale = GameSupport.GetLogic<YKW3.Charascale>();
                        break;
                    case "Yo-Kai Watch Blaster":
                        newCharascale = GameSupport.GetLogic<YKWB.Charascale>();
                        break;
                }

                newCharascale.BaseHash = charabase.BaseHash;
                Charascales.Add(newCharascale);
            }

            // Update all names
            characterListBox.Items.Clear();
            characterListBox.Items.AddRange(GetNames(Charascales.ToArray()).ToArray());

            // Select the added charabase
            if (CharascalesFiltred.Count == 0)
            {
                characterListBox.Focus();
                characterListBox.SelectedIndex = characterListBox.Items.Count - 1;
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get all the charascale that have charabase that don't exist
            foreach (ICharascale charascale in Charascales.Where(x => Charabases.Any(y => y.BaseHash == x.BaseHash) == false).ToArray())
            {
                Charascales.Remove(charascale);

                if (CharascalesFiltred != null && CharascalesFiltred.IndexOf(charascale) != -1)
                {
                    CharascalesFiltred.Remove(charascale);
                }
            }

            MessageBox.Show("All the scales that had a charabase that didn't exist have been deleted!");

            characterGroupBox.Enabled = false;
            facePictureBox.Image = null;

            if (CharascalesFiltred != null && CharascalesFiltred.Count > 0)
            {
                string[] names = GetNames(CharascalesFiltred.ToArray());

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
                characterListBox.Items.AddRange(GetNames(Charascales.ToArray()).ToArray());;
            }
        }

        private void CharacterListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!characterListBox.Focused) return;

            if (CharascalesFiltred != null && CharascalesFiltred.Count > 0)
            {
                SelectedCharascale = CharascalesFiltred[characterListBox.SelectedIndex];
            }
            else
            {
                SelectedCharascale = Charascales[characterListBox.SelectedIndex];
            }

            hashTextBox.Text = SelectedCharascale.BaseHash.ToString("X8");

            ICharabase selectedCharabase = Charabases.FirstOrDefault(x => x.BaseHash == SelectedCharascale.BaseHash);

            if (selectedCharabase != null)
            {
                if (Charanames.Nouns.ContainsKey(selectedCharabase.NameHash))
                {
                    nameTextBox.Text = Charanames.Nouns[selectedCharabase.NameHash].Strings[0].Text;
                }
                else
                {
                    nameTextBox.Clear();
                }

                string fileName = GameSupport.GetFileModelText(selectedCharabase.FileNamePrefix, selectedCharabase.FileNameNumber, selectedCharabase.FileNameVariant);

                try
                {
                    byte[] imageData = GameOpened.Files["face_icon"].File.Directory.GetFileFromFullPath(GameOpened.Files["face_icon"].Path + "/" + fileName + ".xi");
                    facePictureBox.Image = IMGC.ToBitmap(imageData);
                }
                catch
                {
                    facePictureBox.Image = null;
                }
            }
            else
            {
                nameTextBox.Text = "";
                facePictureBox.Image = null;
            }

            scaleFlatNumericUpDown1.Value = Convert.ToDecimal(SelectedCharascale.Scale1);
            scaleFlatNumericUpDown2.Value = Convert.ToDecimal(SelectedCharascale.Scale2);
            scaleFlatNumericUpDown3.Value = Convert.ToDecimal(SelectedCharascale.Scale3);
            scaleFlatNumericUpDown4.Value = Convert.ToDecimal(SelectedCharascale.Scale4);
            scaleFlatNumericUpDown5.Value = Convert.ToDecimal(SelectedCharascale.Scale5);
            scaleFlatNumericUpDown6.Value = Convert.ToDecimal(SelectedCharascale.Scale6);

            characterGroupBox.Enabled = true;
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!searchTextBox.Focused || searchTextBox.Text == "Search...") return;

            if (searchTextBox.Text == null || searchTextBox.Text == "")
            {
                characterListBox.Items.Clear();
                characterListBox.Items.AddRange(GetNames(Charascales.ToArray()).ToArray());
                CharascalesFiltred = null;
                searchTextBox.Text = "Search...";
            }
            else
            {
                CharascalesFiltred = Charascales
                    .Where(charaparam =>
                    {
                        var searchCharabase = Charabases.FirstOrDefault(x => x.BaseHash == charaparam.BaseHash);

                        return searchCharabase != null &&
                               Charanames.Nouns.ContainsKey(searchCharabase.NameHash) &&
                               Charanames.Nouns[searchCharabase.NameHash].Strings.Any(s => s.Text.ToLower().Contains(searchTextBox.Text.ToLower()));
                    })
                    .ToList();

                string[] names = GetNames(CharascalesFiltred.ToArray());

                string focusedText = characterListBox.Text;

                characterListBox.Items.Clear();
                characterListBox.Items.AddRange(names);

                if (names.Contains(focusedText))
                {
                    characterListBox.SelectedIndex = Array.IndexOf(names, focusedText);
                }
            }
        }

        private void ScaleFlatNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!scaleFlatNumericUpDown1.Focused) return;

            SelectedCharascale.Scale1 = Convert.ToInt32(scaleFlatNumericUpDown1.Value);
        }

        private void ScaleFlatNumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (!scaleFlatNumericUpDown2.Focused) return;

            SelectedCharascale.Scale2 = Convert.ToInt32(scaleFlatNumericUpDown2.Value);
        }

        private void ScaleFlatNumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (!scaleFlatNumericUpDown3.Focused) return;

            SelectedCharascale.Scale3 = Convert.ToInt32(scaleFlatNumericUpDown3.Value);
        }

        private void ScaleFlatNumericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (!scaleFlatNumericUpDown4.Focused) return;

            SelectedCharascale.Scale4 = Convert.ToInt32(scaleFlatNumericUpDown4.Value);
        }

        private void ScaleFlatNumericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (!scaleFlatNumericUpDown5.Focused) return;

            SelectedCharascale.Scale5 = Convert.ToInt32(scaleFlatNumericUpDown5.Value);
        }

        private void ScaleFlatNumericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            if (!scaleFlatNumericUpDown6.Focused) return;

            SelectedCharascale.Scale6 = Convert.ToInt32(scaleFlatNumericUpDown6.Value);
        }
    }
}
