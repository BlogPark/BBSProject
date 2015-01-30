using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using BBSProject.DataModel.Model;
using System.Data;
using System.Data.SqlClient;

namespace BBSProject.SQLCommDAL
{
    /// <summary>
    /// 后台基础数据的维护操作
    /// </summary>
    public class BaseDataDAL
    {
        private readonly string sqlconnectstr = @"Data Source=localhost;Initial Catalog=BBSProData;User ID=sa;password=!@#123qwe;pooling=false;";//数据库连接字符串
        /// <summary>
        /// 读取有权限的菜单
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<SysModulars> GetModularByUser(int userID)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"SELECT  sm.ID ,
        sm.ModularName ,
        sm.ModularValue ,
        sm.[Action] ,
        sm.FatherID
FROM    BBSProData.dbo.bbs_SysModulars sm WITH ( NOLOCK )
        INNER JOIN BBSProData.dbo.bbs_SysUserModular um WITH ( NOLOCK ) ON sm.ID = um.ModularID
                                                              AND um.IsUsed = 1
                                                              AND sm.ModularValue = 0
        INNER JOIN BBSProData.dbo.bbs_SysUsers su WITH ( NOLOCK ) ON su.SysUserGroupID = um.UsergroupID
                                                              AND su.id = @id";
                List<SysModulars> result = conn.Query<SysModulars>(sqltxt, new { id = userID }).ToList<SysModulars>();
                return result;
            }
        }
        /// <summary>
        /// 得到全部的配置信息
        /// </summary>
        /// <returns></returns>
        public List<SysConfigurationVO> GetAllConfiguration(int pageindex, int pagesize)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"SELECT  ID ,
        OperateName ,
        OperateValue ,
        FatherID ,
        IsUsed ,
        OperateRemark ,
        CreateTime ,
        CreateUser ,
        UsedName
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY ID ASC ) AS rowid ,
                    ID ,
                    OperateName ,
                    OperateValue ,
                    FatherID ,
                    IsUsed ,
                    OperateRemark ,
                    CreateTime ,
                    CreateUser ,
                    CASE IsUsed
                      WHEN 1 THEN '启用'
                      WHEN 0 THEN '无效'
                    END UsedName
          FROM      BBSProData.dbo.bbs_SysConfiguration config WITH ( NOLOCK )
        ) AS A
WHERE   A.rowid > ( @pageindex - 1 ) * @pagesize
        AND A.rowid <= @pageindex * @pagesize";
                return conn.Query<SysConfigurationVO>(sqltxt, new { pageindex = pageindex, pagesize = pagesize }).ToList<SysConfigurationVO>();
            }
        }
        /// <summary>
        /// 得到父级节点
        /// </summary>
        /// <returns></returns>
        public List<SysConfiguration> getfatherconfig()
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"SELECT  ID ,
        OperateName ,
        OperateValue ,
        FatherID ,
        IsUsed ,
        OperateRemark ,
        CreateTime ,
        CreateUser
FROM    BBSProData.dbo.bbs_SysConfiguration config WITH ( NOLOCK )
WHERE   FatherID = 0
        AND IsUsed = 1";
                return conn.Query<SysConfiguration>(sqltxt).ToList<SysConfiguration>();
            }
        }
        /// <summary>
        /// 添加配置项
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertConfiguration(SysConfiguration model)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"INSERT  INTO BBSProData.dbo.bbs_SysConfiguration
        ( OperateName ,
          OperateValue ,
          FatherID ,
          IsUsed ,
          OperateRemark ,
          CreateTime ,
          CreateUser
        )
VALUES  ( @OperateName ,
          @OperateValue ,
          @FatherID ,
          1 ,
          @OperateRemark ,
          GETDATE() ,
          @CreateUser
        )";
                return conn.Execute(sqltxt, model);
            }
        }
        /// <summary>
        /// 修改配置项
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateConfiguration(SysConfiguration model)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"UPDATE  BBSProData.dbo.bbs_SysConfiguration
SET     OperateName = @OperateName ,
        OperateValue = @OperateValue ,
        OperateRemark = @OperateRemark ,
        FatherID = @FatherID
WHERE   ID = @ID";
                return conn.Execute(sqltxt, model);
            }
        }
        /// <summary>
        /// 禁用/启用配置项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DisableConfiguration(int id)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"UPDATE  BBSProData.dbo.bbs_SysConfiguration
SET     IsUsed = CASE IsUsed
                   WHEN 1 THEN 0
                   WHEN 0 THEN 1
                 END
WHERE   ID = @id";
                return conn.Execute(sqltxt, new { id = id });
            }
        }
    }
}
