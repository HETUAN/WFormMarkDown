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
        private string baseDir = @"D:\Sublime\Blog";
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
            leftTree = new Common.LeftTree(baseDir);
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



        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
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
                curDir = baseDir;
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
    }
}
