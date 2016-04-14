using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WFormMarkDown.Common
{
    public class ProcessHelper
    {
        private static System.Diagnostics.Process p = new System.Diagnostics.Process();
        public static bool RunOwinWebServer()
        {
            try
            {
                /*
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("test.Code.exe");
                byte[] bs = new byte[stream.Length];
                stream.Read(bs, 0, (int)stream.Length);
                Assembly asm = Assembly.Load(bs);
                MethodInfo info = asm.EntryPoint;
                ParameterInfo[] parameters = info.GetParameters();
                if ((parameters != null) && (parameters.Length > 0))
                    info.Invoke(null, (object[])args);
                else
                    info.Invoke(null, null);
                */

                string path = Environment.CurrentDirectory + "\\HexoData\\blog\\OwinWebServer.exe";
                if (!File.Exists(path))
                {
                    Assembly asm = Assembly.GetExecutingAssembly();//读取嵌入式资源
                    Stream sm = asm.GetManifestResourceStream("WFormMarkDown.DLL.OwinWebServer.exe");
                    //StreamReader sr = new StreamReader(sm);
                    byte[] bts = new byte[sm.Length];

                    sm.Read(bts, 0, bts.Length);
                    //StreamWriter sw = new StreamWriter(sm);

                    FileStream fs = File.Create(path);
                    fs.Write(bts, 0, bts.Length);
                    fs.Close();
                }

                p.StartInfo.FileName = path;// @"C:\Program Files\Git\bin\sh.exe";
                //p.StartInfo.FileName = @"cmd.exe";
                p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                p.StartInfo.Arguments = " \"" + Directory.GetParent(path) + "\" \"http://localhost:" + Program.GetConfig().Site.localport + "\"";
                p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                p.Start();//启动程序
                p.StandardInput.WriteLine("sadf");
                //向cmd窗口发送输入信息 
                //p.StandardInput.WriteLine("exit");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool StopOwinWebServer()
        {
            try
            {
                p.StandardInput.WriteLine("exit");
                p.StandardInput.WriteLine("exit");
                p.StandardInput.WriteLine("exit");
                return true;
                //p.Close();
                //p.Kill();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
