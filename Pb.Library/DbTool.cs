using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SqlClient;

namespace Pb.Library
{
    public static class DbTool
    {
        #region 数据转换
        public static DataRow[] DataTableToDataRows(DataTable dt)
        {
            return dt.Select();
        }

        public static DataTable DataRowsToDataTable(DataRow[] drs)
        {
            if (drs.Length > 0)
            {
                DataTable dt = drs[0].Table.Clone();
                foreach (DataRow dr in drs)
                {
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            return new DataTable();
        }

        public static List<Dictionary<string, object>> DataTableToListDictionary(DataTable dt)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    dic.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                list.Add(dic);
            }
            return list;
        }

        public static List<Dictionary<string, object>> DataRowsToListDictionary(DataRow[] drs)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow dr in drs)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (DataColumn dc in dr.Table.Columns)
                {
                    dic.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                list.Add(dic);
            }
            return list;
        }
        #endregion

        #region 获取表结构
        /// <summary>
        /// 获取表结构
        /// </summary>
        /// <param name="conStr">连接字符串</param>
        /// <param name="tableName">表名</param>
        /// <param name="owner">表来源</param>
        /// <param name="type">数据类型</param>
        /// <returns></returns>
        //public static TableSchema GetTableSchema(string conStr, string tableName, string owner, PbDbType type)
        //{
        //    DatabaseSchema ds;
        //    if (type == PbDbType.Sql)
        //        ds = new DatabaseSchema(new SqlSchemaProvider(), conStr);
        //    else
        //        ds = new DatabaseSchema(new ADOXSchemaProvider(), conStr);

        //    return new TableSchema(ds, tableName, owner, DateTime.MinValue);
        //}
        #endregion

        #region 数据类型转换
        /// <summary>
        /// DbType转换为OleDbType
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static OleDbType DbTypeToOleDbType(DbType type)
        {
            #region 判断数据类型
            OleDbType stype;
            switch (type)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                    stype = OleDbType.VarChar;
                    break;
                case DbType.Binary:
                    stype = OleDbType.Binary;
                    break;
                case DbType.Boolean:
                    stype = OleDbType.Boolean;
                    break;
                case DbType.Byte:
                    stype = OleDbType.TinyInt;
                    break;
                case DbType.Currency:
                    stype = OleDbType.Currency;
                    break;
                case DbType.Date:
                    stype = OleDbType.Date;
                    break;
                case DbType.DateTime:
                    stype = OleDbType.DBTimeStamp;
                    break;
                case DbType.Time:
                    stype = OleDbType.DBTime;
                    break;
                case DbType.Decimal:
                    stype = OleDbType.Decimal;
                    break;
                case DbType.Double:
                    stype = OleDbType.Double;
                    break;
                case DbType.Single:
                    stype = OleDbType.Single;
                    break;
                case DbType.Guid:
                    stype = OleDbType.Guid;
                    break;
                case DbType.Int16:
                case DbType.UInt16:
                    stype = OleDbType.SmallInt;
                    break;
                case DbType.Int32:
                case DbType.UInt32:
                    stype = OleDbType.Integer;
                    break;
                case DbType.Int64:
                case DbType.UInt64:
                    stype = OleDbType.BigInt;
                    break;
                case DbType.String:
                case DbType.StringFixedLength:
                    stype = OleDbType.VarWChar;
                    break;
                default:
                    stype = OleDbType.BigInt;
                    break;
            }
            #endregion

            return stype;
        }

        /// <summary>
        /// DbType转换为SqlDbType
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static SqlDbType DbTypeToSqlDbType(DbType type)
        {
            #region 判断数据类型
            SqlDbType stype;
            switch (type)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                    stype = SqlDbType.VarChar;
                    break;
                case DbType.Binary:
                    stype = SqlDbType.Binary;
                    break;
                case DbType.Boolean:
                    stype = SqlDbType.Bit;
                    break;
                case DbType.Byte:
                    stype = SqlDbType.TinyInt;
                    break;
                case DbType.Currency:
                    stype = SqlDbType.Money;
                    break;
                case DbType.Date:
                case DbType.DateTime:
                case DbType.Time:
                    stype = SqlDbType.DateTime;
                    break;
                case DbType.Decimal:
                    stype = SqlDbType.Decimal;
                    break;
                case DbType.Double:
                case DbType.Single:
                    stype = SqlDbType.Float;
                    break;
                case DbType.Guid:
                    stype = SqlDbType.UniqueIdentifier;
                    break;
                case DbType.Int16:
                case DbType.UInt16:
                    stype = SqlDbType.SmallInt;
                    break;
                case DbType.Int32:
                case DbType.UInt32:
                    stype = SqlDbType.Int;
                    break;
                case DbType.Int64:
                case DbType.UInt64:
                    stype = SqlDbType.BigInt;
                    break;
                case DbType.String:
                case DbType.StringFixedLength:
                    stype = SqlDbType.NVarChar;
                    break;
                default:
                    stype = SqlDbType.BigInt;
                    break;
            }
            #endregion

            return stype;
        }
        #endregion

        #region 获取表的所有列，并且优先排主键
        /// <summary>
        /// 获取表的所有列，并且优先排主键
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static List<string> GetColumns(DataRow dr)
        {
            return GetColumns(dr.Table);
        }

        /// <summary>
        /// 获取表的所有列，并且优先排主键
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<string> GetColumns(DataTable dt)
        {
            var cls = dt.PrimaryKey.Select(c => c.ColumnName).ToList();
            foreach (DataColumn cl in dt.Columns)
            {
                if (!cls.Contains(cl.ColumnName))
                    cls.Add(cl.ColumnName);
            }
            return cls;
        }

        /// <summary>
        /// 获取表的所有列，并且优先排主键
        /// </summary>
        /// <param name="dt">表</param>
        /// <returns></returns>
        //public static List<string> GetColumns(TableSchema dt)
        //{
        //    var list = dt.PrimaryKeys.ToArray().Select(c => c.Name).ToList();
        //    list.AddRange(dt.NonPrimaryKeyColumns.ToArray().Select(c => c.Name));
        //    return list;
        //}

        /// <summary>
        /// 获取表的所有列，并且优先排主键
        /// </summary>
        /// <param name="ds">数据库</param>
        /// <param name="tableName">表名</param>
        /// <param name="owner">表来源</param>
        /// <returns></returns>
        //public static List<string> GetColumns(DatabaseSchema ds, string tableName, string owner)
        //{
        //    TableSchema dt = new TableSchema(ds, tableName, owner, DateTime.MinValue);
        //    return GetColumns(dt);
        //}

        /// <summary>
        /// 获取表的所有列，并且优先排主键
        /// </summary>
        /// <param name="conStr">连接字符串</param>
        /// <param name="tableName">表名</param>
        /// <param name="owner">表来源</param>
        /// <returns></returns>
        //public static List<string> GetColumns(string conStr, string tableName, string owner)
        //{
        //    return GetColumns(conStr, tableName, owner, PbDbType.Sql);
        //}

        /// <summary>
        /// 获取表的所有列，并且优先排主键
        /// </summary>
        /// <param name="conStr">连接字符串</param>
        /// <param name="tableName">表名</param>
        /// <param name="owner">表来源</param>
        /// <param name="type">数据类型</param>
        /// <returns></returns>
        //public static List<string> GetColumns(string conStr, string tableName, string owner, PbDbType type)
        //{
        //    DatabaseSchema ds;
        //    if (type == PbDbType.Sql)
        //        ds = new DatabaseSchema(new SqlSchemaProvider(), conStr);
        //    else
        //        ds = new DatabaseSchema(new ADOXSchemaProvider(), conStr);

        //    return GetColumns(ds, tableName, owner);
        //}
        #endregion

        #region 获取sql语句的参数值
        /// <summary>
        /// 获取sql语句的参数值
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        //public static List<DbParameter[]> GetParemeters(TableSchema dt)
        //{
        //    var list = new List<DbParameter[]>();
        //    var cls = DbTool.GetColumns(dt);
        //    var dtcls = dt.Columns;
        //    foreach (DataRow dr in dt.GetTableData().Rows)
        //    {
        //        var dp = new List<DbParameter>();
        //        foreach (string cl in cls)
        //        {
        //            dp.Add(new SqlParameter(cl, dr[cl]));
        //        }
        //        list.Add(dp.ToArray());
        //    }
        //    return list;
        //}

        /// <summary>
        /// 获取sql语句的参数值
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<DbParameter[]> GetParemeters(DataTable dt)
        {
            var list = new List<DbParameter[]>();
            var cls = DbTool.GetColumns(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var dp = new List<DbParameter>();
                foreach (string cl in cls)
                {
                    dp.Add(new SqlParameter(cl, dr[cl]));
                }
                list.Add(dp.ToArray());
            }
            return list;
        }
        #endregion

        #region 根据sqlserver内置属性获取字段类型
        /// <summary>
        /// 根据sqlserver内置属性获取字段类型
        /// </summary>
        /// <param name="xtype"></param>
        /// <param name="length"></param>
        /// <param name="xprec"></param>
        /// <param name="xscare"></param>
        /// <returns></returns>
        public static string GetColumnType(Byte xtype, Int16 length, Byte xprec, Byte xscare)
        {
            switch (xtype)
            {
                case 167:
                    if (length != -1)
                        return string.Format("varchar({0})", length);
                    else
                        return "varchar(max)";
                case 231:
                    if (length != -1)
                        return string.Format("nvarchar({0})", length / 2);
                    else
                        return "nvarchar(max)";
                case 61:
                    return "datetime";
                case 175:
                    return string.Format("char({0})", length);
                case 62:
                    return "float";
                case 99:
                    return "ntext";
                case 35:
                    return "text";
                case 106:
                    return string.Format("decimal({0},{1})", xprec, xscare);
                case 104:
                    return "bit";
                case 127:
                    return "bigint";
                case 173:
                    return string.Format("binary({0})", length);
            }
            return string.Empty;
        }
        #endregion
    }

    public enum PbDbType
    {
        Sql,
        ADOX
    }
}
