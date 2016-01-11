using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pb.Library
{
    /// <summary>
    /// 枚举帮助类
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// 将枚举转换为DataTable
        /// </summary>
        /// <param name="emType"></param>
        /// <returns></returns>
        public static DataTable GetEnumTable(Type emType)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EnumText");
            dt.Columns.Add("EnumValue");
            foreach (var item in emType.GetFields())
            {
                if (item.FieldType.IsEnum)
                {
                    object[] arr = item.GetCustomAttributes(typeof(DescriptionAttribute), true);
                    DataRow row = dt.NewRow();
                    row["EnumText"] = arr.Length > 0 ? ((DescriptionAttribute)arr[0]).Description : item.Name;
                    row["EnumValue"] = item.Name;

                    dt.Rows.Add(row);
                }
            }

            return dt;
        }
        
        /// <summary>
        /// 将枚举转换为Dictionary
        /// </summary>
        /// <param name="emType"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetEnumDictionary(Type emType)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (var item in emType.GetFields())
            {
                if (item.FieldType.IsEnum)
                {
                    object[] arr = item.GetCustomAttributes(typeof(DescriptionAttribute), true);
                    dic.Add(item.Name, arr.Length > 0 ? ((DescriptionAttribute)arr[0]).Description : item.Name);
                }
            }

            return dic;
        }
    }
}
