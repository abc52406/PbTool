﻿using System;
using System.Configuration;
using System.Drawing;
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
                return this.DataName.Text.Trim();
            }
        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        private string ConnectString
        {
            get
            {
                return this.DataConnect.Text.Trim();
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
            MainForm form = (MainForm)this.Owner;
            form.RefreshDataSources();
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.DataName.Text))
            {
                if (oper.Exist(string.Format("/Base/DataConnections/Connection[@Name='{0}']", this.ConnectName)))
                    MessageBox.Show(string.Format("已存在名称为（{0}）的数据源", this.ConnectName));
                else
                {
                    XmlElement ele = oper.Doc.CreateElement("Connection");
                    ele.SetAttribute("Name", this.ConnectName);
                    ele.InnerText = this.ConnectString;
                    oper.AddEle(ele, "/Base/DataConnections");
                    this.RefreshList();
                }
            }
            else
                MessageBox.Show("名称不能为空");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TreeNode node=this.DataTree.SelectedNode;
            if (node != null&&!string.IsNullOrEmpty(this.ConnectName))
            {
                if (this.ConnectName == this.DataTree.SelectedNode.Name)
                {
                    XmlElement ele = oper.QueryEle(string.Format("/Base/DataConnections/Connection[@Name='{0}']", this.ConnectName));
                    ele.InnerText = this.ConnectString;
                    oper.Save();
                    this.RefreshList();
                }
                else if (oper.Exist(string.Format("/Base/DataConnections/Connection[@Name='{0}']", this.ConnectName)))
                {
                    MessageBox.Show(string.Format("已存在名称为（{0}）的数据源", this.ConnectName));
                }
                else
                {
                    XmlElement ele = oper.QueryEle(string.Format("/Base/DataConnections/Connection[@Name='{0}']", this.DataTree.SelectedNode.Name));
                    ele.SetAttribute("Name", this.ConnectName);
                    ele.InnerText = this.ConnectString;
                    oper.Save();
                    this.RefreshList();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TreeNode node = this.DataTree.SelectedNode;
            if (node != null)
            {
                oper.DeleteNode(string.Format("/Base/DataConnections/Connection[@Name='{0}']", this.DataTree.SelectedNode.Name));
                this.RefreshList();
            }
        }

        private void DataTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.DataName.Text = this.DataTree.SelectedNode.Name;
            XmlElement ele = oper.QueryEle(string.Format("/Base/DataConnections/Connection[@Name='{0}']", this.ConnectName));
            if (ele != null)
                this.DataConnect.Text = ele.InnerText;
        }
        #endregion

        #region 私有函数
        /// <summary>
        /// 刷新数据源
        /// </summary>
        private void RefreshList()
        {
            this.DataTree.Nodes.Clear();

            XmlNodeList list = oper.QueryNodes("/Base/DataConnections/Connection");

            if (list != null)
            {
                foreach (XmlNode node in list)
                {
                    this.DataTree.Nodes.Add(((XmlElement)node).GetAttribute("Name"),((XmlElement)node).GetAttribute("Name"));
                }
            }
        }
        #endregion
    }
}
