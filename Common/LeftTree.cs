using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WFormMarkDown.Common
{
    /// <summary>
    /// 左侧目录
    /// </summary>
    public class LeftTree
    {
        private string dataPath;
        private string baseDir;
        private List<FileEntity> FileList;
        public LeftTree(string dir, string path)
        {
            this.dataPath = Path.Combine(path,"MarkDownData.json");
            this.baseDir = dir;
            this.FileList = new List<FileEntity>();
            this.GetFiles();
        }

        /// <summary>
        /// 刷新左侧目录
        /// </summary>
        public void LeftTreeRef()
        {
            this.GetFiles();

        }

        public bool SaveJson()
        {
            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(this.FileList);
            return Common.FileHelper.WriteFile(jsonStr, this.dataPath);
        }

        public bool RenderTree(TreeView tv)
        {
            tv.Nodes.Clear();
            foreach (FileEntity item in FileList)
            {
                TreeNode node = new TreeNode();
                node.Name = item.GetId().ToString();
                node.Text = item.GetName();
                node.Tag = item;
                if (item.GetFileType() == FileType.Directory)
                {
                    RenderNodes(node, item.GetList());
                }
                tv.Nodes.Add(node);
            }
            return true;
        }

        private void RenderNodes(TreeNode pnode, List<FileEntity> list)
        {
            foreach (FileEntity item in list)
            {
                TreeNode node = new TreeNode();
                node.Name = item.GetId().ToString();
                node.Text = item.GetName();
                node.Tag = item;
                if (item.GetFileType() == FileType.Directory)
                {
                    RenderNodes(node, item.GetList());
                }
                pnode.Nodes.Add(node);
            }
        }

        private bool GetFiles()
        {
            if (Directory.Exists(this.baseDir))
            {
                RefDirToTree(FileEntity.GetNextCount(), 0, this.baseDir, FileList);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RefDirToTree(int pid, int deep, string path, List<FileEntity> list)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            DirectoryInfo[] subdir = info.GetDirectories();
            FileInfo[] subfile = info.GetFiles();
            if (subdir == null || subdir.Length <= 0)
            {
                if (subfile == null || subfile.Length <= 0)
                {
                }
                else
                {
                    list.AddRange(this.CreateList(pid, deep++, subfile));
                }
            }
            else
            {
                foreach (DirectoryInfo item in subdir)
                {
                    FileEntity entity = new FileEntity(pid, FileEntity.GetNextCount(), deep++, FileType.Directory, item.FullName);
                    list.Add(entity);
                    RefDirToTree(entity.GetId(), entity.GetDeep() + 1, item.FullName, entity.GetList());
                }

                if (subfile == null || subfile.Length <= 0)
                {
                }
                else
                {
                    list.AddRange(this.CreateList(pid, deep++, subfile));
                }
            }
        }

        private List<FileEntity> CreateList(int pid, int deep, FileInfo[] infos)
        {
            //if(infos==null||infos.Length<=0)
            //    return;
            List<FileEntity> list = new List<FileEntity>();
            foreach (FileInfo info in infos)
            {
                list.Add(new FileEntity(pid, FileEntity.GetNextCount(), deep, FileType.File, info.FullName));
            }
            return list;
        }
    }

    /// <summary>
    /// 文件类型枚举
    /// </summary>
    public enum FileType
    {
        File, // 文件
        Directory  // 目录
    }

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

        public int GetId()
        {
            return this.id;
        }

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
