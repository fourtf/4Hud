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
    public partial class SettingsEditor : Form
    {
        Settings settings = new Settings();

        public SettingsEditor()
        {
            InitializeComponent();
            settings.LoadFrom("4Hud.Settings");

            foreach (SettingsItem s in settings.Items)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView.Rows[0].Clone();
                row.Cells[0].Value = s.name;
                row.Cells[1].Value = s.value;
                dataGridView.Rows.Add(row);
            }
        }

        public string getData()
        {
            string s = "";
            foreach (DataGridViewRow r in dataGridView.Rows)
            {
                if (r.Cells[0].ToString() != "")
                    s += r.Cells[0].Value + "|" + r.Cells[1].Value + "\r\n";
            }
            return s;
        }

        private void dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                context.Show(Cursor.Position);
            }
        }

        private void ctDeleteSelectedRows_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell item in dataGridView.SelectedCells)
            {
                try
                {
                    dataGridView.Rows.RemoveAt(item.RowIndex);
                }
                catch { }
            }
        }
    }
}
