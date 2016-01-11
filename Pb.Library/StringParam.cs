using System.Collections.Specialized;
using System.Web;

namespace Pb.Library
{
    /// <summary>
    /// StringParam 用于处理Style类型字符串（如UserName:Niqin;UserAge:15;）
    /// 和Query类型字符串（如UserName=Niqin&UserAge=15）的字符串参数集
    /// </summary>
    public class StringParam : NameValueCollection
    {

        private string divChar = ";";
        private string gapChar = ":";

        #region 属性
        public string DivChar
        {
            get
            {
                return this.divChar;
            }
            set
            {
                this.divChar = value;
            }
        }

        public string GapChar
        {
            get
            {
                return this.gapChar;
            }
            set
            {
                this.gapChar = value;
            }
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// StringParam的默认构造器
        /// </summary>
        public StringParam()
        {
        }

        /// <summary>
        /// StringParam的构造器
        /// </summary>
        /// <param name="stringParam">Style的定义字符串</param>
        public StringParam(string stringParam)
        {
            Init(stringParam);
        }

        /// <summary>
        /// 根据stringParam、divChar、gapChar构造StringParam
        /// </summary>
        /// <param name="stringParam"></param>
        /// <param name="divChar"></param>
        /// <param name="gapChar"></param>
        public StringParam(string stringParam, string divChar, string gapChar)
        {
            this.divChar = divChar;
            this.gapChar = gapChar;
            this.Init(stringParam);
        }

        #endregion

        #region 共有方法
        /// <summary>
        /// 以数组方式返回StringParam
        /// </summary>
        /// <param name="itemKey"></param>
        /// <returns></returns>
        public string[] GetArray(string itemKey)
        {
            try
            {
                return this.Get(itemKey).Split(',');
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 格式化stringParam
        /// </summary>
        /// <param name="stringParam"></param>
        private void Init(string stringParam)
        {
            int i;
            string[] paramItem;
            paramItem = stringParam.Split(this.divChar.ToCharArray());

            for (i = 0; i < paramItem.Length; i++)
            {
                if (paramItem[i].Trim() != "")
                {
                    string[] ary = paramItem[i].Split(this.gapChar.ToCharArray());
                    string key = ary[0].Trim();
                    string val = HttpUtility.UrlDecode(ary[1].Trim());
                    this.Add(key, val);
                }
            }

        }

        /// <summary>
        /// 重写ToString方法
        /// </summary>
        /// <returns>返回与Style类似的字符串</returns>
        public override string ToString()
        {
            string strRtn = "";
            if (this.Count <= 0) return "";
            for (int i = 0; i < this.Count; i++)
            {
                strRtn += this.Keys[i] + this.gapChar + HttpUtility.UrlEncode(this.Get(i)) + this.divChar;
            }
            return strRtn.Substring(0, strRtn.Length - 1);
        }
        #endregion
    }
}
