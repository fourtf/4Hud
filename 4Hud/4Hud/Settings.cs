using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using FastColoredTextBoxNS;

namespace _4Hud
{
    public class Settings
    {
        public delegate void SettingChangedHandler(object sender, SettingsChangedEventArgs e);
        public event SettingChangedHandler SettingChanged;

        public class SettingsFrom
        {
            public Settings CreateSettingsFrom(String path)
            {
                return new Settings().AddLoadedFrom(path);
            }
        }

        public List<SettingsItem> Items = new List<SettingsItem>();

        public void LoadFrom(string path)
        {
            Load(File.ReadAllText(path));
        }

        public Settings() { }

        public Settings AddLoadedFrom(string path)
        {
            this.LoadFrom(path);
            return this;
        }

        public void Load(string data)
        {
            List<string> l = new List<string>();

            if (data.Contains("\r\n"))
            {
                foreach (string s in data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (!s.StartsWith("//"))
                        l.Add(s);
                }
            }

            if (l.Count == 0)
            {
                l.Add(data);
            }

            Load(l);
        }

        public void Load(IEnumerable<String> data)
        {
            foreach (string s in data)
            {
                bool contains = false;
                foreach (SettingsItem si in Items)
                {
                    if (si.name == s.Split('|')[0])
                    {
                        contains = true;
                        if (si.value != s.Split(new char[] { '|' }, 2)[1])
                        {
                            si.value = s.Split(new char[] { '|' }, 2)[1];
                            if (SettingChanged != null)
                                SettingChanged(this, new SettingsChangedEventArgs(si.name));
                        }
                        break;
                    }
                }

                if (!contains)
                {
                    if (s.Split('|')[0] != "")
                    {
                        if (s.Contains("|"))
                        {
                            Items.Add(new SettingsItem(s.Split('|')[0], s.Split(new char[] { '|' }, 2)[1]));
                            if (SettingChanged != null)
                                SettingChanged(this, new SettingsChangedEventArgs(s.Split('|')[0]));
                        }
                        else
                        {
                            Items.Add(new SettingsItem(s, "true"));
                            if (SettingChanged != null)
                                SettingChanged(this, new SettingsChangedEventArgs(s));
                        }
                    }
                }
            }
        }

        public string GetData()
        {
            string s = "";

            foreach (SettingsItem si in Items)
            {
                s += si.name + "|" + si.value + "\r\n";
            }

            return s;
        }

        public void SaveTo(string path)
        {
            try
            {
                File.WriteAllText(path, GetData());
            }
            catch { }
        }

        public string GetString(string name)
        {
            foreach (SettingsItem s in Items)
            {
                if (s.name == name)
                {
                    return s.value;
                }
            }

            return "";
        }

        public int GetInt(string name)
        {
            foreach (SettingsItem s in Items)
            {
                if (s.name == name)
                {
                    int v;
                    int.TryParse(s.value, out v);
                    return v;
                }
            }

            return 0;
        }

        public bool GetBool(string name)
        {
            foreach (SettingsItem s in Items)
            {
                if (s.name == name)
                {
                    if (s.value.ToLower() == "true")
                        return true;
                    else
                        return false;
                }
            }

            return false;
        }

        public List<string> GetStringArray(string name)
        {
            foreach (SettingsItem s in Items)
            {
                if (s.name == name)
                {
                    return new List<string>(s.value.Split(new String[] { "|" }, StringSplitOptions.RemoveEmptyEntries));
                }
            }

            return new List<string>();
        }

        public Color GetColor(string name)
        {
            foreach (SettingsItem s in Items)
            {
                if (s.name == name)
                {
                    if (s.value.Contains("|"))
                    {
                        string[] S = s.value.Split('|');
                        List<Byte> I = new List<Byte>();

                        foreach (string ss in S)
                        {
                            Byte Out;
                            Byte.TryParse(ss, out Out);
                            I.Add(Out);
                        }

                        if (I.Count < 3)
                            break;
                        else
                        {
                            if (I.Count == 3)
                                return Color.FromArgb(I[0], I[1], I[2]);
                            else
                                return Color.FromArgb(I[0], I[1], I[2], I[3]);
                        }
                    }
                    else
                    {
                        int Out;
                        int.TryParse(s.value, out Out);
                        return Color.FromArgb(Out);
                    }
                }
            }
            return Color.Green;
        }

        public SolidBrush GetSolidBrush(string name)
        {
            return new SolidBrush(GetColor(name));
        }

        public bool Exists(string name)
        {
            bool exists = false;
            foreach (SettingsItem s in Items)
            {
                if (s.name == name)
                    exists = true;
            }
            return exists;
        }

        public void Set(string name, string value)
        {
            bool continiue = true;

            foreach (SettingsItem s in Items)
            {
                if (s.name == name)
                {
                    s.value = value;
                    continiue = false;
                }
            }

            if (continiue)
            {
                Items.Add(new SettingsItem(name, value));
            }

            if (SettingChanged != null)
                SettingChanged(this, new SettingsChangedEventArgs(name));
        }

        public void Set(string name, int value)
        {
            Set(name, value.ToString());
            if (SettingChanged != null)
                SettingChanged(this, new SettingsChangedEventArgs(name));
        }

        public void Set(string name, bool value)
        {
            if (value == true)
                Set(name, "true");
            else
                Set(name, "false");
            if (SettingChanged != null)
                SettingChanged(this, new SettingsChangedEventArgs(name));
        }

        public void Set(string name, string[] value)
        {
            string val = "";
            foreach (string s in value)
            {
                val += s + "|";
            }

            Set(name, val);
            if (SettingChanged != null)
                SettingChanged(this, new SettingsChangedEventArgs(name));
        }

        public void Set(string name, Color value)
        {
            if (value.A == 255)
                Set(name, value.R + "|" + value.G + "|" + value.B);
            else
                Set(name,value.R + "|" + value.G + "|" + value.B + "|" + value.A);
        }

        public void Remove(string name)
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                if (Items[i].name == name)
                {
                    Items.RemoveAt(i);
                }

            }
        }

        public void Clear()
        {
            Items.RemoveRange(0, Items.Count);
        }
    }

    public class SettingsChangedEventArgs : EventArgs
    {
        public string ChangedName;

        public SettingsChangedEventArgs(string changedName)
        {
            ChangedName = changedName;
        }
    }
}
