using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WFormMarkDown.Common
{
    public class GitHelper
    {
        /// <summary>
        /// Git Bush 程序启动目录
        /// </summary>
        private string workPath;

        //public GitHelper()
        //{ }

        public GitHelper(string path)
        {
            if (File.Exists(path))
            {
                this.workPath = path;
            }
            else
            {
                this.workPath = @"C:\Program Files\Git\bin\sh.exe";
            }
        }

        public bool Init(string dir)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = this.workPath;
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
                p.StandardInput.WriteLine("exit");
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
                p.StartInfo.FileName = this.workPath;
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
                p.StandardInput.WriteLine("exit");
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
                p.StartInfo.FileName = this.workPath;
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
                p.StandardInput.WriteLine("exit");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RmRemote(string dir)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = this.workPath;
                //p.StartInfo.FileName = @"cmd.exe";
                p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                p.Start();//启动程序

                //向cmd窗口发送输入信息 
                p.StandardInput.WriteLine(@"cd " + dir);
                p.StandardInput.WriteLine("git remote rm");
                p.StandardInput.WriteLine("exit");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Remote(string dir, string url, string UserName, string PassWord)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = this.workPath;
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
                p.StandardInput.WriteLine("exit");
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
                p.StartInfo.FileName = this.workPath;
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
                p.StandardInput.WriteLine("exit");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
