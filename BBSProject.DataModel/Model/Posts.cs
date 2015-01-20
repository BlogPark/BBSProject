using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class Posts
    {
        /// <summary>
        /// PostID
        /// </summary>
        [DataMember]
        public int PostID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string PostTitle { get; set; }
        /// <summary>
        /// 帖子内容
        /// </summary>
        [DataMember]
        public string PostContent { get; set; }
        /// <summary>
        /// 发布会员ID
        /// </summary>
        [DataMember]
        public int MemberID { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        [DataMember]
        public DateTime PublishTime { get; set; }
        /// <summary>
        /// 发表来源
        /// </summary>
        [DataMember]
        public string PublishSouce { get; set; }
        /// <summary>
        /// 查看数
        /// </summary>
        [DataMember]
        public int CheckNumber { get; set; }
        /// <summary>
        /// 回复数
        /// </summary>
        [DataMember]
        public int ReplyNumber { get; set; }
        /// <summary>
        /// 收藏数
        /// </summary>
        [DataMember]
        public int CollectionNumber { get; set; }
        /// <summary>
        /// 支持数
        /// </summary>
        [DataMember]
        public int SupportNumber { get; set; }
        /// <summary>
        /// 反对数
        /// </summary>
        [DataMember]
        public int OppositionNumber { get; set; }
        /// <summary>
        /// 主题ID
        /// </summary>
        [DataMember]
        public int ThemeID { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        [DataMember]
        public string PostKeyWord { get; set; }
        /// <summary>
        /// 发布状态  100 草稿  200 已发布 300 已删除 400 已屏蔽
        /// </summary>
        [DataMember]
        public int PublishState { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        [DataMember]
        public DateTime LastUpdateTime { get; set; }
        /// <summary>
        /// 最后更新人
        /// </summary>
        [DataMember]
        public string LastUpdateUserName { get; set; }
        /// <summary>
        /// 最后更新人ID
        /// </summary>
        [DataMember]
        public int LastUpdateUserID { get; set; }
		 
    }
}
