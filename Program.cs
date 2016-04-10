using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WFormMarkDown
{
    static class Program
    {
        private static string baseDir;
        private static string dataDir;
        private static string configDir;
        private static string ddDir;
        private static Entitys.ConfigEntity Config;
        private static Entitys.ConfigEntity GetConfig()
        {
            return Program.Config;
        }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            baseDir = Environment.CurrentDirectory;
            dataDir = baseDir + "\\HexoData";
            configDir = dataDir + "\\config.json";
            ddDir = dataDir + "\\Data";
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
                    Directory.CreateDirectory(dataDir);
                    File.Create(configDir);
                    Directory.CreateDirectory(ddDir);
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
                string config = File.ReadAllText(configDir);
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
