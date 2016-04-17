using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace WFormMarkDown.Common
{
    public class ProgramInit
    {
        private string hexoDataDir;
        private string configPath;
        private string dataDir;
        private string blogDir;
        private string markDownDir;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="exeDir"></param>
        public ProgramInit(string exeDir)
        {
            if (Directory.Exists(exeDir))
            {
                this.hexoDataDir = Path.Combine(exeDir, "HexoData");
                this.configPath = Path.Combine(this.hexoDataDir, "Config.json");
                this.dataDir = Path.Combine(this.hexoDataDir, "Data");
                this.blogDir = Path.Combine(this.hexoDataDir, "Blog");
                this.markDownDir = Path.Combine(this.hexoDataDir, "MarkDown");
            }
        }

        public ProgramInit(string hexoDataDir, string configPath, string dataDir, string blogDir, string markDownDir)
        {
            this.hexoDataDir = hexoDataDir;
            this.configPath = configPath;
            this.dataDir = dataDir;
            this.blogDir = blogDir;
            this.markDownDir = markDownDir;
        }

        /// <summary>
        /// 检查主目录是否存在
        /// </summary>
        /// <returns></returns>
        public bool hexoDataDirExist()
        {
            return File.Exists(this.hexoDataDir);
        }

        /// <summary>
        /// 判断所有文件是否存在
        /// </summary>
        /// <returns></returns>
        public bool CreateAll()
        {
            if (!this.HexoDataDirCheck())
            {
                return false;
            }
            if (!this.ConfigCheck())
            {
                return false;
            }
            if (!this.DataDirCheck())
            {
                return false;
            }
            if (!this.BlogDirCheck())
            {
                return false;
            }
            if (!this.MarkDownDirCheck())
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 检查主目录是否存在，如果存在返回true否则创建目录并返回结果
        /// </summary>
        /// <returns>是否存在</returns>
        public bool HexoDataDirCheck()
        {
            try
            {
                if (!Directory.Exists(this.hexoDataDir))
                {
                    Directory.CreateDirectory(this.hexoDataDir);
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                // todo: Write Log
                return false;
            }
        }

        /// <summary>
        /// 检查主配置文件是否存在，如果存在返回true否则创建文件并返回结果
        /// </summary>
        /// <returns>是否存在</returns>
        public bool ConfigCheck()
        {
            if (!File.Exists(this.configPath))
            {
                try
                {
                    //如果不存在 则从嵌入资源内读取 BlockSet.xml 
                    Assembly asm = Assembly.GetExecutingAssembly();//读取嵌入式资源
                    Stream sm = asm.GetManifestResourceStream("WFormMarkDown.DLL.HexoData.config.json");
                    StreamReader sr = new StreamReader(sm);
                    string configContent = sr.ReadToEnd();
                    sr.Close();
                    Entitys.ConfigEntity configEntity = Newtonsoft.Json.JsonConvert.DeserializeObject<Entitys.ConfigEntity>(configContent);
                    configEntity.BlogDirectory = this.blogDir;
                    configEntity.CurrentDirectory = this.hexoDataDir;
                    configContent = Newtonsoft.Json.JsonConvert.SerializeObject(configEntity);
                    using (StreamWriter sw = File.CreateText(this.configPath))
                    {
                        sw.Write(configContent);
                        sw.Close();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    // todo: Write Log
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 检查数据存放目录是否存在，如果存在返回true否则创建目录并返回结果
        /// </summary>
        /// <returns>是否存在</returns>
        public bool DataDirCheck()
        {
            try
            {
                if (!Directory.Exists(this.dataDir))
                {
                    Directory.CreateDirectory(this.dataDir);
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                // todo: Write Log
                return false;
            }
        }

        /// <summary>
        /// 检查主目录是否存在，如果存在返回true否则创建目录并返回结果
        /// </summary>
        /// <returns>是否存在</returns>
        public bool BlogDirCheck()
        {
            try
            {
                if (!Directory.Exists(this.blogDir))
                {
                    Directory.CreateDirectory(this.blogDir);
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                // todo: Write Log
                return false;
            }
        }
        /// <summary>
        /// 检查主目录是否存在，如果存在返回true否则创建目录并返回结果
        /// </summary>
        /// <returns>是否存在</returns>
        public bool MarkDownDirCheck()
        {
            try
            {
                if (!Directory.Exists(this.markDownDir))
                {
                    Directory.CreateDirectory(this.markDownDir);
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                // todo: Write Log
                return false;
            }
        }

    }
}
