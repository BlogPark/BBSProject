using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class ExtensClass
    {
        /// <summary>
        /// 将字符串转换为数字
        /// </summary>
        /// <param name="str">传入字符串</param>
        /// <param name="kt">若转换失败则返回此值</param>
        /// <returns></returns>
        public static int ToInt(this string str,int kt)
        {
            int k = kt;
            if (!int.TryParse(str, out k))
            {
                return 0;
            }
            else
            {
                return k;
            }
        }
        /// <summary>
        /// 将字符串转换为decimal
        /// </summary>
        /// <param name="str">传入字符串</param>
        /// <param name="de">若转换失败则返回此值</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string str, decimal de)
        {
            if (!decimal.TryParse(str, out de))
            {
                return de;
            }
            else
            {
                return de;
            }
        }
        /// <summary>
        /// 返回短日期字符串
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToSortDatestr(this DateTime date)
        {
            return date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString();
        }
        /// <summary>
        /// 将字符串转换为日期类型
        /// </summary>
        /// <param name="str"></param>
        /// <param name="date">若转换失败则返回此值</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str, DateTime date)
        {
            if (!DateTime.TryParse(str, out date))
            {
                return date;
            }
            else
                return date;
        }
    }
}
