using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class MemberCollection
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>
        [DataMember]
        public int MemberID { get; set; }
        /// <summary>
        /// 帖子ID
        /// </summary>
        [DataMember]
        public int PostID { get; set; }
        /// <summary>
        /// 状态  100 收藏  200 取消
        /// </summary>
        [DataMember]
        public int Status { get; set; }
        /// <summary>
        /// 收藏时间
        /// </summary>
        [DataMember]
        public DateTime CollectionTime { get; set; }
    }
}
