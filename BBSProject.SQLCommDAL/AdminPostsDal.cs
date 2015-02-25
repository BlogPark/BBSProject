using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using BBSProject.DataModel.Model;
using BBSProject.Comm;
using System.Data;
using System.Data.SqlClient;

namespace BBSProject.SQLCommDAL
{
    /// <summary>
    /// 管理台 帖子管理
    /// </summary>
    public class AdminPostsDal
    {
        private readonly string sqlconnectstr = @"Data Source=localhost;Initial Catalog=BBSProData;User ID=sa;password=!@#123qwe;pooling=false;";//数据库连接字符串
        /// <summary>
        /// 查询帖子列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<PostsVO> GetPostlist(PostsVO model)
        {
            string sqltxt = @"SELECT  IDENTITY ( INT,1,1 ) AS rowid ,
        postid * 1 AS postid
INTO    #t
FROM    BBSProData.dbo.bbs_Posts WITH ( NOLOCK ) ";
            if (!string.IsNullOrWhiteSpace(model.PostTitle))
            {
                sqltxt += @" WHERE PostTitle LIKE '%" + model.PostTitle + @"%'";
            }
            sqltxt += @"SELECT  A.PostID ,
        PostTitle ,
        PostContent ,
        B.MemberID ,
        PublishTime ,
        PublishSouce ,
        CheckNumber ,
        ReplyNumber ,
        CollectionNumber ,
        SupportNumber ,
        OppositionNumber ,
        ThemeID ,
        PostKeyWord ,
        PublishState ,
        LastUpdateTime ,
        LastUpdateUserName ,
        LastUpdateUserID,
                CASE PublishState
                  WHEN 100 THEN '草稿'
                  WHEN 200 THEN '已发布'
                  WHEN 300 THEN '已删除'
                  WHEN 400 THEN '已屏蔽'
                  ELSE '未知状态'
                END AS PublishStatename
FROM    #t A
        INNER JOIN BBSProData.dbo.bbs_Posts B WITH ( NOLOCK ) ON A.postid = b.PostID
                                                              AND a.rowid > ( @pageindex
                                                              - 1 )
                                                              * @pagesize
                                                              AND a.rowid <= @pageindex
                                                              * @pagesize
                                                              AND B.PublishTime>@strpublishtime
                                                              AND b.PublishTime<=@endpublishtime
        LEFT JOIN BBSProData.dbo.bbs_MemberInfo C WITH ( NOLOCK ) ON C.MemberID = B.MemberID";

            if (!string.IsNullOrWhiteSpace(model.SortOrderName))
            {
                sqltxt += @" Order by " + model.SortOrderName;
            }
            else { sqltxt += @" Order By A.PostID  "; }
            if (!string.IsNullOrWhiteSpace(model.SortOrderOption))
            {
                sqltxt += " " + model.SortOrderOption;
            }
            else
            {
                sqltxt += " DESC ";
            }

            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                return conn.Query<PostsVO>(sqltxt, new { pageindex = model.PageIndex, pagesize = model.PageSize, strpublishtime = model.StrPublishTime, endpublishtime = model.EndPublishTime }).ToList<PostsVO>();
            }
        }

        /// <summary>
        /// 插入消息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertMemberNews(MemberNewsVO model)
        {
            string sqltxt = @"INSERT  INTO BBSProData.dbo.bbs_MemberNews
        ( NewsTitle ,
          NewsPublisher ,
          NewsReceiver ,
          NewsReaded ,
          NewsStatus ,
          NewsPublishTime,
          NewsContent  
        )
VALUES  ( @NewsTitle ,
          @NewsPublisher ,
          @NewsReceiver ,
          0 ,
          200 ,
          GETDATE(),
          @NewsContent
        )
        SELECT @@IDENTITY as ID";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                dynamic identity = conn.Query(sqltxt, model).Single();
                return (int)identity.ID;
            }
        }
        /// <summary>
        /// 删除帖子
        /// </summary>
        /// <param name="postid"></param>
        /// <returns></returns>
        public int DeletePosts(int postid)
        {
            string sqltxt = @"UPDATE  BBSProData.dbo.bbs_Posts
SET     PublishState = 300
WHERE   PostID = @id";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                return conn.Execute(sqltxt, new { id = postid });
            }
        }
    }
}
