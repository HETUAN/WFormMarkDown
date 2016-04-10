using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormMarkDown.Entitys
{
    public class ConfigEntity
    {
        //
        public SiteEntity Site { get; set; }
        public DeploymentEntity Deployment { get; set; }
        public PaginationEntity Pagination { get; set; }
    }
}
