using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormMarkDown.Entitys
{
    public class BlogListView
    {
        public List<BlogView> bloglist { get; set; }
        public DateTime edittime { get; set; }
    }
}
