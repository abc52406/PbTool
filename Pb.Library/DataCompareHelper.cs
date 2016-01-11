using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Pb.Library
{
    public static class DataCompareHelper
    {
        /// <summary>
        /// 查询两张表的数据差异
        /// </summary>
        /// <param name="conFrom">源数据连接</param>
        /// <param name="tableFrom">源表</param>
        /// <param name="providerFrom">源数据类型</param>
        /// <param name="whereStrFrom">源数据筛选条件</param>
        /// <param name="conTo">目标数据连接</param>
        /// <param name="TableTo">目标表</param>
        /// <param name="providerTo">目标数据类型</param>
        /// <param name="whereStrTo">目标数据筛选条件</param>
        /// <param name="fields">比较的字段</param>
        /// <param name="primaryKeys">主键</param>
        /// <returns>目标表中与源表不一样的数据</returns>
        public static IEnumerable<DataRow> QueryDiffRows(string conFrom, string tableFrom,string providerFrom,string whereStrFrom, string conTo, string TableTo,string providerTo,string whereStrTo,string fields,string primaryKeys)
        {
            //差异数据存储器
            List<DataRow> diff = new List<DataRow>();
            //目标数据的表结构
            //TableSchema st = new TableSchema(new DatabaseSchema(new SqlSchemaProvider(), conTo), TableTo, "dbo", DateTime.MinValue);
            DataTable st = new DBHelper(conTo, providerTo).ExecuteTable(string.Format(ConfigurationSettings.AppSettings["ColumnSearchSql"], TableTo));
            //查询两个数据源
            DataTable dtFrom = new DBHelper(conFrom, providerFrom).ExecuteTable(string.Format("select {0} from {1} {2}", fields, tableFrom, string.IsNullOrEmpty(whereStrFrom) ? "" : string.Format(" where {0}", whereStrFrom)));
            DataTable dtTo = new DBHelper(conTo, providerTo).ExecuteTable(string.Format("select {0} from {1} {2}", fields, TableTo, string.IsNullOrEmpty(whereStrTo) ? "" : string.Format(" where {0}", whereStrTo)));
            //如果主键只有1列，则开始判断（暂时只处理主键只有一个的逻辑）

            List<string> pks = new List<string>();
            if (!string.IsNullOrEmpty(primaryKeys))
                pks = primaryKeys.Split(',').ToList();
            else
                pks = st.AsEnumerable().Where(c => c["pk"].ToString() == "1").Select(c => c["name"].ToString()).ToList();
            #region 开始判断
            if (pks.Count == 1)
            {
                string pk = pks[0];
                var unpk = st.AsEnumerable().Where(c => c["pk"].ToString() == "0").Select(c => c["name"].ToString()).ToList();
                foreach (var item in dtTo.AsEnumerable())
                {
                    var sourceitems =dtFrom.AsEnumerable().Where(c=>c[pk].ToString() == item[pk].ToString());
                    if (sourceitems.Count() == 0)
                        diff.Add(item);
                    else
                    {
                        var sourceitem=sourceitems.First();
                        foreach (var up in st.AsEnumerable().Where(c => c["pk"].ToString() == "0").ToList())
                        {
                            bool add = false;

                            #region 非主键判断
                            #region 如果一个为空，另一个不空，则两者不相等
                            if ((sourceitem[up["name"].ToString()] != DBNull.Value && item[up["name"].ToString()] == DBNull.Value) || (sourceitem[up["name"].ToString()] == DBNull.Value && item[up["name"].ToString()] != DBNull.Value))
                            {
                                diff.Add(item);
                                add = true;
                            }
                            #endregion

                            #region 如果都不为空，则将数据类型转换后再比较（如果不转换，会通通认为不相等）
                            else if (sourceitem[up["name"].ToString()] != DBNull.Value && item[up["name"].ToString()] != DBNull.Value)
                            {
                                switch (up["ctype"].ToString())
                                {
                                    case "varchar":
                                    case "nvarchar":
                                    case "char":
                                    case "nchar":
                                    case "text":
                                    case "ntext":
                                        if (sourceitem[up["name"].ToString()].ToString() != item[up["name"].ToString()].ToString())
                                        {
                                            diff.Add(item);
                                            add = true;
                                        }
                                        break;
                                    case "bit":
                                        if (Convert.ToBoolean(sourceitem[up["name"].ToString()]) != Convert.ToBoolean(item[up["name"].ToString()]))
                                        {
                                            diff.Add(item);
                                            add = true;
                                        }
                                        break;
                                    case "int":
                                    case "bigint":
                                    case "tinyint":
                                        if (Convert.ToInt64(sourceitem[up["name"].ToString()]) != Convert.ToInt64(item[up["name"].ToString()]))
                                        {
                                            diff.Add(item);
                                            add = true;
                                        }
                                        break;
                                    case "decimal":
                                    case "numeric":
                                        if (Convert.ToDecimal(sourceitem[up["name"].ToString()]) != Convert.ToDecimal(item[up["name"].ToString()]))
                                        {
                                            diff.Add(item);
                                            add = true;
                                        }
                                        break;
                                    case "date":
                                    case "datetime":
                                    case "datetime2":
                                    case "datetimeoffset":
                                        if (Convert.ToDateTime(sourceitem[up["name"].ToString()]) != Convert.ToDateTime(item[up["name"].ToString()]))
                                        {
                                            diff.Add(item);
                                            add = true;
                                        }
                                        break;
                                    case "float":
                                        if (Convert.ToDouble(sourceitem[up["name"].ToString()]) != Convert.ToDouble(item[up["name"].ToString()]))
                                        {
                                            diff.Add(item);
                                            add = true;
                                        }
                                        break;
                                }
                            }
                            #endregion
                            #endregion

                            //如果该行已被判断为不一样，则跳出循环去判断下一行
                            if (add)
                                break;
                        }
                    }
                }
            }
            #endregion

            string whereStr = string.Join(") or (", diff.Select(c => string.Join(" and ", pks.Select(d => string.Format(" {0}='{1}' ", d, c[d])).ToArray())).ToArray());

            if (string.IsNullOrEmpty(whereStr.Trim()))
                return new List<DataRow>();
            else
                return dtTo.Select(string.Format("({0})", whereStr));
        }

        /// <summary>
        /// 查询两张表的数据差异
        /// </summary>
        /// <param name="conFrom">源数据连接</param>
        /// <param name="tableFrom">源表</param>
        /// <param name="providerFrom">源数据类型</param>
        /// <param name="whereStrFrom">源数据筛选条件</param>
        /// <param name="conTo">目标数据连接</param>
        /// <param name="TableTo">目标表</param>
        /// <param name="providerTo">目标数据类型</param>
        /// <param name="whereStrTo">目标数据筛选条件</param>
        /// <param name="fields">查询字段</param>
        /// <returns>目标表中与源表不一样的数据</returns>
        public static IEnumerable<DataRow> QueryDiffRows(string conFrom, string tableFrom, string providerFrom, string whereStrFrom, string conTo, string TableTo, string providerTo, string whereStrTo, string fields)
        {
            return QueryDiffRows(conFrom, tableFrom, providerFrom, whereStrFrom, conTo, TableTo, providerTo, whereStrTo, fields, null);
        }

        /// <summary>
        /// 查询两张表的数据差异
        /// </summary>
        /// <param name="conFrom">源数据连接</param>
        /// <param name="tableFrom">源表</param>
        /// <param name="providerFrom">源数据类型</param>
        /// <param name="whereStrFrom">源数据筛选条件</param>
        /// <param name="conTo">目标数据连接</param>
        /// <param name="TableTo">目标表</param>
        /// <param name="providerTo">目标数据类型</param>
        /// <param name="whereStrTo">目标数据筛选条件</param>
        /// <returns>目标表中与源表不一样的数据</returns>
        public static IEnumerable<DataRow> QueryDiffRows(string conFrom, string tableFrom, string providerFrom, string whereStrFrom, string conTo, string TableTo, string providerTo, string whereStrTo)
        {
            return QueryDiffRows(conFrom, tableFrom, providerFrom, whereStrFrom, conTo, TableTo, providerTo, whereStrTo, "*");
        }

        /// <summary>
        /// 查询两张表的数据差异
        /// </summary>
        /// <param name="conFrom">源数据连接</param>
        /// <param name="tableFrom">源表</param>
        /// <param name="providerFrom">源数据类型</param>
        /// <param name="conTo">目标数据连接</param>
        /// <param name="TableTo">目标表</param>
        /// <param name="providerTo">目标数据类型</param>
        /// <returns>目标表中与源表不一样的数据</returns>
        public static IEnumerable<DataRow> QueryDiffRows(string conFrom, string tableFrom, string providerFrom, string conTo, string TableTo, string providerTo)
        {
            return QueryDiffRows(conFrom, tableFrom, providerFrom, null, conTo, TableTo, providerTo, null, "*", null);
        }
    }
}
