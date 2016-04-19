using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFormMarkDown.Enums; 

namespace WFormMarkDown.Entitys
{

    /// <summary>
    /// 文件实体
    /// </summary>
    public class FileEntity
    {
        private static int FileCount = 0;
        public static int GetNextCount()
        {
            return ++FileCount;
        }

        public static int GetFileCount()
        {
            return FileCount;
        }

        /// <summary>
        /// 当前文件的号码
        /// </summary>
        private int id;

        /// <summary>
        /// 父节点的号码
        /// </summary>
        private int pid;

        /// <summary>
        /// 目录或文件的名称
        /// </summary>
        private string name;

        /// <summary>
        /// 文件路径
        /// </summary>
        private string path;

        /// <summary>
        /// 目录或文件的所在深度
        /// </summary>
        private int deep;

        /// <summary>
        /// 文件是目录还是文件
        /// </summary>
        private FileType type;

        /// <summary>
        /// 如果是目录的话的子文件的列表
        /// </summary>
        private List<FileEntity> list;

        /// <summary>
        /// 初始化函数
        /// </summary>
        /// <param name="path">当前文件名</param>
        /// <param name="deep">文件深度</param>
        /// <param name="type">文件类型</param>
        public FileEntity(int pid, int id, int deep, FileType type, string path)
        {
            this.pid = pid;
            this.id = id;
            this.path = path;
            if (this.type == FileType.File)
            {
                FileInfo finfo = new FileInfo(path);
                this.name = finfo.Name;
            }
            else
            {
                DirectoryInfo dinfo = new DirectoryInfo(path);
                this.name = dinfo.Name;
            }
            this.deep = deep;
            this.type = type;
            if (type == FileType.Directory)
            {
                this.list = new List<FileEntity>();
            }
        }

        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        public int GetId()
        {
            return this.id;
        }

        /// <summary>
        /// 父节点ID
        /// </summary>
        /// <returns></returns>
        public int GetParentId()
        {
            return this.pid;
        }

        /// <summary>
        /// 获取当前的文件名
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return this.name;
        }

        /// <summary>
        /// 获取文件的全路径
        /// </summary>
        /// <returns></returns>
        public string GetFullPath()
        {
            return this.path;
        }

        /// <summary>
        /// 获取当前文件的深度
        /// </summary>
        /// <returns></returns>
        public int GetDeep()
        {
            return this.deep;
        }

        /// <summary>
        /// 获取当前文件的类型
        /// </summary>
        /// <returns></returns>
        public FileType GetFileType()
        {
            return this.type;
        }

        /// <summary>
        /// 添加一个文件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddFile(FileEntity entity)
        {
            if (this.list != null)
            {
                this.list.Add(entity);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取子文件列表
        /// </summary>
        /// <returns></returns>
        public List<FileEntity> GetList()
        {
            return this.list;
        }

    }
}
