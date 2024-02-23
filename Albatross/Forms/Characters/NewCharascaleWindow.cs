using System;
using System.Windows.Forms;

namespace Albatross.Forms.Characters
{
    public partial class NewCharascaleWindow : Form
    {
        public int SelectedBaseIndex;

        public NewCharascaleWindow(string[] baseUnused)
        {
            InitializeComponent();
            baseFlatComboBox.Items.AddRange(baseUnused);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (baseFlatComboBox.SelectedIndex == -1) return;

            SelectedBaseIndex = baseFlatComboBox.SelectedIndex;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
