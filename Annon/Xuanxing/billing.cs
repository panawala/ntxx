using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Annon.Xuanxing
{
    public partial class billing : Form
    {
        public string job_No;
        public string job_Name;
        public int site_num;
        public string sold_name;

        
        public billing()
        {
            InitializeComponent();
            this.site_numericUpDown.Maximum = 10000000;
            this.site_numericUpDown.Minimum = -10000000;
            this.site_numericUpDown.Increment = 50;
            this.site_numericUpDown.Value = 150;
            
        }

        

    }
}
