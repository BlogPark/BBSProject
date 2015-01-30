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
        /// <summary>
        /// 得到全部的配置信息
        /// </summary>
        /// <returns></returns>
        public List<SysConfigurationVO> GetAllConfiguration(int pageindex, int pagesize)
        {
            return dal.GetAllConfiguration(pageindex,pagesize);
        }
        /// <summary>
        /// 得到父级节点
        /// </summary>
        /// <returns></returns>
        public List<SysConfiguration> getfatherconfig()
        {
            SysConfiguration cmodel = new SysConfiguration();
            cmodel.ID = -1;
            cmodel.OperateName = "<无>";
            List<SysConfiguration> conlist = dal.getfatherconfig();
            conlist.Insert(0, cmodel);
            return conlist;
        }
        /// <summary>
        /// 添加配置项
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertConfiguration(SysConfiguration model)
        {
            return dal.InsertConfiguration(model);
        }
        /// <summary>
        /// 修改配置项
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateConfiguration(SysConfiguration model)
        {
            return dal.UpdateConfiguration(model);
        }
        /// <summary>
        /// 禁用/启用配置项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DisableConfiguration(int id)
        {
            return dal.DisableConfiguration(id);
        }
    }
}
