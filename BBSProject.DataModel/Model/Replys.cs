using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class Replys
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 帖子ID
        /// </summary>
        [DataMember]
        public int PostID { get; set; }
        /// <summary>
        /// 回复人ID
        /// </summary>
        [DataMember]
        public int ReplyUserID { get; set; }
        /// <summary>
        /// 回复人名称
        /// </summary>
        [DataMember]
        public string ReplyName { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        [DataMember]
        public string ReplyContent { get; set; }
        /// <summary>
        /// 状态  100 回复 200 管理员屏蔽 300 贴主删除
        /// </summary>
        [DataMember]
        public int ReplyState { get; set; }
        /// <summary>
        /// 回复时间
        /// </summary>
        [DataMember]
        public DateTime ReplyDataTime { get; set; }
    }
}
