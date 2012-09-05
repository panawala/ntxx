using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using EntityFrameworkTryBLL.ReportManager;

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
           
            var resultSet =FacilityBLL.getOrderDetail(2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Annon.Report.Report1.rdlc";

            var ordersInfo = FacilityBLL.getOrderInfo(1);

            ReportParameter rp = new ReportParameter("Latitute", "200m");
            ReportParameter rpTag = new ReportParameter("CustomerName", "ordersInfo.Customer");
            ReportParameter rpProjectName = new ReportParameter("ProjectName", ordersInfo.JobName);
            ReportParameter rpProjectNo = new ReportParameter("ProjectNo", ordersInfo.JobNum);
            ReportParameter rpSeller = new ReportParameter("AnnonContact", "ordersInfo.AAonCon");
            ReportParameter rpOrderDate = new ReportParameter("DealDate", ordersInfo.Activity);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp, rpTag, rpProjectName, rpProjectNo, rpSeller, rpOrderDate });

            //ReportParameter rp = new ReportParameter("content", this.textBox1.Text);
            //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet));
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
           
           

           

           
            
        }


        }
    }

