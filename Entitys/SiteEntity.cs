using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormMarkDown.Entitys
{
    /// <summary>
    /// 站点信息设置
    /// </summary>
    public class SiteEntity
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public string description { get; set; }
        public string author { get; set; }
        public string email { get; set; }
        public string language { get; set; }
    }
}
