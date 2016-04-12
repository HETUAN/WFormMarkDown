using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormMarkDown.Entitys
{
    public class BlogView
    {
        public int id { get; set; }
        public int num { get; set; }
        public int hashcode { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string tag { get; set; }
        public string url { get; set; }
        public DateTime time { get; set; }
        public string describe { get; set; }
        public string imgimgurl { get; set; }
        public bool ischanged { get; set; }
    }
}
