using System;
using System.Configuration;
using System.Windows.Forms;
using System.Xml;
using Pb.Library;

namespace PbTool
{
    public partial class DataConnectList : Form
    {
        #region 构造函数
        public DataConnectList()
        {
            InitializeComponent();
        }
        #endregion

        #region 私有变量
        private XmlHelper oper;
        private string dataSetConfigPath = ConfigurationSettings.AppSettings["SourcePath"];
        #endregion

        #region 私有属性
        /// <summary>
        /// 连接名称
        /// </summary>
        private string ConnectName
        {
            get
            {
                return DataName.Text.Trim();
            }
        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        private string ConnectString
        {
            get
            {
                return DataConnect.Text.Trim();
            }
        }

        /// <summary>
        /// 连接类型
        /// </summary>
        private string ConnectType
        {
            get
            {
                return cbbConnectType.SelectedItem.ToString();
            }
        }
        #endregion

        #region 事件
        private void DataConnectList_Load(object sender, EventArgs e)
        {
            oper = new XmlHelper(string.Format("{0}{1}", Application.StartupPath, dataSetConfigPath), XmlType.Path);

            RefreshList();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm form = (MainForm)Owner;
            form.RefreshDataSources();
            Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DataName.Text))
            {
                if (oper.Exist(string.Format("/Base/DataConnections/Connection[@Name='{0}']", ConnectName)))
                    MessageBox.Show(string.Format("已存在名称为（{0}）的数据源", ConnectName));
                else
                {
                    XmlElement ele = oper.Doc.CreateElement("Connection");
                    ele.SetAttribute("Name", ConnectName);
                    ele.SetAttribute("Type", ConnectType);
                    ele.InnerText = ConnectString;
                    oper.AddEle(ele, "/Base/DataConnections");
                    RefreshList();
                }
            }
            else
                MessageBox.Show("名称不能为空");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TreeNode node= DataTree.SelectedNode;
            if (node != null&&!string.IsNullOrEmpty(ConnectName))
            {
                if (ConnectName == DataTree.SelectedNode.Name)
                {
                    XmlElement ele = oper.QueryEle(string.Format("/Base/DataConnections/Connection[@Name='{0}']", ConnectName));
                    ele.SetAttribute("Type", ConnectType);
                    ele.InnerText = ConnectString;
                    oper.Save();
                    RefreshList();
                }
                else if (oper.Exist(string.Format("/Base/DataConnections/Connection[@Name='{0}']", ConnectName)))
                {
                    MessageBox.Show(string.Format("已存在名称为（{0}）的数据源", ConnectName));
                }
                else
                {
                    XmlElement ele = oper.QueryEle(string.Format("/Base/DataConnections/Connection[@Name='{0}']", DataTree.SelectedNode.Name));
                    ele.SetAttribute("Name", ConnectName);
                    ele.SetAttribute("Type", ConnectType);
                    ele.InnerText = ConnectString;
                    oper.Save();
                    RefreshList();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TreeNode node = DataTree.SelectedNode;
            if (node != null)
            {
                oper.DeleteNode(string.Format("/Base/DataConnections/Connection[@Name='{0}']", DataTree.SelectedNode.Name));
                RefreshList();
            }
        }

        private void DataTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataName.Text = DataTree.SelectedNode.Name;
            XmlElement ele = oper.QueryEle(string.Format("/Base/DataConnections/Connection[@Name='{0}']", ConnectName));
            if (ele != null) {
                DataConnect.Text = ele.InnerText;
                if (string.IsNullOrWhiteSpace(ele.GetAttribute("Type")))
                    cbbConnectType.SelectedItem = "SqlServer";
                else
                    cbbConnectType.SelectedItem = ele.GetAttribute("Type");
            }
        }
        #endregion

        #region 私有函数
        /// <summary>
        /// 刷新数据源
        /// </summary>
        private void RefreshList()
        {
            DataTree.Nodes.Clear();

            XmlNodeList list = oper.QueryNodes("/Base/DataConnections/Connection");

            if (list != null)
            {
                foreach (XmlNode node in list)
                {
                    DataTree.Nodes.Add(((XmlElement)node).GetAttribute("Name"),((XmlElement)node).GetAttribute("Name"));
                }
            }
        }
        #endregion
    }
}
