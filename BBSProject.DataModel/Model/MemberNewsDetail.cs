using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class MemberNewsDetail
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 消息ID
        /// </summary>
        [DataMember]
        public int NewsID { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        [DataMember]
        public string NewsContent { get; set; }
    }
}
