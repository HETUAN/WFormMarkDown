using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormMarkDown.Entitys
{
    public class DeploymentEntity
    {
        public string deploy { get; set; }
        public string type { get; set; }
        public string repository { get; set; }
        public string branch { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
