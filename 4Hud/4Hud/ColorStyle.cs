using System;
using System.Collections.Generic;
using System.Text;
using FastColoredTextBoxNS;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _4Hud
{
    public class ColorStyle : TextStyle
    {
        public Brush ForeBrush { get; set; }
        //public Brush BackgroundBrush { get; set; }
        //public FontStyle FontStyle { get; set; }

        public ColorStyle(Brush ForeBrush) : base(null, null, FontStyle.Regular) { this.ForeBrush = ForeBrush; }

        public override void Draw(Graphics gr, Point position, Range range)
        {
            //This try catch will give the control terrible performance when it would otherwise crash.
            try
            {
                if (range.Text[0] == '\"' && range.Text[range.Text.Length - 1] == '\"')
                {
                    String[] S = range.Text.Substring(1).Remove(range.Text.Length - 2).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Color cl;

                    if (S.Length == 3)
                        cl = Color.FromArgb(intP(S[0]), intP(S[1]), intP(S[2]));
                    else if (S.Length == 4)
                        cl = Color.FromArgb(intP(S[3]), intP(S[0]), intP(S[1]), intP(S[2]));
                    else
                        cl = Color.Black;

                    Font f = new Font(range.tb.Font, FontStyle);
                    String line = range.tb.Lines[range.Start.iLine];
                    float dx = range.tb.CharWidth;
                    float y = position.Y;
                    float x = position.X - 2f;

                    gr.FillRectangle(new SolidBrush(cl), position.X, position.Y,
                        range.tb.CharWidth / 2, range.tb.CharHeight);

                    gr.FillRectangle(new SolidBrush(cl), position.X + (range.End.iChar - range.Start.iChar) * range.tb.CharWidth - range.tb.CharWidth / 2, position.Y,
                        range.tb.CharWidth / 2, range.tb.CharHeight);

                    gr.FillRectangle(new SolidBrush(Color.FromArgb(63, cl)), position.X + range.tb.CharWidth / 2, position.Y,
                        (range.End.iChar - range.Start.iChar) * range.tb.CharWidth - range.tb.CharWidth, range.tb.CharHeight);


                    for (int i = range.Start.iChar; i < range.End.iChar; i++)
                    {
                        gr.DrawString(line[i].ToString(), f, ForeBrush, x, y);
                        x += dx;
                    }
                }
                else
                {
                    ForeBrush = new SolidBrush(Color.Black);

                    Font f = new Font(range.tb.Font, FontStyle);
                    String line = range.tb.Lines[range.Start.iLine];
                    float dx = range.tb.CharWidth;
                    float y = position.Y;
                    float x = position.X - 2f;

                    for (int i = range.Start.iChar; i < range.End.iChar; i++)
                    {
                        gr.DrawString(line[i].ToString(), f, ForeBrush, x, y);
                        x += dx;
                    }
                }
            }
            catch { }
        }

        static int intP(string value)
        {
            int result = 0;
            for (int i = 0; i < value.Length; i++)
            {
                char letter = value[i];
                result = 10 * result + (letter - 48);
            }
            return Math.Max(0, Math.Min(result, 255));
        }
    }
}
