using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBSProject.DataModel.Model
{
    public class MemberNewsVO : MemberNews
    {
        public MemberNewsDetail details { get; set; }
        /// <summary>
        /// 发布者名字
        /// </summary>
        public string NewsPublisherName { get; set; }
        /// <summary>
        /// 消息接收者
        /// </summary>
        public string NewsReceiverName { get; set; }
        /// <summary>
        /// 状态名称
        /// </summary>
        public string NewsStatusName { get; set; }

    }
}
