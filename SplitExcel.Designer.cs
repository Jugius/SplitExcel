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
            this.lblFileName = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNumberOfRows = new System.Windows.Forms.Label();
            this.lblNumberOfColumns = new System.Windows.Forms.Label();
            this.cmbSheets = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkShowNumbers = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSplitRowEnd = new System.Windows.Forms.TextBox();
            this.txtSplitRowBegin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSplitColumn = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSplitFounded = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.conMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuUseMultiThreads = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.conMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFileName.LinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblFileName.Location = new System.Drawing.Point(12, 7);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(105, 15);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.TabStop = true;
            this.lblFileName.Text = "Файл не открыт";
            this.lblFileName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenFile);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNumberOfRows);
            this.groupBox2.Controls.Add(this.lblNumberOfColumns);
            this.groupBox2.Controls.Add(this.cmbSheets);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(6, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 91);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Рабочая область";
            // 
            // lblNumberOfRows
            // 
            this.lblNumberOfRows.AutoSize = true;
            this.lblNumberOfRows.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumberOfRows.Location = new System.Drawing.Point(101, 68);
            this.lblNumberOfRows.Name = "lblNumberOfRows";
            this.lblNumberOfRows.Size = new System.Drawing.Size(42, 15);
            this.lblNumberOfRows.TabIndex = 5;
            this.lblNumberOfRows.Text = "Строк:";
            // 
            // lblNumberOfColumns
            // 
            this.lblNumberOfColumns.AutoSize = true;
            this.lblNumberOfColumns.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumberOfColumns.Location = new System.Drawing.Point(101, 47);
            this.lblNumberOfColumns.Name = "lblNumberOfColumns";
            this.lblNumberOfColumns.Size = new System.Drawing.Size(63, 15);
            this.lblNumberOfColumns.TabIndex = 4;
            this.lblNumberOfColumns.Text = "Столбцов:";
            // 
            // cmbSheets
            // 
            this.cmbSheets.DisplayMember = "Name";
            this.cmbSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSheets.Enabled = false;
            this.cmbSheets.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbSheets.FormattingEnabled = true;
            this.cmbSheets.Location = new System.Drawing.Point(104, 19);
            this.cmbSheets.Name = "cmbSheets";
            this.cmbSheets.Size = new System.Drawing.Size(171, 23);
            this.cmbSheets.TabIndex = 1;
            this.cmbSheets.ValueMember = "Index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Активный лист:";
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
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(6, 125);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(284, 111);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметры ";
            // 
            // chkShowNumbers
            // 
            this.chkShowNumbers.AutoSize = true;
            this.chkShowNumbers.Location = new System.Drawing.Point(191, 24);
            this.chkShowNumbers.Name = "chkShowNumbers";
            this.chkShowNumbers.Size = new System.Drawing.Size(32, 19);
            this.chkShowNumbers.TabIndex = 37;
            this.chkShowNumbers.Text = "#";
            this.chkShowNumbers.UseVisualStyleBackColor = true;
            this.chkShowNumbers.CheckedChanged += new System.EventHandler(this.chkShowNumbers_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(6, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 15);
            this.label5.TabIndex = 36;
            this.label5.Text = "Номер последней строки:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 15);
            this.label6.TabIndex = 35;
            this.label6.Text = "Номер первой строки со значениями:";
            // 
            // txtSplitRowEnd
            // 
            this.txtSplitRowEnd.Location = new System.Drawing.Point(229, 80);
            this.txtSplitRowEnd.Name = "txtSplitRowEnd";
            this.txtSplitRowEnd.Size = new System.Drawing.Size(46, 23);
            this.txtSplitRowEnd.TabIndex = 34;
            // 
            // txtSplitRowBegin
            // 
            this.txtSplitRowBegin.Location = new System.Drawing.Point(229, 51);
            this.txtSplitRowBegin.Name = "txtSplitRowBegin";
            this.txtSplitRowBegin.Size = new System.Drawing.Size(46, 23);
            this.txtSplitRowBegin.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Режем файл по столбцу:";
            // 
            // cmbSplitColumn
            // 
            this.cmbSplitColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSplitColumn.Enabled = false;
            this.cmbSplitColumn.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbSplitColumn.FormattingEnabled = true;
            this.cmbSplitColumn.Location = new System.Drawing.Point(229, 22);
            this.cmbSplitColumn.Name = "cmbSplitColumn";
            this.cmbSplitColumn.Size = new System.Drawing.Size(46, 23);
            this.cmbSplitColumn.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnStart);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.lblSplitFounded);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(6, 261);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(283, 76);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Обработка файла";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(200, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Начать";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 38;
            this.label1.Text = "Сохранено:";
            // 
            // lblSplitFounded
            // 
            this.lblSplitFounded.AutoSize = true;
            this.lblSplitFounded.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSplitFounded.Location = new System.Drawing.Point(6, 23);
            this.lblSplitFounded.Name = "lblSplitFounded";
            this.lblSplitFounded.Size = new System.Drawing.Size(121, 15);
            this.lblSplitFounded.TabIndex = 37;
            this.lblSplitFounded.Text = "Найдено вариантов:";
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(6, 242);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(284, 13);
            this.pbProgress.TabIndex = 5;
            // 
            // conMenu
            // 
            this.conMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenFile,
            this.toolStripSeparator2,
            this.mnuUseMultiThreads,
            this.toolStripSeparator1,
            this.mnuCheckUpdate,
            this.mnuAbout});
            this.conMenu.Name = "conMenu";
            this.conMenu.Size = new System.Drawing.Size(252, 104);
            // 
            // mnuOpenFile
            // 
            this.mnuOpenFile.Name = "mnuOpenFile";
            this.mnuOpenFile.Size = new System.Drawing.Size(251, 22);
            this.mnuOpenFile.Text = "Открыть файл";
            this.mnuOpenFile.Click += new System.EventHandler(this.OpenFile);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(248, 6);
            // 
            // mnuUseMultiThreads
            // 
            this.mnuUseMultiThreads.Checked = true;
            this.mnuUseMultiThreads.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuUseMultiThreads.Name = "mnuUseMultiThreads";
            this.mnuUseMultiThreads.Size = new System.Drawing.Size(251, 22);
            this.mnuUseMultiThreads.Text = "использовать многопоточность";
            this.mnuUseMultiThreads.Click += new System.EventHandler(this.mnuUseMultiThreads_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(248, 6);
            // 
            // mnuCheckUpdate
            // 
            this.mnuCheckUpdate.Name = "mnuCheckUpdate";
            this.mnuCheckUpdate.Size = new System.Drawing.Size(251, 22);
            this.mnuCheckUpdate.Text = "Проверить обновления";
            this.mnuCheckUpdate.Click += new System.EventHandler(this.mnuCheckUpdate_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(251, 22);
            this.mnuAbout.Text = "О программе";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // SplitExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(298, 342);
            this.ContextMenuStrip = this.conMenu;
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblFileName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplitExcel";
            this.Text = "SplitExcel";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.SplitExcel_HelpButtonClicked);
            this.Shown += new System.EventHandler(this.SplitExcel_Shown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.conMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblNumberOfRows;
        private System.Windows.Forms.Label lblNumberOfColumns;
        private System.Windows.Forms.ComboBox cmbSheets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lblFileName;
        private System.Windows.Forms.TextBox txtSplitRowBegin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSplitColumn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSplitRowEnd;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSplitFounded;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chkShowNumbers;
        private System.Windows.Forms.ContextMenuStrip conMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuUseMultiThreads;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuCheckUpdate;
    }
}