namespace VolumeChanger
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            label1 = new Label();
            UpdateTimer = new System.Windows.Forms.Timer(components);
            label2 = new Label();
            UpdateFrequencyNud = new NumericUpDown();
            SwitchButton = new Button();
            DevicesComboBox = new ComboBox();
            wantedVolumeNud = new NumericUpDown();
            label3 = new Label();
            groupBox1 = new GroupBox();
            StartWithWindows_Checkbox = new CheckBox();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            OpenWindow_toolStripMenuItem = new ToolStripMenuItem();
            StartWithWindows_toolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            Exit_toolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)UpdateFrequencyNud).BeginInit();
            ((System.ComponentModel.ISupportInitialize)wantedVolumeNud).BeginInit();
            groupBox1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 2;
            label1.Text = "Input Devices";
            // 
            // UpdateTimer
            // 
            UpdateTimer.Tick += UpdateTimer_Tick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(130, 15);
            label2.TabIndex = 3;
            label2.Text = "Update Frequency (ms)";
            // 
            // UpdateFrequencyNud
            // 
            UpdateFrequencyNud.Location = new Point(6, 37);
            UpdateFrequencyNud.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UpdateFrequencyNud.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            UpdateFrequencyNud.Name = "UpdateFrequencyNud";
            UpdateFrequencyNud.Size = new Size(120, 23);
            UpdateFrequencyNud.TabIndex = 4;
            UpdateFrequencyNud.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            UpdateFrequencyNud.ValueChanged += UpdateFrequencyNud_ValueChanged;
            // 
            // SwitchButton
            // 
            SwitchButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SwitchButton.Location = new Point(264, 206);
            SwitchButton.Name = "SwitchButton";
            SwitchButton.Size = new Size(142, 23);
            SwitchButton.TabIndex = 5;
            SwitchButton.Text = "Start Changing Volume";
            SwitchButton.UseVisualStyleBackColor = true;
            SwitchButton.Click += SwitchUpdate_Click;
            // 
            // DevicesComboBox
            // 
            DevicesComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DevicesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DevicesComboBox.FormattingEnabled = true;
            DevicesComboBox.Location = new Point(12, 27);
            DevicesComboBox.Name = "DevicesComboBox";
            DevicesComboBox.Size = new Size(394, 23);
            DevicesComboBox.TabIndex = 6;
            // 
            // wantedVolumeNud
            // 
            wantedVolumeNud.Location = new Point(6, 81);
            wantedVolumeNud.Name = "wantedVolumeNud";
            wantedVolumeNud.Size = new Size(120, 23);
            wantedVolumeNud.TabIndex = 7;
            wantedVolumeNud.Value = new decimal(new int[] { 100, 0, 0, 0 });
            wantedVolumeNud.ValueChanged += WantedVolumeNud_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 63);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 8;
            label3.Text = "Wanted Volume";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(StartWithWindows_Checkbox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(wantedVolumeNud);
            groupBox1.Controls.Add(UpdateFrequencyNud);
            groupBox1.Location = new Point(12, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(394, 140);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Options";
            // 
            // StartWithWindows_Checkbox
            // 
            StartWithWindows_Checkbox.AutoSize = true;
            StartWithWindows_Checkbox.Location = new Point(6, 110);
            StartWithWindows_Checkbox.Name = "StartWithWindows_Checkbox";
            StartWithWindows_Checkbox.Size = new Size(165, 19);
            StartWithWindows_Checkbox.TabIndex = 9;
            StartWithWindows_Checkbox.Text = "Always start with windows";
            StartWithWindows_Checkbox.UseVisualStyleBackColor = true;
            StartWithWindows_Checkbox.CheckedChanged += StartWithWindows_Checkbox_CheckedChanged;
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Volume Changer";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += NotifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { OpenWindow_toolStripMenuItem, StartWithWindows_toolStripMenuItem, toolStripSeparator1, Exit_toolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(177, 76);
            // 
            // OpenWindow_toolStripMenuItem
            // 
            OpenWindow_toolStripMenuItem.Name = "OpenWindow_toolStripMenuItem";
            OpenWindow_toolStripMenuItem.Size = new Size(176, 22);
            OpenWindow_toolStripMenuItem.Text = "&Open";
            OpenWindow_toolStripMenuItem.Click += OpenWindow_toolStripMenuItem_Click;
            // 
            // StartWithWindows_toolStripMenuItem
            // 
            StartWithWindows_toolStripMenuItem.Name = "StartWithWindows_toolStripMenuItem";
            StartWithWindows_toolStripMenuItem.Size = new Size(176, 22);
            StartWithWindows_toolStripMenuItem.Text = "Start with Windows";
            StartWithWindows_toolStripMenuItem.Click += StartWithWindowsMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(173, 6);
            // 
            // Exit_toolStripMenuItem
            // 
            Exit_toolStripMenuItem.Name = "Exit_toolStripMenuItem";
            Exit_toolStripMenuItem.Size = new Size(176, 22);
            Exit_toolStripMenuItem.Text = "E&xit";
            Exit_toolStripMenuItem.Click += Exit_toolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 242);
            Controls.Add(groupBox1);
            Controls.Add(DevicesComboBox);
            Controls.Add(SwitchButton);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(300, 270);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Volume Changer";
            Load += OnFormLoad;
            ((System.ComponentModel.ISupportInitialize)UpdateFrequencyNud).EndInit();
            ((System.ComponentModel.ISupportInitialize)wantedVolumeNud).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private System.Windows.Forms.Timer UpdateTimer;
        private Label label2;
        private NumericUpDown UpdateFrequencyNud;
        private Button SwitchButton;
        private ComboBox DevicesComboBox;
        private NumericUpDown wantedVolumeNud;
        private Label label3;
        private GroupBox groupBox1;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem OpenWindow_toolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem Exit_toolStripMenuItem;
        private ToolStripMenuItem StartWithWindows_toolStripMenuItem;
        private CheckBox StartWithWindows_Checkbox;
    }
}
