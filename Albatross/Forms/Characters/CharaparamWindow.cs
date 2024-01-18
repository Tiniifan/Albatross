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

namespace Albatross.Forms.Characters
{
    public partial class CharaparamWindow : Form
    {
        private IGame GameOpened;

        private List<IItem> Items;

        private List<ICharaabilityConfig> Abilities;

        private List<ISkillconfig> Skills;

        private List<IBattleCommand> BattleCommands;

        private List<ICharabase> Charabases;

        private List<ICharaparam> Charaparams;

        private List<IBattleCharaparam> BattleCharaparams;

        private List<IHackslashCharaparam> HackslashCharaparams;

        private List<IHackslashCharaabilityConfig> HackslashAbilities;

        private List<IHackslashTechnic> HackslashTechnics;

        private List<ICharaparam> CharaparamsFiltred;

        private ICharaparam SelectedCharaparam;

        private T2bþ Itemnames;

        private T2bþ Abilitynames;

        private T2bþ BattleCommandnames;

        private T2bþ Skillnames;

        private T2bþ Charanames;

        private T2bþ Addmembernames;

        private T2bþ HackslashAbilitynames;

        private T2bþ HackslashTechnicnames;

        public CharaparamWindow(IGame game)
        {
            GameOpened = game;

            Items = new List<IItem>();
            Abilities = new List<ICharaabilityConfig>();
            Skills = new List<ISkillconfig>();
            BattleCommands = new List<IBattleCommand>();
            Charabases = new List<ICharabase>();
            Charaparams = new List<ICharaparam>();
            BattleCharaparams = new List<IBattleCharaparam>();
            HackslashCharaparams = new List<IHackslashCharaparam>();
            HackslashAbilities = new List<IHackslashCharaabilityConfig>();
            HackslashTechnics = new List<IHackslashTechnic>();
            CharaparamsFiltred = new List<ICharaparam>();

            InitializeComponent();
            LoadCharaparam();
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

        private string[] GetNames(ICharaabilityConfig[] abilities)
        {
            return abilities
                .Select((ability, index) =>
                {
                    return Abilitynames.Nouns.TryGetValue(ability.NameHash, out var noun) && noun.Strings.Count > 0
                        ? noun.Strings[0].Text
                        : "Ability " + index;
                })
                .ToArray();
        }

        private string[] GetNames(ISkillconfig[] skills)
        {
            return skills
                .Select((skill, index) =>
                {
                    return Skillnames.Nouns.TryGetValue(skill.NameHash, out var noun) && noun.Strings.Count > 0
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

        private string[] GetNames(IHackslashCharaabilityConfig[] hackslashAbilities)
        {
            return hackslashAbilities
                .Select((hackslashAbility, index) =>
                {
                    return HackslashAbilitynames.Nouns.TryGetValue(hackslashAbility.NameHash, out var noun) && noun.Strings.Count > 0
                        ? noun.Strings[0].Text
                        : "Ability " + index;
                })
                .ToArray();
        }

        private string[] GetNames(IHackslashTechnic[] hackslashSkills)
        {
            return hackslashSkills
                .Select((hackslashSkill, index) =>
                {
                    return HackslashTechnicnames.Nouns.TryGetValue(hackslashSkill.NameHash, out var noun) && noun.Strings.Count > 0
                        ? noun.Strings[0].Text
                        : "Skill " + index;
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

        private void LoadCharaparam()
        {
            // Reset form
            tribeFlatComboBox.Items.Clear();
            scoutFlatComboBox.Items.Clear();
            attackFlatComboBox.Items.Clear();
            inspiritFlatComboBox.Items.Clear();
            soultimateFlatComboBox.Items.Clear();
            abilityFlatComboBox.Items.Clear();
            itemFlatComboBox1.Items.Clear();
            baseModelFlatComboBox.Items.Clear();
            characterListBox.Items.Clear();
            evolutionFlatComboBox.Items.Clear();
            facePictureBox.Image = null;
            characterGroupBox.Enabled = false;

            // Get resources
            Items.AddRange(GameOpened.GetItems("all"));
            Abilities.AddRange(GameOpened.GetAbilities());

            if (GameOpened.Name == "Yo-Kai Watch 3")
            {
                Skills.AddRange(GameOpened.GetSkills());
                BattleCharaparams.AddRange(GameOpened.GetBattleCharaparam());
                HackslashCharaparams.AddRange(GameOpened.GetHackslashCharaparam());
                HackslashAbilities.AddRange(GameOpened.GetHackslashAbilities());
                HackslashTechnics.AddRange(GameOpened.GetHackslashSkills());
                HackslashAbilitynames = new T2bþ(GameOpened.Files["hackslash_chara_ability_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["hackslash_chara_ability_text"].Path));
                HackslashTechnicnames = new T2bþ(GameOpened.Files["hackslash_technic_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["hackslash_technic_text"].Path));
                attackAFlatComboBox.Items.AddRange(GetNames(HackslashTechnics.ToArray()).ToArray());
                attackXFlatComboBox.Items.AddRange(attackAFlatComboBox.Items.Cast<Object>().ToArray());
                attackYFlatComboBox.Items.AddRange(attackAFlatComboBox.Items.Cast<Object>().ToArray());
                soultimateBlasterTFlatComboBox.Items.AddRange(attackAFlatComboBox.Items.Cast<Object>().ToArray());
                abilityBlasterTFlatComboBox.Items.AddRange(GetNames(HackslashAbilities.ToArray()).ToArray());
            }
            else
            {
                BattleCommands.AddRange(GameOpened.GetBattleCommands());
            }

            Charabases.AddRange(GameOpened.GetCharacterbase(true));
            Charaparams.AddRange(GameOpened.GetCharaparam());
            ICharaevolve[] charaevolves = GameOpened.GetCharaevolution();

            // Get names
            Itemnames = new T2bþ(GameOpened.Files["item_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["item_text"].Path));
            Skillnames = new T2bþ(GameOpened.Files["skill_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["skill_text"].Path));
            Abilitynames = new T2bþ(GameOpened.Files["chara_ability_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["chara_ability_text"].Path));
            BattleCommandnames = new T2bþ(GameOpened.Files["battle_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["battle_text"].Path));
            Charanames = new T2bþ(GameOpened.Files["chara_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["chara_text"].Path));
            Addmembernames = new T2bþ(GameOpened.Files["addmembermenu_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["addmembermenu_text"].Path));

            // Prepare combobox 
            tribeFlatComboBox.Items.AddRange(GameOpened.Tribes.Values.ToArray());
            resistanceFlatComboBox.Items.AddRange(Attributes.YW.Values.ToArray());
            weaknessFlatComboBox.Items.AddRange(Attributes.YW.Values.ToArray());
            scoutFlatComboBox.Items.AddRange(GameOpened.ScoutablesType.Values.ToArray());
            
            if (GameOpened.Name == "Yo-Kai Watch 3")
            {
                attackFlatComboBox.Items.AddRange(GetNames(Skills.ToArray()).ToArray());
            } else
            {
                attackFlatComboBox.Items.AddRange(GetNames(BattleCommands.ToArray()).ToArray());
            }

            techniqueFlatComboBox.Items.AddRange(attackFlatComboBox.Items.Cast<Object>().ToArray());
            inspiritFlatComboBox.Items.AddRange(attackFlatComboBox.Items.Cast<Object>().ToArray());
            soultimateFlatComboBox.Items.AddRange(attackFlatComboBox.Items.Cast<Object>().ToArray());
            abilityFlatComboBox.Items.AddRange(GetNames(Abilities.ToArray()).ToArray());
            itemFlatComboBox1.Items.AddRange(GetNames(Items.ToArray()).ToArray());
            itemFlatComboBox2.Items.AddRange(itemFlatComboBox1.Items.Cast<Object>().ToArray());
            baseModelFlatComboBox.Items.AddRange(GetNames(Charabases.ToArray()).ToArray());
            characterListBox.Items.AddRange(GetNames(Charaparams.ToArray()).ToArray());
            evolutionFlatComboBox.Items.AddRange(characterListBox.Items.Cast<Object>().ToArray());

            // Link charaevolve to charaparam
            foreach(ICharaparam charaparamsWithEvolve in Charaparams.Where(x => x.EvolveOffset != -1).ToArray())
            {
                ICharaevolve charaevolve = charaevolves[charaparamsWithEvolve.EvolveOffset];
                charaparamsWithEvolve.EvolveParam = charaevolve.ParamHash;
                charaparamsWithEvolve.EvolveLevel = charaevolve.Level;
            }

            if (GameOpened.Name == "Yo-Kai Watch 1")
            {
                label8.Enabled = true;
                tribePictureBox.Enabled = true;
                tribeFlatComboBox.Enabled = true;
                label13.Enabled = false;
                scoutFlatComboBox.Enabled = false;
                label21.Enabled = false;
                maxStatFlatNumericUpDown1.Enabled = false;
                maxStatFlatNumericUpDown2.Enabled = false;
                maxStatFlatNumericUpDown3.Enabled = false;
                maxStatFlatNumericUpDown4.Enabled = false;
                maxStatFlatNumericUpDown5.Enabled = false;
                label44.Visible = false;
                waitTimeFlatNumericUpDown.Visible = false;
                vsTabControl2.TabPages.RemoveAt(1);
                vsTabControl2.TabPages.RemoveAt(1);
                label42.Visible = false;
                pictureBox1.Visible = false;
                resistanceFlatComboBox.Visible = false;
                label43.Visible = false;
                weaknessFlatComboBox.Visible = false;
            }
            else if (GameOpened.Name == "Yo-Kai Watch 2")
            {
                label8.Enabled = false;
                tribePictureBox.Enabled = false;
                tribeFlatComboBox.Enabled = false;
                label13.Enabled = true;
                scoutFlatComboBox.Enabled = true;
                maxStatFlatNumericUpDown1.Enabled = true;
                maxStatFlatNumericUpDown2.Enabled = true;
                maxStatFlatNumericUpDown3.Enabled = true;
                maxStatFlatNumericUpDown4.Enabled = true;
                maxStatFlatNumericUpDown5.Enabled = true;
                label44.Visible = false;
                waitTimeFlatNumericUpDown.Visible = false;
                vsTabControl2.TabPages.RemoveAt(1);
                vsTabControl2.TabPages.RemoveAt(1);
                label42.Visible = false;
                pictureBox1.Visible = false;
                resistanceFlatComboBox.Visible = false;
                label43.Visible = false;
                weaknessFlatComboBox.Visible = false;
            }
            else if (GameOpened.Name == "Yo-Kai Watch 3")
            {
                label44.Visible = true;
                waitTimeFlatNumericUpDown.Visible = true;
                label8.Enabled = false;
                tribePictureBox.Enabled = false;
                tribeFlatComboBox.Enabled = false;
                label13.Enabled = true;
                scoutFlatComboBox.Enabled = true;
                maxStatFlatNumericUpDown1.Enabled = true;
                maxStatFlatNumericUpDown2.Enabled = true;
                maxStatFlatNumericUpDown3.Enabled = true;
                maxStatFlatNumericUpDown4.Enabled = true;
                maxStatFlatNumericUpDown5.Enabled = true;
                label36.Visible = false;
                attributeFlatNumericUpDown1.Visible = false;
                label35.Visible = false;
                attributeFlatNumericUpDown2.Visible = false;
                label34.Visible = false;
                attributeFlatNumericUpDown3.Visible = false;
                label33.Visible = false;
                attributeFlatNumericUpDown4.Visible = false;
                label32.Visible = false;
                attributeFlatNumericUpDown5.Visible = false;
                label31.Visible = false;
                attributeFlatNumericUpDown6.Visible = false;
                vsTabControl2.TabPages.RemoveAt(1);
                eatGroupBox.Enabled = false;
                favoriteFoodGroupBox.Enabled = false;
                hatedFoodGroupBox.Enabled = false;
            }
        }

        private void CharaparamWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Generate charaevolves array
            List<ICharaevolve> charaevolves = new List<ICharaevolve>() { };

            // Loop through Charaparams with non-zero ParamHash
            foreach (ICharaparam charaparamWithEvolve in Charaparams.Where(x => x.ParamHash != 0).ToArray())
            {
                ICharaevolve charaevolve = null;

                // Determine the game type and get the corresponding Charaevolve logic
                switch (GameOpened.Name)
                {
                    case "Yo-Kai Watch 1":
                        charaevolve = GameSupport.GetLogic<YKW1.Charaevolve>();
                        break;
                    case "Yo-Kai Watch 2":
                        charaevolve = GameSupport.GetLogic<YKW2.Charaevolve>();
                        break;
                    case "Yo-Kai Watch 3":
                        charaevolve = GameSupport.GetLogic<YKW3.Charaevolve>();
                        break;
                }

                // Assign values to charaevolve properties
                charaevolve.ParamHash = charaparamWithEvolve.EvolveParam;
                charaevolve.Level = charaparamWithEvolve.EvolveLevel;
                charaparamWithEvolve.EvolveOffset = charaevolves.Count();

                // Add charaevolve to the charaevolves list
                charaevolves.Add(charaevolve);
            }

            // Save Charaparams and charaevolves arrays to the game
            GameOpened.SaveCharaparam(Charaparams.ToArray());
            GameOpened.SaveCharaevolution(charaevolves.ToArray());
            GameOpened.SaveBattleCharaparam(BattleCharaparams.ToArray());
            GameOpened.SaveHackslashCharaparam(HackslashCharaparams.ToArray());

            // Save text files related to battle and member commands
            GameSupport.SaveTextFile(GameOpened.Files["battle_text"], BattleCommandnames);
            GameSupport.SaveTextFile(GameOpened.Files["addmembermenu_text"], Addmembernames);
        }


        private void InsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICharaparam newCharaparam = null;

            switch (GameOpened.Name)
            {
                case "Yo-Kai Watch 1":
                    newCharaparam = GameSupport.GetLogic<YKW1.Charaparam>();
                    break;
                case "Yo-Kai Watch 2":
                    newCharaparam = GameSupport.GetLogic<YKW2.Charaparam>();
                    break;
                case "Yo-Kai Watch 3":
                    newCharaparam = GameSupport.GetLogic<YKW3.Charaparam>();
                    break;
            }

            // Generate a param name with a random number
            string paramName = "param_" + RandomNumber.Next().ToString();
            uint paramHashUInt = Crc32.Compute(Encoding.GetEncoding("Shift-JIS").GetBytes(paramName));
            int paramHash = unchecked((int)paramHashUInt);

            // Check if the generated base hash already exists, generate a new base name if needed
            while (Charaparams.Any(x => x.ParamHash == paramHash))
            {
                paramName = "param_" + RandomNumber.Next().ToString();
                paramHashUInt = Crc32.Compute(Encoding.GetEncoding("Shift-JIS").GetBytes(paramName));
                paramHash = unchecked((int)paramHashUInt);
            }

            newCharaparam.ParamHash = paramHash;
            newCharaparam.EvolveOffset = -1;
;
            Charaparams.Add(newCharaparam);

            // Automatically adds additional data for YKW3
            if (GameOpened.Name == "Yo-Kai Watch 3")
            {
                IBattleCharaparam battleCharaparam = GameSupport.GetLogic<YKW3.BattleCharaparam>();
                IHackslashCharaparam hackslashCharaparam = GameSupport.GetLogic<YKW3.HackslashCharaparam>();

                battleCharaparam.ParamHash = paramHash;
                hackslashCharaparam.ParamHash = paramHash;

                BattleCharaparams.Add(battleCharaparam);
                HackslashCharaparams.Add(hackslashCharaparam);
            }

            // Update all names
            characterListBox.Items.Clear();
            evolutionFlatComboBox.Items.Clear();
            characterListBox.Items.AddRange(GetNames(Charaparams.ToArray()).ToArray());
            evolutionFlatComboBox.Items.AddRange(characterListBox.Items.Cast<Object>().ToArray());

            // Select the added charabase
            if (CharaparamsFiltred.Count == 0)
            {
                characterListBox.Focus();
                characterListBox.SelectedIndex = characterListBox.Items.Count - 1;
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (characterListBox.SelectedIndex == -1) return;

            DialogResult dialogResult = MessageBox.Show("Do you want to delete " + characterListBox.SelectedItem.ToString() + "?", "Delete character", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                characterGroupBox.Enabled = false;

                Charaparams.Remove(SelectedCharaparam);

                // Remove additional data for YKW3
                if (GameOpened.Name == "Yo-Kai Watch 3")
                {
                    IBattleCharaparam selectedBattleParam = BattleCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);
                    IHackslashCharaparam selectedHackslashCharaparam = HackslashCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

                    if (selectedBattleParam != null)
                    {
                        BattleCharaparams.Remove(selectedBattleParam);
                    }

                    if (selectedHackslashCharaparam != null)
                    {
                        HackslashCharaparams.Remove(selectedHackslashCharaparam);
                    }
                }

                facePictureBox.Image = null;

                MessageBox.Show(characterListBox.SelectedItem.ToString() + " has been removed!");

                if (CharaparamsFiltred != null && CharaparamsFiltred.Count > 0)
                {
                    CharaparamsFiltred.Remove(SelectedCharaparam);

                    string[] names = GetNames(CharaparamsFiltred.ToArray());

                    string focusedText = characterListBox.Text;

                    characterListBox.Items.Clear();
                    evolutionFlatComboBox.Items.Clear();
                    characterListBox.Items.AddRange(names);
                    evolutionFlatComboBox.Items.AddRange(GetNames(Charaparams.ToArray()).ToArray());

                    if (names.Contains(focusedText))
                    {
                        characterListBox.SelectedIndex = Array.IndexOf(names, focusedText);
                    }
                }
                else
                {
                    characterListBox.Items.Clear();
                    evolutionFlatComboBox.Items.Clear();
                    characterListBox.Items.AddRange(GetNames(Charaparams.ToArray()).ToArray());
                    evolutionFlatComboBox.Items.AddRange(characterListBox.Items.Cast<Object>().ToArray());
                }
            }
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

            ICharabase selectedCharabase = Charabases.FirstOrDefault(x => x.BaseHash == SelectedCharaparam.BaseHash);
            IBattleCharaparam selectedBattleParam = BattleCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);
            IHackslashCharaparam selectedHackslashCharaparam = HackslashCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

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
            } 
            else
            {
                baseModelFlatComboBox.SelectedIndex = -1;
                nameTextBox.Text = "";
                facePictureBox.Image = null;
            }

            SetComboBox(SelectedCharaparam.Tribe, GameOpened.Tribes, tribeFlatComboBox);
            SetComboBox(SelectedCharaparam.ScoutableHash, GameOpened.ScoutablesType, scoutFlatComboBox);
            SetComboBox(SelectedCharaparam.Strongest, Attributes.YW, resistanceFlatComboBox);
            SetComboBox(SelectedCharaparam.Weakness, Attributes.YW, weaknessFlatComboBox);
            experienceCurveFlatNumericUpDown.Value = SelectedCharaparam.ExperienceCurve;
            waitTimeFlatNumericUpDown.Value = SelectedCharaparam.WaitTime;
            medalFlatNumericUpDown.Value = SelectedCharaparam.MedaliumOffset;
            isShownFlatCheckBox.Checked = SelectedCharaparam.ShowInMedalium;
            if (SelectedCharaparam.EvolveParam != 0)
            {
                evolutionFlatComboBox.SelectedIndex = Charaparams.FindIndex(x => x.ParamHash == SelectedCharaparam.EvolveParam);
                evolutionFlatNumericUpDown.Value = SelectedCharaparam.EvolveLevel;

                label27.Enabled = true;
                evolutionFlatNumericUpDown.Enabled = true;
            } else
            {
                evolutionFlatComboBox.SelectedIndex = -1;
                evolutionFlatComboBox.Text = "";
                evolutionFlatNumericUpDown.Value = 0;

                label27.Enabled = false;
                evolutionFlatNumericUpDown.Enabled = false;
                evolutionPictureBox.Image = null;
            }

            // Item & Experience & Money
            if (GameOpened.Name == "Yo-Kai Watch 3")
            {
                if (selectedBattleParam != null)
                {
                    itemFlatComboBox1.SelectedIndex = Items.FindIndex(x => x.ItemHash == selectedBattleParam.Drop1Hash);
                    dropFlatNumericUpDown1.Value = selectedBattleParam.Drop1Rate;
                    itemFlatComboBox2.SelectedIndex = Items.FindIndex(x => x.ItemHash == selectedBattleParam.Drop2Hash);
                    dropFlatNumericUpDown2.Value = selectedBattleParam.Drop2Rate;
                    moneyFlatNumericUpDown.Value = selectedBattleParam.Money;
                    experienceFlatNumericUpDown.Value = selectedBattleParam.Experience;
                }
            } else
            {
                itemFlatComboBox1.SelectedIndex = Items.FindIndex(x => x.ItemHash == SelectedCharaparam.Drop1Hash);
                dropFlatNumericUpDown1.Value = SelectedCharaparam.Drop1Rate;
                itemFlatComboBox2.SelectedIndex = Items.FindIndex(x => x.ItemHash == SelectedCharaparam.Drop2Hash);
                dropFlatNumericUpDown2.Value = SelectedCharaparam.Drop2Rate;
                moneyFlatNumericUpDown.Value = SelectedCharaparam.Money;
                experienceFlatNumericUpDown.Value = SelectedCharaparam.Experience;
            }

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

            if (GameOpened.Name == "Yo-Kai Watch 3")
            {
                attackFlatComboBox.SelectedIndex = Skills.FindIndex(x => x.SkillHash == SelectedCharaparam.AttackHash);
                techniqueFlatComboBox.SelectedIndex = Skills.FindIndex(x => x.SkillHash == SelectedCharaparam.TechniqueHash);
                inspiritFlatComboBox.SelectedIndex = Skills.FindIndex(x => x.SkillHash == SelectedCharaparam.InspiritHash);
                soultimateFlatComboBox.SelectedIndex = Skills.FindIndex(x => x.SkillHash == SelectedCharaparam.SoultimateHash);

                // Blaster T
                if (selectedHackslashCharaparam != null)
                {
                    attackAFlatComboBox.SelectedIndex = HackslashTechnics.FindIndex(x => x.HackslashTechnicHash == selectedHackslashCharaparam.AttackAHash);
                    attackXFlatComboBox.SelectedIndex = HackslashTechnics.FindIndex(x => x.HackslashTechnicHash == selectedHackslashCharaparam.AttackXHash);
                    attackYFlatComboBox.SelectedIndex = HackslashTechnics.FindIndex(x => x.HackslashTechnicHash == selectedHackslashCharaparam.AttackYHash);
                    soultimateBlasterTFlatComboBox.SelectedIndex = HackslashTechnics.FindIndex(x => x.HackslashTechnicHash == selectedHackslashCharaparam.SoultimateHash);
                    abilityBlasterTFlatComboBox.SelectedIndex = HackslashAbilities.FindIndex(x => x.CharaabilityConfigHash == selectedHackslashCharaparam.SkillHash);
                }
            }
            else
            {
                attackFlatComboBox.SelectedIndex = BattleCommands.FindIndex(x => x.BattleCommandHash == SelectedCharaparam.AttackHash);
                techniqueFlatComboBox.SelectedIndex = BattleCommands.FindIndex(x => x.BattleCommandHash == SelectedCharaparam.TechniqueHash);
                inspiritFlatComboBox.SelectedIndex = BattleCommands.FindIndex(x => x.BattleCommandHash == SelectedCharaparam.InspiritHash);
                soultimateFlatComboBox.SelectedIndex = BattleCommands.FindIndex(x => x.BattleCommandHash == SelectedCharaparam.SoultimateHash);
            }

            abilityFlatComboBox.SelectedIndex = Abilities.FindIndex(x => x.CharaabilityConfigHash == SelectedCharaparam.AbilityHash);

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

            if (Addmembernames.Texts.ContainsKey(SelectedCharaparam.BefriendQuote))
            {
                string recruitQuote = Addmembernames.Texts[SelectedCharaparam.BefriendQuote].Strings[0].Text;
                recruitQuote = recruitQuote.Replace("\\n", Environment.NewLine);
                befriendQuoteTextBox.Text = recruitQuote;
            }
            else
            {
                befriendQuoteTextBox.Clear();
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
                string tribeFile = tribeFlatComboBox.SelectedItem.ToString().ToLower().Replace(" ", "_");
                SetPictureBox(tribePictureBox, "Albatross.Resources.Tribe_Icon." + tribeFile + ".png");
            }

            if (!tribeFlatComboBox.Focused) return;

            if (tribeFlatComboBox.SelectedIndex != -1)
            {
                SelectedCharaparam.Tribe = Ranks.YW.Values.ToList().IndexOf(tribeFlatComboBox.SelectedItem.ToString());
            }
            else
            {
                SelectedCharaparam.Tribe = 0;
            }
        }

        private void ScoutFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!scoutFlatComboBox.Focused) return;

            SelectedCharaparam.ScoutableHash = GameOpened.ScoutablesType.Values.ToList().IndexOf(scoutFlatComboBox.SelectedItem.ToString());
        }

        private void ExperienceCurveFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!experienceCurveFlatNumericUpDown.Focused) return;

            SelectedCharaparam.ExperienceCurve = Convert.ToInt32(experienceCurveFlatNumericUpDown.Value);
        }

        private void WaitTimeFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!waitTimeFlatNumericUpDown.Focused) return;

            SelectedCharaparam.WaitTime = Convert.ToInt32(waitTimeFlatNumericUpDown.Value);
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
            if (evolutionFlatComboBox.SelectedIndex == -1)
            {
                evolutionPictureBox.Image = null;
                evolutionFlatComboBox.Text = "";
            }
            else
            {
                ICharaparam charaparam = Charaparams[evolutionFlatComboBox.SelectedIndex];
                ICharabase charabase = Charabases.FirstOrDefault(x => x.BaseHash == charaparam.BaseHash);

                if (charabase != null)
                {
                    string fileName = GameSupport.GetFileModelText(charabase.FileNamePrefix, charabase.FileNameNumber, charabase.FileNameVariant);

                    try
                    {
                        byte[] imageData = GameOpened.Files["face_icon"].File.Directory.GetFileFromFullPath(GameOpened.Files["face_icon"].Path + "/" + fileName + ".xi");
                        evolutionPictureBox.Image = IMGC.ToBitmap(imageData);
                    }
                    catch
                    {
                        evolutionPictureBox.Image = null;
                    }
                }
            }

            if (!evolutionFlatComboBox.Focused) return;

            if (evolutionFlatComboBox.SelectedIndex != -1)
            {
                SelectedCharaparam.EvolveParam = Charaparams[evolutionFlatComboBox.SelectedIndex].ParamHash;
                evolutionFlatNumericUpDown.Enabled = true;
            }
            else
            {
                SelectedCharaparam.EvolveOffset = -1;
                SelectedCharaparam.EvolveParam = 0;
                SelectedCharaparam.EvolveLevel = 0;
                evolutionFlatNumericUpDown.Value = 0;
                evolutionFlatNumericUpDown.Enabled = false;
            }
        }

        private void EvolutionFlatComboBox_TextChanged(object sender, EventArgs e)
        {
            if (!evolutionFlatComboBox.Focused) return;

            if (string.IsNullOrEmpty(evolutionFlatComboBox.Text))
            {
                SelectedCharaparam.EvolveOffset = -1;
                SelectedCharaparam.EvolveParam = 0;
                SelectedCharaparam.EvolveLevel = 0;
                evolutionFlatNumericUpDown.Value = 0;
                evolutionFlatNumericUpDown.Enabled = false;
                evolutionPictureBox.Image = null;
            }
        }

        private void EvolutionFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!evolutionFlatNumericUpDown.Focused) return;

            SelectedCharaparam.EvolveLevel = Convert.ToInt32(evolutionFlatNumericUpDown.Value);
        }

        private void ItemFlatComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IBattleCharaparam selectedBattleParam = BattleCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

            if (itemFlatComboBox1.SelectedIndex == -1)
            {
                itemPictureBox1.Image = null;
                SelectedCharaparam.Drop1Hash = 0;

                if (selectedBattleParam != null)
                {
                    selectedBattleParam.Drop1Hash = 0;
                }
            }
            else
            {
                IItem item = Items[itemFlatComboBox1.SelectedIndex];

                if (itemFlatComboBox1.Focused)
                {
                    SelectedCharaparam.Drop1Hash = item.ItemHash;

                    if (selectedBattleParam != null)
                    {
                        selectedBattleParam.Drop1Hash = item.ItemHash;
                    }
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

            IBattleCharaparam selectedBattleParam = BattleCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

            if (selectedBattleParam != null)
            {
                selectedBattleParam.Drop1Rate = Convert.ToInt32(dropFlatNumericUpDown1.Value);
            }

            SelectedCharaparam.Drop1Rate = Convert.ToInt32(dropFlatNumericUpDown1.Value);
        }

        private void ItemFlatComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            IBattleCharaparam selectedBattleParam = BattleCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

            if (itemFlatComboBox2.SelectedIndex == -1)
            {
                itemPictureBox2.Image = null;
                SelectedCharaparam.Drop2Hash = 0;

                if (selectedBattleParam != null)
                {
                    selectedBattleParam.Drop2Hash = 0;
                }
            }
            else
            {
                IItem item = Items[itemFlatComboBox2.SelectedIndex];

                if (itemFlatComboBox2.Focused)
                {
                    SelectedCharaparam.Drop2Hash = item.ItemHash;

                    if (selectedBattleParam != null)
                    {
                        selectedBattleParam.Drop2Hash = item.ItemHash;
                    }
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

            IBattleCharaparam selectedBattleParam = BattleCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

            if (selectedBattleParam != null)
            {
                selectedBattleParam.Drop2Rate = Convert.ToInt32(dropFlatNumericUpDown2.Value);
            }

            SelectedCharaparam.Drop2Rate = Convert.ToInt32(dropFlatNumericUpDown2.Value);
        }

        private void MoneyFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!moneyFlatNumericUpDown.Focused) return;

            IBattleCharaparam selectedBattleParam = BattleCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

            if (selectedBattleParam != null)
            {
                selectedBattleParam.Money = Convert.ToInt32(moneyFlatNumericUpDown.Value);
            }

            SelectedCharaparam.Money = Convert.ToInt32(moneyFlatNumericUpDown.Value);
        }

        private void ExperienceFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!experienceFlatNumericUpDown.Focused) return;

            IBattleCharaparam selectedBattleParam = BattleCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

            if (selectedBattleParam != null)
            {
                selectedBattleParam.Experience = Convert.ToInt32(experienceFlatNumericUpDown.Value);
            }

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

        private void ResistanceFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!resistanceFlatComboBox.Focused) return;

            SelectedCharaparam.Strongest = Attributes.YW.Values.ToList().IndexOf(resistanceFlatComboBox.SelectedItem.ToString());
        }

        private void WeaknessFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!weaknessFlatComboBox.Focused) return;

            SelectedCharaparam.Weakness = Attributes.YW.Values.ToList().IndexOf(weaknessFlatComboBox.SelectedItem.ToString());
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

            if (attackFlatComboBox.SelectedIndex == -1)
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

            if (techniqueFlatComboBox.SelectedIndex == -1)
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

            if (inspiritFlatComboBox.SelectedIndex == -1)
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

            if (soultimateFlatComboBox.SelectedIndex == -1)
            {
                SelectedCharaparam.SoultimateHash = 0;
            }
            else
            {
                SelectedCharaparam.SoultimateHash = BattleCommands[soultimateFlatComboBox.SelectedIndex].BattleCommandHash;
            }
        }

        private void AbilityFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!abilityFlatComboBox.Focused) return;

            if (abilityFlatComboBox.SelectedIndex == -1)
            {
                SelectedCharaparam.AbilityHash = 0;
            }
            else
            {
                SelectedCharaparam.AbilityHash = Abilities[abilityFlatComboBox.SelectedIndex].CharaabilityConfigHash;
            }
        }

        private void AttackAFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!attackAFlatComboBox.Focused) return;

            IHackslashCharaparam selectedHackslashCharaparam = HackslashCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

            if (selectedHackslashCharaparam != null)
            {
                if (attackAFlatComboBox.SelectedIndex == -1)
                {
                    selectedHackslashCharaparam.AttackAHash = 0;
                }
                else
                {
                    selectedHackslashCharaparam.AttackAHash = HackslashTechnics[attackAFlatComboBox.SelectedIndex].HackslashTechnicHash;
                }
            }
        }

        private void AttackXFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!attackXFlatComboBox.Focused) return;

            IHackslashCharaparam selectedHackslashCharaparam = HackslashCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

            if (selectedHackslashCharaparam != null)
            {
                if (attackXFlatComboBox.SelectedIndex == -1)
                {
                    selectedHackslashCharaparam.AttackXHash = 0;
                }
                else
                {
                    selectedHackslashCharaparam.AttackXHash = HackslashTechnics[attackXFlatComboBox.SelectedIndex].HackslashTechnicHash;
                }
            }
        }

        private void AttackYFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!attackYFlatComboBox.Focused) return;

            IHackslashCharaparam selectedHackslashCharaparam = HackslashCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

            if (selectedHackslashCharaparam != null)
            {
                if (attackYFlatComboBox.SelectedIndex == -1)
                {
                    selectedHackslashCharaparam.AttackYHash = 0;
                }
                else
                {
                    selectedHackslashCharaparam.AttackYHash = HackslashTechnics[attackYFlatComboBox.SelectedIndex].HackslashTechnicHash;
                }
            }
        }

        private void SoultimateBlasterTFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!soultimateBlasterTFlatComboBox.Focused) return;

            IHackslashCharaparam selectedHackslashCharaparam = HackslashCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

            if (selectedHackslashCharaparam != null)
            {
                if (soultimateBlasterTFlatComboBox.SelectedIndex == -1)
                {
                    selectedHackslashCharaparam.SoultimateHash = 0;
                }
                else
                {
                    selectedHackslashCharaparam.SoultimateHash = HackslashTechnics[soultimateBlasterTFlatComboBox.SelectedIndex].HackslashTechnicHash;
                }
            }
        }

        private void AbilityBlasterTFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!abilityBlasterTFlatComboBox.Focused) return;

            IHackslashCharaparam selectedHackslashCharaparam = HackslashCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

            if (selectedHackslashCharaparam != null)
            {
                if (abilityBlasterTFlatComboBox.SelectedIndex == -1)
                {
                    selectedHackslashCharaparam.SkillHash = 0;
                }
                else
                {
                    selectedHackslashCharaparam.SkillHash = HackslashAbilities[abilityBlasterTFlatComboBox.SelectedIndex].CharaabilityConfigHash;
                }
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
            Nyanko.Nyanko nyanko = new Nyanko.Nyanko(Path.GetFileName(GameOpened.Files["battle_text"].Path), Addmembernames, true, false, SelectedCharaparam.BefriendQuote);
            nyanko.ShowDialog();
            Addmembernames = nyanko.T2bþFileOpened;

            if (nyanko.SelectedHash != 0)
            {
                SelectedCharaparam.BefriendQuote = nyanko.SelectedHash;

                if (Addmembernames.Texts.ContainsKey(SelectedCharaparam.BefriendQuote))
                {
                    string quote = Addmembernames.Texts[SelectedCharaparam.BefriendQuote].Strings[0].Text;
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
