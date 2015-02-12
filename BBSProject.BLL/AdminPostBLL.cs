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
    }
}
