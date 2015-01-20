using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace BBSProject.DataModel.Model
{
    [DataContract]
     public class MemberFriends
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
        /// 会员好友ID
        /// </summary>
        [DataMember]
        public int FriendMemberID { get; set; }
        /// <summary>
        /// 状态   100 申请发出 200 对方拒绝 300 对方同意 400 对方忽略
        /// </summary>
        [DataMember]
        public int Status { get; set; }
    }
}
