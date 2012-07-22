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

        private void btn_addNew_Click(object sender, EventArgs e)
        {
            AddNewUnit ANU = new AddNewUnit();
            ANU.OrderSale = AAonRating.aaon.RowIndex;
            ANU.Show();
        }


    }
}
