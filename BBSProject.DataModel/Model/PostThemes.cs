using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BBSProject.DataModel.Model
{
    [DataContract]
    public class PostThemes
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int ThemeID { get; set; }
        /// <summary>
        /// 主题名称
        /// </summary>
        [DataMember]
        public string ThemeName { get; set; }
        /// <summary>
        /// 模块ID
        /// </summary>
        [DataMember]
        public int ModularID { get; set; }
    }
}
