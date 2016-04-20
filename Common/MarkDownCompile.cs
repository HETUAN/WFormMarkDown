using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WFormMarkDown.Entitys;
using WFormMarkDown.Enums;

namespace WFormMarkDown.Common
{
    public class MarkDownCompile
    {
        /// <summary>
        /// 页面的模板
        /// </summary>
        private string htmlModel;

        /// <summary>
        /// head引用
        /// </summary>
        private string headStr;

        /// <summary>
        /// data
        /// </summary>
        private BlogListView blogListView;

        /// <summary>
        /// 类型关键字
        /// </summary>
        private List<string> typeList;

        /// <summary>
        /// 标签关键字
        /// </summary>
        private List<string> tagList;

        /// <summary>
        /// 主页面主体html
        /// </summary>
        private StringBuilder indexHtml;

        /// <summary>
        /// 构造函数
        /// </summary>
        public MarkDownCompile()
        {
            //如果不存在 则从嵌入资源内读取 model.html 
            Assembly asm = Assembly.GetExecutingAssembly();//读取嵌入式资源
            Stream sm = asm.GetManifestResourceStream("WFormMarkDown.DLL.web.model.html");
            StreamReader sr = new StreamReader(sm);
            string configContent = sr.ReadToEnd();
            sr.Close();
            htmlModel = configContent;
            headStr = string.Join("\r\n", Program.GetConfig().Site.headref);
            blogListView = new BlogListView();
            blogListView.bloglist = new List<BlogView>();
            indexHtml = new StringBuilder();
            typeList = new List<string>();
            tagList = new List<string>();
        }

        /// <summary>
        /// 编译文件
        /// </summary>
        /// <param name="blogViewLiat"></param>
        /// <returns></returns>
        public int Compile(List<FileEntity> blogViewLiat)
        {
            int num = CompileList(blogViewLiat);
            FileHelper.WriteFile(Newtonsoft.Json.JsonConvert.SerializeObject(this.blogListView), Path.Combine(Program.GetDataDir(), "data.json"));
            //string pathStr = Path.Combine(Program.GetBlogDir(), "index.html");
            //FileHelper.WriteFile(string.Format(htmlModel, headStr, indexHtml.ToString()), pathStr);
            CompileIndexPage();
            CompileListPages();
            return num;
        }

        /// <summary>
        /// 保存主页面HTML
        /// </summary>
        /// <returns></returns>
        private bool CompileIndexPage()
        {
            string pathStr = Path.Combine(Program.GetBlogDir(), "index.html");
            return FileHelper.WriteFile(string.Format(htmlModel, headStr, indexHtml.ToString()), pathStr);
        }

        /// <summary>
        /// 生成类型和标签页面内容
        /// </summary>
        /// <returns></returns>
        private bool CompileListPages()
        {
            Dictionary<string, string> typedata = new Dictionary<string, string>();
            foreach (var type in typeList)
            {
                StringBuilder typehtml = new StringBuilder();
                typehtml.AppendLine("<h2 class=\"typetitle\">types</h2>");
                typehtml.AppendLine("<ul class=\"typelist\">");
                foreach (var blog in this.blogListView.bloglist.Where(b => b.type == type).ToList())
                {
                    typehtml.AppendLine(string.Format("<li><a href=\"{0}\">{1}----{2}</a></li>", blog.url, blog.title, blog.edittime.ToString("yyyy-MM-dd hh:mm:ss")));
                }
                typehtml.AppendLine("</ul>");
                string pathStr = Path.Combine(Program.GetBlogDir(), "type_" + type + ".html");
                FileHelper.WriteFile(string.Format(htmlModel, headStr, typehtml.ToString()), pathStr);
                typedata.Add(type, "type_" + type + ".html");
            }
            FileHelper.WriteFile(Newtonsoft.Json.JsonConvert.SerializeObject(typedata), Path.Combine(Program.GetDataDir(), "typedata.json"));

            Dictionary<string, string> tagdata = new Dictionary<string, string>();
            foreach (var tag in tagList)
            {
                StringBuilder typehtml = new StringBuilder();
                typehtml.AppendLine("<h2 class=\"typetitle\">tags</h2>");
                typehtml.AppendLine("<ul class=\"typelist\">");
                foreach (var blog in this.blogListView.bloglist.Where(b => b.type == tag).ToList())
                {
                    typehtml.AppendLine(string.Format("<li><a href=\"{0}\">{1}----{2}</a></li>", blog.url, blog.title, blog.edittime.ToString("yyyy-MM-dd hh:mm:ss")));
                }
                typehtml.AppendLine("</ul>");
                string pathStr = Path.Combine(Program.GetBlogDir(), "tag_" + tag + ".html");
                FileHelper.WriteFile(string.Format(htmlModel, headStr, typehtml.ToString()), pathStr);
                tagdata.Add(tag, "tag_" + tag + ".html");
            }
            FileHelper.WriteFile(Newtonsoft.Json.JsonConvert.SerializeObject(tagdata), Path.Combine(Program.GetDataDir(), "tagdata.json"));
            return true;
        }

        /// <summary>
        /// 递归编译
        /// </summary>
        /// <param name="blogViewLiat"></param>
        /// <returns></returns>
        private int CompileList(List<FileEntity> blogViewLiat)
        {
            int count = 0;
            foreach (FileEntity item in blogViewLiat)
            {
                if (item.GetName() == "README.MD")
                    continue;
                if (item.GetFileType() == FileType.Directory)
                {
                    if (item.GetList() != null && item.GetList().Count > 0)
                    {
                        count += CompileList(item.GetList());
                    }
                    continue;
                }

                // md文件创建日期
                DateTime createTime = File.GetCreationTime(item.GetFullPath());

                // 获取md文件内容
                string mdStr = FileHelper.ReadFile(item.GetFullPath());

                // 获取blog头部的配置
                string mdhead = mdStr.Substring(mdStr.IndexOf("---StartBlogHead") + 16, mdStr.IndexOf("---EndBlogHead") - 16);
                Entitys.BlogHead blogHead = Newtonsoft.Json.JsonConvert.DeserializeObject<Entitys.BlogHead>(mdhead);

                // 获取blog内容
                string mdBody = mdStr.Substring(mdStr.IndexOf("---EndBlogHead") + 14);

                // 根据md文件创建日期获取html文件创建路径
                string relativePath = Path.Combine(new string[] { createTime.Year.ToString(), createTime.Month.ToString(), createTime.Day.ToString(), item.GetName() });
                string dirStr = Path.Combine(Program.GetBlogDir(), relativePath);

                // html 文件的所在深度
                int deep = relativePath.Count(c => c == '\\') + 1;

                // 获取html文件的相对路径
                string relativeUrl = "" + relativePath.Replace("\\", "/");
                string relativeHead = "";
                for (int i = 0; i < deep; i++)
                    relativeHead += "../";

                relativeUrl = relativeHead + relativeUrl;

                StringBuilder blogFootStr = new StringBuilder();
                blogFootStr.AppendLine("");
                blogFootStr.AppendLine("<p>");
                blogFootStr.AppendLine(string.Format("<a title =\"pre\" class=\"prev-article\" href=\"{0}\" > 上一篇</a>","#"));
                blogFootStr.AppendLine(string.Format("<a title=\"next\" class=\"next-article\" href=\"#{0}\">下一篇</a>","#"));
                blogFootStr.AppendLine("</p>"); 
                // 将md文件转换成html
                string articleStr = string.Format("<article><h1 class=\"article-title\">{0}</h1>\n\r\n\r{1}\n\r\n\r{2}</article>", blogHead.title, MarkDownHelper.ConvertToHtml(mdBody), blogFootStr.ToString());

                // 创建html文件存放路径
                if (!Directory.Exists(dirStr))
                    Directory.CreateDirectory(dirStr);

                // html文件路径
                string pathStr = Path.Combine(dirStr, "index.html");

                //样式文件的引用 todo:处理本地文件和非本地文件非关系
                string styleRef = "\n\r<link rel=\"stylesheet\" type=\"text/css\" href=\"" + relativeHead + "Styles/style.css\" />";
                styleRef = string.Join("\r\n", Program.GetConfig().Site.headref.Where(str => !str.Contains("href=\"http://") & !str.Contains("href=\"https://") & !str.Contains("src=\"http://") & !str.Contains("src=\"https://"))).Replace("href=\"", "href=\"" + relativeHead);
                styleRef += string.Join("\r\n", Program.GetConfig().Site.headref.Where(str => str.Contains("href=\"http://") || str.Contains("href=\"https://") || str.Contains("src=\"http://") || str.Contains("src=\"https://")));
                if (FileHelper.WriteFile(string.Format(htmlModel, headStr + styleRef, articleStr), pathStr))
                {
                    count++;
                    BlogView blogView = new BlogView();
                    blogView.tags = new List<string>();
                    blogView.title = blogHead.title;  //todo: edit
                    blogView.edittime = DateTime.Now;
                    blogView.createtime = createTime;
                    blogView.describe = blogHead.description;

                    // 计算HashCode
                    var hash = System.Security.Cryptography.HashAlgorithm.Create();
                    var fs = File.Open(item.GetFullPath(), FileMode.Open);
                    byte[] bts = hash.ComputeHash(fs);
                    fs.Close();
                    blogView.hashcode = string.Join("-", bts);
                    blogView.id = item.GetId();
                    blogView.num = item.GetId();
                    blogView.tags = blogHead.tags;
                    blogView.type = blogHead.type;
                    blogView.url = relativeUrl;
                    blogView.imgurls = blogHead.photos;
                    this.blogListView.bloglist.Add(blogView);

                    indexHtml.AppendLine("");
                    indexHtml.AppendLine("<p>");
                    indexHtml.AppendLine(string.Format("    <a title=\"{0}\" target=\"_self\" href=\"{1}\\\">", blogView.title, relativeUrl.Replace("../", "")));
                    indexHtml.AppendLine(string.Format("        <h3>{0}</h3>", blogView.title));
                    indexHtml.AppendLine(string.Format("        <h4>{0}</h4>", blogView.describe));
                    foreach (string imgurl in blogView.imgurls)
                    {
                        indexHtml.AppendLine(string.Format("        <img alt=\"{0}\" src=\"{1}\" />", blogView.title, imgurl));
                    }
                    indexHtml.AppendLine("    </a>");
                    indexHtml.AppendLine("</p>");
                    if (!typeList.Contains(blogView.type))
                        typeList.Add(blogView.type);
                    tagList.Concat(blogView.tags);
                    //if (!tagList.Concat(blogView.tags))
                    //    tagList.Add(blogView.tag);
                }
            }
            return count;
        }

        /*
        public int Compile(List<BlogView> blogViewLiat)
        {
            int count = 0;
            foreach (BlogView view in blogViewLiat)
            {
                string mdStr = FileHelper.ReadFile(view.url);
                string articleStr = string.Format("<article>{0}</article>", MarkDownHelper.ConvertToHtml(mdStr));
                string pathStr = Path.Combine(new string[] { Program.GetBlogDir(), view.createtime.Year.ToString(), view.createtime.Month.ToString(), view.createtime.Day.ToString(), view.title, "index.html" });
                if (FileHelper.WriteFile(string.Format(htmlModel, headStr, articleStr), pathStr))
                {
                    count++;
                }
            }
            return count;
        }
        */
    }
}
