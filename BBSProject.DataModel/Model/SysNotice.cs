using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class SysNotice
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int NoticeID { get; set; }
        /// <summary>
        /// 公告标题
        /// </summary>
        [DataMember]
        public string NoticeTitle { get; set; }
        /// <summary>
        /// 公告内容
        /// </summary>
        [DataMember]
        public string NoticeContent { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        [DataMember]
        public DateTime PublishTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember]
        public DateTime ExpiredTime { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        [DataMember]
        public int IsUsed { get; set; }
        /// <summary>
        /// 发布人名称
        /// </summary>
        [DataMember]
        public string PublishUserName { get; set; }
        /// <summary>
        /// 状态  100 待发布 200 已发布 300 已过期 400 已删除
        /// </summary>
        [DataMember]
        public int PublishState { get; set; }
    }
}
