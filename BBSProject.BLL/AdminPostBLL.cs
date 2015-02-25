using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBSProject.DataModel.Model;
using BBSProject.SQLCommDAL;

namespace BBSProject.BLL
{
    public class AdminPostBLL
    {
        private AdminPostsDal dal = new AdminPostsDal();
        /// <summary>
        /// 查询帖子列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<PostsVO> GetPostlist(PostsVO model)
        {
            return dal.GetPostlist(model);
        }

        /// <summary>
        /// 插入消息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertMemberNews(MemberNewsVO model)
        {
            return dal.InsertMemberNews(model);
        }
        /// <summary>
        /// 删除帖子
        /// </summary>
        /// <param name="postid"></param>
        /// <returns></returns>
        public int DeletePosts(int postid)
        {
            return dal.DeletePosts(postid);
        }
    }
}
