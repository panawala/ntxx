using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Annon.Report
{
    public partial class FormControl : Form
    {
        public FormControl()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormControl_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> reportNames = new List<string>();
            if (checkBox1.CheckState == CheckState.Checked)
            {
                new Annon.Report.Form4().ShowDialog();
            }
            if (checkBox2.CheckState == CheckState.Checked)
            {
                reportNames.Add("Report1.rdlc");
            }
            if (checkBox3.CheckState == CheckState.Checked)
            {
                reportNames.Add("Report2.rdlc");
            }
            if (checkBox4.CheckState == CheckState.Checked)
            {
                reportNames.Add("Report3.rdlc");
            }
            if (checkBox5.CheckState == CheckState.Checked)
            {
                reportNames.Add("Report4.rdlc");
            }
            if (checkBox6.CheckState == CheckState.Checked)
            {
                reportNames.Add("Report5.rdlc");
            }

            AllReports allreport = new AllReports(reportNames);
            allreport.setConfig(orderId, orderDetailId, orderDetailIds);
            allreport.ShowAllReport(reportNames.First());
            
            allreport.ShowDialog();
        }
        public void setConfig(int orderId, int orderDetailId,List<int> orderDetailIds)
        {
            this.orderId = orderId;
            this.orderDetailId = orderDetailId;
            this.orderDetailIds = orderDetailIds;
        }

        private int orderId { get; set; }
        private int orderDetailId { get; set; }
        private List<int> orderDetailIds { get; set; }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
