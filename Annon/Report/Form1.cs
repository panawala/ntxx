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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“northwindDataSet.Customers”中。您可以根据需要移动或删除它。
         

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            List<Order> orderList = new List<Order> { 
            new Order(){
            OrderId=1,
            OrderCount=2,
            OrderDescription="hello",
            OrderPrice=123,
            OrderTag="tag"
            },
            new Order(){
            OrderId=2,
            OrderCount=2,
            OrderDescription="hello",
            OrderPrice=123,
            OrderTag="tag"
            },
            new Order(){
            OrderId=3,
            OrderCount=2,
            OrderDescription="hello",
            OrderPrice=123,
            OrderTag="tag"
            },
            new Order(){
            OrderId=4,
            OrderCount=2,
            OrderDescription="hello",
            OrderPrice=123,
            OrderTag="tag"
            }
            };
            var resultSet = orderList;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Annon.Report.Report2.rdlc";
            //ReportParameter rp = new ReportParameter("content", this.textBox1.Text);
            //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet_Order", resultSet));
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
           
           

           

           
            
        }


        }
    }

