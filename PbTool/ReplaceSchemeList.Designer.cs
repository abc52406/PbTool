namespace PbTool
{
    partial class ReplaceSchemeList
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
            this.DataTree = new System.Windows.Forms.TreeView();
            this.lblName = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbxContent = new System.Windows.Forms.TextBox();
            this.lblStr = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.cbbConfigType = new System.Windows.Forms.ComboBox();
            this.cbbDataBase = new System.Windows.Forms.ComboBox();
            this.lblDataBase = new System.Windows.Forms.Label();
            this.tbxPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnPath = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // DataTree
            // 
            this.DataTree.Location = new System.Drawing.Point(12, 37);
            this.DataTree.Name = "DataTree";
            this.DataTree.Size = new System.Drawing.Size(161, 379);
            this.DataTree.TabIndex = 0;
            this.DataTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DataTree_AfterSelect);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(197, 40);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 12);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "名称";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(265, 37);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(160, 21);
            this.tbxName.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(39, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbxContent
            // 
            this.tbxContent.Location = new System.Drawing.Point(199, 167);
            this.tbxContent.Multiline = true;
            this.tbxContent.Name = "tbxContent";
            this.tbxContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxContent.Size = new System.Drawing.Size(226, 211);
            this.tbxContent.TabIndex = 5;
            // 
            // lblStr
            // 
            this.lblStr.AutoSize = true;
            this.lblStr.Location = new System.Drawing.Point(293, 147);
            this.lblStr.Name = "lblStr";
            this.lblStr.Size = new System.Drawing.Size(29, 12);
            this.lblStr.TabIndex = 4;
            this.lblStr.Text = "内容";
            this.lblStr.Click += new System.EventHandler(this.lblStr_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(57, 8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(39, 23);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(102, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(39, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(279, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "退出";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(197, 68);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(29, 12);
            this.lblFilePath.TabIndex = 12;
            this.lblFilePath.Text = "类型";
            // 
            // cbbConfigType
            // 
            this.cbbConfigType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbConfigType.FormattingEnabled = true;
            this.cbbConfigType.Items.AddRange(new object[] {
            "Text",
            "Sql"});
            this.cbbConfigType.Location = new System.Drawing.Point(265, 64);
            this.cbbConfigType.Name = "cbbConfigType";
            this.cbbConfigType.Size = new System.Drawing.Size(160, 20);
            this.cbbConfigType.TabIndex = 13;
            // 
            // cbbDataBase
            // 
            this.cbbDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDataBase.FormattingEnabled = true;
            this.cbbDataBase.Location = new System.Drawing.Point(265, 119);
            this.cbbDataBase.Name = "cbbDataBase";
            this.cbbDataBase.Size = new System.Drawing.Size(160, 20);
            this.cbbDataBase.TabIndex = 15;
            // 
            // lblDataBase
            // 
            this.lblDataBase.AutoSize = true;
            this.lblDataBase.Location = new System.Drawing.Point(197, 123);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(41, 12);
            this.lblDataBase.TabIndex = 14;
            this.lblDataBase.Text = "数据库";
            // 
            // tbxPath
            // 
            this.tbxPath.Location = new System.Drawing.Point(265, 91);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.Size = new System.Drawing.Size(135, 21);
            this.tbxPath.TabIndex = 17;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(197, 94);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(29, 12);
            this.lblPath.TabIndex = 16;
            this.lblPath.Text = "文件";
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(399, 91);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(26, 23);
            this.btnPath.TabIndex = 18;
            this.btnPath.Text = "...";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ReplaceSchemeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(450, 428);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.tbxPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.cbbDataBase);
            this.Controls.Add(this.lblDataBase);
            this.Controls.Add(this.cbbConfigType);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.tbxContent);
            this.Controls.Add(this.lblStr);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.DataTree);
            this.MaximumSize = new System.Drawing.Size(466, 466);
            this.MinimumSize = new System.Drawing.Size(466, 466);
            this.Name = "ReplaceSchemeList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "方案明细";
            this.Load += new System.EventHandler(this.DataConnectList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView DataTree;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbxContent;
        private System.Windows.Forms.Label lblStr;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.ComboBox cbbConfigType;
        private System.Windows.Forms.ComboBox cbbDataBase;
        private System.Windows.Forms.Label lblDataBase;
        private System.Windows.Forms.TextBox tbxPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}