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
            radioButton3.Checked = true;
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
                List<int> orderDetailList = new List<int>();
                //if (checkBox1.CheckState == CheckState.Checked)
                //{
                //    new Annon.Report.Form4().ShowDialog();
                //}
              

                if (radioButton3.Checked)
                {
                    if (checkBox2.CheckState == CheckState.Checked)
                    {
                        reportNames.Add("Report1.rdlc");
                        orderDetailList.Add(orderDetailId);
                    }
                    if (checkBox3.CheckState == CheckState.Checked)
                    {
                        reportNames.Add("Report2.rdlc");
                        orderDetailList.Add(orderDetailId);
                    }
                    if (checkBox4.CheckState == CheckState.Checked)
                    {
                        reportNames.Add("Report3.rdlc");
                        orderDetailList.Add(orderDetailId);
                    }
                    if (checkBox5.CheckState == CheckState.Checked)
                    {
                        reportNames.Add("Report4.rdlc");
                        orderDetailList.Add(orderDetailId);
                    }
                    if (checkBox6.CheckState == CheckState.Checked)
                    {
                        reportNames.Add("Report5.rdlc");
                        orderDetailList.Add(orderDetailId);
                    }
                    AllReports allreport = new AllReports(reportNames,orderDetailList);
                    allreport.setConfig(orderId);
                    allreport.ShowAllReport(reportNames.First(),orderDetailList.First());
                    allreport.ShowDialog();
                }
                else
                {
                    for (int i = 0; i < orderDetailIds.Count; i++)
                    {
                        reportNames.Add("Report1.rdlc");
                        orderDetailList.Add(orderDetailIds[i]);
                    
                    }
                    for (int i = 0; i < orderDetailIds.Count; i++)
                    {
                        reportNames.Add("Report2.rdlc");
                        orderDetailList.Add(orderDetailIds[i]);

                    }
                    for (int i = 0; i < orderDetailIds.Count; i++)
                    {
                        reportNames.Add("Report3.rdlc");
                        orderDetailList.Add(orderDetailIds[i]);

                    }
                    for (int i = 0; i < orderDetailIds.Count; i++)
                    {
                        reportNames.Add("Report4.rdlc");
                        orderDetailList.Add(orderDetailIds[i]);

                    }
                    for (int i = 0; i < orderDetailIds.Count; i++)
                    {
                        reportNames.Add("Report5.rdlc");
                        orderDetailList.Add(orderDetailIds[i]);

                    }

                    AllReports allreport = new AllReports(reportNames,orderDetailList);
                    allreport.setConfig(orderId);
                    allreport.ShowAllReport(reportNames.First(),orderDetailList.First());
                    allreport.ShowDialog();
                
                }

               

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
            if (checkBox1.Checked)
            {
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
        }



  
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                radioButton4.Checked = false; 
            else radioButton4.Checked = true;

        }

       

        }
    }

