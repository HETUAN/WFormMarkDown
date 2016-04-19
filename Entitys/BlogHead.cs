using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormMarkDown.Entitys
{
    public class BlogHead
    {
        public string title { get; set; }

        public DateTime date { get; set; }

        public string type { get; set; }

        public List<string> tags { get; set; }

        public List<string> photos { get; set; }

        public string description { get; set; }
    }
}
