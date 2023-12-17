using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using Albatross.Level5.Text;
using Albatross.Level5.Image;
using Albatross.Yokai_Watch.Logic;
using Albatross.Yokai_Watch.Games;
using Albatross.Yokai_Watch.Common;

namespace Albatross.Forms.Characters
{
    public partial class CharaparamWindow : Form
    {
        private IGame GameOpened;

        private List<IItem> Items;

        private List<ICharaabilityConfig> Skills;

        private List<IBattleCommand> BattleCommands;

        private List<ICharabase> Charabases;

        private List<ICharaparam> Charaparams;

        private List<ICharaparam> CharaparamsFiltred;

        private ICharaparam SelectedCharaparam;

        private T2bþ Itemnames;

        private T2bþ Abilitynames;

        private T2bþ BattleCommandnames;

        private T2bþ Skillnames;

        private T2bþ Charanames;

        private T2bþ Addmembernames;

        public CharaparamWindow(IGame game)
        {
            GameOpened = game;

            Items = new List<IItem>();
            Skills = new List<ICharaabilityConfig>();
            BattleCommands = new List<IBattleCommand>();
            Charabases = new List<ICharabase>();
            Charaparams = new List<ICharaparam>();
            CharaparamsFiltred = new List<ICharaparam>();

            InitializeComponent();
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

        private string[] GetNames(ICharaparam[] charaparams)
        {
            return charaparams
                .Select((charaparam, index) =>
                {
                    var searchCharabase = Charabases.FirstOrDefault(x => x.BaseHash == charaparam.BaseHash);

                    if (searchCharabase != null && Charanames.Nouns.TryGetValue(searchCharabase.NameHash, out var noun) && noun.Strings.Count > 0)
                    {
                        return noun.Strings[0].Text;
                    }

                    return "Param " + index;
                })
                .ToArray();
        }

        private string[] GetNames(IItem[] items)
        {
            return items
                .Select((item, index) =>
                {
                    return Itemnames.Nouns.TryGetValue(item.NameHash, out var noun) && noun.Strings.Count > 0
                        ? noun.Strings[0].Text
                        : "Item " + index;
                })
                .ToArray();
        }

        private string[] GetNames(ICharaabilityConfig[] skills)
        {
            return skills
                .Select((skill, index) =>
                {
                    return Abilitynames.Nouns.TryGetValue(skill.NameHash, out var noun) && noun.Strings.Count > 0
                        ? noun.Strings[0].Text
                        : "Skill " + index;
                })
                .ToArray();
        }

        private string[] GetNames(IBattleCommand[] battleCommands)
        {
            return battleCommands
                .Select((battleCommand, index) =>
                {
                    if (BattleCommandnames.Nouns.TryGetValue(battleCommand.NameHash, out var noun) && noun.Strings.Count > 0)
                    {
                        return noun.Strings[0].Text;
                    }
                    else if (Skillnames.Nouns.TryGetValue(battleCommand.NameHash, out var skillNoun) && skillNoun.Strings.Count > 0)
                    {
                        return skillNoun.Strings[0].Text;
                    }
                    else if (Itemnames.Nouns.TryGetValue(battleCommand.NameHash, out var itemNoun) && itemNoun.Strings.Count > 0)
                    {
                        return itemNoun.Strings[0].Text;
                    }
                    else
                    {
                        return "Battle Command " + index;
                    }
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

        private void CharaparamWindow_Load(object sender, EventArgs e)
        {
            // Get resources
            Items.AddRange(GameOpened.GetItems("all"));
            Skills.AddRange(GameOpened.GetSkills());
            BattleCommands.AddRange(GameOpened.GetBattleCommands());
            Charabases.AddRange(GameOpened.GetCharacterbase(true));
            Charaparams.AddRange(GameOpened.GetCharaparam());

            // Get names
            Itemnames = new T2bþ(GameOpened.Files["item_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["item_text"].Path));
            Skillnames = new T2bþ(GameOpened.Files["skill_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["skill_text"].Path));
            Abilitynames = new T2bþ(GameOpened.Files["chara_ability_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["chara_ability_text"].Path));
            BattleCommandnames = new T2bþ(GameOpened.Files["battle_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["battle_text"].Path));
            Charanames = new T2bþ(GameOpened.Files["chara_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["chara_text"].Path));
            Addmembernames = new T2bþ(GameOpened.Files["addmembermenu_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["addmembermenu_text"].Path));

            // Prepare combobox 
            tribeFlatComboBox.Items.AddRange(GameOpened.Tribes.Values.ToArray());
            scoutFlatComboBox.Items.AddRange(Ranks.YW.Values.ToArray());
            attackFlatComboBox.Items.AddRange(GetNames(BattleCommands.ToArray()).ToArray());
            techniqueFlatComboBox.Items.AddRange(attackFlatComboBox.Items.Cast<Object>().ToArray());
            inspiritFlatComboBox.Items.AddRange(attackFlatComboBox.Items.Cast<Object>().ToArray());
            soultimateFlatComboBox.Items.AddRange(attackFlatComboBox.Items.Cast<Object>().ToArray());
            skillFlatComboBox.Items.AddRange(GetNames(Skills.ToArray()).ToArray());
            itemFlatComboBox1.Items.AddRange(GetNames(Items.ToArray()).ToArray());
            itemFlatComboBox2.Items.AddRange(itemFlatComboBox1.Items.Cast<Object>().ToArray());
            baseModelFlatComboBox.Items.AddRange(GetNames(Charabases.ToArray()).ToArray());
            characterListBox.Items.AddRange(GetNames(Charaparams.ToArray()).ToArray());
        }

        private void CharaparamWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameOpened.SaveCharaparam(Charaparams.ToArray());
            GameSupport.SaveTextFile(GameOpened.Files["battle_text"], BattleCommandnames);
            GameSupport.SaveTextFile(GameOpened.Files["addmembermenu_text"], Addmembernames);
        }

        private void CharacterListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!characterListBox.Focused) return;

            if (CharaparamsFiltred != null && CharaparamsFiltred.Count > 0)
            {
                SelectedCharaparam = CharaparamsFiltred[characterListBox.SelectedIndex];
            }
            else
            {
                SelectedCharaparam = Charaparams[characterListBox.SelectedIndex];
            }

            hashTextBox.Text = SelectedCharaparam.ParamHash.ToString("X8");

            ICharabase selectedCharabase = Charabases.First(x => x.BaseHash == SelectedCharaparam.BaseHash);

            if (selectedCharabase != null)
            {
                baseModelFlatComboBox.SelectedIndex = Charabases.IndexOf(selectedCharabase);

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
            } else
            {
                baseModelFlatComboBox.SelectedIndex = -1;
            }

            SetComboBox(SelectedCharaparam.Tribe, GameOpened.Tribes, tribeFlatComboBox);
            experienceCurveFlatNumericUpDown.Value = SelectedCharaparam.ExperienceCurve;
            medalFlatNumericUpDown.Value = SelectedCharaparam.MedaliumOffset;
            isShownFlatCheckBox.Checked = SelectedCharaparam.ShowInMedalium;
            itemFlatComboBox1.SelectedIndex = Items.FindIndex(x => x.ItemHash == SelectedCharaparam.Drop1Hash);
            dropFlatNumericUpDown1.Value = SelectedCharaparam.Drop1Rate;
            itemFlatComboBox2.SelectedIndex = Items.FindIndex(x => x.ItemHash == SelectedCharaparam.Drop2Hash);
            dropFlatNumericUpDown2.Value = SelectedCharaparam.Drop2Rate;
            moneyFlatNumericUpDown.Value = SelectedCharaparam.Money;
            experienceFlatNumericUpDown.Value = SelectedCharaparam.Experience;

            minStatFlatNumericUpDown1.Value = SelectedCharaparam.MinHP;
            minStatFlatNumericUpDown2.Value = SelectedCharaparam.MinStrength;
            minStatFlatNumericUpDown3.Value = SelectedCharaparam.MinSpirit;
            minStatFlatNumericUpDown4.Value = SelectedCharaparam.MinDefense;
            minStatFlatNumericUpDown5.Value = SelectedCharaparam.MinSpeed;
            maxStatFlatNumericUpDown1.Value = SelectedCharaparam.MaxHP;
            maxStatFlatNumericUpDown2.Value = SelectedCharaparam.MaxStrength;
            maxStatFlatNumericUpDown3.Value = SelectedCharaparam.MaxSpirit;
            maxStatFlatNumericUpDown4.Value = SelectedCharaparam.MaxDefense;
            maxStatFlatNumericUpDown5.Value = SelectedCharaparam.MaxSpeed;
            attributeFlatNumericUpDown1.Value = Convert.ToDecimal(SelectedCharaparam.AttributeDamageFire);
            attributeFlatNumericUpDown2.Value = Convert.ToDecimal(SelectedCharaparam.AttributeDamageIce);
            attributeFlatNumericUpDown3.Value = Convert.ToDecimal(SelectedCharaparam.AttributeDamageEarth);
            attributeFlatNumericUpDown4.Value = Convert.ToDecimal(SelectedCharaparam.AttributeDamageLigthning);
            attributeFlatNumericUpDown5.Value = Convert.ToDecimal(SelectedCharaparam.AttributeDamageWater);
            attributeFlatNumericUpDown6.Value = Convert.ToDecimal(SelectedCharaparam.AttributeDamageWind);
            attackFlatComboBox.SelectedIndex = BattleCommands.FindIndex(x => x.BattleCommandHash == SelectedCharaparam.AttackHash);
            techniqueFlatComboBox.SelectedIndex = BattleCommands.FindIndex(x => x.BattleCommandHash == SelectedCharaparam.TechniqueHash);
            inspiritFlatComboBox.SelectedIndex = BattleCommands.FindIndex(x => x.BattleCommandHash == SelectedCharaparam.InspiritHash);
            soultimateFlatComboBox.SelectedIndex = BattleCommands.FindIndex(x => x.BattleCommandHash == SelectedCharaparam.SoultimateHash);
            skillFlatComboBox.SelectedIndex = Skills.FindIndex(x => x.CharaabilityConfigHash == SelectedCharaparam.SkillHash);

            if (BattleCommandnames.Texts.ContainsKey(SelectedCharaparam.Quote1))
            {
                eatQuoteTextBox.Text = BattleCommandnames.Texts[SelectedCharaparam.Quote1].Strings[0].Text;
            }
            else
            {
                eatQuoteTextBox.Clear();
            }

            if (BattleCommandnames.Texts.ContainsKey(SelectedCharaparam.Quote2))
            {
                favoriteFoodQuoteTextBox.Text = BattleCommandnames.Texts[SelectedCharaparam.Quote2].Strings[0].Text;
            }
            else
            {
                favoriteFoodQuoteTextBox.Clear();
            }

            if (BattleCommandnames.Texts.ContainsKey(SelectedCharaparam.Quote3))
            {
                hatedFoodQuoteTextBox.Text = BattleCommandnames.Texts[SelectedCharaparam.Quote3].Strings[0].Text;
            }
            else
            {
                hatedFoodQuoteTextBox.Clear();
            }

            if (Addmembernames.Texts.ContainsKey(SelectedCharaparam.Quote4))
            {
                string recruitQuote = Addmembernames.Texts[SelectedCharaparam.Quote4].Strings[0].Text;
                recruitQuote = recruitQuote.Replace("\\n", Environment.NewLine);
                befriendQuoteTextBox.Text = recruitQuote;
            }
            else
            {
                befriendQuoteTextBox.Clear();
            }

            characterGroupBox.Enabled = true;
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!searchTextBox.Focused || searchTextBox.Text == "Search...") return;

            if (searchTextBox.Text == null || searchTextBox.Text == "")
            {
                characterListBox.Items.Clear();
                characterListBox.Items.AddRange(GetNames(Charaparams.ToArray()).ToArray());
                CharaparamsFiltred = null;
                searchTextBox.Text = "Search...";
            }
            else
            {
                CharaparamsFiltred = Charaparams
                    .Where(charaparam =>
                    {
                        var searchCharabase = Charabases.FirstOrDefault(x => x.BaseHash == charaparam.BaseHash);

                        return searchCharabase != null &&
                               Charanames.Nouns.ContainsKey(searchCharabase.NameHash) &&
                               Charanames.Nouns[searchCharabase.NameHash].Strings.Any(s => s.Text.ToLower().Contains(searchTextBox.Text.ToLower()));
                    })
                    .ToList();

                string[] names = GetNames(CharaparamsFiltred.ToArray());

                string focusedText = characterListBox.Text;

                characterListBox.Items.Clear();
                characterListBox.Items.AddRange(names);

                if (names.Contains(focusedText))
                {
                    characterListBox.SelectedIndex = Array.IndexOf(names, focusedText);
                }
            }
        }

        private void BaseModelFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!baseModelFlatComboBox.Focused) return;

            if (baseModelFlatComboBox.SelectedIndex != -1)
            {
                ICharabase charabase = Charabases[baseModelFlatComboBox.SelectedIndex];
                SelectedCharaparam.BaseHash = charabase.BaseHash;
                characterListBox.Items[characterListBox.SelectedIndex] = baseModelFlatComboBox.SelectedItem.ToString(); 
                nameTextBox.Text = characterListBox.Text;

                string fileName = GameSupport.GetFileModelText(charabase.FileNamePrefix, charabase.FileNameNumber, charabase.FileNameVariant);

                try
                {
                    byte[] imageData = GameOpened.Files["face_icon"].File.Directory.GetFileFromFullPath(GameOpened.Files["face_icon"].Path + "/" + fileName + ".xi");
                    facePictureBox.Image = IMGC.ToBitmap(imageData);
                }
                catch
                {
                    facePictureBox.Image = null;
                }
            } else
            {
                SelectedCharaparam.BaseHash = 0;
                characterListBox.Items[characterListBox.SelectedIndex] = "Param " + characterListBox.SelectedIndex;
                nameTextBox.Text = characterListBox.Text;
                facePictureBox.Image = null;
            }
        }

        private void TribeFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tribeFlatComboBox.SelectedIndex == -1)
            {
                tribePictureBox.Image = null;
            }
            else
            {
                if (tribeFlatComboBox.Focused)
                {
                    SelectedCharaparam.Tribe = GameOpened.Tribes.Values.ToList().IndexOf(tribeFlatComboBox.Text);
                }

                SetPictureBox(tribePictureBox, "Albatross.Resources.Tribe_Icon.y_type0" + SelectedCharaparam.Tribe + ".xi.00.png");
            }
        }

        private void ScoutFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!scoutFlatComboBox.Focused) return;
        }

        private void ExperienceCurveFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!experienceCurveFlatNumericUpDown.Focused) return;

            SelectedCharaparam.ExperienceCurve = Convert.ToInt32(experienceCurveFlatNumericUpDown.Value);
        }

        private void MedalFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!medalFlatNumericUpDown.Focused) return;

            SelectedCharaparam.MedaliumOffset = Convert.ToInt32(medalFlatNumericUpDown.Value);
        }

        private void IsShownFlatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!isShownFlatCheckBox.Focused) return;

            SelectedCharaparam.ShowInMedalium = isShownFlatCheckBox.Checked;
        }

        private void EvolutionFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EvolutionFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ItemFlatComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemFlatComboBox1.SelectedIndex == -1)
            {
                itemPictureBox1.Image = null;
                SelectedCharaparam.Drop1Hash = 0;
            }
            else
            {
                IItem item = Items[itemFlatComboBox1.SelectedIndex];

                if (itemFlatComboBox1.Focused)
                {
                    SelectedCharaparam.Drop1Hash = item.ItemHash;
                }

                try
                {
                    string fileName = "item_" + item.ItemNumber.ToString().PadLeft(3, '0');
                    byte[] imageData = GameOpened.Files["item_icon"].File.Directory.GetFileFromFullPath(GameOpened.Files["item_icon"].Path + "/" + fileName + ".xi");
                    itemPictureBox1.Image = IMGC.ToBitmap(imageData);
                }
                catch
                {
                    itemPictureBox1.Image = null;
                }
            }
        }

        private void DropFlatNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!dropFlatNumericUpDown1.Focused) return;

            SelectedCharaparam.Drop1Rate = Convert.ToInt32(dropFlatNumericUpDown1.Value);
        }

        private void ItemFlatComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemFlatComboBox2.SelectedIndex == -1)
            {
                itemPictureBox2.Image = null;
                SelectedCharaparam.Drop2Hash = 0;
            }
            else
            {
                IItem item = Items[itemFlatComboBox2.SelectedIndex];

                if (itemFlatComboBox2.Focused)
                {
                    SelectedCharaparam.Drop2Hash = item.ItemHash;
                }

                try
                {
                    string fileName = "item_" + item.ItemNumber.ToString().PadLeft(3, '0');
                    byte[] imageData = GameOpened.Files["item_icon"].File.Directory.GetFileFromFullPath(GameOpened.Files["item_icon"].Path + "/" + fileName + ".xi");
                    itemPictureBox2.Image = IMGC.ToBitmap(imageData);
                }
                catch
                {
                    itemPictureBox2.Image = null;
                }
            }
        }

        private void DropFlatNumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (!dropFlatNumericUpDown2.Focused) return;

            SelectedCharaparam.Drop2Rate = Convert.ToInt32(dropFlatNumericUpDown2.Value);
        }

        private void MoneyFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!moneyFlatNumericUpDown.Focused) return;

            SelectedCharaparam.Money = Convert.ToInt32(moneyFlatNumericUpDown.Value);
        }

        private void ExperienceFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!experienceFlatNumericUpDown.Focused) return;

            SelectedCharaparam.Experience = Convert.ToInt32(experienceFlatNumericUpDown.Value);
        }

        private void MinStatFlatNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!minStatFlatNumericUpDown1.Focused) return;

            SelectedCharaparam.MinHP = Convert.ToInt32(minStatFlatNumericUpDown1.Value);
        }

        private void MinStatFlatNumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (!minStatFlatNumericUpDown2.Focused) return;

            SelectedCharaparam.MinStrength = Convert.ToInt32(minStatFlatNumericUpDown2.Value);
        }

        private void MinStatFlatNumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (!minStatFlatNumericUpDown3.Focused) return;

            SelectedCharaparam.MinSpirit = Convert.ToInt32(minStatFlatNumericUpDown3.Value);
        }

        private void MinStatFlatNumericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (!minStatFlatNumericUpDown4.Focused) return;

            SelectedCharaparam.MinDefense = Convert.ToInt32(minStatFlatNumericUpDown4.Value);
        }

        private void MinStatFlatNumericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (!minStatFlatNumericUpDown5.Focused) return;

            SelectedCharaparam.MinSpeed = Convert.ToInt32(minStatFlatNumericUpDown5.Value);
        }

        private void MaxStatFlatNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!maxStatFlatNumericUpDown1.Focused) return;

            SelectedCharaparam.MaxHP = Convert.ToInt32(maxStatFlatNumericUpDown1.Value);
        }

        private void MaxStatFlatNumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (!maxStatFlatNumericUpDown2.Focused) return;

            SelectedCharaparam.MaxStrength = Convert.ToInt32(maxStatFlatNumericUpDown2.Value);
        }

        private void MaxStatFlatNumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (!maxStatFlatNumericUpDown3.Focused) return;

            SelectedCharaparam.MaxSpirit = Convert.ToInt32(maxStatFlatNumericUpDown3.Value);
        }

        private void MaxStatFlatNumericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (!maxStatFlatNumericUpDown4.Focused) return;

            SelectedCharaparam.MaxDefense = Convert.ToInt32(maxStatFlatNumericUpDown4.Value);
        }

        private void MaxStatFlatNumericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (!maxStatFlatNumericUpDown5.Focused) return;

            SelectedCharaparam.MaxSpeed = Convert.ToInt32(maxStatFlatNumericUpDown5.Value);
        }

        private void AttributeFlatNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!attributeFlatNumericUpDown1.Focused) return;

            SelectedCharaparam.AttributeDamageFire = Convert.ToInt32(attributeFlatNumericUpDown1.Value);
        }

        private void AttributeFlatNumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (!attributeFlatNumericUpDown2.Focused) return;

            SelectedCharaparam.AttributeDamageIce = Convert.ToInt32(attributeFlatNumericUpDown2.Value);
        }

        private void AttributeFlatNumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (!attributeFlatNumericUpDown3.Focused) return;

            SelectedCharaparam.AttributeDamageEarth = Convert.ToInt32(attributeFlatNumericUpDown3.Value);
        }

        private void AttributeFlatNumericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (!attributeFlatNumericUpDown4.Focused) return;

            SelectedCharaparam.AttributeDamageLigthning = Convert.ToInt32(attributeFlatNumericUpDown4.Value);
        }

        private void AttributeFlatNumericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (!attributeFlatNumericUpDown5.Focused) return;

            SelectedCharaparam.AttributeDamageWater = Convert.ToInt32(attributeFlatNumericUpDown5.Value);
        }

        private void AttributeFlatNumericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            if (!attributeFlatNumericUpDown6.Focused) return;

            SelectedCharaparam.AttributeDamageWind = Convert.ToInt32(attributeFlatNumericUpDown6.Value);
        }

        private void AttackFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!attackFlatComboBox.Focused) return;

            if (attackFlatComboBox.SelectedIndex != -1)
            {
                SelectedCharaparam.AttackHash = 0;
            }
            else
            {
                SelectedCharaparam.AttackHash = BattleCommands[attackFlatComboBox.SelectedIndex].BattleCommandHash;
            }
        }

        private void TechniqueFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!techniqueFlatComboBox.Focused) return;

            if (techniqueFlatComboBox.SelectedIndex != -1)
            {
                SelectedCharaparam.TechniqueHash = 0;
            }
            else
            {
                SelectedCharaparam.TechniqueHash = BattleCommands[techniqueFlatComboBox.SelectedIndex].BattleCommandHash;
            }
        }

        private void InspiritFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!inspiritFlatComboBox.Focused) return;

            if (inspiritFlatComboBox.SelectedIndex != -1)
            {
                SelectedCharaparam.InspiritHash = 0;
            }
            else
            {
                SelectedCharaparam.InspiritHash = BattleCommands[inspiritFlatComboBox.SelectedIndex].BattleCommandHash;
            }
        }

        private void SoultimateFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!soultimateFlatComboBox.Focused) return;

            if (soultimateFlatComboBox.SelectedIndex != -1)
            {
                SelectedCharaparam.SoultimateHash = 0;
            }
            else
            {
                SelectedCharaparam.SoultimateHash = BattleCommands[soultimateFlatComboBox.SelectedIndex].BattleCommandHash;
            }
        }

        private void SkillFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!skillFlatComboBox.Focused) return;

            if (skillFlatComboBox.SelectedIndex != -1)
            {
                SelectedCharaparam.SkillHash = 0;
            }
            else
            {
                SelectedCharaparam.SkillHash = Skills[skillFlatComboBox.SelectedIndex].CharaabilityConfigHash;
            }
        }

        private void EatQuoteTextBox_Click(object sender, EventArgs e)
        {
            Nyanko.Nyanko nyanko = new Nyanko.Nyanko(Path.GetFileName(GameOpened.Files["battle_text"].Path), BattleCommandnames, true, false, SelectedCharaparam.Quote1);
            nyanko.ShowDialog();
            BattleCommandnames = nyanko.T2bþFileOpened;

            if (nyanko.SelectedHash != 0)
            {
                SelectedCharaparam.Quote1 = nyanko.SelectedHash;

                if (BattleCommandnames.Texts.ContainsKey(SelectedCharaparam.Quote1))
                {
                    string quote = BattleCommandnames.Texts[SelectedCharaparam.Quote1].Strings[0].Text;
                    eatQuoteTextBox.Text = quote.Replace("\\n", Environment.NewLine);
                }
                else
                {
                    eatQuoteTextBox.Clear();
                }
            }
        }

        private void FavoriteFoodQuoteTextBox_Click(object sender, EventArgs e)
        {
            Nyanko.Nyanko nyanko = new Nyanko.Nyanko(Path.GetFileName(GameOpened.Files["battle_text"].Path), BattleCommandnames, true, false, SelectedCharaparam.Quote2);
            nyanko.ShowDialog();
            BattleCommandnames = nyanko.T2bþFileOpened;

            if (nyanko.SelectedHash != 0)
            {
                SelectedCharaparam.Quote2 = nyanko.SelectedHash;

                if (BattleCommandnames.Texts.ContainsKey(SelectedCharaparam.Quote2))
                {
                    string quote = BattleCommandnames.Texts[SelectedCharaparam.Quote2].Strings[0].Text;
                    favoriteFoodQuoteTextBox.Text = quote.Replace("\\n", Environment.NewLine);
                }
                else
                {
                    favoriteFoodQuoteTextBox.Clear();
                }
            }
        }

        private void HatedFoodQuoteTextBox_Click(object sender, EventArgs e)
        {
            Nyanko.Nyanko nyanko = new Nyanko.Nyanko(Path.GetFileName(GameOpened.Files["battle_text"].Path), BattleCommandnames, true, false, SelectedCharaparam.Quote3);
            nyanko.ShowDialog();
            BattleCommandnames = nyanko.T2bþFileOpened;

            if (nyanko.SelectedHash != 0)
            {
                SelectedCharaparam.Quote3 = nyanko.SelectedHash;

                if (BattleCommandnames.Texts.ContainsKey(SelectedCharaparam.Quote3))
                {
                    string quote = BattleCommandnames.Texts[SelectedCharaparam.Quote3].Strings[0].Text;
                    hatedFoodQuoteTextBox.Text = quote.Replace("\\n", Environment.NewLine);
                }
                else
                {
                    hatedFoodQuoteTextBox.Clear();
                }
            }
        }

        private void BefriendQuoteTextBox_Click(object sender, EventArgs e)
        {
            Nyanko.Nyanko nyanko = new Nyanko.Nyanko(Path.GetFileName(GameOpened.Files["battle_text"].Path), Addmembernames, true, false, SelectedCharaparam.Quote4);
            nyanko.ShowDialog();
            Addmembernames = nyanko.T2bþFileOpened;

            if (nyanko.SelectedHash != 0)
            {
                SelectedCharaparam.Quote4 = nyanko.SelectedHash;

                if (Addmembernames.Texts.ContainsKey(SelectedCharaparam.Quote4))
                {
                    string quote = Addmembernames.Texts[SelectedCharaparam.Quote4].Strings[0].Text;
                    befriendQuoteTextBox.Text = quote.Replace("\\n", Environment.NewLine);
                }
                else
                {
                    befriendQuoteTextBox.Clear();
                }
            }
        }
    }
}
