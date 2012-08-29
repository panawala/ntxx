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
    public partial class Controls : Form
    {
        public Controls()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustomLineItems CLT = new CustomLineItems();
            CLT.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
