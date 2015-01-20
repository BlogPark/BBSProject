using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class AdvertPosition
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 位置名称
        /// </summary>
        [DataMember]
        public string PositionTitle { get; set; }
        /// <summary>
        /// 是否启用  0 禁用 1 启用
        /// </summary>
        [DataMember]
        public int IsUsed { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public string Description { get; set; }
    }
}
