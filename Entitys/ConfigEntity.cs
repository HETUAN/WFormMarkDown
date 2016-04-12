using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormMarkDown.Entitys
{
    public class ConfigEntity
    {
        public bool IsChanged { get; set; }
        public string CurrentDirectory { get; set; }
        public string BlogDirectory { get; set; }
        public SiteEntity Site { get; set; }
        public DeploymentEntity Deployment { get; set; }
        public PaginationEntity Pagination { get; set; }
    }
}
