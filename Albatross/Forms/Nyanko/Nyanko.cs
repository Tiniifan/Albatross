using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Albatross.Tools;
using Albatross.Level5.Text;
using Albatross.Level5.Text.Logic;

namespace Albatross.Forms.Nyanko
{
    public partial class Nyanko : Form
    {
        private string FileName;

        private bool ShowText;

        private bool ShowNoun;

        private int FocusHash;

        public T2bþ T2bþFileOpened;

        private TreeNode SelectedRightClickTreeNode;

        public int SelectedHash;

        private class TreeNodeTag
        {
            public string Type { get; set; }
            public int Key { get; set; }
            public int Number { get; set; }
        }

        public Nyanko(string fileName, T2bþ t2bþFileOpened, bool showText, bool showNoun, int focusHash = 0)
        {
            InitializeComponent();

            FileName = fileName;
            ShowText = showText;
            ShowNoun = showNoun;
            FocusHash = focusHash;
            T2bþFileOpened = t2bþFileOpened;
        }

        private void SelectNodeByTagKey(int keyToFind)
        {
            foreach (TreeNode node in textTreeView.Nodes)
            {
                SelectNodeByTagKeyRecursive(node, keyToFind);
            }
        }

        private void SelectNodeByTagKeyRecursive(TreeNode node, int keyToFind)
        {
            if (node.Tag is TreeNodeTag tag && tag.Key == keyToFind)
            {
                textTreeView.SelectedNode = node;
                node.EnsureVisible();
                return;
            }

            foreach (TreeNode childNode in node.Nodes)
            {
                SelectNodeByTagKeyRecursive(childNode, keyToFind);
            }
        }

        private void DrawTreeView(string name)
        {
            TreeNode rootNode = new TreeNode(name);
            rootNode.Tag = new TreeNodeTag
            {
                Type = "FileName",
                Key = 0,
            };

            if (ShowText)
            {
                TreeNode textNode = new TreeNode("Text");
                textNode.Tag = new TreeNodeTag
                {
                    Type = "TextType",
                    Key = 0,
                };
                textNode.ContextMenuStrip = textTypeContextMenuStrip;

                foreach (KeyValuePair<int, TextConfig> text in T2bþFileOpened.Texts)
                {
                    int index = 0;
                    foreach (StringLevel5 stringLevel5 in text.Value.Strings)
                    {
                        TreeNode textValueNode = new TreeNode(stringLevel5.Text);
                        textValueNode.Tag = new TreeNodeTag
                        {
                            Type = "TextItem",
                            Key = text.Key,
                            Number = index,
                        };
                        textValueNode.ContextMenuStrip = textItemContextMenuStrip;
                        textNode.Nodes.Add(textValueNode);

                        index++;
                    }
                }

                rootNode.Nodes.Add(textNode);
            }

            if (ShowNoun)
            {
                TreeNode nounNode = new TreeNode("Noun");
                nounNode.Tag = new TreeNodeTag
                {
                    Type = "NounType",
                    Key = 0,
                };
                nounNode.ContextMenuStrip = nounTypeContextMenuStrip;

                foreach (KeyValuePair<int, TextConfig> noun in T2bþFileOpened.Nouns)
                {
                    foreach (StringLevel5 stringLevel5 in noun.Value.Strings)
                    {
                        TreeNode nounValueNode = new TreeNode(stringLevel5.Text);
                        nounValueNode.Tag = new TreeNodeTag
                        {
                            Type = "NounItem",
                            Key = noun.Key,
                            Number = 0
                        };

                        nounValueNode.ContextMenuStrip = textItemContextMenuStrip;
                        nounNode.Nodes.Add(nounValueNode);
                    }
                }

                rootNode.Nodes.Add(nounNode);
            }

            textTreeView.Nodes.Clear();
            textTreeView.Nodes.Add(rootNode);

            if (textTreeView.Nodes.Count > 0)
            {
                textTreeView.SelectedNode = textTreeView.Nodes[0];
            }
        }

        private void Nyanko_Load(object sender, EventArgs e)
        {
            DrawTreeView(FileName);
            textTreeView.ExpandAll();

            if (FocusHash != 0)
            {
                SelectNodeByTagKey(FocusHash);
            }
        }

        private void TextTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNodeTag tag = e.Node.Tag as TreeNodeTag;

            if (e.Node.Tag != null && (tag.Type == "TextItem" || tag.Type == "NounItem"))
            {
                textTextBox.Text = e.Node.Text;
                textTextBox.Enabled = true;
                confirmButton.Enabled = true;
            }
            else
            {
                textTextBox.Enabled = false;
                confirmButton.Enabled = false;
                textTextBox.Clear();
            }
        }

        private void TextTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SelectedRightClickTreeNode = e.Node;
            }
        }

        private void TextTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!textTextBox.Focused || textTreeView.SelectedNode == null) return;

            TreeNode selectedNode = textTreeView.SelectedNode;

            selectedNode.Text = textTextBox.Text;

            TreeNodeTag tag = selectedNode.Tag as TreeNodeTag;
            string entryType = tag.Type.ToString();

            if (entryType == "TextItem")
            {
                T2bþFileOpened.Texts[tag.Key].Strings[tag.Number].Text = selectedNode.Text;
            }
            else if (entryType == "NounItem")
            {
                T2bþFileOpened.Nouns[tag.Key].Strings[tag.Number].Text = selectedNode.Text;
            }
        }

        private void RemoveTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;

            TreeNodeTag tag = selectedNode.Tag as TreeNodeTag;
            string entryType = tag.Type.ToString();

            if (entryType == "TextItem")
            {
                T2bþFileOpened.Texts.Remove(tag.Key);
            }
            else if (entryType == "NounItem")
            {
                T2bþFileOpened.Nouns.Remove(tag.Key);
            }

            selectedNode.Remove();
            SelectedRightClickTreeNode = null;
        }

        private void NounTypeAddTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;

            string newText = Interaction.InputBox("Enter text:");
            int crc32 = unchecked((int)Crc32.Compute(Encoding.UTF8.GetBytes("noun_" + newText)));

            T2bþFileOpened.Nouns.Add(crc32, new TextConfig(new List<StringLevel5>() { new StringLevel5(0, newText) }));

            TreeNode nounValueNode = new TreeNode(newText);
            nounValueNode.Tag = new TreeNodeTag
            {
                Type = "NounItem",
                Key = crc32,
                Number = 0
            };

            nounValueNode.ContextMenuStrip = textItemContextMenuStrip;
            selectedNode.Nodes.Add(nounValueNode);

            textTreeView.SelectedNode = nounValueNode;
            nounValueNode.EnsureVisible();

            SelectedRightClickTreeNode = null;
        }

        private void AddKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRightClickTreeNode == null) return;

            TreeNode selectedNode = SelectedRightClickTreeNode;

            string newText = Interaction.InputBox("Enter text:");
            int crc32 = unchecked((int)Crc32.Compute(Encoding.UTF8.GetBytes("text_" + newText)));

            T2bþFileOpened.Texts.Add(crc32, new TextConfig(new List<StringLevel5>() { new StringLevel5(0, newText) }));

            TreeNode textValueNode = new TreeNode(newText);
            textValueNode.Tag = new TreeNodeTag
            {
                Type = "TextItem",
                Key = crc32,
                Number = 0
            };

            textValueNode.ContextMenuStrip = textItemContextMenuStrip;
            selectedNode.Nodes.Add(textValueNode);

            textTreeView.SelectedNode = textValueNode;
            textValueNode.EnsureVisible();

            SelectedRightClickTreeNode = null;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(textTreeView.SelectedNode.Text + " " + (textTreeView.SelectedNode.Tag as TreeNodeTag).Key);
            SelectedHash = (textTreeView.SelectedNode.Tag as TreeNodeTag).Key;
            this.Close();
        }
    }
}
