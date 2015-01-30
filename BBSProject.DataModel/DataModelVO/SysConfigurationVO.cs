using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBSProject.DataModel.Model
{
    public class SysConfigurationVO : SysConfiguration
    {
        /// <summary>
        /// 使用状态名称
        /// </summary>
        public string UsedName { get; set; }
    }
}
