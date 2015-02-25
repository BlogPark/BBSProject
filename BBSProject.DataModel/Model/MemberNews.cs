using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class MemberNews
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int NewsID { get; set; }
        /// <summary>
        /// 消息标题
        /// </summary>
        [DataMember]
        public string NewsTitle { get; set; }
        /// <summary>
        /// 消息发布者
        /// </summary>
        [DataMember]
        public int NewsPublisher { get; set; }
        /// <summary>
        /// 消息接受者
        /// </summary>
        [DataMember]
        public int NewsReceiver { get; set; }
        /// <summary>
        /// 消息是否已读  0 未读 1 已读
        /// </summary>
        [DataMember]
        public int NewsReaded { get; set; }
        /// <summary>
        /// 消息状态 100 未发送  200 已发送  300 已过期  400 已删除 500 已阅读
        /// </summary>
        [DataMember]
        public int NewsStatus { get; set; }
        /// <summary>
        /// 消息发布时间
        /// </summary>
        [DataMember]
        public DateTime NewsPublishTime { get; set; }
        /// <summary>
        /// 消息阅读时间
        /// </summary>
        [DataMember]
        public DateTime NewsReadedTime { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        [DataMember]
        public string NewsContent { get; set; }
    }
}
