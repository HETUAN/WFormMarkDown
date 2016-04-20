using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormMarkDown.Entitys
{
    public class BlogView
    {
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public int num { get; set; }

        /// <summary>
        /// 文件哈希值
        /// </summary>
        public string hashcode { get; set; }

        /// <summary>
        /// 文章标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 文章类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 文章标题
        /// </summary>
        public List<string> tags { get; set; }

        /// <summary>
        /// 文章路径
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createtime { get; set; }

        /// <summary>
        /// 最近修改时间
        /// </summary>
        public DateTime edittime { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string describe { get; set; }

        /// <summary>
        /// 显示图片
        /// </summary>
        public List<string> imgurls { get; set; }

        /// <summary>
        /// 是否修改
        /// </summary>
        public bool ischanged { get; set; }
    }
}
