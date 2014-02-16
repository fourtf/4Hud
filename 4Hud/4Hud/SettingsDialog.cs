using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace _4Hud
{
    public partial class SettingsDialog : Form
    {
        public delegate void SettingChangedHandler(string name, string value);
        public event SettingChangedHandler SettingChanged;

        private List<TFKey> TFKeys = new List<TFKey>();

        public SettingsDialog(List<TFKey> keys, Settings settings)
        {
            InitializeComponent();
            this.TFKeys = keys;

            List<String> keynames = new List<string>();
            foreach (TFKey k in keys)
                keynames.Add(k.DisplayText);

            combReloadHud.Items.AddRange(keynames.ToArray());

            foreach (string s in settings.GetStringArray("Launch Presets"))
            {
                try
                {
                    string[] S = s.Split('?');
                    gridLaunch.Rows.Add(S[0], S[1], S[2], bool.Parse(S[3]), bool.Parse(S[4]));
                }
                catch { }
            }

            chkDev.Checked = settings.GetBool("Developer");
            txtLaunchLine.Text = settings.GetString("Custom Launch Line");

            TFKey tmp = new TFKey();
            if (GetKeyByTF2Keyname(settings.GetString("TF2 Reload Scheme Key"), ref tmp))
            {
                combReloadHud.SelectedItem = tmp.DisplayText;
                txtReloadConsoleCode.Text = "bind " + tmp.TFKeyName + @" ""hud_reloadscheme; echo hud_reloadscheme""";
            }
        }

        public bool GetKeyByDisplayText(string displayText, ref TFKey key)
        {
            foreach (TFKey k in TFKeys)
                if (k.DisplayText == displayText)
                {
                    key = k; return true;
                }
            return false;
        }

        public bool GetKeyByTF2Keyname(string TF2KeyName, ref TFKey key)
        {
            foreach (TFKey k in TFKeys)
                if (k.TFKeyName == TF2KeyName)
                {
                    key = k; return true;
                }
            return false;
        }

        public void Show(int tabPage)
        {
            try
            {
                tabControl1.SelectedIndex = tabPage;
            }
            catch { }
            Show();
        }

        private void Set(string name, string value)
        {
            if (SettingChanged != null)
                SettingChanged(name, value);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPresetsReset_Click(object sender, EventArgs e)
        {
            gridLaunch.Rows.Add("embed x480, 4:3", "640", "480", false, true);
            gridLaunch.Rows.Add("embed x480, 5:4", "600", "480", false, true);
            gridLaunch.Rows.Add("embed x480, 16:9", "854", "480", false, true);
            gridLaunch.Rows.Add("embed x480, 16:10", "768", "480", false, true);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            gridLaunch.Rows.Clear();
            gridLaunch.Rows.Add("embed x480, 4:3", "640", "480", false, true);
            gridLaunch.Rows.Add("embed x480, 5:4", "600", "480", false, true);
            gridLaunch.Rows.Add("embed x480, 16:9", "854", "480", false, true);
            gridLaunch.Rows.Add("embed x480, 16:10", "768", "480", false, true);

        }

        private void chkDev_CheckedChanged(object sender, EventArgs e)
        {
            Set("Developer", chkDev.Checked.ToString());
        }

        private void gridLaunch_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewCell cell = gridLaunch.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (e.ColumnIndex == 0)
                {
                    if (((string)cell.Value).Contains("|") || ((string)cell.Value).Contains("?"))
                        cell.ErrorText = @"Aliases may not contain ""|"" or ""?""";
                    else
                        cell.ErrorText = null;
                }
                else if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
                {
                    int Out;
                    if (!int.TryParse((string)cell.Value, out Out))
                        cell.ErrorText = "Not a valid number";
                    else if (Out < 1)
                        cell.ErrorText = "Number too small";
                    else
                        cell.ErrorText = null;
                }
                else
                {
                    if ((bool)gridLaunch.Rows[e.RowIndex].Cells[3].Value == true && (bool)gridLaunch.Rows[e.RowIndex].Cells[4].Value == true)
                        gridLaunch.Rows[e.RowIndex].Cells[4].ErrorText = "Fullscreen and Hook in 4Hud is not possible at the same time!";
                    else
                        gridLaunch.Rows[e.RowIndex].Cells[4].ErrorText = null;
                }
            }
            catch { }
        }

        private string fix(string s)
        {
            return s.Replace("?", "").Replace("|", "");
        }
        
        protected override void OnClosing(CancelEventArgs e)
        {
            string s = "";
            foreach (DataGridViewRow r in gridLaunch.Rows)
            {
                if (!String.IsNullOrEmpty(r.Cells[0].Value as string))
                {
                    s += fix(r.Cells[0].Value.ToString()) + "?";
                    s += fix(r.Cells[1].Value.ToString()) + "?";
                    s += fix(r.Cells[2].Value.ToString()) + "?";
                    s += r.Cells[3].Value.ToString() + "?";
                    s += r.Cells[4].Value.ToString() + "|";
                }
            }
            Set("Launch Presets", s.TrimEnd('|'));
        
            base.OnClosing(e);
        }

        private void combReloadHud_SelectedIndexChanged(object sender, EventArgs e)
        {
            TFKey tmp = new TFKey();
            if (GetKeyByDisplayText(combReloadHud.Text, ref tmp))
            {
                txtReloadConsoleCode.Text = "bind " + tmp.TFKeyName + @" ""hud_reloadscheme; echo hud_reloadscheme""";
                Set("TF2 Reload Scheme Key", tmp.TFKeyName);
            }
        }

        private void btnHudOpen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Please direct to your Hud folder.";
            if (Directory.Exists(@"C:\Program Files (x86)\Steam\SteamApps\common\Team Fortress 2\tf\custom\"))
                dialog.SelectedPath = @"C:\Program Files (x86)\Steam\SteamApps\common\Team Fortress 2\tf\custom\";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Set("Hud Paths", dialog.SelectedPath + "\\");
            }
        }

        private void btnPresetsAdd_Click(object sender, EventArgs e)
        {
            gridLaunch.Rows.Add("", "", "", false, false);
        }

        private void btnPresetsRemove_Click(object sender, EventArgs e)
        {
            if (gridLaunch.SelectedCells.Count != 0)
            {
                gridLaunch.Rows.RemoveAt(gridLaunch.SelectedCells[0].RowIndex);
            }
        }

        private void txtLaunchLine_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("wub");
            Set("Custom Launch Line", txtLaunchLine.Text);
        }

        private void btnLaunchLine_Click(object sender, EventArgs e)
        {
            txtLaunchLine.Text = "-console -novid -nopreload +developer";
        }
    }
}
