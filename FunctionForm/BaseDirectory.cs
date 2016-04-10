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

namespace WFormMarkDown.FunctionForm
{
    public partial class BaseDirectory : Form
    {
        private string baseDir = "";
        public bool SetBaseDir(string dir)
        {
            if (Directory.Exists(dir))
            {
                this.baseDir = dir;
                return true;
            }
            else
            {
                MessageBox.Show("目录 " + dir + " 不存在！");
                return false;
            }
        }

        public string GetBaseDir()
        {
            return this.baseDir;
        }

        public BaseDirectory()
        {
            InitializeComponent();
        }

        private void InitData()
        {
            //
        }

    }
}
