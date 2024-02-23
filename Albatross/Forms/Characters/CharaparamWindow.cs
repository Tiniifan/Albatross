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

        private List<IOrgetimeTechnic> OrgetimeTechnics;

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

        private T2bþ OrgeTechnicnames;

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
            OrgetimeTechnics = new List<IOrgetimeTechnic>();

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

        private string[] GetNames(IOrgetimeTechnic[] orgeTechnicnames)
        {
            return orgeTechnicnames
                .Select((hackslashSkill, index) =>
                {
                    return OrgeTechnicnames.Nouns.TryGetValue(hackslashSkill.NameHash, out var noun) && noun.Strings.Count > 0
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
            else if (GameOpened.Name == "Yo-Kai Watch Blaster")
            {
                OrgeTechnicnames = new T2bþ(GameOpened.Files["orgetime_technic"].File.Directory.GetFileFromFullPath(GameOpened.Files["orgetime_technic"].Path));
                OrgetimeTechnics.AddRange(GameOpened.GetOrgetimeTechnics());
                attackBlasterFlatComboBox.Items.AddRange(GetNames(OrgetimeTechnics.ToArray()).ToArray());
                soultimateBlasterFlatComboBox.Items.AddRange(attackBlasterFlatComboBox.Items.Cast<Object>().ToArray());
                slotBlasterFlatComboBox1.Items.AddRange(attackBlasterFlatComboBox.Items.Cast<Object>().ToArray());
                slotBlasterFlatComboBox2.Items.AddRange(attackBlasterFlatComboBox.Items.Cast<Object>().ToArray());
                slotBlasterFlatComboBox3.Items.AddRange(attackBlasterFlatComboBox.Items.Cast<Object>().ToArray());
                slotBlasterFlatComboBox4.Items.AddRange(attackBlasterFlatComboBox.Items.Cast<Object>().ToArray());
            }
            else
            {
                BattleCommands.AddRange(GameOpened.GetBattleCommands());
            }

            // Get yokais and evolutions
            Charabases.AddRange(GameOpened.GetCharacterbase(true));
            Charaparams.AddRange(GameOpened.GetCharaparam());
            ICharaevolve[] charaevolves = GameOpened.GetCharaevolution();

            // Get names
            Itemnames = new T2bþ(GameOpened.Files["item_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["item_text"].Path));
            Abilitynames = new T2bþ(GameOpened.Files["chara_ability_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["chara_ability_text"].Path));
            Charanames = new T2bþ(GameOpened.Files["chara_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["chara_text"].Path));
            Addmembernames = new T2bþ(GameOpened.Files["addmembermenu_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["addmembermenu_text"].Path));

            if (GameOpened.Name != "Yo-Kai Watch Blaster")
            {
                Skillnames = new T2bþ(GameOpened.Files["skill_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["skill_text"].Path));
                BattleCommandnames = new T2bþ(GameOpened.Files["battle_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["battle_text"].Path));
            }

            // Prepare combobox 
            resistanceFlatComboBox.Items.AddRange(Attributes.YW.Values.ToArray());
            weaknessFlatComboBox.Items.AddRange(Attributes.YW.Values.ToArray());
            scoutFlatComboBox.Items.AddRange(GameOpened.ScoutablesType.Values.ToArray());
            speedFlatComboBox.Items.AddRange(Speeds.YWB.Values.ToArray());

            if (GameOpened.Name == "Yo-Kai Watch 3")
            {
                attackFlatComboBox.Items.AddRange(GetNames(Skills.ToArray()).ToArray());
            } else
            {
                attackFlatComboBox.Items.AddRange(GetNames(BattleCommands.ToArray()).ToArray());
            }

            if (GameOpened.Name == "Yo-Kai Watch Blaster")
            {
                abilityBlasterBlasterFlatComboBox.Items.AddRange(GetNames(Abilities.ToArray()).ToArray());
            } else
            {
                tribeFlatComboBox.Items.AddRange(GameOpened.Tribes.Values.ToArray());
                techniqueFlatComboBox.Items.AddRange(attackFlatComboBox.Items.Cast<Object>().ToArray());
                inspiritFlatComboBox.Items.AddRange(attackFlatComboBox.Items.Cast<Object>().ToArray());
                soultimateFlatComboBox.Items.AddRange(attackFlatComboBox.Items.Cast<Object>().ToArray());
                guardFlatComboBox.Items.AddRange(attackFlatComboBox.Items.Cast<Object>().ToArray());
                abilityFlatComboBox.Items.AddRange(GetNames(Abilities.ToArray()).ToArray());
            }

            itemFlatComboBox1.Items.AddRange(GetNames(Items.ToArray()).ToArray());
            itemFlatComboBox2.Items.AddRange(itemFlatComboBox1.Items.Cast<Object>().ToArray());
            baseModelFlatComboBox.Items.AddRange(GetNames(Charabases.ToArray()).ToArray());
            characterListBox.Items.AddRange(GetNames(Charaparams.ToArray()).ToArray());
            evolutionFlatComboBox.Items.AddRange(characterListBox.Items.Cast<Object>().ToArray());

            // Link charaevolve to charaparam
            foreach (ICharaparam charaparamsWithEvolve in Charaparams.Where(x => x.EvolveOffset != -1).ToArray())
            {
                if (charaparamsWithEvolve.EvolveOffset < charaevolves.Length)
                {
                    ICharaevolve charaevolve = charaevolves[charaparamsWithEvolve.EvolveOffset];
                    charaparamsWithEvolve.EvolveParam = charaevolve.ParamHash;
                    charaparamsWithEvolve.EvolveLevel = charaevolve.Level;
                    charaparamsWithEvolve.EvolveCost = charaevolve.Cost;
                }
            }

            if (GameOpened.Name == "Yo-Kai Watch 1")
            {
                label8.Enabled = true;
                tribePictureBox.Enabled = true;
                tribeFlatComboBox.Enabled = true;
                label13.Enabled = false;
                scoutFlatComboBox.Enabled = false;
                label21.Enabled = false;
                label47.Visible = false;
                evolutionCostFlatNumericUpDown.Visible = false;
                evolutionFlatNumericUpDown.Size = new Size(128, 22);
                maxStatFlatNumericUpDown1.Enabled = false;
                maxStatFlatNumericUpDown2.Enabled = false;
                maxStatFlatNumericUpDown3.Enabled = false;
                maxStatFlatNumericUpDown4.Enabled = false;
                maxStatFlatNumericUpDown5.Enabled = false;
                speedFlatComboBox.Visible = false;
                label44.Enabled = false;
                waitTimeFlatNumericUpDown.Enabled = false;
                label48.Enabled = false;
                battleTypeFlatNumericUpDown.Enabled = false;
                vsTabControl2.TabPages.RemoveAt(1);
                vsTabControl2.TabPages.RemoveAt(1);
                label42.Visible = false;
                pictureBox1.Visible = false;
                resistanceFlatComboBox.Visible = false;
                label43.Visible = false;
                weaknessFlatComboBox.Visible = false;
                equipmentSlotFlatNumericUpDown.Enabled = false;
            }
            else if (GameOpened.Name == "Yo-Kai Watch 2")
            {
                label8.Enabled = false;
                tribePictureBox.Enabled = false;
                tribeFlatComboBox.Enabled = false;
                label13.Enabled = true;
                scoutFlatComboBox.Enabled = true;
                label47.Visible = false;
                evolutionCostFlatNumericUpDown.Visible = false;
                evolutionFlatNumericUpDown.Size = new Size(128, 22);
                maxStatFlatNumericUpDown1.Enabled = true;
                maxStatFlatNumericUpDown2.Enabled = true;
                maxStatFlatNumericUpDown3.Enabled = true;
                maxStatFlatNumericUpDown4.Enabled = true;
                maxStatFlatNumericUpDown5.Enabled = true;
                speedFlatComboBox.Visible = false;
                label44.Enabled = false;
                waitTimeFlatNumericUpDown.Enabled = false;
                label48.Enabled = false;
                battleTypeFlatNumericUpDown.Enabled = false;
                vsTabControl2.TabPages.RemoveAt(1);
                vsTabControl2.TabPages.RemoveAt(1);
                label42.Visible = false;
                pictureBox1.Visible = false;
                resistanceFlatComboBox.Visible = false;
                label43.Visible = false;
                weaknessFlatComboBox.Visible = false;
                equipmentSlotFlatNumericUpDown.Enabled = true;
            }
            else if (GameOpened.Name == "Yo-Kai Watch 3")
            {
                label44.Enabled = true;
                waitTimeFlatNumericUpDown.Enabled = true;
                label48.Enabled = true;
                battleTypeFlatNumericUpDown.Enabled = true;
                label8.Enabled = false;
                tribePictureBox.Enabled = false;
                tribeFlatComboBox.Enabled = false;
                label13.Enabled = true;
                scoutFlatComboBox.Enabled = true;
                label47.Visible = false;
                evolutionCostFlatNumericUpDown.Visible = false;
                evolutionFlatNumericUpDown.Size = new Size(128, 22);
                maxStatFlatNumericUpDown1.Enabled = true;
                maxStatFlatNumericUpDown2.Enabled = true;
                maxStatFlatNumericUpDown3.Enabled = true;
                maxStatFlatNumericUpDown4.Enabled = true;
                maxStatFlatNumericUpDown5.Enabled = true;
                speedFlatComboBox.Visible = false;
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
                equipmentSlotFlatNumericUpDown.Enabled = true;
            }
            else if (GameOpened.Name == "Yo-Kai Watch Blaster")
            {
                label44.Enabled = false;
                waitTimeFlatNumericUpDown.Enabled = false;
                label48.Enabled = false;
                battleTypeFlatNumericUpDown.Enabled = false;
                label8.Enabled = false;
                tribePictureBox.Enabled = false;
                tribeFlatComboBox.Enabled = false;
                label13.Enabled = false;
                scoutFlatComboBox.Enabled = false;
                label47.Enabled = true;
                evolutionCostFlatNumericUpDown.Enabled = true;
                maxStatFlatNumericUpDown1.Enabled = true;
                maxStatFlatNumericUpDown2.Enabled = true;
                maxStatFlatNumericUpDown3.Enabled = true;
                maxStatFlatNumericUpDown4.Enabled = true;
                maxStatFlatNumericUpDown5.Visible = false;
                minStatFlatNumericUpDown5.Visible = false;
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
                vsTabControl2.TabPages.RemoveAt(0);
                vsTabControl2.TabPages.RemoveAt(1);
                eatGroupBox.Enabled = false;
                favoriteFoodGroupBox.Enabled = false;
                hatedFoodGroupBox.Enabled = false;
                equipmentSlotFlatNumericUpDown.Enabled = false;
            }
        }

        private void CharaparamWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Generate charaevolves array
            List<ICharaevolve> charaevolves = new List<ICharaevolve>() { };

            // Loop through Charaparams with non-zero ParamHash
            foreach (ICharaparam charaparamWithEvolve in Charaparams.Where(x => x.EvolveParam != 0x00).ToArray())
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
                    case "Yo-Kai Watch Blaster":
                        charaevolve = GameSupport.GetLogic<YKWB.Charaevolve>();
                        break;
                }

                // Assign values to charaevolve properties
                charaevolve.ParamHash = charaparamWithEvolve.EvolveParam;
                charaevolve.Level = charaparamWithEvolve.EvolveLevel;
                charaevolve.Cost = charaparamWithEvolve.EvolveCost;
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
            if (BattleCommandnames != null)
            {
                GameSupport.SaveTextFile(GameOpened.Files["battle_text"], BattleCommandnames);
            }        
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
                case "Yo-Kai Watch Blaster":
                    newCharaparam = GameSupport.GetLogic<YKWB.Charaparam>();
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

            // Reset search
            CharaparamsFiltred = null;
            searchTextBox.Text = "Search...";

            // Update all names
            characterListBox.Items.Clear();
            evolutionFlatComboBox.Items.Clear();
            characterListBox.Items.AddRange(GetNames(Charaparams.ToArray()).ToArray());
            evolutionFlatComboBox.Items.AddRange(characterListBox.Items.Cast<Object>().ToArray());

            // Select the added charaparam
            characterListBox.Focus();
            characterListBox.SelectedIndex = characterListBox.Items.Count - 1;
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
            SetComboBox(SelectedCharaparam.Speed, Speeds.YWB, speedFlatComboBox);
            experienceCurveFlatNumericUpDown.Value = SelectedCharaparam.ExperienceCurve;
            equipmentSlotFlatNumericUpDown.Value = SelectedCharaparam.EquipmentSlotsAmount;
            waitTimeFlatNumericUpDown.Value = SelectedCharaparam.WaitTime;
            battleTypeFlatNumericUpDown.Value = SelectedCharaparam.BattleType;
            medalFlatNumericUpDown.Value = SelectedCharaparam.MedaliumOffset;
            isShownFlatCheckBox.Checked = SelectedCharaparam.ShowInMedalium;
            if (SelectedCharaparam.EvolveParam != 0)
            {
                evolutionFlatComboBox.SelectedIndex = Charaparams.FindIndex(x => x.ParamHash == SelectedCharaparam.EvolveParam);
                evolutionFlatNumericUpDown.Value = SelectedCharaparam.EvolveLevel;
                evolutionCostFlatNumericUpDown.Value = SelectedCharaparam.EvolveCost;

                label27.Enabled = true;
                evolutionFlatNumericUpDown.Enabled = true;

                label47.Enabled = true;
                evolutionCostFlatNumericUpDown.Enabled = true;
            } else
            {
                evolutionFlatComboBox.SelectedIndex = -1;
                evolutionFlatComboBox.Text = "";
                evolutionFlatNumericUpDown.Value = 0;

                label27.Enabled = false;
                evolutionFlatNumericUpDown.Enabled = false;
                evolutionPictureBox.Image = null;

                label47.Enabled = false;
                evolutionCostFlatNumericUpDown.Enabled = false;
                evolutionCostFlatNumericUpDown.Value = 0;
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
                guardFlatComboBox.SelectedIndex = Skills.FindIndex(x => x.SkillHash == SelectedCharaparam.GuardHash);

                attackFlatNumericUpDown.Value = (decimal)SelectedCharaparam.AttackPercentage;
                techniqueFlatNumericUpDown.Value = (decimal)SelectedCharaparam.TechniquePercentage;
                inspiritFlatNumericUpDown.Value = (decimal)SelectedCharaparam.InspiritPercentage;
                guardFlatNumericUpDown.Value = (decimal)SelectedCharaparam.GuardPercentage;

                // Blaster T
                if (selectedHackslashCharaparam != null)
                {
                    attackAFlatComboBox.SelectedIndex = HackslashTechnics.FindIndex(x => x.HackslashTechnicHash == selectedHackslashCharaparam.AttackAHash);
                    attackXFlatComboBox.SelectedIndex = HackslashTechnics.FindIndex(x => x.HackslashTechnicHash == selectedHackslashCharaparam.AttackXHash);
                    attackYFlatComboBox.SelectedIndex = HackslashTechnics.FindIndex(x => x.HackslashTechnicHash == selectedHackslashCharaparam.AttackYHash);
                    soultimateBlasterTFlatComboBox.SelectedIndex = HackslashTechnics.FindIndex(x => x.HackslashTechnicHash == selectedHackslashCharaparam.SoultimateHash);
                    abilityBlasterTFlatComboBox.SelectedIndex = HackslashAbilities.FindIndex(x => x.CharaabilityConfigHash == selectedHackslashCharaparam.SkillHash);
                }
            } else if (GameOpened.Name == "Yo-Kai Watch Blaster")
            {
                attackBlasterFlatComboBox.SelectedIndex = OrgetimeTechnics.FindIndex(x => x.OrgeTimeTechnicHash == SelectedCharaparam.BlasterAttack);
                soultimateBlasterFlatComboBox.SelectedIndex = OrgetimeTechnics.FindIndex(x => x.OrgeTimeTechnicHash == SelectedCharaparam.BlasterSoultimate);
                slotBlasterFlatComboBox1.SelectedIndex = OrgetimeTechnics.FindIndex(x => x.OrgeTimeTechnicHash == SelectedCharaparam.BlasterMoveSlot1);
                slotBlasterFlatComboBox2.SelectedIndex = OrgetimeTechnics.FindIndex(x => x.OrgeTimeTechnicHash == SelectedCharaparam.BlasterMoveSlot2);
                slotBlasterFlatComboBox3.SelectedIndex = OrgetimeTechnics.FindIndex(x => x.OrgeTimeTechnicHash == SelectedCharaparam.BlasterMoveSlot3);
                slotBlasterFlatComboBox4.SelectedIndex = OrgetimeTechnics.FindIndex(x => x.OrgeTimeTechnicHash == SelectedCharaparam.BlasterMoveSlot4);
                earnLevelFlatNumericUpDown1.Value = SelectedCharaparam.BlasterEarnLevelMoveSlot1;
                earnLevelFlatNumericUpDown2.Value = SelectedCharaparam.BlasterEarnLevelMoveSlot2;
                earnLevelFlatNumericUpDown3.Value = SelectedCharaparam.BlasterEarnLevelMoveSlot3;
                earnLevelFlatNumericUpDown4.Value = SelectedCharaparam.BlasterEarnLevelMoveSlot4;
            }
            else
            {
                attackFlatComboBox.SelectedIndex = BattleCommands.FindIndex(x => x.BattleCommandHash == SelectedCharaparam.AttackHash);
                techniqueFlatComboBox.SelectedIndex = BattleCommands.FindIndex(x => x.BattleCommandHash == SelectedCharaparam.TechniqueHash);
                inspiritFlatComboBox.SelectedIndex = BattleCommands.FindIndex(x => x.BattleCommandHash == SelectedCharaparam.InspiritHash);
                soultimateFlatComboBox.SelectedIndex = BattleCommands.FindIndex(x => x.BattleCommandHash == SelectedCharaparam.SoultimateHash);
                guardFlatComboBox.SelectedIndex = BattleCommands.FindIndex(x => x.BattleCommandHash == SelectedCharaparam.GuardHash);

                attackFlatNumericUpDown.Value = (decimal)SelectedCharaparam.AttackPercentage;
                techniqueFlatNumericUpDown.Value = (decimal)SelectedCharaparam.TechniquePercentage;
                inspiritFlatNumericUpDown.Value = (decimal)SelectedCharaparam.InspiritPercentage;
                guardFlatNumericUpDown.Value = (decimal)SelectedCharaparam.GuardPercentage;
            }

            if (GameOpened.Name == "Yo-Kai Watch Blaster")
            {
                abilityBlasterBlasterFlatComboBox.SelectedIndex = Abilities.FindIndex(x => x.CharaabilityConfigHash == SelectedCharaparam.BlasterSkill);
            } else
            {
                abilityFlatComboBox.SelectedIndex = Abilities.FindIndex(x => x.CharaabilityConfigHash == SelectedCharaparam.AbilityHash);
            }

            if (BattleCommandnames != null && BattleCommandnames.Texts.ContainsKey(SelectedCharaparam.Quote1))
            {
                eatQuoteTextBox.Text = BattleCommandnames.Texts[SelectedCharaparam.Quote1].Strings[0].Text;
            }
            else
            {
                eatQuoteTextBox.Clear();
            }

            if (BattleCommandnames != null && BattleCommandnames.Texts.ContainsKey(SelectedCharaparam.Quote2))
            {
                favoriteFoodQuoteTextBox.Text = BattleCommandnames.Texts[SelectedCharaparam.Quote2].Strings[0].Text;
            }
            else
            {
                favoriteFoodQuoteTextBox.Clear();
            }

            if (BattleCommandnames != null && BattleCommandnames.Texts.ContainsKey(SelectedCharaparam.Quote3))
            {
                hatedFoodQuoteTextBox.Text = BattleCommandnames.Texts[SelectedCharaparam.Quote3].Strings[0].Text;
            }
            else
            {
                hatedFoodQuoteTextBox.Clear();
            }

            if (Addmembernames != null && Addmembernames.Texts.ContainsKey(SelectedCharaparam.BefriendQuote))
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

                        bool searchByBaseHash = ("0x" + charaparam.BaseHash.ToString("X8").ToLower()).Contains(searchTextBox.Text.ToLower());
                        bool searchByParamHash = ("0x" + charaparam.ParamHash.ToString("X8").ToLower()).Contains(searchTextBox.Text.ToLower());
                        bool searchByModelName = searchCharabase != null && GameSupport.GetFileModelText(searchCharabase.FileNamePrefix, searchCharabase.FileNameNumber, searchCharabase.FileNameVariant).ToLower().Contains(searchTextBox.Text.ToLower());
                        bool searchByYokaiName = searchCharabase != null && Charanames.Nouns.ContainsKey(searchCharabase.NameHash) &&
                               Charanames.Nouns[searchCharabase.NameHash].Strings.Any(s => s.Text.ToLower().Contains(searchTextBox.Text.ToLower()));

                        return searchByBaseHash || searchByParamHash || searchByModelName || searchByYokaiName;
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
            if (!tribeFlatComboBox.Enabled)
            {
                tribeFlatComboBox.SelectedIndex = -1;
                tribeFlatComboBox.Text = "";
                return;
            }

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
                SelectedCharaparam.Tribe = GameOpened.Tribes.Values.ToList().IndexOf(tribeFlatComboBox.SelectedItem.ToString());
            }
            else
            {
                SelectedCharaparam.Tribe = 0;
            }
        }

        private void ScoutFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!scoutFlatComboBox.Enabled)
            {
                scoutFlatComboBox.SelectedIndex = -1;
                scoutFlatComboBox.Text = "";
                return;
            }

            if (!scoutFlatComboBox.Focused) return;

            SelectedCharaparam.ScoutableHash = GameOpened.ScoutablesType.Keys.ElementAt(scoutFlatComboBox.SelectedIndex);
        }

        private void ExperienceCurveFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!experienceCurveFlatNumericUpDown.Focused) return;

            SelectedCharaparam.ExperienceCurve = Convert.ToInt32(experienceCurveFlatNumericUpDown.Value);
        }

        private void EquipmentSlotFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!equipmentSlotFlatNumericUpDown.Focused) return;

            SelectedCharaparam.EquipmentSlotsAmount = Convert.ToInt32(equipmentSlotFlatNumericUpDown.Value);
        }

        private void WaitTimeFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!waitTimeFlatNumericUpDown.Focused) return;

            SelectedCharaparam.WaitTime = Convert.ToInt32(waitTimeFlatNumericUpDown.Value);
        }

        private void BattleTypeFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!battleTypeFlatNumericUpDown.Focused) return;

            SelectedCharaparam.BattleType = Convert.ToInt32(battleTypeFlatNumericUpDown.Value);
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

        private void EvolutionCostFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!evolutionCostFlatNumericUpDown.Focused) return;

            SelectedCharaparam.EvolveCost = Convert.ToInt32(evolutionCostFlatNumericUpDown.Value);
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
                    int fileNumber = 0;
                    string fileName = "";

                    switch(GameOpened.Name)
                    {
                        case "Yo-Kai Watch 1":
                            fileNumber = item.ItemPosY * 16 + (item.ItemPosX + 1);
                            fileName = "item_" + fileNumber.ToString().PadLeft(3, '0');
                            break;
                        case "Yo-Kai Watch 2":
                            fileNumber = item.ItemPosY * 16 + (item.ItemPosX + 1);
                            fileName = "item_" + fileNumber.ToString().PadLeft(3, '0');
                            break;
                        case "Yo-Kai Watch 3":
                            fileNumber = item.ItemPosY * 32 + (item.ItemPosX + 1);
                            fileName = "item_" + fileNumber.ToString().PadLeft(4, '0');
                            break;
                    }

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
                    int fileNumber = 0;
                    string fileName = "";

                    switch (GameOpened.Name)
                    {
                        case "Yo-Kai Watch 1":
                            fileNumber = item.ItemPosY * 16 + (item.ItemPosX + 1);
                            fileName = "item_" + fileNumber.ToString().PadLeft(3, '0');
                            break;
                        case "Yo-Kai Watch 2":
                            fileNumber = item.ItemPosY * 16 + (item.ItemPosX + 1);
                            fileName = "item_" + fileNumber.ToString().PadLeft(3, '0');
                            break;
                        case "Yo-Kai Watch 3":
                            fileNumber = item.ItemPosY * 32 + (item.ItemPosX + 1);
                            fileName = "item_" + fileNumber.ToString().PadLeft(4, '0');
                            break;
                    }

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

        private void SpeedFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!speedFlatComboBox.Focused) return;

            if (speedFlatComboBox.SelectedIndex != -1)
            {
                SelectedCharaparam.Speed = Speeds.YWB.Values.ToList().IndexOf(speedFlatComboBox.SelectedItem.ToString());
            }
            else
            {
                SelectedCharaparam.Speed = 0;
            }
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

            SelectedCharaparam.AttributeDamageFire = Convert.ToSingle(attributeFlatNumericUpDown1.Value);
        }

        private void AttributeFlatNumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (!attributeFlatNumericUpDown2.Focused) return;

            SelectedCharaparam.AttributeDamageIce = Convert.ToSingle(attributeFlatNumericUpDown2.Value);
        }

        private void AttributeFlatNumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (!attributeFlatNumericUpDown3.Focused) return;

            SelectedCharaparam.AttributeDamageEarth = Convert.ToSingle(attributeFlatNumericUpDown3.Value);
        }

        private void AttributeFlatNumericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (!attributeFlatNumericUpDown4.Focused) return;

            SelectedCharaparam.AttributeDamageLigthning = Convert.ToSingle(attributeFlatNumericUpDown4.Value);
        }

        private void AttributeFlatNumericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (!attributeFlatNumericUpDown5.Focused) return;

            SelectedCharaparam.AttributeDamageWater = Convert.ToSingle(attributeFlatNumericUpDown5.Value);
        }

        private void AttributeFlatNumericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            if (!attributeFlatNumericUpDown6.Focused) return;

            SelectedCharaparam.AttributeDamageWind = Convert.ToSingle(attributeFlatNumericUpDown6.Value);
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
                if (GameOpened.Name == "Yo-Kai Watch 3")
                {
                    SelectedCharaparam.AttackHash = Skills[attackFlatComboBox.SelectedIndex].SkillHash;
                }
                else
                {
                    SelectedCharaparam.AttackHash = BattleCommands[attackFlatComboBox.SelectedIndex].BattleCommandHash;
                }
            }
        }

        private void AttackFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!attackFlatNumericUpDown.Focused) return;

            SelectedCharaparam.AttackPercentage = Convert.ToSingle(attackFlatNumericUpDown.Value);
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
                if (GameOpened.Name == "Yo-Kai Watch 3")
                {
                    SelectedCharaparam.TechniqueHash = Skills[techniqueFlatComboBox.SelectedIndex].SkillHash;
                }
                else
                {
                    SelectedCharaparam.TechniqueHash = BattleCommands[techniqueFlatComboBox.SelectedIndex].BattleCommandHash;
                }
            }
        }

        private void TechniqueFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!techniqueFlatNumericUpDown.Focused) return;

            SelectedCharaparam.TechniquePercentage = Convert.ToSingle(techniqueFlatNumericUpDown.Value);
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
                if (GameOpened.Name == "Yo-Kai Watch 3")
                {
                    SelectedCharaparam.InspiritHash = Skills[inspiritFlatComboBox.SelectedIndex].SkillHash;
                }
                else
                {
                    SelectedCharaparam.InspiritHash = BattleCommands[inspiritFlatComboBox.SelectedIndex].BattleCommandHash;
                }
            }
        }

        private void InspiritFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!inspiritFlatNumericUpDown.Focused) return;

            SelectedCharaparam.InspiritPercentage = Convert.ToSingle(inspiritFlatNumericUpDown.Value);
        }

        private void GuardFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!guardFlatComboBox.Focused) return;

            if (guardFlatComboBox.SelectedIndex == -1)
            {
                SelectedCharaparam.GuardHash = 0;
            }
            else
            {
                if (GameOpened.Name == "Yo-Kai Watch 3")
                {
                    SelectedCharaparam.GuardHash = Skills[guardFlatComboBox.SelectedIndex].SkillHash;
                }
                else
                {
                    SelectedCharaparam.GuardHash = BattleCommands[guardFlatComboBox.SelectedIndex].BattleCommandHash;
                }
            }
        }

        private void GuardFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!guardFlatNumericUpDown.Focused) return;

            SelectedCharaparam.GuardPercentage = Convert.ToSingle(guardFlatNumericUpDown.Value);
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
                if (GameOpened.Name == "Yo-Kai Watch 3")
                {
                    SelectedCharaparam.SoultimateHash = Skills[soultimateFlatComboBox.SelectedIndex].SkillHash;
                }
                else
                {
                    SelectedCharaparam.SoultimateHash = BattleCommands[soultimateFlatComboBox.SelectedIndex].BattleCommandHash;
                }
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

        private void AbilityBlasterBlasterFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!abilityBlasterBlasterFlatComboBox.Focused) return;

            if (abilityBlasterBlasterFlatComboBox.SelectedIndex == -1)
            {
                SelectedCharaparam.BlasterSkill = 0;
            }
            else
            {
                SelectedCharaparam.BlasterSkill = Abilities[abilityBlasterBlasterFlatComboBox.SelectedIndex].CharaabilityConfigHash;
            }
        }

        private void AttackBlasterFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!attackBlasterFlatComboBox.Focused) return;

            if (attackBlasterFlatComboBox.SelectedIndex == -1)
            {
                SelectedCharaparam.BlasterAttack = 0;
            }
            else
            {
                SelectedCharaparam.BlasterAttack = OrgetimeTechnics[attackBlasterFlatComboBox.SelectedIndex].OrgeTimeTechnicHash;
            }
        }

        private void SoultimateBlasterFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!soultimateBlasterFlatComboBox.Focused) return;

            if (soultimateBlasterFlatComboBox.SelectedIndex == -1)
            {
                SelectedCharaparam.BlasterSoultimate = 0;
            }
            else
            {
                SelectedCharaparam.BlasterSoultimate = OrgetimeTechnics[soultimateBlasterFlatComboBox.SelectedIndex].OrgeTimeTechnicHash;
            }
        }

        private void SlotBlasterFlatComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!slotBlasterFlatComboBox1.Focused) return;

            if (slotBlasterFlatComboBox1.SelectedIndex == -1)
            {
                SelectedCharaparam.BlasterMoveSlot1 = 0;
            }
            else
            {
                SelectedCharaparam.BlasterMoveSlot1 = OrgetimeTechnics[slotBlasterFlatComboBox1.SelectedIndex].OrgeTimeTechnicHash;
            }
        }

        private void EarnLevelFlatNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!earnLevelFlatNumericUpDown1.Focused) return;

            SelectedCharaparam.BlasterEarnLevelMoveSlot1 = Convert.ToInt32(earnLevelFlatNumericUpDown1.Value);
        }

        private void SlotBlasterFlatComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!slotBlasterFlatComboBox2.Focused) return;

            if (slotBlasterFlatComboBox2.SelectedIndex == -1)
            {
                SelectedCharaparam.BlasterMoveSlot2 = 0;
            }
            else
            {
                SelectedCharaparam.BlasterMoveSlot2 = OrgetimeTechnics[slotBlasterFlatComboBox2.SelectedIndex].OrgeTimeTechnicHash;
            }
        }

        private void EarnLevelFlatNumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (!earnLevelFlatNumericUpDown2.Focused) return;

            SelectedCharaparam.BlasterEarnLevelMoveSlot2 = Convert.ToInt32(earnLevelFlatNumericUpDown2.Value);
        }

        private void SlotBlasterFlatComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!slotBlasterFlatComboBox3.Focused) return;

            if (slotBlasterFlatComboBox3.SelectedIndex == -1)
            {
                SelectedCharaparam.BlasterMoveSlot3 = 0;
            }
            else
            {
                SelectedCharaparam.BlasterMoveSlot3 = OrgetimeTechnics[slotBlasterFlatComboBox3.SelectedIndex].OrgeTimeTechnicHash;
            }
        }

        private void EarnLevelFlatNumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (!earnLevelFlatNumericUpDown3.Focused) return;

            SelectedCharaparam.BlasterEarnLevelMoveSlot1 = Convert.ToInt32(earnLevelFlatNumericUpDown3.Value);
        }

        private void SlotBlasterFlatComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!slotBlasterFlatComboBox4.Focused) return;

            if (slotBlasterFlatComboBox4.SelectedIndex == -1)
            {
                SelectedCharaparam.BlasterMoveSlot4 = 0;
            }
            else
            {
                SelectedCharaparam.BlasterMoveSlot4 = OrgetimeTechnics[slotBlasterFlatComboBox4.SelectedIndex].OrgeTimeTechnicHash;
            }
        }

        private void EarnLevelFlatNumericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (!earnLevelFlatNumericUpDown4.Focused) return;

            SelectedCharaparam.BlasterEarnLevelMoveSlot4 = Convert.ToInt32(earnLevelFlatNumericUpDown4.Value);
        }

        private void AttackAFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!attackAFlatComboBox.Focused) return;

            IHackslashCharaparam selectedHackslashCharaparam = HackslashCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

            // Automatically create a hackslash entry
            if (selectedHackslashCharaparam == null)
            {
                selectedHackslashCharaparam = GameSupport.GetLogic<YKW3.HackslashCharaparam>();
                selectedHackslashCharaparam.ParamHash = SelectedCharaparam.ParamHash;
                HackslashCharaparams.Add(selectedHackslashCharaparam);
            }

            if (attackAFlatComboBox.SelectedIndex == -1)
            {
                selectedHackslashCharaparam.AttackAHash = 0;
            }
            else
            {
                selectedHackslashCharaparam.AttackAHash = HackslashTechnics[attackAFlatComboBox.SelectedIndex].HackslashTechnicHash;
            }
        }

        private void AttackXFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!attackXFlatComboBox.Focused) return;

            IHackslashCharaparam selectedHackslashCharaparam = HackslashCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

            // Automatically create a hackslash entry
            if (selectedHackslashCharaparam == null)
            {
                selectedHackslashCharaparam = GameSupport.GetLogic<YKW3.HackslashCharaparam>();
                selectedHackslashCharaparam.ParamHash = SelectedCharaparam.ParamHash;
                HackslashCharaparams.Add(selectedHackslashCharaparam);
            }

            if (attackXFlatComboBox.SelectedIndex == -1)
            {
                selectedHackslashCharaparam.AttackXHash = 0;
            }
            else
            {
                selectedHackslashCharaparam.AttackXHash = HackslashTechnics[attackXFlatComboBox.SelectedIndex].HackslashTechnicHash;
            }
        }

        private void AttackYFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!attackYFlatComboBox.Focused) return;

            IHackslashCharaparam selectedHackslashCharaparam = HackslashCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

            // Automatically create a hackslash entry
            if (selectedHackslashCharaparam == null)
            {
                selectedHackslashCharaparam = GameSupport.GetLogic<YKW3.HackslashCharaparam>();
                selectedHackslashCharaparam.ParamHash = SelectedCharaparam.ParamHash;
                HackslashCharaparams.Add(selectedHackslashCharaparam);
            }

            if (attackYFlatComboBox.SelectedIndex == -1)
            {
                selectedHackslashCharaparam.AttackYHash = 0;
            }
            else
            {
                selectedHackslashCharaparam.AttackYHash = HackslashTechnics[attackYFlatComboBox.SelectedIndex].HackslashTechnicHash;
            }
        }

        private void SoultimateBlasterTFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!soultimateBlasterTFlatComboBox.Focused) return;

            IHackslashCharaparam selectedHackslashCharaparam = HackslashCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

            // Automatically create a hackslash entry
            if (selectedHackslashCharaparam == null)
            {
                selectedHackslashCharaparam = GameSupport.GetLogic<YKW3.HackslashCharaparam>();
                selectedHackslashCharaparam.ParamHash = SelectedCharaparam.ParamHash;
                HackslashCharaparams.Add(selectedHackslashCharaparam);
            }

            if (soultimateBlasterTFlatComboBox.SelectedIndex == -1)
            {
                selectedHackslashCharaparam.SoultimateHash = 0;
            }
            else
            {
                selectedHackslashCharaparam.SoultimateHash = HackslashTechnics[soultimateBlasterTFlatComboBox.SelectedIndex].HackslashTechnicHash;
            }
        }

        private void AbilityBlasterTFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!abilityBlasterTFlatComboBox.Focused) return;

            IHackslashCharaparam selectedHackslashCharaparam = HackslashCharaparams.FirstOrDefault(x => x.ParamHash == SelectedCharaparam.ParamHash);

            // Automatically create a hackslash entry
            if (selectedHackslashCharaparam == null)
            {
                selectedHackslashCharaparam = GameSupport.GetLogic<YKW3.HackslashCharaparam>();
                selectedHackslashCharaparam.ParamHash = SelectedCharaparam.ParamHash;
                HackslashCharaparams.Add(selectedHackslashCharaparam);
            }

            if (abilityBlasterTFlatComboBox.SelectedIndex == -1)
            {
                selectedHackslashCharaparam.SkillHash = 0;
            }
            else
            {
                selectedHackslashCharaparam.SkillHash = HackslashAbilities[abilityBlasterTFlatComboBox.SelectedIndex].CharaabilityConfigHash;
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
