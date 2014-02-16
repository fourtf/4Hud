using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace _4Hud
{
    public partial class Line : UserControl
    {
        public Line()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(137, 140,149)) , 0, 0, Size.Width, 0);
        }
    }
}
