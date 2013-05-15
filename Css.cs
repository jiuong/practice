using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace formatCss
{
    class Css
    {
        #region
        /// <summary>
        /// 一属性一行
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SingleLine(string str)
        {
            string beSingle = @";\s*";
            string afSingle = ";\r\n\t";
            string single;
            single = Regex.Replace(str,beSingle,afSingle);
            return single;
        }
        #endregion

        #region
        /// <summary>
        /// 花括号}重起一行
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string AddLine(string str)
        {
            string beAddLine = @"(\s*)}";
            string afAddLine = "\r\n}";
            string AddLine;
            AddLine = Regex.Replace(str, beAddLine, afAddLine);
            return AddLine;
        }
        #endregion

        #region
        /// <summary>
        /// 花括号{重起一行且缩进
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstAttr(string str)
        {
            string beFirstAttr = @"\s*{\s*";
            string afFirstAttr = " {\r\n\t";
            string FirstAttr;
            FirstAttr = Regex.Replace(str, beFirstAttr,afFirstAttr);
            return FirstAttr;
        }
        #endregion

        #region
        /// <summary>
        /// 集合上面三个函数，以格式化缩进
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CheckIndent(string str)
        {
            string checkIndent;
            checkIndent = SingleLine(str);
            checkIndent = FirstAttr(checkIndent);
            checkIndent = AddLine(checkIndent);
            return checkIndent;
        }
        #endregion
        
                #region
        /// <summary>
        /// 将除了路径外的Css属性及值都转化为小写,看起来比较复杂。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToLower(string str)
        {
            string lower;
            string urlReg = @"\(\S+\)";
            string styleName = @"(\.|#)\w+ ?(\w ?)*{";
            string[] Url = getStrs(str, urlReg);
            string[] SN = getStrs(str, styleName);
            lower = Regex.Replace(str, urlReg, "@");
            lower = Regex.Replace(lower, styleName, "&");
            lower = lower.ToLower();
            Regex UrlReg = new Regex("@");
            Regex SNReg = new Regex("&");
            for (int i = 0; i < Url.Length; i++)
            {
                lower = UrlReg.Replace(lower, Url[i], 1);
            }
            for (int i = 0; i < SN.Length; i++)
            {
                lower = SNReg.Replace(lower, SN[i], 1);
            }
            return lower;
        }
        #endregion


        #region
        /// <summary>
        /// 返回匹配字符串数组
        /// </summary>
        /// <param name="input"></param>
        /// <param name="reg"></param>
        /// <returns></returns>
        static string[] getStrs(string input,string reg)
        {
            MatchCollection mc = Regex.Matches(input, reg);
            string[] strs;
            strs = new string[mc.Count];
            for (int i = 0; i < mc.Count; i++)
            {
                strs[i] = mc[i].Value.ToString();
            }
            return strs;
        }
        #endregion

    }
}
