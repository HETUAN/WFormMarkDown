namespace WFormMarkDown
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.User_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.User_Msg_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.File_ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Create_ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Delete_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.File_BaseDir_toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Build_toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.RunLocal_toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Push_toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.InitGit_toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Site_toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Site_Base_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Site_Ref_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Deployment_toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Deployment_Config_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.初始化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.推送ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.推送ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Dir_Create_toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 30);
            this.panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.User_ToolStripMenuItem,
            this.File_ToolStripMenuItem1,
            this.Build_toolStripMenuItem3,
            this.RunLocal_toolStripMenuItem2,
            this.Push_toolStripMenuItem1,
            this.InitGit_toolStripMenuItem1,
            this.Site_toolStripMenuItem1,
            this.Deployment_toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(731, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // User_ToolStripMenuItem
            // 
            this.User_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.User_Msg_ToolStripMenuItem});
            this.User_ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.User_ToolStripMenuItem.Name = "User_ToolStripMenuItem";
            this.User_ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.User_ToolStripMenuItem.Text = "用户";
            // 
            // User_Msg_ToolStripMenuItem
            // 
            this.User_Msg_ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.User_Msg_ToolStripMenuItem.Name = "User_Msg_ToolStripMenuItem";
            this.User_Msg_ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.User_Msg_ToolStripMenuItem.Text = "编辑";
            // 
            // File_ToolStripMenuItem1
            // 
            this.File_ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_Create_ToolStripMenuItem2,
            this.File_Delete_ToolStripMenuItem,
            this.File_BaseDir_toolStripMenuItem1,
            this.Dir_Create_toolStripMenuItem1});
            this.File_ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.File_ToolStripMenuItem1.Name = "File_ToolStripMenuItem1";
            this.File_ToolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.File_ToolStripMenuItem1.Text = "文件";
            // 
            // File_Create_ToolStripMenuItem2
            // 
            this.File_Create_ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.File_Create_ToolStripMenuItem2.Name = "File_Create_ToolStripMenuItem2";
            this.File_Create_ToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.File_Create_ToolStripMenuItem2.Text = "创建文件";
            this.File_Create_ToolStripMenuItem2.Click += new System.EventHandler(this.File_Create_ToolStripMenuItem2_Click);
            // 
            // File_Delete_ToolStripMenuItem
            // 
            this.File_Delete_ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.File_Delete_ToolStripMenuItem.Name = "File_Delete_ToolStripMenuItem";
            this.File_Delete_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.File_Delete_ToolStripMenuItem.Text = "删除";
            // 
            // File_BaseDir_toolStripMenuItem1
            // 
            this.File_BaseDir_toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.File_BaseDir_toolStripMenuItem1.Name = "File_BaseDir_toolStripMenuItem1";
            this.File_BaseDir_toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.File_BaseDir_toolStripMenuItem1.Text = "主目录";
            this.File_BaseDir_toolStripMenuItem1.Click += new System.EventHandler(this.File_BaseDir_toolStripMenuItem1_Click);
            // 
            // Build_toolStripMenuItem3
            // 
            this.Build_toolStripMenuItem3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.Build_toolStripMenuItem3.Name = "Build_toolStripMenuItem3";
            this.Build_toolStripMenuItem3.Size = new System.Drawing.Size(44, 21);
            this.Build_toolStripMenuItem3.Text = "生成";
            this.Build_toolStripMenuItem3.Click += new System.EventHandler(this.Build_toolStripMenuItem3_Click);
            // 
            // RunLocal_toolStripMenuItem2
            // 
            this.RunLocal_toolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.RunLocal_toolStripMenuItem2.Name = "RunLocal_toolStripMenuItem2";
            this.RunLocal_toolStripMenuItem2.Size = new System.Drawing.Size(44, 21);
            this.RunLocal_toolStripMenuItem2.Text = "运行";
            this.RunLocal_toolStripMenuItem2.Click += new System.EventHandler(this.RUnLocal_toolStripMenuItem2_Click);
            // 
            // Push_toolStripMenuItem1
            // 
            this.Push_toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.Push_toolStripMenuItem1.Name = "Push_toolStripMenuItem1";
            this.Push_toolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.Push_toolStripMenuItem1.Text = "提交";
            this.Push_toolStripMenuItem1.Click += new System.EventHandler(this.Push_toolStripMenuItem1_Click);
            // 
            // InitGit_toolStripMenuItem1
            // 
            this.InitGit_toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.InitGit_toolStripMenuItem1.Name = "InitGit_toolStripMenuItem1";
            this.InitGit_toolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.InitGit_toolStripMenuItem1.Text = "推送";
            this.InitGit_toolStripMenuItem1.Click += new System.EventHandler(this.InitGit_toolStripMenuItem1_Click);
            // 
            // Site_toolStripMenuItem1
            // 
            this.Site_toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Site_Base_ToolStripMenuItem,
            this.Site_Ref_ToolStripMenuItem});
            this.Site_toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.Site_toolStripMenuItem1.Name = "Site_toolStripMenuItem1";
            this.Site_toolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.Site_toolStripMenuItem1.Text = "网站";
            // 
            // Site_Base_ToolStripMenuItem
            // 
            this.Site_Base_ToolStripMenuItem.Name = "Site_Base_ToolStripMenuItem";
            this.Site_Base_ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.Site_Base_ToolStripMenuItem.Text = "基础";
            this.Site_Base_ToolStripMenuItem.Click += new System.EventHandler(this.Site_Base_ToolStripMenuItem_Click);
            // 
            // Site_Ref_ToolStripMenuItem
            // 
            this.Site_Ref_ToolStripMenuItem.Name = "Site_Ref_ToolStripMenuItem";
            this.Site_Ref_ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.Site_Ref_ToolStripMenuItem.Text = "引用";
            this.Site_Ref_ToolStripMenuItem.Click += new System.EventHandler(this.Site_Ref_ToolStripMenuItem_Click);
            // 
            // Deployment_toolStripMenuItem1
            // 
            this.Deployment_toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Deployment_Config_ToolStripMenuItem,
            this.初始化ToolStripMenuItem,
            this.推送ToolStripMenuItem,
            this.推送ToolStripMenuItem1});
            this.Deployment_toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.Deployment_toolStripMenuItem1.Name = "Deployment_toolStripMenuItem1";
            this.Deployment_toolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.Deployment_toolStripMenuItem1.Text = "远程";
            // 
            // Deployment_Config_ToolStripMenuItem
            // 
            this.Deployment_Config_ToolStripMenuItem.Name = "Deployment_Config_ToolStripMenuItem";
            this.Deployment_Config_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.Deployment_Config_ToolStripMenuItem.Text = "配置";
            this.Deployment_Config_ToolStripMenuItem.Click += new System.EventHandler(this.Deployment_Config_ToolStripMenuItem_Click);
            // 
            // 初始化ToolStripMenuItem
            // 
            this.初始化ToolStripMenuItem.Name = "初始化ToolStripMenuItem";
            this.初始化ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.初始化ToolStripMenuItem.Text = "初始化";
            // 
            // 推送ToolStripMenuItem
            // 
            this.推送ToolStripMenuItem.Name = "推送ToolStripMenuItem";
            this.推送ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.推送ToolStripMenuItem.Text = "提交修改";
            // 
            // 推送ToolStripMenuItem1
            // 
            this.推送ToolStripMenuItem1.Name = "推送ToolStripMenuItem1";
            this.推送ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.推送ToolStripMenuItem1.Text = "推送";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(731, 352);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Size = new System.Drawing.Size(731, 352);
            this.splitContainer1.SplitterDistance = 132;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ForeColor = System.Drawing.Color.White;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(132, 352);
            this.treeView1.TabIndex = 0;
            this.treeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDoubleClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(21, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(574, 352);
            this.panel5.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.textBox1.MaxLength = 65535;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(574, 352);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(21, 352);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 382);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(731, 20);
            this.panel3.TabIndex = 1;
            // 
            // Dir_Create_toolStripMenuItem1
            // 
            this.Dir_Create_toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.Dir_Create_toolStripMenuItem1.Name = "Dir_Create_toolStripMenuItem1";
            this.Dir_Create_toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.Dir_Create_toolStripMenuItem1.Text = "创建目录";
            this.Dir_Create_toolStripMenuItem1.Click += new System.EventHandler(this.Dir_Create_toolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(731, 402);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem User_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem User_Msg_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem File_ToolStripMenuItem1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem File_Create_ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem File_Delete_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem File_BaseDir_toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Build_toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem RunLocal_toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem Push_toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem InitGit_toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Site_toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Site_Base_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Site_Ref_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Deployment_toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Deployment_Config_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 初始化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 推送ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 推送ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Dir_Create_toolStripMenuItem1;
    }
}

