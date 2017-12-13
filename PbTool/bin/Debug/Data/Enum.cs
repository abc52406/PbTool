using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DataDiffTool
{
    /// <summary>
    /// 操作类型
    /// </summary>
    [Description("操作类型")]
    public enum FuncType
    {
        /// <summary>
        /// 添加
        /// </summary>
        [Description("添加")]
        Add,
        /// <summary>
        /// 修改
        /// </summary>
        [Description("修改")]
        Edit,
        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        Delete,
        /// <summary>
        /// 查看
        /// </summary>
        [Description("查看")]
        View
    }

    /// <summary>
    /// 数据类型
    /// </summary>
    [Description("数据类型")]
    public enum DataType
    {
        /// <summary>
        /// 表
        /// </summary>
        [Description("表")]
        DataTable,
        /// <summary>
        /// 库
        /// </summary>
        [Description("库")]
        DataSet
    }

    /// <summary>
    /// 导出方式
    /// </summary>
    [Description("导出方式")]
    public enum ExportType
    {
        /// <summary>
        /// Excel导出
        /// </summary>
        [Description("Excel导出")]
        Xls,
        /// <summary>
        /// 文本导出
        /// </summary>
        [Description("文本导出")]
        Txt
    }

    /// <summary>
    /// 比较方式
    /// </summary>
    [Description("比较方式")]
    public enum CompareType
    {
        /// <summary>
        /// 删除不匹配项
        /// </summary>
        [Description("删除不匹配项")]
        D,
        /// <summary>
        /// 覆盖不匹配项
        /// </summary>
        [Description("覆盖不匹配项")]
        C,
        /// <summary>
        /// 追加不匹配项
        /// </summary>
        [Description("追加不匹配项")]
        A,
        /// <summary>
        /// 更新Key相同但其他字段不匹配项
        /// </summary>
        [Description("更新Key相同但其他字段不匹配项")]
        U
    }
}
