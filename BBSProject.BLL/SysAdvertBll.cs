using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BBSProject.DataModel.Model;
using BBSProject.SQLCommDAL;

namespace BBSProject.BLL
{
    public  class SysAdvertBll
    {
        private SysAdvertDAL dal = new SysAdvertDAL();
         /// <summary>
        /// 得到所有的广告位置
        /// </summary>
        /// <returns></returns>
        public List<AdvertPositionVO> GetAlladvertinfo()
        {
            return dal.GetAlladvertinfo();
        }
        /// <summary>
        /// 插入广告位置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertAdvertinfo(AdvertPosition model)
        {
            return dal.InsertAdvertinfo(model);
        }
        /// <summary>
        /// 修改广告位置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateAdvertinfo(AdvertPosition model)
        {
            return dal.UpdateAdvertinfo(model);
        }
        /// <summary>
        /// 禁用/启用广告位置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int DisableAdvertinfo(int id)
        {
            return dal.DisableAdvertinfo(id);
        }
    }
}
