using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBSProject.DataModel.Model;
using BBSProject.SQLCommDAL;

namespace BBSProject.BLL
{
    /// <summary>
    /// 基础数据的业务逻辑层
    /// </summary>
    public class BaseDataBll
    {
        private BaseDataDAL dal = new BaseDataDAL();
        /// <summary>
        /// 根据用户名获取权限菜单
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<SysModulars> GetModularsByUser(int userid)
        {
            return dal.GetModularByUser(userid);
        }
    }
}
