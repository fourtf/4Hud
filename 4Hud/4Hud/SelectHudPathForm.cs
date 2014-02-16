using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _4Hud
{
    public partial class SelectHudPathForm : Form
    {
        public Boolean UseCustomFolder { get { return radCustomPath.Checked; } }
        public String CustomPath { get { return lblCustom.Text; } }
        public String HudPath { get { return lblDirect.Text; } }


        public SelectHudPathForm(bool useCustomFolder, string customPath, string hudPath)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            lblCustom.Text = customPath;
            lblDirect.Text = hudPath;

            if (useCustomFolder)
            {
                radCustomPath.Checked = true;
            }
            else
            {
                radDirectFolder.Checked = true;
            }
        }

        private void radCustomPath_CheckedChanged(object sender, EventArgs e)
        {
            if (radCustomPath.Checked)
            {
                groupCustom.Enabled = true;
                groupDirect.Enabled = false;
            }
            else
            {
                groupCustom.Enabled = false;
                groupDirect.Enabled = true;
            }
        }

        private void btnCustomFolder_Click(object sender, EventArgs e)
        {
            OpenFolderDialog dialog = new OpenFolderDialog();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                lblCustom.Text = dialog.Folder.TrimEnd(System.IO.Path.DirectorySeparatorChar) + System.IO.Path.DirectorySeparatorChar;
            }
        }

        private void btnDirectFolder_Click(object sender, EventArgs e)
        {
            OpenFolderDialog dialog = new OpenFolderDialog();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                lblDirect.Text = dialog.Folder.TrimEnd(System.IO.Path.DirectorySeparatorChar) + System.IO.Path.DirectorySeparatorChar;
            }
        }
    }
}
