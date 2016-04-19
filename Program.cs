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
        /// <summary>
        /// 程序所在目录
        /// </summary>
        private static string exeDir;

        /// <summary>
        /// 程序创建的数据主目录
        /// </summary>
        private static string baseDir;

        /// <summary>
        /// 配置文件路径
        /// </summary>
        private static string configDir;

        /// <summary>
        /// 其他配置数据所在目录
        /// </summary>
        private static string dataDir;
        public static string GetDataDir()
        {
            return dataDir;
        }

        /// <summary>
        /// 博客文件所在目录
        /// </summary>
        private static string blogDir;

        public static string GetBlogDir()
        {
            return blogDir;
        }

        /// <summary>
        /// MarkDown文件所在目录
        /// </summary>
        private static string markDownDir;
        public static string GetMarkDownDir()
        {
            return markDownDir;
        }

        /// <summary>
        /// 程序的主配置文件
        /// </summary>
        private static Entitys.ConfigEntity Config;
        public static Entitys.ConfigEntity GetConfig()
        {
            return Program.Config;
        }

        /// <summary>
        /// 是否查看
        /// </summary>
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
            try
            {
                if (!Directory.Exists(baseDir))
                {
                    DialogResult re = MessageBox.Show("是否进行数据初始化？", "数据初始化", MessageBoxButtons.YesNo);
                    if (re == DialogResult.Yes)
                    {
                        // 创建
                        Directory.CreateDirectory(baseDir);
                    }
                }
                if (!File.Exists(configDir))
                {
                    //如果不存在 则从嵌入资源内读取 BlockSet.xml 
                    Assembly asm = Assembly.GetExecutingAssembly();//读取嵌入式资源
                    Stream sm = asm.GetManifestResourceStream("WFormMarkDown.DLL.HexoData.config.json");
                    StreamReader sr = new StreamReader(sm);
                    string configContent = sr.ReadToEnd();
                    sr.Close();
                    Entitys.ConfigEntity configEntity = Newtonsoft.Json.JsonConvert.DeserializeObject<Entitys.ConfigEntity>(configContent);
                    configEntity.BlogDirectory = blogDir;
                    configEntity.CurrentDirectory = baseDir;
                    configContent = Newtonsoft.Json.JsonConvert.SerializeObject(configEntity);
                    using (StreamWriter sw = File.CreateText(configDir))
                    {
                        sw.Write(configContent);
                        sw.Close();
                    }
                }
                if (!Directory.Exists(dataDir))
                {
                    Directory.CreateDirectory(dataDir);
                }
                if (!Directory.Exists(markDownDir))
                {
                    Directory.CreateDirectory(markDownDir);
                    using (StreamWriter sw = File.CreateText(markDownDir + "\\README.MD"))
                    {
                        sw.Write("Hello World!");
                        sw.Close();
                    }
                }
                if (!Directory.Exists(blogDir))
                {
                    Directory.CreateDirectory(blogDir);
                }

                string stylesDir = Path.Combine(blogDir, "Styles");
                if (!Directory.Exists(stylesDir))
                    Directory.CreateDirectory(stylesDir);

                string scriptsDir = Path.Combine(blogDir, "Scripts");
                if (!Directory.Exists(scriptsDir))
                    Directory.CreateDirectory(scriptsDir);

                string baseStyle = Path.Combine(blogDir, "Styles", "style.css");
                if (!File.Exists(baseStyle))
                {
                    //如果不存在 则从嵌入资源内读取 BlockSet.xml 
                    Assembly asm = Assembly.GetExecutingAssembly();//读取嵌入式资源
                    Stream sm = asm.GetManifestResourceStream("WFormMarkDown.DLL.web.style.css");
                    StreamReader sr = new StreamReader(sm);
                    string baseStyleContent = sr.ReadToEnd();
                    sr.Close();
                    using (StreamWriter sw = File.CreateText(baseStyle))
                    {
                        sw.Write(baseStyleContent);
                        sw.Close();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <returns></returns>
        public static bool SaveConfig()
        {
            try
            {
                string config = Newtonsoft.Json.JsonConvert.SerializeObject(GetConfig());
                using (StreamWriter sw = new StreamWriter(configDir))
                {
                    sw.Write(config);
                    sw.Close();
                }
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
