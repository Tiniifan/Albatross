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

        private IEncountChara SelectedEncountChara;

        private List<string> Filenames;

        private T2bþ Charanames;

        public EncounterWindow(IGame game)
        {
            GameOpened = game;

            Charabases = new List<ICharabase>();
            Charaparams = new List<ICharaparam>();
            EncountTables = new List<IEncountTable>();
            EncountCharas = new List<IEncountChara>();
            Filenames = new List<string>();

            InitializeComponent();
            LoadEncounter();
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

            // Prepare combobox
            ((DataGridViewComboBoxColumn)encounterDataGridView.Columns[1]).Items.AddRange(GetNames(Charaparams.ToArray()));

            // Get folder who contains encounter data
            Filenames = GameOpened.GetMapWhoContainsEncounter().ToList();
            mapListBox.Items.AddRange(Filenames.ToArray());
        }

        private void MapListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mapListBox.SelectedIndex == -1) return;

            // Get map encounter data
            (IEncountTable[], IEncountChara[]) encounterData = GameOpened.GetMapEncounter(mapListBox.SelectedItem.ToString());
            EncountTables = encounterData.Item1.ToList();
            EncountCharas = encounterData.Item2.ToList();

            // Fill table
            tableFlatComboBox.Items.Clear();
            tableFlatComboBox.Items.AddRange(EncountTables.Select((table, index) => $"Table {index + 1}").ToArray());

            mapGroupBox.Enabled = true;
        }

        private void TableFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!tableFlatComboBox.Focused && tableFlatComboBox.SelectedIndex != -1) return;

            encounterDataGridView.Rows.Clear();
            SelectedEncountTable = EncountTables[tableFlatComboBox.SelectedIndex];
            hashTextBox.Text = SelectedEncountTable.EncountConfigHash.ToString("X8");

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

    }
}
