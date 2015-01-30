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
        /// <summary>
        /// 状态 100 未启用  200 启用中  300 已过期
        /// </summary>
        [DataMember]
        public int AdvertState { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [DataMember]
        public DateTime AdvertStarttime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember]
        public DateTime AdvertEndtime { get; set; }
        /// <summary>
        /// 类型0代表文字,1代表图片,2代表flash,3代表代码)
        /// </summary>
        [DataMember]
        public int AdvertType { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        [DataMember]
        public string AdvertURL { get; set; }
        /// <summary>
        /// 广告主题
        /// </summary>
        [DataMember]
        public string AdvertBody { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        [DataMember]
        public string extfield1 { get; set; }
        /// <summary>
        /// 扩展字段
        /// </summary>
        [DataMember]
        public string extfield2 { get; set; }
    }
}
