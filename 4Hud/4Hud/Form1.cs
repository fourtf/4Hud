using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using Thread = System.Threading.Thread;
using System.IO.Compression;
using System.Runtime.InteropServices;
using FastColoredTextBoxNS;


namespace _4Hud
{
    public partial class Form1 : Form
    {
        Int32 Version = 15;
        Settings settings = new Settings();
        Settings settings4Script = new Settings();
        String[] settingsToLoad =
        {
            "Border Style|0",
            "Save All On F5|True",
            "Launch Presets|embed x480, 4:3?640?480?False?True|embed x480, 5:4?600?480?False?True|" +
                "embed x480, 16:9?854?480?False?True|embed x480, 16:10?768?480?False?True",
            "Last Launch Preset|embed x480, 4:3",
            "Custom Launch Line|-console -novid -nopreload +developer",
            "TopMost|False"
        };
        SettingsDialog settingsDialog;
        String currentPath;
        List<String> maps = new List<String> { "_nomap" };
        List<LaunchPresent> launchPresents = new List<LaunchPresent>();
        TreeNode tmpNode;
        Color dark = Color.FromArgb(32, 32, 32);

        Boolean updateOnClose = false;
        String ForumLink = "";
        String secondServer = "";

        int tf2width = 640;
        int tf2height = 480;
        bool movetf = false;

        Timer timerRestartBtn;
        Timer timerTF2LaunchResize;
        Timer timerTF2CheckClosed;

        TFKey hotkeyReloadHud;

        BackgroundWorker mover = new BackgroundWorker();
        BackgroundWorker checker = new BackgroundWorker();
        BackgroundWorker updateChecker = new BackgroundWorker();
        Boolean domove = false;

        public Form1()
        {
            InitializeComponent();

            if (File.Exists("4Hud Theme.txt"))
                SetTheme(new Settings().AddLoadedFrom("4Hud Theme.txt"));

            hotkeyReloadHud = GetKeyByDisplayText("Numpad Add");

            mover.DoWork += new DoWorkEventHandler(mover_DoWork);
            mover.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mover_RunWorkerCompleted);

            checker.DoWork += new DoWorkEventHandler(checker_DoWork);
            checker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(checker_RunWorkerCompleted);

            //TIMERS
            timerTF2LaunchResize = new Timer();
            timerTF2LaunchResize.Interval = 100;
            timerTF2LaunchResize.Tick += new EventHandler(timerTF2LaunchResize_Tick);

            timerTF2CheckClosed = new Timer();
            timerTF2CheckClosed.Interval = 100;
            timerTF2CheckClosed.Tick += new EventHandler(timerTF2CheckClosed_Tick);

            //STEAM PATH
            if (!settings.Exists("Steam Path") || !File.Exists(settings.GetString("Steam Path")))
            {
                if (File.Exists(@"C:\Program Files (x86)\Steam\Steam.exe"))
                    settings.Set("Steam Path", @"C:\Program Files (x86)\Steam\Steam.exe");
                else if (File.Exists(@"C:\Program Files\Steam\Steam.exe"))
                    settings.Set("Steam Path", @"C:\Program Files\Steam\Steam.exe");
                else
                    ShowSteamPathDialog();
            }

            //Events
            treeView.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(treeView_NodeMouseDoubleClick);
            treeView.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView_NodeMouseClick);
            treeView.AfterLabelEdit += new NodeLabelEditEventHandler(treeView_AfterLabelEdit);
            treeView.AfterExpand += new TreeViewEventHandler(treeView_AfterExpand);
            treeViewSearch.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(treeView_NodeMouseDoubleClick);
            treeViewSearch.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView_NodeMouseClick);
            treeViewSearch.AfterLabelEdit += new NodeLabelEditEventHandler(treeView_AfterLabelEdit);
            treeViewSearch.AfterExpand += new TreeViewEventHandler(treeView_AfterExpand);
            //Settings
            settings.SettingChanged += new Settings.SettingChangedHandler(settings_SettingChanged);
            settings.Load(settingsToLoad);
            if (File.Exists("4Hud.Settings"))
                settings.LoadFrom("4Hud.Settings");

            //Maps and such
            if (File.Exists("4Script.Settings"))
            {
                log("settings exists");
                settings4Script.LoadFrom("4Script.Settings");
                if (settings4Script.Exists("Script Paths"))
                {
                    foreach (var S in settings4Script.GetStringArray("Script Paths"))
                    {
                        try
                        {
                            if (S.Split('?')[1] == "Team Fortress 2")
                            {

                                #region getmaps
                                string a = S.Split('?')[0];
                                if (Directory.Exists(a))
                                {
                                    maps = new List<string>();
                                    maps.Add("_nomap");

                                    try
                                    {
                                        if (Directory.Exists(a + @"..\maps"))
                                        {
                                            foreach (string s in Directory.GetFiles(a + @"..\maps"))
                                                if (s.EndsWith(".bsp"))
                                                    if (!maps.Contains(s.Substring(s.LastIndexOf("\\") + 1).Remove(s.Substring(s.LastIndexOf("\\") + 1).Length - 4)))
                                                    {
                                                        maps.Add(s.Substring(s.LastIndexOf("\\") + 1).Remove(s.Substring(s.LastIndexOf("\\") + 1).Length - 4));
                                                    }
                                        }
                                    }
                                    catch { }

                                    try
                                    {
                                        if (Directory.Exists(a + @"..\custom\maps"))
                                        {
                                            foreach (string s in Directory.GetFiles(a + @"..\custom\maps"))
                                                if (s.EndsWith(".bsp"))
                                                    if (!maps.Contains(s.Substring(s.LastIndexOf("\\") + 1).Remove(s.Substring(s.LastIndexOf("\\") + 1).Length - 4)))
                                                    {
                                                        maps.Add(s.Substring(s.LastIndexOf("\\") + 1).Remove(s.Substring(s.LastIndexOf("\\") + 1).Length - 4));
                                                    }
                                        }
                                    }
                                    catch { }

                                    try
                                    {
                                        if (Directory.Exists(a + @"..\download\maps"))
                                        {
                                            foreach (string s in Directory.GetFiles(a + @"..\download\maps"))
                                                if (s.EndsWith(".bsp"))
                                                    if (!maps.Contains(s.Substring(s.LastIndexOf("\\") + 1).Remove(s.Substring(s.LastIndexOf("\\") + 1).Length - 4)))
                                                    {
                                                        maps.Add(s.Substring(s.LastIndexOf("\\") + 1).Remove(s.Substring(s.LastIndexOf("\\") + 1).Length - 4));
                                                    }
                                        }
                                    }
                                    catch { }

                                }
                                #endregion
                            }
                        }
                        finally
                        {
                            tsMaps.Items.Clear();
                            foreach (string s in maps)
                                tsMaps.Items.Add(s);
                        }
                    }
                }
            }

            editor1.ValueChanged += new SplitFCTB.ValueChangedHandler(editor_ValueChanged);
            editor2.ValueChanged += new SplitFCTB.ValueChangedHandler(editor_ValueChanged);

            //Path
            try
            {
                if (!settings.Exists("Use Installed Hud") ||
                    (settings.GetBool("Use Installed Hud") && !Directory.Exists(settings.GetString("Custom Path"))) ||
                    (!settings.GetBool("Use Installed Hud") && (!settings.Exists("Hud Paths") || !Directory.Exists(settings.GetStringArray("Hud Paths")[0]))))
                {
                    showPathDialog(true);
                }
            }
            catch { showPathDialog(true); };

            setCustomPath();

            editor1.CurrentPath = currentPath;
            editor2.CurrentPath = currentPath;

            //Settings
            if (settings.Exists("Split 1")) editor1.Split = settings.GetBool("Split 1");
            if (settings.Exists("Split 2")) editor2.Split = settings.GetBool("Split 2");
            if (settings.Exists("Line Numbers 1")) editor1.ShowLineNumbers = settings.GetBool("Line Numbers 1");
            if (settings.Exists("Line Numbers 2")) editor2.ShowLineNumbers = settings.GetBool("Line Numbers 2");

            if (settings.Exists("Splitter Container Distance")) splitContainer.SplitterDistance = settings.GetInt("Splitter Container Distance");
            if (settings.Exists("Splitter Distance")) split.SplitterDistance = settings.GetInt("Splitter Distance");
            if (settings.Exists("Splitter Distance 1")) editor1.SplitDistance = settings.GetInt("Splitter Distance 1");
            if (settings.Exists("Splitter TF2 Distance")) splitContainer1.SplitterDistance = settings.GetInt("Splitter TF2 Distance");
            if (settings.Exists("Splitter Distance 2")) editor2.SplitDistance = settings.GetInt("Splitter Distance 2");
            if (settings.Exists("Maximized")) if (settings.GetBool("Maximized")) WindowState = FormWindowState.Maximized;


            tsLaunchPresets.Text = settings.GetString("Last Launch Preset");

            updateChecker.DoWork += new DoWorkEventHandler(updateChecker_DoWork);
            updateChecker.RunWorkerAsync();

            loadFiles();
        }

        public Form1(bool restart)
        {
            try
            {
                ZipStorer zip = ZipStorer.Open("_4Hud.zip", FileAccess.Read);

                List<ZipStorer.ZipFileEntry> dir = zip.ReadCentralDir();

                foreach (ZipStorer.ZipFileEntry entry in dir)
                {
                    if (entry.FilenameInZip.EndsWith("/"))
                    {
                        if (!Directory.Exists(Application.StartupPath + "\\" + entry.FilenameInZip))
                            Directory.CreateDirectory(Application.StartupPath + "\\" + entry.FilenameInZip);
                    }
                    else
                    {
                        zip.ExtractFile(entry, Application.StartupPath + "\\" + entry.FilenameInZip);
                    }
                }
                zip.Close();
            }
            catch { }

            if (restart)
            {
                try
                {
                    Process.Start(Application.StartupPath + "\\4Hud.exe");
                }
                catch { }
            }

            Environment.Exit(0);
        }

        void setCustomPath()
        {
            if (settings.GetBool("Use Installed Hud"))
            {
                bool hudFound = false;
                foreach (String f in Directory.GetDirectories(settings.GetString("Custom Path")))
                {
                    if (File.Exists(Path.Combine(f, "resource\\clientscheme.res")))
                    {
                        currentPath = f.TrimEnd('\\') + '\\';
                        hudFound = true;
                        break;
                    }
                }
                if (!hudFound)
                {
                    MessageBox.Show("No Hud was found in the custom folder!");
                    showPathDialog(true);
                    setCustomPath();
                }
            }
            else
            {
                if (Directory.Exists(settings.GetStringArray("Hud Paths")[0]))
                {
                    currentPath = settings.GetStringArray("Hud Paths")[0];
                }
                else
                {
                    MessageBox.Show("The hud folder was not found!");
                    showPathDialog(true);
                    setCustomPath();
                }
            }
        }

        void updateChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            WebClient client = new WebClient();
            string s = client.DownloadString(new Uri("http://yuhrney.square7.ch/TF2/4Hud.txt"));

            try
            {
                string[] S = s.Split('|');
                if (int.Parse(S[0]) != Version)
                {
                    if (s.Contains("|") && S[1] != "")
                    {
                        ForumLink = S[1];
                    }
                    Invoke(new MethodInvoker(delegate()
                        {
                            tsUpButton.Visible = true;
                            tsUpSplitter.Visible = true;
                        }
                    ));
                }

                if (S.Length > 4 && S[2] == "oldsys")
                {
                    Invoke(new MethodInvoker(delegate()
                        {
                            tsUpButton.Text = S[3];
                        }));
                    secondServer = S[4];
                }
            }
            catch { log("Aaaaaaaaaaaa"); }

        }

        void loadFiles()
        {
            ListDirectory(treeView, currentPath);
            try
            {
                treeView.Nodes[0].Expand();
            }
            catch { }

            if (settings.Exists("Open Files 1")) foreach (string s in settings.GetStringArray("Open Files 1")) { try { if (File.Exists(currentPath + s.Split('?')[0])) editor1.AddTab(File.ReadAllText(currentPath + s.Split('?')[0]), s.Split('?')[0], int.Parse(s.Split('?')[1])); } catch { } }
            if (settings.Exists("Open Files 2")) foreach (string s in settings.GetStringArray("Open Files 2")) { try { if (File.Exists(currentPath + s.Split('?')[0])) editor2.AddTab(File.ReadAllText(currentPath + s.Split('?')[0]), s.Split('?')[0], int.Parse(s.Split('?')[1])); } catch { } }
            else if (File.Exists(currentPath + "resource\\ClientScheme.res"))
                editor2.AddTab(File.ReadAllText(currentPath + "resource\\ClientScheme.res"), "resource\\ClientScheme.res", 2);
        }

        void reloadFiles()
        {
            if ((!editor1.AllFilesSaved() || !editor1.currentTabSaved) || (!editor2.AllFilesSaved() || !editor2.currentTabSaved))
            {
                switch (MessageBox.Show("Some files are unsaved. Save them?", "", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        SaveAll();
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }

            settings.Set("Open Files 1", editor1.GetOpenFiles().ToArray());
            settings.Set("Open Files 2", editor2.GetOpenFiles().ToArray());
            settings.Set("Selected File 1", editor1.GetSelectedTab());
            settings.Set("Selected File 2", editor2.GetSelectedTab());

            treeView.Nodes.Clear();
            editor1.RemoveAllTabs();
            editor2.RemoveAllTabs();

            loadFiles();
        }

        public void showPathDialog(bool exitOnCancel)
        {
            string path = "";
            try
            {
                path = settings.GetStringArray("Hud Paths")[0];
            }
            catch { }

            var dialog = new SelectHudPathForm(settings.GetBool("Use Installed Hud"), settings.GetString("Custom Path"),  path);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.UseCustomFolder)
                {
                    settings.Set("Use Installed Hud", true);
                    settings.Set("Custom Path", dialog.CustomPath);
                }
                else
                {
                    settings.Set("Use Installed Hud", false);
                    settings.Set("Hud Paths", dialog.HudPath);
                }
            }
            else
            {
                if (exitOnCancel)
                    Environment.Exit(0);
            }
        }

        public void SetTheme(Settings settings)
        {
            var w = Stopwatch.StartNew();
            if (settings.Exists("editor.ForeColor"))
            {
                editor1.ForeColor = editor2.ForeColor = settings.GetColor("editor.ForeColor");
                SplitFCTB.ColorStyle1 = new ColorStyle(settings.GetSolidBrush("editor.ForeColor"));
            }
            if (settings.Exists("editor.BackColor"))
            {
                editor1.EditorBackColor = editor2.EditorBackColor = settings.GetColor("editor.BackColor");
            }
            if (settings.Exists("editor.IndentBackColor"))
            {
                editor1.editor1.IndentBackColor = editor1.editor2.IndentBackColor =
                    editor2.editor1.IndentBackColor = editor2.editor2.IndentBackColor = settings.GetColor("editor.IndentBackColor");
            }
            if (settings.Exists("editor.LineNumberColor"))
            {
                editor1.LineNumberColor = editor2.LineNumberColor = settings.GetColor("editor.LineNumberColor");
            }
            if (settings.Exists("editor.SelectionColor"))
            {
                editor1.SelectionColor = editor2.SelectionColor = settings.GetColor("editor.SelectionColor");
            }
            if (settings.Exists("editor.CaretColor"))
            {
                editor1.CaretColor = editor2.CaretColor = settings.GetColor("editor.CaretColor");
            }
            if (settings.Exists("editor.Font"))
            {
                try
                {
                    editor1.editor1.Font = editor1.editor2.Font = editor2.editor1.Font = editor2.editor2.Font = new Font(settings.GetString("editor.Font"), editor1.editor1.Font.Size);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error in \"4Hud Theme.txt\"");
                }
            }

            if (settings.Exists("treeview.ForeColor"))
            {
                treeView.ForeColor = treeViewSearch.ForeColor = settings.GetColor("treeview.ForeColor");
            }
            if (settings.Exists("treeview.BackColor"))
            {
                treeView.BackColor = treeViewSearch.BackColor = settings.GetColor("treeview.BackColor");
            }

            if (settings.Exists("split.Bg"))
            {
                splitContainer.BackColor = editor1.btnClose.FlatAppearance.BorderColor = editor1.btnClose.FlatAppearance.CheckedBackColor = editor1.btnClose.BackColor = editor1.btnClose.FlatAppearance.MouseDownBackColor = editor1.btnClose.FlatAppearance.MouseOverBackColor = editor1.CloseButtonBorder =
                    split.BackColor = editor2.btnClose.FlatAppearance.BorderColor = editor2.btnClose.FlatAppearance.CheckedBackColor = editor2.btnClose.BackColor = editor2.btnClose.FlatAppearance.MouseDownBackColor = editor2.btnClose.FlatAppearance.MouseOverBackColor = editor2.CloseButtonBorder =
                    editor1.BackColor = editor2.BackColor = splitContainer.Panel1.BackColor =
                    settings.GetColor("split.Bg");
                
            }


            if (settings.Exists("color.ColorName"))
                SplitFCTB.ColorNameStyle = new TextStyle(settings.GetSolidBrush("color.ColorName"), null, FontStyle.Regular);

            if (settings.Exists("color.Comment"))
                SplitFCTB.CommentStyle = new TextStyle(settings.GetSolidBrush("color.Comment"), null, FontStyle.Regular);

            if (settings.Exists("color.Enabled"))
                SplitFCTB.EnabledStyle = new MarkerStyle(settings.GetSolidBrush("color.Enabled"));

            if (settings.Exists("color.Disabled"))
                SplitFCTB.DisabledStyle = new MarkerStyle(settings.GetSolidBrush("color.Disabled"));

            if (settings.Exists("color.Minmode"))
                SplitFCTB.MinModeStyle = new TextStyle(settings.GetSolidBrush("color.Minmode"), null, FontStyle.Regular);

            if (settings.Exists("color.Keywords"))
                SplitFCTB.NameStyle = new TextStyle(settings.GetSolidBrush("color.Keywords"), null, FontStyle.Regular);

            if (settings.Exists("color.Pos1"))
                SplitFCTB.PosStyle1 = new TextStyle(settings.GetSolidBrush("color.Pos1"), null, FontStyle.Regular);

            if (settings.Exists("color.Pos2"))
                SplitFCTB.PosStyle2 = new TextStyle(settings.GetSolidBrush("color.Pos2"), null, FontStyle.Regular);

           //if (settings.Exists("color.Pos2"))
           //    SplitFCTB.UnderlinedStyle = new TextStyle(settings.GetSolidBrush("color.Pos2"), null, FontStyle.Regular);


            w.Stop();
            Console.WriteLine(w.Elapsed.TotalMilliseconds);
        }

        void SettingChanged(string name, string value)
        {
            settings.Set(name, value);
        }

        void settings_SettingChanged(object sender, SettingsChangedEventArgs e)
        {
            switch (e.ChangedName)
            {
                case "Window Size":
                    try
                    {
                        Size = new Size(int.Parse(settings.GetStringArray("Window Size")[0]), int.Parse(settings.GetStringArray("Window Size")[1]));
                    }
                    catch
                    {
                        Size = new Size(800, 600);
                    }
                    break;
                case "Screen Position":
                    try
                    {
                        StartPosition = FormStartPosition.Manual;
                        Location = new Point(int.Parse(settings.GetStringArray("Screen Position")[0]), int.Parse(settings.GetStringArray("Screen Position")[1]));
                    }
                    catch { }
                    break;
                case "Border Style":
                    if (settings.GetInt("Border Style") == 0)
                        split.BorderStyle = BorderStyle.None;
                    else if (settings.GetInt("Border Style") == 1)
                        split.BorderStyle = BorderStyle.FixedSingle;
                    else
                        split.BorderStyle = BorderStyle.Fixed3D;
                    break;
                case "Developer":
                    tsSettingsEditor.Visible = settings.GetBool("Developer");
                    break;
                case "TF2 Reload Scheme Key":
                    hotkeyReloadHud = GetKeyByTF2KeyName(settings.GetString("TF2 Reload Scheme Key"));
                    break;
                case "Launch Presets":
                    tsLaunchPresets.Items.Clear();
                    List<string> l = settings.GetStringArray("Launch Presets");
                    foreach (string s in l)
                    {
                        try
                        {
                            string[] S = s.Split('?');
                            launchPresents.Add(new LaunchPresent(S[0], int.Parse(S[1]), int.Parse(S[2]), bool.Parse(S[3]), bool.Parse(S[4])));
                            tsLaunchPresets.Items.Add(S[0]);
                        }
                        catch { }
                    }
                    break;
                case "TopMost":
                    tsTopMost.Checked = settings.GetBool("TopMost");
                    this.TopMost = settings.GetBool("TopMost");
                    break;
            }
        }



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            splitContainer1.Panel2Collapsed = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if ((!editor1.AllFilesSaved() || !editor1.currentTabSaved) || (!editor2.AllFilesSaved() || !editor2.currentTabSaved))
            {
                switch (MessageBox.Show("Some files are unsaved. Save them?", "", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        SaveAll();
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
            //openfiles
            settings.Set("Open Files 1", editor1.GetOpenFiles().ToArray());
            settings.Set("Open Files 2", editor2.GetOpenFiles().ToArray());
            settings.Set("Selected File 1", editor1.GetSelectedTab());
            settings.Set("Selected File 2", editor2.GetSelectedTab());

            //maximized
            if (WindowState == FormWindowState.Maximized)
                settings.Set("Maximized", true);
            else
                settings.Set("Maximized", false);
            //save
            settings.SaveTo("4Hud.Settings");

            if (updateOnClose)
            {
                try
                {
                    Process.Start("_4Hud.exe", "-update -restart");
                    //Process.Start(ForumLink);
                }
                catch { }
            }

            base.OnClosing(e);
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            if (WindowState != FormWindowState.Maximized)
                settings.Set("Window Size", new String[] { Size.Width.ToString(), Size.Height.ToString() });

            if (movetf)
            {
                var Prc = Process.GetProcessesByName("hl2");
                if (Prc.Length != 0)
                {
                    if (mover.IsBusy)
                        domove = true;
                    else
                        mover.RunWorkerAsync();
                }
            }
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            if (WindowState != FormWindowState.Maximized)
                settings.Set("Screen Position", new String[] { Location.X.ToString(), Location.Y.ToString() });

            if (movetf)
            {
                var Prc = Process.GetProcessesByName("hl2");
                if (Prc.Length != 0)
                {
                    if (mover.IsBusy)
                        domove = true;
                    else
                        mover.RunWorkerAsync();
                }
            }
        }

        //SHOW
        public void ShowSteamPathDialog()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select Steam.exe (needed for launching tf2 with special settings)";
            if (dialog.ShowDialog() == DialogResult.OK)
                settings.Set("Steam Path", dialog.FileName);
        }

        public void showSettingsEditor()
        {
            settings.SaveTo("4Hud.Settings");
            SettingsEditor settingsEditor = new SettingsEditor();
            if (settingsEditor.ShowDialog() == DialogResult.OK)
            {
                settings.Clear();
                settings.Load(settingsToLoad);
                settings.Load(settingsEditor.getData());
            }
            else if (settingsEditor.DialogResult == DialogResult.Retry)
            {
                if (MessageBox.Show("Reset the 4Hud config?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    settings.Clear();
                    settings.Load(settingsToLoad);
                }
            }
        }

        //EVENTS
        private void tsMenu_ButtonClick(object sender, EventArgs e)
        {
            tsMenu.ShowDropDown();
        }

        private void tsSettingsEditor_Click(object sender, EventArgs e)
        {
            showSettingsEditor();
        }

        private void split_SplitterMoved(object sender, SplitterEventArgs e)
        {
            settings.Set("Splitter Distance", split.SplitterDistance);
        }

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            settings.Set("Splitter Container Distance", splitContainer.SplitterDistance);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            settings.Set("Splitter TF2 Distance", splitContainer1.SplitterDistance);
        }

        private void tsChangeHudPath_Click(object sender, EventArgs e)
        {
            showPathDialog(false);
            setCustomPath();
        }

        //UPDATE
        void timerRestartBtn_Tick(object sender, EventArgs e)
        {
            tsUpRestart.Visible = false;
            timerRestartBtn.Stop();
        }

        private void tsUpButton_Click(object sender, EventArgs e)
        {
            tsUpButton.Visible = false;
            WebClient client = new WebClient();
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.DownloadFileAsync(new Uri("http://yuhrney.square7.ch/TF2/4Hud.zip"), Application.StartupPath + "\\_4Hud.zip");
            File.Copy(Application.ExecutablePath, Application.StartupPath + "\\_4Hud.exe", true);
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            tsUpRestart.Visible = true;
            updateOnClose = true;
        }

        private void tsUpRestart_Click(object sender, EventArgs e)
        {
            if (timerRestartBtn != null)
                timerRestartBtn.Stop();
            tsUpRestart.Visible = false;
            Close();
        }

        private void tsUpRestart_VisibleChanged(object sender, EventArgs e)
        {
            if (timerRestartBtn == null)
            {
                timerRestartBtn = new Timer();
                timerRestartBtn.Tick += new EventHandler(timerRestartBtn_Tick);
                timerRestartBtn.Interval = 20000;
                timerRestartBtn.Start();
            }
        }

        private void tsSortFile_Click(object sender, EventArgs e)
        {

        }

        private void selectSteamexePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSteamPathDialog();
        }

        private void tsSettings_Click(object sender, EventArgs e)
        {
            showSettings();
        }

        private void tsLaunchTF2_Click(object sender, EventArgs e)
        {
            foreach (LaunchPresent p in launchPresents)
            {
                if (p.Alias == tsLaunchPresets.Text)
                    launchTF2(p.Width, p.Height, p.Full, p.Hook);
            }
        }

        private void tsLaunchSettings_Click(object sender, EventArgs e)
        {
            showSettings(1);
        }

        private void tsLaunchPresets_TextUpdate(object sender, EventArgs e)
        {
            settings.Set("Last Launch Preset", tsLaunchPresets.Text);
        }

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            reloadFiles();
        }

        private void cmRename_Click(object sender, EventArgs e)
        {
            tmpNode.BeginEdit();
        }

        private void tsSaveAll_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        private void cmDelete_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(currentPath + tmpNode.FullPath.Substring(tmpNode.FullPath.IndexOf('\\') + 1));
                tmpNode.Remove();
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (settings.Exists("Selected File 1")) editor1.SelectTab(settings.GetString("Selected File 1"));
            if (settings.Exists("Selected File 2")) editor2.SelectTab(settings.GetString("Selected File 2"));
        }

        private void tsMenuDesigner_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(currentPath + "resource\\");
            string fileA = null;
            string fileB = null;

            foreach (string s in files)
            {
                if (s.ToLower().EndsWith("\\gamemenu.res"))
                    fileA = s;
            }

            if (Directory.Exists(currentPath + "resource\\ui"))
            {
                files = Directory.GetFiles(currentPath + "resource\\ui");
                foreach (string s in files)
                    if (s.ToLower().EndsWith("\\mainmenuoverride.res"))
                        fileB = s;
            }

            if (fileA != null && fileB != null)
            {
                new MainMenuDesigner(File.ReadAllText(fileA), File.ReadAllText(fileB)).Show();
            }
        }

        private void tsEditInfo_Click(object sender, EventArgs e)
        {
            if (File.Exists(currentPath + "data.txt"))
            {
                if (editor1.TabExists("data.txt"))
                    editor1.SelectTab("data.txt");
                else if (editor2.TabExists("data.txt"))
                    editor2.SelectTab("data.txt");
                else
                {
                    editor1.AddTab(File.ReadAllText(currentPath + "data.txt"), "data.txt", 8);
                }
            }
            else
            {
                File.WriteAllText(currentPath + "data.txt", "name=" + currentPath.TrimEnd('\\').Substring(currentPath.TrimEnd('\\').LastIndexOf('\\') + 1));
                treeView.Nodes[0].Nodes.Add(new TreeNode("data.txt", 8, 8));
                editor1.AddTab("name=" + currentPath.TrimEnd('\\').Substring(currentPath.TrimEnd('\\').LastIndexOf('\\') + 1), "data.txt", 8);
            }
        }

        private void tsTopMost_Click(object sender, EventArgs e)
        {
            settings.Set("TopMost", tsTopMost.Checked);
        }
    }
}
