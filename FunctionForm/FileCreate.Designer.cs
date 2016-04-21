namespace WFormMarkDown.FunctionForm
{
    partial class FileCreate
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
            this.btn_Create = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tBox_FileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(233, 72);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(75, 23);
            this.btn_Create.TabIndex = 0;
            this.btn_Create.Text = "创建";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "文件名";
            // 
            // tBox_FileName
            // 
            this.tBox_FileName.Location = new System.Drawing.Point(71, 27);
            this.tBox_FileName.Name = "tBox_FileName";
            this.tBox_FileName.Size = new System.Drawing.Size(250, 21);
            this.tBox_FileName.TabIndex = 2;
            this.tBox_FileName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBox_FileName_KeyPress);
            // 
            // FileCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 108);
            this.Controls.Add(this.tBox_FileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Create);
            this.Name = "FileCreate";
            this.Text = "新建文件";
            this.Activated += new System.EventHandler(this.FileCreate_Activated);
            this.Load += new System.EventHandler(this.FileCreate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBox_FileName;
    }
}