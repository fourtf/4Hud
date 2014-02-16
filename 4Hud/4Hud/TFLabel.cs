using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace _4Hud
{
    public class TFLabel : UserControl, ITFControl
    {
        ToolTip tip = new ToolTip();
        Boolean ShowToolTip = false;
        public Boolean IsMouseDown = false;
        public Boolean DoResize = false;
        public ResizeDirection ResizeDirections = ResizeDirection.None;

        static string desc = "A simple lable";

        public string GetDescription()
        {
            return desc;
        }

        public TFLabel(string Text, int x, int y, int wide, int tall)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.Text = Text;
            this.Location = new Point(x, y);
            this.AutoSize = false;
            this.Size = new Size(wide, tall);
            this.BackColor = Color.LightGray;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            Invalidate();
            BackColor = Color.LightGray;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (ShowToolTip)
                tip.Show(Text, this, new Point(0, Size.Height));
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            tip.Hide(this);
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            IsMouseDown = true;
            BackColor = Color.FromArgb(220, 220, 220);

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            IsMouseDown = false;
            base.OnMouseUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            DoResize = true;
            if (Focused && !IsMouseDown)
            {
                ////Top Left
                //if (e.Location.X < 5 && e.Location.Y < 5)
                //{
                //    Cursor = Cursors.SizeNWSE;
                //    ResizeDirections = (ResizeDirection.Top | ResizeDirection.Left);
                //}
                ////Top Right
                //else if (e.Location.X > Size.Width - 5 && e.Location.Y < 5)
                //{
                //    Cursor = Cursors.SizeNESW;
                //    ResizeDirections = (ResizeDirection.Top | ResizeDirection.Right);
                //}
                ////Bottom Left
                //else if (e.Location.X < 5 && e.Location.Y > Size.Height - 5)
                //{
                //    Cursor = Cursors.SizeNESW;
                //    ResizeDirections = (ResizeDirection.Bottom | ResizeDirection.Left);
                //}
                //Bottom Right
                if (e.Location.X > Size.Width - 5 && e.Location.Y > Size.Height - 5)
                {
                    Cursor = Cursors.SizeNWSE;
                    ResizeDirections = (ResizeDirection.Bottom | ResizeDirection.Right);
                }
                //Left
                //else if (e.Location.X < 5 /*&& e.Location.Y < Height / 2 + 2 && e.Location.Y > Height / 2 -2*/)
                //{
                //    Cursor = Cursors.SizeWE;
                //    ResizeDirections = ResizeDirection.Left;
                //}
                //Right
                else if (e.Location.X > Width - 5)
                {
                    Cursor = Cursors.SizeWE;
                    ResizeDirections = ResizeDirection.Right;
                }
                //Top
                //else if (e.Location.Y < 5)
                //{
                //    Cursor = Cursors.SizeNS;
                //    ResizeDirections = ResizeDirection.Top;
                //}
                //Bottom
                else if (e.Location.Y > Height - 5)
                {
                    Cursor = Cursors.SizeNS;
                    ResizeDirections = ResizeDirection.Bottom;
                }
                else
                {
                    Cursor = Cursors.Default;
                    DoResize = false;
                    ResizeDirections = ResizeDirection.None;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (((int)e.Graphics.MeasureString(Text, Font).Width) > Width)
                ShowToolTip = true;


            e.Graphics.DrawRectangle(Pens.DarkGray, 0, 0, Size.Width - 1, Size.Height - 1);

            if (Focused)
            {
                if (Width > 50 && Height > 12)
                {
                    e.Graphics.DrawString(Text, Font, Brushes.Black, new PointF(5, (Height - 13) / 2));

                    e.Graphics.DrawRectangles(Pens.SlateBlue,
                        new Rectangle[]
                    {
                        ////top left
                        //new Rectangle(0,0,4,4),
                        //new Rectangle(0, Size.Height/2-2, 4, 4),
                        //new Rectangle(0, Size.Height - 5, 4, 4),
                        ////middle
                        //new Rectangle(Size.Width/2-2, 0, 4, 4),
                        new Rectangle(Size.Width/2-2, Size.Height - 5, 4, 4),
                        //right
                        //new Rectangle(Size.Width -5, 0, 4, 4),
                        new Rectangle(Size.Width -5, Size.Height / 2 - 2, 4, 4),
                        new Rectangle(Size.Width -5, Size.Height - 5, 4, 4),
                    });
                }
                else
                {
                    //e.Graphics.DrawString(Text, Font, Brushes.Black, new PointF(0, (Height - 13) / 2));
                    e.Graphics.DrawString(Text, Font, Brushes.Black, new PointF(5, (Height - 13) / 2));

                    e.Graphics.DrawRectangles(Pens.SlateBlue,
                    new Rectangle[]
                    {
                        //top left
                        //new Rectangle(0,0,4,4),
                        //new Rectangle(0, Size.Height/2-2, 4, 4),
                        //new Rectangle(0, Size.Height - 5, 4, 4),
                        //middle
                        //new Rectangle(Size.Width/2-2, 0, 4, 4),
                        //new Rectangle(Size.Width/2-2, Size.Height - 5, 4, 4),
                        //right
                        //new Rectangle(Size.Width -5, 0, 4, 4),
                        //new Rectangle(Size.Width -5, Size.Height / 2 - 2, 4, 4),
                        new Rectangle(Size.Width -5, Size.Height - 5, 4, 4),
                    });

                }
            }
            else
            {
                e.Graphics.DrawString(Text, Font, Brushes.Black, new PointF(0, (Height - 13) / 2));
            }
        }
    }

    [Flags]
    public enum ResizeDirection
    {
        None = 0,
        Left = 1,
        Right = 2,
        Top = 4,
        Bottom = 8
    }
}
