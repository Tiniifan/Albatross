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

namespace Albatross.Forms.Shops
{
    public partial class ShopWindow : Form
    {
        private IGame GameOpened;

        private List<IItem> Items;

        private List<IShopConfig> ShopConfigs;

        private List<IShopValidCondition> ShopValidConditions;

        private T2bþ Itemnames;

        public ShopWindow(IGame game)
        {
            GameOpened = game;

            Items = new List<IItem>();
            ShopConfigs = new List<IShopConfig>();
            ShopValidConditions = new List<IShopValidCondition>();

            InitializeComponent();
            LoadShop();
        }

        private string[] GetNames(IItem[] items)
        {
            HashSet<string> encounteredNames = new HashSet<string>();
            Dictionary<string, int> nameOccurrences = new Dictionary<string, int>();

            return items
                .Select((item, index) =>
                {
                    if (Itemnames.Nouns.TryGetValue(item.NameHash, out var noun) && noun.Strings.Count > 0)
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

                    return "Item " + index;
                })
                .ToArray();
        }

        private void LoadShop()
        {
            // Reset form
            shopListBox.Items.Clear();
            ((DataGridViewComboBoxColumn)shopDataGridView.Columns[1]).Items.Clear();

            if (GameOpened.Name == "Yo-Kai Watch 1")
            {
                shopDataGridView.Columns[3].Visible = false;
                shopDataGridView.Columns[4].Visible = false;
                this.Size = new Size(683, 598);
                shopDataGridView.Size = new Size(404, 511);
            } else
            {
                shopDataGridView.Columns[3].Visible = true;
                shopDataGridView.Columns[4].Visible = true;
                this.Size = new Size(985,598);
                shopDataGridView.Size = new Size(704, 511);
            }

            // Get resources
            Items.AddRange(GameOpened.GetItems("all"));

            // Get names
            Itemnames = new T2bþ(GameOpened.Files["item_text"].File.Directory.GetFileFromFullPath(GameOpened.Files["item_text"].Path));

            // Prepare combobox
            ((DataGridViewComboBoxColumn)shopDataGridView.Columns[1]).Items.AddRange(GetNames(Items.ToArray()));

            // Get all files starting with "shop_shp" from the specified directory
            var files = GameOpened.Game.Directory.GetFolderFromFullPath(GameOpened.Files["shop"].Path).Files.Keys;

            // Group files by their common prefix (everything up to the last "_")
            var fileGroups = files
                .Where(x => x.StartsWith("shop_shp"))
                .GroupBy(x => x.Substring(x.LastIndexOf('_') + 1));

            // Select the last file from each group based on the ordering
            var lastFiles = fileGroups
                .Select(group => group.OrderByDescending(x => x).First());

            shopListBox.Items.AddRange(lastFiles.ToArray());
        }

        private void ShopListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shopListBox.SelectedIndex == -1) return;

            shopDataGridView.Rows.Clear();
            shopDataGridView.Enabled = false;

            (IShopConfig[], IShopValidCondition[]) shopData = GameOpened.GetShop(shopListBox.SelectedItem.ToString());
            ShopConfigs = shopData.Item1.ToList();

            if (shopData.Item2 != null)
            {
                ShopValidConditions = shopData.Item2.ToList();
                shopDataGridView.Columns[3].ReadOnly = false;
                shopDataGridView.Columns[4].ReadOnly = false;
            } else
            {
                shopDataGridView.Columns[3].ReadOnly = true;
                shopDataGridView.Columns[4].ReadOnly = true;
            }

            // Get combobox from sgopDataGridView
            DataGridViewComboBoxColumn comboBox = (DataGridViewComboBoxColumn)shopDataGridView.Columns[1];

            // Fill shopDataGridView
            foreach (IShopConfig shopConfig in ShopConfigs)
            {
                Bitmap itemPicture = null;
                IItem item = Items.FirstOrDefault(x => x.ItemHash == shopConfig.ItemHash);

                // Try to get item picture
                if (item != null)
                {
                    try
                    {
                        int fileNumber = 0;

                        switch (GameOpened.Name)
                        {
                            case "Yo-Kai Watch 1":
                                fileNumber = item.ItemPosY * 16 + (item.ItemPosX + 1);
                                break;
                        }

                        string fileName = "item_" + fileNumber.ToString().PadLeft(3, '0');
                        byte[] imageData = GameOpened.Files["item_icon"].File.Directory.GetFileFromFullPath(GameOpened.Files["item_icon"].Path + "/" + fileName + ".xi");
                        itemPicture = IMGC.ToBitmap(imageData);
                    }
                    catch
                    {
                        itemPicture = null;
                    }
                }

                if (shopData.Item2 != null)
                {

                } else
                {
                    shopDataGridView.Rows.Add(itemPicture, comboBox.Items[Items.IndexOf(item)], (shopConfig.Price / 100f).ToString("0.00"));
                }
            }

            shopDataGridView.Enabled = true;
        }
    }
}
