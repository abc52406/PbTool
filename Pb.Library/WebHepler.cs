using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pb.Library
{
    public class WebHepler
    {
        private static Dictionary<string, string> replaceDic = new Dictionary<string, string>() 
        {
            {"&ldquo;","“"},
            {"&rdquo;","”"},
            {"&mdash","—"},
            {"&hellip","…"},
            {"&middot;","·"},
            {"&lsquo;","‘"},
            {"&rsquo;","’"},
            {"&nbsp;"," "},
            {"&lt;","<"},
            {"&gt;",">"},
            {"&amp;","&"},
            {"&quot;","\""},
            {"&copy;","?"},
            {"&reg;","?"},
            {"&times;","×"},
            {"&divide;","÷"},
        };

        /// <summary>
        /// 将Html命名实体转换为字符
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReplaceHtml(string value)
        {
            foreach (var di in replaceDic)
            {
                value = value.Replace(di.Key, di.Value);
            }
            return value;
        }

        /// <summary>
        /// 将字符转换为Html命名实体
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string UnReplaceHtml(string value)
        {
            foreach (var di in replaceDic)
            {
                value = value.Replace(di.Value, di.Key);
            }
            return value;
        }
    }
}
