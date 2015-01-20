using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class MemberInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int MemberID { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        [DataMember]
        public string MemberCode { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        [DataMember]
        public string MemberName { get; set; }
        /// <summary>
        /// 会员邮箱
        /// </summary>
        [DataMember]
        public string Email { get; set; }
        /// <summary>
        /// 邮箱是否验证  0 未验证 1 已验证
        /// </summary>
        [DataMember]
        public int CertifiedEmail { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [DataMember]
        public string UserPassWord { get; set; }
        /// <summary>
        /// 用户组ID
        /// </summary>
        [DataMember]
        public int MemberGroupID { get; set; }
        /// <summary>
        /// 发帖数量
        /// </summary>
        [DataMember]
        public int PostCount { get; set; }
        /// <summary>
        /// 是否禁用 0 禁用 1 正常
        /// </summary>
        [DataMember]
        public int IsUsed { get; set; }
        /// <summary>
        /// 头像文件名称
        /// </summary>
        [DataMember]
        public string HeadFileName { get; set; }
        /// <summary>
        /// 头像文件路径
        /// </summary>
        [DataMember]
        public string HeadFilePath { get; set; }
    }
}
