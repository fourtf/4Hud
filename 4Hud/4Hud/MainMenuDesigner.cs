using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;

namespace _4Hud
{
    public partial class MainMenuDesigner : Form
    {
        Point startPos = new Point();
        Size startSize = new Size();
        Point startPosScreen = new Point();
        ResizeDirection ResizeDirections = ResizeDirection.None;
        Boolean move1 = false;
        Boolean move2 = false;
        Boolean resize = false;
        bool snapToGrid = false;
        int gridSize = 8;
        Control controlToMove = null;
        List<String> hoverControls = new List<string>();
        TFObjectCollection Items = new TFObjectCollection();
        //bool goMove = false;

        Style NameStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        Style ColorStyle1 = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        Style ColorStyle2 = new TextStyle(Brushes.DarkRed, null, FontStyle.Regular);
        Style ColorNameStyle = new TextStyle(Brushes.DarkRed, null, FontStyle.Regular);
        Style CommentStyle = new TextStyle(Brushes.ForestGreen, null, FontStyle.Regular);
        Style MinModeStyle = new TextStyle(Brushes.Purple, null, FontStyle.Regular);
        Style PosStyle1 = new TextStyle(Brushes.DodgerBlue, null, FontStyle.Regular);
        Style PosStyle2 = new TextStyle(Brushes.BlueViolet, null, FontStyle.Regular);
        Style EnabledStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(32, 0, 255, 0)));
        Style DisabledStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(32, 255, 0, 0)));

        String hoverControlsString()
        {
            string s = "";
            foreach (string S in hoverControls)
            {
                if (s != "")
                    s += ", ";
                s += S;
            }
            return s;
        }

        public MainMenuDesigner(string GameMenu, string MainMenuOverride)
        {
            InitializeComponent();

            tsLabel.Text = "";

            string[] lines = GameMenu.Split(new String[] { Environment.NewLine }, StringSplitOptions.None);
            int lvl = 0;
            int q = 0;

            for (int i = 0; i < lines.Length; ++i)
            {
                if (lines[i].Trim() == "{")
                {
                    lvl++;
                    if (lvl == 2)
                    {
                        Items.Add(lines[i - 1].TrimStart(' ', '\"').TrimEnd(' ', '\"'));
                        comboBox.Items.Add(lines[i - 1].TrimStart(' ', '\"').TrimEnd(' ', '\"'));
                        ++q;
                    }
                    continue;
                }
                if (lines[i].Trim() == "}")
                {
                    lvl--;
                    continue;
                }
                if (lines[i].Trim() == "")
                    continue;

                if (lvl == 2)
                {
                    String s = lines[i].TrimStart(' ', '\"').TrimEnd(' ', '\"');
                    string a = "";
                    string b = "";

                    int j = 0;
                    for (; j < s.Length; ++j)
                    {
                        if (s[j] != '\"')
                            a += s[j];
                        else
                        {
                            while (s[j] == '\"' || s[j] == ' ')
                            {
                                ++j;
                            }
                            break;
                        }
                    }
                    for (; j < s.Length; ++j)
                    {
                        b += s[j];
                    }

                    Items[q - 1].GameMenuParams.Add(new String2(a, b));
                }
            }


            /*for (int i = 0; i < Items.Count; ++i)
            {
                Console.WriteLine(Items[i].ID + "\r\n{");
                foreach (String2 s in Items[i].GameMenuParams)
                    Console.WriteLine("    [" + s.s1 + "] [" + s.s2 + "]");
                Console.WriteLine("}");
            }*/

            lines = MainMenuOverride.Split(new String[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; ++i)
            {
                if (lines[i].Trim() == "{")
                {
                    string tmpID = "";
                    string s = "";
                    if (Items.IDExists(lines[i - 1].Trim(' ', '\"')))
                    {
                        tmpID = lines[i - 1].Trim(' ', '\"');
                        ++i;
                        q = 1;
                        while (true)
                        {
                            if (lines[i].Trim() == "{")
                                q++;
                            if (lines[i].Trim() == "}")
                            {
                                q--;
                                if (q == 0)
                                    break;
                            }
                            s += lines[i] + "\r\n";
                            ++i;
                            if (i == lines.Length)
                                break;
                        }
                        Items[tmpID].MainMenuCode = s;
                    }
                }
            }

            string S = "";
            foreach (TFObject o in Items)
            {
                S += o.ID + "\r\n{\r\n" + o.MainMenuCode + "\r\n}\r\n";
            }
            System.IO.File.WriteAllText(@"C:\Users\Daniel\Desktop\Dump.txt", S);

            foreach (TFObject o in Items)
            {
                //Console.WriteLine("{2} [{0}, {1}]",o.XPos,o.YPos,o.ID);
                container.Controls.Add(new TFLabel(o.ID, o.XPos, o.YPos, o.Wide, o.Tall));
            }
        }

        private void container_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.MouseDown += new MouseEventHandler(Control_MouseDown);
            e.Control.MouseUp += new MouseEventHandler(Control_MouseUp);
            e.Control.MouseMove += new MouseEventHandler(Control_MouseMove);
            //e.Control.MouseEnter += new EventHandler(Control_MouseEnter);
            e.Control.MouseLeave += new EventHandler(Control_MouseLeave);
        }

        void Control_MouseMove(object sender, MouseEventArgs e)
        {
            //MOVE
            if (move1)
            {
                if (!move2)
                {
                    Point pos = controlToMove.PointToScreen(e.Location);
                    if (pos.X - 3 > startPosScreen.X || pos.X + 3 < startPosScreen.X || pos.Y - 3 > startPosScreen.Y || pos.Y + 3 < startPosScreen.Y)
                    {
                        move2 = true;
                    }
                }
                if (move2)
                {
                    if (snapToGrid)
                        controlToMove.Location = new Point((container.PointToClient(((Control)sender).PointToScreen(e.Location)).X - startPos.X) / gridSize * gridSize, (container.PointToClient(((Control)sender).PointToScreen(e.Location)).Y - startPos.Y) / gridSize * gridSize);
                    else
                        controlToMove.Location = new Point(container.PointToClient(((Control)sender).PointToScreen(e.Location)).X - startPos.X, container.PointToClient(((Control)sender).PointToScreen(e.Location)).Y - startPos.Y);
                    //SetEditorPos();
                    Cursor = Cursors.SizeAll;
                }
            }
            else if (resize)
            {
                Point toPos = controlToMove.Location;
                Size toSize = startSize;

                //if (ResizeDirections == ResizeDirection.Left)
                //{                                                                                                        // / gridSize * gridSize
                //    controlToMove.Location = new Point(container.PointToClient(((Control)sender).PointToScreen(e.Location)).X - startPos.X, controlToMove.Location.Y);
                //    controlToMove.Width = toSize.Width + startPos.X - e.Location.X;
                //    Application.DoEvents();
                //}
                //else if (ResizeDirections == ResizeDirection.Top)
                //{
                //    toPos.Y = container.PointToClient(((Control)sender).PointToScreen(e.Location)).Y - startPos.Y;
                //    toSize.Height = toSize.Height + startPos.Y - e.Location.Y;
                //}
                if (ResizeDirections == ResizeDirection.Right)
                {
                    controlToMove.Width = toSize.Width - startPos.X + e.Location.X;
                }
                else if (ResizeDirections == ResizeDirection.Bottom)
                {
                    controlToMove.Height = toSize.Height - startPos.Y + e.Location.Y;
                }
                else if (ResizeDirections == (ResizeDirection.Right | ResizeDirection.Bottom))
                {
                    controlToMove.Size = new Size(toSize.Width - startPos.X + e.Location.X, toSize.Height - startPos.Y + e.Location.Y);
                }
                controlToMove.Invalidate();
            }

            //HOVER OBJECTS
            Point p = container.PointToClient(Cursor.Position);
            hoverControls.Clear();
            foreach (Control c in container.Controls)
            {
                if (c.Location.X < p.X && c.Location.X + c.Size.Width > p.X && c.Location.Y < p.Y && c.Location.Y + c.Size.Height > p.Y)
                {
                    hoverControls.Add(c.Text);
                }
            }
            tsLabel.Text = hoverControlsString();

            //CONTAINER POSITION
            Point loc = container.PointToClient((sender as Control).PointToScreen(e.Location));
            if (snapToGrid)
                tsPosition.Text = " " + (loc.X / gridSize * gridSize).ToString().PadLeft(3) + ", " + (loc.Y / gridSize * gridSize).ToString().PadLeft(3);
            else
                tsPosition.Text = " " + loc.X.ToString().PadLeft(3) + ", " + loc.Y.ToString().PadLeft(3);
        }

        void selectID(string id)
        {
            comboBox.SelectedItem = id;
            editor.Text = Items[id].MainMenuCode;
            editor.ClearUndo();
        }

        void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TFLabel).DoResize)
                resize = true;
            else
                move1 = true;
            controlToMove = (Control)sender;
            controlToMove.BringToFront();
            if (comboBox.SelectedItem as String != controlToMove.Text)
            {
                selectID(controlToMove.Text);
            }
            startSize = (sender as Control).Size;
            startPos = e.Location;
            startPosScreen = controlToMove.PointToScreen(e.Location);
            ResizeDirections = (sender as TFLabel).ResizeDirections;
        }

        void Control_MouseUp(object sender, MouseEventArgs e)
        {
            move1 = false;
            move2 = false;
            resize = false;
            SetEditorPos();
        }

        void SetEditorPos()
        {
            string[] S = editor.Text.Split(new String[] { Environment.NewLine }, StringSplitOptions.None);
            int pos = 0;
            
            bool br = false;
            for (int i = 0; i < S.Length; ++i)
            {
                if (S[i].Contains("\"xpos\""))
                {
                    editor.Selection = new Range(editor, 0, i, S[i].Length, i);
                    S[i] = S[i].TrimEnd('\"', ' ').TrimEnd("-1234567890".ToCharArray()) + controlToMove.Location.X + "\"";
                    editor.SelectedText = S[i];
                    if (br) return;
                    br = true;
                }
                else if (S[i].Contains("\"ypos\""))
                {
                    editor.Selection = new Range(editor, 0, i, S[i].Length, i);
                    S[i] = S[i].TrimEnd('\"', ' ').TrimEnd("-1234567890".ToCharArray()) + controlToMove.Location.Y + "\"";
                    editor.SelectedText = S[i];
                    if (br) return;
                    br = true;
                }
                pos += S[i].Length + 1;
            }
        }

        void Control_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;

            Point p = container.PointToClient(Cursor.Position);
            hoverControls.Clear();
            foreach (Control c in container.Controls)
            {
                if (c.Location.X < p.X && c.Location.X + c.Size.Width > p.X && c.Location.Y < p.Y && c.Location.Y + c.Size.Height > p.Y)
                {
                    hoverControls.Add(c.Text);
                }
            }
            tsLabel.Text = hoverControlsString();
        }

        private void editor_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            highlight(e.ChangedRange);
        }

        public void highlight(Range r)
        {
            r.ClearStyle(CommentStyle, ColorStyle1, ColorStyle2, PosStyle1, PosStyle2, EnabledStyle, DisabledStyle, MinModeStyle);
            r.SetStyle(CommentStyle, @"//.*$", RegexOptions.Multiline);

            r.SetStyle(ColorStyle1, @"""?\d+\s+\d+\s+\d+(\s+\d+)?""?", RegexOptions.Singleline);
            r.SetStyle(ColorNameStyle, @"(?<range>""?[\w]+""?)\s+""?\d+\s+\d+\s+\d+(\s+\d+)?""?", RegexOptions.Singleline);

            r.SetStyle(MinModeStyle, @"\s*""\w+(?<range>_minmode)""", RegexOptions.Singleline);

            r.SetStyle(PosStyle1, @"(""xpos(_minmode)?""|""ypos(_minmode)?"")\s+""(l|r|c|t|b)?-?\d+""");
            r.SetStyle(PosStyle2, @"(""wide(_minmode)?""|""tall(_minmode)?"")\s+""(\d+|f0)""");
            r.SetStyle(PosStyle1, @"""zpos(_minmode)?""\s+""(-?\d+)""");

            r.SetStyle(EnabledStyle, @"(?<range>(""visible(_minmode)?""|""enabled(_minmode)?""))\s+""1""");
            r.SetStyle(DisabledStyle, @"(?<range>(""visible(_minmode)?""|""enabled(_minmode)?""))\s+""0""");
            r.SetStyle(EnabledStyle, @"(""visible(_minmode)?""|""enabled(_minmode)?"")\s+(?<range>""1"")");
            r.SetStyle(DisabledStyle, @"(""visible(_minmode)?""|""enabled(_minmode)?"")\s+(?<range>""0"")");

            r.ClearFoldingMarkers();
            r.SetFoldingMarkers("{", "}");
        }

        private void editor_VisibleRangeChangedDelayed(object sender, EventArgs e)
        {
            editor.VisibleRange.ClearStyle(NameStyle);
            editor.VisibleRange.SetStyle(NameStyle, @"(?<range>""?[\w|.|/]+""?)[\s|]*\{");
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectID(comboBox.SelectedItem as String);
            for (int i = 0; i < container.Controls.Count; ++i)
            {
                if (container.Controls[i].Text == comboBox.SelectedItem as String)
                    container.Controls[i].Focus();
            }
        }

        private void btnSnap_Click(object sender, EventArgs e)
        {
            snapToGrid = btnSnap.Checked;
        }

        private void tsBringToFront_Click(object sender, EventArgs e)
        {
            if (controlToMove != null)
                controlToMove.BringToFront();
        }

        private void tsSendToBack_Click(object sender, EventArgs e)
        {
            if (controlToMove != null)
                controlToMove.SendToBack();
        }

        private void container_MouseMove(object sender, MouseEventArgs e)
        {
            if (snapToGrid)
                tsPosition.Text = " " + (e.Location.X / gridSize * gridSize).ToString().PadLeft(3) + ", " + (e.Location.Y / gridSize * gridSize).ToString().PadLeft(3);
            else
                tsPosition.Text = " " + e.Location.X.ToString().PadLeft(3) + ", " + e.Location.Y.ToString().PadLeft(3);
        }

        string to3(string s)
        {
            while (s.Length < 3)
                s = " " + s;
            return s;
        }

        void Control_MouseEnter(object sender, EventArgs e)
        {
            //Point p = container.PointToClient(Cursor.Position);
            //hoverControls.Clear();
            //foreach (Control c in container.Controls)
            //{
            //    if (c.Location.X < p.X && c.Location.X + c.Size.Width > p.X && c.Location.Y < p.Y && c.Location.Y + c.Size.Height > p.Y)
            //    {
            //        hoverControls.Add(c.Text);
            //    }
            //}
            //tsLabel.Text = hoverControlsString();
        }

        private void tsGridSize_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem is ToolStripMenuItem)
            {
                gridSize = int.Parse(e.ClickedItem.Text);
                tsGridSize.Text = gridSize.ToString();
                container.Invalidate();
            }
        }

        private void container_Paint(object sender, PaintEventArgs e)
        {
            //List<Rectangle> recs = new List<Rectangle>();
            //for (int i = 0; i < 640; i += gridSize)
            //{
            //    for (int j = 0; j < 480; j += gridSize)
            //    {
            //        recs.Add(new Rectangle(i, j, 1, 1));
            //    }
            //}
            Bitmap bmap = new Bitmap(gridSize, gridSize);
            //bmap.SetPixel(gridSize - 1, gridSize - 1, Color.Gray);
            bmap.SetPixel(0, 0, Color.Gray);
            e.Graphics.FillRectangle(new TextureBrush(bmap as Image), 0, 0, 640, 480);
        }
    }
}
