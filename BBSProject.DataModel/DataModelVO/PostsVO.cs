using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BBSProject.DataModel.Model
{
    public class PostsVO : Posts
    {
        /// <summary>
        /// 页索引
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 页容量
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 状态名称
        /// </summary>
        public string StateName { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortOrderName { get; set; }
        /// <summary>
        /// 排序方向
        /// </summary>
        public string SortOrderOption { get; set; }
        /// <summary>
        /// 开始发布时间
        /// </summary>
        public DateTime StrPublishTime { get; set; }
        /// <summary>
        /// 结束发布时间
        /// </summary>
        public DateTime EndPublishTime { get; set; }
        /// <summary>
        /// 状态名称
        /// </summary>
        public string PublishStatename { get; set; }
    }
}
