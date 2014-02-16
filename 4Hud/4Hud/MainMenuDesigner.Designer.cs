namespace _4Hud
{
    partial class MainMenuDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuDesigner));
            this.container = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.editor = new FastColoredTextBoxNS.FastColoredTextBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSnap = new System.Windows.Forms.ToolStripButton();
            this.tsGridSize = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBringToFront = new System.Windows.Forms.ToolStripButton();
            this.tsSendToBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsShowIt = new System.Windows.Forms.ToolStripSplitButton();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editor)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.container.Location = new System.Drawing.Point(8, 35);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(642, 482);
            this.container.TabIndex = 0;
            this.container.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.container_ControlAdded);
            this.container.Paint += new System.Windows.Forms.PaintEventHandler(this.container_Paint);
            this.container.MouseMove += new System.Windows.Forms.MouseEventHandler(this.container_MouseMove);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPosition,
            this.tsLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 524);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1090, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsPosition
            // 
            this.tsPosition.AutoSize = false;
            this.tsPosition.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPosition.Name = "tsPosition";
            this.tsPosition.Size = new System.Drawing.Size(100, 17);
            this.tsPosition.Text = "tsPosition";
            this.tsPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsLabel
            // 
            this.tsLabel.Name = "tsLabel";
            this.tsLabel.Size = new System.Drawing.Size(44, 17);
            this.tsLabel.Text = "tsLabel";
            // 
            // editor
            // 
            this.editor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editor.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.editor.BackBrush = null;
            this.editor.CharHeight = 14;
            this.editor.CharWidth = 8;
            this.editor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.editor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.editor.Hotkeys = resources.GetString("editor.Hotkeys");
            this.editor.IsReplaceMode = false;
            this.editor.Location = new System.Drawing.Point(658, 35);
            this.editor.Name = "editor";
            this.editor.Paddings = new System.Windows.Forms.Padding(0);
            this.editor.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.editor.Size = new System.Drawing.Size(420, 473);
            this.editor.TabIndex = 2;
            this.editor.Zoom = 100;
            this.editor.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.editor_TextChanged);
            this.editor.VisibleRangeChangedDelayed += new System.EventHandler(this.editor_VisibleRangeChangedDelayed);
            // 
            // comboBox
            // 
            this.comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(658, 8);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(420, 21);
            this.comboBox.TabIndex = 3;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSnap,
            this.tsGridSize,
            this.toolStripSeparator1,
            this.tsBringToFront,
            this.tsSendToBack,
            this.toolStripSeparator3,
            this.tsShowIt});
            this.toolStrip1.Location = new System.Drawing.Point(9, 8);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(640, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSnap
            // 
            this.btnSnap.CheckOnClick = true;
            this.btnSnap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSnap.Image = global::_4Hud.Properties.Resources.snapToGrid;
            this.btnSnap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(23, 22);
            this.btnSnap.Text = "Snap to grid";
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // tsGridSize
            // 
            this.tsGridSize.AutoSize = false;
            this.tsGridSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsGridSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripSeparator2,
            this.toolStripMenuItem9,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8});
            this.tsGridSize.Image = ((System.Drawing.Image)(resources.GetObject("tsGridSize.Image")));
            this.tsGridSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsGridSize.Name = "tsGridSize";
            this.tsGridSize.Size = new System.Drawing.Size(40, 22);
            this.tsGridSize.Text = "8";
            this.tsGridSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsGridSize.ToolTipText = "Grid Size";
            this.tsGridSize.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsGridSize_DropDownItemClicked);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem2.Text = "4";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem3.Text = "8";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem4.Text = "16";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem5.Text = "32";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(83, 6);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem9.Text = "5";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem6.Text = "10";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem7.Text = "20";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem8.Text = "40";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBringToFront
            // 
            this.tsBringToFront.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBringToFront.Image = global::_4Hud.Properties.Resources.bringToFront;
            this.tsBringToFront.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBringToFront.Name = "tsBringToFront";
            this.tsBringToFront.Size = new System.Drawing.Size(23, 22);
            this.tsBringToFront.Text = "BringToFront (editor only)";
            this.tsBringToFront.Click += new System.EventHandler(this.tsBringToFront_Click);
            // 
            // tsSendToBack
            // 
            this.tsSendToBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSendToBack.Image = global::_4Hud.Properties.Resources.sendToBack;
            this.tsSendToBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSendToBack.Name = "tsSendToBack";
            this.tsSendToBack.Size = new System.Drawing.Size(23, 22);
            this.tsSendToBack.Text = "Send to back (editor only)";
            this.tsSendToBack.Click += new System.EventHandler(this.tsSendToBack_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsShowIt
            // 
            this.tsShowIt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsShowIt.Image = ((System.Drawing.Image)(resources.GetObject("tsShowIt.Image")));
            this.tsShowIt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsShowIt.Name = "tsShowIt";
            this.tsShowIt.Size = new System.Drawing.Size(54, 22);
            this.tsShowIt.Text = "adsad";
            // 
            // MainMenuDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 546);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.editor);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.container);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenuDesigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu Designer - This can\'t save right now!";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editor)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsLabel;
        private FastColoredTextBoxNS.FastColoredTextBox editor;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSnap;
        private System.Windows.Forms.ToolStripButton tsSendToBack;
        private System.Windows.Forms.ToolStripButton tsBringToFront;
        private System.Windows.Forms.ToolStripStatusLabel tsPosition;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton tsGridSize;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSplitButton tsShowIt;
    }
}