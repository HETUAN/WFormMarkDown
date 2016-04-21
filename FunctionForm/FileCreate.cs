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
using WFormMarkDown.Common;

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
                if (string.IsNullOrWhiteSpace(tBox_FileName.Text))
                {
                    MessageBox.Show("请输入文件名");
                    return;
                }
                string fileName = tBox_FileName.Text.Trim().Replace(' ', '_');
                string filepath = Path.Combine(baseDir, fileName);
                if (filepath.Substring(filepath.Length - 2).ToUpper() != ".MD")
                {
                    filepath += ".md";
                }
                if (File.Exists(filepath))
                {
                    MessageBox.Show("文件名已经存在！");
                    return;
                }
                StreamWriter sw = File.CreateText(filepath);
                Entitys.BlogHead blogHead = new Entitys.BlogHead();
                blogHead.type = "";
                blogHead.tags = new List<string>();
                blogHead.title = fileName;
                blogHead.photos = new List<string>();
                blogHead.description = "";
                blogHead.date = DateTime.Now;
                StringBuilder headStr = new StringBuilder();

                headStr.AppendLine("---StartBlogHead");
                headStr.AppendLine(JsonPrase.PraseToJson(Newtonsoft.Json.JsonConvert.SerializeObject(blogHead)));
                //headStr.AppendLine("{");
                //headStr.AppendLine(string.Format("    \"title\": \"{0}\",", fileName));
                //headStr.AppendLine("    \"date\": \"0001-01-01T00:00:00\",");
                //headStr.AppendLine("    \"type\": \"\",");
                //headStr.AppendLine("    \"tags\": [],");
                //headStr.AppendLine("    \"photos\": [],");
                //headStr.AppendLine("    \"description\": \"\"");
                //headStr.AppendLine("}");
                headStr.AppendLine("---EndBlogHead");
                headStr.AppendLine("");
                headStr.AppendLine("##Hello World!");

                sw.Write(headStr.ToString());
                sw.Close();
                DelLeftTreeEvent();
                this.Close();
            }
            else
            {
                MessageBox.Show("请重新选择文件目录！");
            }
        }

        private void FileCreate_Load(object sender, EventArgs e)
        {
            this.tBox_FileName.Focus();
        }

        private void FileCreate_Activated(object sender, EventArgs e)
        {
            this.tBox_FileName.Focus();
        }

        private void tBox_FileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btn_Create_Click(sender, e);
            }
        }
    }
}
