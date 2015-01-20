using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class MemberGroup
    {
        /// <summary>
        /// 分组ID
        /// </summary>
        [DataMember]
        public int MemberGroupID { get; set; }
        /// <summary>
        /// 分组名称
        /// </summary>
        [DataMember]
        public string MemberGroupName { get; set; }
        /// <summary>
        /// 分组积分最低值
        /// </summary>
        [DataMember]
        public int MinIntegral { get; set; }
        /// <summary>
        /// 分组积分最高值
        /// </summary>
        [DataMember]
        public int MaxIntegral { get; set; }
        /// <summary>
        /// 是否启用  0 禁用 1 启用
        /// </summary>
        [DataMember]
        public int IsUsed { get; set; }
    }
}
