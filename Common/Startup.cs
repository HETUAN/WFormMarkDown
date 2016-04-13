using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormMarkDown.Common
{

    public class Startup
    {
        private static string LocalDir;// = @"C:\Users\hepw\Desktop\hetuan.github.io-master";

        static Startup()
        {
            LocalDir = Program.GetConfig().BlogDirectory;// @"C:\Users\hepw\Desktop\weather";
            //LocalDir = @"C:\Users\hepw\Desktop\hetuan.github.io-master";
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.Run(HandleRequest);
        }

        static Task HandleRequest(IOwinContext context)
        {
            try
            {

                string url = context.Request.Uri.AbsolutePath;
                string local;
                if (string.IsNullOrWhiteSpace(url.Replace("/", "")))
                {
                    local = LocalDir + "\\index.html";
                }
                else
                {
                    local = LocalDir + url.Replace("/", "\\");
                }
                FileInfo fi = new FileInfo(local);
                //string type = fi.Extension.Replace(".", "");
                //string ContentType = extensions[type];
                if (string.IsNullOrWhiteSpace(fi.Extension))
                {
                    local += @"\index.html";
                    fi = new FileInfo(local);
                }
                string ContentType = ContentTypeDic.GetContentType(fi.Extension);
                byte[] bts = File.ReadAllBytes(local);
                context.Response.ContentType = ContentType;
                return context.Response.WriteAsync(bts);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/octet-stream";
                return context.Response.WriteAsync("");
            }
        }
    }
}
