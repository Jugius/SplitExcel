namespace SplitExcel
{
    partial class SplitExcel
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkShowNumbers = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSplitRowEnd = new System.Windows.Forms.TextBox();
            this.txtSplitRowBegin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSplitColumn = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFileName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNumberOfRows = new System.Windows.Forms.Label();
            this.lblNumberOfColumns = new System.Windows.Forms.Label();
            this.cmbSheets = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.mnuSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuUseMultiThreads = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mnuAbout = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSendLetter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuShowAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCheckUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.mnuSettings.SuspendLayout();
            this.mnuAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkShowNumbers);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtSplitRowEnd);
            this.groupBox3.Controls.Add(this.txtSplitRowBegin);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cmbSplitColumn);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.groupBox3.Location = new System.Drawing.Point(5, 151);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(291, 111);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметры ";
            // 
            // chkShowNumbers
            // 
            this.chkShowNumbers.AutoSize = true;
            this.chkShowNumbers.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkShowNumbers.Location = new System.Drawing.Point(190, 19);
            this.chkShowNumbers.Name = "chkShowNumbers";
            this.chkShowNumbers.Size = new System.Drawing.Size(35, 21);
            this.chkShowNumbers.TabIndex = 37;
            this.chkShowNumbers.Text = "#";
            this.chkShowNumbers.UseVisualStyleBackColor = true;
            this.chkShowNumbers.CheckedChanged += new System.EventHandler(this.chkShowNumbers_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label5.Location = new System.Drawing.Point(6, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 17);
            this.label5.TabIndex = 36;
            this.label5.Text = "Завершить чтение на строке:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label6.Location = new System.Drawing.Point(6, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 17);
            this.label6.TabIndex = 35;
            this.label6.Text = "Начать чтение со строки:";
            // 
            // txtSplitRowEnd
            // 
            this.txtSplitRowEnd.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSplitRowEnd.Location = new System.Drawing.Point(231, 79);
            this.txtSplitRowEnd.Name = "txtSplitRowEnd";
            this.txtSplitRowEnd.Size = new System.Drawing.Size(52, 25);
            this.txtSplitRowEnd.TabIndex = 34;
            // 
            // txtSplitRowBegin
            // 
            this.txtSplitRowBegin.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSplitRowBegin.Location = new System.Drawing.Point(231, 48);
            this.txtSplitRowBegin.Name = "txtSplitRowBegin";
            this.txtSplitRowBegin.Size = new System.Drawing.Size(52, 25);
            this.txtSplitRowBegin.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Режем файл по столбцу:";
            // 
            // cmbSplitColumn
            // 
            this.cmbSplitColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSplitColumn.Enabled = false;
            this.cmbSplitColumn.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSplitColumn.FormattingEnabled = true;
            this.cmbSplitColumn.Location = new System.Drawing.Point(231, 17);
            this.cmbSplitColumn.Name = "cmbSplitColumn";
            this.cmbSplitColumn.Size = new System.Drawing.Size(52, 25);
            this.cmbSplitColumn.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblStatus);
            this.groupBox4.Controls.Add(this.pbProgress);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.groupBox4.Location = new System.Drawing.Point(5, 262);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(291, 68);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Обработка файла";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblStatus.Location = new System.Drawing.Point(6, 27);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(87, 17);
            this.lblStatus.TabIndex = 38;
            this.lblStatus.Text = "Обработано:";
            // 
            // pbProgress
            // 
            this.pbProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbProgress.Location = new System.Drawing.Point(3, 52);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(285, 13);
            this.pbProgress.TabIndex = 5;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnStart.Location = new System.Drawing.Point(213, 334);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 26);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Начать";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblFileName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 27);
            this.panel1.TabIndex = 47;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFileName.Location = new System.Drawing.Point(3, 5);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(43, 17);
            this.lblFileName.TabIndex = 39;
            this.lblFileName.Text = "label7";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNumberOfRows);
            this.groupBox1.Controls.Add(this.lblNumberOfColumns);
            this.groupBox1.Controls.Add(this.cmbSheets);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(5, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 92);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Рабочая область";
            // 
            // lblNumberOfRows
            // 
            this.lblNumberOfRows.AutoSize = true;
            this.lblNumberOfRows.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblNumberOfRows.Location = new System.Drawing.Point(109, 71);
            this.lblNumberOfRows.Name = "lblNumberOfRows";
            this.lblNumberOfRows.Size = new System.Drawing.Size(46, 17);
            this.lblNumberOfRows.TabIndex = 9;
            this.lblNumberOfRows.Text = "Строк:";
            // 
            // lblNumberOfColumns
            // 
            this.lblNumberOfColumns.AutoSize = true;
            this.lblNumberOfColumns.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblNumberOfColumns.Location = new System.Drawing.Point(109, 48);
            this.lblNumberOfColumns.Name = "lblNumberOfColumns";
            this.lblNumberOfColumns.Size = new System.Drawing.Size(69, 17);
            this.lblNumberOfColumns.TabIndex = 8;
            this.lblNumberOfColumns.Text = "Столбцов:";
            // 
            // cmbSheets
            // 
            this.cmbSheets.DisplayMember = "Name";
            this.cmbSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSheets.Enabled = false;
            this.cmbSheets.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSheets.FormattingEnabled = true;
            this.cmbSheets.Location = new System.Drawing.Point(112, 22);
            this.cmbSheets.Name = "cmbSheets";
            this.cmbSheets.Size = new System.Drawing.Size(171, 25);
            this.cmbSheets.TabIndex = 6;
            this.toolTip.SetToolTip(this.cmbSheets, "Выберите лист");
            this.cmbSheets.ValueMember = "Index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Активный лист:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSettings);
            this.panel2.Controls.Add(this.btnAbout);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnOpenFile);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(1);
            this.panel2.Size = new System.Drawing.Size(291, 32);
            this.panel2.TabIndex = 51;
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Image = global::SplitExcel.Properties.Resources.preferences_icon_24;
            this.btnSettings.Location = new System.Drawing.Point(230, 1);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(30, 30);
            this.btnSettings.TabIndex = 4;
            this.toolTip.SetToolTip(this.btnSettings, "Настройки");
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSettings_MouseDown);
            // 
            // btnAbout
            // 
            this.btnAbout.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Image = global::SplitExcel.Properties.Resources.information_icon_24;
            this.btnAbout.Location = new System.Drawing.Point(260, 1);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(30, 30);
            this.btnAbout.TabIndex = 3;
            this.toolTip.SetToolTip(this.btnAbout, "О программе");
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAbout_MouseDown);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::SplitExcel.Properties.Resources.refresh_icon_24;
            this.btnRefresh.Location = new System.Drawing.Point(31, 1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(30, 30);
            this.btnRefresh.TabIndex = 1;
            this.toolTip.SetToolTip(this.btnRefresh, "Перезагрузить информацию о файле");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOpenFile.FlatAppearance.BorderSize = 0;
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.Image = global::SplitExcel.Properties.Resources.open_file_icon_24;
            this.btnOpenFile.Location = new System.Drawing.Point(1, 1);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(30, 30);
            this.btnOpenFile.TabIndex = 0;
            this.toolTip.SetToolTip(this.btnOpenFile, "Открыть файл");
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.OpenFile);
            // 
            // mnuSettings
            // 
            this.mnuSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUseMultiThreads});
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(254, 26);
            // 
            // mnuUseMultiThreads
            // 
            this.mnuUseMultiThreads.Name = "mnuUseMultiThreads";
            this.mnuUseMultiThreads.Size = new System.Drawing.Size(253, 22);
            this.mnuUseMultiThreads.Text = "Использовать многопоточность";
            this.mnuUseMultiThreads.ToolTipText = "Режет файл в несколько потоков, ускоряя процесс.\r\nИногда вызывает ошибку.\r\nРекоме" +
    "ндуется использовать с большими файлами.";
            this.mnuUseMultiThreads.Click += new System.EventHandler(this.mnuUseMultiThreads_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelp,
            this.mnuSendLetter,
            this.mnuCheckUpdates,
            this.toolStripSeparator1,
            this.mnuShowAbout});
            this.mnuAbout.Name = "mnuSettings";
            this.mnuAbout.Size = new System.Drawing.Size(205, 120);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(204, 22);
            this.mnuHelp.Text = "Справка";
            this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
            // 
            // mnuSendLetter
            // 
            this.mnuSendLetter.Name = "mnuSendLetter";
            this.mnuSendLetter.Size = new System.Drawing.Size(204, 22);
            this.mnuSendLetter.Text = "Обратная связь";
            this.mnuSendLetter.Click += new System.EventHandler(this.mnuSendLetter_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // mnuShowAbout
            // 
            this.mnuShowAbout.Name = "mnuShowAbout";
            this.mnuShowAbout.Size = new System.Drawing.Size(204, 22);
            this.mnuShowAbout.Text = "О программе";
            this.mnuShowAbout.Click += new System.EventHandler(this.mnuShowAbout_Click);
            // 
            // mnuCheckUpdates
            // 
            this.mnuCheckUpdates.Name = "mnuCheckUpdates";
            this.mnuCheckUpdates.Size = new System.Drawing.Size(204, 22);
            this.mnuCheckUpdates.Text = "Проверить обновления";
            this.mnuCheckUpdates.Click += new System.EventHandler(this.MnuCheckUpdates_Click);
            // 
            // SplitExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(301, 371);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplitExcel";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplitExcel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SplitExcel_FormClosing);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.mnuSettings.ResumeLayout(false);
            this.mnuAbout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSplitRowBegin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSplitColumn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSplitRowEnd;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chkShowNumbers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNumberOfRows;
        private System.Windows.Forms.Label lblNumberOfColumns;
        private System.Windows.Forms.ComboBox cmbSheets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.ContextMenuStrip mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuUseMultiThreads;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuSendLetter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuShowAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuCheckUpdates;
    }
}