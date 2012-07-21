using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.Order;

namespace Annon.Xuanxing
{
    public partial class orderImformation : Form
    {
        List<ordersinfo> ll = new List<ordersinfo>();
        

        public orderImformation()
        {
            InitializeComponent();
            hours_comboBox.Text = 48+"";
            //AAonRating.aaon.dataGridView1.Columns["No"].DataPropertyName=ll.
        }

        private void orderImformation_Load(object sender, EventArgs e)
        {

        }

        private void OK_button_Click(object sender, EventArgs e)
        {
            ordersinfo odinfo = new ordersinfo();
            odinfo.OrderNo++    ;
            odinfo.JobNum = Jobno_textBox.Text;
            odinfo.JobName = JobName_textBox.Text;
            odinfo.JobDes = jobDes_textBox.Text;
            odinfo.Site = (int)site_numericUpDown.Value;
            odinfo.Customer = Name_comboBox.DisplayMember;
            odinfo.Activity = DateTime.Now.ToString("dd-MM-yyyy");

         
            ll.Add(odinfo);
            AAonRating.aaon.dataGridView1.DataSource=ll;
            AAonRating.aaon.dataGridView1.Refresh();
            this.Close();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            //Font newFont, oldFont;
            //oldFont = tabPage1.Font;
            //if (oldFont.Bold)
            //    newFont = new Font(oldFont, oldFont.Style ^ FontStyle.Bold);
            //else
            //    newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);
            //tabPage1.Font = newFont;
            //tabPage1.Focus();
        }

    }

    

}
