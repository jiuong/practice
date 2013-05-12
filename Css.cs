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
            string beFirstAttr = @"(\s*){(\s*)";
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
    }
}
