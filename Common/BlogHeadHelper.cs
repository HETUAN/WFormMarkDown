using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WFormMarkDown.Entitys;

namespace WFormMarkDown.Common
{
    public class BlogHeadHelper
    {

        public static BlogHead GetEmptyBlogHead()
        { 
            Assembly asm = Assembly.GetExecutingAssembly();//读取嵌入式资源
            Stream sm = asm.GetManifestResourceStream("WFormMarkDown.DLL.HexoData.bloghead.json");
            StreamReader sr = new StreamReader(sm);
            string configContent = sr.ReadToEnd();
            sr.Close();
            BlogHead blogHead = Newtonsoft.Json.JsonConvert.DeserializeObject<BlogHead>(configContent);
            return blogHead; 
        }


        public static string GetHelloWorld()
        {
            Assembly asm = Assembly.GetExecutingAssembly();//读取嵌入式资源
            Stream sm = asm.GetManifestResourceStream("WFormMarkDown.DLL.HexoData.Hello_World.MD");
            StreamReader sr = new StreamReader(sm);
            string configContent = sr.ReadToEnd();
            sr.Close();
            return configContent; 
        }
    }
}
