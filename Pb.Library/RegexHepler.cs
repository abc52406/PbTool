using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Pb.Library
{
    public class RegexHepler
    {
        private static string exampletag = @"{(.*)}";//表达式：以“{”开始，中间字符不限，最后以“}”结尾

        /// <summary>
        /// 逐行读取每一行字符串中最长的匹配项,匹配以“{”开始，中间字符不限，最后以“}”结尾的字符串
        /// </summary>
        /// <param name="Content">内容</param>
        /// <returns></returns>
        public static List<string> DoRegex(string Content)
        {
            return DoRegex(Content, exampletag, 1, 1);
        }

        /// <summary>
        /// 逐行读取每一行字符串中最长的匹配项
        /// </summary>
        /// <param name="Content">内容</param>
        /// <param name="tag">匹配标签</param>
        /// <param name="beginlength">匹配标签开始长度</param>
        /// <param name="finishlength">匹配标签结束长度</param>
        /// <returns></returns>
        public static List<string> DoRegex(string Content, string tag, int beginlength, int finishlength)
        {
            MatchCollection macths = Regex.Matches(Content, tag);
            List<string> res = new List<string>();
            foreach (Match macth in macths)
            {
                res.Add(macth.ToString().Substring(beginlength, macth.ToString().Length - finishlength - beginlength));
            }
            return res;
        }
    }
}
