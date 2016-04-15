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
    public partial class SiteBaseSettings : Form
    {
        public SiteBaseSettings()
        {
            InitializeComponent();
        }

        private void SiteBaseSettings_Load(object sender, EventArgs e)
        {
            Entitys.SiteEntity site = Program.GetConfig().Site;
            tBox_localport.Text = site.localport.ToString();
            tBox_title.Text = site.title;
            tBox_subtitle.Text = site.subtitle;
            tBox_description.Text = site.description;
            tBox_author.Text = site.author;
            tBox_email.Text = site.email;
        }

        private void btn_Site_Base_Save_Click(object sender, EventArgs e)
        {
            int port = 8181;
            if (!int.TryParse(tBox_localport.Text, out port)&&port<10000)
            {
                MessageBox.Show("端口号错误");
                return;
            }
            Entitys.SiteEntity site = Program.GetConfig().Site;
            site.localport = port;
            site.title = tBox_title.Text;
            site.subtitle = tBox_subtitle.Text;
            site.description = tBox_description.Text;
            site.author = tBox_author.Text;
            site.email = tBox_email.Text;
            if (Program.SaveConfig())
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("配置保存失败");
            }
        }

    }
}
