﻿using System;
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

namespace Albatross.Forms.Encounters
{
    public partial class EncounterWindow : Form
    {
        private IGame GameOpened;

        private List<ICharabase> Charabases;

        private List<ICharaparam> Charaparams;

        private List<IEncountTable> EncountTables;

        private IEncountTable SelectedEncountTable;

        private List<IEncountChara> EncountCharas;

        private T2bþ Charanames;

        private Dictionary<string, string> Mapnames;

        private bool EncounterDataGridEditInProgress = false;

        private bool IsProcessingCellValueChange = false;

        public EncounterWindow(IGame game)
        {
            GameOpened = game;

            Charabases = new List<ICharabase>();
            Charaparams = new List<ICharaparam>();
            EncountTables = new List<IEncountTable>();
            EncountCharas = new List<IEncountChara>();
            Mapnames = new Dictionary<string, string>();

            InitializeComponent();
            LoadEncounter();
        }

        private string GetNames(int nameHash)
        {
            return Charanames.Nouns.TryGetValue(nameHash, out var noun) && noun.Strings.Count > 0
                        ? noun.Strings[0].Text
                        : "Undefined";
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
            HashSet<string> encounteredNames = new HashSet<string>();
            Dictionary<string, int> nameOccurrences = new Dictionary<string, int>();

            return charaparams
                .Select((charaparam, index) =>
                {
                    var searchCharabase = Charabases.FirstOrDefault(x => x.BaseHash == charaparam.BaseHash);

                    if (searchCharabase != null && Charanames.Nouns.TryGetValue(searchCharabase.NameHash, out var noun) && noun.Strings.Count > 0)
                    {
                        string name = noun.Strings[0].Text;

                        // The name has already been encountered, update the occurrences and add the count to the end
                        if (encounteredNames.Contains(name))
                        {
                            int occurrences = nameOccurrences.TryGetValue(name, out int count) ? count + 1 : 2;
                            nameOccurrences[name] = occurrences;
                            name += " " + occurrences;
                        }

                        // Add the name to the list of encountered names
                        encounteredNames.Add(name);

                        return name;
                    }

                    return "Param " + index;
                })
                .ToArray();
        }

        private void LoadEncounter()
        {
            // Reset form
            mapListBox.Items.Clear();
            ((DataGridViewComboBoxColumn)encounterDataGridView.Columns[1]).Items.Clear();

            // Get resources
            Charabases.AddRange(GameOpened.GetCharacterbase(true));
            Charaparams.AddRange(GameOpened.GetCharaparam());

            // Get names
            Charanames = new T2bþ(GameOpened.Files["chara_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["chara_text"].Path));
            T2bþ systemtext = new T2bþ(GameOpened.Files["system_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["system_text"].Path));

            // Prepare combobox
            ((DataGridViewComboBoxColumn)encounterDataGridView.Columns[1]).Items.AddRange(GetNames(Charaparams.ToArray()));

            // Get folder who contains encounter data          
            string[] filenames = GameOpened.GetMapWhoContainsEncounter();
            Dictionary<string, int> nameCounter = new Dictionary<string, int>();

            for (int i = 0; i < filenames.Length; i++)
            {
                // Obtain map name using crc32 hash
                uint crc32 = Crc32.Compute(Encoding.GetEncoding("Shift-JIS").GetBytes(filenames[i]));
                int crc32AsInt = (int)crc32;

                string mapName = systemtext.Texts.TryGetValue(crc32AsInt, out var text) && text.Strings.Count > 0
                    ? text.Strings[0].Text
                    : "Map " + i;

                // Check if the name has already been added
                if (nameCounter.ContainsKey(mapName))
                {
                    // Increment the counter and add the name with the counter in parentheses
                    nameCounter[mapName]++;
                    mapName = $"{mapName} ({nameCounter[mapName]})";
                }
                else
                {
                    // Add the name to the counter dictionary
                    nameCounter.Add(mapName, 1);
                }

                Mapnames.Add(filenames[i], mapName);
            }

            mapListBox.Items.AddRange(Mapnames.Values.ToArray());
        }

        private void MapListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mapListBox.SelectedIndex == -1) return;

            encounterDataGridView.Rows.Clear();
            encounterDataGridView.Enabled = false;
            tableFlatComboBox.SelectedIndex = -1;
            tableFlatComboBox.Text = "";

            // Console.WriteLine(Mapnames.FirstOrDefault(x => x.Value == mapListBox.SelectedItem.ToString()).Key + " " + mapListBox.SelectedItem.ToString());

            (IEncountTable[], IEncountChara[]) encounterData = GameOpened.GetMapEncounter(Mapnames.FirstOrDefault(x => x.Value == mapListBox.SelectedItem.ToString()).Key);
            EncountTables = encounterData.Item1.ToList();

            if (encounterData.Item2 != null)
            {
                EncountCharas = encounterData.Item2.ToList();
            }
            
            // Fill table
            tableFlatComboBox.Items.Clear();
            tableFlatComboBox.Items.AddRange(EncountTables.Select((table, index) => $"Table {index + 1}").ToArray());

            // Load first table
            if (tableFlatComboBox.Items.Count > 0)
            {
                tableFlatComboBox.SelectedIndex = 0;
            }           

            mapGroupBox.Enabled = true;
        }

        private void TableFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tableFlatComboBox.SelectedIndex == -1) return;

            encounterDataGridView.Rows.Clear();
            SelectedEncountTable = EncountTables[tableFlatComboBox.SelectedIndex];
            hashTextBox.Text = SelectedEncountTable.EncountConfigHash.ToString("X8");

            if (GameOpened.Name == "Yo-Kai Watch Blaster")
            {
                // Iterate through the encounter offsets
                for (int i = 0; i < SelectedEncountTable.CharaCount; i++)
                {
                    DataGridViewComboBoxColumn comboBox = (DataGridViewComboBoxColumn)encounterDataGridView.Columns[1];

                    int paramHash = SelectedEncountTable.Charas[0 + i * 3];
                    int level = SelectedEncountTable.Charas[1 + i * 3];

                    if (paramHash != 0x00)
                    {
                        // Retrieve charaparam and charabase information
                        ICharaparam charaparam = Charaparams.FirstOrDefault(x => x.ParamHash == paramHash);
                        ICharabase charabase = Charabases.FirstOrDefault(x => x.BaseHash == charaparam.BaseHash);

                        // Try to get the picture of the yokai
                        Bitmap yokaiPicture;
                        string fileName = GameSupport.GetFileModelText(charabase.FileNamePrefix, charabase.FileNameNumber, charabase.FileNameVariant);
                        try
                        {
                            byte[] imageData = GameOpened.Files["face_icon"].File.Directory.GetFileFromFullPath(GameOpened.Files["face_icon"].Path + "/" + fileName + ".xi");
                            yokaiPicture = IMGC.ToBitmap(imageData);
                        }
                        catch
                        {
                            yokaiPicture = null;
                        }

                        // Add a row with yokai picture, ComboBox item, and level
                        encounterDataGridView.Rows.Add(yokaiPicture, comboBox.Items[Charaparams.IndexOf(charaparam)], level);
                    }
                    else
                    {
                        encounterDataGridView.Rows.Add(null, null, level);
                    }
                }
            } else
            {
                // Iterate through the encounter offsets
                for (int i = 0; i < SelectedEncountTable.EncountOffsets.Count(); i++)
                {
                    DataGridViewComboBoxColumn comboBox = (DataGridViewComboBoxColumn)encounterDataGridView.Columns[1];

                    int charaIndex = SelectedEncountTable.EncountOffsets[i];

                    if (charaIndex != -1)
                    {
                        // Retrieve charaparam and charabase information
                        ICharaparam charaparam = Charaparams.FirstOrDefault(x => x.ParamHash == EncountCharas[charaIndex].ParamHash);
                        ICharabase charabase = Charabases.FirstOrDefault(x => x.BaseHash == charaparam.BaseHash);

                        // Try to get the picture of the yokai
                        Bitmap yokaiPicture;
                        string fileName = GameSupport.GetFileModelText(charabase.FileNamePrefix, charabase.FileNameNumber, charabase.FileNameVariant);
                        try
                        {
                            byte[] imageData = GameOpened.Files["face_icon"].File.Directory.GetFileFromFullPath(GameOpened.Files["face_icon"].Path + "/" + fileName + ".xi");
                            yokaiPicture = IMGC.ToBitmap(imageData);
                        }
                        catch
                        {
                            yokaiPicture = null;
                        }

                        // Add a row with yokai picture, ComboBox item, and level
                        encounterDataGridView.Rows.Add(yokaiPicture, comboBox.Items[Charaparams.IndexOf(charaparam)], EncountCharas[charaIndex].Level);
                    }
                    else
                    {
                        encounterDataGridView.Rows.Add(null, null, 0);
                    }
                }
            }

            encounterDataGridView.Enabled = true;
        }

        private void EncounterDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (encounterDataGridView.IsCurrentCellDirty)
            {
                if (!EncounterDataGridEditInProgress && !IsProcessingCellValueChange)
                {
                    EncounterDataGridEditInProgress = true;
                    encounterDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    encounterDataGridView.EndEdit();
                }
            }
        }

        private void EncounterDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (EncounterDataGridEditInProgress && !IsProcessingCellValueChange)
            {
                IsProcessingCellValueChange = true;

                int paramHash = 0;
                int level = 0;

                if (e.ColumnIndex == 1)
                {
                    DataGridViewComboBoxColumn comboBoxColumn = (DataGridViewComboBoxColumn)encounterDataGridView.Columns[1];

                    DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)encounterDataGridView.Rows[e.RowIndex].Cells[comboBoxColumn.DisplayIndex];
                    object selectedObject = comboBoxCell.FormattedValue;

                    if (selectedObject != null)
                    {
                        int selectedIndex = comboBoxColumn.Items.IndexOf(selectedObject);

                        // Retrieve charaparam and charabase information
                        ICharaparam charaparam = Charaparams[selectedIndex];
                        ICharabase charabase = Charabases.FirstOrDefault(x => x.BaseHash == charaparam.BaseHash);

                        // Try to get the picture of the yokai
                        Bitmap yokaiPicture;
                        string fileName = GameSupport.GetFileModelText(charabase.FileNamePrefix, charabase.FileNameNumber, charabase.FileNameVariant);
                        try
                        {
                            byte[] imageData = GameOpened.Files["face_icon"].File.Directory.GetFileFromFullPath(GameOpened.Files["face_icon"].Path + "/" + fileName + ".xi");
                            yokaiPicture = IMGC.ToBitmap(imageData);
                        }
                        catch
                        {
                            yokaiPicture = null;
                        }

                        paramHash = charaparam.ParamHash;
                        level = 1;

                        encounterDataGridView.Rows[e.RowIndex].Cells[0].Value = yokaiPicture;
                        encounterDataGridView.Rows[e.RowIndex].Cells[2].Value = 1;
                    }
                } 
                else if (e.ColumnIndex == 2)
                {
                    try
                    {
                        int number = Convert.ToInt32(encounterDataGridView.Rows[e.RowIndex].Cells[2].Value);
                        level = number;
                    }
                    catch
                    {
                    }
                }

                if (SelectedEncountTable.EncountOffsets[e.RowIndex] != 0)
                {
                    // Update
                    int charaIndex = SelectedEncountTable.EncountOffsets[e.RowIndex];
                    
                    if (e.ColumnIndex == 1)
                    {
                        EncountCharas[charaIndex].ParamHash = paramHash;
                    } else if (e.ColumnIndex == 2)
                    {
                        EncountCharas[charaIndex].Level = level;
                    }

                    // Refresh
                    TableFlatComboBox_SelectedIndexChanged(sender, e);
                } 
                else
                {
                    // Insert new one
                    IEncountChara encountChara = null;

                    // Determine the game type and get the corresponding Charaevolve logic
                    switch (GameOpened.Name)
                    {
                        case "Yo-Kai Watch 1":
                            encountChara = GameSupport.GetLogic<YKW1.EncountChara>();
                            break;
                            //case "Yo-Kai Watch 2":
                            //encountChara = GameSupport.GetLogic<YKW2.Charaevolve>();
                            //break;
                            //case "Yo-Kai Watch 3":
                            //encountChara = GameSupport.GetLogic<YKW3.Charaevolve>();
                            //break;
                            //case "Yo-Kai Watch Blaster":
                            //encountChara = GameSupport.GetLogic<YKWB.Charaevolve>();
                            //break;
                    }

                    // Settings
                    encountChara.ParamHash = paramHash;
                    encountChara.Level = level;

                    // Add
                    EncountCharas.Add(encountChara);

                    SelectedEncountTable.EncountOffsets[e.RowIndex] = EncountCharas.Count() - 1;
                }

                // Save
                GameOpened.SaveMapEncounter(Mapnames.FirstOrDefault(x => x.Value == mapListBox.SelectedItem.ToString()).Key, EncountTables.ToArray(), EncountCharas.ToArray());

                EncounterDataGridEditInProgress = false;
                IsProcessingCellValueChange = false;
            }
        }

        private void EncounterDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Sélectionnez la ligne sous le pointeur de la souris
                var hti = encounterDataGridView.HitTest(e.X, e.Y);
                if (hti.RowIndex >= 0)
                {
                    // Sélectionnez la ligne sur laquelle le clic droit a eu lieu
                    encounterDataGridView.ClearSelection();
                    encounterDataGridView.Rows[hti.RowIndex].Selected = true;

                    // Obtenez les coordonnées du point pour positionner le menu contextuel
                    Point point = encounterDataGridView.PointToScreen(new Point(e.X, e.Y));

                    // Affichez le menu contextuel à ces coordonnées
                    charaContextMenuStrip.Show(point);
                }
            }
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get selected index
            int encountCharaIndex = SelectedEncountTable.EncountOffsets[encounterDataGridView.SelectedRows[0].Index];

            // Update all indexes
            if (encountCharaIndex != 0 && encountCharaIndex < EncountCharas.Count)
            {
                EncountCharas.RemoveAt(encountCharaIndex);

                if (EncountCharas.Count > 0)
                {
                    for (int i = 0; i < EncountTables.Count; i++)
                    {
                        for (int j = 0; j < EncountTables[i].EncountOffsets.Length; j++)
                        {
                            if (EncountTables[i].EncountOffsets[j] == encountCharaIndex)
                            {
                                // Reset
                                EncountTables[i].EncountOffsets[j] = -1;
                            } else if (EncountTables[i].EncountOffsets[j] > encountCharaIndex)
                            {
                                // Index -1 to all items after encountCharaIndex
                                EncountTables[i].EncountOffsets[j] -= 1;
                            }
                        }
                    }
                }
            }

            // Refresh
            TableFlatComboBox_SelectedIndexChanged(sender, e);
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RemoveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tableFlatComboBox.Items.Count > 0)
            {
                // Remove selected table
                EncountTables.RemoveAt(tableFlatComboBox.SelectedIndex);

                // Save
                GameOpened.SaveMapEncounter(Mapnames.FirstOrDefault(x => x.Value == mapListBox.SelectedItem.ToString()).Key, EncountTables.ToArray(), EncountCharas.ToArray());

                // Refresh
                MapListBox_SelectedIndexChanged(sender, e);
            }
        }
    }
}
