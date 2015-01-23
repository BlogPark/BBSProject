using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using BBSProject.DataModel.Model;

namespace BBSProject.SQLCommDAL
{
    public class SystemUserDal
    {
        private readonly string sqlconnectstr = @"Data Source=localhost;Initial Catalog=BBSProData;User ID=sa;password=!@#123qwe;pooling=false;";//数据库连接字符串
        /// <summary>
        /// 根据用户加载页面权限列表
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="ModularFatherID"></param>
        /// <returns></returns>
        public List<SysUserModular> GetAuthorityByUser(int userid, int ModularFatherID)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"SELECT  suem.ID ,
        suem.ModularID ,
        suem.ModularName ,
        suem.UsergroupID ,
        suem.IsUsed ,
        suem.ModularFatherID
FROM    BBSProData.dbo.bbs_SysUserModular suem WITH ( NOLOCK )
        INNER JOIN BBSProData.dbo.bbs_SysUsers sue WITH ( NOLOCK ) ON sue.SysUserGroupID = suem.UsergroupID
                                                              AND suem.IsUsed = 1
                                                              AND suem.ModularFatherID = @modularfatherid
                                                              AND sue.ID = @id";
                List<SysUserModular> result = conn.Query<SysUserModular>(sqltxt, new { modularfatherid = ModularFatherID, id = userid }).ToList<SysUserModular>();
                return result;
            }
        }

        /// <summary>
        /// 查询所有系统用户的列表
        /// </summary>
        /// <returns></returns>
        public List<SysUsersVO> GetAllSysUsers()
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"SELECT  sue.ID ,
        sue.SysUserName ,
        sue.SysUserPassword ,
        sue.SysUserGroupID,
        sug.SysUserGroupName,
        sue.SysUserTrueName,
        sue.SysUserPhone,
        sue.Status,
        Case sue.Status WHEN 1 THEN '启用' WHEN 2 THEN '禁用' WHEN 3 THEN '注销' ELSE '未知'END AS StatusName
FROM    BBSProData.dbo.bbs_SysUsers sue WITH(NOLOCK)
INNER JOIN BBSProData.dbo.bbs_SysUserGroups sug WITH(NOLOCK) ON sug.SysUserGroupID = sue.SysUserGroupID";
                List<SysUsersVO> result = conn.Query<SysUsersVO>(sqltxt).ToList<SysUsersVO>();
                return result;
            }
        }
        /// <summary>
        /// 返回所有的在用的用户分组
        /// </summary>
        /// <returns></returns>
        public List<SysUserGroups> GetAllSysUserGroup()
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"SELECT  SysUserGroupID ,
        SysUserGroupName
FROM    BBSProData.dbo.bbs_SysUserGroups
WHERE   IsUsed = 1";
                return conn.Query<SysUserGroups>(sqltxt).ToList<SysUserGroups>();
            }
        }
        /// <summary>
        /// 禁用账户
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int DisableSysUser(int userid)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"  UPDATE BBSProData.dbo.bbs_SysUsers SET [Status]=CASE [Status] WHEN 3 THEN 1 WHEN 1 THEN 3 END WHERE ID=@id";
                int rowcount = conn.Execute(sqltxt, new { id = userid });
                return rowcount;
            }
        }
        /// <summary>
        /// 插入新的系统用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertSysUser(SysUsers model)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"INSERT INTO BBSProData.dbo.bbs_SysUsers
        ( SysUserName ,
          SysUserPassword ,
          SysUserGroupID ,
          SysUserTrueName ,
          SysUserPhone ,
          [Status]
        )
VALUES  ( @SysUserName,
          @SysUserPassword,
          @SysUserGroupID,
          @SysUserTrueName,
          @SysUserPhone,
          1
        )";
                return conn.Execute(sqltxt, model);
            }
        }
        /// <summary>
        /// 修改系统用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSysUser(SysUsers model)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"UPDATE  [BBSProData].[dbo].[bbs_SysUsers]
SET     SysUserName = @SysUserName ,
        SysUserTrueName = @SysUserTrueName ,
        SysUserPhone = @SysUserPhone ,
        SysUserGroupID = @SysUserGroupID
WHERE   ID = @ID";
                return conn.Execute(sqltxt, model);
            }
        }
    }
}
