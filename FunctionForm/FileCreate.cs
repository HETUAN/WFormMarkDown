using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFormMarkDown.FunctionForm
{

    public delegate bool DelLeftTree();
    public partial class FileCreate : Form
    {
        public FileCreate(string dir)
        {
            InitializeComponent();
            this.baseDir = dir;
        }

        public event DelLeftTree DelLeftTreeEvent;

        public string baseDir;

        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(baseDir))
            {
                string filepath = Path.Combine(baseDir,tBox_FileName.Text.Trim().Replace(' ','_'));
                if (filepath.Substring(filepath.Length-2) != ".md")
                {
                    filepath += ".md";
                }
                if (File.Exists(filepath))
                {
                    MessageBox.Show("文件名已经存在！");
                    return;
                }
                StreamWriter sw = File.CreateText(filepath);
                sw.Write("Hello World!");
                sw.Close();
                DelLeftTreeEvent();
                this.Close();
            }
            else {
                MessageBox.Show("请重新选择文件目录！");
            }
        }
    }
}
