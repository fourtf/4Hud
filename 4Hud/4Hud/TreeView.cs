using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace _4Hud
{
    public partial class Form1 : Form
    {
        private void treeviewFindTxt_TextChanged(object sender, EventArgs e)
        {
            if (treeviewFindTxt.Text == "")
            {
                treeviewFindBtn.Image = Properties.Resources.find;
                treeViewSearch.Visible = false;
            }
            else
            {
                treeViewSearch.Visible = true;
                treeviewFindBtn.Image = Properties.Resources.x;
                treeViewSearch.Nodes.Clear();
                TreeNode n = FilterNodes((TreeNode)treeView.Nodes[0].Clone(), treeviewFindTxt.Text.ToLower());
                if (n != null)
                    treeViewSearch.Nodes.Add(n);
            }
        }

        private TreeNode FilterNodes(TreeNode node, string filter)
        {
            bool folder = node.Nodes.Count != 0;

            for (int i = 0; i < node.Nodes.Count; ++i)
            {
                TreeNode n = FilterNodes(node.Nodes[i], filter);
                if (n == null)
                {
                    node.Nodes.RemoveAt(i);
                    --i;
                }
                else
                    node.Nodes[i] = n;
            }

            if (folder && node.Nodes.Count == 0)
                return null;
            if (node.Nodes.Count == 0 && !node.Text.ToLower().Contains(filter))
                return null;

            node.Expand();
            return node;
        }

        void treeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].ImageIndex == -1)
                e.Node.Nodes[0].Expand();
        }

        private void treeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode n = e.Node.PrevNode;
            try
            {
                int subs = e.Node.FullPath.IndexOf('\\') + 1;
                while (n != null)
                {
                    if (n.Text == e.Label)
                        e.CancelEdit = true;
                    n = n.PrevNode;
                }

                n = e.Node.NextNode;
                while (n != null)
                {
                    if (n.Text == e.Label)
                        e.CancelEdit = true;
                    n = n.NextNode;
                }

                if (!e.CancelEdit)
                {
                    File.Move(currentPath + e.Node.FullPath.Substring(subs), currentPath + e.Node.FullPath.Remove(e.Node.FullPath.LastIndexOf('\\')).Substring(subs) + "\\" + e.Label);
                    editor1.RenameTab(e.Node.FullPath.Substring(subs), e.Node.FullPath.Remove(e.Node.FullPath.LastIndexOf('\\')).Substring(subs) + "\\" + e.Label);
                    editor2.RenameTab(e.Node.FullPath.Substring(subs), e.Node.FullPath.Remove(e.Node.FullPath.LastIndexOf('\\')).Substring(subs) + "\\" + e.Label);
                }
            }
            catch
            {
                e.CancelEdit = true;
            }
        }

        private void treeviewFindBtn_Click(object sender, EventArgs e)
        {
            treeviewFindTxt.Text = "";
        }

        private void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
            {
                if (file.FullName.Substring(currentPath.Length) == "data.txt")
                    directoryNode.Nodes.Add(new TreeNode(file.Name, 8, 8));
                else if (file.FullName.EndsWith(".zip"))
                    directoryNode.Nodes.Add(new TreeNode(file.Name, 1, 1));
                else if (file.FullName.EndsWith(".res"))
                    directoryNode.Nodes.Add(new TreeNode(file.Name, 2, 2));
                else if (file.FullName.EndsWith(".otf") || file.FullName.EndsWith(".ttf"))
                    directoryNode.Nodes.Add(new TreeNode(file.Name, 3, 3));
                else if (file.FullName.EndsWith(".png") || file.FullName.EndsWith(".jpg") || file.FullName.EndsWith(".jpeg") || file.FullName.EndsWith(".gif") || file.FullName.EndsWith(".vtf"))
                    directoryNode.Nodes.Add(new TreeNode(file.Name, 4, 4));
                else if (file.FullName.EndsWith(".txt") || file.FullName.EndsWith(".vmt"))
                    directoryNode.Nodes.Add(new TreeNode(file.Name, 5, 5));
                else if (file.FullName.EndsWith(".exe"))
                    directoryNode.Nodes.Add(new TreeNode(file.Name, 6, 6));
                else
                    directoryNode.Nodes.Add(new TreeNode(file.Name, 7, 7));
            }
            return directoryNode;
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Node.ImageIndex != -1)
            {
                string fpath = e.Node.FullPath;

                if (fpath.ToLower().EndsWith(".ttf") ||
                    fpath.ToLower().EndsWith(".otf") ||
                    fpath.ToLower().EndsWith(".vtf") ||
                    fpath.ToLower().EndsWith(".png") ||
                    fpath.ToLower().EndsWith(".jpg") ||
                    fpath.ToLower().EndsWith(".jpeg") ||
                    fpath.ToLower().EndsWith(".gif") ||
                    fpath.ToLower().EndsWith(".exe") ||
                    fpath.ToLower().EndsWith(".ico")
                    )
                {
                    try
                    {
                        Process.Start(currentPath + fpath.Substring(fpath.IndexOf('\\') + 1));
                    }
                    catch { }
                }
                else
                {
                    //FIX THIS
                    try
                    {
                        if (!editor1.TabExists(fpath.Substring(fpath.IndexOf('\\') + 1)) && !editor2.TabExists(fpath.Substring(fpath.IndexOf('\\') + 1)))
                        {
                            editor1.AddTab(File.ReadAllText(currentPath + fpath.Substring(fpath.IndexOf('\\') + 1)), fpath.Substring(fpath.IndexOf('\\') + 1), e.Node.ImageIndex);
                        }
                        else
                        {
                            if (editor1.TabExists(fpath.Substring(fpath.IndexOf('\\') + 1)))
                                editor1.SelectTab(fpath.Substring(fpath.IndexOf('\\') + 1));
                            if (editor2.TabExists(fpath.Substring(fpath.IndexOf('\\') + 1)))
                                editor2.SelectTab(fpath.Substring(fpath.IndexOf('\\') + 1));
                        }
                    }
                    catch { }
                }
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Node.ImageIndex != -1)
            {
                tmpNode = e.Node;
                treeViewContext.Show(Cursor.Position);
            }
        }


        private void cmOpenLeftEditor_Click(object sender, EventArgs e)
        {
            String s = tmpNode.FullPath.Substring(tmpNode.FullPath.IndexOf('\\') + 1);

            if (!editor1.TabExists(s) && !editor2.TabExists(s))
            {
                try
                {
                    editor1.AddTab(File.ReadAllText(currentPath + s), s, tmpNode.ImageIndex);
                }
                catch { }
            }
        }

        private void cmOpenRightEditor_Click(object sender, EventArgs e)
        {
            String s = tmpNode.FullPath.Substring(tmpNode.FullPath.IndexOf('\\') + 1);

            if (!editor1.TabExists(s) && !editor2.TabExists(s))
            {
                try
                {
                    editor2.AddTab(File.ReadAllText(currentPath + s), s, tmpNode.ImageIndex);
                }
                catch { }
            }
        }

        private void cmOpenDefaultTool_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Process.Start(currentPath + tmpNode.FullPath.Substring(tmpNode.FullPath.IndexOf('\\') + 1));
                }
                catch { }
            }
            catch
            {
                try
                {
                    MessageBox.Show("Couldn't launch " + currentPath + tmpNode.FullPath.Substring(tmpNode.FullPath.IndexOf('\\') + 1));
                }
                catch { }
            }
        }

        private void cmOpenEditor_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Process.Start("notepad.exe", currentPath + tmpNode.FullPath.Substring(tmpNode.FullPath.IndexOf('\\') + 1));
                }
                catch { }
            }
            catch
            {
                try
                {
                    MessageBox.Show("Couldn't launch notepad.exe with\r\n" + currentPath + tmpNode.FullPath.Substring(tmpNode.FullPath.IndexOf('\\') + 1));
                }
                catch { }
            }
        }

        private void cmOpenExplorer_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("Explorer.exe", "/Select," + currentPath + tmpNode.FullPath.Substring(tmpNode.FullPath.IndexOf('\\') + 1));
            }
            catch { }
        }
    }
}
