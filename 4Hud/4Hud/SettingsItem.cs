using System;
using System.Collections.Generic;
using System.Text;

namespace _4Hud
{
    public class SettingsItem
    {
        public string name;
        public string value;

        public SettingsItem(string name, string value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
