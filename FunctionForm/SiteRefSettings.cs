using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFormMarkDown.FunctionForm
{
    public partial class SiteRefSettings : Form
    {
        public SiteRefSettings()
        {
            InitializeComponent();
        }

        private void btn_Site_Ref_Save_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> list = new List<string>();
                string str = textBox1.Text.ToString();
                string[] strs = str.Split('\n');
                for (int i = 0; i < strs.Length; i++)
                {
                    list.Add(strs[i]);
                }
                Program.GetConfig().Site.headref = list;
                if (Program.SaveConfig())
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("配置保存失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SiteRefSettings_Load(object sender, EventArgs e)
        {
            Entitys.SiteEntity site = Program.GetConfig().Site;
            StringBuilder sb = new StringBuilder();
            foreach (string item in site.headref)
            {
                sb.AppendLine(item);
            }
            this.textBox1.Text = sb.ToString();
        }
    }
}
