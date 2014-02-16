using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace _4Hud
{
    public partial class Transpanel : UserControl
    {
        private int loc = 0;
        private byte drawLine = 0;

        List<dPoint> lines = new List<dPoint>();

        public Transpanel()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, 10, Height);
            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, Width, 10);

            if (drawLine == 1)
            {
                if (ModifierKeys == Keys.Control)
                    e.Graphics.DrawLine(Pens.Blue, 10, loc, Width, loc);
                else
                    e.Graphics.DrawLine(Pens.Red, 10, loc, Width, loc);
            }
            else if (drawLine == 2)
            {
                if (ModifierKeys == Keys.Control)
                    e.Graphics.DrawLine(Pens.Blue, loc, 10, loc, Height);
                else
                    e.Graphics.DrawLine(Pens.Red, loc, 10, loc, Height);
            }

            foreach (dPoint d in lines)
            {
                e.Graphics.DrawLine(new Pen(d.Color), d.p1, d.p2);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.X < 10 && e.Y > 10)
            {
                drawLine = 1;
                loc = e.Y;
                Invalidate();
            }
            else if (e.Y < 10 && e.X > 10)
            {
                drawLine = 2;
                loc = e.X;
                Invalidate();
            }
            else
            {
                drawLine = 0;
                Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            drawLine = 0;
            Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                if (e.X < 10 && e.Y > 10)
                {
                    if (ModifierKeys == Keys.Control)
                        lines.Add(new dPoint(Color.Blue, 10, e.Y, Width, e.Y));
                    else
                        lines.Add(new dPoint(Color.Red, 10, e.Y, Width, e.Y));
                    Invalidate();
                }
                else if (e.Y < 10 && e.X > 10)
                {
                    if (ModifierKeys == Keys.Control)
                        lines.Add(new dPoint(Color.Blue, e.X, 10, e.X, Height));
                    else
                        lines.Add(new dPoint(Color.Red, e.X, 10, e.X, Height));
                    Invalidate();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (lines.Count != 0)
                {
                    for (int i = lines.Count - 1; i > -1; --i)
                    {
                        if (ModifierKeys == Keys.Control)
                        {
                            if (lines[i].Color == Color.Blue)
                                lines.RemoveAt(i);
                        }
                        else
                        {
                            if (lines[i].Color == Color.Red)
                                lines.RemoveAt(i);
                        }
                    }
                    Invalidate();
                }
            }
        }

        internal struct dPoint
        {
            public Color Color;
            public Point p1;
            public Point p2;

            public dPoint(Color Color, Point p1, Point p2)
            {
                this.Color = Color;
                this.p1 = p1;
                this.p2 = p2;
            }

            public dPoint(Color Color, int p1x, int p1y, int p2x, int p2y)
            {
                this.Color = Color;
                this.p1 = new Point(p1x, p1y);
                this.p2 = new Point(p2x, p2y);
            }
        }
    }
}
