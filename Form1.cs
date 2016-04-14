using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WFormMarkDown.Common;

namespace WFormMarkDown
{
    public partial class Form1 : Form
    {
        private Common.LeftTree leftTree;
        public Form1()
        {
            InitializeComponent();
            InitForm();
        }

        /// <summary>
        /// 初始化用户界面
        /// </summary>
        /// <returns></returns>
        private bool InitForm()
        {
            InitUserInfo();
            InitLeftTree();
            return true;
        }

        /// <summary>
        /// 初始化左侧目录树
        /// </summary>
        /// <returns></returns>
        private bool InitLeftTree()
        {
            leftTree = new Common.LeftTree(WFormMarkDown.Program.GetConfig().BlogDirectory);
            leftTree.RenderTree(treeView1);
            return true;
        }

        /// <summary>
        /// 初始化用户以及其他数据
        /// </summary>
        /// <returns></returns>
        private bool InitUserInfo()
        {
            return true;
        }


        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                //Common.FileEntity entity = (Common.FileEntity)((TreeView)sender).Tag;
                if (this.treeView1.SelectedNode.Nodes.Count > 0)
                    return;
                Common.FileEntity entity = (Common.FileEntity)this.treeView1.SelectedNode.Tag;
                this.textBox1.Text = File.ReadAllText(entity.GetFullPath());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //MarkdownDeep.Markdown mkd = new MarkdownDeep.Markdown();

            MarkdownSharp.Markdown md = new MarkdownSharp.Markdown();
            string str = md.Transform(textBox1.Text);
            Console.WriteLine(str);
        }

        private void File_Create_ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string curDir;
            if (treeView1.SelectedNode == null)
            {
                curDir = WFormMarkDown.Program.GetConfig().BlogDirectory;
            }
            else
            {
                curDir = ((FileEntity)treeView1.SelectedNode.Tag).GetFullPath();
            }
        }

        /// <summary>
        /// 设置用户主目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void File_BaseDir_toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FunctionForm.BaseDirectory bd = new FunctionForm.BaseDirectory();
            bd.SetBaseDir("");
            bd.Show();
        }

        /// <summary>
        /// 提交推送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Push_toolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 本地查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RUnLocal_toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!Program.GetIsRunInLocal())
            {
                Common.ProcessHelper.RunOwinWebServer();
                Program.SetIsRunInLocal(true);
            }
            else
            {
                Common.ProcessHelper.StopOwinWebServer();
                Program.SetIsRunInLocal(false);
            }
            //if (Program.GetIsRunInLocal())
            //{
            //    if (Common.RunInLocal.StopServer())
            //    {
            //        MessageBox.Show("网站停止成功！");
            //        Program.SetIsRunInLocal(true);
            //    }
            //    else
            //    {
            //        MessageBox.Show("网站停止失败！");
            //    }
            //}
            //else
            //{
            //    //string HostAddress = "http://localhost:8181/";
            //    if (Common.RunInLocal.RunServer())
            //    {
            //        MessageBox.Show("网站启动成功！");
            //        Program.SetIsRunInLocal(true);
            //    }
            //    else
            //    {
            //        MessageBox.Show("网站启动失败！");
            //    }

            //}
        }

        /// <summary>
        /// 编译配置文件和MarkDown文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Build_toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void InitGit_toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string blogDir = Program.GetBlogDir().Replace("\\", "/");
            Common.GitHelper git = new Common.GitHelper(blogDir);
            git.Init(blogDir);
            git.Add(blogDir);
            git.Commit(blogDir, "commit" + DateTime.Now.ToString());
            git.Remote(blogDir, Program.GetConfig().Deployment.repository, "123", "456");
        }
    }
}
