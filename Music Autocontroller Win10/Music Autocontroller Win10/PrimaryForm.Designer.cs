namespace Music_Autocontroller_Win10
{
    partial class PrimaryForm
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
            this.OnOffButton = new System.Windows.Forms.Button();
            this.MusicSelectionBox = new System.Windows.Forms.ComboBox();
            this.ScanButton = new System.Windows.Forms.Button();
            this.ExemptApps = new System.Windows.Forms.CheckedListBox();
            this.ExemptTitle = new System.Windows.Forms.TextBox();
            this.AboutButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.IsSelectedExempt = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.DetailedAppTitle = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ActiveMusicVolume = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.DefaultMusicVolume = new System.Windows.Forms.NumericUpDown();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveMusicVolume)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultMusicVolume)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // OnOffButton
            // 
            this.OnOffButton.Location = new System.Drawing.Point(166, 262);
            this.OnOffButton.Name = "OnOffButton";
            this.OnOffButton.Size = new System.Drawing.Size(75, 23);
            this.OnOffButton.TabIndex = 0;
            this.OnOffButton.Text = "Start";
            this.OnOffButton.UseVisualStyleBackColor = true;
            this.OnOffButton.Click += new System.EventHandler(this.OnOffButton_Click);
            // 
            // MusicSelectionBox
            // 
            this.MusicSelectionBox.FormattingEnabled = true;
            this.MusicSelectionBox.Location = new System.Drawing.Point(13, 7);
            this.MusicSelectionBox.Name = "MusicSelectionBox";
            this.MusicSelectionBox.Size = new System.Drawing.Size(228, 21);
            this.MusicSelectionBox.TabIndex = 1;
            this.MusicSelectionBox.Text = "Select Music";
            // 
            // ScanButton
            // 
            this.ScanButton.Location = new System.Drawing.Point(13, 262);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(75, 23);
            this.ScanButton.TabIndex = 3;
            this.ScanButton.Text = "Scan";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.Scan_Click);
            // 
            // ExemptApps
            // 
            this.ExemptApps.FormattingEnabled = true;
            this.ExemptApps.Location = new System.Drawing.Point(13, 75);
            this.ExemptApps.Name = "ExemptApps";
            this.ExemptApps.Size = new System.Drawing.Size(228, 169);
            this.ExemptApps.TabIndex = 5;
            this.ExemptApps.SelectedIndexChanged += new System.EventHandler(this.ExemptApps_SelectedIndexChanged);
            // 
            // ExemptTitle
            // 
            this.ExemptTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ExemptTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ExemptTitle.ForeColor = System.Drawing.Color.Snow;
            this.ExemptTitle.Location = new System.Drawing.Point(13, 56);
            this.ExemptTitle.Name = "ExemptTitle";
            this.ExemptTitle.Size = new System.Drawing.Size(100, 13);
            this.ExemptTitle.TabIndex = 6;
            this.ExemptTitle.Text = "Exempt Apps";
            // 
            // AboutButton
            // 
            this.AboutButton.Location = new System.Drawing.Point(15, 0);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(44, 21);
            this.AboutButton.TabIndex = 7;
            this.AboutButton.Text = "About";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(189, 0);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(54, 21);
            this.SettingsButton.TabIndex = 8;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // IsSelectedExempt
            // 
            this.IsSelectedExempt.AutoSize = true;
            this.IsSelectedExempt.ForeColor = System.Drawing.Color.Snow;
            this.IsSelectedExempt.Location = new System.Drawing.Point(3, 44);
            this.IsSelectedExempt.Name = "IsSelectedExempt";
            this.IsSelectedExempt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.IsSelectedExempt.Size = new System.Drawing.Size(148, 17);
            this.IsSelectedExempt.TabIndex = 9;
            this.IsSelectedExempt.Text = "                             Exempt";
            this.IsSelectedExempt.UseVisualStyleBackColor = true;
            this.IsSelectedExempt.CheckedChanged += new System.EventHandler(this.IsSelectedExempt_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.DetailedAppTitle);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.IsSelectedExempt);
            this.panel1.Controls.Add(this.ActiveMusicVolume);
            this.panel1.Location = new System.Drawing.Point(58, 351);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 91);
            this.panel1.TabIndex = 10;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.ForeColor = System.Drawing.Color.Snow;
            this.textBox3.Location = new System.Drawing.Point(3, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(163, 13);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "Selected App Configuration";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DetailedAppTitle
            // 
            this.DetailedAppTitle.BackColor = System.Drawing.SystemColors.WindowText;
            this.DetailedAppTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DetailedAppTitle.ForeColor = System.Drawing.Color.Snow;
            this.DetailedAppTitle.Location = new System.Drawing.Point(3, 17);
            this.DetailedAppTitle.Margin = new System.Windows.Forms.Padding(4);
            this.DetailedAppTitle.Name = "DetailedAppTitle";
            this.DetailedAppTitle.Size = new System.Drawing.Size(163, 20);
            this.DetailedAppTitle.TabIndex = 11;
            this.DetailedAppTitle.Text = "App: ";
            this.DetailedAppTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.Snow;
            this.textBox1.Location = new System.Drawing.Point(3, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(104, 13);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Active Music Volume";
            // 
            // ActiveMusicVolume
            // 
            this.ActiveMusicVolume.Location = new System.Drawing.Point(113, 65);
            this.ActiveMusicVolume.Name = "ActiveMusicVolume";
            this.ActiveMusicVolume.Size = new System.Drawing.Size(43, 20);
            this.ActiveMusicVolume.TabIndex = 13;
            this.ActiveMusicVolume.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ActiveMusicVolume.ValueChanged += new System.EventHandler(this.ActiveMusicVolume_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.DefaultMusicVolume);
            this.panel2.Controls.Add(this.ExemptApps);
            this.panel2.Controls.Add(this.OnOffButton);
            this.panel2.Controls.Add(this.ExemptTitle);
            this.panel2.Controls.Add(this.ScanButton);
            this.panel2.Controls.Add(this.MusicSelectionBox);
            this.panel2.Location = new System.Drawing.Point(12, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 294);
            this.panel2.TabIndex = 11;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.ForeColor = System.Drawing.Color.Snow;
            this.textBox4.Location = new System.Drawing.Point(50, 34);
            this.textBox4.Name = "textBox4";
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox4.Size = new System.Drawing.Size(104, 13);
            this.textBox4.TabIndex = 15;
            this.textBox4.Text = "Default Music Volume";
            // 
            // DefaultMusicVolume
            // 
            this.DefaultMusicVolume.Location = new System.Drawing.Point(160, 32);
            this.DefaultMusicVolume.Name = "DefaultMusicVolume";
            this.DefaultMusicVolume.Size = new System.Drawing.Size(43, 20);
            this.DefaultMusicVolume.TabIndex = 16;
            this.DefaultMusicVolume.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.DefaultMusicVolume.ValueChanged += new System.EventHandler(this.DefaultMusicVolume_ValueChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SettingsButton);
            this.panel3.Controls.Add(this.AboutButton);
            this.panel3.Location = new System.Drawing.Point(10, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(262, 22);
            this.panel3.TabIndex = 12;
            // 
            // PrimaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(285, 448);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PrimaryForm";
            this.Text = "Music Autocontroller";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveMusicVolume)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultMusicVolume)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OnOffButton;
        private System.Windows.Forms.ComboBox MusicSelectionBox;
        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.CheckedListBox ExemptApps;
        private System.Windows.Forms.TextBox ExemptTitle;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.CheckBox IsSelectedExempt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox DetailedAppTitle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown ActiveMusicVolume;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.NumericUpDown DefaultMusicVolume;
    }
}

