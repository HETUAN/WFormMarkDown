using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace WFormMarkDown
{
    static class Program
    {
        private static string exeDir;
        private static string baseDir;
        private static string configDir;
        private static string dataDir;
        private static string blogDir;
        private static string markDownDir;
        private static Entitys.ConfigEntity Config;
        public static Entitys.ConfigEntity GetConfig()
        {
            return Program.Config;
        }

        private static bool IsRunInLocal = false;
        public static bool GetIsRunInLocal()
        {
            return IsRunInLocal;
        }
        public static bool SetIsRunInLocal(bool state)
        {
            IsRunInLocal = state;
            return IsRunInLocal;
        }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            exeDir = Environment.CurrentDirectory;
            baseDir = exeDir + "\\HexoData";
            configDir = baseDir + "\\config.json";
            dataDir = baseDir + "\\Data";
            blogDir = baseDir + "\\Blog";
            markDownDir = baseDir + "\\MarkDown";
            if (!InitProgram())
            {
                return;
            }
            LoadConfig();
            Application.Run(new Form1());
        }

        /// <summary>
        /// 初始化文件目录
        /// </summary>
        /// <returns>初始化程序</returns>
        private static bool InitProgram()
        {
            //string baseDir = Environment.CurrentDirectory;
            //string dataDir = baseDir + "\\HexoData";
            //string configDir = dataDir + "\\config.json";
            //string ddDir = dataDir + "\\Data";

            if (Directory.Exists(dataDir))
            {
                return true;
            }
            else
            {
                DialogResult re = MessageBox.Show("是否进行数据初始化？", "数据初始化", MessageBoxButtons.YesNo);
                if (re == DialogResult.Yes)
                {
                    // 创建
                    Directory.CreateDirectory(baseDir);
                    //如果不存在 则从嵌入资源内读取 BlockSet.xml 
                    Assembly asm = Assembly.GetExecutingAssembly();//读取嵌入式资源
                    Stream sm = asm.GetManifestResourceStream("WFormMarkDown.DLL.HexoData.config.json");
                    StreamReader sr = new StreamReader(sm);
                    string configContent = sr.ReadToEnd();
                    Entitys.ConfigEntity configEntity = Newtonsoft.Json.JsonConvert.DeserializeObject<Entitys.ConfigEntity>(configContent);
                    configEntity.BlogDirectory = blogDir;
                    configEntity.CurrentDirectory = baseDir;
                    configContent = Newtonsoft.Json.JsonConvert.SerializeObject(configEntity);
                    using (StreamWriter sw = File.CreateText(configDir))
                    {
                        sw.Write(configContent);
                    }

                    //File.WriteAllText(configDir, configContent, System.Text.Encoding.UTF8);
                    Directory.CreateDirectory(dataDir);
                    Directory.CreateDirectory(markDownDir);
                    Directory.CreateDirectory(blogDir);
                    using (StreamWriter sw = File.CreateText(blogDir + "\\README.MD"))
                    {
                        sw.Write("Hello World!");
                    }
                    Common.GitHelper git = new Common.GitHelper();
                    git.Init(blogDir.Replace("\\", "/"));
                    git.Add(blogDir.Replace("\\", "/"));
                    git.Commit(blogDir.Replace("\\", "/"), "asdf");
                    //File.WriteAllText(blogDir + "\\README.MD", "Hello World!", System.Text.Encoding.UTF8);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private static bool LoadConfig()
        {
            try
            {
                string config = File.ReadAllText(configDir, System.Text.Encoding.UTF8);
                Config = Newtonsoft.Json.JsonConvert.DeserializeObject<Entitys.ConfigEntity>(config);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
