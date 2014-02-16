namespace _4Hud
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ts = new System.Windows.Forms.ToolStrip();
            this.tsMenu = new System.Windows.Forms.ToolStripSplitButton();
            this.tsChangeHudPath = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSteamPath = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuDesigner = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSettingsEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSortFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsUpSplitter = new System.Windows.Forms.ToolStripSeparator();
            this.tsSaveAll = new System.Windows.Forms.ToolStripButton();
            this.tsRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLaunchPresets = new System.Windows.Forms.ToolStripComboBox();
            this.tsLaunchSettings = new System.Windows.Forms.ToolStripButton();
            this.tsMaps = new System.Windows.Forms.ToolStripComboBox();
            this.tsLaunchTF2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsUpRestart = new System.Windows.Forms.ToolStripButton();
            this.tsUpButton = new System.Windows.Forms.ToolStripButton();
            this.split = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.treeviewFindBtn = new System.Windows.Forms.Button();
            this.treeviewFindTxt = new System.Windows.Forms.TextBox();
            this.treeViewContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmOpenLeftEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.cmOpenRightEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmOpenDefaultTool = new System.Windows.Forms.ToolStripMenuItem();
            this.cmOpenEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.cmOpenExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cmRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewSearch = new System.Windows.Forms.TreeView();
            this.treeView = new System.Windows.Forms.TreeView();
            this.editor1 = new _4Hud.SplitFCTB();
            this.editor2 = new _4Hud.SplitFCTB();
            this.transpanel = new _4Hud.Transpanel();
            this.ts.SuspendLayout();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.treeViewContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // ts
            // 
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenu,
            this.tsUpSplitter,
            this.tsSaveAll,
            this.tsRefresh,
            this.toolStripSeparator4,
            this.tsLaunchPresets,
            this.tsLaunchSettings,
            this.tsMaps,
            this.tsLaunchTF2,
            this.toolStripSeparator3,
            this.tsUpRestart,
            this.tsUpButton});
            this.ts.Location = new System.Drawing.Point(0, 0);
            this.ts.Name = "ts";
            this.ts.Size = new System.Drawing.Size(784, 25);
            this.ts.TabIndex = 0;
            // 
            // tsMenu
            // 
            this.tsMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsChangeHudPath,
            this.tsSteamPath,
            this.tsTopMost,
            this.tsMenuDesigner,
            this.tsSettings,
            this.tsSettingsEditor,
            this.tsSortFile});
            this.tsMenu.Image = global::_4Hud.Properties.Resources.menu;
            this.tsMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(32, 22);
            this.tsMenu.Text = "Menu";
            this.tsMenu.ButtonClick += new System.EventHandler(this.tsMenu_ButtonClick);
            // 
            // tsChangeHudPath
            // 
            this.tsChangeHudPath.Name = "tsChangeHudPath";
            this.tsChangeHudPath.Size = new System.Drawing.Size(285, 22);
            this.tsChangeHudPath.Text = "Change Hud Path";
            this.tsChangeHudPath.Click += new System.EventHandler(this.tsChangeHudPath_Click);
            // 
            // tsSteamPath
            // 
            this.tsSteamPath.Name = "tsSteamPath";
            this.tsSteamPath.Size = new System.Drawing.Size(285, 22);
            this.tsSteamPath.Text = "Select Steam.exe Path";
            this.tsSteamPath.Click += new System.EventHandler(this.selectSteamexePathToolStripMenuItem_Click);
            // 
            // tsTopMost
            // 
            this.tsTopMost.CheckOnClick = true;
            this.tsTopMost.Name = "tsTopMost";
            this.tsTopMost.Size = new System.Drawing.Size(285, 22);
            this.tsTopMost.Text = "Make 4Hud Topmost";
            this.tsTopMost.Click += new System.EventHandler(this.tsTopMost_Click);
            // 
            // tsMenuDesigner
            // 
            this.tsMenuDesigner.Name = "tsMenuDesigner";
            this.tsMenuDesigner.Size = new System.Drawing.Size(285, 22);
            this.tsMenuDesigner.Text = "Main Menu Viewer (pointless right now)";
            this.tsMenuDesigner.Visible = false;
            this.tsMenuDesigner.Click += new System.EventHandler(this.tsMenuDesigner_Click);
            // 
            // tsSettings
            // 
            this.tsSettings.Name = "tsSettings";
            this.tsSettings.Size = new System.Drawing.Size(285, 22);
            this.tsSettings.Text = "Settings";
            this.tsSettings.Click += new System.EventHandler(this.tsSettings_Click);
            // 
            // tsSettingsEditor
            // 
            this.tsSettingsEditor.Name = "tsSettingsEditor";
            this.tsSettingsEditor.Size = new System.Drawing.Size(285, 22);
            this.tsSettingsEditor.Text = "Settingseditor";
            this.tsSettingsEditor.Visible = false;
            this.tsSettingsEditor.Click += new System.EventHandler(this.tsSettingsEditor_Click);
            // 
            // tsSortFile
            // 
            this.tsSortFile.Name = "tsSortFile";
            this.tsSortFile.Size = new System.Drawing.Size(285, 22);
            this.tsSortFile.Text = "Sort File (doesn\'t work)";
            this.tsSortFile.Visible = false;
            this.tsSortFile.Click += new System.EventHandler(this.tsSortFile_Click);
            // 
            // tsUpSplitter
            // 
            this.tsUpSplitter.Name = "tsUpSplitter";
            this.tsUpSplitter.Size = new System.Drawing.Size(6, 25);
            // 
            // tsSaveAll
            // 
            this.tsSaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSaveAll.Image = global::_4Hud.Properties.Resources.saveAll;
            this.tsSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSaveAll.Name = "tsSaveAll";
            this.tsSaveAll.Size = new System.Drawing.Size(23, 22);
            this.tsSaveAll.Text = "Save All (Ctrl+S)";
            this.tsSaveAll.Click += new System.EventHandler(this.tsSaveAll_Click);
            // 
            // tsRefresh
            // 
            this.tsRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRefresh.Image = global::_4Hud.Properties.Resources.refresh;
            this.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRefresh.Name = "tsRefresh";
            this.tsRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsRefresh.Text = "Reload Files";
            this.tsRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsLaunchPresets
            // 
            this.tsLaunchPresets.Name = "tsLaunchPresets";
            this.tsLaunchPresets.Size = new System.Drawing.Size(121, 25);
            this.tsLaunchPresets.ToolTipText = "Launch Preset";
            this.tsLaunchPresets.TextUpdate += new System.EventHandler(this.tsLaunchPresets_TextUpdate);
            // 
            // tsLaunchSettings
            // 
            this.tsLaunchSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsLaunchSettings.Image = global::_4Hud.Properties.Resources.RunSetting;
            this.tsLaunchSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLaunchSettings.Name = "tsLaunchSettings";
            this.tsLaunchSettings.Size = new System.Drawing.Size(23, 22);
            this.tsLaunchSettings.Text = "Configure Launch Presets";
            this.tsLaunchSettings.Click += new System.EventHandler(this.tsLaunchSettings_Click);
            // 
            // tsMaps
            // 
            this.tsMaps.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tsMaps.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tsMaps.Items.AddRange(new object[] {
            "_no map"});
            this.tsMaps.Name = "tsMaps";
            this.tsMaps.Size = new System.Drawing.Size(150, 25);
            this.tsMaps.Text = "_nomap";
            this.tsMaps.ToolTipText = "Map";
            // 
            // tsLaunchTF2
            // 
            this.tsLaunchTF2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsLaunchTF2.Image = global::_4Hud.Properties.Resources.start;
            this.tsLaunchTF2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLaunchTF2.Name = "tsLaunchTF2";
            this.tsLaunchTF2.Size = new System.Drawing.Size(23, 22);
            this.tsLaunchTF2.Text = "Launch TF2";
            this.tsLaunchTF2.Click += new System.EventHandler(this.tsLaunchTF2_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsUpRestart
            // 
            this.tsUpRestart.Checked = true;
            this.tsUpRestart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsUpRestart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsUpRestart.Image = ((System.Drawing.Image)(resources.GetObject("tsUpRestart.Image")));
            this.tsUpRestart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUpRestart.Name = "tsUpRestart";
            this.tsUpRestart.Size = new System.Drawing.Size(86, 22);
            this.tsUpRestart.Text = "Restart 4Script";
            this.tsUpRestart.Visible = false;
            this.tsUpRestart.Click += new System.EventHandler(this.tsUpRestart_Click);
            this.tsUpRestart.VisibleChanged += new System.EventHandler(this.tsUpRestart_VisibleChanged);
            // 
            // tsUpButton
            // 
            this.tsUpButton.Checked = true;
            this.tsUpButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsUpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsUpButton.Image = ((System.Drawing.Image)(resources.GetObject("tsUpButton.Image")));
            this.tsUpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUpButton.Name = "tsUpButton";
            this.tsUpButton.Size = new System.Drawing.Size(52, 22);
            this.tsUpButton.Text = "Update!";
            this.tsUpButton.Visible = false;
            this.tsUpButton.Click += new System.EventHandler(this.tsUpButton_Click);
            // 
            // split
            // 
            this.split.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 0);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.editor1);
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.splitContainer1);
            this.split.Size = new System.Drawing.Size(606, 537);
            this.split.SplitterDistance = 331;
            this.split.TabIndex = 2;
            this.split.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.split_SplitterMoved);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.editor2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.transpanel);
            this.splitContainer1.Size = new System.Drawing.Size(271, 534);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 25);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel1.Controls.Add(this.treeViewSearch);
            this.splitContainer.Panel1.Controls.Add(this.treeviewFindBtn);
            this.splitContainer.Panel1.Controls.Add(this.treeviewFindTxt);
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.split);
            this.splitContainer.Size = new System.Drawing.Size(784, 537);
            this.splitContainer.SplitterDistance = 174;
            this.splitContainer.TabIndex = 3;
            this.splitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder2.png");
            this.imageList.Images.SetKeyName(1, "zip16.png");
            this.imageList.Images.SetKeyName(2, "component.png");
            this.imageList.Images.SetKeyName(3, "fontfile2.png");
            this.imageList.Images.SetKeyName(4, "image.png");
            this.imageList.Images.SetKeyName(5, "textfile1.png");
            this.imageList.Images.SetKeyName(6, "app.png");
            this.imageList.Images.SetKeyName(7, "document.png");
            this.imageList.Images.SetKeyName(8, "note.png");
            // 
            // treeviewFindBtn
            // 
            this.treeviewFindBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeviewFindBtn.Image = global::_4Hud.Properties.Resources.find;
            this.treeviewFindBtn.Location = new System.Drawing.Point(147, 1);
            this.treeviewFindBtn.Name = "treeviewFindBtn";
            this.treeviewFindBtn.Size = new System.Drawing.Size(24, 23);
            this.treeviewFindBtn.TabIndex = 2;
            this.treeviewFindBtn.UseVisualStyleBackColor = true;
            this.treeviewFindBtn.Click += new System.EventHandler(this.treeviewFindBtn_Click);
            // 
            // treeviewFindTxt
            // 
            this.treeviewFindTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeviewFindTxt.Location = new System.Drawing.Point(3, 3);
            this.treeviewFindTxt.Name = "treeviewFindTxt";
            this.treeviewFindTxt.Size = new System.Drawing.Size(143, 20);
            this.treeviewFindTxt.TabIndex = 1;
            this.treeviewFindTxt.TextChanged += new System.EventHandler(this.treeviewFindTxt_TextChanged);
            // 
            // treeViewContext
            // 
            this.treeViewContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmOpenLeftEditor,
            this.cmOpenRightEditor,
            this.toolStripSeparator1,
            this.cmOpenDefaultTool,
            this.cmOpenEditor,
            this.cmOpenExplorer,
            this.toolStripSeparator5,
            this.cmRename,
            this.cmDelete});
            this.treeViewContext.Name = "treeViewContext";
            this.treeViewContext.Size = new System.Drawing.Size(219, 170);
            // 
            // cmOpenLeftEditor
            // 
            this.cmOpenLeftEditor.Name = "cmOpenLeftEditor";
            this.cmOpenLeftEditor.Size = new System.Drawing.Size(218, 22);
            this.cmOpenLeftEditor.Text = "Open in Left Editor";
            this.cmOpenLeftEditor.Click += new System.EventHandler(this.cmOpenLeftEditor_Click);
            // 
            // cmOpenRightEditor
            // 
            this.cmOpenRightEditor.Name = "cmOpenRightEditor";
            this.cmOpenRightEditor.Size = new System.Drawing.Size(218, 22);
            this.cmOpenRightEditor.Text = "Open in Right Editor";
            this.cmOpenRightEditor.Click += new System.EventHandler(this.cmOpenRightEditor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // cmOpenDefaultTool
            // 
            this.cmOpenDefaultTool.Name = "cmOpenDefaultTool";
            this.cmOpenDefaultTool.Size = new System.Drawing.Size(218, 22);
            this.cmOpenDefaultTool.Text = "Open with default Program";
            this.cmOpenDefaultTool.Click += new System.EventHandler(this.cmOpenDefaultTool_Click);
            // 
            // cmOpenEditor
            // 
            this.cmOpenEditor.Name = "cmOpenEditor";
            this.cmOpenEditor.Size = new System.Drawing.Size(218, 22);
            this.cmOpenEditor.Text = "Open with Editor";
            this.cmOpenEditor.Click += new System.EventHandler(this.cmOpenEditor_Click);
            // 
            // cmOpenExplorer
            // 
            this.cmOpenExplorer.Name = "cmOpenExplorer";
            this.cmOpenExplorer.Size = new System.Drawing.Size(218, 22);
            this.cmOpenExplorer.Text = "Open in Explorer";
            this.cmOpenExplorer.Click += new System.EventHandler(this.cmOpenExplorer_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(215, 6);
            // 
            // cmRename
            // 
            this.cmRename.Name = "cmRename";
            this.cmRename.Size = new System.Drawing.Size(218, 22);
            this.cmRename.Text = "Rename";
            this.cmRename.Click += new System.EventHandler(this.cmRename_Click);
            // 
            // cmDelete
            // 
            this.cmDelete.Name = "cmDelete";
            this.cmDelete.Size = new System.Drawing.Size(218, 22);
            this.cmDelete.Text = "Delete";
            this.cmDelete.Click += new System.EventHandler(this.cmDelete_Click);
            // 
            // treeViewSearch
            // 
            this.treeViewSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewSearch.BackColor = System.Drawing.SystemColors.Control;
            this.treeViewSearch.ImageIndex = 0;
            this.treeViewSearch.ImageList = this.imageList;
            this.treeViewSearch.LabelEdit = true;
            this.treeViewSearch.Location = new System.Drawing.Point(0, 29);
            this.treeViewSearch.Name = "treeViewSearch";
            this.treeViewSearch.SelectedImageIndex = 0;
            this.treeViewSearch.Size = new System.Drawing.Size(174, 508);
            this.treeViewSearch.TabIndex = 3;
            this.treeViewSearch.Visible = false;
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.LabelEdit = true;
            this.treeView.Location = new System.Drawing.Point(0, 25);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(174, 512);
            this.treeView.TabIndex = 0;
            // 
            // editor1
            // 
            this.editor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editor1.CaretColor = System.Drawing.Color.Black;
            this.editor1.CloseButtonBorder = System.Drawing.SystemColors.GradientActiveCaption;
            this.editor1.EditorBackColor = System.Drawing.Color.White;
            this.editor1.IndentColor = System.Drawing.Color.WhiteSmoke;
            this.editor1.LineNumberColor = System.Drawing.Color.Teal;
            this.editor1.Location = new System.Drawing.Point(0, 3);
            this.editor1.Name = "editor1";
            this.editor1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.editor1.Size = new System.Drawing.Size(331, 534);
            this.editor1.Split = false;
            this.editor1.SplitDistance = 272;
            this.editor1.TabIndex = 0;
            // 
            // editor2
            // 
            this.editor2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.editor2.CaretColor = System.Drawing.Color.Black;
            this.editor2.CloseButtonBorder = System.Drawing.SystemColors.GradientInactiveCaption;
            this.editor2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor2.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(250)))));
            this.editor2.IndentColor = System.Drawing.Color.WhiteSmoke;
            this.editor2.LineNumberColor = System.Drawing.Color.Peru;
            this.editor2.Location = new System.Drawing.Point(0, 0);
            this.editor2.Name = "editor2";
            this.editor2.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.editor2.Size = new System.Drawing.Size(271, 266);
            this.editor2.Split = false;
            this.editor2.SplitDistance = 123;
            this.editor2.TabIndex = 0;
            // 
            // transpanel
            // 
            this.transpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.transpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(0)))));
            this.transpanel.Location = new System.Drawing.Point(-380, -229);
            this.transpanel.Name = "transpanel";
            this.transpanel.Size = new System.Drawing.Size(650, 490);
            this.transpanel.TabIndex = 0;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.ts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "4Hud 1.0";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(0)))));
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            this.split.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.treeViewContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ts;
        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.ToolStripSplitButton tsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsSettingsEditor;
        private SplitFCTB editor2;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ToolStripMenuItem tsChangeHudPath;
        private SplitFCTB editor1;
        private System.Windows.Forms.ContextMenuStrip treeViewContext;
        private System.Windows.Forms.ToolStripMenuItem cmOpenLeftEditor;
        private System.Windows.Forms.ToolStripMenuItem cmOpenRightEditor;
        private System.Windows.Forms.ToolStripSeparator tsUpSplitter;
        private System.Windows.Forms.ToolStripButton tsUpRestart;
        private System.Windows.Forms.ToolStripButton tsUpButton;
        private System.Windows.Forms.ToolStripMenuItem cmOpenDefaultTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmOpenEditor;
        private System.Windows.Forms.ToolStripMenuItem tsSortFile;
        private System.Windows.Forms.ToolStripMenuItem tsSteamPath;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Transpanel transpanel;
        private System.Windows.Forms.TextBox treeviewFindTxt;
        private System.Windows.Forms.Button treeviewFindBtn;
        private System.Windows.Forms.TreeView treeViewSearch;
        private System.Windows.Forms.ToolStripMenuItem tsSettings;
        private System.Windows.Forms.ToolStripButton tsLaunchTF2;
        private System.Windows.Forms.ToolStripComboBox tsLaunchPresets;
        private System.Windows.Forms.ToolStripComboBox tsMaps;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsLaunchSettings;
        private System.Windows.Forms.ToolStripButton tsRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem cmRename;
        private System.Windows.Forms.ToolStripButton tsSaveAll;
        private System.Windows.Forms.ToolStripMenuItem cmDelete;
        private System.Windows.Forms.ToolStripMenuItem tsMenuDesigner;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem cmOpenExplorer;
        private System.Windows.Forms.ToolStripMenuItem tsTopMost;
    }
}

