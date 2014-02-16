namespace _4Hud
{
    partial class SelectHudPathForm
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
            this.radCustomPath = new System.Windows.Forms.RadioButton();
            this.groupCustom = new System.Windows.Forms.GroupBox();
            this.btnCustomFolder = new System.Windows.Forms.Button();
            this.lblCustom = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.groupDirect = new System.Windows.Forms.GroupBox();
            this.btnDirectFolder = new System.Windows.Forms.Button();
            this.lblDirect = new System.Windows.Forms.Label();
            this.radDirectFolder = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupCustom.SuspendLayout();
            this.groupDirect.SuspendLayout();
            this.SuspendLayout();
            // 
            // radCustomPath
            // 
            this.radCustomPath.AutoSize = true;
            this.radCustomPath.Checked = true;
            this.radCustomPath.Location = new System.Drawing.Point(19, 10);
            this.radCustomPath.Name = "radCustomPath";
            this.radCustomPath.Size = new System.Drawing.Size(164, 17);
            this.radCustomPath.TabIndex = 0;
            this.radCustomPath.TabStop = true;
            this.radCustomPath.Text = "Scan your tf/custom directory\r\n";
            this.radCustomPath.UseVisualStyleBackColor = true;
            this.radCustomPath.CheckedChanged += new System.EventHandler(this.radCustomPath_CheckedChanged);
            // 
            // groupCustom
            // 
            this.groupCustom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCustom.Controls.Add(this.btnCustomFolder);
            this.groupCustom.Controls.Add(this.lblCustom);
            this.groupCustom.Controls.Add(this.lbl);
            this.groupCustom.Location = new System.Drawing.Point(12, 12);
            this.groupCustom.Name = "groupCustom";
            this.groupCustom.Size = new System.Drawing.Size(471, 78);
            this.groupCustom.TabIndex = 1;
            this.groupCustom.TabStop = false;
            this.groupCustom.Text = "    ";
            // 
            // btnCustomFolder
            // 
            this.btnCustomFolder.Image = global::_4Hud.Properties.Resources.openFolder;
            this.btnCustomFolder.Location = new System.Drawing.Point(9, 46);
            this.btnCustomFolder.Name = "btnCustomFolder";
            this.btnCustomFolder.Size = new System.Drawing.Size(23, 23);
            this.btnCustomFolder.TabIndex = 3;
            this.btnCustomFolder.UseVisualStyleBackColor = true;
            this.btnCustomFolder.Click += new System.EventHandler(this.btnCustomFolder_Click);
            // 
            // lblCustom
            // 
            this.lblCustom.AutoSize = true;
            this.lblCustom.Location = new System.Drawing.Point(38, 51);
            this.lblCustom.Name = "lblCustom";
            this.lblCustom.Size = new System.Drawing.Size(52, 13);
            this.lblCustom.TabIndex = 2;
            this.lblCustom.Text = "lblCustom";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(6, 18);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(220, 13);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "4Hud will search for a folder containing a hud";
            // 
            // groupDirect
            // 
            this.groupDirect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupDirect.Controls.Add(this.btnDirectFolder);
            this.groupDirect.Controls.Add(this.lblDirect);
            this.groupDirect.Enabled = false;
            this.groupDirect.Location = new System.Drawing.Point(12, 96);
            this.groupDirect.Name = "groupDirect";
            this.groupDirect.Size = new System.Drawing.Size(471, 52);
            this.groupDirect.TabIndex = 4;
            this.groupDirect.TabStop = false;
            this.groupDirect.Text = "    ";
            // 
            // btnDirectFolder
            // 
            this.btnDirectFolder.Image = global::_4Hud.Properties.Resources.openFolder;
            this.btnDirectFolder.Location = new System.Drawing.Point(6, 21);
            this.btnDirectFolder.Name = "btnDirectFolder";
            this.btnDirectFolder.Size = new System.Drawing.Size(23, 23);
            this.btnDirectFolder.TabIndex = 3;
            this.btnDirectFolder.UseVisualStyleBackColor = true;
            this.btnDirectFolder.Click += new System.EventHandler(this.btnDirectFolder_Click);
            // 
            // lblDirect
            // 
            this.lblDirect.AutoSize = true;
            this.lblDirect.Location = new System.Drawing.Point(35, 26);
            this.lblDirect.Name = "lblDirect";
            this.lblDirect.Size = new System.Drawing.Size(45, 13);
            this.lblDirect.TabIndex = 2;
            this.lblDirect.Text = "lblDirect";
            // 
            // radDirectFolder
            // 
            this.radDirectFolder.AutoSize = true;
            this.radDirectFolder.Location = new System.Drawing.Point(20, 94);
            this.radDirectFolder.Name = "radDirectFolder";
            this.radDirectFolder.Size = new System.Drawing.Size(107, 17);
            this.radDirectFolder.TabIndex = 0;
            this.radDirectFolder.Text = "Select Hud folder";
            this.radDirectFolder.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(408, 164);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(327, 164);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // SelectHudPathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 199);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.radDirectFolder);
            this.Controls.Add(this.radCustomPath);
            this.Controls.Add(this.groupDirect);
            this.Controls.Add(this.groupCustom);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 237);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(0, 237);
            this.Name = "SelectHudPathForm";
            this.Text = "Select your hud path";
            this.groupCustom.ResumeLayout(false);
            this.groupCustom.PerformLayout();
            this.groupDirect.ResumeLayout(false);
            this.groupDirect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radCustomPath;
        private System.Windows.Forms.GroupBox groupCustom;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btnCustomFolder;
        private System.Windows.Forms.Label lblCustom;
        private System.Windows.Forms.GroupBox groupDirect;
        private System.Windows.Forms.Button btnDirectFolder;
        private System.Windows.Forms.Label lblDirect;
        private System.Windows.Forms.RadioButton radDirectFolder;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}