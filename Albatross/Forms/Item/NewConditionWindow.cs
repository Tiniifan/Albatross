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
    public partial class NewConditionWindow : Form
    {
        private List<Yokai> Yokais;

        public List<int> CheckedRows;

        public NewConditionWindow(List<Yokai> yokais)
        {
            InitializeComponent();

            Yokais = yokais;
        }

        private void NewConditionWindow_Load(object sender, EventArgs e)
        {
            foreach (Yokai yokai in Yokais)
            {
                yokaiPreviewDataGridView.Rows.Add(new object[] {false, yokai.Name });
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            CheckedRows = yokaiPreviewDataGridView.Rows.Cast<DataGridViewRow>()
                              .Where(row => Convert.ToBoolean(row.Cells["checkBoxColumn"].Value))
                              .Select(row => row.Index)
                              .ToList();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
