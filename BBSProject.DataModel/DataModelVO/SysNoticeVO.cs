using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBSProject.DataModel.Model
{
    public class SysNoticeVO:SysNotice
    {
        /// <summary>
        /// 发布状态
        /// </summary>
        public string PublishStateName { get; set; }
        /// <summary>
        /// 有效标识
        /// </summary>
        public string UsedName { get; set; }
    }
}
