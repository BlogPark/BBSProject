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
    public class SystemUserBLL
    {
        private SystemUserDal dal = new SystemUserDal();
        /// <summary>
        /// 查询用户权限
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="modularfatherid"></param>
        /// <returns></returns>
        public List<SysUserModular> GetAuthorityByUser(int userid,int modularfatherid)
        {
            return dal.GetAuthorityByUser(userid, modularfatherid);
        }
        /// <summary>
        /// 查询所有的系统用户
        /// </summary>
        /// <returns></returns>
        public List<SysUsersVO> GetAllSysUsers()
        {
            return dal.GetAllSysUsers();
        }
        /// <summary>
        /// 得到所有的启用的用户分组
        /// </summary>
        /// <returns></returns>
        public List<SysUserGroups> GetAllSysUserGroup()
        {
            return dal.GetAllSysUserGroup();
        }
        /// <summary>
        /// 禁用账户登录
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int DisableSysUser(int userid)
        {
            return dal.DisableSysUser(userid);
        }
    }
}
