using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBSProject.DataModel.Model;
using BBSProject.SQLCommDAL;
using System.Data;

namespace BBSProject.BLL
{
    public  class NoticeNewsBLL
    {
        private NoticeNewsDal dal = new NoticeNewsDal();
        public List<SysNoticeVO> GetNoticelist(int pageindex, int pagesize)
        {
            return dal.GetNotice(pageindex,pagesize);
        }

        /// <summary>
        /// 插入系统公告
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertNotices(SysNotice model)
        {
            return dal.InsertNotices(model);
        }
        /// <summary>
        /// 撤销单个公告
        /// </summary>
        /// <param name="noticesid"></param>
        /// <returns></returns>
        public int deleteNotice(int noticesid)
        {
            DataTable dt = new DataTable();
            string str = "<table>";
            foreach (DataRow item in dt.Rows)
            {
                string s = "<tr><td>";
                s += item[0].ToString();
                s += "</td></tr>";
                str += s;
                
            }

            str += "</table>";




            return dal.deleteNotice(noticesid);
        }
    }
}
