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
    }
}
