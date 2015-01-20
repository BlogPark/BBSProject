using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class SysUserModular
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 系统模块ID
        /// </summary>
        [DataMember]
        public int ModularID { get; set; }
        /// <summary>
        /// 系统模块名称
        /// </summary>
        [DataMember]
        public string ModularName { get; set; }
        /// <summary>
        /// 用户组ID
        /// </summary>
        [DataMember]
        public int UsergroupID { get; set; }
        /// <summary>
        /// 是否启用  0 弃用 1 启用
        /// </summary>
        [DataMember]
        public int IsUsed { get; set; }
    }
}
