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
FROM    BBSProData.dbo.bbs_Posts WITH ( NOLOCK )
SELECT  A.PostID ,
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
        LastUpdateUserID
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
            if (!string.IsNullOrWhiteSpace(model.PostTitle))
            {
                sqltxt += @" AND PostTitle LIKE '%" + model.PostTitle + @"%'";
            }
            if (!string.IsNullOrWhiteSpace(model.SortOrderName))
            {
                sqltxt += @" Order by " + model.SortOrderName;
            }
            else { sqltxt += @"Order By A.PostID  "; }
            if (!string.IsNullOrWhiteSpace(model.SortOrderOption))
            {
                sqltxt += model.SortOrderOption;
            }
            else
            {
                sqltxt += "DESC ";
            }

            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                return conn.Query<PostsVO>(sqltxt, new { pageindex = model.PageIndex, pagesize = model.PageSize, strpublishtime = model.StrPublishTime, endpublishtime = model.EndPublishTime }).ToList<PostsVO>();
            }
        }
    }
}
