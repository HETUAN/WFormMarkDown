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

namespace WFormMarkDown
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            richTextBox1.Text = File.ReadAllText(@"E:\20160317-CentOS-Other-Operater.md");
        }
    }
}
