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
    public partial class ordersummary : Form
    {
        DataTable dt = new DataTable();
        private int NO = 0;

        public ordersummary()
        {
            InitializeComponent();

        }

        private void ordersummary_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddNewUnit ANU = new AddNewUnit();
            ANU.Show();
        }
    }
}
