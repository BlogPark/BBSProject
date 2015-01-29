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
    public class NoticeNewsDal
    {
        private readonly string sqlconnectstr = @"Data Source=localhost;Initial Catalog=BBSProData;User ID=sa;password=!@#123qwe;pooling=false;";//数据库连接字符串
        /// <summary>
        /// 系统公告列表
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public List<SysNoticeVO> GetNotice(int pageindex, int pagesize)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"SELECT  NoticeID ,
        NoticeTitle ,
        NoticeContent ,
        PublishTime ,
        ExpiredTime ,
        IsUsed ,
        PublishUserName ,
        PublishState ,
        PublishStateName ,
        UsedName
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY NoticeID DESC ) AS rowid ,
                    NoticeID ,
                    NoticeTitle ,
                    NoticeContent ,
                    PublishTime ,
                    ExpiredTime ,
                    IsUsed ,
                    PublishUserName ,
                    PublishState ,
                    CASE PublishState
                      WHEN 100 THEN '待发布'
                      WHEN 200 THEN '已发布'
                      WHEN 300 THEN '已过期'
                      WHEN 400 THEN '已删除'
                    END AS PublishStateName ,
                    CASE IsUsed
                      WHEN 1 THEN '有效'
                      WHEN 0 THEN '无效'
                    END AS UsedName
          FROM      BBSProData.dbo.bbs_SysNotice WITH ( NOLOCK )
        ) AS tablea
WHERE   rowid > ( @pageindex - 1 ) * @pagesize
        AND rowid <= @pageindex * @pagesize";
                return conn.Query<SysNoticeVO>(sqltxt, new { pageindex = pageindex, pagesize = pagesize }).ToList<SysNoticeVO>();
            }
        }
        /// <summary>
        /// 插入系统公告
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertNotices(SysNotice model)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"INSERT  INTO BBSProData.dbo.bbs_SysNotice
        ( NoticeTitle ,
          NoticeContent ,
          PublishTime ,
          ExpiredTime ,
          IsUsed ,
          PublishUserName ,
          PublishState
        )
VALUES  ( @NoticeTitle ,
          @NoticeContent ,
          GETDATE() ,
          @ExpiredTime ,
          1 ,
          @PublishUserName ,
          @PublishState
        )";
                return conn.Execute(sqltxt, model);
            }
        }
        /// <summary>
        /// 撤销单个公告
        /// </summary>
        /// <param name="noticesid"></param>
        /// <returns></returns>
        public int deleteNotice(int noticesid)
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"UPDATE  BBSProData.dbo.bbs_SysNotice
SET     PublishState = 400 ,
        IsUsed = 0
WHERE   NoticeID = @NoticeID";
                return conn.Execute(sqltxt, new { NoticeID = noticesid });
            }
        }
    }
}
