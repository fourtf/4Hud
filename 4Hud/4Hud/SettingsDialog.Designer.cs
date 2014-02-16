namespace _4Hud
{
    partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
            this.lblReloadHud = new System.Windows.Forms.Label();
            this.combReloadHud = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.btnLaunchLine = new System.Windows.Forms.Button();
            this.lblLaunchLine = new System.Windows.Forms.Label();
            this.txtLaunchLine = new System.Windows.Forms.TextBox();
            this.lblTip = new System.Windows.Forms.Label();
            this.btnHudOpen = new System.Windows.Forms.Button();
            this.btnSteamOpen = new System.Windows.Forms.Button();
            this.txtHud = new System.Windows.Forms.TextBox();
            this.lblHud = new System.Windows.Forms.Label();
            this.lblSteam = new System.Windows.Forms.Label();
            this.txtSteam = new System.Windows.Forms.TextBox();
            this.chkDev = new System.Windows.Forms.CheckBox();
            this.tabLaunchSettings = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPresetsReset = new System.Windows.Forms.Button();
            this.btnPresetsRemove = new System.Windows.Forms.Button();
            this.btnPresetsAdd = new System.Windows.Forms.Button();
            this.lblLaunch = new System.Windows.Forms.Label();
            this.gridLaunch = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colHook = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabKeys = new System.Windows.Forms.TabPage();
            this.groupReloadScheme = new System.Windows.Forms.GroupBox();
            this.txtReloadConsoleCode = new System.Windows.Forms.TextBox();
            this.lblReloadConsoleCode = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.tabLaunchSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLaunch)).BeginInit();
            this.tabKeys.SuspendLayout();
            this.groupReloadScheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblReloadHud
            // 
            this.lblReloadHud.AutoSize = true;
            this.lblReloadHud.Location = new System.Drawing.Point(6, 25);
            this.lblReloadHud.Name = "lblReloadHud";
            this.lblReloadHud.Size = new System.Drawing.Size(130, 13);
            this.lblReloadHud.TabIndex = 0;
            this.lblReloadHud.Text = "Ingame key to reload hud:";
            // 
            // combReloadHud
            // 
            this.combReloadHud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combReloadHud.FormattingEnabled = true;
            this.combReloadHud.Location = new System.Drawing.Point(142, 22);
            this.combReloadHud.Name = "combReloadHud";
            this.combReloadHud.Size = new System.Drawing.Size(121, 21);
            this.combReloadHud.TabIndex = 1;
            this.combReloadHud.SelectedIndexChanged += new System.EventHandler(this.combReloadHud_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabOptions);
            this.tabControl1.Controls.Add(this.tabLaunchSettings);
            this.tabControl1.Controls.Add(this.tabKeys);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(-1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(531, 290);
            this.tabControl1.TabIndex = 2;
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.btnLaunchLine);
            this.tabOptions.Controls.Add(this.lblLaunchLine);
            this.tabOptions.Controls.Add(this.txtLaunchLine);
            this.tabOptions.Controls.Add(this.lblTip);
            this.tabOptions.Controls.Add(this.btnHudOpen);
            this.tabOptions.Controls.Add(this.btnSteamOpen);
            this.tabOptions.Controls.Add(this.txtHud);
            this.tabOptions.Controls.Add(this.lblHud);
            this.tabOptions.Controls.Add(this.lblSteam);
            this.tabOptions.Controls.Add(this.txtSteam);
            this.tabOptions.Controls.Add(this.chkDev);
            this.tabOptions.ImageIndex = 2;
            this.tabOptions.Location = new System.Drawing.Point(4, 23);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Size = new System.Drawing.Size(523, 263);
            this.tabOptions.TabIndex = 2;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // btnLaunchLine
            // 
            this.btnLaunchLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLaunchLine.Image = global::_4Hud.Properties.Resources.refresh;
            this.btnLaunchLine.Location = new System.Drawing.Point(489, 6);
            this.btnLaunchLine.Name = "btnLaunchLine";
            this.btnLaunchLine.Size = new System.Drawing.Size(23, 23);
            this.btnLaunchLine.TabIndex = 10;
            this.btnLaunchLine.UseVisualStyleBackColor = true;
            this.btnLaunchLine.Click += new System.EventHandler(this.btnLaunchLine_Click);
            // 
            // lblLaunchLine
            // 
            this.lblLaunchLine.AutoSize = true;
            this.lblLaunchLine.Location = new System.Drawing.Point(7, 11);
            this.lblLaunchLine.Name = "lblLaunchLine";
            this.lblLaunchLine.Size = new System.Drawing.Size(126, 13);
            this.lblLaunchLine.TabIndex = 9;
            this.lblLaunchLine.Text = "Custom Start Parameters:";
            // 
            // txtLaunchLine
            // 
            this.txtLaunchLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLaunchLine.Location = new System.Drawing.Point(139, 8);
            this.txtLaunchLine.Name = "txtLaunchLine";
            this.txtLaunchLine.Size = new System.Drawing.Size(344, 20);
            this.txtLaunchLine.TabIndex = 8;
            this.txtLaunchLine.TextChanged += new System.EventHandler(this.txtLaunchLine_TextChanged);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(7, 40);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(375, 13);
            this.lblTip.TabIndex = 7;
            this.lblTip.Text = "Tip: 4Hud will import map lists and such if you have 4Script in the same Folder.";
            // 
            // btnHudOpen
            // 
            this.btnHudOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHudOpen.Image = global::_4Hud.Properties.Resources.openFolder;
            this.btnHudOpen.Location = new System.Drawing.Point(489, 154);
            this.btnHudOpen.Name = "btnHudOpen";
            this.btnHudOpen.Size = new System.Drawing.Size(23, 23);
            this.btnHudOpen.TabIndex = 6;
            this.btnHudOpen.UseVisualStyleBackColor = true;
            this.btnHudOpen.Visible = false;
            this.btnHudOpen.Click += new System.EventHandler(this.btnHudOpen_Click);
            // 
            // btnSteamOpen
            // 
            this.btnSteamOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSteamOpen.Image = global::_4Hud.Properties.Resources.openFolder;
            this.btnSteamOpen.Location = new System.Drawing.Point(489, 128);
            this.btnSteamOpen.Name = "btnSteamOpen";
            this.btnSteamOpen.Size = new System.Drawing.Size(23, 23);
            this.btnSteamOpen.TabIndex = 5;
            this.btnSteamOpen.UseVisualStyleBackColor = true;
            this.btnSteamOpen.Visible = false;
            // 
            // txtHud
            // 
            this.txtHud.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHud.Location = new System.Drawing.Point(51, 156);
            this.txtHud.Name = "txtHud";
            this.txtHud.Size = new System.Drawing.Size(434, 20);
            this.txtHud.TabIndex = 4;
            this.txtHud.Visible = false;
            // 
            // lblHud
            // 
            this.lblHud.AutoSize = true;
            this.lblHud.Location = new System.Drawing.Point(7, 159);
            this.lblHud.Name = "lblHud";
            this.lblHud.Size = new System.Drawing.Size(30, 13);
            this.lblHud.TabIndex = 3;
            this.lblHud.Text = "Hud:";
            this.lblHud.Visible = false;
            // 
            // lblSteam
            // 
            this.lblSteam.AutoSize = true;
            this.lblSteam.Location = new System.Drawing.Point(5, 133);
            this.lblSteam.Name = "lblSteam";
            this.lblSteam.Size = new System.Drawing.Size(40, 13);
            this.lblSteam.TabIndex = 2;
            this.lblSteam.Text = "Steam:";
            this.lblSteam.Visible = false;
            // 
            // txtSteam
            // 
            this.txtSteam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSteam.Location = new System.Drawing.Point(51, 130);
            this.txtSteam.Name = "txtSteam";
            this.txtSteam.Size = new System.Drawing.Size(434, 20);
            this.txtSteam.TabIndex = 1;
            this.txtSteam.Visible = false;
            // 
            // chkDev
            // 
            this.chkDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDev.AutoSize = true;
            this.chkDev.Location = new System.Drawing.Point(8, 243);
            this.chkDev.Name = "chkDev";
            this.chkDev.Size = new System.Drawing.Size(136, 17);
            this.chkDev.TabIndex = 0;
            this.chkDev.Text = "Enable Developer Stuff";
            this.chkDev.UseVisualStyleBackColor = true;
            this.chkDev.CheckedChanged += new System.EventHandler(this.chkDev_CheckedChanged);
            // 
            // tabLaunchSettings
            // 
            this.tabLaunchSettings.Controls.Add(this.btnReset);
            this.tabLaunchSettings.Controls.Add(this.btnPresetsReset);
            this.tabLaunchSettings.Controls.Add(this.btnPresetsRemove);
            this.tabLaunchSettings.Controls.Add(this.btnPresetsAdd);
            this.tabLaunchSettings.Controls.Add(this.lblLaunch);
            this.tabLaunchSettings.Controls.Add(this.gridLaunch);
            this.tabLaunchSettings.ImageIndex = 1;
            this.tabLaunchSettings.Location = new System.Drawing.Point(4, 23);
            this.tabLaunchSettings.Name = "tabLaunchSettings";
            this.tabLaunchSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabLaunchSettings.Size = new System.Drawing.Size(523, 263);
            this.tabLaunchSettings.TabIndex = 1;
            this.tabLaunchSettings.Text = "Launch Presets";
            this.tabLaunchSettings.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(442, 237);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnPresetsReset
            // 
            this.btnPresetsReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPresetsReset.Location = new System.Drawing.Point(352, 237);
            this.btnPresetsReset.Name = "btnPresetsReset";
            this.btnPresetsReset.Size = new System.Drawing.Size(87, 23);
            this.btnPresetsReset.TabIndex = 5;
            this.btnPresetsReset.Text = "Add Defaults";
            this.btnPresetsReset.UseVisualStyleBackColor = true;
            this.btnPresetsReset.Click += new System.EventHandler(this.btnPresetsReset_Click);
            // 
            // btnPresetsRemove
            // 
            this.btnPresetsRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPresetsRemove.Location = new System.Drawing.Point(84, 237);
            this.btnPresetsRemove.Name = "btnPresetsRemove";
            this.btnPresetsRemove.Size = new System.Drawing.Size(75, 23);
            this.btnPresetsRemove.TabIndex = 4;
            this.btnPresetsRemove.Text = "Remove";
            this.btnPresetsRemove.UseVisualStyleBackColor = true;
            this.btnPresetsRemove.Click += new System.EventHandler(this.btnPresetsRemove_Click);
            // 
            // btnPresetsAdd
            // 
            this.btnPresetsAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPresetsAdd.Location = new System.Drawing.Point(3, 237);
            this.btnPresetsAdd.Name = "btnPresetsAdd";
            this.btnPresetsAdd.Size = new System.Drawing.Size(75, 23);
            this.btnPresetsAdd.TabIndex = 3;
            this.btnPresetsAdd.Text = "Add";
            this.btnPresetsAdd.UseVisualStyleBackColor = true;
            this.btnPresetsAdd.Click += new System.EventHandler(this.btnPresetsAdd_Click);
            // 
            // lblLaunch
            // 
            this.lblLaunch.AutoSize = true;
            this.lblLaunch.Location = new System.Drawing.Point(6, 3);
            this.lblLaunch.Name = "lblLaunch";
            this.lblLaunch.Size = new System.Drawing.Size(224, 13);
            this.lblLaunch.TabIndex = 1;
            this.lblLaunch.Text = "You can create Presets for launching tf2 here:";
            // 
            // gridLaunch
            // 
            this.gridLaunch.AllowUserToAddRows = false;
            this.gridLaunch.AllowUserToDeleteRows = false;
            this.gridLaunch.AllowUserToResizeRows = false;
            this.gridLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLaunch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLaunch.BackgroundColor = System.Drawing.Color.White;
            this.gridLaunch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridLaunch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLaunch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colWidth,
            this.colHeight,
            this.colFull,
            this.colHook});
            this.gridLaunch.Location = new System.Drawing.Point(3, 19);
            this.gridLaunch.MultiSelect = false;
            this.gridLaunch.Name = "gridLaunch";
            this.gridLaunch.Size = new System.Drawing.Size(517, 212);
            this.gridLaunch.TabIndex = 0;
            this.gridLaunch.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLaunch_CellValueChanged);
            // 
            // colName
            // 
            this.colName.FillWeight = 140F;
            this.colName.HeaderText = "Alias";
            this.colName.Name = "colName";
            // 
            // colWidth
            // 
            this.colWidth.FillWeight = 45F;
            this.colWidth.HeaderText = "Width";
            this.colWidth.Name = "colWidth";
            // 
            // colHeight
            // 
            this.colHeight.FillWeight = 45F;
            this.colHeight.HeaderText = "Height";
            this.colHeight.Name = "colHeight";
            // 
            // colFull
            // 
            this.colFull.FillWeight = 60F;
            this.colFull.HeaderText = "Fullscreen";
            this.colFull.Name = "colFull";
            // 
            // colHook
            // 
            this.colHook.FillWeight = 80F;
            this.colHook.HeaderText = "Hook in 4Hud";
            this.colHook.Name = "colHook";
            // 
            // tabKeys
            // 
            this.tabKeys.BackColor = System.Drawing.Color.White;
            this.tabKeys.Controls.Add(this.label1);
            this.tabKeys.Controls.Add(this.groupReloadScheme);
            this.tabKeys.ImageIndex = 0;
            this.tabKeys.Location = new System.Drawing.Point(4, 23);
            this.tabKeys.Name = "tabKeys";
            this.tabKeys.Padding = new System.Windows.Forms.Padding(3);
            this.tabKeys.Size = new System.Drawing.Size(523, 263);
            this.tabKeys.TabIndex = 0;
            this.tabKeys.Text = "Keys";
            // 
            // groupReloadScheme
            // 
            this.groupReloadScheme.Controls.Add(this.lblReloadHud);
            this.groupReloadScheme.Controls.Add(this.txtReloadConsoleCode);
            this.groupReloadScheme.Controls.Add(this.combReloadHud);
            this.groupReloadScheme.Controls.Add(this.lblReloadConsoleCode);
            this.groupReloadScheme.Location = new System.Drawing.Point(6, 6);
            this.groupReloadScheme.Name = "groupReloadScheme";
            this.groupReloadScheme.Size = new System.Drawing.Size(362, 101);
            this.groupReloadScheme.TabIndex = 5;
            this.groupReloadScheme.TabStop = false;
            this.groupReloadScheme.Text = "4Hud needs a keybind in TF2 to reload the hud";
            // 
            // txtReloadConsoleCode
            // 
            this.txtReloadConsoleCode.Location = new System.Drawing.Point(6, 75);
            this.txtReloadConsoleCode.Name = "txtReloadConsoleCode";
            this.txtReloadConsoleCode.ReadOnly = true;
            this.txtReloadConsoleCode.Size = new System.Drawing.Size(352, 20);
            this.txtReloadConsoleCode.TabIndex = 4;
            // 
            // lblReloadConsoleCode
            // 
            this.lblReloadConsoleCode.AutoSize = true;
            this.lblReloadConsoleCode.Location = new System.Drawing.Point(6, 59);
            this.lblReloadConsoleCode.Name = "lblReloadConsoleCode";
            this.lblReloadConsoleCode.Size = new System.Drawing.Size(315, 13);
            this.lblReloadConsoleCode.TabIndex = 3;
            this.lblReloadConsoleCode.Text = "Copy the following code and put it in your TF2 console/autoexec:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "KeyBoard");
            this.imageList1.Images.SetKeyName(1, "LaunchPresets");
            this.imageList1.Images.SetKeyName(2, "Window");
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(440, 298);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "Hotkeys in the editor are currently fixed to certain keycombinations:\r\n   F5: Rel" +
    "oad Hud ingame\r\n   F6: Bring 4Hud and TF2 to the front";
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 325);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(450, 266);
            this.Name = "SettingsDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabOptions.ResumeLayout(false);
            this.tabOptions.PerformLayout();
            this.tabLaunchSettings.ResumeLayout(false);
            this.tabLaunchSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLaunch)).EndInit();
            this.tabKeys.ResumeLayout(false);
            this.tabKeys.PerformLayout();
            this.groupReloadScheme.ResumeLayout(false);
            this.groupReloadScheme.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblReloadHud;
        private System.Windows.Forms.ComboBox combReloadHud;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabKeys;
        private System.Windows.Forms.TabPage tabLaunchSettings;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView gridLaunch;
        private System.Windows.Forms.Label lblLaunch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeight;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colFull;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colHook;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.CheckBox chkDev;
        private System.Windows.Forms.Label lblReloadConsoleCode;
        private System.Windows.Forms.TextBox txtReloadConsoleCode;
        private System.Windows.Forms.GroupBox groupReloadScheme;
        private System.Windows.Forms.TextBox txtSteam;
        private System.Windows.Forms.Label lblSteam;
        private System.Windows.Forms.Label lblHud;
        private System.Windows.Forms.TextBox txtHud;
        private System.Windows.Forms.Button btnSteamOpen;
        private System.Windows.Forms.Button btnHudOpen;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Button btnPresetsReset;
        private System.Windows.Forms.Button btnPresetsRemove;
        private System.Windows.Forms.Button btnPresetsAdd;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtLaunchLine;
        private System.Windows.Forms.Label lblLaunchLine;
        private System.Windows.Forms.Button btnLaunchLine;
        private System.Windows.Forms.Label label1;
    }
}