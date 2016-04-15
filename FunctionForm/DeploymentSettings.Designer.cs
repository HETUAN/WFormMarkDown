namespace WFormMarkDown.FunctionForm
{
    partial class DeploymentSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tBox_deploy = new System.Windows.Forms.TextBox();
            this.tBox_type = new System.Windows.Forms.TextBox();
            this.tBox_repository = new System.Windows.Forms.TextBox();
            this.tBox_branch = new System.Windows.Forms.TextBox();
            this.tBox_username = new System.Windows.Forms.TextBox();
            this.tBox_password = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "远程（空）";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "地址";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "分支";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "用户名";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "密码";
            // 
            // tBox_deploy
            // 
            this.tBox_deploy.Location = new System.Drawing.Point(88, 27);
            this.tBox_deploy.Name = "tBox_deploy";
            this.tBox_deploy.Size = new System.Drawing.Size(223, 21);
            this.tBox_deploy.TabIndex = 6;
            // 
            // tBox_type
            // 
            this.tBox_type.Location = new System.Drawing.Point(88, 65);
            this.tBox_type.Name = "tBox_type";
            this.tBox_type.Size = new System.Drawing.Size(223, 21);
            this.tBox_type.TabIndex = 7;
            // 
            // tBox_repository
            // 
            this.tBox_repository.Location = new System.Drawing.Point(88, 109);
            this.tBox_repository.Name = "tBox_repository";
            this.tBox_repository.Size = new System.Drawing.Size(223, 21);
            this.tBox_repository.TabIndex = 8;
            // 
            // tBox_branch
            // 
            this.tBox_branch.Location = new System.Drawing.Point(88, 154);
            this.tBox_branch.Name = "tBox_branch";
            this.tBox_branch.Size = new System.Drawing.Size(223, 21);
            this.tBox_branch.TabIndex = 9;
            // 
            // tBox_username
            // 
            this.tBox_username.Location = new System.Drawing.Point(88, 198);
            this.tBox_username.Name = "tBox_username";
            this.tBox_username.Size = new System.Drawing.Size(223, 21);
            this.tBox_username.TabIndex = 10;
            // 
            // tBox_password
            // 
            this.tBox_password.Location = new System.Drawing.Point(88, 231);
            this.tBox_password.Name = "tBox_password";
            this.tBox_password.Size = new System.Drawing.Size(223, 21);
            this.tBox_password.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DeploymentSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 320);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tBox_password);
            this.Controls.Add(this.tBox_username);
            this.Controls.Add(this.tBox_branch);
            this.Controls.Add(this.tBox_repository);
            this.Controls.Add(this.tBox_type);
            this.Controls.Add(this.tBox_deploy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DeploymentSettings";
            this.Text = "DeploymentSettings";
            this.Load += new System.EventHandler(this.DeploymentSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBox_deploy;
        private System.Windows.Forms.TextBox tBox_type;
        private System.Windows.Forms.TextBox tBox_repository;
        private System.Windows.Forms.TextBox tBox_branch;
        private System.Windows.Forms.TextBox tBox_username;
        private System.Windows.Forms.TextBox tBox_password;
        private System.Windows.Forms.Button button1;
    }
}