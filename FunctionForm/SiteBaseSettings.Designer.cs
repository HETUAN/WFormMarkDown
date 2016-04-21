namespace WFormMarkDown.FunctionForm
{
    partial class SiteBaseSettings
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
            this.tBox_title = new System.Windows.Forms.TextBox();
            this.tBox_subtitle = new System.Windows.Forms.TextBox();
            this.tBox_description = new System.Windows.Forms.TextBox();
            this.tBox_author = new System.Windows.Forms.TextBox();
            this.tBox_email = new System.Windows.Forms.TextBox();
            this.tBox_localport = new System.Windows.Forms.TextBox();
            this.btn_Site_Base_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标题";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "子标题";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "描述";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "作者";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "邮箱";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "端口";
            // 
            // tBox_title
            // 
            this.tBox_title.Location = new System.Drawing.Point(106, 21);
            this.tBox_title.Name = "tBox_title";
            this.tBox_title.Size = new System.Drawing.Size(242, 21);
            this.tBox_title.TabIndex = 6;
            // 
            // tBox_subtitle
            // 
            this.tBox_subtitle.Location = new System.Drawing.Point(106, 67);
            this.tBox_subtitle.Name = "tBox_subtitle";
            this.tBox_subtitle.Size = new System.Drawing.Size(242, 21);
            this.tBox_subtitle.TabIndex = 7;
            // 
            // tBox_description
            // 
            this.tBox_description.Location = new System.Drawing.Point(106, 114);
            this.tBox_description.Name = "tBox_description";
            this.tBox_description.Size = new System.Drawing.Size(242, 21);
            this.tBox_description.TabIndex = 8;
            // 
            // tBox_author
            // 
            this.tBox_author.Location = new System.Drawing.Point(106, 162);
            this.tBox_author.Name = "tBox_author";
            this.tBox_author.Size = new System.Drawing.Size(242, 21);
            this.tBox_author.TabIndex = 9;
            // 
            // tBox_email
            // 
            this.tBox_email.Location = new System.Drawing.Point(106, 207);
            this.tBox_email.Name = "tBox_email";
            this.tBox_email.Size = new System.Drawing.Size(242, 21);
            this.tBox_email.TabIndex = 10;
            // 
            // tBox_localport
            // 
            this.tBox_localport.Location = new System.Drawing.Point(106, 249);
            this.tBox_localport.Name = "tBox_localport";
            this.tBox_localport.Size = new System.Drawing.Size(242, 21);
            this.tBox_localport.TabIndex = 11;
            // 
            // btn_Site_Base_Save
            // 
            this.btn_Site_Base_Save.Location = new System.Drawing.Point(241, 301);
            this.btn_Site_Base_Save.Name = "btn_Site_Base_Save";
            this.btn_Site_Base_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Site_Base_Save.TabIndex = 12;
            this.btn_Site_Base_Save.Text = "保存";
            this.btn_Site_Base_Save.UseVisualStyleBackColor = true;
            this.btn_Site_Base_Save.Click += new System.EventHandler(this.btn_Site_Base_Save_Click);
            // 
            // SiteBaseSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 351);
            this.Controls.Add(this.btn_Site_Base_Save);
            this.Controls.Add(this.tBox_localport);
            this.Controls.Add(this.tBox_email);
            this.Controls.Add(this.tBox_author);
            this.Controls.Add(this.tBox_description);
            this.Controls.Add(this.tBox_subtitle);
            this.Controls.Add(this.tBox_title);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SiteBaseSettings";
            this.Text = "博客信息";
            this.Load += new System.EventHandler(this.SiteBaseSettings_Load);
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
        private System.Windows.Forms.TextBox tBox_title;
        private System.Windows.Forms.TextBox tBox_subtitle;
        private System.Windows.Forms.TextBox tBox_description;
        private System.Windows.Forms.TextBox tBox_author;
        private System.Windows.Forms.TextBox tBox_email;
        private System.Windows.Forms.TextBox tBox_localport;
        private System.Windows.Forms.Button btn_Site_Base_Save;
    }
}