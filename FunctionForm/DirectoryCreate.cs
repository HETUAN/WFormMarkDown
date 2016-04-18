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
    public partial class DirectoryCreate : Form
    {
        public DirectoryCreate(string dir)
        {
            InitializeComponent();
            this.baseDir = dir;
        }

        public event DelLeftTree DelLeftTreeEvent;

        public string baseDir;

        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tBox_DirName.Text))
            {
                MessageBox.Show("请输入文件名");
                return;
            }
            string dirname = Path.Combine(this.baseDir, tBox_DirName.Text.Trim().Replace("\\", ""));
            if (Directory.Exists(dirname))
            {
                MessageBox.Show("目录已经存在！");
            }
            else
            {
                DirectoryInfo info = new DirectoryInfo(dirname);
                info.Create();
                DelLeftTreeEvent();
                this.Close();
            }
        }
    }
}
