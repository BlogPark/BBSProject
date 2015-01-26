using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBSProject.DataModel.Model;
using BBSProject.SQLCommDAL;

namespace BBSProject.BLL
{
    public  class NoticeNewsBLL
    {
        private NoticeNewsDal dal = new NoticeNewsDal();
        public List<SysNoticeVO> GetNoticelist(int pageindex, int pagesize)
        {
            return dal.GetNotice(pageindex,pagesize);
        }
    }
}
