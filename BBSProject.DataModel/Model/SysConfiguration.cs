using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class SysConfiguration
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 配置项名称
        /// </summary>
        [DataMember]
        public string OperateName { get; set; }
        /// <summary>
        /// 配置项值
        /// </summary>
        [DataMember]
        public string OperateValue { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        [DataMember]
        public int FatherID { get; set; }
        /// <summary>
        /// 是否启用 0 弃用 1 启用
        /// </summary>
        [DataMember]
        public int IsUsed { get; set; }
        /// <summary>
        /// 配置项备注
        /// </summary>
        [DataMember]
        public string OperateRemark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建人名称
        /// </summary>
        [DataMember]
        public string CreateUser { get; set; }
    }
}
