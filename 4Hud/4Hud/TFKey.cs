using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace _4Hud
{
    public partial class Form1
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.S:
                        SaveAll();
                        break;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.F5:
                        if (settings.GetBool("Save All On F5"))
                            SaveAll();
                        Process[] prc = Process.GetProcessesByName("hl2");
                        if (prc.Length != 0)
                        {
                            reloadHud();
                        }
                        break;
                    case Keys.F6:
                        showWindows();
                        break;
                    case Keys.Escape:
                        simulateEsc();
                        break;
                }
            }
        }

        List<TFKey> TFKeys = new List<TFKey>()
        {
            new TFKey(VirtualKeyShort.KEY_A, ScanCodeShort.KEY_A, "A", "A"),
            new TFKey(VirtualKeyShort.KEY_B, ScanCodeShort.KEY_B, "B", "B"),
            new TFKey(VirtualKeyShort.KEY_C, ScanCodeShort.KEY_C, "C", "C"),
            new TFKey(VirtualKeyShort.KEY_D, ScanCodeShort.KEY_D, "D", "D"),
            new TFKey(VirtualKeyShort.KEY_E, ScanCodeShort.KEY_E, "E", "E"),
            new TFKey(VirtualKeyShort.KEY_F, ScanCodeShort.KEY_F, "F", "F"),
            new TFKey(VirtualKeyShort.KEY_G, ScanCodeShort.KEY_G, "G", "G"),
            new TFKey(VirtualKeyShort.KEY_H, ScanCodeShort.KEY_H, "H", "H"),
            new TFKey(VirtualKeyShort.KEY_I, ScanCodeShort.KEY_I, "I", "I"),
            new TFKey(VirtualKeyShort.KEY_J, ScanCodeShort.KEY_J, "J", "J"),
            new TFKey(VirtualKeyShort.KEY_K, ScanCodeShort.KEY_K, "K", "K"),
            new TFKey(VirtualKeyShort.KEY_L, ScanCodeShort.KEY_L, "L", "L"),
            new TFKey(VirtualKeyShort.KEY_M, ScanCodeShort.KEY_M, "M", "M"),
            new TFKey(VirtualKeyShort.KEY_N, ScanCodeShort.KEY_N, "N", "N"),
            new TFKey(VirtualKeyShort.KEY_O, ScanCodeShort.KEY_O, "O", "O"),
            new TFKey(VirtualKeyShort.KEY_P, ScanCodeShort.KEY_P, "P", "P"),
            new TFKey(VirtualKeyShort.KEY_Q, ScanCodeShort.KEY_Q, "Q", "Q"),
            new TFKey(VirtualKeyShort.KEY_R, ScanCodeShort.KEY_R, "R", "R"),
            new TFKey(VirtualKeyShort.KEY_S, ScanCodeShort.KEY_S, "S", "S"),
            new TFKey(VirtualKeyShort.KEY_T, ScanCodeShort.KEY_T, "T", "T"),
            new TFKey(VirtualKeyShort.KEY_U, ScanCodeShort.KEY_U, "U", "U"),
            new TFKey(VirtualKeyShort.KEY_V, ScanCodeShort.KEY_V, "V", "V"),
            new TFKey(VirtualKeyShort.KEY_W, ScanCodeShort.KEY_W, "W", "W"),
            new TFKey(VirtualKeyShort.KEY_X, ScanCodeShort.KEY_X, "X", "X"),
            new TFKey(VirtualKeyShort.KEY_Y, ScanCodeShort.KEY_Y, "Y", "Y"),
            new TFKey(VirtualKeyShort.KEY_Z, ScanCodeShort.KEY_Z, "Z", "Z"),

            new TFKey(VirtualKeyShort.NUMPAD0, ScanCodeShort.NUMPAD0, "KP_INS",       "Numpad 0"),
            new TFKey(VirtualKeyShort.NUMPAD1, ScanCodeShort.NUMPAD1, "KP_END",       "Numpad 1"),
            new TFKey(VirtualKeyShort.NUMPAD2, ScanCodeShort.NUMPAD2, "KP_DOWNARROW", "Numpad 2"),
            new TFKey(VirtualKeyShort.NUMPAD3, ScanCodeShort.NUMPAD3, "KP_PGDN",      "Numpad 3"),
            new TFKey(VirtualKeyShort.NUMPAD4, ScanCodeShort.NUMPAD4, "KP_LEFTARROW", "Numpad 4"),
            new TFKey(VirtualKeyShort.NUMPAD5, ScanCodeShort.NUMPAD5, "KP_5",         "Numpad 5"),
            new TFKey(VirtualKeyShort.NUMPAD6, ScanCodeShort.NUMPAD6, "KP_RIGHTARROW","Numpad 6"),
            new TFKey(VirtualKeyShort.NUMPAD7, ScanCodeShort.NUMPAD7, "KP_HOME",      "Numpad 7"),
            new TFKey(VirtualKeyShort.NUMPAD8, ScanCodeShort.NUMPAD8, "KP_UPARROW",   "Numpad 8"),
            new TFKey(VirtualKeyShort.NUMPAD9, ScanCodeShort.NUMPAD9, "KP_PGUP",      "Numpad 9"),

            new TFKey(VirtualKeyShort.KEY_0, ScanCodeShort.KEY_0, "0", "0"),
            new TFKey(VirtualKeyShort.KEY_1, ScanCodeShort.KEY_1, "1", "1"),
            new TFKey(VirtualKeyShort.KEY_2, ScanCodeShort.KEY_2, "2", "2"),
            new TFKey(VirtualKeyShort.KEY_3, ScanCodeShort.KEY_3, "3", "3"),
            new TFKey(VirtualKeyShort.KEY_4, ScanCodeShort.KEY_4, "4", "4"),
            new TFKey(VirtualKeyShort.KEY_5, ScanCodeShort.KEY_5, "5", "5"),
            new TFKey(VirtualKeyShort.KEY_6, ScanCodeShort.KEY_6, "6", "6"),
            new TFKey(VirtualKeyShort.KEY_7, ScanCodeShort.KEY_7, "7", "7"),
            new TFKey(VirtualKeyShort.KEY_8, ScanCodeShort.KEY_8, "8", "8"),
            new TFKey(VirtualKeyShort.KEY_9, ScanCodeShort.KEY_9, "9", "9"),

            new TFKey(VirtualKeyShort.ADD, ScanCodeShort.ADD, "KP_PLUS",              "Numpad Plus"),
            new TFKey(VirtualKeyShort.SUBTRACT, ScanCodeShort.SUBTRACT, "KP_MINUS",   "Numpad Minus"),
            new TFKey(VirtualKeyShort.MULTIPLY, ScanCodeShort.MULTIPLY, "KP_MULTIPLY","Numpad Multiply"),
            new TFKey(VirtualKeyShort.DIVIDE, ScanCodeShort.DIVIDE, "KP_DIVIDE",      "Numpad Divide"),

            new TFKey(VirtualKeyShort.INSERT, ScanCodeShort.INSERT, "INS", "Insert"),
            new TFKey(VirtualKeyShort.DELETE, ScanCodeShort.DELETE, "DEL", "Delete"),
        };

        public TFKey GetKeyByDisplayText(string displayText)
        {
            foreach (TFKey k in TFKeys)
            {
                if (k.DisplayText == displayText)
                {
                    return k;
                }
            }
            return null;
        }

        public TFKey GetKeyByTF2KeyName(string TF2KeyName)
        {
            foreach (TFKey k in TFKeys)
            {
                if (k.TFKeyName == TF2KeyName)
                {
                    return k;
                }
            }
            return null;
        }

        public List<String> GetKeyDisplayTextList()
        {
            List<String> l = new List<String>();
            foreach (TFKey k in TFKeys)
                l.Add(k.DisplayText);
            return l;
        }
    }

    public class TFKey
    {
        public VirtualKeyShort VirtualKeyShort;
        public ScanCodeShort ScanCodeShort;
        public String TFKeyName;
        public String DisplayText;

        public TFKey(VirtualKeyShort VirtualKeyShort, ScanCodeShort ScanCodeShort, String TFKeyName, String DisplayText)
        {
            this.VirtualKeyShort = VirtualKeyShort;
            this.ScanCodeShort = ScanCodeShort;
            this.TFKeyName = TFKeyName;
            this.DisplayText = DisplayText;
        }

        public TFKey() { }
    }
}
