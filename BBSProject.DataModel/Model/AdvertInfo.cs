using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class AdvertInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 广告位置ID
        /// </summary>
        [DataMember]
        public int AdvertPositionID { get; set; }
        /// <summary>
        /// 广告Tip
        /// </summary>
        [DataMember]
        public string AdvertTip { get; set; }
        /// <summary>
        /// 广告图文件名
        /// </summary>
        [DataMember]
        public string AdvertFileName { get; set; }
        /// <summary>
        /// 广告图文件位置
        /// </summary>
        [DataMember]
        public string AdvertFilePath { get; set; }
        /// <summary>
        /// 广告点击量
        /// </summary>
        [DataMember]
        public int AdvertClickCount { get; set; }
    }
}
