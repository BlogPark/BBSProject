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
    }
}
