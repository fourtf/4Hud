namespace _4Hud
{
    partial class SplitFCTB
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplitFCTB));
            this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuSplitTextbox = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowLineNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSplit1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFind = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.split = new System.Windows.Forms.SplitContainer();
            this.editor1 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.editor2 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.line1 = new _4Hud.Line();
            this.line2 = new _4Hud.Line();
            this.tabControl = new _4Hud.DragTabControl();
            this.MenuStrip.SuspendLayout();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editor2)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSplitTextbox,
            this.menuShowLineNumbers,
            this.menuSplit1,
            this.menuFind,
            this.menuReplace});
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(193, 98);
            // 
            // menuSplitTextbox
            // 
            this.menuSplitTextbox.Checked = true;
            this.menuSplitTextbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuSplitTextbox.Name = "menuSplitTextbox";
            this.menuSplitTextbox.Size = new System.Drawing.Size(192, 22);
            this.menuSplitTextbox.Text = "Split Textbox Vertically";
            this.menuSplitTextbox.Click += new System.EventHandler(this.menuSplitTextbox_Click);
            // 
            // menuShowLineNumbers
            // 
            this.menuShowLineNumbers.Checked = true;
            this.menuShowLineNumbers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuShowLineNumbers.Name = "menuShowLineNumbers";
            this.menuShowLineNumbers.Size = new System.Drawing.Size(192, 22);
            this.menuShowLineNumbers.Text = "Show Line Numbers";
            this.menuShowLineNumbers.Click += new System.EventHandler(this.menuShowLineNumbers_Click);
            // 
            // menuSplit1
            // 
            this.menuSplit1.Name = "menuSplit1";
            this.menuSplit1.Size = new System.Drawing.Size(189, 6);
            // 
            // menuFind
            // 
            this.menuFind.Image = global::_4Hud.Properties.Resources.find;
            this.menuFind.Name = "menuFind";
            this.menuFind.ShortcutKeyDisplayString = "Ctrl+F";
            this.menuFind.Size = new System.Drawing.Size(192, 22);
            this.menuFind.Text = "Find";
            this.menuFind.Click += new System.EventHandler(this.menuFind_Click);
            // 
            // menuReplace
            // 
            this.menuReplace.Name = "menuReplace";
            this.menuReplace.ShortcutKeyDisplayString = "Ctrl+R";
            this.menuReplace.Size = new System.Drawing.Size(192, 22);
            this.menuReplace.Text = "Replace";
            this.menuReplace.Click += new System.EventHandler(this.menuReplace_Click);
            // 
            // split
            // 
            this.split.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.split.Location = new System.Drawing.Point(0, 21);
            this.split.Name = "split";
            this.split.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.editor1);
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.editor2);
            this.split.Size = new System.Drawing.Size(150, 128);
            this.split.SplitterDistance = 64;
            this.split.TabIndex = 1;
            this.split.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.split_SplitterMoved);
            // 
            // editor1
            // 
            this.editor1.AutoScrollMinSize = new System.Drawing.Size(251, 42);
            this.editor1.BackBrush = null;
            this.editor1.CharHeight = 14;
            this.editor1.CharWidth = 8;
            this.editor1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.editor1.DelayedEventsInterval = 1;
            this.editor1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.editor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor1.Hotkeys = resources.GetString("editor1.Hotkeys");
            this.editor1.IsReplaceMode = false;
            this.editor1.LeftBracket = '{';
            this.editor1.Location = new System.Drawing.Point(0, 0);
            this.editor1.Name = "editor1";
            this.editor1.Paddings = new System.Windows.Forms.Padding(0);
            this.editor1.RightBracket = '}';
            this.editor1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.editor1.Size = new System.Drawing.Size(150, 64);
            this.editor1.TabIndex = 0;
            this.editor1.Text = "//\r\n// Select a file on the left\r\n//";
            this.editor1.Zoom = 100;
            this.editor1.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.editor1_TextChanged);
            this.editor1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.editor1_MouseClick);
            // 
            // editor2
            // 
            this.editor2.AutoIndentExistingLines = false;
            this.editor2.AutoScrollMinSize = new System.Drawing.Size(251, 42);
            this.editor2.BackBrush = null;
            this.editor2.CharHeight = 14;
            this.editor2.CharWidth = 8;
            this.editor2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.editor2.DelayedEventsInterval = 1;
            this.editor2.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.editor2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor2.Hotkeys = resources.GetString("editor2.Hotkeys");
            this.editor2.IsReplaceMode = false;
            this.editor2.LeftBracket = '{';
            this.editor2.Location = new System.Drawing.Point(0, 0);
            this.editor2.Name = "editor2";
            this.editor2.Paddings = new System.Windows.Forms.Padding(0);
            this.editor2.RightBracket = '}';
            this.editor2.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.editor2.Size = new System.Drawing.Size(150, 60);
            this.editor2.SourceTextBox = this.editor1;
            this.editor2.TabIndex = 0;
            this.editor2.Text = "//\r\n// Select a file on the left\r\n//";
            this.editor2.Zoom = 100;
            this.editor2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.editor2_MouseClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::_4Hud.Properties.Resources.x;
            this.btnClose.Location = new System.Drawing.Point(133, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(17, 17);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.Location = new System.Drawing.Point(122, 20);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(50, 10);
            this.line1.TabIndex = 4;
            // 
            // line2
            // 
            this.line2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line2.Location = new System.Drawing.Point(1, 20);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(150, 10);
            this.line2.TabIndex = 5;
            // 
            // tabControl
            // 
            this.tabControl.AllowDrop = true;
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(133, 21);
            this.tabControl.TabIndex = 2;
            this.tabControl.Visible = false;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // SplitFCTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.split);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.line2);
            this.Controls.Add(this.tabControl);
            this.Name = "SplitFCTB";
            this.MenuStrip.ResumeLayout(false);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            this.split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editor2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuSplitTextbox;
        private System.Windows.Forms.ToolStripMenuItem menuShowLineNumbers;
        private System.Windows.Forms.SplitContainer split;
        private _4Hud.DragTabControl tabControl;
        private Line line1;
        private Line line2;
        private System.Windows.Forms.ToolStripSeparator menuSplit1;
        private System.Windows.Forms.ToolStripMenuItem menuFind;
        private System.Windows.Forms.ToolStripMenuItem menuReplace;
        public FastColoredTextBoxNS.FastColoredTextBox editor1;
        public FastColoredTextBoxNS.FastColoredTextBox editor2;
        public System.Windows.Forms.Button btnClose;
    }
}
