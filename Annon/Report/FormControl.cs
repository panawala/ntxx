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
                // If checked, do not allow items to be dragged onto the form.
                new Annon.Report.Form1().ShowDialog();
                new Annon.Report.Form2().ShowDialog();
                new Annon.Report.Form3().ShowDialog();
                new Annon.Report.Form4().ShowDialog();

            }
            if (checkBox2.CheckState == CheckState.Checked)
            {
                // If checked, do not allow items to be dragged onto the form.
                reportNames.Add("Report1.rdlc");
                new Annon.Report.Form1().ShowDialog();
            }
            if (checkBox3.CheckState == CheckState.Checked)
            {
                reportNames.Add("Report2.rdlc");
                // If checked, do not allow items to be dragged onto the form.
                new Annon.Report.Form2().ShowDialog();
            }
            if (checkBox4.CheckState == CheckState.Checked)
            {
                // If checked, do not allow items to be dragged onto the form.
                reportNames.Add("Report3.rdlc");
                new Annon.Report.Form3().ShowDialog();
            }
            if (checkBox5.CheckState == CheckState.Checked)
            {
                // If checked, do not allow items to be dragged onto the form.
                reportNames.Add("Report4.rdlc");
                new Annon.Report.Form4().ShowDialog();
            }
            if (checkBox6.CheckState == CheckState.Checked)
            {
                // If checked, do not allow items to be dragged onto the form.
                reportNames.Add("Report5.rdlc");
                new Annon.Report.Form5().ShowDialog();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
