using System;
using System.Configuration;
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
                return tbxName.Text.Trim();
            }
        }

        /// <summary>
        /// 内容
        /// </summary>
        private string Content
        {
            get
            {
                return tbxContent.Text.Trim();
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

            DirectoryInfo di = new DirectoryInfo(string.Format("{0}{1}{2}", Application.StartupPath, configDataPath, configItemName));
            if (!di.Exists)
                di.Create();

            if (DataTree.Nodes.Count > 0)
                SelectSingleItem(DataTree.Nodes[0].Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm form = (MainForm)Owner;
            Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxName.Text))
            {
                XmlNodeList nodelist = configele.SelectNodes(string.Format("Item[@Name='{0}']", ReplaceName));
                if (nodelist.Count > 0)
                {
                    MessageBox.Show(string.Format("已存在名称为（{0}）的明细", ReplaceName));
                }
                else
                {
                    //保存XML
                    XmlElement ele = oper.Doc.CreateElement("Item");
                    ele.SetAttribute("Name", ReplaceName);
                    ele.SetAttribute("Type", cbbConfigType.Text);
                    ele.SetAttribute("DataBase", cbbDataBase.Text);
                    ele.SetAttribute("Path", tbxPath.Text);
                    oper.AddEle(ele, configele);
                    //保存文件
                    FileStreamHelper.SaveText(string.Format("{0}{1}{2}", Application.StartupPath, configDataPath, configItemName), ReplaceName, Content);
                    RefreshList();
                }
            }
            else
                MessageBox.Show("名称不能为空");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TreeNode node = DataTree.SelectedNode;
            if (node != null && !string.IsNullOrEmpty(ReplaceName))
            {
                if (ReplaceName == node.Text)
                {
                    XmlNodeList nodelist = configele.SelectNodes(string.Format("Item[@Name='{0}']", ReplaceName));
                    if (nodelist.Count > 0)
                    {
                        //保存XML
                        XmlElement ele = (XmlElement)nodelist[0];
                        ele.SetAttribute("Type", cbbConfigType.Text);
                        ele.SetAttribute("DataBase", cbbDataBase.Text);
                        ele.SetAttribute("Path", tbxPath.Text);
                        oper.Save();
                        //保存文件
                        FileInfo fi = new FileInfo(string.Format("{0}{1}{2}\\{3}", Application.StartupPath, configDataPath, configItemName, ReplaceName));
                        if (fi.Exists)
                            fi.Delete();
                        FileStreamHelper.SaveText(fi.DirectoryName, ReplaceName, Content);
                    }
                }
                else if (configele.SelectNodes(string.Format("Item[@Name='{0}']", ReplaceName)).Count >0)
                {
                    MessageBox.Show(string.Format("已存在名称为（{0}）的明细", ReplaceName));
                }
                else
                {
                    XmlNodeList nodelist = configele.SelectNodes(string.Format("Item[@Name='{0}']", node.Text));
                    if (nodelist.Count > 0)
                    {
                        //保存XML
                        XmlElement ele = (XmlElement)nodelist[0];
                        ele.SetAttribute("Name", ReplaceName);
                        ele.SetAttribute("Type", cbbConfigType.Text);
                        ele.SetAttribute("DataBase", cbbDataBase.Text);
                        ele.SetAttribute("Path", tbxPath.Text);
                        oper.Save();
                        //保存文件
                        FileInfo fi = new FileInfo(string.Format("{0}{1}{2}\\{3}", Application.StartupPath, configDataPath, configItemName, node.Text));
                        if (fi.Exists)
                            fi.Delete();
                        FileStreamHelper.SaveText(fi.DirectoryName, ReplaceName, Content);
                        RefreshList();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TreeNode node = DataTree.SelectedNode;
            if (node == null)
                return;
            XmlNodeList nodelist = configele.SelectNodes(string.Format("Item[@Name='{0}']", node.Text));
            if (nodelist.Count > 0)
            {
                oper.DeleteNode(nodelist[0]);
                FileInfo fi = new FileInfo(string.Format("{0}{1}{2}\\{3}", Application.StartupPath, configDataPath, configItemName, node.Text));
                if (fi.Exists)
                    fi.Delete();
                RefreshList();
            }
        }

        private void DataTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectSingleItem(DataTree.SelectedNode.Text);
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbxPath.Text = openFileDialog1.FileName;
            }
        }

        private void lblStr_Click(object sender, EventArgs e)
        {
            tbxContent.Focus();
            tbxContent.SelectAll();
        }
        #endregion

        #region 私有函数
        /// <summary>
        /// 刷新数据源
        /// </summary>
        private void RefreshList()
        {
            DataTree.Nodes.Clear();

            configele = oper.QueryEle(string.Format("/Base/ConfigAddress/Config[@Name='{0}']", configItemName));
            foreach (XmlNode node in configele.ChildNodes)
            {
                DataTree.Nodes.Add(((XmlElement)node).GetAttribute("Name"));
            }
        }

        private void SelectSingleItem(string itemName)
        {
            tbxName.Text = itemName;
            XmlNodeList nodelist = configele.SelectNodes(string.Format("Item[@Name='{0}']", itemName));
            if (nodelist.Count > 0)
            {
                XmlElement ele = (XmlElement)nodelist[0];
                tbxName.Text = ele.GetAttribute("Name");
                cbbConfigType.Text = ele.GetAttribute("Type");
                cbbDataBase.Text = ele.GetAttribute("DataBase");
                tbxPath.Text = ele.GetAttribute("Path");
                tbxContent.Text = FileStreamHelper.ReadText(string.Format("{0}{1}{2}\\{3}", Application.StartupPath, configDataPath, configItemName, ele.GetAttribute("Name")));
            }
        }
        #endregion
    }
}
