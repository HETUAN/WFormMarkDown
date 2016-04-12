using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormMarkDown.Common
{
    public class GitHelper
    {
        private string workPath = @"C:\Program Files\Git\bin\sh.exe";
        public GitHelper()
        { }
        public GitHelper(string path)
        {
            this.workPath = path;
        }
        public bool Init(string dir)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = @"C:\Program Files\Git\bin\sh.exe";
                //p.StartInfo.FileName = @"cmd.exe";
                p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                p.Start();//启动程序

                //向cmd窗口发送输入信息 
                p.StandardInput.WriteLine(@"cd " + dir);
                p.StandardInput.WriteLine("git init");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Add(string dir)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = @"C:\Program Files\Git\bin\sh.exe";
                //p.StartInfo.FileName = @"cmd.exe";
                p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                p.Start();//启动程序

                //向cmd窗口发送输入信息 
                p.StandardInput.WriteLine(@"cd " + dir);
                p.StandardInput.WriteLine("git add .");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool Commit(string dir, string msg)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = @"C:\Program Files\Git\bin\sh.exe";
                //p.StartInfo.FileName = @"cmd.exe";
                p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                p.Start();//启动程序

                //向cmd窗口发送输入信息 
                p.StandardInput.WriteLine(@"cd " + dir);
                p.StandardInput.WriteLine("git commit -m \"" + msg + "\"");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool Remote(string dir, string url, string UserName, string PassWord)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = @"C:\Program Files\Git\bin\sh.exe";
                //p.StartInfo.FileName = @"cmd.exe";
                p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                p.Start();//启动程序

                //向cmd窗口发送输入信息 
                p.StandardInput.WriteLine(@"cd " + dir);
                p.StandardInput.WriteLine(string.Format("git remote add origin http://{0}:{1}@{2}", UserName, PassWord, url.Replace("http://", string.Empty)));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Push(string dir)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = @"C:\Program Files\Git\bin\sh.exe";
                //p.StartInfo.FileName = @"cmd.exe";
                p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                p.Start();//启动程序

                //向cmd窗口发送输入信息 
                p.StandardInput.WriteLine(@"cd " + dir);
                p.StandardInput.WriteLine("git push -u origin master");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
