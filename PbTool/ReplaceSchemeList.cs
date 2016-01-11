using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Pb.Library;
using System.IO;

namespace PbTool
{
    public partial class ReplaceSchemeList : Form
    {
        #region 构造函数
        public ReplaceSchemeList()
        {
            InitializeComponent();
        }
        #endregion

        #region 公共属性
        private string configItemName;
        /// <summary>
        /// IP方案名称
        /// </summary>
        public string ConfigItemName
        {
            set
            {
                configItemName = value;
            }
        }
        #endregion

        #region 私有变量
        private XmlHelper oper;
        private string dataSetConfigPath = ConfigurationSettings.AppSettings["SourcePath"];
        private string configDataPath = ConfigurationSettings.AppSettings["ConfigDataPath"];
        private XmlElement configele;
        #endregion

        #region 私有属性
        /// <summary>
        /// 替换方案名称
        /// </summary>
        private string ReplaceName
        {
            get
            {
                return this.tbxName.Text.Trim();
            }
        }

        /// <summary>
        /// 内容
        /// </summary>
        private string Content
        {
            get
            {
                return this.tbxContent.Text.Trim();
            }
        }
        #endregion

        #region 事件
        private void DataConnectList_Load(object sender, EventArgs e)
        {
            oper = new XmlHelper(string.Format("{0}{1}", Application.StartupPath, dataSetConfigPath), XmlType.Path);

            RefreshList();

            XmlNodeList list = oper.QueryNodes("/Base/DataConnections/Connection");
            cbbDataBase.Items.Clear();
            foreach (XmlNode node in list)
            {
                XmlElement ele = (XmlElement)node;
                cbbDataBase.Items.Add(ele.GetAttribute("Name"));
            }

            DirectoryInfo di = new DirectoryInfo(string.Format("{0}{1}{2}", Application.StartupPath, configDataPath, this.configItemName));
            if (!di.Exists)
                di.Create();

            if (this.DataTree.Nodes.Count > 0)
                SelectSingleItem(this.DataTree.Nodes[0].Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm form = (MainForm)this.Owner;
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tbxName.Text))
            {
                XmlNodeList nodelist = configele.SelectNodes(string.Format("Item[@Name='{0}']", this.ReplaceName));
                if (nodelist.Count > 0)
                {
                    MessageBox.Show(string.Format("已存在名称为（{0}）的明细", this.ReplaceName));
                }
                else
                {
                    //保存XML
                    XmlElement ele = oper.Doc.CreateElement("Item");
                    ele.SetAttribute("Name", this.ReplaceName);
                    ele.SetAttribute("Type", this.cbbConfigType.Text);
                    ele.SetAttribute("DataBase", this.cbbDataBase.Text);
                    ele.SetAttribute("Path", this.tbxPath.Text);
                    oper.AddEle(ele, configele);
                    //保存文件
                    FileStreamHelper.SaveText(string.Format("{0}{1}{2}", Application.StartupPath, configDataPath, this.configItemName), this.ReplaceName, this.Content);
                    this.RefreshList();
                }
            }
            else
                MessageBox.Show("名称不能为空");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TreeNode node = this.DataTree.SelectedNode;
            if (node != null && !string.IsNullOrEmpty(this.ReplaceName))
            {
                if (this.ReplaceName == node.Text)
                {
                    XmlNodeList nodelist = configele.SelectNodes(string.Format("Item[@Name='{0}']", this.ReplaceName));
                    if (nodelist.Count > 0)
                    {
                        //保存XML
                        XmlElement ele = (XmlElement)nodelist[0];
                        ele.SetAttribute("Type", this.cbbConfigType.Text);
                        ele.SetAttribute("DataBase", this.cbbDataBase.Text);
                        ele.SetAttribute("Path", this.tbxPath.Text);
                        oper.Save();
                        //保存文件
                        FileInfo fi = new FileInfo(string.Format("{0}{1}{2}\\{3}", Application.StartupPath, configDataPath, this.configItemName, this.ReplaceName));
                        if (fi.Exists)
                            fi.Delete();
                        FileStreamHelper.SaveText(fi.DirectoryName, this.ReplaceName, this.Content);
                    }
                }
                else if (configele.SelectNodes(string.Format("Item[@Name='{0}']", this.ReplaceName)).Count >0)
                {
                    MessageBox.Show(string.Format("已存在名称为（{0}）的明细", this.ReplaceName));
                }
                else
                {
                    XmlNodeList nodelist = configele.SelectNodes(string.Format("Item[@Name='{0}']", node.Text));
                    if (nodelist.Count > 0)
                    {
                        //保存XML
                        XmlElement ele = (XmlElement)nodelist[0];
                        ele.SetAttribute("Name", this.ReplaceName);
                        ele.SetAttribute("Type", this.cbbConfigType.Text);
                        ele.SetAttribute("DataBase", this.cbbDataBase.Text);
                        ele.SetAttribute("Path", this.tbxPath.Text);
                        oper.Save();
                        //保存文件
                        FileInfo fi = new FileInfo(string.Format("{0}{1}{2}\\{3}", Application.StartupPath, configDataPath, this.configItemName, node.Text));
                        if (fi.Exists)
                            fi.Delete();
                        FileStreamHelper.SaveText(fi.DirectoryName, this.ReplaceName, this.Content);
                        this.RefreshList();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TreeNode node = this.DataTree.SelectedNode;
            if (node == null)
                return;
            XmlNodeList nodelist = configele.SelectNodes(string.Format("Item[@Name='{0}']", node.Text));
            if (nodelist.Count > 0)
            {
                oper.DeleteNode(nodelist[0]);
                FileInfo fi = new FileInfo(string.Format("{0}{1}{2}\\{3}", Application.StartupPath, configDataPath, this.configItemName, node.Text));
                if (fi.Exists)
                    fi.Delete();
                this.RefreshList();
            }
        }

        private void DataTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectSingleItem(this.DataTree.SelectedNode.Text);
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.tbxPath.Text = this.openFileDialog1.FileName;
            }
        }

        private void lblStr_Click(object sender, EventArgs e)
        {
            this.tbxContent.Focus();
            this.tbxContent.SelectAll();
        }
        #endregion

        #region 私有函数
        /// <summary>
        /// 刷新数据源
        /// </summary>
        private void RefreshList()
        {
            this.DataTree.Nodes.Clear();

            configele = oper.QueryEle(string.Format("/Base/ConfigAddress/Config[@Name='{0}']", this.configItemName));
            foreach (XmlNode node in configele.ChildNodes)
            {
                this.DataTree.Nodes.Add(((XmlElement)node).GetAttribute("Name"));
            }
        }

        private void SelectSingleItem(string itemName)
        {
            this.tbxName.Text = itemName;
            XmlNodeList nodelist = configele.SelectNodes(string.Format("Item[@Name='{0}']", itemName));
            if (nodelist.Count > 0)
            {
                XmlElement ele = (XmlElement)nodelist[0];
                this.tbxName.Text = ele.GetAttribute("Name");
                this.cbbConfigType.Text = ele.GetAttribute("Type");
                this.cbbDataBase.Text = ele.GetAttribute("DataBase");
                this.tbxPath.Text = ele.GetAttribute("Path");
                this.tbxContent.Text = FileStreamHelper.ReadText(string.Format("{0}{1}{2}\\{3}", Application.StartupPath, configDataPath, this.configItemName, ele.GetAttribute("Name")));
            }
        }
        #endregion
    }
}
