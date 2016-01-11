using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Pb.Library
{
    public static class SqlHelper
    {
        #region 生成带参数的Insert语句
        /// <summary>
        /// 生成带参数的Insert语句
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static string CreateInsertSqlWithParameter(string tableName, DataRow dr)
        {
            var cls = DbTool.GetColumns(dr);
            return CreateInsertSqlWithParameter(tableName, cls);
        }

        /// <summary>
        /// 生成带参数的Insert语句
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string CreateInsertSqlWithParameter(string tableName, DataTable dt)
        {
            var cls = DbTool.GetColumns(dt);
            return CreateInsertSqlWithParameter(tableName, cls);
        }

        /// <summary>
        /// 生成带参数的Insert语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columnNames">列名</param>
        /// <returns></returns>
        public static string CreateInsertSqlWithParameter(string tableName, List<string> columnNames)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("Insert into [{0}] (", tableName);
            strSql.AppendFormat("[{0}] )", string.Join("],[", columnNames.ToArray()));
            strSql.Append(" values (");
            strSql.AppendFormat("@{0} )", string.Join(",@", columnNames.ToArray()));

            return strSql.ToString();
        }
        #endregion

        #region 生成Insert语句
        /// <summary>
        /// 生成Insert语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="dr">数据</param>
        /// <returns></returns>
        public static string CreateInsertSql(string tableName, DataRow dr)
        {
            List<string> strFields = new List<string>();
            List<string> strValues = new List<string>();
            foreach (var pair in DbTool.GetColumns(dr))
            {
                strFields.Add(string.Format("[{0}]", pair));
                strValues.Add(dr[pair] == DBNull.Value ? "null" : string.Format("'{0}'",dr[pair].ToString().Replace("'", "''")));
            }
            string insertSql = string.Format("Insert Into [{0}]({1}) values({2})",
                tableName, string.Join(",",strFields.ToArray()), string.Join(",",strValues.ToArray()));
            return insertSql;
        }

        /// <summary>
        /// 生成Insert语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="dt">数据</param>
        /// <returns></returns>
        public static string CreateInsertSql(string tableName, DataTable dt)
        {
            return string.Join(@"
",dt.AsEnumerable().Select(c=>CreateInsertSql(tableName,c)).ToArray());
        }

        /// <summary>
        /// 生成Insert语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="drs">数据</param>
        /// <returns></returns>
        public static string CreateInsertSql(string tableName, IEnumerable<DataRow> drs)
        {
            return string.Join(@"
", drs.Select(c => CreateInsertSql(tableName, c)).ToArray());
        }
        #endregion

        #region  生成Update语句
        public static string CreateUpdateSql(string tableName, DataRow dr,string whereStr)
        {
            List<string> valueStr = new List<string>();
            foreach (DataColumn dp in dr.Table.Columns)
            {
                valueStr.Add(string.Format("{0}='{1}'", dp.ColumnName, dr[dp.ColumnName]));
            }
            return string.Format("Update [{0}] Set {1} Where {2}", tableName, string.Join(",", valueStr.ToArray()), whereStr);
        }

        public static string CreateUpdateSql(string tableName, Dictionary<DataRow,string> data)
        {
            return string.Join(@"
", data.Select(c => CreateUpdateSql(tableName, c.Key, c.Value)).ToArray());
        }
        #endregion

        #region  生成Delete语句
        /// <summary>
        /// 生成Delete语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="dr">数据</param>
        /// <returns></returns>
        public static string CreateDeleteSql(string tableName, DataRow dr)
        {
            return string.Format("Delete [{0}] where {1}", tableName, string.Join(" and ", dr.Table.PrimaryKey.Select(c => string.Format(" {0}='{1}' ", c.ColumnName, dr[c.ColumnName])).ToArray()));
        }

        /// <summary>
        /// 生成Delete语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="dr">数据</param>
        /// <returns></returns>
        public static string CreateDeleteSql(string tableName, DataTable dt)
        {
            List<string> whereStr = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                whereStr.Add(string.Join(" and ", dt.PrimaryKey.Select(c => string.Format(" {0}='{1}' ", c.ColumnName, dr[c.ColumnName])).ToArray()));
            }
            return string.Format("Delete [{0}] where ({1})", tableName, string.Join(") or (", whereStr.ToArray()));
        }

        /// <summary>
        /// 生成Delete语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="dr">数据</param>
        /// <returns></returns>
        public static string CreateDeleteSql(string tableName, IEnumerable<DataRow> drs)
        {
            List<string> whereStr = new List<string>();
            foreach (DataRow dr in drs)
            {
                whereStr.Add(string.Join(" and ", dr.Table.PrimaryKey.Select(c => string.Format(" {0}='{1}' ", c.ColumnName, dr[c.ColumnName])).ToArray()));
            }
            return string.Format("Delete [{0}] where ({1})", tableName, string.Join(") or (", whereStr.ToArray()));
        }

        /// <summary>
        /// 生成Delete语句
        /// </summary>
        /// <param name="tableNames">表名</param>
        /// <returns></returns>
        public static string CreateDeleteSql(List<string> tableNames)
        {
            return string.Join(@"
", (from name in tableNames select string.Format("delete [{0}]", name)).ToArray());
        }
        #endregion

        #region 获取Select语句
        /// <summary>
        /// 生成查询语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="primaryKey">主键</param>
        /// <param name="dt">数据</param>
        /// <returns></returns>
        public static string CreateSearchSql(string tableName, string primaryKey, DataTable dt)
        {
            return string.Format("select * from {0} where {1} in ('{2}')", tableName, primaryKey, string.Join("','", dt.AsEnumerable().Select(c => c[primaryKey].ToString()).ToArray()));
        }

        /// <summary>
        /// 生成查询语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="primaryKey">主键</param>
        /// <param name="drs">数据</param>
        /// <returns></returns>
        public static string CreateSearchSql(string tableName, string primaryKey, DataRow[] drs)
        {
            return string.Format("select * from {0} where {1} in ('{2}')", tableName, primaryKey, string.Join("','", drs.Select(c => c[primaryKey].ToString()).ToArray()));
        }

        /// <summary>
        /// 生成查询语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="primaryKey">主键</param>
        /// <param name="dr">数据</param>
        /// <returns></returns>
        public static string CreateSearchSql(string tableName, string primaryKey, DataRow dr)
        {
            return string.Format("select * from {0} where {1}='{2}'", tableName, primaryKey, dr[primaryKey]);
        }

        /// <summary>
        /// 生成查询语句
        /// </summary>
        /// <param name="conStr">数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="owner">表来源</param>
        /// <param name="dt">数据</param>
        /// <returns></returns>
        public static string CreateSearchSql(string conStr, string tableName, string owner, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                //TableSchema st = new TableSchema(new DatabaseSchema(new SqlSchemaProvider(), conStr), tableName, owner, DateTime.MinValue);
                DataTable st = new DBHelper(conStr).ExecuteTable(string.Format(ConfigurationSettings.AppSettings["ColumnSearchSql"], tableName));
                return string.Format("select * from {0} where ({1})", tableName, string.Join(") or (", dt.AsEnumerable().Select(d => string.Join(" and ", st.AsEnumerable().Where(c => c["pk"].ToString() == "1").ToArray().Select(c => string.Format(" {0}='{1}' ", c["name"], d[c["name"].ToString()])).ToArray())).ToArray()));
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// 生成查询语句
        /// </summary>
        /// <param name="conStr">数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="owner">表来源</param>
        /// <param name="drs">数据</param>
        /// <returns></returns>
        public static string CreateSearchSql(string conStr, string tableName, string owner, DataRow[] drs)
        {
            if (drs.Length > 0)
            {
                //TableSchema st = new TableSchema(new DatabaseSchema(new SqlSchemaProvider(), conStr), tableName, owner, DateTime.MinValue);
                DataTable st = new DBHelper(conStr).ExecuteTable(string.Format(ConfigurationSettings.AppSettings["ColumnSearchSql"], tableName));
                return string.Format("select * from {0} where ({1})", tableName, string.Join(") or (", drs.Select(c => string.Join(" and ", st.AsEnumerable().Where(d => d["pk"].ToString() == "0").ToArray().Select(d => string.Format(" {0}='{1}' ", d["name"], c[d["name"].ToString()])).ToArray())).ToArray()));
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// 生成查询语句
        /// </summary>
        /// <param name="conStr">数据库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="owner">表来源</param>
        /// <param name="dr">数据</param>
        /// <returns></returns>
        public static string CreateSearchSql(string conStr, string tableName, string owner, DataRow dr)
        {
            //TableSchema dt = new TableSchema(new DatabaseSchema(new SqlSchemaProvider(), conStr), tableName, owner, DateTime.MinValue);
            DataTable st = new DBHelper(conStr).ExecuteTable(string.Format(ConfigurationSettings.AppSettings["ColumnSearchSql"], tableName));
            var pkWhereStr = from pk in st.AsEnumerable().Where(c => c["pk"].ToString() == "0").ToArray() select string.Format(" {0}='{1}' ", pk["name"], dr[pk["name"].ToString()]);
            return string.Format("select * from {0} where {1}", tableName, string.Join(" and ", pkWhereStr.ToArray()));
        }
        #endregion

        #region 生成字段创建语句
        /// <summary>
        /// 生成字段创建语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columnName">字段名</param>
        /// <param name="columnType">字段类型</param>
        /// <returns></returns>
        public static string CreateColumnSql(string tableName, string columnName, string columnType)
        {
            return string.Format(@"if not exists
(select * from syscolumns where id=object_id('{0}') and name='{1}') begin  
alter table {0} ADD {1} {2}
end 
else
alter table {0} alter column {1} {2}", tableName, columnName, columnType);
        }
        #endregion
    }
}
