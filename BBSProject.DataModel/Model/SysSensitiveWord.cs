using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class SysSensitiveWord
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 敏感词
        /// </summary>
        [DataMember]
        public string SensitiveWord { get; set; }
        /// <summary>
        /// 是否启用（0 弃用 1 启用）
        /// </summary>
        [DataMember]
        public int IsUsed { get; set; }
    }
}
