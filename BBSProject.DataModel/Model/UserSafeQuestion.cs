using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class UserSafeQuestion
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
        /// 问题ID
        /// </summary>
        [DataMember]
        public int QuestionID { get; set; }
        /// <summary>
        /// 答案
        /// </summary>
        [DataMember]
        public string AnswerValue { get; set; }
    }
}
