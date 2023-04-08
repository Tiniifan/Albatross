using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using Albatross.Tool;
using Albatross.Level5.Text;
using Albatross.Yokai_Watch.Common;
using Albatross.Yokai_Watch.Games;
using Albatross.Yokai_Watch.Games.YW2;
using Albatross.Yokai_Watch.Logic;
using Albatross.Level5.Image;

namespace Albatross
{
    public partial class YokaiWindow : Form
    {
        private IGame Game;

        private Yokai SelectedYokai;

        private List<Yokai> Yokais = new List<Yokai>();

        public YokaiWindow(IGame game)
        {
            InitializeComponent();

            Game = game;
            Yokais = game.GetYokais();
        }

        private void SetComboBox(UInt32 itemID, Dictionary<UInt32, string> dict, ComboBox comboBox)
        {
            if (dict.ContainsKey(itemID))
            {
                comboBox.SelectedIndex = comboBox.Items.IndexOf(dict[itemID]);
            }
            else
            {
                comboBox.SelectedIndex = -1;
            }
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

        private void YokaiWindow_Load(object sender, EventArgs e)
        {
            attackFlatComboBox.DataSource = Game.Attacks.Values.ToArray();
            inspiritFlatComboBox.DataSource = Game.Inspirits.Values.ToArray();
            skillFlatComboBox.DataSource = Game.Skills.Values.ToArray();
            soultimateFlatComboBox.DataSource = Game.Soultimates.Values.ToArray();
            techniqueFlatComboBox.DataSource = Game.Techniques.Values.ToArray();
            itemFlatComboBox1.DataSource = Game.Items.Values.ToArray();
            itemFlatComboBox2.DataSource = Game.Items.Values.ToArray();
            modelFlatComboBox.Items.AddRange(Game.Game.Directory.GetFolderFromFullPath("/data/character/").Folders.Select(x => x.Name).ToArray());
            tribeFlatComboBox.Items.AddRange(Game.Tribes.Values.ToArray());
            rankFlatComboBox.Items.AddRange(Ranks.YW.Values.ToArray());
;
            yokaiListBox.Items.AddRange(Yokais.ToArray());
            evolutionFlatComboBox.Items.AddRange(Yokais.Select(x => x.Name).ToArray());

            yokaiListBox.SelectedIndex = 0;
        }

        private void YokaiListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Prevent to missing index
            if (yokaiListBox.SelectedIndex == -1)
            {
                groupBox1.Enabled = false;
                return;
            }
            else
            {
                groupBox1.Enabled = true;

                SelectedYokai = (Yokai) yokaiListBox.Items[yokaiListBox.SelectedIndex];

                nameTextBox.Text = yokaiListBox.Text;
                paramIDTextBox.Text = SelectedYokai.ParamID.ToString("X8");

                if (modelFlatComboBox.Items.Contains(SelectedYokai.ModelName))
                {
                    modelFlatComboBox.SelectedIndex = modelFlatComboBox.Items.IndexOf(SelectedYokai.ModelName);
                }
                else
                {
                    modelFlatComboBox.SelectedIndex = -1;
                }

                // Base
                SetComboBox(SelectedYokai.Tribe, Game.Tribes, tribeFlatComboBox);
                SetComboBox((uint)SelectedYokai.Rank, Ranks.YW, rankFlatComboBox);
                experienceCurveFlatNumericUpDown.Value = SelectedYokai.ExperienceCurve;
                isRareFlatCheckBox.Checked = SelectedYokai.Statut.IsRare;
                isLegendaryFlatCheckBox.Checked = SelectedYokai.Statut.IsLegendary;

                //Evolution
                evolutionGroupBox.Enabled = false;
                //if (SelectedYokai.Item1.EvolveOffset != -1)
                //{
                //(int, UInt32) evolution = Game.GetEvolution(SelectedYokai.Item1.EvolveOffset);

                //if (evolution != (0, 0))
                //{
                //evolutionGroupBox.Enabled = true;
                //evolutionFlatNumericUpDown.Value = evolution.Item1;
                //evolutionFlatComboBox.SelectedIndex = evolutionFlatComboBox.Items.IndexOf(Game.Yokais[evolution.Item2]);
                //}
                //else
                //{
                //evolutionGroupBox.Enabled = false;
                //evolutionFlatComboBox.SelectedIndex = -1;
                //evolutionFlatNumericUpDown.Value = 0;
                //}
                //}
                //else
                //{
                //evolutionGroupBox.Enabled = false;
                //evolutionFlatComboBox.SelectedIndex = -1;
                //evolutionFlatNumericUpDown.Value = 0;
                // }

                // Drop
                for (int i = 0; i < 2; i++)
                {
                    if (SelectedYokai.DropID != null)
                    {
                        SetComboBox((uint)SelectedYokai.DropID[i], Game.Items, groupBox5.Controls["itemFlatComboBox" + (i + 1)] as ComboBox);
                        (groupBox5.Controls["dropFlatNumericUpDown" + (i + 1)] as NumericUpDown).Value = SelectedYokai.DropRate[i];
                    }
                }
                moneyFlatNumericUpDown.Value = SelectedYokai.Money;
                experienceFlatNumericUpDown.Value = SelectedYokai.Experience;

                // Stat
                for (int i = 0; i < 5; i++)
                {
                    (tabPage2.Controls["minStatFlatNumericUpDown" + (i + 1)] as NumericUpDown).Value = SelectedYokai.MinStat[i];
                    (tabPage2.Controls["maxStatFlatNumericUpDown" + (i + 1)] as NumericUpDown).Value = SelectedYokai.MaxStat[i];
                }

                // Attribute Damage
                for (int i = 0; i < 6; i++)
                {
                    (groupBox3.Controls["attributeFlatNumericUpDown" + (i + 1)] as NumericUpDown).Value = (decimal)SelectedYokai.AttributeDamage[i];
                }

                // Move
                SetComboBox(SelectedYokai.AttackID, Game.Attacks, attackFlatComboBox);
                SetComboBox(SelectedYokai.TechniqueID, Game.Techniques, techniqueFlatComboBox);
                SetComboBox(SelectedYokai.SoultimateID, Game.Soultimates, soultimateFlatComboBox);
                SetComboBox(SelectedYokai.InspiritID, Game.Inspirits, inspiritFlatComboBox);
                SetComboBox(SelectedYokai.SkillID, Game.Skills, skillFlatComboBox);
            }
        }

        private void ModelFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modelFlatComboBox.SelectedIndex == -1)
            {
                pictureBox1.Image = null;
            } else
            {
                if (modelFlatComboBox.Focused)
                {
                    SelectedYokai.ModelName = modelFlatComboBox.Text;
                    Game.SaveYokai(SelectedYokai);
                }

                try
                {
                    byte[] imageData = Game.Game.Directory.GetFileFromFullPath("/data/menu/face_icon/" + SelectedYokai.ModelName + ".xi");
                    pictureBox1.Image = IMGC.ToBitmap(imageData);
                }
                catch (Exception ex)
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private void TribeFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tribeFlatComboBox.SelectedIndex == -1)
            {
                rankPictureBox.Image = null;
            }
            else
            {
                if (tribeFlatComboBox.Focused)
                {
                    SelectedYokai.Tribe = Game.Tribes.Values.ToList().IndexOf(tribeFlatComboBox.Text);
                    Game.SaveYokai(SelectedYokai);
                }

                SetPictureBox(tribePictureBox, "Albatross.Resources.Tribe_Icon.y_type0" + SelectedYokai.Tribe + ".xi.00.png");
            }
        }

        private void RankFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rankFlatComboBox.SelectedIndex == -1)
            {
                rankPictureBox.Image = null;
            } else
            {
                SetPictureBox(rankPictureBox, "Albatross.Resources.Rank_Icon.Rank_" + rankFlatComboBox.Text + ".png");

                if (rankFlatComboBox.Focused)
                {
                    SelectedYokai.Rank = Ranks.YW.Values.ToList().IndexOf(rankFlatComboBox.Text);
                    Game.SaveYokai(SelectedYokai);
                }
            }
        }

        private void ExperienceCurveFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!experienceCurveFlatNumericUpDown.Focused) return;

            SelectedYokai.ExperienceCurve = Convert.ToInt32(experienceCurveFlatNumericUpDown.Value);
            Game.SaveYokai(SelectedYokai);
        }

        private void IsRareFlatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!isRareFlatCheckBox.Focused) return;

            SelectedYokai.Statut.IsRare = isRareFlatCheckBox.Checked;
            Game.SaveYokai(SelectedYokai);
        }

        private void IsLegendaryFlatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLegendaryFlatCheckBox.Focused) return;

            SelectedYokai.Statut.IsLegendary = isLegendaryFlatCheckBox.Checked;
            Game.SaveYokai(SelectedYokai);
        }

        private void EvolutionFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (evolutionFlatComboBox.SelectedIndex == -1)
            {
                evolutionPictureBox.Image = null;
            }
            else
            {
                //(ICharaparam, ICharabase) evolution = Game.GetYokai(yokaiListBox.Items.IndexOf(evolutionFlatComboBox.Text));

                //if (Game.YokaiIcons.Contains(evolution.Item2.ModelName))
                //{

                    //SetPictureBox(evolutionPictureBox, "Albatross.Resources.Yokai_Icon." + evolution.Item2.ModelName + ".xi.00.png");
                //}
                //else
                //{
                    //evolutionPictureBox.Image = null;
                //}

                //if (evolutionFlatComboBox.Focused)
                //{
                //
                //}
            }
        }

        private void SearchTextBox_Click(object sender, EventArgs e)
        {
            if (!searchTextBox.Focused) return;

            if (searchTextBox.Text == "Search...")
            {
                searchTextBox.Clear();
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!searchTextBox.Focused) return;

            if (searchTextBox.Text == null)
            {
                yokaiListBox.Items.Clear();
                yokaiListBox.Items.AddRange(Yokais.Select(x => x.Name).ToArray());
                searchTextBox.Text = "Search...";
            } else
            {
                Yokai[] matchItems = Yokais.Where(x => x.Name.Contains(searchTextBox.Text)).ToArray();
                string focusedText = yokaiListBox.Text;

                yokaiListBox.Items.Clear();
                yokaiListBox.Items.AddRange(matchItems);

                if (matchItems.Any(x => x.Name.Contains(focusedText)))
                {
                    yokaiListBox.SelectedIndex = Array.IndexOf(matchItems, focusedText);
                }
            }
        }

        private void EvolutionFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!evolutionFlatComboBox.Focused) return;
        }

        private void ItemFlatComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!itemFlatComboBox1.Focused) return;

            SelectedYokai.DropID[0] = Game.Items.FirstOrDefault(x => x.Value == itemFlatComboBox1.Text).Key;
            Game.SaveYokai(SelectedYokai);
        }

        private void ItemFlatComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!itemFlatComboBox2.Focused) return;

            SelectedYokai.DropID[1] = Game.Items.FirstOrDefault(x => x.Value == itemFlatComboBox2.Text).Key;
            Game.SaveYokai(SelectedYokai);
        }

        private void DropFlatNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!dropFlatNumericUpDown1.Focused) return;

            SelectedYokai.DropRate[0] = Convert.ToInt32(dropFlatNumericUpDown1.Value);
            Game.SaveYokai(SelectedYokai);
        }

        private void DropFlatNumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (!dropFlatNumericUpDown2.Focused) return;

            SelectedYokai.DropRate[1] = Convert.ToInt32(dropFlatNumericUpDown2.Value);
            Game.SaveYokai(SelectedYokai);
        }

        private void MoneyFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!moneyFlatNumericUpDown.Focused) return;

            SelectedYokai.Money = Convert.ToInt32(moneyFlatNumericUpDown.Value);
            Game.SaveYokai(SelectedYokai);
        }

        private void ExperienceFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!experienceFlatNumericUpDown.Focused) return;

            SelectedYokai.Experience = Convert.ToInt32(experienceFlatNumericUpDown.Value);
            Game.SaveYokai(SelectedYokai);
        }

        private void MinStat_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;

            if (!numericUpDown.Focused) return;

            SelectedYokai.MinStat[Convert.ToInt32(numericUpDown.Name.Replace("minStatFlatNumericUpDown", ""))-1] = Convert.ToInt32(numericUpDown.Value);
            Game.SaveYokai(SelectedYokai);
        }

        private void MaxStat_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;

            if (!numericUpDown.Focused) return;

            SelectedYokai.MaxStat[Convert.ToInt32(numericUpDown.Name.Replace("maxStatFlatNumericUpDown", "")) - 1] = Convert.ToInt32(numericUpDown.Value);
            Game.SaveYokai(SelectedYokai);
        }

        private void AttributeDamage_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;

            if (!numericUpDown.Focused) return;

            SelectedYokai.AttributeDamage[Convert.ToInt32(numericUpDown.Name.Replace("attributeFlatNumericUpDown", "")) - 1] = (float)numericUpDown.Value;
            Game.SaveYokai(SelectedYokai);
        }

        private void AttackFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!attackFlatComboBox.Focused) return;

            SelectedYokai.AttackID = Game.Attacks.FirstOrDefault(x => x.Value == attackFlatComboBox.Text).Key;
            Game.SaveYokai(SelectedYokai);
        }

        private void TechniqueFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!techniqueFlatComboBox.Focused) return;

            SelectedYokai.TechniqueID = Game.Techniques.FirstOrDefault(x => x.Value == techniqueFlatComboBox.Text).Key;
            Game.SaveYokai(SelectedYokai);
        }

        private void SoultimateFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!soultimateFlatComboBox.Focused) return;

            SelectedYokai.SoultimateID = Game.Soultimates.FirstOrDefault(x => x.Value == soultimateFlatComboBox.Text).Key;
            Game.SaveYokai(SelectedYokai);
        }

        private void InspiritFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!inspiritFlatComboBox.Focused) return;

            SelectedYokai.InspiritID = Game.Inspirits.FirstOrDefault(x => x.Value == inspiritFlatComboBox.Text).Key;
            Game.SaveYokai(SelectedYokai);
        }

        private void SkillFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!skillFlatComboBox.Focused) return;

            SelectedYokai.SkillID = Game.Skills.FirstOrDefault(x => x.Value == skillFlatComboBox.Text).Key;
            Game.SaveYokai(SelectedYokai);
        }
    }
}
