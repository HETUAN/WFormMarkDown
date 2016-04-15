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
    public partial class DeploymentSettings : Form
    {
        public DeploymentSettings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Entitys.DeploymentEntity deploy = Program.GetConfig().Deployment;
            deploy.deploy = tBox_deploy.Text;
            deploy.branch = tBox_branch.Text;
            deploy.repository = tBox_repository.Text;
            deploy.type = tBox_type.Text;
            deploy.username = tBox_username.Text;
            deploy.password = tBox_password.Text;
            if (Program.SaveConfig())
            {
                MessageBox.Show("成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("失败");
            }
        }

        private void DeploymentSettings_Load(object sender, EventArgs e)
        {
            tBox_deploy.Text = Program.GetConfig().Deployment.deploy;
            tBox_branch.Text = Program.GetConfig().Deployment.branch;
            tBox_type.Text = Program.GetConfig().Deployment.type;
            tBox_repository.Text = Program.GetConfig().Deployment.repository;
            tBox_username.Text = Program.GetConfig().Deployment.username;
            tBox_password.Text = Program.GetConfig().Deployment.password;
        }
    }
}
