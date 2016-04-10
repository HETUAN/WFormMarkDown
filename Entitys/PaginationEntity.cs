using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormMarkDown.Entitys
{
    public class PaginationEntity
    {
        public int per_page { get; set; }
        public string pagination_dir { get; set; }
        public string page_data { get; set; }
    }
}
