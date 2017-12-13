using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pb.Library;
using System.Configuration;
using System.Xml;
using System.Data.Common;
using System.IO;

namespace PbTool
{
    public partial class MainForm : Form
    {
        #region 私有变量
        private XmlHelper docoper;
        private Dictionary<string, Tuple<string,string>> dataSourceList = new Dictionary<string, Tuple<string, string>>();
        private DBHelper dbHelperfrom, dbHelperto, dbHelperoper;
        private string providerName = ConfigurationSettings.AppSettings["ProviderName"];
        private string[] tableSearchSql = ConfigurationSettings.AppSettings["TableSearchSql"].Split(';');
        private string[] columnSearchSql = ConfigurationSettings.AppSettings["ColumnSearchSql"].Split(';');
        private string dataSetConfigPath = ConfigurationSettings.AppSettings["SourcePath"];
        private string excelTmplPath = ConfigurationSettings.AppSettings["ExcelTmplPath"];
        private string configDataPath = ConfigurationSettings.AppSettings["ConfigDataPath"];
        private string outputDataPath = ConfigurationSettings.AppSettings["OutputDataPath"];
        private string deskPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private Dictionary<string, string> connectType = new Dictionary<string, string>()
        {
            { "SqlServer","System.Data.SqlClient"},
            { "MySql","MySql.Data.MySqlClient"},
        };
        #endregion

        #region 构造函数
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 私有事件
        #region 系统事件
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshDataSources();
            LoadIPScheme();
            LoadConfigScheme();
            LoadOutputScheme();
            LoadCodeScheme();
        }
        #endregion

        #region 编辑数据源
        /// <summary>
        /// 编辑数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 数据源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataConnectList listform = new DataConnectList();
            listform.Owner = this;
            listform.ShowDialog();
            RefreshDataSources();
        }
        #endregion

        #region 退出
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        #endregion
        #endregion

        #region 数据差异
        #region 数据差异开始执行
        /// <summary>
        /// 数据差异开始执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDataDiffOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbData.Checked)
                {
                    //两个表名都不能为空
                    if (!string.IsNullOrEmpty(TableFrom) && !string.IsNullOrEmpty(TableTo))
                    {
                        IEnumerable<DataRow> targetdif = DataCompareHelper.QueryDiffRows(dataSourceList[DataSetFrom].Item1, TableFrom, dataSourceList[DataSetFrom].Item2, WhereFrom, dataSourceList[DataSetTo].Item1, TableTo, dataSourceList[DataSetTo].Item2, WhereTo);
                        IEnumerable<DataRow> sourcedif = DataCompareHelper.QueryDiffRows(dataSourceList[DataSetTo].Item1, TableTo, dataSourceList[DataSetTo].Item2, WhereTo, dataSourceList[DataSetFrom].Item1, TableFrom, dataSourceList[DataSetFrom].Item2, WhereFrom);
                        DoDataDiffExecute(targetdif, sourcedif);
                        MessageBox.Show("执行成功");
                    }
                    else
                        MessageBox.Show("表名不能为空");
                }
                else if (rdbStruct.Checked)
                {
                    //对比两张表的字段
                    if (!string.IsNullOrEmpty(TableFrom) && !string.IsNullOrEmpty(TableTo))
                    {
                        string diffsql = DoStructDiffExecute(TableFrom, TableTo);
                        if (string.IsNullOrEmpty(diffsql))
                            SaveText(@"/***说明***/
无差别");
                        else
                            SaveText(string.Format(@"/***说明***/
/***[{0}]***/{1}", TableFrom, diffsql));
                        MessageBox.Show("执行成功");
                    }
                    //对比两个库所有表的字段
                    else
                    {
                        //两个库里面都有的表
                        var sharetables = TableListFrom.Items.Cast<string>().Join(TableListTo.Items.Cast<string>(),
                            f => f, t => t, (f, t) => f);
                        //共有表的差异sql
                        var sharesql = sharetables.Select(c => new { Name = c, Sql = DoStructDiffExecute(c, c) });
                        if (cbxSameName.Checked)
                        {
                            if (sharesql.All(c => string.IsNullOrEmpty(c.Name)))
                                SaveText(@"/***说明***/
无差别");
                            else
                            {
                                SaveText(string.Format(@"/***说明***/
{0}", string.Join("", sharesql.Where(c => !string.IsNullOrEmpty(c.Sql)).Select(c => string.Format("/***[{0}]***/{1}", c.Name, c.Sql)).ToArray())));
                            }
                        }
                        else
                        {
                            var fonly = TableListFrom.Items.Cast<string>().Except(TableListTo.Items.Cast<string>());
                            var tonly = TableListTo.Items.Cast<string>().Except(TableListFrom.Items.Cast<string>());
                            if (sharesql.All(c => string.IsNullOrEmpty(c.Name)) && fonly.Count() == 0 && tonly.Count() == 0)
                                SaveText(@"/***说明***/
无差别");
                            else
                                SaveText(string.Format(@"/***说明***/
{0}
{1}

{2}",
       string.Join("", sharesql.Where(c => !string.IsNullOrEmpty(c.Sql)).Select(c => string.Format("/***[{0}]***/{1}", c.Name, c.Sql)).ToArray()),
       string.Format(@"/***原始库中不存在的表***/
{0}", string.Join(@"
", tonly.Select(c => string.Format("--[{0}]", c)).ToArray())),
       string.Format(@"/***目标库中不存在的表***/
{0}", string.Join(@"
", fonly.Select(c => string.Format("--[{0}]", c)).ToArray()))));
                        }

                        MessageBox.Show("执行成功");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 切换原始数据
        /// <summary>
        /// 切换原始数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SourceListFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dbHelperfrom = new DBHelper(dataSourceList[DataSetFrom].Item1, connectType[dataSourceList[DataSetFrom].Item2]);
                DbDataReader reader = DBFrom.ExecuteReader(GetTableNamesSearchSql(dataSourceList[DataSetFrom].Item2));
                TableListFrom.Items.Clear();
                while (reader.Read())
                {
                    TableListFrom.Items.Add(reader.Get<string>("Name"));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 切换目标数据
        /// <summary>
        /// 切换目标数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SourceListTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dbHelperto = new DBHelper(dataSourceList[DataSetTo].Item1, connectType[dataSourceList[DataSetTo].Item2]);
                DbDataReader reader = DBTo.ExecuteReader(GetTableNamesSearchSql(dataSourceList[DataSetTo].Item2));
                TableListTo.Items.Clear();
                while (reader.Read())
                {
                    TableListTo.Items.Add(reader.Get<string>("Name"));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #endregion

        #region 数据操作
        #region 数据操作开始执行
        /// <summary>
        /// 数据操作执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDataOperOK_Click(object sender, EventArgs e)
        {
            //如果是生成delete语句
            if (cbxBackupDelete.Checked || cbxBackupInsert.Checked)
            {
                if (DataSetOper.Count()>0)
                {
                    DoDataBaseExecute(DataSetOper.Select(c => dataSourceList[c].Item1).ToArray(), cbxBackupDelete.Checked, cbxBackupInsert.Checked);
                    MessageBox.Show("执行成功");
                }
                else
                    MessageBox.Show("请选择数据源");
            }
            //如果是备份数据库
            else if (cbxBackUpDataBase.Checked)
            {
                try
                {
                    if (DataSetOper.Count() > 0)
                    {
                        foreach (var item in DataSetOper.Select(c => dataSourceList[c]))
                        {
                            DBHelper db = new DBHelper(item.Item1, connectType[item.Item2]);
                            db.ExecuteNonQuery(string.Format("backup database {1} to disk='{0}\\{1}{2}.bak' With init",
                                tbxBakPath.Text.TrimEnd('\\'),
                                db.DataBaseName,
                                DateTime.Now.ToString("yyMMddHHmmss")), 7200);
                        }
                        MessageBox.Show("执行成功");
                    }
                    else
                        MessageBox.Show("请选择数据源");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region 点击“生成Delete语句”
        /// <summary>
        /// 点击“生成Delete语句”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDelete_CheckedChanged(object sender, EventArgs e)
        {
            //如果选择生成sql语句，则不能备份数据库
            if (cbxBackupDelete.Checked)
            {
                cbxBackUpDataBase.Checked = false;
                cbxCompressBak.Checked = false;
            }
        }
        #endregion

        #region 点击“生成Insert语句”
        /// <summary>
        /// 点击“生成Insert语句”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxBackupInsert_CheckedChanged(object sender, EventArgs e)
        {
            //如果选择生成sql语句，则不能备份数据库
            if (cbxBackupInsert.Checked)
            {
                cbxBackUpDataBase.Checked = false;
                cbxCompressBak.Checked = false;
            }
        }
        #endregion

        #region 点击“备份数据库”
        /// <summary>
        /// 点击“备份数据库”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxBackUpDataBase_CheckedChanged(object sender, EventArgs e)
        {
            //如果选择备份数据库，就不能生成delete语句
            if (cbxBackUpDataBase.Checked)
            {
                cbxBackupDelete.Checked = false;
                cbxBackupInsert.Checked = false;
            }
        }
        #endregion

        #region 点击“压缩备份文件”
        /// <summary>
        /// 点击“压缩备份文件”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxCompressBak_CheckedChanged(object sender, EventArgs e)
        {
            //如果没有选择备份数据库，就不能压缩备份文件
            if (!cbxBackUpDataBase.Checked)
            {
                cbxCompressBak.Checked = false;
            }
        }
        #endregion

        #region 点击“清除日志”
        /// <summary>
        /// 点击“清除日志”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDataOperClearLog_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataSetOper.Count() > 0)
                {
                    foreach (var item in DataSetOper.Select(c => dataSourceList[c]))
                    {
                        DBHelper db = new DBHelper(item.Item1, connectType[item.Item2]);
                        //因为ExecuteNonQuery方法不支持多个sql语句之间用GO连接，因此拆成多次执行
                        var SqlVersion = db.ExecuteScalar("select @@version").ToString();
                        if (SqlVersion.IndexOf("2005") > 0)
                        {
                            db.ExecuteNonQuery(string.Format("Backup Log {0} with no_log", db.DataBaseName));
                            db.ExecuteNonQuery(string.Format("dump transaction {0} with no_log", db.DataBaseName));
                            db.ExecuteNonQuery(string.Format(@"USE [{0}] 
DBCC SHRINKFILE ( 2 )", db.DataBaseName));
                        }
                        else if (SqlVersion.IndexOf("2008") > 0)
                        {
                            var logName = db.ExecuteScalar("select name from sys.database_files where type='1'");
                            db.ExecuteNonQuery(string.Format(@"USE [master] 
ALTER DATABASE {0} SET RECOVERY SIMPLE WITH NO_WAIT", db.DataBaseName));
                            db.ExecuteNonQuery(string.Format(@"ALTER DATABASE {0} SET RECOVERY SIMPLE   -- 简单模式 ", db.DataBaseName));
                            db.ExecuteNonQuery(string.Format(@"DBCC SHRINKFILE (N'{0}' , 11 , TRUNCATEONLY)", logName));
                            db.ExecuteNonQuery(string.Format(@"USE [master] 
ALTER DATABASE {0} SET RECOVERY FULL WITH NO_WAIT", db.DataBaseName));
                            db.ExecuteNonQuery(string.Format(@"USE [master] 
ALTER DATABASE {0} SET RECOVERY FULL   -- 还原为完全模式 ", db.DataBaseName));
                        }
                    }
                    MessageBox.Show("执行成功");
                }
                else
                    MessageBox.Show("请选择数据源");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #endregion

        #region 复制
        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                #region 检查文件夹过滤
                KeepDirectorys = new List<string>();
                RemoveDirectorys = new List<string>();
                if (!string.IsNullOrEmpty(tbxCopyDirectorys.Text))
                {
                    if (rbtOnlyCopyDirectorys.Checked)
                    {
                        KeepDirectorys.AddRange(tbxCopyDirectorys.Text.Split(';'));
                    }
                    else if (rbtRemoveCopyDirectorys.Checked)
                    {
                        RemoveDirectorys.AddRange(tbxCopyDirectorys.Text.Split(';'));
                    }
                }
                #endregion

                #region 检查文件过滤
                KeepFiles = new List<string>();
                RemoveFiles = new List<string>();
                if (!string.IsNullOrEmpty(tbxCopyFiles.Text))
                {
                    if (rbtOnlyCopyFiles.Checked)
                    {
                        foreach (var item in tbxCopyFiles.Text.Split(';'))
                        {
                            if (item.Split('.').Length > 2)
                                throw new Exception(string.Format("文件名（{0}）不正确", item));
                        }
                        KeepFiles.AddRange(tbxCopyFiles.Text.Split(';'));
                    }
                    else if (rbtRemoveCopyFiles.Checked)
                    {
                        foreach (var item in tbxCopyFiles.Text.Split(';'))
                        {
                            if (item.Split('.').Length > 2)
                                throw new Exception(string.Format("文件名（{0}）不正确", item));
                        }
                        RemoveFiles.AddRange(tbxCopyFiles.Text.Split(';'));
                    }
                }
                #endregion

                #region 检查操作优先权
                //if (rbtCopyFileFirst.Checked)
                //{
                //    FileFirst = true;
                //    DirectoryFirst = false;
                //}
                //else
                //{
                //    FileFirst = false;
                //    DirectoryFirst = true;
                //}
                #endregion

                #region 检查文件夹优先权
                //if (rbtCopyChildFirst.Checked)
                //{
                //    ChildFirst = true;
                //    FatherFirst = true;
                //}
                //else
                //{
                //    ChildFirst = false;
                //    FatherFirst = true;
                //}
                #endregion

                #region 检查文件是否替换
                ReplaceFile = cbxReplaceFile.Checked;
                #endregion

                //开始复制
                DoCopy(new DirectoryInfo(tbxCopyFrom.Text), new DirectoryInfo(tbxCopyTo.Text));

                MessageBox.Show("复制完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                #region 检查文件夹过滤
                KeepDirectorys = new List<string>();
                RemoveDirectorys = new List<string>();
                if (!string.IsNullOrEmpty(tbxDelDirectorys.Text))
                {
                    if (rbtDelKeepDirectory.Checked)
                    {
                        KeepDirectorys.AddRange(tbxDelDirectorys.Text.Split(';'));
                    }
                    else if (rbtDelRemoveDirectory.Checked)
                    {
                        RemoveDirectorys.AddRange(tbxDelDirectorys.Text.Split(';'));
                    }
                }
                #endregion

                #region 检查文件过滤
                KeepFiles = new List<string>();
                RemoveFiles = new List<string>();
                if (!string.IsNullOrEmpty(tbxDelFiles.Text))
                {
                    if (rbtDelKeepFile.Checked)
                    {
                        foreach (var item in tbxDelFiles.Text.Split(';'))
                        {
                            if (item.Split('.').Length > 2)
                                throw new Exception(string.Format("文件名（{0}）不正确", item));
                        }
                        KeepFiles.AddRange(tbxDelFiles.Text.Split(';'));
                    }
                    else if (rbtDelRemoveFile.Checked)
                    {
                        foreach (var item in tbxDelFiles.Text.Split(';'))
                        {
                            if (item.Split('.').Length > 2)
                                throw new Exception(string.Format("文件名（{0}）不正确", item));
                        }
                        RemoveFiles.AddRange(tbxDelFiles.Text.Split(';'));
                    }
                }
                #endregion

                #region 检查操作优先权
                if (rbtDelFileFirst.Checked)
                {
                    FileFirst = true;
                    DirectoryFirst = false;
                }
                else
                {
                    FileFirst = false;
                    DirectoryFirst = true;
                }
                #endregion

                DoDelete(new DirectoryInfo(tbxDelTarget.Text), false);
                MessageBox.Show("删除成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region IP转换
        #region 选择IP方案后
        /// <summary>
        /// 选择IP方案后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IPTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectSingleIP(e.Node.Text);
        }
        #endregion

        #region 添加IP方案
        /// <summary>
        /// 添加IP方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIPAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxIPName.Text))
            {
                if (docoper.Exist(string.Format("/Base/IPAddress/IP[@Name='{0}']", tbxIPName.Text)))
                    MessageBox.Show(string.Format("已存在名称为（{0}）的IP方案", tbxIPName.Text));
                else
                {
                    XmlElement ele = docoper.Doc.CreateElement("IP");
                    ele.SetAttribute("Name", tbxIPName.Text);
                    ele.SetAttribute("IPAddress", tbxIPAddress.Text);
                    ele.SetAttribute("SubnetMask", tbxSubNetMask.Text);
                    ele.SetAttribute("DefaultIPGateway", tbxDefaultIPGateWay.Text);
                    ele.SetAttribute("DNSServerSearchOrder", tbxDNSServerSearchOrder.Text);
                    ele.SetAttribute("DNSServerSpare", tbxDNSServerSpare.Text);
                    docoper.AddEle(ele, "/Base/IPAddress");
                    LoadIPScheme();
                }
            }
            else
                MessageBox.Show("名称不能为空");
        }
        #endregion

        #region 修改IP方案
        /// <summary>
        /// 修改IP方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIPEdit_Click(object sender, EventArgs e)
        {
            TreeNode node = IPTree.SelectedNode;
            if (node != null && !string.IsNullOrEmpty(tbxIPName.Text))
            {
                if (tbxIPName.Text == IPTree.SelectedNode.Text)
                {
                    XmlElement ele = docoper.QueryEle(string.Format("/Base/IPAddress/IP[@Name='{0}']", tbxIPName.Text));
                    ele.SetAttribute("IPAddress", tbxIPAddress.Text);
                    ele.SetAttribute("SubnetMask", tbxSubNetMask.Text);
                    ele.SetAttribute("DefaultIPGateway", tbxDefaultIPGateWay.Text);
                    ele.SetAttribute("DNSServerSearchOrder", tbxDNSServerSearchOrder.Text);
                    ele.SetAttribute("DNSServerSpare", tbxDNSServerSpare.Text);
                    docoper.Save();
                    LoadIPScheme();
                }
                else if (docoper.Exist(string.Format("/Base/IPAddress/IP[@Name='{0}']", tbxIPName.Text)))
                {
                    MessageBox.Show(string.Format("已存在名称为（{0}）的数据源", tbxIPName.Text));
                }
                else
                {
                    XmlElement ele = docoper.QueryEle(string.Format("/Base/IPAddress/IP[@Name='{0}']", IPTree.SelectedNode.Name));
                    ele.SetAttribute("Name", tbxIPName.Text);
                    ele.SetAttribute("IPAddress", tbxIPAddress.Text);
                    ele.SetAttribute("SubnetMask", tbxSubNetMask.Text);
                    ele.SetAttribute("DefaultIPGateway", tbxDefaultIPGateWay.Text);
                    ele.SetAttribute("DNSServerSearchOrder", tbxDNSServerSearchOrder.Text);
                    ele.SetAttribute("DNSServerSpare", tbxDNSServerSpare.Text);
                    docoper.Save();
                    LoadIPScheme();
                }
            }
        }
        #endregion

        #region 删除IP方案
        /// <summary>
        /// 删除IP方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIPDelete_Click(object sender, EventArgs e)
        {
            TreeNode node = IPTree.SelectedNode;
            if (node != null)
            {
                docoper.DeleteNode(string.Format("/Base/IPAddress/IP[@Name='{0}']", IPTree.SelectedNode.Text));
                LoadIPScheme();
            }
        }
        #endregion

        #region 应用IP方案
        /// <summary>
        /// 应用IP方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIPUse_Click(object sender, EventArgs e)
        {
            try
            {
                IPHelper.SetIP(tbxIPAddress.Text, tbxSubNetMask.Text, tbxDefaultIPGateWay.Text, tbxDNSServerSearchOrder.Text, tbxDNSServerSpare.Text);
                if (IPTree.SelectedNode != null)
                {
                    var selectedscheme = IPSchemeList.Where(c => c.Name == IPTree.SelectedNode.Text).FirstOrDefault();
                    if (!string.IsNullOrEmpty(selectedscheme.Name))
                    {
                        foreach (var item in selectedscheme.ReplaceSchemes)
                        {
                            string fileContent = FileStreamHelper.ReadText(item.FilePath);
                            FileStreamHelper.SaveText(item.FilePath, item.FilePath.Split('\\').Last(), fileContent.Replace(item.OldStr, item.NewStr));
                        }
                    }
                }
                MessageBox.Show("应用成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 自动获取IP
        /// <summary>
        /// 自动获取IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIPAuto_Click(object sender, EventArgs e)
        {
            try
            {
                IPHelper.SetAutoIP();
                MessageBox.Show("应用成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion
        #endregion

        #region 配置转换
        #region 添加配置
        /// <summary>
        /// 添加配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfigAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxConfigName.Text))
            {
                if (docoper.Exist(string.Format("/Base/ConfigAddress/Config[@Name='{0}']", tbxConfigName.Text)))
                    MessageBox.Show(string.Format("已存在名称为（{0}）的配置方案", tbxConfigName.Text));
                else
                {
                    XmlElement ele = docoper.Doc.CreateElement("Config");
                    ele.SetAttribute("Name", tbxConfigName.Text);
                    docoper.AddEle(ele, "/Base/ConfigAddress");
                    LoadConfigScheme();
                }
            }
            else
                MessageBox.Show("名称不能为空");
        }
        #endregion

        #region 修改配置
        /// <summary>
        /// 修改配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfigEdit_Click(object sender, EventArgs e)
        {
            TreeNode node = ConfigTree.SelectedNode;
            if (node != null && !string.IsNullOrEmpty(tbxConfigName.Text))
            {
                if (node.Text == tbxConfigName.Text)
                    return;
                if (docoper.Exist(string.Format("/Base/ConfigAddress/Config[@Name='{0}']", tbxConfigName.Text)))
                {
                    MessageBox.Show(string.Format("已存在名称为（{0}）的数据源", tbxConfigName.Text));
                }
                else
                {
                    XmlElement ele = docoper.QueryEle(string.Format("/Base/ConfigAddress/Config[@Name='{0}']", node.Text));
                    ele.SetAttribute("Name", tbxConfigName.Text);
                    docoper.Save();
                    DirectoryInfo di = new DirectoryInfo(string.Format("{0}{1}{2}", Application.StartupPath, configDataPath, node.Text));
                    if (di.Exists)
                        di.MoveTo(string.Format("{0}{1}{2}", Application.StartupPath, configDataPath, tbxConfigName.Text));
                    LoadConfigScheme();
                }
            }
        }
        #endregion

        #region 删除配置
        /// <summary>
        /// 删除配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfigDelete_Click(object sender, EventArgs e)
        {
            TreeNode node = ConfigTree.SelectedNode;
            if (node != null)
            {
                docoper.DeleteNode(string.Format("/Base/ConfigAddress/Config[@Name='{0}']", node.Text));

                DirectoryInfo di = new DirectoryInfo(string.Format("{0}{1}{2}", Application.StartupPath, configDataPath, node.Text));
                if (di.Exists)
                    di.Delete(true);

                LoadConfigScheme();
            }
        }
        #endregion

        #region 应用配置
        /// <summary>
        /// 应用配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfigUse_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = ConfigTree.SelectedNode;
                XmlElement ele = docoper.QueryEle(string.Format("/Base/ConfigAddress/Config[@Name='{0}']", node.Text));
                for (int i = 0; i < ele.ChildNodes.Count; i++)
                {
                    XmlElement child = (XmlElement)ele.ChildNodes[i];
                    if (child.GetAttribute("Type") == "Text" && !string.IsNullOrEmpty(child.GetAttribute("Path")))
                    {
                        FileInfo fi = new FileInfo(child.GetAttribute("Path"));
                        if (fi.Exists)
                            fi.Delete();
                        FileStreamHelper.SaveText(fi.DirectoryName, fi.Name,
                            FileStreamHelper.ReadText(string.Format("{0}{1}{2}\\{3}", Application.StartupPath, configDataPath, ele.GetAttribute("Name"), child.GetAttribute("Name"))).Replace("{IP}", tbxConfigIP.Text));
                    }
                    else if (child.GetAttribute("Type") == "Sql" && !string.IsNullOrEmpty(child.GetAttribute("DataBase")))
                    {
                        DBHelper db = new DBHelper(dataSourceList[child.GetAttribute("DataBase")].Item1, connectType[dataSourceList[child.GetAttribute("DataBase")].Item2]);
                        db.ExecuteNonQuery(FileStreamHelper.ReadText(string.Format("{0}{1}{2}\\{3}", Application.StartupPath, configDataPath, ele.GetAttribute("Name"), child.GetAttribute("Name"))).Replace("{IP}", tbxConfigIP.Text));
                    }
                }
                MessageBox.Show("应用成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 维护配置明细
        /// <summary>
        /// 维护配置明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfigText_Click(object sender, EventArgs e)
        {
            if (ConfigTree.SelectedNode != null)
            {
                ReplaceSchemeList form = new ReplaceSchemeList();
                form.ConfigItemName = ConfigTree.SelectedNode.Text;
                form.ShowDialog();
            }
        }
        #endregion

        #region 切换配置
        private void ConfigTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tbxConfigName.Text = ConfigTree.SelectedNode.Text;
        }
        #endregion
        #endregion

        #region 导出数据
        #region 添加导出
        /// <summary>
        /// 添加导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutputAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxOutputName.Text))
            {
                if (docoper.Exist(string.Format("/Base/Output/Item[@Name='{0}']", tbxOutputName.Text)))
                    MessageBox.Show(string.Format("已存在名称为（{0}）的导出方案", tbxOutputName.Text));
                else
                {
                    XmlElement ele = docoper.Doc.CreateElement("Item");
                    ele.SetAttribute("Name", tbxOutputName.Text);
                    ele.SetAttribute("Table", tbxOutputTableName.Text);
                    ele.SetAttribute("DataBase", cbbOutputDataSet.Text);
                    docoper.AddEle(ele, "/Base/Output");
                    DirectoryInfo di = new DirectoryInfo(string.Format("{0}{1}{2}\\", Application.StartupPath, outputDataPath, tbxOutputName.Text));
                    di.Create();
                    FileStreamHelper.SaveText(string.Format("{0}{1}{2}\\", Application.StartupPath, outputDataPath, tbxOutputName.Text), "Select", tbxOutputSql.Text);
                    FileStreamHelper.SaveText(string.Format("{0}{1}{2}\\", Application.StartupPath, outputDataPath, tbxOutputName.Text), "Delete", tbxOutputDelete.Text);
                    LoadOutputScheme(tbxOutputName.Text);
                }
            }
            else
                MessageBox.Show("名称不能为空");
        }
        #endregion

        #region 修改导出
        /// <summary>
        /// 修改导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutputModify_Click(object sender, EventArgs e)
        {
            string selecteditem = (string)OutputList.SelectedItem;
            if (!string.IsNullOrEmpty(selecteditem) && !string.IsNullOrEmpty(tbxOutputName.Text))
            {
                if (selecteditem != tbxOutputName.Text && docoper.Exist(string.Format("/Base/Output/Item[@Name='{0}']", tbxOutputName.Text)))
                {
                    MessageBox.Show(string.Format("已存在名称为（{0}）的导出方案", tbxOutputName.Text));
                }
                else
                {
                    XmlElement ele = docoper.QueryEle(string.Format("/Base/Output/Item[@Name='{0}']", selecteditem));
                    ele.SetAttribute("Name", tbxOutputName.Text);
                    ele.SetAttribute("Table", tbxOutputTableName.Text);
                    ele.SetAttribute("DataBase", cbbOutputDataSet.Text);
                    docoper.Save();
                    DirectoryInfo di = new DirectoryInfo(string.Format("{0}{1}{2}\\", Application.StartupPath, outputDataPath, selecteditem));
                    if (di.Exists)
                        di.Delete(true);
                    DirectoryInfo newdi = new DirectoryInfo(string.Format("{0}{1}{2}\\", Application.StartupPath, outputDataPath, tbxOutputName.Text));
                    newdi.Create();
                    FileStreamHelper.SaveText(string.Format("{0}{1}{2}\\", Application.StartupPath, outputDataPath, tbxOutputName.Text), "Select", tbxOutputSql.Text);
                    FileStreamHelper.SaveText(string.Format("{0}{1}{2}\\", Application.StartupPath, outputDataPath, tbxOutputName.Text), "Delete", tbxOutputDelete.Text);
                    LoadOutputScheme(tbxOutputName.Text);
                }
            }
        }
        #endregion

        #region 删除导出
        /// <summary>
        /// 删除导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutputDelete_Click(object sender, EventArgs e)
        {
            string selecteditem = (string)OutputList.SelectedItem;
            if (!string.IsNullOrEmpty(selecteditem))
            {
                docoper.DeleteNode(string.Format("/Base/Output/Item[@Name='{0}']", selecteditem));
                DirectoryInfo di = new DirectoryInfo(string.Format("{0}{1}{2}\\", Application.StartupPath, outputDataPath, tbxOutputName.Text));
                if (di.Exists)
                    di.Delete(true);
                LoadOutputScheme();
            }
        }
        #endregion

        #region 执行导出
        /// <summary>
        /// 执行导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutputOK_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (object item in OutputList.SelectedItems)
                {
                    XmlElement ele = docoper.QueryEle(string.Format("/Base/Output/Item[@Name='{0}']", item));
                    DBHelper operDB = new DBHelper(dataSourceList[ele.GetAttribute("DataBase")].Item1, connectType[dataSourceList[ele.GetAttribute("DataBase")].Item2]);
                    sb.AppendFormat(@"Use [{0}]

", operDB.DataBaseName);

                    if (cbxOutputDelete.Checked)
                        sb.AppendFormat(@"{0}

", FileStreamHelper.ReadText(string.Format("{0}{1}{2}\\Delete", Application.StartupPath, outputDataPath, ele.GetAttribute("Name"))));

                    sb.Append(SqlHelper.CreateInsertSql(ele.GetAttribute("Table"),
                        operDB.ExecuteTable(FileStreamHelper.ReadText(
                        string.Format("{0}{1}{2}\\Select", Application.StartupPath, outputDataPath, ele.GetAttribute("Name"))))));
                    sb.Append(@"

");
                }
                SaveText(sb.ToString());
                MessageBox.Show("导出成功");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 选中导出
        private void OutputList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectSingleOutput((string)OutputList.SelectedItem);
        }
        #endregion
        #endregion

        #region 代码生成器
        #region 执行代码生成
        /// <summary>
        /// 执行代码生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCodeRun_Click(object sender, EventArgs e)
        {
            #region 检查
            if (string.IsNullOrWhiteSpace(cbbCodeTemplete.SelectedItem.ToString())) {
                MessageBox.Show("模板不能为空");
                return;
            }
            var templete = CodeTempleteSchemeList.Where(c => c.Name == cbbCodeTemplete.SelectedItem.ToString()).FirstOrDefault();
            if (templete == null)
            {
                MessageBox.Show("模板不能为空");
                return;
            }
            var templetedir = new DirectoryInfo(templete.Path);
            if (!templetedir.Exists)
            {
                MessageBox.Show("模板文件夹不存在");
                return;
            }
            if (string.IsNullOrWhiteSpace(cbbCodeDataSource.SelectedItem.ToString()))
            {
                MessageBox.Show("数据源不能为空");
                return;
            }
            if (string.IsNullOrWhiteSpace(cbbCodeDataTable.SelectedItem.ToString()))
            {
                MessageBox.Show("表不能为空");
                return;
            }
            var selfReplace = tbxCodeOther.Text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(c => c.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries));
            if (selfReplace.Where(c => c.Count() != 2).Count() > 0)
            {
                MessageBox.Show("其他替换内容有误");
                return;
            }
            #endregion

            #region 执行
            dbHelperoper=new DBHelper(dataSourceList[cbbCodeDataSource.SelectedItem.ToString()].Item1, connectType[dataSourceList[cbbCodeDataSource.SelectedItem.ToString()].Item2]);
            var columninfo = dbHelperoper.ExecuteTable(string.Format(GetColumnsSearchSql(dataSourceList[cbbCodeDataSource.SelectedItem.ToString()].Item2), cbbCodeDataTable.SelectedItem.ToString()));
            ExecuteCodeTempleteDir(templetedir, new DirectoryInfo($"{deskPath}\\{DateTime.Now.ToString("yyMMddHHmmss")}")
                , selfReplace, columninfo);
            #endregion
        }
        #endregion

        #region 生成代码模板文件夹
        /// <summary>
        /// 生成代码模板文件夹
        /// </summary>
        /// <param name="fromDir"></param>
        /// <param name="toDir"></param>
        private void ExecuteCodeTempleteDir(DirectoryInfo fromDir, DirectoryInfo toDir, IEnumerable<string[]> selfReplace, DataTable columnInfo)
        {
            //创建文件夹
            if (!toDir.Exists)
                toDir.Create();
            foreach (var file in fromDir.GetFiles())
            {
                FileStreamHelper.SaveText(toDir.FullName
                , ReplaceCodeTempleteText(file.Name, selfReplace)//替换文件名中的其他替换内容
                , ReplaceCodeTempleteColumn(ReplaceCodeTempleteText(FileStreamHelper.ReadText(file.FullName), selfReplace), columnInfo));//替换文件正文中的其他替换内容和字段信息
            }
            foreach (var dir in fromDir.GetDirectories())
            {
                ExecuteCodeTempleteDir(dir, new DirectoryInfo($"{toDir.FullName}\\{ReplaceCodeTempleteText(dir.Name, selfReplace)}"), selfReplace, columnInfo);//递归生成子文件夹
            }
        }
        #endregion

        #region 替换代码模板字段
        /// <summary>
        /// 替换代码模板字段
        /// </summary>
        /// <param name="source"></param>
        /// <param name="columnInfo"></param>
        /// <returns></returns>
        private string ReplaceCodeTempleteColumn(string source, DataTable columnInfo)
        {
            while (source.IndexOf("[FieldStart]") > -1) {
                var start = source.IndexOf("[FieldStart]");
                var end = source.IndexOf("[FieldEnd]");
                var content = source.Substring(start + 12, end - start - 12);
                var resultList = columnInfo.AsEnumerable().Select(c => content.Replace("[FieldTitle]", c["name"].ToString()).Replace("[FieldName]", c["name"].ToString()));

                source = $"{source.Substring(0, start)}{string.Join("\r\n", resultList)}{source.Substring(end + 10)}";
            }
            source = source.Replace("[FieldCount]", columnInfo.Rows.Count.ToString());
            return source;
        }
        #endregion

        #region 替换代码模板文本
        /// <summary>
        /// 替换代码模板文本
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selfReplace"></param>
        /// <returns></returns>
        private string ReplaceCodeTempleteText(string source, IEnumerable<string[]> selfReplace)
        {
            foreach (var item in selfReplace)
            {
                source = source.Replace(item[0], item[1]);
            }
            return source;
        }
        #endregion
        #endregion
        #endregion

        #region 私有属性
        #region DB属性
        #region 原始数据源
        /// <summary>
        /// 原始数据源
        /// </summary>
        private DBHelper DBFrom
        {
            get
            {
                return dbHelperfrom;
            }
        }
        #endregion

        #region 目标数据源
        /// <summary>
        /// 目标数据源
        /// </summary>
        private DBHelper DBTo
        {
            get
            {
                return dbHelperto;
            }
        }
        #endregion

        #region 操作数据源
        /// <summary>
        /// 操作数据源
        /// </summary>
        private DBHelper DBOper
        {
            get
            {
                return dbHelperoper;
            }
        }
        #endregion

        #region 原始库
        /// <summary>
        /// 原始库
        /// </summary>
        private string DataSetFrom
        {
            get
            {
                return SourceListFrom.Text.Trim();
            }
        }
        #endregion

        #region 目标库
        /// <summary>
        /// 目标库
        /// </summary>
        private string DataSetTo
        {
            get
            {
                return SourceListTo.Text.Trim();
            }
        }
        #endregion

        #region 操作库
        /// <summary>
        /// 操作库
        /// </summary>
        private string[] DataSetOper
        {
            get
            {
                return OperatorSourcesList.SelectedItems.Cast<string>().ToArray();
            }
        }
        #endregion

        #region 原始表
        /// <summary>
        /// 原始表
        /// </summary>
        private string TableFrom
        {
            get
            {
                return TableListFrom.Text.Trim();
            }
        }
        #endregion

        #region 目标表
        /// <summary>
        /// 目标表
        /// </summary>
        private string TableTo
        {
            get
            {
                return TableListTo.Text.Trim();
            }
        }
        #endregion

        #region 原始查询条件
        /// <summary>
        /// 原始查询条件
        /// </summary>
        private string WhereFrom
        {
            get
            {
                return tbxWhereStrFrom.Text.Trim();
            }
        }
        #endregion

        #region 目标查询条件
        /// <summary>
        /// 目标查询条件
        /// </summary>
        private string WhereTo
        {
            get
            {
                return tbxWhereStrTo.Text.Trim();
            }
        }
        #endregion
        #endregion

        #region IO属性
        #region 排除文件
        /// <summary>
        /// 排除文件
        /// </summary>
        private List<string> RemoveFiles
        {
            get;
            set;
        }
        #endregion

        #region 排除文件夹
        /// <summary>
        /// 排除文件夹
        /// </summary>
        private List<string> RemoveDirectorys
        {
            get;
            set;
        }
        #endregion

        #region 保留文件
        /// <summary>
        /// 保留文件
        /// </summary>
        private List<string> KeepFiles
        {
            get;
            set;
        }
        #endregion

        #region 保留文件夹
        /// <summary>
        /// 保留文件夹
        /// </summary>
        private List<string> KeepDirectorys
        {
            get;
            set;
        }
        #endregion

        #region 文件夹优先
        /// <summary>
        /// 文件夹优先
        /// </summary>
        private bool DirectoryFirst
        {
            get;
            set;
        }
        #endregion

        #region 文件优先
        /// <summary>
        /// 文件优先
        /// </summary>
        private bool FileFirst
        {
            get;
            set;
        }
        #endregion

        #region 父文件夹优先
        /// <summary>
        /// 父文件夹优先
        /// </summary>
        private bool FatherFirst
        {
            get;
            set;
        }
        #endregion

        #region 子文件夹优先
        /// <summary>
        /// 子文件夹优先
        /// </summary>
        private bool ChildFirst
        {
            get;
            set;
        }
        #endregion

        #region 替换现有文件
        /// <summary>
        /// 替换现有文件
        /// </summary>
        private bool ReplaceFile
        {
            get;
            set;
        }
        #endregion
        #endregion

        #region IP属性
        #region IP方案
        /// <summary>
        /// IP方案
        /// </summary>
        private List<IPScheme> IPSchemeList
        {
            get;
            set;
        }
        #endregion
        #endregion

        #region 导出属性
        #region 导出方案
        /// <summary>
        /// 导出方案
        /// </summary>
        private List<OutputScheme> OutputSchemeList
        {
            get;
            set;
        }
        #endregion
        #endregion

        #region 代码生成属性
        #region 代码生成方案
        /// <summary>
        /// 代码生成方案
        /// </summary>
        private List<CodeTempleteScheme> CodeTempleteSchemeList
        {
            get;
            set;
        }
        #endregion
        #endregion
        #endregion

        #region 公共函数
        #region 刷新数据源
        /// <summary>
        /// 刷新数据源
        /// </summary>
        public void RefreshDataSources()
        {
            docoper = new XmlHelper(string.Format("{0}{1}", Application.StartupPath, dataSetConfigPath), XmlType.Path);
            XmlNodeList list = docoper.QueryNodes("/Base/DataConnections/Connection");
            SourceListFrom.Items.Clear();
            SourceListTo.Items.Clear();
            OperatorSourcesList.Items.Clear();
            cbbOutputDataSet.Items.Clear();
            cbbCodeDataSource.Items.Clear();
            dataSourceList.Clear();
            foreach (XmlNode node in list)
            {
                XmlElement ele = (XmlElement)node;
                SourceListFrom.Items.Add(ele.GetAttribute("Name"));
                SourceListTo.Items.Add(ele.GetAttribute("Name"));
                OperatorSourcesList.Items.Add(ele.GetAttribute("Name"));
                cbbOutputDataSet.Items.Add(ele.GetAttribute("Name"));
                cbbCodeDataSource.Items.Add(ele.GetAttribute("Name"));
                dataSourceList.Add(ele.GetAttribute("Name"), new Tuple<string, string>(ele.InnerText, string.IsNullOrWhiteSpace(ele.GetAttribute("Type")) ? "SqlServer" : ele.GetAttribute("Type")));
            }
        }
        #endregion

        #region 初始化IP方案
        /// <summary>
        /// 初始化IP方案
        /// </summary>
        public void LoadIPScheme()
        {
            IPTree.Nodes.Clear();
            IPSchemeList = new List<IPScheme>();
            docoper = new XmlHelper(string.Format("{0}{1}", Application.StartupPath, dataSetConfigPath), XmlType.Path);
            XmlNodeList list = docoper.QueryNodes("/Base/IPAddress/IP");
            foreach (XmlNode node in list)
            {
                XmlElement ele = (XmlElement)node;
                List<ReplaceScheme> strList = new List<ReplaceScheme>();
                foreach (XmlNode replacenode in ele.ChildNodes)
                {
                    XmlElement replaceele = (XmlElement)replacenode;
                    string oldstr = string.Empty;
                    string newstr = string.Empty;
                    foreach (XmlNode strnode in replaceele.ChildNodes)
                    {
                        if (strnode.Name == "OldStr")
                            oldstr = strnode.InnerText;
                        if (strnode.Name == "NewStr")
                            newstr = strnode.InnerText;
                    }
                    strList.Add(new ReplaceScheme()
                    {
                        Name = replaceele.GetAttribute("Name"),
                        FilePath = replaceele.GetAttribute("Path"),
                        OldStr = oldstr,
                        NewStr = newstr,
                    });
                }
                IPSchemeList.Add(new IPScheme()
                {
                    Name = ele.GetAttribute("Name"),
                    IPAddress = ele.GetAttribute("IPAddress"),
                    SubNetMask = ele.GetAttribute("SubnetMask"),
                    DefaultIPGateway = ele.GetAttribute("DefaultIPGateway"),
                    DNSServerSearchOrder = ele.GetAttribute("DNSServerSearchOrder"),
                    DNSServerSpare = ele.GetAttribute("DNSServerSpare"),
                    ReplaceSchemes = strList,
                });
                TreeNode IPnode = new TreeNode(ele.GetAttribute("Name"));
                IPTree.Nodes.Add(IPnode);
            }
            if (IPSchemeList.Count() > 0)
                SelectSingleIP(IPSchemeList[0].Name);
        }
        #endregion

        #region 初始化配置方案
        /// <summary>
        /// 初始化配置方案
        /// </summary>
        public void LoadConfigScheme()
        {
            ConfigTree.Nodes.Clear();
            docoper = new XmlHelper(string.Format("{0}{1}", Application.StartupPath, dataSetConfigPath), XmlType.Path);
            XmlNodeList list = docoper.QueryNodes("/Base/ConfigAddress/Config");
            foreach (XmlNode node in list)
            {
                XmlElement ele = (XmlElement)node;
                TreeNode confignode = new TreeNode(ele.GetAttribute("Name"));
                ConfigTree.Nodes.Add(confignode);
            }
            if (ConfigTree.Nodes.Count > 0)
            {
                tbxConfigName.Text = ConfigTree.Nodes[0].Text;
                ConfigTree.SelectedNode = ConfigTree.Nodes[0];
            }
        }
        #endregion

        #region 初始化导出方案
        /// <summary>
        /// 初始化导出方案
        /// </summary>
        public void LoadOutputScheme()
        {
            OutputList.Items.Clear();
            OutputSchemeList = new List<OutputScheme>();
            docoper = new XmlHelper(string.Format("{0}{1}", Application.StartupPath, dataSetConfigPath), XmlType.Path);
            XmlNodeList list = docoper.QueryNodes("/Base/Output/Item");
            foreach (XmlNode node in list)
            {
                XmlElement ele = (XmlElement)node;
                OutputList.Items.Add(ele.GetAttribute("Name"));
                OutputSchemeList.Add(new OutputScheme()
                {
                    Name = ele.GetAttribute("Name"),
                    Table = ele.GetAttribute("Table"),
                    DataBase = ele.GetAttribute("DataBase"),
                    Select = FileStreamHelper.ReadText(string.Format("{0}{1}{2}\\Select", Application.StartupPath, outputDataPath, ele.GetAttribute("Name"))),
                    Delete = FileStreamHelper.ReadText(string.Format("{0}{1}{2}\\Delete", Application.StartupPath, outputDataPath, ele.GetAttribute("Name"))),
                });
            }
            if (OutputList.Items.Count > 0)
            {
                XmlElement ele = (XmlElement)list[0];
                tbxOutputName.Text = ele.GetAttribute("Name");
                tbxOutputTableName.Text = ele.GetAttribute("Table");
                cbbOutputDataSet.Text = ele.GetAttribute("DataBase");
                OutputList.SetSelected(0, true);
            }
        }

        /// <summary>
        /// 初始化导出方案
        /// </summary>
        /// <param name="selectedName">被选中的节点</param>
        public void LoadOutputScheme(string selectedName)
        {
            OutputList.Items.Clear();
            OutputSchemeList = new List<OutputScheme>();
            docoper = new XmlHelper(string.Format("{0}{1}", Application.StartupPath, dataSetConfigPath), XmlType.Path);
            XmlNodeList list = docoper.QueryNodes("/Base/Output/Item");
            var selectedindex = 0;
            foreach (XmlNode node in list)
            {
                XmlElement ele = (XmlElement)node;
                OutputList.Items.Add(ele.GetAttribute("Name"));
                if (ele.GetAttribute("Name") == selectedName)
                    selectedindex = OutputList.Items.Count - 1;
                OutputSchemeList.Add(new OutputScheme()
                {
                    Name = ele.GetAttribute("Name"),
                    Table = ele.GetAttribute("Table"),
                    DataBase = ele.GetAttribute("DataBase"),
                    Select = FileStreamHelper.ReadText(string.Format("{0}{1}{2}\\Select", Application.StartupPath, outputDataPath, ele.GetAttribute("Name"))),
                    Delete = FileStreamHelper.ReadText(string.Format("{0}{1}{2}\\Delete", Application.StartupPath, outputDataPath, ele.GetAttribute("Name"))),
                });
            }
            if (OutputList.Items.Count > 0)
            {
                XmlElement ele = (XmlElement)list[selectedindex];
                tbxOutputName.Text = ele.GetAttribute("Name");
                tbxOutputTableName.Text = ele.GetAttribute("Table");
                cbbOutputDataSet.Text = ele.GetAttribute("DataBase");
                OutputList.SetSelected(selectedindex, true);
            }
        }
        #endregion

        #region 初始化代码生成器方案
        public void LoadCodeScheme()
        {
            cbbCodeTemplete.Items.Clear();
            CodeTempleteSchemeList = new List<CodeTempleteScheme>();
            docoper = new XmlHelper(string.Format("{0}{1}", Application.StartupPath, dataSetConfigPath), XmlType.Path);
            XmlNodeList list = docoper.QueryNodes("/Base/CodeTemplete/Item");
            foreach (XmlNode node in list)
            {
                XmlElement ele = (XmlElement)node;
                cbbCodeTemplete.Items.Add(ele.GetAttribute("Name"));
                CodeTempleteSchemeList.Add(new CodeTempleteScheme()
                {
                    Name = ele.GetAttribute("Name"),
                    Path = ele.GetAttribute("Path"),
                });
            }
        }
        #endregion
        #endregion

        #region 私有函数
        #region 生成比对结果
        /// <summary>
        /// 生成数据比对结果
        /// </summary>
        /// <param name="target">目标差异数据</param>
        /// <param name="consuit">源表差异数据</param>
        private void DoDataDiffExecute(IEnumerable<DataRow> target, IEnumerable<DataRow> consuit)
        {
            StringBuilder resultSql = new StringBuilder(@"/***说明***/

");
            if (cbxSelect.Checked)
            {
                resultSql.AppendFormat(@"
/***查询原始数据中的差异记录***/
{0}

/***查询目标数据中的差异记录***/
{1}
", SqlHelper.CreateSearchSql(dataSourceList[DataSetFrom].Item1, TableFrom, "dbo", consuit.ToArray()), SqlHelper.CreateSearchSql(dataSourceList[DataSetTo].Item1, TableTo, "dbo", target.ToArray()));
            }

            if (cbxInsert.Checked)
            {
                resultSql.AppendFormat(@"
/***插入原始数据中的差异记录***/
{0}

/***插入目标数据中的差异记录***/
{1}
", SqlHelper.CreateInsertSql(TableFrom, consuit), SqlHelper.CreateInsertSql(TableTo, target));
            }

            #region 导出Sql文件
            SaveText(resultSql.ToString());
            #endregion
        }

        /// <summary>
        /// 生成结构比对结果
        /// </summary>
        /// <param name="fromtable">原始表</param>
        /// <param name="sourceonly">存在于原始表，但不存在与目标表的字段</param>
        /// <param name="sourcealter">原始表中与目标表不同的字段</param>
        /// <param name="totable">目标表</param>
        /// <param name="targetonly">存在于目标表，但不存在与原始表的字段</param>
        /// <param name="targetalter">目标表中与原始表不同的字段</param>
        /// <returns>带if else的添加修改字段语句</returns>
        private string DoStructDiffExecute(string fromtable, string totable)
        {
            //目标表中与原始表有差异的字段
            IEnumerable<DataRow> targetdif = DataCompareHelper.QueryDiffRows(dataSourceList[DataSetFrom].Item1, "syscolumns", dataSourceList[DataSetFrom].Item2, string.Format("id=object_id('{0}')", fromtable), dataSourceList[DataSetTo].Item1, "syscolumns", dataSourceList[DataSetTo].Item2, string.Format("id=object_id('{0}')", totable), "name,xtype,length,xprec,xscale", "name");
            //原始表中与目标表有差异的字段
            IEnumerable<DataRow> sourcedif = DataCompareHelper.QueryDiffRows(dataSourceList[DataSetTo].Item1, "syscolumns", dataSourceList[DataSetTo].Item2, string.Format("id=object_id('{0}')", totable), dataSourceList[DataSetFrom].Item1, "syscolumns", dataSourceList[DataSetFrom].Item2, string.Format("id=object_id('{0}')", fromtable), "name,xtype,length,xprec,xscale", "name");

            DBHelper dbfrom = new DBHelper(dataSourceList[DataSetFrom].Item1, connectType[dataSourceList[DataSetFrom].Item2]);
            DBHelper dbto = new DBHelper(dataSourceList[DataSetTo].Item1, connectType[ dataSourceList[DataSetTo].Item2]);
            //所有原始表的字段
            var columnsFrom = dbfrom.ExecuteTable(string.Format(GetColumnsSearchSql(dataSourceList[DataSetFrom].Item2), fromtable)).AsEnumerable();
            //所有目标表的字段
            var columnsTo = dbto.ExecuteTable(string.Format(GetColumnsSearchSql(dataSourceList[DataSetTo].Item2), totable)).AsEnumerable();
            //存在于原始表，但不存在与目标表的字段
            var sourceonly = from sd in sourcedif
                             join ct in columnsTo
                                 on sd.Field<string>("name") equals ct.Field<string>("name") into temp
                             from tp in temp.DefaultIfEmpty()
                             where tp == null
                             select sd;
            //存在于目标表，但不存在与原始表的字段
            var targetonly = from td in targetdif
                             join cf in columnsFrom
                                 on td.Field<string>("name") equals cf.Field<string>("name") into temp
                             from tp in temp.DefaultIfEmpty()
                             where tp == null
                             select td;
            //原始表中与目标表不同的字段
            var sourcealter = sourcedif.Except(sourceonly);
            //目标表中与原始表不同的字段
            var targetalter = targetdif.Except(targetonly);

            return (sourceonly.Count() == 0 && targetonly.Count() == 0 && sourcealter.Count() == 0 && targetalter.Count()==0)
                ?string.Empty:string.Format(@"
/***存在于原始表，但不存在与目标表的字段***/
{0}

/***原始表中与目标表不同的字段***/
{1}

/***存在于目标表，但不存在与原始表的字段***/
{2}

/***目标表中与原始表不同的字段***/
{3}
"
 , string.Join(@"
", sourceonly.Select(c => SqlHelper.CreateColumnSql(fromtable, c[0].ToString(), DbTool.GetColumnType(Convert.ToByte(c[1]), Convert.ToInt16(c[2]), Convert.ToByte(c[3]), Convert.ToByte(c[4])))).ToArray())
 , string.Join(@"
", sourcealter.Select(c => SqlHelper.CreateColumnSql(totable, c[0].ToString(), DbTool.GetColumnType(Convert.ToByte(c[1]), Convert.ToInt16(c[2]), Convert.ToByte(c[3]), Convert.ToByte(c[4])))).ToArray())
 , string.Join(@"
", targetonly.Select(c => SqlHelper.CreateColumnSql(totable, c[0].ToString(), DbTool.GetColumnType(Convert.ToByte(c[1]), Convert.ToInt16(c[2]), Convert.ToByte(c[3]), Convert.ToByte(c[4])))).ToArray())
 , string.Join(@"
", targetalter.Select(c => SqlHelper.CreateColumnSql(totable, c[0].ToString(), DbTool.GetColumnType(Convert.ToByte(c[1]), Convert.ToInt16(c[2]), Convert.ToByte(c[3]), Convert.ToByte(c[4])))).ToArray()));
        }
        #endregion

        #region 生成删除语句
        /// <summary>
        /// 生成删除语句
        /// </summary>
        /// <param name="dataSources">数据库</param>
        /// <param name="isDelete">是否生成Delete语句</param>
        /// <param name="isInsert">是否生成Insert语句</param>
        private void DoDataBaseExecute(string[] dataSources,bool isDelete,bool isInsert)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in dataSources)
                {
                    dbHelperoper = new DBHelper(item, providerName);
                    DbDataReader reader = DBOper.ExecuteReader(tableSearchSql[0]);
                    List<string> names = new List<string>();
                    while (reader.Read())
                    {
                        names.Add(reader.Get<string>("Name"));
                    }
                    reader.Close();

                    string deleteSql=string.Empty;
                    string insertSql=string.Empty;
                    if (isDelete)
                        deleteSql = SqlHelper.CreateDeleteSql(names);
                    if (isInsert)
                        insertSql = string.Join(@"
", names.Select(c => SqlHelper.CreateInsertSql(c, DBOper.ExecuteTable(string.Format("select * from [{0}]", c)))).ToArray());
                    sb.AppendFormat(@"Use [{0}]

{1}

{2}

", dbHelperoper.DataBaseName, deleteSql, insertSql);
                }
                SaveText(sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 复制文件夹
        /// <summary>
        /// 复制文件夹
        /// </summary>
        /// <param name="f">来源文件夹</param>
        /// <param name="t">目标文件夹</param>
        private void DoCopy(DirectoryInfo f, DirectoryInfo t)
        {
            DirectoryInfo tempDire = new DirectoryInfo(string.Format("{0}\\{1}", t.FullName, f.Name));
            if (!tempDire.Exists)
                tempDire.Create();
            foreach (FileInfo fi in f.GetFiles())
            {
                if (KeepFiles.Count > 0)
                {
                    if (FormatFile(KeepFiles, fi.Name))
                        fi.CopyTo(string.Format("{0}\\{1}", tempDire.FullName, fi.Name), ReplaceFile);
                }
                else if (RemoveFiles.Count > 0)
                {
                    if (!FormatFile(RemoveFiles, fi.Name))
                        fi.CopyTo(string.Format("{0}\\{1}", tempDire.FullName, fi.Name), ReplaceFile);
                }
                else
                {
                    fi.CopyTo(string.Format("{0}\\{1}", tempDire.FullName, fi.Name), ReplaceFile);
                }
            }
            foreach (DirectoryInfo di in f.GetDirectories())
            {
                if (KeepDirectorys.Count > 0)
                {
                    //if ((FatherFirst && KeepDirectorys.Contains(di.Name)) || (ChildFirst && (KeepDirectorys.Contains(di.Name) || ExistDirectory(di, KeepDirectorys))))
                    if (KeepDirectorys.Contains(di.Name))
                    {
                        DoCopy(di, tempDire);
                    }
                }
                else if (RemoveDirectorys.Count > 0)
                {
                    if (!RemoveDirectorys.Contains(di.Name))
                        DoCopy(di, tempDire);
                }
                else
                {
                    DoCopy(di, tempDire);
                }
            }
        }
        #endregion

        #region 删除文件夹
        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="target">目标文件夹</param>
        private void DoDelete(DirectoryInfo target, bool directoryFirst)
        {
            DirectoryInfo[] dis = target.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                if (directoryFirst)
                    DoDelete(di, true);
                else if (KeepDirectorys.Count > 0)
                {
                    if (!KeepDirectorys.Contains(di.Name))
                        DoDelete(di, true);
                    else
                        DoDelete(di, false);
                }
                else if (RemoveDirectorys.Count > 0)
                {
                    if (RemoveDirectorys.Contains(di.Name))
                        DoDelete(di, true);
                    else
                        DoDelete(di, false);
                }
                else
                    DoDelete(di, true);
            }
            foreach (FileInfo fi in target.GetFiles())
            {
                if (directoryFirst)
                    fi.Delete();
                else if (KeepFiles.Count > 0)
                {
                    if (!FormatFile(KeepFiles, fi.Name))
                        fi.Delete();
                }
                else if (RemoveFiles.Count > 0)
                {
                    if (FormatFile(RemoveFiles, fi.Name))
                        fi.Delete();
                }
                else
                {
                    fi.Delete();
                }
            }
            if (directoryFirst)
                target.Delete();
        }
        #endregion

        #region 判断文件名称是否在过滤列表中
        /// <summary>
        /// 判断文件名称是否在过滤列表中
        /// </summary>
        /// <param name="formatList">过滤列表</param>
        /// <param name="value">文件名称</param>
        /// <returns></returns>
        private bool FormatFile(List<string> formatList, string value)
        {                     //复制所有文件
            if (formatList.Contains("*.*"))
                return true;
            else
            {
                string[] names = value.Split('.');
                string extensionName = names.Length > 1 ? names.Last() : string.Empty;
                string fileName = names.Length > 1 ? value.Substring(0, value.Length - extensionName.Length - 1) : value;
                #region 处理*.abc样式的文件
                foreach (var item in formatList.Where(c => c.Split('.').Length == 2 && c.Split('.')[0] == "*"))
                {
                    if (extensionName == item.Split('.')[1])
                        return true;
                }
                #endregion

                #region 处理abc.*样式的文件
                foreach (var item in formatList.Where(c => c.Split('.').Length == 2 && c.Split('.')[1] == "*"))
                {
                    string[] items = item.Split('.');
                    if (fileName == items[0])
                        return true;
                }
                #endregion

                #region 处理abc.def样式的文件
                foreach (var item in formatList.Where(c => !(c.Split('.').Length == 2 && (c.Split('.')[0] == "*" || c.Split('.')[1] == "*"))))
                {
                    if (item == value)
                        return true;
                }
                #endregion
            }
            return false;
        }
        #endregion

        #region 判断指定文件夹的子孙文件夹中是否存在指定名称的文件夹
        /// <summary>
        /// 判断指定文件夹的子孙文件夹中是否存在指定名称的文件夹
        /// </summary>
        /// <param name="f">文件夹</param>
        /// <param name="direName">名称</param>
        /// <returns></returns>
        private bool ExistDirectory(DirectoryInfo f, List<string> direName)
        {
            DirectoryInfo[] infos = f.GetDirectories();
            if (infos.Length > 0)
            {
                if (infos.Any(c => direName.Contains(c.Name)))
                    return true;
                else
                    foreach (DirectoryInfo di in infos)
                    {
                        if (ExistDirectory(di, direName))
                            return true;
                    }
            }
            return false;
        }
        #endregion

        #region 选择单个IP方案
        /// <summary>
        /// 选择单个IP方案
        /// </summary>
        /// <param name="schemeName">方案名称</param>
        private void SelectSingleIP(string schemeName)
        {
            var ipschemes = IPSchemeList.Where(c => c.Name == schemeName);
            if (ipschemes.Count() == 1)
            {
                var ipscheme = ipschemes.Single();
                tbxIPName.Text = ipscheme.Name;
                tbxIPAddress.Text = ipscheme.IPAddress;
                tbxSubNetMask.Text = ipscheme.SubNetMask;
                tbxDefaultIPGateWay.Text = ipscheme.DefaultIPGateway;
                tbxDNSServerSearchOrder.Text = ipscheme.DNSServerSearchOrder;
                tbxDNSServerSpare.Text = ipscheme.DNSServerSpare;
            }
        }
        #endregion

        #region 选择单个导出方案
        /// <summary>
        /// 选择单个导出方案
        /// </summary>
        /// <param name="schemeName"></param>
        private void SelectSingleOutput(string schemeName)
        {
            var outputschemes = OutputSchemeList.Where(c => c.Name == schemeName);
            if (outputschemes.Count() == 1)
            {
                var outputscheme = outputschemes.Single();
                tbxOutputName.Text = outputscheme.Name;
                tbxOutputTableName.Text = outputscheme.Table;
                tbxOutputSql.Text = outputscheme.Select;
                tbxOutputDelete.Text = outputscheme.Delete;
                cbbOutputDataSet.Text = outputscheme.DataBase;
            }
        }

        private void cbbCodeDataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dbHelperfrom = new DBHelper(dataSourceList[cbbCodeDataSource.SelectedItem.ToString()].Item1, connectType[dataSourceList[cbbCodeDataSource.SelectedItem.ToString()].Item2]);
                DbDataReader reader = DBFrom.ExecuteReader(GetTableNamesSearchSql(dataSourceList[cbbCodeDataSource.SelectedItem.ToString()].Item2));
                cbbCodeDataTable.Items.Clear();
                while (reader.Read())
                {
                    cbbCodeDataTable.Items.Add(reader.Get<string>("Name"));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 保存文件到桌面
        /// <summary>
        /// 保存文件到桌面
        /// </summary>
        /// <param name="text"></param>
        private void SaveText(string text)
        {
            FileStreamHelper.SaveText(deskPath, string.Format("{0}.sql", DateTime.Now.ToString("yyMMddHHmmss")), text);
        }
        #endregion

        #region 清除数据库日志
        /// <summary>
        /// 清除数据库日志
        /// </summary>
        /// <param name="ConnName">数据库连接名称</param>
        private void ClearDataLog(string ConnName)
        { }
        #endregion

        #region 获取表结构查询sql
        private string GetTableNamesSearchSql(string provider) {
            switch (provider) {
                case "SqlServer":
                    return tableSearchSql[0];
                case "MySql":
                    return tableSearchSql[1];
            }
            return "";
        }
        private string GetColumnsSearchSql(string provider)
        {
            switch (provider)
            {
                case "SqlServer":
                    return columnSearchSql[0];
                case "MySql":
                    return columnSearchSql[1];
            }
            return "";
        }
        #endregion
        #endregion
    }

    #region 结构
    #region 替换方案
    /// <summary>
    /// 替换方案
    /// </summary>
    struct ReplaceScheme
    {
        public string Name, OldStr, NewStr, FilePath;
    }
    #endregion

    #region IP方案
    /// <summary>
    /// IP方案
    /// </summary>
    struct IPScheme
    {
        public string Name, IPAddress, SubNetMask, DefaultIPGateway, DNSServerSearchOrder, DNSServerSpare;
        public List<ReplaceScheme> ReplaceSchemes;
    }
    #endregion

    #region 导出方案
    /// <summary>
    /// 导出方案
    /// </summary>
    struct OutputScheme
    {
        public string Name, Table, DataBase, Select, Delete;
    }
    #endregion

    #region 代码生成方案
    /// <summary>
    /// 代码生成方案
    /// </summary>
    class CodeTempleteScheme
    {
        public string Name, Path;
    }
    #endregion
    #endregion
}
