using System;
using System.Collections.Generic;
using System.Text;

namespace _4Hud
{
    public struct LaunchPresent
    {
        public string Alias;
        public int Width;
        public int Height;
        public bool Full;
        public bool Hook;

        public LaunchPresent(string Alias, int Width, int Height, bool Full, bool Hook)
        {
            this.Alias = Alias;
            this.Width = Width;
            this.Height = Height;
            this.Full = Full;
            this.Hook = Hook;
        }
    }
}
