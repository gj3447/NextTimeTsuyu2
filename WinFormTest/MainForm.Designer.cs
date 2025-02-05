namespace WinFormTest
{
    partial class MainForm
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
            btnPanelChangeCopy = new Button();
            btnPanelChangeFileSync = new Button();
            btnPanelChangeFolderBackup = new Button();
            pnlFileSync = new Panel();
            btnFileSyncSyncLoadFileSystem = new Button();
            btnFileSyncTargetLoadFileSystem = new Button();
            lblFileSyncStatus = new Label();
            lblFileSyncArrow = new Label();
            txbFileSyncSyncPath = new TextBox();
            txbFileSyncTargetPath = new TextBox();
            btnFileSyncAdd = new Button();
            lstvFileSync = new ListView();
            btnFileSyncSync = new Button();
            btnFileSyncChange = new Button();
            btnFileSyncCopy = new Button();
            pnlFolderBackup = new Panel();
            ckbFolderBackupRun = new CheckBox();
            ckbFolderBackupSun = new CheckBox();
            ckbFolderBackupSat = new CheckBox();
            ckbFolderBackupFri = new CheckBox();
            ckbFolderBackupThu = new CheckBox();
            ckbFolderBackupWed = new CheckBox();
            ckbFolderBackupTue = new CheckBox();
            ckbFolderBackupMon = new CheckBox();
            lblFolderBackupBackup = new Label();
            lblFolderBackupTarget = new Label();
            btnFolderBackupLoadFileSystem = new Button();
            btnFolderBackupRestore = new Button();
            btnFolderBackupCopy = new Button();
            txbFolderBackupBackupPath = new TextBox();
            txbFolderBackupTargetPath = new TextBox();
            btnFolderBackupAdd = new Button();
            lstvFolderBackupBackup = new ListView();
            lstvFolderBackupTarget = new ListView();
            pnlCopy = new Panel();
            lblCopyStatus = new Label();
            pgbCopy = new ProgressBar();
            btnCopyCopy = new Button();
            lblCopyTo = new Label();
            lblCopyFrom = new Label();
            trvCopyTo = new TreeView();
            btnCopyToLoadFileSystem = new Button();
            btnCopyFromLoadFileSystem = new Button();
            txbCopyToPath = new TextBox();
            trvCopyFrom = new TreeView();
            txbCopyFromPath = new TextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadsettingfileToolStripMenuItem = new ToolStripMenuItem();
            writesettingfileToolStripMenuItem = new ToolStripMenuItem();
            settingToolStripMenuItem = new ToolStripMenuItem();
            pnlFileSync.SuspendLayout();
            pnlFolderBackup.SuspendLayout();
            pnlCopy.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnPanelChangeCopy
            // 
            btnPanelChangeCopy.Location = new Point(0, 474);
            btnPanelChangeCopy.Name = "btnPanelChangeCopy";
            btnPanelChangeCopy.Size = new Size(108, 30);
            btnPanelChangeCopy.TabIndex = 0;
            btnPanelChangeCopy.Text = "Copy";
            btnPanelChangeCopy.UseVisualStyleBackColor = true;
            btnPanelChangeCopy.Click += btnPanelChangeCopy_Click;
            // 
            // btnPanelChangeFileSync
            // 
            btnPanelChangeFileSync.Location = new Point(114, 474);
            btnPanelChangeFileSync.Name = "btnPanelChangeFileSync";
            btnPanelChangeFileSync.Size = new Size(108, 30);
            btnPanelChangeFileSync.TabIndex = 1;
            btnPanelChangeFileSync.Text = "FIleSync";
            btnPanelChangeFileSync.UseVisualStyleBackColor = true;
            btnPanelChangeFileSync.Click += btnPanelChangeFileSync_Click;
            // 
            // btnPanelChangeFolderBackup
            // 
            btnPanelChangeFolderBackup.Location = new Point(228, 474);
            btnPanelChangeFolderBackup.Name = "btnPanelChangeFolderBackup";
            btnPanelChangeFolderBackup.Size = new Size(109, 30);
            btnPanelChangeFolderBackup.TabIndex = 2;
            btnPanelChangeFolderBackup.Text = "FolderBackup";
            btnPanelChangeFolderBackup.UseVisualStyleBackColor = true;
            btnPanelChangeFolderBackup.Click += btnPanelChangeFolderBackup_Click;
            // 
            // pnlFileSync
            // 
            pnlFileSync.Controls.Add(btnFileSyncSyncLoadFileSystem);
            pnlFileSync.Controls.Add(btnFileSyncTargetLoadFileSystem);
            pnlFileSync.Controls.Add(lblFileSyncStatus);
            pnlFileSync.Controls.Add(lblFileSyncArrow);
            pnlFileSync.Controls.Add(txbFileSyncSyncPath);
            pnlFileSync.Controls.Add(txbFileSyncTargetPath);
            pnlFileSync.Controls.Add(btnFileSyncAdd);
            pnlFileSync.Controls.Add(lstvFileSync);
            pnlFileSync.Controls.Add(btnFileSyncSync);
            pnlFileSync.Controls.Add(btnFileSyncChange);
            pnlFileSync.Controls.Add(btnFileSyncCopy);
            pnlFileSync.Location = new Point(12, 27);
            pnlFileSync.Name = "pnlFileSync";
            pnlFileSync.Size = new Size(438, 441);
            pnlFileSync.TabIndex = 3;
            // 
            // btnFileSyncSyncLoadFileSystem
            // 
            btnFileSyncSyncLoadFileSystem.Location = new Point(411, 6);
            btnFileSyncSyncLoadFileSystem.Name = "btnFileSyncSyncLoadFileSystem";
            btnFileSyncSyncLoadFileSystem.Size = new Size(21, 23);
            btnFileSyncSyncLoadFileSystem.TabIndex = 13;
            btnFileSyncSyncLoadFileSystem.Text = "..";
            btnFileSyncSyncLoadFileSystem.UseVisualStyleBackColor = true;
            // 
            // btnFileSyncTargetLoadFileSystem
            // 
            btnFileSyncTargetLoadFileSystem.Location = new Point(177, 4);
            btnFileSyncTargetLoadFileSystem.Name = "btnFileSyncTargetLoadFileSystem";
            btnFileSyncTargetLoadFileSystem.Size = new Size(21, 23);
            btnFileSyncTargetLoadFileSystem.TabIndex = 11;
            btnFileSyncTargetLoadFileSystem.Text = "..";
            btnFileSyncTargetLoadFileSystem.UseVisualStyleBackColor = true;
            // 
            // lblFileSyncStatus
            // 
            lblFileSyncStatus.AutoSize = true;
            lblFileSyncStatus.Location = new Point(360, 413);
            lblFileSyncStatus.Name = "lblFileSyncStatus";
            lblFileSyncStatus.Size = new Size(59, 15);
            lblFileSyncStatus.TabIndex = 10;
            lblFileSyncStatus.Text = "Sync : off";
            // 
            // lblFileSyncArrow
            // 
            lblFileSyncArrow.AutoSize = true;
            lblFileSyncArrow.Location = new Point(204, 6);
            lblFileSyncArrow.Name = "lblFileSyncArrow";
            lblFileSyncArrow.Size = new Size(23, 15);
            lblFileSyncArrow.TabIndex = 9;
            lblFileSyncArrow.Text = ">>";
            // 
            // txbFileSyncSyncPath
            // 
            txbFileSyncSyncPath.Location = new Point(233, 3);
            txbFileSyncSyncPath.Name = "txbFileSyncSyncPath";
            txbFileSyncSyncPath.Size = new Size(172, 23);
            txbFileSyncSyncPath.TabIndex = 8;
            // 
            // txbFileSyncTargetPath
            // 
            txbFileSyncTargetPath.Location = new Point(5, 3);
            txbFileSyncTargetPath.Name = "txbFileSyncTargetPath";
            txbFileSyncTargetPath.Size = new Size(172, 23);
            txbFileSyncTargetPath.TabIndex = 7;
            // 
            // btnFileSyncAdd
            // 
            btnFileSyncAdd.Location = new Point(360, 36);
            btnFileSyncAdd.Name = "btnFileSyncAdd";
            btnFileSyncAdd.Size = new Size(72, 37);
            btnFileSyncAdd.TabIndex = 6;
            btnFileSyncAdd.Text = "Add";
            btnFileSyncAdd.UseVisualStyleBackColor = true;
            // 
            // lstvFileSync
            // 
            lstvFileSync.Location = new Point(8, 36);
            lstvFileSync.Name = "lstvFileSync";
            lstvFileSync.Size = new Size(346, 402);
            lstvFileSync.TabIndex = 4;
            lstvFileSync.UseCompatibleStateImageBehavior = false;
            // 
            // btnFileSyncSync
            // 
            btnFileSyncSync.Location = new Point(360, 362);
            btnFileSyncSync.Name = "btnFileSyncSync";
            btnFileSyncSync.Size = new Size(72, 36);
            btnFileSyncSync.TabIndex = 3;
            btnFileSyncSync.Text = "Sync";
            btnFileSyncSync.UseVisualStyleBackColor = true;
            // 
            // btnFileSyncChange
            // 
            btnFileSyncChange.Location = new Point(360, 317);
            btnFileSyncChange.Name = "btnFileSyncChange";
            btnFileSyncChange.Size = new Size(72, 39);
            btnFileSyncChange.TabIndex = 2;
            btnFileSyncChange.Text = "Change";
            btnFileSyncChange.UseVisualStyleBackColor = true;
            // 
            // btnFileSyncCopy
            // 
            btnFileSyncCopy.Location = new Point(360, 274);
            btnFileSyncCopy.Name = "btnFileSyncCopy";
            btnFileSyncCopy.Size = new Size(72, 37);
            btnFileSyncCopy.TabIndex = 1;
            btnFileSyncCopy.Text = "Copy";
            btnFileSyncCopy.UseVisualStyleBackColor = true;
            // 
            // pnlFolderBackup
            // 
            pnlFolderBackup.Controls.Add(ckbFolderBackupRun);
            pnlFolderBackup.Controls.Add(ckbFolderBackupSun);
            pnlFolderBackup.Controls.Add(ckbFolderBackupSat);
            pnlFolderBackup.Controls.Add(ckbFolderBackupFri);
            pnlFolderBackup.Controls.Add(ckbFolderBackupThu);
            pnlFolderBackup.Controls.Add(ckbFolderBackupWed);
            pnlFolderBackup.Controls.Add(ckbFolderBackupTue);
            pnlFolderBackup.Controls.Add(ckbFolderBackupMon);
            pnlFolderBackup.Controls.Add(lblFolderBackupBackup);
            pnlFolderBackup.Controls.Add(lblFolderBackupTarget);
            pnlFolderBackup.Controls.Add(btnFolderBackupLoadFileSystem);
            pnlFolderBackup.Controls.Add(btnFolderBackupRestore);
            pnlFolderBackup.Controls.Add(btnFolderBackupCopy);
            pnlFolderBackup.Controls.Add(txbFolderBackupBackupPath);
            pnlFolderBackup.Controls.Add(txbFolderBackupTargetPath);
            pnlFolderBackup.Controls.Add(btnFolderBackupAdd);
            pnlFolderBackup.Controls.Add(lstvFolderBackupBackup);
            pnlFolderBackup.Controls.Add(lstvFolderBackupTarget);
            pnlFolderBackup.Location = new Point(456, 27);
            pnlFolderBackup.Name = "pnlFolderBackup";
            pnlFolderBackup.Size = new Size(438, 441);
            pnlFolderBackup.TabIndex = 4;
            // 
            // ckbFolderBackupRun
            // 
            ckbFolderBackupRun.AutoSize = true;
            ckbFolderBackupRun.Location = new Point(365, 289);
            ckbFolderBackupRun.Name = "ckbFolderBackupRun";
            ckbFolderBackupRun.Size = new Size(50, 19);
            ckbFolderBackupRun.TabIndex = 24;
            ckbFolderBackupRun.Text = "RUN";
            ckbFolderBackupRun.UseVisualStyleBackColor = true;
            // 
            // ckbFolderBackupSun
            // 
            ckbFolderBackupSun.AutoSize = true;
            ckbFolderBackupSun.Location = new Point(366, 241);
            ckbFolderBackupSun.Name = "ckbFolderBackupSun";
            ckbFolderBackupSun.Size = new Size(50, 19);
            ckbFolderBackupSun.TabIndex = 23;
            ckbFolderBackupSun.Text = "SUN";
            ckbFolderBackupSun.UseVisualStyleBackColor = true;
            // 
            // ckbFolderBackupSat
            // 
            ckbFolderBackupSat.AutoSize = true;
            ckbFolderBackupSat.Location = new Point(366, 216);
            ckbFolderBackupSat.Name = "ckbFolderBackupSat";
            ckbFolderBackupSat.Size = new Size(47, 19);
            ckbFolderBackupSat.TabIndex = 22;
            ckbFolderBackupSat.Text = "SAT";
            ckbFolderBackupSat.UseVisualStyleBackColor = true;
            // 
            // ckbFolderBackupFri
            // 
            ckbFolderBackupFri.AutoSize = true;
            ckbFolderBackupFri.Location = new Point(366, 191);
            ckbFolderBackupFri.Name = "ckbFolderBackupFri";
            ckbFolderBackupFri.Size = new Size(42, 19);
            ckbFolderBackupFri.TabIndex = 21;
            ckbFolderBackupFri.Text = "FRI";
            ckbFolderBackupFri.UseVisualStyleBackColor = true;
            // 
            // ckbFolderBackupThu
            // 
            ckbFolderBackupThu.AutoSize = true;
            ckbFolderBackupThu.Location = new Point(366, 166);
            ckbFolderBackupThu.Name = "ckbFolderBackupThu";
            ckbFolderBackupThu.Size = new Size(49, 19);
            ckbFolderBackupThu.TabIndex = 20;
            ckbFolderBackupThu.Text = "THU";
            ckbFolderBackupThu.UseVisualStyleBackColor = true;
            // 
            // ckbFolderBackupWed
            // 
            ckbFolderBackupWed.AutoSize = true;
            ckbFolderBackupWed.Location = new Point(366, 141);
            ckbFolderBackupWed.Name = "ckbFolderBackupWed";
            ckbFolderBackupWed.Size = new Size(52, 19);
            ckbFolderBackupWed.TabIndex = 19;
            ckbFolderBackupWed.Text = "WED";
            ckbFolderBackupWed.UseVisualStyleBackColor = true;
            // 
            // ckbFolderBackupTue
            // 
            ckbFolderBackupTue.AutoSize = true;
            ckbFolderBackupTue.Location = new Point(366, 116);
            ckbFolderBackupTue.Name = "ckbFolderBackupTue";
            ckbFolderBackupTue.Size = new Size(46, 19);
            ckbFolderBackupTue.TabIndex = 18;
            ckbFolderBackupTue.Text = "TUE";
            ckbFolderBackupTue.UseVisualStyleBackColor = true;
            // 
            // ckbFolderBackupMon
            // 
            ckbFolderBackupMon.AutoSize = true;
            ckbFolderBackupMon.Location = new Point(366, 91);
            ckbFolderBackupMon.Name = "ckbFolderBackupMon";
            ckbFolderBackupMon.Size = new Size(55, 19);
            ckbFolderBackupMon.TabIndex = 17;
            ckbFolderBackupMon.Text = "MON";
            ckbFolderBackupMon.UseVisualStyleBackColor = true;
            // 
            // lblFolderBackupBackup
            // 
            lblFolderBackupBackup.AutoSize = true;
            lblFolderBackupBackup.Location = new Point(10, 226);
            lblFolderBackupBackup.Name = "lblFolderBackupBackup";
            lblFolderBackupBackup.Size = new Size(49, 15);
            lblFolderBackupBackup.TabIndex = 16;
            lblFolderBackupBackup.Text = "backup:";
            // 
            // lblFolderBackupTarget
            // 
            lblFolderBackupTarget.AutoSize = true;
            lblFolderBackupTarget.Location = new Point(9, 8);
            lblFolderBackupTarget.Name = "lblFolderBackupTarget";
            lblFolderBackupTarget.Size = new Size(41, 15);
            lblFolderBackupTarget.TabIndex = 15;
            lblFolderBackupTarget.Text = "target:";
            // 
            // btnFolderBackupLoadFileSystem
            // 
            btnFolderBackupLoadFileSystem.Location = new Point(366, 4);
            btnFolderBackupLoadFileSystem.Name = "btnFolderBackupLoadFileSystem";
            btnFolderBackupLoadFileSystem.Size = new Size(21, 23);
            btnFolderBackupLoadFileSystem.TabIndex = 14;
            btnFolderBackupLoadFileSystem.Text = "..";
            btnFolderBackupLoadFileSystem.UseVisualStyleBackColor = true;
            // 
            // btnFolderBackupRestore
            // 
            btnFolderBackupRestore.Location = new Point(363, 396);
            btnFolderBackupRestore.Name = "btnFolderBackupRestore";
            btnFolderBackupRestore.Size = new Size(72, 38);
            btnFolderBackupRestore.TabIndex = 9;
            btnFolderBackupRestore.Text = "Restore";
            btnFolderBackupRestore.UseVisualStyleBackColor = true;
            // 
            // btnFolderBackupCopy
            // 
            btnFolderBackupCopy.Location = new Point(363, 352);
            btnFolderBackupCopy.Name = "btnFolderBackupCopy";
            btnFolderBackupCopy.Size = new Size(72, 37);
            btnFolderBackupCopy.TabIndex = 8;
            btnFolderBackupCopy.Text = "Copy";
            btnFolderBackupCopy.UseVisualStyleBackColor = true;
            // 
            // txbFolderBackupBackupPath
            // 
            txbFolderBackupBackupPath.Location = new Point(65, 223);
            txbFolderBackupBackupPath.Name = "txbFolderBackupBackupPath";
            txbFolderBackupBackupPath.Size = new Size(294, 23);
            txbFolderBackupBackupPath.TabIndex = 7;
            // 
            // txbFolderBackupTargetPath
            // 
            txbFolderBackupTargetPath.Location = new Point(57, 4);
            txbFolderBackupTargetPath.Name = "txbFolderBackupTargetPath";
            txbFolderBackupTargetPath.Size = new Size(302, 23);
            txbFolderBackupTargetPath.TabIndex = 6;
            // 
            // btnFolderBackupAdd
            // 
            btnFolderBackupAdd.Location = new Point(366, 36);
            btnFolderBackupAdd.Name = "btnFolderBackupAdd";
            btnFolderBackupAdd.Size = new Size(69, 39);
            btnFolderBackupAdd.TabIndex = 5;
            btnFolderBackupAdd.Text = "Add";
            btnFolderBackupAdd.UseVisualStyleBackColor = true;
            // 
            // lstvFolderBackupBackup
            // 
            lstvFolderBackupBackup.Location = new Point(8, 252);
            lstvFolderBackupBackup.Name = "lstvFolderBackupBackup";
            lstvFolderBackupBackup.Size = new Size(351, 183);
            lstvFolderBackupBackup.TabIndex = 1;
            lstvFolderBackupBackup.UseCompatibleStateImageBehavior = false;
            // 
            // lstvFolderBackupTarget
            // 
            lstvFolderBackupTarget.Location = new Point(8, 34);
            lstvFolderBackupTarget.Name = "lstvFolderBackupTarget";
            lstvFolderBackupTarget.Size = new Size(351, 183);
            lstvFolderBackupTarget.TabIndex = 0;
            lstvFolderBackupTarget.UseCompatibleStateImageBehavior = false;
            // 
            // pnlCopy
            // 
            pnlCopy.Controls.Add(lblCopyStatus);
            pnlCopy.Controls.Add(pgbCopy);
            pnlCopy.Controls.Add(btnCopyCopy);
            pnlCopy.Controls.Add(lblCopyTo);
            pnlCopy.Controls.Add(lblCopyFrom);
            pnlCopy.Controls.Add(trvCopyTo);
            pnlCopy.Controls.Add(btnCopyToLoadFileSystem);
            pnlCopy.Controls.Add(btnCopyFromLoadFileSystem);
            pnlCopy.Controls.Add(txbCopyToPath);
            pnlCopy.Controls.Add(trvCopyFrom);
            pnlCopy.Controls.Add(txbCopyFromPath);
            pnlCopy.Location = new Point(900, 27);
            pnlCopy.Name = "pnlCopy";
            pnlCopy.Size = new Size(438, 441);
            pnlCopy.TabIndex = 4;
            // 
            // lblCopyStatus
            // 
            lblCopyStatus.AutoSize = true;
            lblCopyStatus.Location = new Point(120, 203);
            lblCopyStatus.Name = "lblCopyStatus";
            lblCopyStatus.Size = new Size(38, 15);
            lblCopyStatus.TabIndex = 31;
            lblCopyStatus.Text = "status";
            // 
            // pgbCopy
            // 
            pgbCopy.Location = new Point(121, 230);
            pgbCopy.Name = "pgbCopy";
            pgbCopy.Size = new Size(318, 22);
            pgbCopy.TabIndex = 30;
            // 
            // btnCopyCopy
            // 
            btnCopyCopy.Location = new Point(13, 194);
            btnCopyCopy.Name = "btnCopyCopy";
            btnCopyCopy.Size = new Size(90, 58);
            btnCopyCopy.TabIndex = 29;
            btnCopyCopy.Text = "Copy";
            btnCopyCopy.UseVisualStyleBackColor = true;
            // 
            // lblCopyTo
            // 
            lblCopyTo.AutoSize = true;
            lblCopyTo.Location = new Point(20, 266);
            lblCopyTo.Name = "lblCopyTo";
            lblCopyTo.Size = new Size(29, 15);
            lblCopyTo.TabIndex = 28;
            lblCopyTo.Text = "  to:";
            // 
            // lblCopyFrom
            // 
            lblCopyFrom.AutoSize = true;
            lblCopyFrom.Location = new Point(13, 10);
            lblCopyFrom.Name = "lblCopyFrom";
            lblCopyFrom.Size = new Size(36, 15);
            lblCopyFrom.TabIndex = 27;
            lblCopyFrom.Text = "from:";
            // 
            // trvCopyTo
            // 
            trvCopyTo.Location = new Point(13, 287);
            trvCopyTo.Name = "trvCopyTo";
            trvCopyTo.Size = new Size(419, 148);
            trvCopyTo.TabIndex = 26;
            // 
            // btnCopyToLoadFileSystem
            // 
            btnCopyToLoadFileSystem.Location = new Point(412, 257);
            btnCopyToLoadFileSystem.Name = "btnCopyToLoadFileSystem";
            btnCopyToLoadFileSystem.Size = new Size(21, 23);
            btnCopyToLoadFileSystem.TabIndex = 25;
            btnCopyToLoadFileSystem.Text = "..";
            btnCopyToLoadFileSystem.UseVisualStyleBackColor = true;
            // 
            // btnCopyFromLoadFileSystem
            // 
            btnCopyFromLoadFileSystem.Location = new Point(411, 4);
            btnCopyFromLoadFileSystem.Name = "btnCopyFromLoadFileSystem";
            btnCopyFromLoadFileSystem.Size = new Size(21, 23);
            btnCopyFromLoadFileSystem.TabIndex = 24;
            btnCopyFromLoadFileSystem.Text = "..";
            btnCopyFromLoadFileSystem.UseVisualStyleBackColor = true;
            // 
            // txbCopyToPath
            // 
            txbCopyToPath.Location = new Point(64, 258);
            txbCopyToPath.Name = "txbCopyToPath";
            txbCopyToPath.Size = new Size(341, 23);
            txbCopyToPath.TabIndex = 2;
            // 
            // trvCopyFrom
            // 
            trvCopyFrom.Location = new Point(13, 37);
            trvCopyFrom.Name = "trvCopyFrom";
            trvCopyFrom.Size = new Size(419, 145);
            trvCopyFrom.TabIndex = 1;
            // 
            // txbCopyFromPath
            // 
            txbCopyFromPath.Location = new Point(64, 4);
            txbCopyFromPath.Name = "txbCopyFromPath";
            txbCopyFromPath.Size = new Size(341, 23);
            txbCopyFromPath.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, settingToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1351, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadsettingfileToolStripMenuItem, writesettingfileToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(35, 20);
            fileToolStripMenuItem.Text = "file";
            // 
            // loadsettingfileToolStripMenuItem
            // 
            loadsettingfileToolStripMenuItem.Name = "loadsettingfileToolStripMenuItem";
            loadsettingfileToolStripMenuItem.Size = new Size(162, 22);
            loadsettingfileToolStripMenuItem.Text = "load_setting_file";
            // 
            // writesettingfileToolStripMenuItem
            // 
            writesettingfileToolStripMenuItem.Name = "writesettingfileToolStripMenuItem";
            writesettingfileToolStripMenuItem.Size = new Size(162, 22);
            writesettingfileToolStripMenuItem.Text = "write_setting_file";
            // 
            // settingToolStripMenuItem
            // 
            settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            settingToolStripMenuItem.Size = new Size(55, 20);
            settingToolStripMenuItem.Text = "setting";
            settingToolStripMenuItem.Click += settingToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1351, 504);
            Controls.Add(pnlCopy);
            Controls.Add(pnlFolderBackup);
            Controls.Add(btnPanelChangeFolderBackup);
            Controls.Add(btnPanelChangeFileSync);
            Controls.Add(btnPanelChangeCopy);
            Controls.Add(pnlFileSync);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            pnlFileSync.ResumeLayout(false);
            pnlFileSync.PerformLayout();
            pnlFolderBackup.ResumeLayout(false);
            pnlFolderBackup.PerformLayout();
            pnlCopy.ResumeLayout(false);
            pnlCopy.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPanelChangeCopy;
        private Button btnPanelChangeFileSync;
        private Button btnPanelChangeFolderBackup;
        private Panel pnlFileSync;
        private Button btnFileSyncSync;
        private Button btnFileSyncChange;
        private Button btnFileSyncCopy;
        private Panel pnlFolderBackup;
        private Panel pnlCopy;
        private ListView lstvFileSync;
        private ListView lstvFolderBackupBackup;
        private ListView lstvFolderBackupTarget;
        private Button btnFileSyncAdd;
        private Button btnFolderBackupAdd;
        private MenuStrip menuStrip1;
        private Label lblFileSyncArrow;
        private TextBox txbFileSyncSyncPath;
        private TextBox txbFileSyncTargetPath;
        private Label lblFileSyncStatus;
        private TextBox txbFolderBackupBackupPath;
        private TextBox txbFolderBackupTargetPath;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem settingToolStripMenuItem;
        private Button btnFileSyncSyncLoadFileSystem;
        private Button btnFileSyncTargetLoadFileSystem;
        private Label lblFolderBackupTarget;
        private Button btnFolderBackupLoadFileSystem;
        private Button btnFolderBackupRestore;
        private Button btnFolderBackupCopy;
        private CheckBox ckbFolderBackupSun;
        private CheckBox ckbFolderBackupSat;
        private CheckBox ckbFolderBackupFri;
        private CheckBox ckbFolderBackupThu;
        private CheckBox ckbFolderBackupWed;
        private CheckBox ckbFolderBackupTue;
        private CheckBox ckbFolderBackupMon;
        private Label lblFolderBackupBackup;
        private TreeView trvCopyTo;
        private Button btnCopyToLoadFileSystem;
        private Button btnCopyFromLoadFileSystem;
        private TextBox txbCopyToPath;
        private TreeView trvCopyFrom;
        private TextBox txbCopyFromPath;
        private ToolStripMenuItem loadsettingfileToolStripMenuItem;
        private ToolStripMenuItem writesettingfileToolStripMenuItem;
        private Label lblCopyTo;
        private Label lblCopyFrom;
        private ProgressBar pgbCopy;
        private Button btnCopyCopy;
        private Label lblCopyStatus;
        private CheckBox ckbFolderBackupRun;
    }
}