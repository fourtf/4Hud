using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace _4Hud
{
    public class TabContent
    {
        public string Text;
        public string Name;
        public bool Saved = true;
        public int XScroll1;
        public int YScroll1;
        public int XScroll2;
        public int YScroll2;
        public List<String> Aliases;
        public TabMode TabMode;
        private int imageIndex;
        public int ImageIndex
        {
            get { return imageIndex; }
            set
            {
                switch (value)
                {
                    case 2:
                        this.TabMode = _4Hud.TabMode.res;
                        break;
                    case 8:
                        this.TabMode = _4Hud.TabMode.info;
                        break;
                    default:
                        this.TabMode = _4Hud.TabMode.none;
                        break;
                }
                imageIndex = value;
            }
        }

        public TabContent(string text, string name, int ImageIndex)
        {
            Text = text;
            Name = name;
            Aliases = new List<string>();
            XScroll1 = 0;
            YScroll1 = 0;
            XScroll2 = 0;
            YScroll2 = 0;
            this.ImageIndex = ImageIndex;
        }
    }

    public enum TabMode
    {
        none, res, info
    }
}
