using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormMarkDown.Common
{
    /// <summary>
    /// 配置文件读写类
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ReadFile(string path)
        {
            try
            {
                return File.ReadAllText(path, Encoding.UTF8);
            }
            catch
            {
                return "";
            }
        }

        public static bool WriteFile(string content, string path)
        {
            try
            {
                File.WriteAllText(path, content, Encoding.UTF8);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
         
    }
}
