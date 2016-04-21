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
using WFormMarkDown.Enums;
using WFormMarkDown.Entitys;

namespace WFormMarkDown
{
    public partial class Form1 : Form
    {
        public Common.LeftTree leftTree;

        public bool IsTextBoxChanged = false;

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
            if (this.leftTree == null)
            {
                this.leftTree = new Common.LeftTree(WFormMarkDown.Program.GetMarkDownDir(), WFormMarkDown.Program.GetDataDir());
            }
            else
            {
                this.leftTree.LeftTreeRef();
            }
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
                if (this.treeView1.SelectedNode.Nodes.Count > 0)
                    return;
                FileEntity entity = (FileEntity)this.treeView1.SelectedNode.Tag;
                if (entity.GetFileType() == FileType.Directory)
                    return;
                this.textBox1.Text = File.ReadAllText(entity.GetFullPath());
                this.textBox1.Tag = entity.GetFullPath();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //MarkdownSharp.Markdown md = new MarkdownSharp.Markdown();
            //string str = md.Transform(textBox1.Text);
            //Console.WriteLine(str);
            if (!IsTextBoxChanged)
            {
                IsTextBoxChanged = true;
                this.Text += "*";
            }
        }

        #region 顶部按钮事件


        /// <summary>
        /// 设置用户主目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void File_BaseDir_toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //FunctionForm.BaseDirectory bd = new FunctionForm.BaseDirectory();
            //bd.SetBaseDir("");
            //bd.Show();
            MessageBox.Show("暂时不支持自定义主目录。。。");
            return;
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
                this.RunLocal_toolStripMenuItem2.Text = "停止";
            }
            else
            {
                Common.ProcessHelper.StopOwinWebServer();
                Program.SetIsRunInLocal(false);
                this.RunLocal_toolStripMenuItem2.Text = "运行";
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
            MarkDownCompile mdc = new MarkDownCompile();
            int num = mdc.Compile(this.leftTree.GetFileEntityLsit());

            MessageBox.Show("成功编译" + num + "个 MarkDown 文件");
        }

        /// <summary>
        /// Git 初始化 init Add Commit Remote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitGit_toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string blogDir = Program.GetBlogDir().Replace("\\", "/");
            string gitpwd = Program.GetConfig().Deployment.deploy;
            if (string.IsNullOrWhiteSpace(gitpwd) || File.Exists(gitpwd))
            {
                MessageBox.Show("Git Bush 路径错误！");
                return;
            }
            Common.GitHelper git = new Common.GitHelper(blogDir);
            git.Init(blogDir);
            return;
            git.Add(blogDir);
            git.Commit(blogDir, "commit" + DateTime.Now.ToString());
            if (string.IsNullOrWhiteSpace(Program.GetConfig().Deployment.repository))
            {
                MessageBox.Show("Git远程地址错误！");
                return;
            }
            if (string.IsNullOrWhiteSpace(Program.GetConfig().Deployment.username) || string.IsNullOrWhiteSpace(Program.GetConfig().Deployment.password))
            {
                MessageBox.Show("Git远程用户错误！");
                return;
            }
            git.Remote(blogDir, Program.GetConfig().Deployment.repository, Program.GetConfig().Deployment.username, Program.GetConfig().Deployment.password);
        }

        private void Site_Base_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FunctionForm.SiteBaseSettings sbs = new FunctionForm.SiteBaseSettings();
            sbs.Show();
        }

        private void Site_Ref_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FunctionForm.SiteRefSettings sbs = new FunctionForm.SiteRefSettings();
            sbs.Show();
        }

        private void Deployment_Config_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FunctionForm.DeploymentSettings ds = new FunctionForm.DeploymentSettings();
            ds.Show();
        }


        /// <summary>
        /// 创建MarkDown文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void File_Create_ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string curDir;
            if (treeView1.Focused)
            {
                if (treeView1.SelectedNode == null)
                {
                    curDir = WFormMarkDown.Program.GetConfig().BlogDirectory;
                }
                else
                {
                    FileEntity fe = (FileEntity)treeView1.SelectedNode.Tag;
                    curDir = fe.GetFileType() == FileType.File ? Directory.GetParent(fe.GetFullPath()).FullName : fe.GetFullPath();
                }
            }
            else
            {
                curDir = WFormMarkDown.Program.GetConfig().BlogDirectory;
            }

            FunctionForm.FileCreate fc = new FunctionForm.FileCreate(curDir);
            fc.DelLeftTreeEvent += InitLeftTree;
            fc.Show();
        }

        private void Dir_Create_toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string curDir;
            if (treeView1.Focused)
            {
                if (treeView1.SelectedNode == null)
                {
                    curDir = WFormMarkDown.Program.GetConfig().BlogDirectory;
                }
                else
                {
                    FileEntity fe = (FileEntity)treeView1.SelectedNode.Tag;
                    curDir = fe.GetFileType() == FileType.File ? Directory.GetParent(fe.GetFullPath()).FullName : fe.GetFullPath();
                }
            }
            else
            {
                curDir = WFormMarkDown.Program.GetConfig().BlogDirectory;
            }

            FunctionForm.DirectoryCreate dc = new FunctionForm.DirectoryCreate(curDir);
            dc.DelLeftTreeEvent += InitLeftTree;
            dc.Show();

        }

        /// <summary>
        /// 删除文件或者目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void File_Delete_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择要删除的目录或文件");
            }
            else
            {
                FileEntity fe = (FileEntity)treeView1.SelectedNode.Tag;
                if (fe.GetFileType() == FileType.File)
                {
                    if (MessageBox.Show(this, "确认要删除文件：" + fe.GetName() + " 吗？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        File.Delete(fe.GetFullPath());
                        InitLeftTree();
                    }
                }
                else
                {
                    if (MessageBox.Show(this, "确认要删除目录：" + fe.GetName() + " 和它包含的文件吗？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Directory.Delete(fe.GetFullPath(), true);
                        InitLeftTree();
                    }
                }
            }

        }

        #endregion

        /// <summary>
        /// 主窗体关闭时事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 判断本地WebServer是否正在运行如果正在运行先关闭
            if (Program.GetIsRunInLocal())
            {
                Common.ProcessHelper.StopOwinWebServer();
                Program.SetIsRunInLocal(false);
            }

        }
         
        private void File_Save_toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string path = this.textBox1.Tag.ToString();
            if (this.IsTextBoxChanged && FileHelper.WriteFile(this.textBox1.Text, path))
            {
                this.Text = this.Text.Substring(0, this.Text.Length - 1);
                //MessageBox.Show("文件保存成功！");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                File_Save_toolStripMenuItem1_Click(sender, e);
            }
        }
         
        private void Git_Init_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string blogDir = Program.GetBlogDir().Replace("\\", "/");
            string gitpwd = Program.GetConfig().Deployment.deploy;
            if (string.IsNullOrWhiteSpace(gitpwd) || !File.Exists(gitpwd))
            {
                MessageBox.Show("Git Bush 路径错误！");
                return;
            }
            Common.GitHelper git = new Common.GitHelper(blogDir);
            if (git.Init(blogDir)&&git.Remote(blogDir,Program.GetConfig().Deployment.repository, Program.GetConfig().Deployment.username, Program.GetConfig().Deployment.password))
            {
                MessageBox.Show("初始化成功!");
            }
            else
            {
                MessageBox.Show("初始化失败!");
            }

        }

        private void Git_Commit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string blogDir = Program.GetBlogDir().Replace("\\", "/");
            string gitpwd = Program.GetConfig().Deployment.deploy;
            if (string.IsNullOrWhiteSpace(gitpwd) || !File.Exists(gitpwd))
            {
                MessageBox.Show("Git Bush 路径错误！");
                return;
            }
            Common.GitHelper git = new Common.GitHelper(blogDir);
            if (git.Add(blogDir) && git.Commit(blogDir, "commit" + DateTime.Now.ToString()))
            {
                MessageBox.Show("提交成功!");
            }
            else
            {
                MessageBox.Show("提交失败!");
            }
        }

        private void Git_Push_ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string blogDir = Program.GetBlogDir().Replace("\\", "/");
            string gitpwd = Program.GetConfig().Deployment.deploy;
            if (string.IsNullOrWhiteSpace(gitpwd) || !File.Exists(gitpwd))
            {
                MessageBox.Show("Git Bush 路径错误！");
                return;
            }
            Common.GitHelper git = new Common.GitHelper(blogDir);
            if (git.Push(blogDir))
            {
                MessageBox.Show("推送成功!");
            }
            else
            {
                MessageBox.Show("推送失败!");
            }
        } 
    }
}
