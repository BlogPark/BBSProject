using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class SysUsers
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 系统用户名
        /// </summary>
        [DataMember]
        public string SysUserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [DataMember]
        public string SysUserPassword { get; set; }
        /// <summary>
        /// 用户组ID
        /// </summary>
        [DataMember]
        public int SysUserGroupID { get; set; }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        [DataMember]
        public string SysUserTrueName { get; set; }
        /// <summary>
        /// 用户联系方式
        /// </summary>
        [DataMember]
        public string SysUserPhone { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        [DataMember]
        public int Status { get; set; }
    }
}
