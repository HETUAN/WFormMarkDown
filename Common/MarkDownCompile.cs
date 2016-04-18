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
        }

        /// <summary>
        /// 编译文件
        /// </summary>
        /// <param name="blogViewLiat"></param>
        /// <returns></returns>
        public int Compile(List<FileEntity> blogViewLiat)
        {
            return CompileList(blogViewLiat);
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
                if (item.GetFileType() == FileType.Directory)
                {
                    if (item.GetList() != null && item.GetList().Count > 0)
                    {
                        count += CompileList(item.GetList());
                    }
                    continue;
                }

                DateTime createTime = File.GetCreationTime(item.GetFullPath());
                string mdStr = FileHelper.ReadFile(item.GetFullPath());

                string articleStr = string.Format("<article>{0}</article>", MarkDownHelper.ConvertToHtml(mdStr));
                string dirStr = Path.Combine(new string[] { Program.GetBlogDir(), createTime.Year.ToString(), createTime.Month.ToString(), createTime.Day.ToString(), item.GetName() });
                if (!Directory.Exists(dirStr))
                    Directory.CreateDirectory(dirStr);
                string pathStr = Path.Combine(dirStr, "index.html");
                if (FileHelper.WriteFile(string.Format(htmlModel, headStr, articleStr), pathStr))
                {
                    count++;
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
