using System;
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

namespace Albatross.Forms.Item
{
    public partial class ConditionViewWindow : Form
    {
        private IGame Game;

        private List<Yokai> Yokais;

        private Dictionary<string, List<Yokai>> CharaConds;

        private int SelectedCond;

        public ConditionViewWindow(IGame game, List<Yokai> yokais, Dictionary<string, List<Yokai>> charaConds, int selectedIndex)
        {
            InitializeComponent();

            Game = game;
            Yokais = yokais;
            CharaConds = charaConds;
            SelectedCond = selectedIndex;
        }

        private void ConditionViewWindow_Load(object sender, System.EventArgs e)
        {
            yokaiFlatComboBox.Items.AddRange(Yokais.ToArray());
            ((DataGridViewComboBoxColumn)yokaiPreviewDataGridView.Columns[1]).Items.AddRange(Yokais.ToArray());

            condListBox.Items.AddRange(CharaConds.Keys.ToArray());
            condListBox.SelectedIndex = SelectedCond;

            // Create smale image list
            ImageList smallImageList = new ImageList();
            smallImageList.ImageSize = new Size(16, 16);
            smallImageList.ColorDepth = ColorDepth.Depth32Bit;            
        }

        private void CondListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            yokaiPreviewDataGridView.Rows.Clear();

            // Prevent to missing index
            if (condListBox.SelectedIndex == -1)
            {
                yokaiPreviewDataGridView.Enabled = false;
                manageGroupBox.Enabled = false;
                return;
            }
            else
            {
                // Can manage only custom condition
                yokaiPreviewDataGridView.Enabled = true;
                manageGroupBox.Enabled = condListBox.Text.StartsWith("Custom Condition");
                contextMenuStrip1.Enabled = condListBox.Text.StartsWith("Custom Condition");

                //Get all yokais from the condition
                foreach (Yokai yokai in CharaConds.ElementAt(condListBox.SelectedIndex).Value)
                {
                    Image image;

                    try
                    {
                        image = IMGC.ToBitmap(Game.Game.Directory.GetFileFromFullPath("/data/menu/face_icon/" + yokai.ModelName + ".xi"));
                    } catch
                    {
                        image = null;
                    }

                    DataGridViewComboBoxColumn comboBox = (DataGridViewComboBoxColumn)yokaiPreviewDataGridView.Columns[1];

                    yokaiPreviewDataGridView.Rows.Add();
                    yokaiPreviewDataGridView.Rows[yokaiPreviewDataGridView.Rows.Count-1].Cells[0].Value = image;
                    yokaiPreviewDataGridView.Rows[yokaiPreviewDataGridView.Rows.Count-1].Cells[1].Value = comboBox.Items[comboBox.Items.IndexOf(yokai)];
                }

                if (yokaiPreviewDataGridView.Rows.Count > 1)
                {
                    Yokai firstYokai = yokaiPreviewDataGridView.Rows[0].Cells[1].Value as Yokai;
                    yokaiFlatComboBox.SelectedIndex = yokaiFlatComboBox.Items.IndexOf(firstYokai);
                }
            }
        }

        private void YokaiPreviewDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!yokaiPreviewDataGridView.Focused) return;

            if (yokaiPreviewDataGridView.Rows.Count > 1)
            {
                Yokai yokai = yokaiPreviewDataGridView.Rows[yokaiPreviewDataGridView.CurrentRow.Index].Cells[1].Value as Yokai;
                yokaiFlatComboBox.SelectedIndex = yokaiFlatComboBox.Items.IndexOf(yokai);
            }
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            if (yokaiFlatComboBox.SelectedIndex == -1) return;

            Image image;
            Yokai yokai = yokaiFlatComboBox.Items[yokaiFlatComboBox.SelectedIndex] as Yokai;

            try
            {
                image = IMGC.ToBitmap(Game.Game.Directory.GetFileFromFullPath("/data/menu/face_icon/" + yokai.ModelName + ".xi"));
            }
            catch
            {
                image = null;
            }

            DataGridViewComboBoxColumn comboBox = (DataGridViewComboBoxColumn)yokaiPreviewDataGridView.Columns[1];

            yokaiPreviewDataGridView.Rows.Add();
            yokaiPreviewDataGridView.Rows[yokaiPreviewDataGridView.Rows.Count - 1].Cells[0].Value = image;
            yokaiPreviewDataGridView.Rows[yokaiPreviewDataGridView.Rows.Count - 1].Cells[1].Value = comboBox.Items[comboBox.Items.IndexOf(yokai)];

            CharaConds[condListBox.Text].Add(yokai);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (yokaiFlatComboBox.SelectedIndex == -1) return;
            if (yokaiPreviewDataGridView.Rows.Count < 1) return;

            Image image;
            Yokai yokai = yokaiFlatComboBox.Items[yokaiFlatComboBox.SelectedIndex] as Yokai;

            try
            {
                image = IMGC.ToBitmap(Game.Game.Directory.GetFileFromFullPath("/data/menu/face_icon/" + yokai.ModelName + ".xi"));
            }
            catch
            {
                image = null;
            }

            DataGridViewComboBoxColumn comboBox = (DataGridViewComboBoxColumn)yokaiPreviewDataGridView.Columns[1];

            yokaiPreviewDataGridView.Rows[yokaiPreviewDataGridView.CurrentRow.Index].Cells[0].Value = image;
            yokaiPreviewDataGridView.Rows[yokaiPreviewDataGridView.CurrentRow.Index].Cells[1].Value = comboBox.Items[comboBox.Items.IndexOf(yokai)];

            CharaConds[condListBox.Text][yokaiPreviewDataGridView.CurrentRow.Index] = yokai;
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CharaConds[condListBox.Text].RemoveAt(yokaiPreviewDataGridView.CurrentRow.Index);
            yokaiPreviewDataGridView.Rows.RemoveAt(yokaiPreviewDataGridView.CurrentRow.Index);
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewConditionWindow newConditionWindow = new NewConditionWindow(Yokais);
            DialogResult result = newConditionWindow.ShowDialog();

            if (result == DialogResult.OK)
            {
                List<int> yokaiIndex = newConditionWindow.CheckedRows;
                int lastIndex = Convert.ToInt32(condListBox.Items[condListBox.Items.Count - 1].ToString().Replace("Custom Condition ", ""));
                CharaConds.Add("Custom Condition " + (lastIndex + 1), yokaiIndex.Select(x => Yokais[x]).ToList());
                condListBox.Items.Add("Custom Condition " + (lastIndex + 1));
                MessageBox.Show("Custom Condition " + (lastIndex + 1) + " added!");
            }
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (condListBox.Text.StartsWith("Custom Condition"))
            {
                CharaConds.Remove(condListBox.Text);

                yokaiPreviewDataGridView.Enabled = false;
                manageGroupBox.Enabled = false;
                contextMenuStrip1.Enabled = false;

                condListBox.Items.RemoveAt(condListBox.SelectedIndex);
            } else
            {
                MessageBox.Show("You can't delete this condition");
            }
        }

        private void ConditionViewWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Game.SaveCharaCond(CharaConds);
        }
    }
}
