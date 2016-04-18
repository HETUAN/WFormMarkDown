using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using WFormMarkDown.Entitys;
using WFormMarkDown.Enums;

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
            this.dataPath = Path.Combine(path, "MarkDownData.json");
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

        public List<FileEntity> GetFileEntityLsit()
        {
            return this.FileList;
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
                this.FileList.Clear();
                RefDirToTree(FileEntity.GetNextCount(), 0, this.baseDir, this.FileList);
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

}
