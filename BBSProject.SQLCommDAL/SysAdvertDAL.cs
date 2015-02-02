using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using BBSProject.DataModel.Model;
using System.Data.SqlClient;


namespace BBSProject.SQLCommDAL
{
    public class SysAdvertDAL
    {
        private readonly string sqlconnectstr = @"Data Source=localhost;Initial Catalog=BBSProData;User ID=sa;password=!@#123qwe;pooling=false;";//数据库连接字符串
        /// <summary>
        /// 得到所有的广告位置
        /// </summary>
        /// <returns></returns>
        public List<AdvertPositionVO> GetAlladvertinfo()
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"SELECT  ID ,
        PositionTitle ,
        IsUsed ,
        [Description],
        CASE IsUsed WHEN 0 THEN '停用中' WHEN 1 THEN '使用中' END as UsedName
FROM    BBSProData.dbo.bbs_AdvertPosition WITH(NOLOCK)";
                return conn.Query<AdvertPositionVO>(sqltxt).ToList<AdvertPositionVO>();
            }
        }
        /// <summary>
        /// 插入广告位置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertAdvertinfo(AdvertPosition model)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"INSERT INTO BBSProData.dbo.bbs_AdvertPosition
        ( PositionTitle ,
          IsUsed ,
          [Description]
        )
VALUES  ( @PositionTitle,
          1, 
          @Description
        )";
                return conn.Execute(sqltxt, model);
            }
        }
        /// <summary>
        /// 修改广告位置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateAdvertinfo(AdvertPosition model)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"UPDATE  BBSProData.dbo.bbs_AdvertPosition
SET     [Description] = @Description ,
        PositionTitle = @PositionTitle
WHERE   ID = @id";
                return conn.Execute(sqltxt, model);
            }
        }
        /// <summary>
        /// 禁用/启用广告位置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int DisableAdvertinfo(int id)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"UPDATE  BBSProData.dbo.bbs_AdvertPosition
SET     IsUsed = CASE IsUsed
                   WHEN 0 THEN 1
                   WHEN 1 THEN 0
                 END
WHERE   ID = @id";
                return conn.Execute(sqltxt, new { id = id });
            }
        }
    }
}
