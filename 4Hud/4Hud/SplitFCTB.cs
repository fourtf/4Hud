using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Forms;
using FastColoredTextBoxNS;


namespace _4Hud
{
    public partial class SplitFCTB : UserControl
    {
        String InfoKeywords = "name|creator|steamid|external_editor|version|url|update_url|version_url|desc";
        List<String> InfoKeywordList;

        public static Style NameStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        public static Style ColorStyle1 = new ColorStyle(Brushes.Black);
        //public static Style ColorStyle1 = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        public static Style ColorStyle2 = new TextStyle(Brushes.DarkRed, null, FontStyle.Regular);
        public static Style ColorNameStyle = new TextStyle(Brushes.DarkRed, null, FontStyle.Regular);
        public static Style CommentStyle = new TextStyle(Brushes.ForestGreen, null, FontStyle.Regular);
        public static Style MinModeStyle = new TextStyle(Brushes.Purple, null, FontStyle.Regular);
        public static Style PosStyle1 = new TextStyle(Brushes.DodgerBlue, null, FontStyle.Regular);
        public static Style PosStyle2 = new TextStyle(Brushes.SlateBlue, null, FontStyle.Regular);

        public static Style EnabledStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(32, 0, 255, 0)));
        public static Style DisabledStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(32, 255, 0, 0)));
        //public static Style UnderlinedStyle = new WavyLineStyle(255, Color.Red);

        public delegate void ValueChangedHandler(object sender, String Name, String Value);
        public event ValueChangedHandler ValueChanged;

        AutocompleteMenu autocompleteMenu1;
        AutocompleteMenu autocompleteMenu2;

        public string currentTab = "";
        public bool currentTabSaved = true;
        public TabMode TabMode = TabMode.none;
        bool handleEditorEvents = true;
        bool handleTabEvents = true;
        bool suppressHighlight = false;
        private bool firstEditorRMouse = true;

        public bool DragHere = false;
        public string CurrentPath = "";
        public string eText
        {
            get
            {
                return editor1.Text;
            }
        }
        void BeginEditorHandle()
        {
            handleEditorEvents = true;
        }
        void EndEditorHandle()
        {
            handleEditorEvents = false;
        }

        //GLOBAL VARIABLES

        [DefaultValue("WhiteSmoke")]
        public Color IndentColor
        {
            get
            {
                return editor1.IndentBackColor;
            }
            set
            {
                editor1.IndentBackColor = value;
                editor2.IndentBackColor = value;
            }
        }

        [DefaultValue("Teal")]
        public Color LineNumberColor
        {
            get
            {
                return editor1.LineNumberColor;
            }
            set
            {
                editor1.LineNumberColor = value;
                editor2.LineNumberColor = value;
            }
        }

        [DefaultValue("White")]
        public Color EditorBackColor
        {
            get
            {
                return editor1.BackColor;
            }
            set
            {
                editor1.BackColor = value;
                editor2.BackColor = value;
            }
        }

        private Color closeButtonBorder = SystemColors.Control;
        [DefaultValue("Control")]
        public Color CloseButtonBorder
        {
            get
            {
                return closeButtonBorder;
            }
            set
            {
                closeButtonBorder = value;
                btnClose.FlatAppearance.BorderColor = value;
            }
        }

        [DefaultValue("Black")]
        public Color CaretColor
        {
            get
            {
                return editor1.CaretColor;
            }
            set
            {
                editor1.CaretColor = value;
                editor2.CaretColor = value;
            }
        }

        //[DefaultValue("Black")]
        public Color SelectionColor
        {
            get
            {
                return editor1.SelectionColor;
            }
            set
            {
                editor1.SelectionColor = value;
                editor2.SelectionColor = value;
            }
        }

        [DefaultValue(true)]
        public bool ShowLineNumbers
        {
            get
            {
                return editor1.ShowLineNumbers;
            }
            set
            {
                editor1.ShowLineNumbers = value;
                editor2.ShowLineNumbers = value;
                menuShowLineNumbers.Checked = value;
            }
        }

        [DefaultValue(true)]
        public bool Split
        {
            get
            {
                return !split.Panel2Collapsed;
            }
            set
            {
                split.Panel2Collapsed = !value;
                menuSplitTextbox.Checked = value;
            }
        }

        [DefaultValue(400)]
        public int SplitDistance
        {
            get
            {
                return split.SplitterDistance;
            }
            set
            {
                split.SplitterDistance = value;
            }
        }

        //GLOBAL VARIABLES
        public List<TabContent> Tabs = new List<TabContent>();

        public TabContent getCurrentTabC()
        {
            foreach (TabContent t in Tabs)
            {
                if (t.Name == currentTab)
                    return t;
            }
            return null;
        }

        public List<String> GetOpenFiles()
        {
            List<String> l = new List<string>();
            foreach (TabContent t in Tabs)
                l.Add(t.Name + "?" + t.ImageIndex);
            return l;
        }

        public String GetSelectedTab()
        {
            if (tabControl.TabPages.Count != 0)
                return tabControl.SelectedTab.Text.Replace("*", "");
            return "";
        }

        public void RemoveAllTabs()
        {
            tabControl.TabPages.Clear();
            Tabs.Clear();
        }

        //CONSTRUCTER
        public SplitFCTB()
        {
            InitializeComponent();

            InfoKeywordList = new List<String>(InfoKeywords.Split('|'));
            InfoKeywordList.Sort();

            autocompleteMenu1 = new AutocompleteMenu(editor1);
            autocompleteMenu1.MinFragmentLength = 0;
            autocompleteMenu1.AppearInterval = 1;

            autocompleteMenu2 = new AutocompleteMenu(editor1);
            autocompleteMenu2.MinFragmentLength = 0;
            autocompleteMenu2.AppearInterval = 1;

            tabControl.Visible = false;
            tabControl.MouseClick += new MouseEventHandler(tabControl_MouseClick);

            editor1.ReadOnly = true;
            editor2.ReadOnly = true;
            editor1.AddStyle(MinModeStyle);
            editor1.UndoRedoStateChanged += new EventHandler<EventArgs>(editor1_UndoRedoStateChanged);

            editor1.VisibleRangeChangedDelayed += new EventHandler(editor1_VisibleRangeChanged);
            editor2.VisibleRangeChangedDelayed += new EventHandler(editor2_VisibleRangeChanged);

            editor1.SelectionChanged += new EventHandler(editor1_SelectionChanged);
            editor2.SelectionChanged += new EventHandler(editor2_SelectionChanged);

            currentTabSaved = true;
        }

        void tabControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                for (int i = 0; i < tabControl.TabCount; ++i)
                {
                    if (tabControl.GetTabRect(i).Contains(e.Location))
                    {
                        Console.WriteLine(tabControl.TabPages[i].Text.Replace("*", ""));
                        RemoveTab(tabControl.TabPages[i].Text.Replace("*", ""));
                        break;
                    }
                }
            }
        }

        void tabControl_HandleEditor(bool handle)
        {
            handleTabEvents = handle;
        }

        public void SetTheme()
        {
            //editor1.ClearStylesBuffer();
            //NameStyle = new TextStyle(new SolidBrush(Color.FromArgb(138, 198, 242)), null, FontStyle.Regular);
            //ColorStyle1 = new TextStyle(new SolidBrush(Color.FromArgb(255, 200, 110)), null, FontStyle.Regular);
            //ColorStyle2 = new TextStyle(new SolidBrush(Color.FromArgb(255, 200, 110)), null, FontStyle.Regular);
            //ColorNameStyle = new TextStyle(new SolidBrush(Color.FromArgb(255, 200, 110)), null, FontStyle.Regular);
            //CommentStyle = new TextStyle(new SolidBrush(Color.FromArgb(95, 130, 95)), null, FontStyle.Regular);
            //MinModeStyle = new TextStyle(Brushes.Purple, null, FontStyle.Regular);
            //PosStyle = new TextStyle(new SolidBrush(Color.FromArgb(202, 230, 130)), null, FontStyle.Regular);
            //EnabledStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(32, 128, 255, 128)));
            //DisabledStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(32, 128, 211, 128)));
        }

        public void ShowFindReplace()
        {
            editor1.ShowReplaceDialog();
        }

        void editor1_UndoRedoStateChanged(object sender, EventArgs e)
        {
            if (handleEditorEvents)
            {
                if (currentTabSaved && (editor1.TextSource.Manager.history.Count != 0 || editor1.TextSource.Manager.redoStack.Count != 0))
                {
                    currentTabSaved = false;
                    for (int i = 0; i < tabControl.TabPages.Count; ++i)
                    {
                        if (tabControl.TabPages[i].Text == currentTab)
                        {
                            tabControl.TabPages[i].Text += "*";
                        }
                    }
                }
            }
        }

        //----------------------------------------------
        public Boolean AllFilesSaved()
        {
            foreach (TabContent t in Tabs)
            {
                if (t.Saved == false)
                    return false;
            }
            return true;
        }

        public void DeleteAllAsterisks()
        {
            foreach (TabPage t in tabControl.TabPages)
            {
                t.Text = t.Text.Replace("*", "");
            }
        }

        public void DeleteAskterisk(string name)
        {
            foreach (TabPage t in tabControl.TabPages)
            {
                if (t.Text.Replace("*", "") == name)
                    t.Text = t.Text.Replace("*", "");
            }
        }

        public void AddTab(string text, string name, int ImageIndex)
        {
            Tabs.Add(new TabContent(text, name, ImageIndex));
            tabControl.TabPages.Add(name);

            editor1.ReadOnly = false;
            editor2.ReadOnly = false;

            if (tabControl.TabPages.Count == 1)
            {
                EndEditorHandle();
                TabMode = Tabs[0].TabMode;
                editor1.Text = text;
                editor1.ClearUndo();
                currentTab = name;
                currentTabSaved = true;
                tabControl.Visible = true;
                BeginEditorHandle();
                line2.Hide();
            }
        }

        public void RemoveTab(string name)
        {
            EndEditorHandle();
            for (int i = 0; i < Tabs.Count; ++i)
            {
                if (Tabs[i].Name == name)
                {
                    Tabs.RemoveAt(i);
                }
            }
            for (int i = 0; i < tabControl.TabPages.Count; ++i)
            {
                if (tabControl.TabPages[i].Text.Replace("*", "") == name)
                {
                    tabControl.TabPages.RemoveAt(i);
                }
            }
            if (Tabs.Count == 0)
            {
                tabControl.Visible = false;
                line2.Show();
            }
            BeginEditorHandle();
        }

        public void SelectTabText(string name)
        {
            EndEditorHandle();
            foreach (TabContent t in Tabs)
            {
                if (t.Name == currentTab)
                {
                    t.TabMode = TabMode;

                    t.Text = editor1.Text;
                    t.Saved = currentTabSaved;

                    t.XScroll1 = editor1.HorizontalScroll.Value;
                    t.YScroll1 = editor1.VerticalScroll.Value;
                    t.XScroll2 = editor2.HorizontalScroll.Value;
                    t.YScroll2 = editor2.VerticalScroll.Value;
                }
            }
            foreach (TabContent t in Tabs)
            {
                if (t.Name == name)
                {
                    TabMode = t.TabMode;
                    //suppressHighlight = true;
                    editor1.Text = t.Text;
                    //suppressHighlight = false;
                    currentTabSaved = t.Saved;

                    //Scroll position
                    if (t.XScroll1 < editor1.HorizontalScroll.Maximum + 1)
                        editor1.HorizontalScroll.Value = t.XScroll1;
                    else
                        editor1.HorizontalScroll.Value = editor1.HorizontalScroll.Maximum;

                    if (t.YScroll1 < editor1.VerticalScroll.Maximum + 1)
                        editor1.VerticalScroll.Value = t.YScroll1;
                    else
                        editor1.VerticalScroll.Value = editor1.VerticalScroll.Maximum;

                    if (t.XScroll2 < editor2.HorizontalScroll.Maximum + 1)
                        editor2.HorizontalScroll.Value = t.XScroll2;
                    else
                        editor2.HorizontalScroll.Value = editor2.HorizontalScroll.Maximum;

                    if (t.YScroll2 < editor2.VerticalScroll.Maximum + 1)
                        editor2.VerticalScroll.Value = t.YScroll2;
                    else
                        editor2.VerticalScroll.Value = editor2.VerticalScroll.Maximum;

                    editor1.UpdateScrollbars();
                    editor2.UpdateScrollbars();
                }
            }
            currentTab = name;
            BeginEditorHandle();
        }

        public void SelectTab(string name)
        {
            for (int i = 0; i < tabControl.TabPages.Count; ++i)
            {
                if (tabControl.TabPages[i].Text.Replace("*", "") == name)
                {
                    tabControl.SelectedIndex = i;
                }
            }
        }

        public void RenameTab(string name, string newname)
        {
            for (int i = 0; i < Tabs.Count; ++i)
            {
                if (Tabs[i].Name == name)
                {
                    Tabs[i].Name = newname;
                }
            }
            for (int i = 0; i < tabControl.TabPages.Count; ++i)
            {
                if (tabControl.TabPages[i].Text.Replace("*", "") == name)
                {
                    if (tabControl.TabPages[i].Text.EndsWith("*"))
                        tabControl.TabPages[i].Text = newname + "*";
                    else
                        tabControl.TabPages[i].Text = newname;
                }
            }
        }

        public bool TabExists(string name)
        {
            for (int i = 0; i < Tabs.Count; ++i)
            {
                if (Tabs[i].Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl.TabPages.Count == 0)
            {
                editor1.Text = "//\r\n// Select a file on the left\r\n//";
                editor1.ReadOnly = true;
                editor2.ReadOnly = true;
            }
            else
            {
                SelectTabText(e.TabPage.Text.Replace("*", ""));
            }
            editor1.ClearUndo();
        }


        //-----------------------------
        void editor1_VisibleRangeChanged(object sender, EventArgs e)
        {
            if (TabMode == _4Hud.TabMode.res)
            {
                Range r = new Range(editor1, 0, editor1.VisibleRange.Start.iLine, editor1.VisibleRange.End.iChar, editor1.VisibleRange.End.iLine);
                r.ClearStyle(NameStyle);
                r.SetStyle(NameStyle, @"(?<range>""?[\w|.|/]+""?)[\s|]*\{");
                highlight(r);
            }
        }

        void editor2_VisibleRangeChanged(object sender, EventArgs e)
        {
            if (TabMode == _4Hud.TabMode.res)
            {
                Range r = new Range(editor2, 0, editor2.VisibleRange.Start.iLine, editor1.VisibleRange.End.iChar, editor1.VisibleRange.End.iLine);
                r.ClearStyle(NameStyle);
                r.SetStyle(NameStyle, @"(?<range>""?[\w|.|/]+""?)[\s|]*\{");
                highlight(r);
            }
        }

        private void editor1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            if (!suppressHighlight)
            {
                highlight(e.ChangedRange);
                suppressHighlight = false;
            }

            if (handleEditorEvents)
            {
                if (currentTabSaved)
                {
                    currentTabSaved = false;
                    for (int i = 0; i < tabControl.TabPages.Count; ++i)
                    {
                        if (tabControl.TabPages[i].Text == currentTab)
                        {
                            tabControl.TabPages[i].Text += "*";
                        }
                    }
                }
            }
        }

        public void ClearStyles(Range r)
        {
            r.ClearStyle(ColorStyle1, ColorStyle2, ColorNameStyle, CommentStyle, MinModeStyle, PosStyle1, PosStyle2, EnabledStyle, DisabledStyle);
        }

        public void highlight(Range r)
        {
            ClearStyles(r);

            if (TabMode == _4Hud.TabMode.res)
            {
                r.SetStyle(CommentStyle, @"//.*$", RegexOptions.Multiline);

                r.SetStyle(ColorStyle1, @"""?\d+\s+\d+\s+\d+(\s+\d+)?""?");
                r.SetStyle(ColorNameStyle, @"(?<range>""?[\w]+""?)\s+""?\d+\s+\d+\s+\d+(\s+\d+)?""?");
                //r.SetStyle(ColorStyle2, @"\d+\s+\d+\s+\d+", RegexOptions.Singleline);
                //r.SetStyle(ColorNameStyle, @"(?<range>""?[\w]+""?)\d+\s+\d+\s+\d+", RegexOptions.Singleline);

                r.SetStyle(MinModeStyle, @"\s*""\w+(?<range>_minmode)""");

                r.SetStyle(PosStyle1, @"(""xpos(_minmode)?""|""ypos(_minmode)?"")\s+""(l|r|c|t|b)?-?\d+""");
                r.SetStyle(PosStyle2, @"(""wide(_minmode)?""|""tall(_minmode)?"")\s+""(\d+|f0)""");
                r.SetStyle(PosStyle1, @"""zpos(_minmode)?""\s+""(-?\d+)""");

                r.SetStyle(EnabledStyle, @"(?<range>(""visible(_minmode)?""|""enabled(_minmode)?""))\s+""1""");
                r.SetStyle(DisabledStyle, @"(?<range>(""visible(_minmode)?""|""enabled(_minmode)?""))\s+""0""");
                r.SetStyle(EnabledStyle, @"(""visible(_minmode)?""|""enabled(_minmode)?"")\s+(?<range>""1"")");
                r.SetStyle(DisabledStyle, @"(""visible(_minmode)?""|""enabled(_minmode)?"")\s+(?<range>""0"")");

                r.ClearFoldingMarkers();
                r.SetFoldingMarkers("{", "}");
                //r.SetFoldingMarkers(@"#region\b", @"#endregion\b");
            }
            else if (TabMode == _4Hud.TabMode.none)
            {
                r.SetStyle(CommentStyle, @"//.*$", RegexOptions.Multiline);
            }
            else if (TabMode == _4Hud.TabMode.info)
            {
                r.ClearStyle(NameStyle);

                r.SetStyle(CommentStyle, @"^//.*$", RegexOptions.Multiline);

                r.SetStyle(PosStyle1, "(?<range>^(" + InfoKeywords + "))(=|$)", RegexOptions.Multiline);
                r.SetStyle(PosStyle2, "(?<range>^[^\n=]+)(=|$)", RegexOptions.Multiline);

                //r.SetStyle(EnabledStyle, @"^url=(?<range>((http://teamfortress\.tv/|http://etf2l\.org/|http://steamcommunity\.com/groups/)).*)", RegexOptions.Multiline);
                //r.SetStyle(UnderlinedStyle, @"^url=(?<range>(?!http://).+)", RegexOptions.Multiline);
            }
        }
        void editor1_SelectionChanged(object sender, EventArgs e)
        {
            SelectionChanged(autocompleteMenu1, editor1);
        }

        void editor2_SelectionChanged(object sender, EventArgs e)
        {
            SelectionChanged(autocompleteMenu2, editor2);
        }

        void SelectionChanged(AutocompleteMenu menu, FastColoredTextBox editor)
        {
            if (TabMode == _4Hud.TabMode.info)
            {
                String s;
                if (editor.Lines[editor.Selection.Start.iLine].Length != editor.Selection.Start.iChar)
                    s = editor.Lines[editor.Selection.Start.iLine].Remove(editor.Selection.Start.iChar);
                else
                    s = editor.Lines[editor.Selection.Start.iLine];

                if (s.Contains("="))
                    menu.Items.SetAutocompleteItems(new String[0]);
                else
                    menu.Items.SetAutocompleteItems(InfoKeywordList);
            }
            else
            {
                menu.Items.SetAutocompleteItems(new String[0]);
            }
        }

        //------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (tabControl.TabPages.Count != 0)
            {
                RemoveTab(currentTab);
            }
        }

        private void menuSplitTextbox_Click(object sender, EventArgs e)
        {
            Split = !Split;
            if (ValueChanged != null)
                ValueChanged(this, "Split " + Name.Substring(Name.Length - 1), Split.ToString());
        }

        private void menuShowLineNumbers_Click(object sender, EventArgs e)
        {
            ShowLineNumbers = !ShowLineNumbers;
            if (ValueChanged != null)
                ValueChanged(this, "Line Numbers " + Name.Substring(Name.Length - 1), ShowLineNumbers.ToString());
        }

        private void editor1_MouseClick(object sender, MouseEventArgs e)
        {
            firstEditorRMouse = true;
            if (e.Button == MouseButtons.Right)
                MenuStrip.Show(Cursor.Position);
        }

        private void editor2_MouseClick(object sender, MouseEventArgs e)
        {
            firstEditorRMouse = false;
            if (e.Button == MouseButtons.Right)
                MenuStrip.Show(Cursor.Position);
        }

        private void split_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, "Splitter Distance " + Name.Substring(Name.Length - 1), split.SplitterDistance.ToString());
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.FlatAppearance.BorderColor = Color.Black;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.FlatAppearance.BorderColor = closeButtonBorder;
        }

        private void menuFind_Click(object sender, EventArgs e)
        {
            if (firstEditorRMouse)
                editor1.ShowFindDialog();
            else
                editor2.ShowFindDialog();
        }

        private void menuReplace_Click(object sender, EventArgs e)
        {
            if (firstEditorRMouse)
                editor1.ShowReplaceDialog();
            else
                editor2.ShowReplaceDialog();
        }
    }
}
