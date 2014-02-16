using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace _4Hud
{
    public partial class KeyChooser : UserControl
    {
        public bool Control = false, Shift = false, Alt = false;
        public Keys Key = Keys.None;
        List<Keys> Keyes = new List<Keys>()
        {
            Keys.Control, Keys.ControlKey, Keys.LControlKey, Keys.RControlKey,
            Keys.Shift, Keys.ShiftKey, Keys.LShiftKey, Keys.RShiftKey,
            Keys.Alt,
            Keys.LWin, Keys.RWin
        };

        public KeyChooser()
        {
            InitializeComponent();
            textBox1.KeyDown += new KeyEventHandler(textBox1_KeyDown);
        }

        void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Keyes.Contains(e.KeyCode))
                Key = e.KeyCode;
            else
                Key = Keys.None;
            Control = e.Control;
            Shift = e.Shift;
            Alt = e.Alt;

            e.SuppressKeyPress = true;
            SetText();
        }

        private void SetText()
        {
            string s = "";
            if (Control)
                s += "Ctrl + ";
            if (Shift)
                s += "Shift + ";
            if (Alt)
                s += "Alt + ";
            if (Key != Keys.None)
                textBox1.Text = s + Key.ToString();
        }
    }
}
