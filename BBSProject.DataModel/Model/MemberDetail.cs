using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class MemberDetail
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
        /// 婚姻状态
        /// </summary>
        [DataMember]
        public int MarriedSta { get; set; }
        /// <summary>
        /// 真实名字
        /// </summary>
        [DataMember]
        public string TrueName { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        [DataMember]
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// 性别  0 男 1 女
        /// </summary>
        [DataMember]
        public int Gender { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        [DataMember]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        [DataMember]
        public string QQNumber { get; set; }
        /// <summary>
        /// 毕业院校
        /// </summary>
        [DataMember]
        public string GraduateShcool { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        [DataMember]
        public string Education { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        [DataMember]
        public string Occupation { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        public string Company { get; set; }
        /// <summary>
        /// 月收入
        /// </summary>
        [DataMember]
        public decimal MonthIncome { get; set; }
        /// <summary>
        /// 自我介绍
        /// </summary>
        [DataMember]
        public string SelfIntroduction { get; set; }
        /// <summary>
        /// 自我签名
        /// </summary>
        [DataMember]
        public string SelfSigned { get; set; }
        /// <summary>
        /// 性格爱好
        /// </summary>
        [DataMember]
        public string SelfHobbies { get; set; }
    }
}
