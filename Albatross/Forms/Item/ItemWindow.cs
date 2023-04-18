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
using Albatross.Yokai_Watch.Games.YW1;
using Albatross.Yokai_Watch.Games.YW2;
using Albatross.Yokai_Watch.Games.YW3;
using Albatross.Yokai_Watch.Logic;
using Albatross.Level5.Image;
using Albatross.Forms.Item;

namespace Albatross
{
    public partial class ItemWindow : Form
    {
        private IGame Game;

        private Item SelectedItem;

        private List<Item> Items;

        private List<Yokai> Yokais;

        private Dictionary<string, List<Yokai>> CharaConds;

        private bool TabPageChangingByCode = false;

        public ItemWindow(IGame game)
        {
            InitializeComponent();

            Game = game;
            Items = game.GetItems();
            Yokais = game.GetYokais();
            CharaConds = game.GetCharaCond(Yokais);
        }

        private void ItemWindow_Load(object sender, System.EventArgs e)
        {
            modelFlatComboBox.Items.AddRange(Game.Game.Directory.GetFolderFromFullPath("/data/menu/item_icon/").Files.Where(x => x.Key != "item_icon.xi").Select(x => x.Key.Replace(".xi", "")).ToArray());
            itemListBox.Items.AddRange(Items.ToArray());
            effectFlatComboBox1.Items.AddRange(Game.Effects.ToArray());
            condFlatComboBox.Items.AddRange(CharaConds.Keys.ToArray());

            itemListBox.SelectedIndex = 0;
        }

        private void ItemListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Prevent to missing index
            if (itemListBox.SelectedIndex == -1)
            {
                groupBox1.Enabled = false;
                return;
            }
            else
            {
                groupBox1.Enabled = true;
                SelectedItem = (Item)itemListBox.Items[itemListBox.SelectedIndex];

                nameTextBox.Text = SelectedItem.Name;
                paramIDTextBox.Text = SelectedItem.ID.ToString("X8");
                modelFlatComboBox.SelectedIndex = modelFlatComboBox.Items.IndexOf(SelectedItem.ItemIcon);
                priceFlatNumericUpDown.Value = (decimal)SelectedItem.SellPrize;
                quantityFlatNumericUpDown.Value = SelectedItem.MaxQuantity;
                boughtFlatCheckBox.Checked = SelectedItem.CanBeBuy;
                soldFlatCheckBox.Checked = SelectedItem.CanBeSell;

                TabPageChangingByCode = true;

                if (SelectedItem is Equipment)
                {
                    vsTabControl1.SelectedIndex = 0;

                    Equipment equipment = (Equipment)SelectedItem;

                    // Effects
                    effectFlatComboBox1.SelectedIndex = effectFlatComboBox1.Items.IndexOf(equipment.Effect1);
                    effectFlatComboBox2.SelectedIndex = effectFlatComboBox2.Items.IndexOf(equipment.Effect2);

                    // Stat
                    for (int i = 0; i < 4; i++)
                    {
                        (groupBox2.Controls["minStatFlatNumericUpDown" + (i + 1)] as NumericUpDown).Value = equipment.Stat[i];
                    }

                    // Chara Condition
                    condFlatComboBox.SelectedIndex = equipment.CharaConditionID;
                }
                else if (SelectedItem is Consumable)
                {
                    vsTabControl1.SelectedIndex = 1;
                    
                }
                else if (SelectedItem is KeyItem)
                {
                    vsTabControl1.SelectedIndex = 2;

                }
                else if (SelectedItem is CreatureItem)
                {
                    vsTabControl1.SelectedIndex = 3;

                }
                else if (SelectedItem is SoulItem)
                {
                    vsTabControl1.SelectedIndex = 4;

                }

                TabPageChangingByCode = false;
            }
        }

        private void ModelFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modelFlatComboBox.SelectedIndex == -1)
            {
                pictureBox1.Image = null;
            }
            else
            {
                if (modelFlatComboBox.Focused)
                {
                    SelectedItem.ItemIcon = modelFlatComboBox.Text;
                }

                try
                {
                    byte[] imageData = Game.Game.Directory.GetFileFromFullPath("/data/menu/item_icon/" + SelectedItem.ItemIcon + ".xi");
                    pictureBox1.Image = IMGC.ToBitmap(imageData);
                }
                catch
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private void ConditionViewButton_Click(object sender, EventArgs e)
        {
            ConditionViewWindow conditionViewWindow = new ConditionViewWindow(Game, Yokais, CharaConds, condFlatComboBox.SelectedIndex);
            conditionViewWindow.ShowDialog();
        }

        private void VsTabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!TabPageChangingByCode)
            {
                e.Cancel = true;
            }
        }

        private void PriceFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!priceFlatNumericUpDown.Focused) return;

            SelectedItem.SellPrize = (double)priceFlatNumericUpDown.Value;
        }

        private void QuantityFlatNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!quantityFlatNumericUpDown.Focused) return;

            SelectedItem.MaxQuantity = (int)quantityFlatNumericUpDown.Value;
        }

        private void BoughtFlatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!boughtFlatCheckBox.Focused) return;

            SelectedItem.CanBeBuy = boughtFlatCheckBox.Checked;
        }

        private void SoldFlatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!soldFlatCheckBox.Focused) return;

            SelectedItem.CanBeSell = soldFlatCheckBox.Checked;
        }

        private void EffectFlatComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!effectFlatComboBox1.Focused) return;

            if (SelectedItem is Equipment)
            {
                Equipment equipment = SelectedItem as Equipment;
                equipment.Effect1 = effectFlatComboBox1.Items[effectFlatComboBox1.SelectedIndex] as Effect;
            }
        }

        private void EffectFlatComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!effectFlatComboBox2.Focused) return;

            if (SelectedItem is Equipment)
            {
                Equipment equipment = SelectedItem as Equipment;
                equipment.Effect2 = effectFlatComboBox2.Items[effectFlatComboBox2.SelectedIndex] as Effect;
            }
        }

        private void MinStatValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;

            if (!numericUpDown.Focused) return;

            if (SelectedItem is Equipment)
            {
                Equipment equipment = SelectedItem as Equipment;
                equipment.Stat[Convert.ToInt32(numericUpDown.Name.Replace("minStatFlatNumericUpDown", "")) - 1] = Convert.ToInt32(numericUpDown.Value);
            }
        }

        private void CondFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!condFlatComboBox.Focused) return;

            if (SelectedItem is Equipment)
            {
                Equipment equipment = SelectedItem as Equipment;
                equipment.CharaConditionID = condFlatComboBox.SelectedIndex;
            }
        }

        private void ItemWindow_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
