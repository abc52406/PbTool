namespace PbTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MainContral = new System.Windows.Forms.TabControl();
            this.OutputInsert = new System.Windows.Forms.TabPage();
            this.cbxOutputDelete = new System.Windows.Forms.CheckBox();
            this.tbxOutputDelete = new System.Windows.Forms.TextBox();
            this.lblOutputDeleteSql = new System.Windows.Forms.Label();
            this.btnOutputAdd = new System.Windows.Forms.Button();
            this.btnOutputModify = new System.Windows.Forms.Button();
            this.btnOutputDelete = new System.Windows.Forms.Button();
            this.btnOutputOK = new System.Windows.Forms.Button();
            this.tbxOutputSql = new System.Windows.Forms.TextBox();
            this.lblOutputSelectSql = new System.Windows.Forms.Label();
            this.cbbOutputDataSet = new System.Windows.Forms.ComboBox();
            this.lblOutputDataSet = new System.Windows.Forms.Label();
            this.lblOutputTableName = new System.Windows.Forms.Label();
            this.tbxOutputTableName = new System.Windows.Forms.TextBox();
            this.lblOutputName = new System.Windows.Forms.Label();
            this.tbxOutputName = new System.Windows.Forms.TextBox();
            this.OutputList = new System.Windows.Forms.ListBox();
            this.lblOutputSource = new System.Windows.Forms.Label();
            this.DataOper = new System.Windows.Forms.TabPage();
            this.btnDataOperClearLog = new System.Windows.Forms.Button();
            this.gbxBak = new System.Windows.Forms.GroupBox();
            this.tbxBakPath = new System.Windows.Forms.TextBox();
            this.cbxBackUpDataBase = new System.Windows.Forms.CheckBox();
            this.cbxCompressBak = new System.Windows.Forms.CheckBox();
            this.lblBakPath = new System.Windows.Forms.Label();
            this.gbxDeleteSql = new System.Windows.Forms.GroupBox();
            this.cbxBackupInsert = new System.Windows.Forms.CheckBox();
            this.cbxBackupDelete = new System.Windows.Forms.CheckBox();
            this.OperatorSourcesList = new System.Windows.Forms.ListBox();
            this.btnDataOperOK = new System.Windows.Forms.Button();
            this.lblOperatorSourse = new System.Windows.Forms.Label();
            this.DataDiff = new System.Windows.Forms.TabPage();
            this.GroupBoxType = new System.Windows.Forms.GroupBox();
            this.rdbStruct = new System.Windows.Forms.RadioButton();
            this.rdbData = new System.Windows.Forms.RadioButton();
            this.groupBoxStruct = new System.Windows.Forms.GroupBox();
            this.cbxSameName = new System.Windows.Forms.CheckBox();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.cbxSelect = new System.Windows.Forms.CheckBox();
            this.cbxInsert = new System.Windows.Forms.CheckBox();
            this.btnDataDiffOK = new System.Windows.Forms.Button();
            this.groupBoxTo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxWhereStrTo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblWhereStrTo = new System.Windows.Forms.Label();
            this.TableListTo = new System.Windows.Forms.ComboBox();
            this.lblTableTo = new System.Windows.Forms.Label();
            this.SourceListTo = new System.Windows.Forms.ComboBox();
            this.lblSourcesTo = new System.Windows.Forms.Label();
            this.groupBoxFrom = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxWhereStrFrom = new System.Windows.Forms.TextBox();
            this.lblWhereStrFrom = new System.Windows.Forms.Label();
            this.TableListFrom = new System.Windows.Forms.ComboBox();
            this.lblTableFrom = new System.Windows.Forms.Label();
            this.SourceListFrom = new System.Windows.Forms.ComboBox();
            this.lblSourcesFrom = new System.Windows.Forms.Label();
            this.CodeTemplete = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCodeRun = new System.Windows.Forms.Button();
            this.cbbCodeTemplete = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxCodeOther = new System.Windows.Forms.TextBox();
            this.cbbCodeDataTable = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbCodeDataSource = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.DocumentCopy = new System.Windows.Forms.TabPage();
            this.cbxReplaceFile = new System.Windows.Forms.CheckBox();
            this.gbxCopyDirectorys = new System.Windows.Forms.GroupBox();
            this.tbxCopyDirectorys = new System.Windows.Forms.TextBox();
            this.rbtRemoveCopyDirectorys = new System.Windows.Forms.RadioButton();
            this.rbtOnlyCopyDirectorys = new System.Windows.Forms.RadioButton();
            this.gbxCopyFile = new System.Windows.Forms.GroupBox();
            this.tbxCopyFiles = new System.Windows.Forms.TextBox();
            this.rbtRemoveCopyFiles = new System.Windows.Forms.RadioButton();
            this.rbtOnlyCopyFiles = new System.Windows.Forms.RadioButton();
            this.tbxCopyTo = new System.Windows.Forms.TextBox();
            this.lblCopyTo = new System.Windows.Forms.Label();
            this.tbxCopyFrom = new System.Windows.Forms.TextBox();
            this.lblCopyFrom = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.DocumentDel = new System.Windows.Forms.TabPage();
            this.gbxDelRight = new System.Windows.Forms.GroupBox();
            this.rbtDelDirectoryFirst = new System.Windows.Forms.RadioButton();
            this.rbtDelFileFirst = new System.Windows.Forms.RadioButton();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gbxDelDirectory = new System.Windows.Forms.GroupBox();
            this.tbxDelDirectorys = new System.Windows.Forms.TextBox();
            this.rbtDelRemoveDirectory = new System.Windows.Forms.RadioButton();
            this.rbtDelKeepDirectory = new System.Windows.Forms.RadioButton();
            this.gbxDelFile = new System.Windows.Forms.GroupBox();
            this.tbxDelFiles = new System.Windows.Forms.TextBox();
            this.rbtDelRemoveFile = new System.Windows.Forms.RadioButton();
            this.rbtDelKeepFile = new System.Windows.Forms.RadioButton();
            this.tbxDelTarget = new System.Windows.Forms.TextBox();
            this.lblDelTarget = new System.Windows.Forms.Label();
            this.IPChange = new System.Windows.Forms.TabPage();
            this.btnIPAuto = new System.Windows.Forms.Button();
            this.btnIPUse = new System.Windows.Forms.Button();
            this.btnIPReplaceScheme = new System.Windows.Forms.Button();
            this.btnIPDelete = new System.Windows.Forms.Button();
            this.btnIPEdit = new System.Windows.Forms.Button();
            this.btnIPAdd = new System.Windows.Forms.Button();
            this.lblIPName = new System.Windows.Forms.Label();
            this.tbxIPName = new System.Windows.Forms.TextBox();
            this.lblDNSServerSpare = new System.Windows.Forms.Label();
            this.tbxDNSServerSpare = new System.Windows.Forms.TextBox();
            this.lblDNSServerSearchOrder = new System.Windows.Forms.Label();
            this.tbxDNSServerSearchOrder = new System.Windows.Forms.TextBox();
            this.lblDefaultIPGateWay = new System.Windows.Forms.Label();
            this.tbxDefaultIPGateWay = new System.Windows.Forms.TextBox();
            this.lblSubNetMask = new System.Windows.Forms.Label();
            this.tbxSubNetMask = new System.Windows.Forms.TextBox();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.tbxIPAddress = new System.Windows.Forms.TextBox();
            this.lblIPTree = new System.Windows.Forms.Label();
            this.IPTree = new System.Windows.Forms.TreeView();
            this.ConfigChange = new System.Windows.Forms.TabPage();
            this.btnConfigText = new System.Windows.Forms.Button();
            this.lblConfigIP = new System.Windows.Forms.Label();
            this.tbxConfigIP = new System.Windows.Forms.TextBox();
            this.btnConfigUse = new System.Windows.Forms.Button();
            this.btnConfigDelete = new System.Windows.Forms.Button();
            this.btnConfigEdit = new System.Windows.Forms.Button();
            this.btnConfigAdd = new System.Windows.Forms.Button();
            this.lblConfigName = new System.Windows.Forms.Label();
            this.tbxConfigName = new System.Windows.Forms.TextBox();
            this.lblConfigTree = new System.Windows.Forms.Label();
            this.ConfigTree = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.常规ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainContral.SuspendLayout();
            this.OutputInsert.SuspendLayout();
            this.DataOper.SuspendLayout();
            this.gbxBak.SuspendLayout();
            this.gbxDeleteSql.SuspendLayout();
            this.DataDiff.SuspendLayout();
            this.GroupBoxType.SuspendLayout();
            this.groupBoxStruct.SuspendLayout();
            this.groupBoxData.SuspendLayout();
            this.groupBoxTo.SuspendLayout();
            this.groupBoxFrom.SuspendLayout();
            this.CodeTemplete.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.DocumentCopy.SuspendLayout();
            this.gbxCopyDirectorys.SuspendLayout();
            this.gbxCopyFile.SuspendLayout();
            this.DocumentDel.SuspendLayout();
            this.gbxDelRight.SuspendLayout();
            this.gbxDelDirectory.SuspendLayout();
            this.gbxDelFile.SuspendLayout();
            this.IPChange.SuspendLayout();
            this.ConfigChange.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainContral
            // 
            this.MainContral.Controls.Add(this.OutputInsert);
            this.MainContral.Controls.Add(this.DataOper);
            this.MainContral.Controls.Add(this.DataDiff);
            this.MainContral.Controls.Add(this.CodeTemplete);
            this.MainContral.Controls.Add(this.DocumentCopy);
            this.MainContral.Controls.Add(this.DocumentDel);
            this.MainContral.Controls.Add(this.IPChange);
            this.MainContral.Controls.Add(this.ConfigChange);
            this.MainContral.Location = new System.Drawing.Point(1, 33);
            this.MainContral.Name = "MainContral";
            this.MainContral.SelectedIndex = 0;
            this.MainContral.Size = new System.Drawing.Size(824, 410);
            this.MainContral.TabIndex = 0;
            // 
            // OutputInsert
            // 
            this.OutputInsert.Controls.Add(this.cbxOutputDelete);
            this.OutputInsert.Controls.Add(this.tbxOutputDelete);
            this.OutputInsert.Controls.Add(this.lblOutputDeleteSql);
            this.OutputInsert.Controls.Add(this.btnOutputAdd);
            this.OutputInsert.Controls.Add(this.btnOutputModify);
            this.OutputInsert.Controls.Add(this.btnOutputDelete);
            this.OutputInsert.Controls.Add(this.btnOutputOK);
            this.OutputInsert.Controls.Add(this.tbxOutputSql);
            this.OutputInsert.Controls.Add(this.lblOutputSelectSql);
            this.OutputInsert.Controls.Add(this.cbbOutputDataSet);
            this.OutputInsert.Controls.Add(this.lblOutputDataSet);
            this.OutputInsert.Controls.Add(this.lblOutputTableName);
            this.OutputInsert.Controls.Add(this.tbxOutputTableName);
            this.OutputInsert.Controls.Add(this.lblOutputName);
            this.OutputInsert.Controls.Add(this.tbxOutputName);
            this.OutputInsert.Controls.Add(this.OutputList);
            this.OutputInsert.Controls.Add(this.lblOutputSource);
            this.OutputInsert.Location = new System.Drawing.Point(4, 22);
            this.OutputInsert.Name = "OutputInsert";
            this.OutputInsert.Padding = new System.Windows.Forms.Padding(3);
            this.OutputInsert.Size = new System.Drawing.Size(816, 384);
            this.OutputInsert.TabIndex = 2;
            this.OutputInsert.Text = "数据导出";
            this.OutputInsert.UseVisualStyleBackColor = true;
            // 
            // cbxOutputDelete
            // 
            this.cbxOutputDelete.AutoSize = true;
            this.cbxOutputDelete.Checked = true;
            this.cbxOutputDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxOutputDelete.Location = new System.Drawing.Point(314, 333);
            this.cbxOutputDelete.Name = "cbxOutputDelete";
            this.cbxOutputDelete.Size = new System.Drawing.Size(108, 16);
            this.cbxOutputDelete.TabIndex = 35;
            this.cbxOutputDelete.Text = "生成Delete语句";
            this.cbxOutputDelete.UseVisualStyleBackColor = true;
            // 
            // tbxOutputDelete
            // 
            this.tbxOutputDelete.Location = new System.Drawing.Point(380, 225);
            this.tbxOutputDelete.Multiline = true;
            this.tbxOutputDelete.Name = "tbxOutputDelete";
            this.tbxOutputDelete.Size = new System.Drawing.Size(363, 77);
            this.tbxOutputDelete.TabIndex = 34;
            // 
            // lblOutputDeleteSql
            // 
            this.lblOutputDeleteSql.AutoSize = true;
            this.lblOutputDeleteSql.Location = new System.Drawing.Point(312, 228);
            this.lblOutputDeleteSql.Name = "lblOutputDeleteSql";
            this.lblOutputDeleteSql.Size = new System.Drawing.Size(59, 12);
            this.lblOutputDeleteSql.TabIndex = 33;
            this.lblOutputDeleteSql.Text = "DeleteSql";
            // 
            // btnOutputAdd
            // 
            this.btnOutputAdd.Location = new System.Drawing.Point(429, 329);
            this.btnOutputAdd.Name = "btnOutputAdd";
            this.btnOutputAdd.Size = new System.Drawing.Size(75, 23);
            this.btnOutputAdd.TabIndex = 32;
            this.btnOutputAdd.Text = "添加";
            this.btnOutputAdd.UseVisualStyleBackColor = true;
            this.btnOutputAdd.Click += new System.EventHandler(this.btnOutputAdd_Click);
            // 
            // btnOutputModify
            // 
            this.btnOutputModify.Location = new System.Drawing.Point(523, 329);
            this.btnOutputModify.Name = "btnOutputModify";
            this.btnOutputModify.Size = new System.Drawing.Size(75, 23);
            this.btnOutputModify.TabIndex = 31;
            this.btnOutputModify.Text = "修改";
            this.btnOutputModify.UseVisualStyleBackColor = true;
            this.btnOutputModify.Click += new System.EventHandler(this.btnOutputModify_Click);
            // 
            // btnOutputDelete
            // 
            this.btnOutputDelete.Location = new System.Drawing.Point(616, 329);
            this.btnOutputDelete.Name = "btnOutputDelete";
            this.btnOutputDelete.Size = new System.Drawing.Size(75, 23);
            this.btnOutputDelete.TabIndex = 30;
            this.btnOutputDelete.Text = "删除";
            this.btnOutputDelete.UseVisualStyleBackColor = true;
            this.btnOutputDelete.Click += new System.EventHandler(this.btnOutputDelete_Click);
            // 
            // btnOutputOK
            // 
            this.btnOutputOK.Location = new System.Drawing.Point(711, 329);
            this.btnOutputOK.Name = "btnOutputOK";
            this.btnOutputOK.Size = new System.Drawing.Size(74, 23);
            this.btnOutputOK.TabIndex = 29;
            this.btnOutputOK.Text = "导出";
            this.btnOutputOK.UseVisualStyleBackColor = true;
            this.btnOutputOK.Click += new System.EventHandler(this.btnOutputOK_Click);
            // 
            // tbxOutputSql
            // 
            this.tbxOutputSql.Location = new System.Drawing.Point(380, 130);
            this.tbxOutputSql.Multiline = true;
            this.tbxOutputSql.Name = "tbxOutputSql";
            this.tbxOutputSql.Size = new System.Drawing.Size(363, 77);
            this.tbxOutputSql.TabIndex = 28;
            // 
            // lblOutputSelectSql
            // 
            this.lblOutputSelectSql.AutoSize = true;
            this.lblOutputSelectSql.Location = new System.Drawing.Point(312, 133);
            this.lblOutputSelectSql.Name = "lblOutputSelectSql";
            this.lblOutputSelectSql.Size = new System.Drawing.Size(59, 12);
            this.lblOutputSelectSql.TabIndex = 27;
            this.lblOutputSelectSql.Text = "SelectSql";
            // 
            // cbbOutputDataSet
            // 
            this.cbbOutputDataSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOutputDataSet.FormattingEnabled = true;
            this.cbbOutputDataSet.Location = new System.Drawing.Point(380, 81);
            this.cbbOutputDataSet.Name = "cbbOutputDataSet";
            this.cbbOutputDataSet.Size = new System.Drawing.Size(363, 20);
            this.cbbOutputDataSet.TabIndex = 25;
            // 
            // lblOutputDataSet
            // 
            this.lblOutputDataSet.AutoSize = true;
            this.lblOutputDataSet.Location = new System.Drawing.Point(312, 85);
            this.lblOutputDataSet.Name = "lblOutputDataSet";
            this.lblOutputDataSet.Size = new System.Drawing.Size(41, 12);
            this.lblOutputDataSet.TabIndex = 24;
            this.lblOutputDataSet.Text = "数据库";
            // 
            // lblOutputTableName
            // 
            this.lblOutputTableName.AutoSize = true;
            this.lblOutputTableName.Location = new System.Drawing.Point(572, 36);
            this.lblOutputTableName.Name = "lblOutputTableName";
            this.lblOutputTableName.Size = new System.Drawing.Size(17, 12);
            this.lblOutputTableName.TabIndex = 23;
            this.lblOutputTableName.Text = "表";
            // 
            // tbxOutputTableName
            // 
            this.tbxOutputTableName.Location = new System.Drawing.Point(616, 33);
            this.tbxOutputTableName.Name = "tbxOutputTableName";
            this.tbxOutputTableName.Size = new System.Drawing.Size(127, 21);
            this.tbxOutputTableName.TabIndex = 22;
            // 
            // lblOutputName
            // 
            this.lblOutputName.AutoSize = true;
            this.lblOutputName.Location = new System.Drawing.Point(336, 36);
            this.lblOutputName.Name = "lblOutputName";
            this.lblOutputName.Size = new System.Drawing.Size(29, 12);
            this.lblOutputName.TabIndex = 21;
            this.lblOutputName.Text = "名称";
            // 
            // tbxOutputName
            // 
            this.tbxOutputName.Location = new System.Drawing.Point(380, 33);
            this.tbxOutputName.Name = "tbxOutputName";
            this.tbxOutputName.Size = new System.Drawing.Size(127, 21);
            this.tbxOutputName.TabIndex = 20;
            // 
            // OutputList
            // 
            this.OutputList.FormattingEnabled = true;
            this.OutputList.ItemHeight = 12;
            this.OutputList.Location = new System.Drawing.Point(88, 20);
            this.OutputList.Name = "OutputList";
            this.OutputList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.OutputList.Size = new System.Drawing.Size(200, 316);
            this.OutputList.TabIndex = 12;
            this.OutputList.SelectedIndexChanged += new System.EventHandler(this.OutputList_SelectedIndexChanged);
            // 
            // lblOutputSource
            // 
            this.lblOutputSource.AutoSize = true;
            this.lblOutputSource.Location = new System.Drawing.Point(23, 20);
            this.lblOutputSource.Name = "lblOutputSource";
            this.lblOutputSource.Size = new System.Drawing.Size(41, 12);
            this.lblOutputSource.TabIndex = 11;
            this.lblOutputSource.Text = "数据源";
            // 
            // DataOper
            // 
            this.DataOper.Controls.Add(this.btnDataOperClearLog);
            this.DataOper.Controls.Add(this.gbxBak);
            this.DataOper.Controls.Add(this.gbxDeleteSql);
            this.DataOper.Controls.Add(this.OperatorSourcesList);
            this.DataOper.Controls.Add(this.btnDataOperOK);
            this.DataOper.Controls.Add(this.lblOperatorSourse);
            this.DataOper.Location = new System.Drawing.Point(4, 22);
            this.DataOper.Name = "DataOper";
            this.DataOper.Padding = new System.Windows.Forms.Padding(3);
            this.DataOper.Size = new System.Drawing.Size(816, 384);
            this.DataOper.TabIndex = 3;
            this.DataOper.Text = "数据库操作";
            this.DataOper.UseVisualStyleBackColor = true;
            // 
            // btnDataOperClearLog
            // 
            this.btnDataOperClearLog.Location = new System.Drawing.Point(700, 59);
            this.btnDataOperClearLog.Name = "btnDataOperClearLog";
            this.btnDataOperClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnDataOperClearLog.TabIndex = 17;
            this.btnDataOperClearLog.Text = "清除日志";
            this.btnDataOperClearLog.UseVisualStyleBackColor = true;
            this.btnDataOperClearLog.Click += new System.EventHandler(this.btnDataOperClearLog_Click);
            // 
            // gbxBak
            // 
            this.gbxBak.Controls.Add(this.tbxBakPath);
            this.gbxBak.Controls.Add(this.cbxBackUpDataBase);
            this.gbxBak.Controls.Add(this.cbxCompressBak);
            this.gbxBak.Controls.Add(this.lblBakPath);
            this.gbxBak.Location = new System.Drawing.Point(325, 106);
            this.gbxBak.Name = "gbxBak";
            this.gbxBak.Size = new System.Drawing.Size(450, 100);
            this.gbxBak.TabIndex = 16;
            this.gbxBak.TabStop = false;
            this.gbxBak.Text = "备份数据";
            // 
            // tbxBakPath
            // 
            this.tbxBakPath.Location = new System.Drawing.Point(90, 57);
            this.tbxBakPath.Name = "tbxBakPath";
            this.tbxBakPath.Size = new System.Drawing.Size(337, 21);
            this.tbxBakPath.TabIndex = 14;
            // 
            // cbxBackUpDataBase
            // 
            this.cbxBackUpDataBase.AutoSize = true;
            this.cbxBackUpDataBase.Location = new System.Drawing.Point(13, 18);
            this.cbxBackUpDataBase.Name = "cbxBackUpDataBase";
            this.cbxBackUpDataBase.Size = new System.Drawing.Size(84, 16);
            this.cbxBackUpDataBase.TabIndex = 11;
            this.cbxBackUpDataBase.Text = "备份数据库";
            this.cbxBackUpDataBase.UseVisualStyleBackColor = true;
            this.cbxBackUpDataBase.CheckedChanged += new System.EventHandler(this.cbxBackUpDataBase_CheckedChanged);
            // 
            // cbxCompressBak
            // 
            this.cbxCompressBak.AutoSize = true;
            this.cbxCompressBak.Location = new System.Drawing.Point(154, 18);
            this.cbxCompressBak.Name = "cbxCompressBak";
            this.cbxCompressBak.Size = new System.Drawing.Size(96, 16);
            this.cbxCompressBak.TabIndex = 12;
            this.cbxCompressBak.Text = "压缩备份文件";
            this.cbxCompressBak.UseVisualStyleBackColor = true;
            this.cbxCompressBak.CheckedChanged += new System.EventHandler(this.cbxCompressBak_CheckedChanged);
            // 
            // lblBakPath
            // 
            this.lblBakPath.AutoSize = true;
            this.lblBakPath.Location = new System.Drawing.Point(14, 60);
            this.lblBakPath.Name = "lblBakPath";
            this.lblBakPath.Size = new System.Drawing.Size(53, 12);
            this.lblBakPath.TabIndex = 13;
            this.lblBakPath.Text = "备份路径";
            // 
            // gbxDeleteSql
            // 
            this.gbxDeleteSql.Controls.Add(this.cbxBackupInsert);
            this.gbxDeleteSql.Controls.Add(this.cbxBackupDelete);
            this.gbxDeleteSql.Location = new System.Drawing.Point(325, 30);
            this.gbxDeleteSql.Name = "gbxDeleteSql";
            this.gbxDeleteSql.Size = new System.Drawing.Size(334, 52);
            this.gbxDeleteSql.TabIndex = 15;
            this.gbxDeleteSql.TabStop = false;
            this.gbxDeleteSql.Text = "Sql脚本";
            // 
            // cbxBackupInsert
            // 
            this.cbxBackupInsert.AutoSize = true;
            this.cbxBackupInsert.Location = new System.Drawing.Point(154, 20);
            this.cbxBackupInsert.Name = "cbxBackupInsert";
            this.cbxBackupInsert.Size = new System.Drawing.Size(108, 16);
            this.cbxBackupInsert.TabIndex = 10;
            this.cbxBackupInsert.Text = "生成Insert脚本";
            this.cbxBackupInsert.UseVisualStyleBackColor = true;
            this.cbxBackupInsert.CheckedChanged += new System.EventHandler(this.cbxBackupInsert_CheckedChanged);
            // 
            // cbxBackupDelete
            // 
            this.cbxBackupDelete.AutoSize = true;
            this.cbxBackupDelete.Checked = true;
            this.cbxBackupDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxBackupDelete.Location = new System.Drawing.Point(15, 20);
            this.cbxBackupDelete.Name = "cbxBackupDelete";
            this.cbxBackupDelete.Size = new System.Drawing.Size(108, 16);
            this.cbxBackupDelete.TabIndex = 9;
            this.cbxBackupDelete.Text = "生成Delete脚本";
            this.cbxBackupDelete.UseVisualStyleBackColor = true;
            this.cbxBackupDelete.CheckedChanged += new System.EventHandler(this.cbxDelete_CheckedChanged);
            // 
            // OperatorSourcesList
            // 
            this.OperatorSourcesList.FormattingEnabled = true;
            this.OperatorSourcesList.ItemHeight = 12;
            this.OperatorSourcesList.Location = new System.Drawing.Point(91, 30);
            this.OperatorSourcesList.Name = "OperatorSourcesList";
            this.OperatorSourcesList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.OperatorSourcesList.Size = new System.Drawing.Size(200, 316);
            this.OperatorSourcesList.TabIndex = 10;
            // 
            // btnDataOperOK
            // 
            this.btnDataOperOK.Location = new System.Drawing.Point(700, 25);
            this.btnDataOperOK.Name = "btnDataOperOK";
            this.btnDataOperOK.Size = new System.Drawing.Size(75, 23);
            this.btnDataOperOK.TabIndex = 5;
            this.btnDataOperOK.Text = "执行";
            this.btnDataOperOK.UseVisualStyleBackColor = true;
            this.btnDataOperOK.Click += new System.EventHandler(this.btnDataOperOK_Click);
            // 
            // lblOperatorSourse
            // 
            this.lblOperatorSourse.AutoSize = true;
            this.lblOperatorSourse.Location = new System.Drawing.Point(26, 30);
            this.lblOperatorSourse.Name = "lblOperatorSourse";
            this.lblOperatorSourse.Size = new System.Drawing.Size(41, 12);
            this.lblOperatorSourse.TabIndex = 3;
            this.lblOperatorSourse.Text = "数据源";
            // 
            // DataDiff
            // 
            this.DataDiff.Controls.Add(this.GroupBoxType);
            this.DataDiff.Controls.Add(this.groupBoxStruct);
            this.DataDiff.Controls.Add(this.groupBoxData);
            this.DataDiff.Controls.Add(this.btnDataDiffOK);
            this.DataDiff.Controls.Add(this.groupBoxTo);
            this.DataDiff.Controls.Add(this.groupBoxFrom);
            this.DataDiff.Location = new System.Drawing.Point(4, 22);
            this.DataDiff.Name = "DataDiff";
            this.DataDiff.Padding = new System.Windows.Forms.Padding(3);
            this.DataDiff.Size = new System.Drawing.Size(816, 384);
            this.DataDiff.TabIndex = 4;
            this.DataDiff.Text = "数据差异";
            this.DataDiff.UseVisualStyleBackColor = true;
            // 
            // GroupBoxType
            // 
            this.GroupBoxType.Controls.Add(this.rdbStruct);
            this.GroupBoxType.Controls.Add(this.rdbData);
            this.GroupBoxType.Location = new System.Drawing.Point(46, 223);
            this.GroupBoxType.Name = "GroupBoxType";
            this.GroupBoxType.Size = new System.Drawing.Size(444, 33);
            this.GroupBoxType.TabIndex = 17;
            this.GroupBoxType.TabStop = false;
            this.GroupBoxType.Text = "对比对象";
            // 
            // rdbStruct
            // 
            this.rdbStruct.AutoSize = true;
            this.rdbStruct.Location = new System.Drawing.Point(283, 11);
            this.rdbStruct.Name = "rdbStruct";
            this.rdbStruct.Size = new System.Drawing.Size(47, 16);
            this.rdbStruct.TabIndex = 1;
            this.rdbStruct.TabStop = true;
            this.rdbStruct.Text = "结构";
            this.rdbStruct.UseVisualStyleBackColor = true;
            // 
            // rdbData
            // 
            this.rdbData.AutoSize = true;
            this.rdbData.Checked = true;
            this.rdbData.Location = new System.Drawing.Point(62, 11);
            this.rdbData.Name = "rdbData";
            this.rdbData.Size = new System.Drawing.Size(47, 16);
            this.rdbData.TabIndex = 0;
            this.rdbData.TabStop = true;
            this.rdbData.Text = "数据";
            this.rdbData.UseVisualStyleBackColor = true;
            // 
            // groupBoxStruct
            // 
            this.groupBoxStruct.Controls.Add(this.cbxSameName);
            this.groupBoxStruct.Location = new System.Drawing.Point(290, 263);
            this.groupBoxStruct.Name = "groupBoxStruct";
            this.groupBoxStruct.Size = new System.Drawing.Size(200, 100);
            this.groupBoxStruct.TabIndex = 16;
            this.groupBoxStruct.TabStop = false;
            this.groupBoxStruct.Text = "结构比较";
            // 
            // cbxSameName
            // 
            this.cbxSameName.AutoSize = true;
            this.cbxSameName.Location = new System.Drawing.Point(17, 26);
            this.cbxSameName.Name = "cbxSameName";
            this.cbxSameName.Size = new System.Drawing.Size(108, 16);
            this.cbxSameName.TabIndex = 13;
            this.cbxSameName.Text = "只对比同名的表";
            this.cbxSameName.UseVisualStyleBackColor = true;
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.cbxSelect);
            this.groupBoxData.Controls.Add(this.cbxInsert);
            this.groupBoxData.Location = new System.Drawing.Point(46, 261);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(200, 100);
            this.groupBoxData.TabIndex = 15;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "数据比较";
            // 
            // cbxSelect
            // 
            this.cbxSelect.AutoSize = true;
            this.cbxSelect.Checked = true;
            this.cbxSelect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSelect.Location = new System.Drawing.Point(15, 26);
            this.cbxSelect.Name = "cbxSelect";
            this.cbxSelect.Size = new System.Drawing.Size(168, 16);
            this.cbxSelect.TabIndex = 8;
            this.cbxSelect.Text = "生成差异数据的Select脚本";
            this.cbxSelect.UseVisualStyleBackColor = true;
            // 
            // cbxInsert
            // 
            this.cbxInsert.AutoSize = true;
            this.cbxInsert.Location = new System.Drawing.Point(15, 63);
            this.cbxInsert.Name = "cbxInsert";
            this.cbxInsert.Size = new System.Drawing.Size(168, 16);
            this.cbxInsert.TabIndex = 9;
            this.cbxInsert.Text = "生成差异数据的Insert脚本";
            this.cbxInsert.UseVisualStyleBackColor = true;
            // 
            // btnDataDiffOK
            // 
            this.btnDataDiffOK.Location = new System.Drawing.Point(668, 331);
            this.btnDataDiffOK.Name = "btnDataDiffOK";
            this.btnDataDiffOK.Size = new System.Drawing.Size(75, 23);
            this.btnDataDiffOK.TabIndex = 12;
            this.btnDataDiffOK.Text = "执行";
            this.btnDataDiffOK.UseVisualStyleBackColor = true;
            this.btnDataDiffOK.Click += new System.EventHandler(this.btnDataDiffOK_Click);
            // 
            // groupBoxTo
            // 
            this.groupBoxTo.Controls.Add(this.label3);
            this.groupBoxTo.Controls.Add(this.tbxWhereStrTo);
            this.groupBoxTo.Controls.Add(this.label4);
            this.groupBoxTo.Controls.Add(this.lblWhereStrTo);
            this.groupBoxTo.Controls.Add(this.TableListTo);
            this.groupBoxTo.Controls.Add(this.lblTableTo);
            this.groupBoxTo.Controls.Add(this.SourceListTo);
            this.groupBoxTo.Controls.Add(this.lblSourcesTo);
            this.groupBoxTo.Location = new System.Drawing.Point(448, 31);
            this.groupBoxTo.Name = "groupBoxTo";
            this.groupBoxTo.Size = new System.Drawing.Size(314, 186);
            this.groupBoxTo.TabIndex = 7;
            this.groupBoxTo.TabStop = false;
            this.groupBoxTo.Text = "目标数据";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "where开头)";
            // 
            // tbxWhereStrTo
            // 
            this.tbxWhereStrTo.Location = new System.Drawing.Point(95, 99);
            this.tbxWhereStrTo.Multiline = true;
            this.tbxWhereStrTo.Name = "tbxWhereStrTo";
            this.tbxWhereStrTo.Size = new System.Drawing.Size(200, 67);
            this.tbxWhereStrTo.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "(不以and或";
            // 
            // lblWhereStrTo
            // 
            this.lblWhereStrTo.AutoSize = true;
            this.lblWhereStrTo.Location = new System.Drawing.Point(25, 125);
            this.lblWhereStrTo.Name = "lblWhereStrTo";
            this.lblWhereStrTo.Size = new System.Drawing.Size(53, 12);
            this.lblWhereStrTo.TabIndex = 6;
            this.lblWhereStrTo.Text = "筛选条件";
            // 
            // TableListTo
            // 
            this.TableListTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TableListTo.FormattingEnabled = true;
            this.TableListTo.Location = new System.Drawing.Point(95, 55);
            this.TableListTo.Name = "TableListTo";
            this.TableListTo.Size = new System.Drawing.Size(200, 20);
            this.TableListTo.TabIndex = 5;
            // 
            // lblTableTo
            // 
            this.lblTableTo.AutoSize = true;
            this.lblTableTo.Location = new System.Drawing.Point(25, 58);
            this.lblTableTo.Name = "lblTableTo";
            this.lblTableTo.Size = new System.Drawing.Size(17, 12);
            this.lblTableTo.TabIndex = 4;
            this.lblTableTo.Text = "表";
            // 
            // SourceListTo
            // 
            this.SourceListTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SourceListTo.FormattingEnabled = true;
            this.SourceListTo.Location = new System.Drawing.Point(95, 19);
            this.SourceListTo.Name = "SourceListTo";
            this.SourceListTo.Size = new System.Drawing.Size(200, 20);
            this.SourceListTo.TabIndex = 3;
            this.SourceListTo.SelectedIndexChanged += new System.EventHandler(this.SourceListTo_SelectedIndexChanged);
            // 
            // lblSourcesTo
            // 
            this.lblSourcesTo.AutoSize = true;
            this.lblSourcesTo.Location = new System.Drawing.Point(25, 22);
            this.lblSourcesTo.Name = "lblSourcesTo";
            this.lblSourcesTo.Size = new System.Drawing.Size(41, 12);
            this.lblSourcesTo.TabIndex = 2;
            this.lblSourcesTo.Text = "数据源";
            // 
            // groupBoxFrom
            // 
            this.groupBoxFrom.Controls.Add(this.label2);
            this.groupBoxFrom.Controls.Add(this.label1);
            this.groupBoxFrom.Controls.Add(this.tbxWhereStrFrom);
            this.groupBoxFrom.Controls.Add(this.lblWhereStrFrom);
            this.groupBoxFrom.Controls.Add(this.TableListFrom);
            this.groupBoxFrom.Controls.Add(this.lblTableFrom);
            this.groupBoxFrom.Controls.Add(this.SourceListFrom);
            this.groupBoxFrom.Controls.Add(this.lblSourcesFrom);
            this.groupBoxFrom.Location = new System.Drawing.Point(46, 31);
            this.groupBoxFrom.Name = "groupBoxFrom";
            this.groupBoxFrom.Size = new System.Drawing.Size(314, 186);
            this.groupBoxFrom.TabIndex = 6;
            this.groupBoxFrom.TabStop = false;
            this.groupBoxFrom.Text = "原始数据";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "where开头)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "(不以and或";
            // 
            // tbxWhereStrFrom
            // 
            this.tbxWhereStrFrom.Location = new System.Drawing.Point(95, 99);
            this.tbxWhereStrFrom.Multiline = true;
            this.tbxWhereStrFrom.Name = "tbxWhereStrFrom";
            this.tbxWhereStrFrom.Size = new System.Drawing.Size(200, 67);
            this.tbxWhereStrFrom.TabIndex = 13;
            // 
            // lblWhereStrFrom
            // 
            this.lblWhereStrFrom.AutoSize = true;
            this.lblWhereStrFrom.Location = new System.Drawing.Point(24, 125);
            this.lblWhereStrFrom.Name = "lblWhereStrFrom";
            this.lblWhereStrFrom.Size = new System.Drawing.Size(53, 12);
            this.lblWhereStrFrom.TabIndex = 5;
            this.lblWhereStrFrom.Text = "筛选条件";
            // 
            // TableListFrom
            // 
            this.TableListFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TableListFrom.FormattingEnabled = true;
            this.TableListFrom.Location = new System.Drawing.Point(95, 55);
            this.TableListFrom.Name = "TableListFrom";
            this.TableListFrom.Size = new System.Drawing.Size(200, 20);
            this.TableListFrom.TabIndex = 4;
            // 
            // lblTableFrom
            // 
            this.lblTableFrom.AutoSize = true;
            this.lblTableFrom.Location = new System.Drawing.Point(24, 58);
            this.lblTableFrom.Name = "lblTableFrom";
            this.lblTableFrom.Size = new System.Drawing.Size(17, 12);
            this.lblTableFrom.TabIndex = 3;
            this.lblTableFrom.Text = "表";
            // 
            // SourceListFrom
            // 
            this.SourceListFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SourceListFrom.FormattingEnabled = true;
            this.SourceListFrom.Location = new System.Drawing.Point(95, 19);
            this.SourceListFrom.Name = "SourceListFrom";
            this.SourceListFrom.Size = new System.Drawing.Size(200, 20);
            this.SourceListFrom.TabIndex = 2;
            this.SourceListFrom.SelectedIndexChanged += new System.EventHandler(this.SourceListFrom_SelectedIndexChanged);
            // 
            // lblSourcesFrom
            // 
            this.lblSourcesFrom.AutoSize = true;
            this.lblSourcesFrom.Location = new System.Drawing.Point(24, 22);
            this.lblSourcesFrom.Name = "lblSourcesFrom";
            this.lblSourcesFrom.Size = new System.Drawing.Size(41, 12);
            this.lblSourcesFrom.TabIndex = 1;
            this.lblSourcesFrom.Text = "数据源";
            // 
            // CodeTemplete
            // 
            this.CodeTemplete.Controls.Add(this.groupBox1);
            this.CodeTemplete.Location = new System.Drawing.Point(4, 22);
            this.CodeTemplete.Name = "CodeTemplete";
            this.CodeTemplete.Padding = new System.Windows.Forms.Padding(3);
            this.CodeTemplete.Size = new System.Drawing.Size(816, 384);
            this.CodeTemplete.TabIndex = 7;
            this.CodeTemplete.Text = "代码生成器";
            this.CodeTemplete.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCodeRun);
            this.groupBox1.Controls.Add(this.cbbCodeTemplete);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbxCodeOther);
            this.groupBox1.Controls.Add(this.cbbCodeDataTable);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbbCodeDataSource);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(62, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 345);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "原始数据";
            // 
            // btnCodeRun
            // 
            this.btnCodeRun.Location = new System.Drawing.Point(298, 303);
            this.btnCodeRun.Name = "btnCodeRun";
            this.btnCodeRun.Size = new System.Drawing.Size(75, 23);
            this.btnCodeRun.TabIndex = 18;
            this.btnCodeRun.Text = "执行";
            this.btnCodeRun.UseVisualStyleBackColor = true;
            this.btnCodeRun.Click += new System.EventHandler(this.btnCodeRun_Click);
            // 
            // cbbCodeTemplete
            // 
            this.cbbCodeTemplete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCodeTemplete.FormattingEnabled = true;
            this.cbbCodeTemplete.Location = new System.Drawing.Point(95, 20);
            this.cbbCodeTemplete.Name = "cbbCodeTemplete";
            this.cbbCodeTemplete.Size = new System.Drawing.Size(550, 20);
            this.cbbCodeTemplete.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "模板";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "其它替换内容";
            // 
            // tbxCodeOther
            // 
            this.tbxCodeOther.Location = new System.Drawing.Point(95, 135);
            this.tbxCodeOther.Multiline = true;
            this.tbxCodeOther.Name = "tbxCodeOther";
            this.tbxCodeOther.Size = new System.Drawing.Size(550, 148);
            this.tbxCodeOther.TabIndex = 13;
            // 
            // cbbCodeDataTable
            // 
            this.cbbCodeDataTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCodeDataTable.FormattingEnabled = true;
            this.cbbCodeDataTable.Location = new System.Drawing.Point(95, 91);
            this.cbbCodeDataTable.Name = "cbbCodeDataTable";
            this.cbbCodeDataTable.Size = new System.Drawing.Size(550, 20);
            this.cbbCodeDataTable.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "表";
            // 
            // cbbCodeDataSource
            // 
            this.cbbCodeDataSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCodeDataSource.FormattingEnabled = true;
            this.cbbCodeDataSource.Location = new System.Drawing.Point(95, 55);
            this.cbbCodeDataSource.Name = "cbbCodeDataSource";
            this.cbbCodeDataSource.Size = new System.Drawing.Size(550, 20);
            this.cbbCodeDataSource.TabIndex = 2;
            this.cbbCodeDataSource.SelectedIndexChanged += new System.EventHandler(this.cbbCodeDataSource_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "数据源";
            // 
            // DocumentCopy
            // 
            this.DocumentCopy.Controls.Add(this.cbxReplaceFile);
            this.DocumentCopy.Controls.Add(this.gbxCopyDirectorys);
            this.DocumentCopy.Controls.Add(this.gbxCopyFile);
            this.DocumentCopy.Controls.Add(this.tbxCopyTo);
            this.DocumentCopy.Controls.Add(this.lblCopyTo);
            this.DocumentCopy.Controls.Add(this.tbxCopyFrom);
            this.DocumentCopy.Controls.Add(this.lblCopyFrom);
            this.DocumentCopy.Controls.Add(this.btnCopy);
            this.DocumentCopy.Location = new System.Drawing.Point(4, 22);
            this.DocumentCopy.Name = "DocumentCopy";
            this.DocumentCopy.Padding = new System.Windows.Forms.Padding(3);
            this.DocumentCopy.Size = new System.Drawing.Size(816, 384);
            this.DocumentCopy.TabIndex = 5;
            this.DocumentCopy.Text = "文件夹复制";
            this.DocumentCopy.UseVisualStyleBackColor = true;
            // 
            // cbxReplaceFile
            // 
            this.cbxReplaceFile.AutoSize = true;
            this.cbxReplaceFile.Location = new System.Drawing.Point(37, 323);
            this.cbxReplaceFile.Name = "cbxReplaceFile";
            this.cbxReplaceFile.Size = new System.Drawing.Size(96, 16);
            this.cbxReplaceFile.TabIndex = 12;
            this.cbxReplaceFile.Text = "替换现有文件";
            this.cbxReplaceFile.UseVisualStyleBackColor = true;
            // 
            // gbxCopyDirectorys
            // 
            this.gbxCopyDirectorys.Controls.Add(this.tbxCopyDirectorys);
            this.gbxCopyDirectorys.Controls.Add(this.rbtRemoveCopyDirectorys);
            this.gbxCopyDirectorys.Controls.Add(this.rbtOnlyCopyDirectorys);
            this.gbxCopyDirectorys.Location = new System.Drawing.Point(37, 100);
            this.gbxCopyDirectorys.Name = "gbxCopyDirectorys";
            this.gbxCopyDirectorys.Size = new System.Drawing.Size(720, 85);
            this.gbxCopyDirectorys.TabIndex = 9;
            this.gbxCopyDirectorys.TabStop = false;
            this.gbxCopyDirectorys.Text = "文件夹（分号分隔）";
            // 
            // tbxCopyDirectorys
            // 
            this.tbxCopyDirectorys.Location = new System.Drawing.Point(100, 35);
            this.tbxCopyDirectorys.Name = "tbxCopyDirectorys";
            this.tbxCopyDirectorys.Size = new System.Drawing.Size(603, 21);
            this.tbxCopyDirectorys.TabIndex = 7;
            // 
            // rbtRemoveCopyDirectorys
            // 
            this.rbtRemoveCopyDirectorys.AutoSize = true;
            this.rbtRemoveCopyDirectorys.Location = new System.Drawing.Point(7, 24);
            this.rbtRemoveCopyDirectorys.Name = "rbtRemoveCopyDirectorys";
            this.rbtRemoveCopyDirectorys.Size = new System.Drawing.Size(83, 16);
            this.rbtRemoveCopyDirectorys.TabIndex = 5;
            this.rbtRemoveCopyDirectorys.TabStop = true;
            this.rbtRemoveCopyDirectorys.Text = "排除文件夹";
            this.rbtRemoveCopyDirectorys.UseVisualStyleBackColor = true;
            // 
            // rbtOnlyCopyDirectorys
            // 
            this.rbtOnlyCopyDirectorys.AutoSize = true;
            this.rbtOnlyCopyDirectorys.Location = new System.Drawing.Point(7, 46);
            this.rbtOnlyCopyDirectorys.Name = "rbtOnlyCopyDirectorys";
            this.rbtOnlyCopyDirectorys.Size = new System.Drawing.Size(83, 16);
            this.rbtOnlyCopyDirectorys.TabIndex = 6;
            this.rbtOnlyCopyDirectorys.TabStop = true;
            this.rbtOnlyCopyDirectorys.Text = "复制文件夹";
            this.rbtOnlyCopyDirectorys.UseVisualStyleBackColor = true;
            // 
            // gbxCopyFile
            // 
            this.gbxCopyFile.Controls.Add(this.tbxCopyFiles);
            this.gbxCopyFile.Controls.Add(this.rbtRemoveCopyFiles);
            this.gbxCopyFile.Controls.Add(this.rbtOnlyCopyFiles);
            this.gbxCopyFile.Location = new System.Drawing.Point(37, 194);
            this.gbxCopyFile.Name = "gbxCopyFile";
            this.gbxCopyFile.Size = new System.Drawing.Size(720, 85);
            this.gbxCopyFile.TabIndex = 8;
            this.gbxCopyFile.TabStop = false;
            this.gbxCopyFile.Text = "文件（分号分隔）";
            // 
            // tbxCopyFiles
            // 
            this.tbxCopyFiles.Location = new System.Drawing.Point(100, 35);
            this.tbxCopyFiles.Name = "tbxCopyFiles";
            this.tbxCopyFiles.Size = new System.Drawing.Size(603, 21);
            this.tbxCopyFiles.TabIndex = 7;
            // 
            // rbtRemoveCopyFiles
            // 
            this.rbtRemoveCopyFiles.AutoSize = true;
            this.rbtRemoveCopyFiles.Location = new System.Drawing.Point(7, 24);
            this.rbtRemoveCopyFiles.Name = "rbtRemoveCopyFiles";
            this.rbtRemoveCopyFiles.Size = new System.Drawing.Size(71, 16);
            this.rbtRemoveCopyFiles.TabIndex = 5;
            this.rbtRemoveCopyFiles.TabStop = true;
            this.rbtRemoveCopyFiles.Text = "排除文件";
            this.rbtRemoveCopyFiles.UseVisualStyleBackColor = true;
            // 
            // rbtOnlyCopyFiles
            // 
            this.rbtOnlyCopyFiles.AutoSize = true;
            this.rbtOnlyCopyFiles.Location = new System.Drawing.Point(7, 46);
            this.rbtOnlyCopyFiles.Name = "rbtOnlyCopyFiles";
            this.rbtOnlyCopyFiles.Size = new System.Drawing.Size(71, 16);
            this.rbtOnlyCopyFiles.TabIndex = 6;
            this.rbtOnlyCopyFiles.TabStop = true;
            this.rbtOnlyCopyFiles.Text = "复制文件";
            this.rbtOnlyCopyFiles.UseVisualStyleBackColor = true;
            // 
            // tbxCopyTo
            // 
            this.tbxCopyTo.Location = new System.Drawing.Point(70, 70);
            this.tbxCopyTo.Name = "tbxCopyTo";
            this.tbxCopyTo.Size = new System.Drawing.Size(687, 21);
            this.tbxCopyTo.TabIndex = 4;
            // 
            // lblCopyTo
            // 
            this.lblCopyTo.AutoSize = true;
            this.lblCopyTo.Location = new System.Drawing.Point(35, 73);
            this.lblCopyTo.Name = "lblCopyTo";
            this.lblCopyTo.Size = new System.Drawing.Size(29, 12);
            this.lblCopyTo.TabIndex = 3;
            this.lblCopyTo.Text = "目标";
            // 
            // tbxCopyFrom
            // 
            this.tbxCopyFrom.Location = new System.Drawing.Point(70, 34);
            this.tbxCopyFrom.Name = "tbxCopyFrom";
            this.tbxCopyFrom.Size = new System.Drawing.Size(687, 21);
            this.tbxCopyFrom.TabIndex = 2;
            // 
            // lblCopyFrom
            // 
            this.lblCopyFrom.AutoSize = true;
            this.lblCopyFrom.Location = new System.Drawing.Point(35, 37);
            this.lblCopyFrom.Name = "lblCopyFrom";
            this.lblCopyFrom.Size = new System.Drawing.Size(29, 12);
            this.lblCopyFrom.TabIndex = 1;
            this.lblCopyFrom.Text = "来源";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(327, 323);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 0;
            this.btnCopy.Text = "执行";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // DocumentDel
            // 
            this.DocumentDel.Controls.Add(this.gbxDelRight);
            this.DocumentDel.Controls.Add(this.btnDelete);
            this.DocumentDel.Controls.Add(this.gbxDelDirectory);
            this.DocumentDel.Controls.Add(this.gbxDelFile);
            this.DocumentDel.Controls.Add(this.tbxDelTarget);
            this.DocumentDel.Controls.Add(this.lblDelTarget);
            this.DocumentDel.Location = new System.Drawing.Point(4, 22);
            this.DocumentDel.Name = "DocumentDel";
            this.DocumentDel.Padding = new System.Windows.Forms.Padding(3);
            this.DocumentDel.Size = new System.Drawing.Size(816, 384);
            this.DocumentDel.TabIndex = 6;
            this.DocumentDel.Text = "文件夹删除";
            this.DocumentDel.UseVisualStyleBackColor = true;
            // 
            // gbxDelRight
            // 
            this.gbxDelRight.Controls.Add(this.rbtDelDirectoryFirst);
            this.gbxDelRight.Controls.Add(this.rbtDelFileFirst);
            this.gbxDelRight.Location = new System.Drawing.Point(48, 258);
            this.gbxDelRight.Name = "gbxDelRight";
            this.gbxDelRight.Size = new System.Drawing.Size(136, 85);
            this.gbxDelRight.TabIndex = 15;
            this.gbxDelRight.TabStop = false;
            this.gbxDelRight.Text = "优先级";
            // 
            // rbtDelDirectoryFirst
            // 
            this.rbtDelDirectoryFirst.AutoSize = true;
            this.rbtDelDirectoryFirst.Checked = true;
            this.rbtDelDirectoryFirst.Location = new System.Drawing.Point(7, 24);
            this.rbtDelDirectoryFirst.Name = "rbtDelDirectoryFirst";
            this.rbtDelDirectoryFirst.Size = new System.Drawing.Size(83, 16);
            this.rbtDelDirectoryFirst.TabIndex = 5;
            this.rbtDelDirectoryFirst.TabStop = true;
            this.rbtDelDirectoryFirst.Text = "文件夹优先";
            this.rbtDelDirectoryFirst.UseVisualStyleBackColor = true;
            // 
            // rbtDelFileFirst
            // 
            this.rbtDelFileFirst.AutoSize = true;
            this.rbtDelFileFirst.Location = new System.Drawing.Point(7, 46);
            this.rbtDelFileFirst.Name = "rbtDelFileFirst";
            this.rbtDelFileFirst.Size = new System.Drawing.Size(71, 16);
            this.rbtDelFileFirst.TabIndex = 6;
            this.rbtDelFileFirst.TabStop = true;
            this.rbtDelFileFirst.Text = "文件优先";
            this.rbtDelFileFirst.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(362, 301);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "执行";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gbxDelDirectory
            // 
            this.gbxDelDirectory.Controls.Add(this.tbxDelDirectorys);
            this.gbxDelDirectory.Controls.Add(this.rbtDelRemoveDirectory);
            this.gbxDelDirectory.Controls.Add(this.rbtDelKeepDirectory);
            this.gbxDelDirectory.Location = new System.Drawing.Point(48, 64);
            this.gbxDelDirectory.Name = "gbxDelDirectory";
            this.gbxDelDirectory.Size = new System.Drawing.Size(720, 85);
            this.gbxDelDirectory.TabIndex = 15;
            this.gbxDelDirectory.TabStop = false;
            this.gbxDelDirectory.Text = "文件夹（分号分隔）";
            // 
            // tbxDelDirectorys
            // 
            this.tbxDelDirectorys.Location = new System.Drawing.Point(100, 35);
            this.tbxDelDirectorys.Name = "tbxDelDirectorys";
            this.tbxDelDirectorys.Size = new System.Drawing.Size(603, 21);
            this.tbxDelDirectorys.TabIndex = 7;
            // 
            // rbtDelRemoveDirectory
            // 
            this.rbtDelRemoveDirectory.AutoSize = true;
            this.rbtDelRemoveDirectory.Checked = true;
            this.rbtDelRemoveDirectory.Location = new System.Drawing.Point(7, 24);
            this.rbtDelRemoveDirectory.Name = "rbtDelRemoveDirectory";
            this.rbtDelRemoveDirectory.Size = new System.Drawing.Size(83, 16);
            this.rbtDelRemoveDirectory.TabIndex = 5;
            this.rbtDelRemoveDirectory.TabStop = true;
            this.rbtDelRemoveDirectory.Text = "删除文件夹";
            this.rbtDelRemoveDirectory.UseVisualStyleBackColor = true;
            // 
            // rbtDelKeepDirectory
            // 
            this.rbtDelKeepDirectory.AutoSize = true;
            this.rbtDelKeepDirectory.Location = new System.Drawing.Point(7, 46);
            this.rbtDelKeepDirectory.Name = "rbtDelKeepDirectory";
            this.rbtDelKeepDirectory.Size = new System.Drawing.Size(83, 16);
            this.rbtDelKeepDirectory.TabIndex = 6;
            this.rbtDelKeepDirectory.TabStop = true;
            this.rbtDelKeepDirectory.Text = "保留文件夹";
            this.rbtDelKeepDirectory.UseVisualStyleBackColor = true;
            // 
            // gbxDelFile
            // 
            this.gbxDelFile.Controls.Add(this.tbxDelFiles);
            this.gbxDelFile.Controls.Add(this.rbtDelRemoveFile);
            this.gbxDelFile.Controls.Add(this.rbtDelKeepFile);
            this.gbxDelFile.Location = new System.Drawing.Point(48, 158);
            this.gbxDelFile.Name = "gbxDelFile";
            this.gbxDelFile.Size = new System.Drawing.Size(720, 85);
            this.gbxDelFile.TabIndex = 14;
            this.gbxDelFile.TabStop = false;
            this.gbxDelFile.Text = "文件（分号分隔）";
            // 
            // tbxDelFiles
            // 
            this.tbxDelFiles.Location = new System.Drawing.Point(100, 35);
            this.tbxDelFiles.Name = "tbxDelFiles";
            this.tbxDelFiles.Size = new System.Drawing.Size(603, 21);
            this.tbxDelFiles.TabIndex = 7;
            // 
            // rbtDelRemoveFile
            // 
            this.rbtDelRemoveFile.AutoSize = true;
            this.rbtDelRemoveFile.Location = new System.Drawing.Point(7, 24);
            this.rbtDelRemoveFile.Name = "rbtDelRemoveFile";
            this.rbtDelRemoveFile.Size = new System.Drawing.Size(71, 16);
            this.rbtDelRemoveFile.TabIndex = 5;
            this.rbtDelRemoveFile.TabStop = true;
            this.rbtDelRemoveFile.Text = "删除文件";
            this.rbtDelRemoveFile.UseVisualStyleBackColor = true;
            // 
            // rbtDelKeepFile
            // 
            this.rbtDelKeepFile.AutoSize = true;
            this.rbtDelKeepFile.Checked = true;
            this.rbtDelKeepFile.Location = new System.Drawing.Point(7, 46);
            this.rbtDelKeepFile.Name = "rbtDelKeepFile";
            this.rbtDelKeepFile.Size = new System.Drawing.Size(71, 16);
            this.rbtDelKeepFile.TabIndex = 6;
            this.rbtDelKeepFile.TabStop = true;
            this.rbtDelKeepFile.Text = "保留文件";
            this.rbtDelKeepFile.UseVisualStyleBackColor = true;
            // 
            // tbxDelTarget
            // 
            this.tbxDelTarget.Location = new System.Drawing.Point(81, 34);
            this.tbxDelTarget.Name = "tbxDelTarget";
            this.tbxDelTarget.Size = new System.Drawing.Size(687, 21);
            this.tbxDelTarget.TabIndex = 13;
            // 
            // lblDelTarget
            // 
            this.lblDelTarget.AutoSize = true;
            this.lblDelTarget.Location = new System.Drawing.Point(46, 37);
            this.lblDelTarget.Name = "lblDelTarget";
            this.lblDelTarget.Size = new System.Drawing.Size(29, 12);
            this.lblDelTarget.TabIndex = 12;
            this.lblDelTarget.Text = "目标";
            // 
            // IPChange
            // 
            this.IPChange.Controls.Add(this.btnIPAuto);
            this.IPChange.Controls.Add(this.btnIPUse);
            this.IPChange.Controls.Add(this.btnIPReplaceScheme);
            this.IPChange.Controls.Add(this.btnIPDelete);
            this.IPChange.Controls.Add(this.btnIPEdit);
            this.IPChange.Controls.Add(this.btnIPAdd);
            this.IPChange.Controls.Add(this.lblIPName);
            this.IPChange.Controls.Add(this.tbxIPName);
            this.IPChange.Controls.Add(this.lblDNSServerSpare);
            this.IPChange.Controls.Add(this.tbxDNSServerSpare);
            this.IPChange.Controls.Add(this.lblDNSServerSearchOrder);
            this.IPChange.Controls.Add(this.tbxDNSServerSearchOrder);
            this.IPChange.Controls.Add(this.lblDefaultIPGateWay);
            this.IPChange.Controls.Add(this.tbxDefaultIPGateWay);
            this.IPChange.Controls.Add(this.lblSubNetMask);
            this.IPChange.Controls.Add(this.tbxSubNetMask);
            this.IPChange.Controls.Add(this.lblIPAddress);
            this.IPChange.Controls.Add(this.tbxIPAddress);
            this.IPChange.Controls.Add(this.lblIPTree);
            this.IPChange.Controls.Add(this.IPTree);
            this.IPChange.Location = new System.Drawing.Point(4, 22);
            this.IPChange.Name = "IPChange";
            this.IPChange.Padding = new System.Windows.Forms.Padding(3);
            this.IPChange.Size = new System.Drawing.Size(816, 384);
            this.IPChange.TabIndex = 0;
            this.IPChange.Text = "IP切换";
            this.IPChange.UseVisualStyleBackColor = true;
            // 
            // btnIPAuto
            // 
            this.btnIPAuto.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIPAuto.Location = new System.Drawing.Point(573, 333);
            this.btnIPAuto.Name = "btnIPAuto";
            this.btnIPAuto.Size = new System.Drawing.Size(92, 26);
            this.btnIPAuto.TabIndex = 19;
            this.btnIPAuto.Text = "自动获取IP";
            this.btnIPAuto.UseVisualStyleBackColor = true;
            this.btnIPAuto.Click += new System.EventHandler(this.btnIPAuto_Click);
            // 
            // btnIPUse
            // 
            this.btnIPUse.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIPUse.Location = new System.Drawing.Point(355, 322);
            this.btnIPUse.Name = "btnIPUse";
            this.btnIPUse.Size = new System.Drawing.Size(92, 43);
            this.btnIPUse.TabIndex = 18;
            this.btnIPUse.Text = "应用";
            this.btnIPUse.UseVisualStyleBackColor = true;
            this.btnIPUse.Click += new System.EventHandler(this.btnIPUse_Click);
            // 
            // btnIPReplaceScheme
            // 
            this.btnIPReplaceScheme.Location = new System.Drawing.Point(647, 277);
            this.btnIPReplaceScheme.Name = "btnIPReplaceScheme";
            this.btnIPReplaceScheme.Size = new System.Drawing.Size(75, 23);
            this.btnIPReplaceScheme.TabIndex = 17;
            this.btnIPReplaceScheme.Text = "替换方案";
            this.btnIPReplaceScheme.UseVisualStyleBackColor = true;
            // 
            // btnIPDelete
            // 
            this.btnIPDelete.Location = new System.Drawing.Point(516, 277);
            this.btnIPDelete.Name = "btnIPDelete";
            this.btnIPDelete.Size = new System.Drawing.Size(75, 23);
            this.btnIPDelete.TabIndex = 16;
            this.btnIPDelete.Text = "删除";
            this.btnIPDelete.UseVisualStyleBackColor = true;
            this.btnIPDelete.Click += new System.EventHandler(this.btnIPDelete_Click);
            // 
            // btnIPEdit
            // 
            this.btnIPEdit.Location = new System.Drawing.Point(389, 277);
            this.btnIPEdit.Name = "btnIPEdit";
            this.btnIPEdit.Size = new System.Drawing.Size(75, 23);
            this.btnIPEdit.TabIndex = 15;
            this.btnIPEdit.Text = "修改";
            this.btnIPEdit.UseVisualStyleBackColor = true;
            this.btnIPEdit.Click += new System.EventHandler(this.btnIPEdit_Click);
            // 
            // btnIPAdd
            // 
            this.btnIPAdd.Location = new System.Drawing.Point(264, 277);
            this.btnIPAdd.Name = "btnIPAdd";
            this.btnIPAdd.Size = new System.Drawing.Size(75, 23);
            this.btnIPAdd.TabIndex = 14;
            this.btnIPAdd.Text = "添加";
            this.btnIPAdd.UseVisualStyleBackColor = true;
            this.btnIPAdd.Click += new System.EventHandler(this.btnIPAdd_Click);
            // 
            // lblIPName
            // 
            this.lblIPName.AutoSize = true;
            this.lblIPName.Location = new System.Drawing.Point(216, 42);
            this.lblIPName.Name = "lblIPName";
            this.lblIPName.Size = new System.Drawing.Size(29, 12);
            this.lblIPName.TabIndex = 13;
            this.lblIPName.Text = "名称";
            // 
            // tbxIPName
            // 
            this.tbxIPName.Location = new System.Drawing.Point(309, 39);
            this.tbxIPName.Name = "tbxIPName";
            this.tbxIPName.Size = new System.Drawing.Size(470, 21);
            this.tbxIPName.TabIndex = 12;
            // 
            // lblDNSServerSpare
            // 
            this.lblDNSServerSpare.AutoSize = true;
            this.lblDNSServerSpare.Location = new System.Drawing.Point(216, 229);
            this.lblDNSServerSpare.Name = "lblDNSServerSpare";
            this.lblDNSServerSpare.Size = new System.Drawing.Size(83, 12);
            this.lblDNSServerSpare.TabIndex = 11;
            this.lblDNSServerSpare.Text = "备用DNS服务器";
            // 
            // tbxDNSServerSpare
            // 
            this.tbxDNSServerSpare.Location = new System.Drawing.Point(309, 226);
            this.tbxDNSServerSpare.Name = "tbxDNSServerSpare";
            this.tbxDNSServerSpare.Size = new System.Drawing.Size(470, 21);
            this.tbxDNSServerSpare.TabIndex = 10;
            // 
            // lblDNSServerSearchOrder
            // 
            this.lblDNSServerSearchOrder.AutoSize = true;
            this.lblDNSServerSearchOrder.Location = new System.Drawing.Point(216, 193);
            this.lblDNSServerSearchOrder.Name = "lblDNSServerSearchOrder";
            this.lblDNSServerSearchOrder.Size = new System.Drawing.Size(83, 12);
            this.lblDNSServerSearchOrder.TabIndex = 9;
            this.lblDNSServerSearchOrder.Text = "首选DNS服务器";
            // 
            // tbxDNSServerSearchOrder
            // 
            this.tbxDNSServerSearchOrder.Location = new System.Drawing.Point(309, 190);
            this.tbxDNSServerSearchOrder.Name = "tbxDNSServerSearchOrder";
            this.tbxDNSServerSearchOrder.Size = new System.Drawing.Size(470, 21);
            this.tbxDNSServerSearchOrder.TabIndex = 8;
            // 
            // lblDefaultIPGateWay
            // 
            this.lblDefaultIPGateWay.AutoSize = true;
            this.lblDefaultIPGateWay.Location = new System.Drawing.Point(216, 157);
            this.lblDefaultIPGateWay.Name = "lblDefaultIPGateWay";
            this.lblDefaultIPGateWay.Size = new System.Drawing.Size(53, 12);
            this.lblDefaultIPGateWay.TabIndex = 7;
            this.lblDefaultIPGateWay.Text = "默认网关";
            // 
            // tbxDefaultIPGateWay
            // 
            this.tbxDefaultIPGateWay.Location = new System.Drawing.Point(309, 154);
            this.tbxDefaultIPGateWay.Name = "tbxDefaultIPGateWay";
            this.tbxDefaultIPGateWay.Size = new System.Drawing.Size(470, 21);
            this.tbxDefaultIPGateWay.TabIndex = 6;
            // 
            // lblSubNetMask
            // 
            this.lblSubNetMask.AutoSize = true;
            this.lblSubNetMask.Location = new System.Drawing.Point(216, 120);
            this.lblSubNetMask.Name = "lblSubNetMask";
            this.lblSubNetMask.Size = new System.Drawing.Size(53, 12);
            this.lblSubNetMask.TabIndex = 5;
            this.lblSubNetMask.Text = "子网掩码";
            // 
            // tbxSubNetMask
            // 
            this.tbxSubNetMask.Location = new System.Drawing.Point(309, 117);
            this.tbxSubNetMask.Name = "tbxSubNetMask";
            this.tbxSubNetMask.Size = new System.Drawing.Size(470, 21);
            this.tbxSubNetMask.TabIndex = 4;
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Location = new System.Drawing.Point(216, 82);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(41, 12);
            this.lblIPAddress.TabIndex = 3;
            this.lblIPAddress.Text = "IP地址";
            // 
            // tbxIPAddress
            // 
            this.tbxIPAddress.Location = new System.Drawing.Point(309, 79);
            this.tbxIPAddress.Name = "tbxIPAddress";
            this.tbxIPAddress.Size = new System.Drawing.Size(470, 21);
            this.tbxIPAddress.TabIndex = 2;
            // 
            // lblIPTree
            // 
            this.lblIPTree.AutoSize = true;
            this.lblIPTree.Location = new System.Drawing.Point(63, 15);
            this.lblIPTree.Name = "lblIPTree";
            this.lblIPTree.Size = new System.Drawing.Size(41, 12);
            this.lblIPTree.TabIndex = 1;
            this.lblIPTree.Text = "IP方案";
            // 
            // IPTree
            // 
            this.IPTree.Location = new System.Drawing.Point(0, 39);
            this.IPTree.Name = "IPTree";
            this.IPTree.Size = new System.Drawing.Size(176, 345);
            this.IPTree.TabIndex = 0;
            this.IPTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.IPTree_AfterSelect);
            // 
            // ConfigChange
            // 
            this.ConfigChange.Controls.Add(this.btnConfigText);
            this.ConfigChange.Controls.Add(this.lblConfigIP);
            this.ConfigChange.Controls.Add(this.tbxConfigIP);
            this.ConfigChange.Controls.Add(this.btnConfigUse);
            this.ConfigChange.Controls.Add(this.btnConfigDelete);
            this.ConfigChange.Controls.Add(this.btnConfigEdit);
            this.ConfigChange.Controls.Add(this.btnConfigAdd);
            this.ConfigChange.Controls.Add(this.lblConfigName);
            this.ConfigChange.Controls.Add(this.tbxConfigName);
            this.ConfigChange.Controls.Add(this.lblConfigTree);
            this.ConfigChange.Controls.Add(this.ConfigTree);
            this.ConfigChange.Location = new System.Drawing.Point(4, 22);
            this.ConfigChange.Name = "ConfigChange";
            this.ConfigChange.Padding = new System.Windows.Forms.Padding(3);
            this.ConfigChange.Size = new System.Drawing.Size(816, 384);
            this.ConfigChange.TabIndex = 1;
            this.ConfigChange.Text = "配置切换";
            this.ConfigChange.UseVisualStyleBackColor = true;
            // 
            // btnConfigText
            // 
            this.btnConfigText.Location = new System.Drawing.Point(701, 76);
            this.btnConfigText.Name = "btnConfigText";
            this.btnConfigText.Size = new System.Drawing.Size(75, 23);
            this.btnConfigText.TabIndex = 26;
            this.btnConfigText.Text = "维护明细";
            this.btnConfigText.UseVisualStyleBackColor = true;
            this.btnConfigText.Click += new System.EventHandler(this.btnConfigText_Click);
            // 
            // lblConfigIP
            // 
            this.lblConfigIP.AutoSize = true;
            this.lblConfigIP.Location = new System.Drawing.Point(230, 264);
            this.lblConfigIP.Name = "lblConfigIP";
            this.lblConfigIP.Size = new System.Drawing.Size(17, 12);
            this.lblConfigIP.TabIndex = 25;
            this.lblConfigIP.Text = "IP";
            // 
            // tbxConfigIP
            // 
            this.tbxConfigIP.Location = new System.Drawing.Point(274, 264);
            this.tbxConfigIP.Name = "tbxConfigIP";
            this.tbxConfigIP.Size = new System.Drawing.Size(508, 21);
            this.tbxConfigIP.TabIndex = 24;
            // 
            // btnConfigUse
            // 
            this.btnConfigUse.Location = new System.Drawing.Point(490, 308);
            this.btnConfigUse.Name = "btnConfigUse";
            this.btnConfigUse.Size = new System.Drawing.Size(75, 23);
            this.btnConfigUse.TabIndex = 23;
            this.btnConfigUse.Text = "应用";
            this.btnConfigUse.UseVisualStyleBackColor = true;
            this.btnConfigUse.Click += new System.EventHandler(this.btnConfigUse_Click);
            // 
            // btnConfigDelete
            // 
            this.btnConfigDelete.Location = new System.Drawing.Point(555, 76);
            this.btnConfigDelete.Name = "btnConfigDelete";
            this.btnConfigDelete.Size = new System.Drawing.Size(75, 23);
            this.btnConfigDelete.TabIndex = 22;
            this.btnConfigDelete.Text = "删除方案";
            this.btnConfigDelete.UseVisualStyleBackColor = true;
            this.btnConfigDelete.Click += new System.EventHandler(this.btnConfigDelete_Click);
            // 
            // btnConfigEdit
            // 
            this.btnConfigEdit.Location = new System.Drawing.Point(411, 76);
            this.btnConfigEdit.Name = "btnConfigEdit";
            this.btnConfigEdit.Size = new System.Drawing.Size(75, 23);
            this.btnConfigEdit.TabIndex = 21;
            this.btnConfigEdit.Text = "修改方案";
            this.btnConfigEdit.UseVisualStyleBackColor = true;
            this.btnConfigEdit.Click += new System.EventHandler(this.btnConfigEdit_Click);
            // 
            // btnConfigAdd
            // 
            this.btnConfigAdd.Location = new System.Drawing.Point(277, 76);
            this.btnConfigAdd.Name = "btnConfigAdd";
            this.btnConfigAdd.Size = new System.Drawing.Size(75, 23);
            this.btnConfigAdd.TabIndex = 20;
            this.btnConfigAdd.Text = "添加方案";
            this.btnConfigAdd.UseVisualStyleBackColor = true;
            this.btnConfigAdd.Click += new System.EventHandler(this.btnConfigAdd_Click);
            // 
            // lblConfigName
            // 
            this.lblConfigName.AutoSize = true;
            this.lblConfigName.Location = new System.Drawing.Point(230, 36);
            this.lblConfigName.Name = "lblConfigName";
            this.lblConfigName.Size = new System.Drawing.Size(29, 12);
            this.lblConfigName.TabIndex = 19;
            this.lblConfigName.Text = "名称";
            // 
            // tbxConfigName
            // 
            this.tbxConfigName.Location = new System.Drawing.Point(274, 33);
            this.tbxConfigName.Name = "tbxConfigName";
            this.tbxConfigName.Size = new System.Drawing.Size(508, 21);
            this.tbxConfigName.TabIndex = 18;
            // 
            // lblConfigTree
            // 
            this.lblConfigTree.AutoSize = true;
            this.lblConfigTree.Location = new System.Drawing.Point(70, 9);
            this.lblConfigTree.Name = "lblConfigTree";
            this.lblConfigTree.Size = new System.Drawing.Size(53, 12);
            this.lblConfigTree.TabIndex = 3;
            this.lblConfigTree.Text = "配置方案";
            // 
            // ConfigTree
            // 
            this.ConfigTree.Location = new System.Drawing.Point(7, 33);
            this.ConfigTree.Name = "ConfigTree";
            this.ConfigTree.Size = new System.Drawing.Size(176, 345);
            this.ConfigTree.TabIndex = 2;
            this.ConfigTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ConfigTree_AfterSelect);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.常规ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(823, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 常规ToolStripMenuItem
            // 
            this.常规ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据源ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.常规ToolStripMenuItem.Name = "常规ToolStripMenuItem";
            this.常规ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.常规ToolStripMenuItem.Text = "常规";
            // 
            // 数据源ToolStripMenuItem
            // 
            this.数据源ToolStripMenuItem.Name = "数据源ToolStripMenuItem";
            this.数据源ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.数据源ToolStripMenuItem.Text = "数据源";
            this.数据源ToolStripMenuItem.Click += new System.EventHandler(this.数据源ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 444);
            this.Controls.Add(this.MainContral);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(839, 483);
            this.MinimumSize = new System.Drawing.Size(839, 483);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainContral.ResumeLayout(false);
            this.OutputInsert.ResumeLayout(false);
            this.OutputInsert.PerformLayout();
            this.DataOper.ResumeLayout(false);
            this.DataOper.PerformLayout();
            this.gbxBak.ResumeLayout(false);
            this.gbxBak.PerformLayout();
            this.gbxDeleteSql.ResumeLayout(false);
            this.gbxDeleteSql.PerformLayout();
            this.DataDiff.ResumeLayout(false);
            this.GroupBoxType.ResumeLayout(false);
            this.GroupBoxType.PerformLayout();
            this.groupBoxStruct.ResumeLayout(false);
            this.groupBoxStruct.PerformLayout();
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.groupBoxTo.ResumeLayout(false);
            this.groupBoxTo.PerformLayout();
            this.groupBoxFrom.ResumeLayout(false);
            this.groupBoxFrom.PerformLayout();
            this.CodeTemplete.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.DocumentCopy.ResumeLayout(false);
            this.DocumentCopy.PerformLayout();
            this.gbxCopyDirectorys.ResumeLayout(false);
            this.gbxCopyDirectorys.PerformLayout();
            this.gbxCopyFile.ResumeLayout(false);
            this.gbxCopyFile.PerformLayout();
            this.DocumentDel.ResumeLayout(false);
            this.DocumentDel.PerformLayout();
            this.gbxDelRight.ResumeLayout(false);
            this.gbxDelRight.PerformLayout();
            this.gbxDelDirectory.ResumeLayout(false);
            this.gbxDelDirectory.PerformLayout();
            this.gbxDelFile.ResumeLayout(false);
            this.gbxDelFile.PerformLayout();
            this.IPChange.ResumeLayout(false);
            this.IPChange.PerformLayout();
            this.ConfigChange.ResumeLayout(false);
            this.ConfigChange.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl MainContral;
        private System.Windows.Forms.TabPage DataDiff;
        private System.Windows.Forms.TabPage DataOper;
        private System.Windows.Forms.TabPage DocumentCopy;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 常规ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据源ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbxInsert;
        private System.Windows.Forms.CheckBox cbxSelect;
        private System.Windows.Forms.GroupBox groupBoxTo;
        private System.Windows.Forms.TextBox tbxWhereStrTo;
        private System.Windows.Forms.Label lblWhereStrTo;
        private System.Windows.Forms.ComboBox TableListTo;
        private System.Windows.Forms.Label lblTableTo;
        private System.Windows.Forms.ComboBox SourceListTo;
        private System.Windows.Forms.Label lblSourcesTo;
        private System.Windows.Forms.GroupBox groupBoxFrom;
        private System.Windows.Forms.TextBox tbxWhereStrFrom;
        private System.Windows.Forms.Label lblWhereStrFrom;
        private System.Windows.Forms.ComboBox TableListFrom;
        private System.Windows.Forms.Label lblTableFrom;
        private System.Windows.Forms.ComboBox SourceListFrom;
        private System.Windows.Forms.Label lblSourcesFrom;
        private System.Windows.Forms.Button btnDataDiffOK;
        private System.Windows.Forms.Button btnDataOperOK;
        private System.Windows.Forms.Label lblOperatorSourse;
        private System.Windows.Forms.CheckBox cbxBackupDelete;
        private System.Windows.Forms.TabPage DocumentDel;
        private System.Windows.Forms.RadioButton rbtOnlyCopyFiles;
        private System.Windows.Forms.RadioButton rbtRemoveCopyFiles;
        private System.Windows.Forms.TextBox tbxCopyTo;
        private System.Windows.Forms.Label lblCopyTo;
        private System.Windows.Forms.TextBox tbxCopyFrom;
        private System.Windows.Forms.Label lblCopyFrom;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox tbxCopyFiles;
        private System.Windows.Forms.GroupBox gbxCopyFile;
        private System.Windows.Forms.GroupBox gbxCopyDirectorys;
        private System.Windows.Forms.TextBox tbxCopyDirectorys;
        private System.Windows.Forms.RadioButton rbtRemoveCopyDirectorys;
        private System.Windows.Forms.RadioButton rbtOnlyCopyDirectorys;
        private System.Windows.Forms.CheckBox cbxReplaceFile;
        private System.Windows.Forms.GroupBox gbxDelRight;
        private System.Windows.Forms.RadioButton rbtDelDirectoryFirst;
        private System.Windows.Forms.RadioButton rbtDelFileFirst;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gbxDelDirectory;
        private System.Windows.Forms.TextBox tbxDelDirectorys;
        private System.Windows.Forms.RadioButton rbtDelRemoveDirectory;
        private System.Windows.Forms.RadioButton rbtDelKeepDirectory;
        private System.Windows.Forms.GroupBox gbxDelFile;
        private System.Windows.Forms.TextBox tbxDelFiles;
        private System.Windows.Forms.RadioButton rbtDelRemoveFile;
        private System.Windows.Forms.RadioButton rbtDelKeepFile;
        private System.Windows.Forms.TextBox tbxDelTarget;
        private System.Windows.Forms.Label lblDelTarget;
        private System.Windows.Forms.TabPage IPChange;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.TextBox tbxIPAddress;
        private System.Windows.Forms.Label lblIPTree;
        private System.Windows.Forms.TreeView IPTree;
        private System.Windows.Forms.Label lblDNSServerSpare;
        private System.Windows.Forms.TextBox tbxDNSServerSpare;
        private System.Windows.Forms.Label lblDNSServerSearchOrder;
        private System.Windows.Forms.TextBox tbxDNSServerSearchOrder;
        private System.Windows.Forms.Label lblDefaultIPGateWay;
        private System.Windows.Forms.TextBox tbxDefaultIPGateWay;
        private System.Windows.Forms.Label lblSubNetMask;
        private System.Windows.Forms.TextBox tbxSubNetMask;
        private System.Windows.Forms.Label lblIPName;
        private System.Windows.Forms.TextBox tbxIPName;
        private System.Windows.Forms.Button btnIPReplaceScheme;
        private System.Windows.Forms.Button btnIPDelete;
        private System.Windows.Forms.Button btnIPEdit;
        private System.Windows.Forms.Button btnIPAdd;
        private System.Windows.Forms.Button btnIPUse;
        private System.Windows.Forms.GroupBox GroupBoxType;
        private System.Windows.Forms.RadioButton rdbStruct;
        private System.Windows.Forms.RadioButton rdbData;
        private System.Windows.Forms.GroupBox groupBoxStruct;
        private System.Windows.Forms.CheckBox cbxSameName;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.ListBox OperatorSourcesList;
        private System.Windows.Forms.GroupBox gbxBak;
        private System.Windows.Forms.TextBox tbxBakPath;
        private System.Windows.Forms.CheckBox cbxBackUpDataBase;
        private System.Windows.Forms.CheckBox cbxCompressBak;
        private System.Windows.Forms.Label lblBakPath;
        private System.Windows.Forms.GroupBox gbxDeleteSql;
        private System.Windows.Forms.TabPage ConfigChange;
        private System.Windows.Forms.Label lblConfigTree;
        private System.Windows.Forms.TreeView ConfigTree;
        private System.Windows.Forms.Label lblConfigIP;
        private System.Windows.Forms.TextBox tbxConfigIP;
        private System.Windows.Forms.Button btnConfigUse;
        private System.Windows.Forms.Button btnConfigDelete;
        private System.Windows.Forms.Button btnConfigEdit;
        private System.Windows.Forms.Button btnConfigAdd;
        private System.Windows.Forms.Label lblConfigName;
        private System.Windows.Forms.TextBox tbxConfigName;
        private System.Windows.Forms.Button btnConfigText;
        private System.Windows.Forms.TabPage OutputInsert;
        private System.Windows.Forms.ListBox OutputList;
        private System.Windows.Forms.Label lblOutputSource;
        private System.Windows.Forms.Label lblOutputTableName;
        private System.Windows.Forms.TextBox tbxOutputTableName;
        private System.Windows.Forms.Label lblOutputName;
        private System.Windows.Forms.TextBox tbxOutputName;
        private System.Windows.Forms.Label lblOutputSelectSql;
        private System.Windows.Forms.ComboBox cbbOutputDataSet;
        private System.Windows.Forms.Label lblOutputDataSet;
        private System.Windows.Forms.TextBox tbxOutputSql;
        private System.Windows.Forms.Button btnOutputAdd;
        private System.Windows.Forms.Button btnOutputModify;
        private System.Windows.Forms.Button btnOutputDelete;
        private System.Windows.Forms.Button btnOutputOK;
        private System.Windows.Forms.CheckBox cbxBackupInsert;
        private System.Windows.Forms.CheckBox cbxOutputDelete;
        private System.Windows.Forms.TextBox tbxOutputDelete;
        private System.Windows.Forms.Label lblOutputDeleteSql;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIPAuto;
        private System.Windows.Forms.Button btnDataOperClearLog;
        private System.Windows.Forms.TabPage CodeTemplete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCodeRun;
        private System.Windows.Forms.ComboBox cbbCodeTemplete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxCodeOther;
        private System.Windows.Forms.ComboBox cbbCodeDataTable;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbbCodeDataSource;
        private System.Windows.Forms.Label label9;
    }
}

