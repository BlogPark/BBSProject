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
        /// <summary>
        /// 插入新的系统用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertSysUser(SysUsers model)
        {
            return dal.InsertSysUser(model);
        }
        /// <summary>
        /// 修改系统用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSysUser(SysUsers model)
        {
            return dal.UpdateSysUser(model);
        }
        /// <summary>
        /// 返回所有的用户分组
        /// </summary>
        /// <returns></returns>
        public List<SysUserGroupVO> GetSysUserGroup(int pageindex, int pagesize)
        {
            return dal.GetSysUserGroup(pageindex, pagesize);
        }
        /// <summary>
        /// 禁用/启用用户组
        /// </summary>
        /// <param name="groupid">组ID</param>
        /// <param name="used">目标状态</param>
        /// <returns></returns>
        public int DisableSysUsergroup(int groupid, int used)
        {
            return dal.DisableSysUsergroup(groupid,used);
        }
        /// <summary>
        /// 添加用户组
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertSysUserGroup(SysUserGroups model)
        {
            return dal.InsertSysUserGroup(model);
        }
        /// <summary>
        /// 校验用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public SysUsers CheckPassport(string username, string password)
        {
            return dal.CheckPassport(username,password);
        }
    }
}
