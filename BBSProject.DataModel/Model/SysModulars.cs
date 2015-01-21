using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class SysModulars
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        [DataMember]
        public string ModularName { get; set; }
        /// <summary>
        /// 模块值
        /// </summary>
        [DataMember]
        public string ModularValue { get; set; }
        /// <summary>
        /// 是否启用  0 弃用 1 启用
        /// </summary>
        [DataMember]
        public int IsUsed { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        [DataMember]
        public string Action { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        [DataMember]
        public int FatherID { get; set; }

    }
}
