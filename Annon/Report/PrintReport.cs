using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Reporting.WinForms;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Collections;
using EntityFrameworkTryBLL.ReportManager;

namespace Annon.Report
{
    class PrintReport
    {
        private int m_currentPageIndex;
        //用于记录打印报表图像流
        private IList<Stream> m_streams;
        //生成图像流
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding,string mimeType, bool willSeek)
        {
            Stream stream = new FileStream(name + "." + fileNameExtension, FileMode.Create);
            m_streams.Add(stream);
            return stream;
        }
        //设置打印数据
        private void Export(LocalReport report)
        {
            string deviceInfo =
              "<DeviceInfo>" +
              "  <OutputFormat>EMF</OutputFormat>" +
              "  <PageWidth>21cm</PageWidth>" +
              "  <PageHeight>29.7cm</PageHeight>" +
              "  <MarginTop>2.5cm</MarginTop>" +
              "  <MarginLeft>2.5cm</MarginLeft>" +
              "  <MarginRight>2.5cm</MarginRight>" +
              "  <MarginBottom>2.5cm</MarginBottom>" +
              "</DeviceInfo>";
            Warning[] warnings;
            try
            {
                report.Render("Image", deviceInfo, CreateStream, out warnings);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }

            foreach (Stream stream in m_streams)
            {
                stream.Position = 0;
            }
        }
        //将图像流文件转换为图像文件，并计算打印页
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, 0, 0);

            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }
        //打印报表
        private void Print()
        {
            const string printerName = "Microsoft Office Document Image Writer";

            if (m_streams == null || m_streams.Count == 0)
                return;

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;
            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = String.Format("Can't find printer \"{0}\".", printerName);
                MessageBox.Show(msg);
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.Print();
        }
        //为打印报表准备数据
        public void StartPrint(string ReportName)
        {
            m_streams = new List<Stream>();
            LocalReport report = new LocalReport();
            
            //foreach (string ReportName in dataSourceList)
            //{
                switch (ReportName)
                {
                    case "Report1.rdlc":
                        {
                            var resultSet = FacilityBLL.getOrderDetail(2);
                            report.ReportEmbeddedResource = "Annon.Report.Report1.rdlc";
                            var ordersInfo = FacilityBLL.getOrderInfo(1);
                            ReportParameter rp = new ReportParameter("Latitute", "200m");
                            ReportParameter rpTag = new ReportParameter("CustomerName", "ordersInfo.Customer");
                            ReportParameter rpProjectName = new ReportParameter("ProjectName", ordersInfo.JobName);
                            ReportParameter rpProjectNo = new ReportParameter("ProjectNo", ordersInfo.JobNum);
                            ReportParameter rpSeller = new ReportParameter("AnnonContact", "ordersInfo.AAonCon");
                            ReportParameter rpOrderDate = new ReportParameter("DealDate", ordersInfo.Activity);
                            report.SetParameters(new ReportParameter[] { rp, rpTag, rpProjectName, rpProjectNo, rpSeller, rpOrderDate });
                            report.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet));
                        }
                        break;
                    case "Report2.rdlc":
                        {
                            var resultSet2 = FacilityBLL.getOrderDetail(2);
                            report.ReportEmbeddedResource = "Annon.Report.Report2.rdlc";
                            var ordersInfo = FacilityBLL.getOrderInfo(1);
                            ReportParameter rp = new ReportParameter("Latitute", "200m");
                            ReportParameter rpTag = new ReportParameter("CustomerName", "ordersInfo.Customer");
                            ReportParameter rpProjectName = new ReportParameter("ProjectName", ordersInfo.JobName);
                            ReportParameter rpProjectNo = new ReportParameter("ProjectNo", ordersInfo.JobNum);
                            ReportParameter rpSeller = new ReportParameter("AnnonContact", "ordersInfo.AAonCon");
                            ReportParameter rpOrderDate = new ReportParameter("DealDate", ordersInfo.Activity);
                            report.SetParameters(new ReportParameter[] { rp, rpTag, rpProjectName, rpProjectNo, rpSeller, rpOrderDate });
                            report.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet2));
                        }
                        break;
                    case "Report3.rdlc":
                        {

                            var resultSet = FacilityBLL.getFacility(1, 1, "model");
                            var resultSet1 = FacilityBLL.getFacility(1, 1, "feature");
                            var productDescription = FacilityBLL.getDescription(1);
                            var ordersInfo = FacilityBLL.getOrderInfo(1);

                            report.ReportEmbeddedResource = "Annon.Report.Report3.rdlc";
                            ReportParameter rp = new ReportParameter("ProductDescription", "6ERM-" + productDescription);
                            ReportParameter rpTag = new ReportParameter("AnnonContact", "Annon.contact");
                            ReportParameter rpProjectName = new ReportParameter("ProjectName", ordersInfo.JobName);
                            ReportParameter rpProjectNo = new ReportParameter("ProjectNo", ordersInfo.JobNum);
                            ReportParameter rpOrderDate = new ReportParameter("OrderDate", ordersInfo.Activity);
                            report.SetParameters(new ReportParameter[] { rp, rpTag, rpProjectName, rpProjectNo, rpOrderDate });
                            report.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet));
                            report.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", resultSet1));
                        }
                        break;
                    case "Report4.rdlc":
                        {
                            var resultSet = FacilityBLL.getFacility(1, 1, "model");
                            var resultSet1 = FacilityBLL.getFacility(1, 1, "feature");
                            var productDescription = FacilityBLL.getDescription(1);
                            var ordersInfo = FacilityBLL.getOrderInfo(1);

                            report.ReportEmbeddedResource = "Annon.Report.Report4.rdlc";
                            ReportParameter rp = new ReportParameter("ProductDescription", "6ERM-" + productDescription);
                            ReportParameter rpTag = new ReportParameter("Tag", "6ERM");
                            ReportParameter rpProjectName = new ReportParameter("ProjectName", ordersInfo.JobName);
                            ReportParameter rpProjectNo = new ReportParameter("ProjectNo", ordersInfo.JobNum);
                            ReportParameter rpSeller = new ReportParameter("Seller", "ordersInfo.AAonCon");
                            ReportParameter rpOrderDate = new ReportParameter("OrderDate", ordersInfo.Activity);
                            report.SetParameters(new ReportParameter[] { rp, rpTag, rpProjectName, rpProjectNo, rpSeller, rpOrderDate });
                            report.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet));
                            report.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", resultSet1));
                        }
                        break;
                    case "Report5.rdlc":
                        {
                            var resultSet = FacilityBLL.getOrderDetail(1);
                            report.ReportEmbeddedResource = "Annon.Report.Report5.rdlc";
                            report.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                            report.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", resultSet));
                        }
                        break;
                }
                //将报表原始数据输出，并进行转换
                Export(report);
            //}            
            m_currentPageIndex = 0;
            Print();
        }
        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            var orderDetail = FacilityBLL.getOrderDetail(2);
            e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet_OrderDetail", orderDetail));
            var orderInformation = FacilityBLL.getOrderInformation(1);
            e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", orderInformation));
        }
    }
}
