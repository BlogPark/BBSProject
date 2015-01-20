using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class SysUserGroups
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int SysUserGroupID { get; set; }
        /// <summary>
        /// 用户组名称
        /// </summary>
        [DataMember]
        public string SysUserGroupName { get; set; }
        /// <summary>
        /// 是否启用  0 弃用 1 启用
        /// </summary>
        [DataMember]
        public int IsUsed { get; set; }
    }
}
