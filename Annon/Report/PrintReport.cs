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
              "  <PageWidth>8.5in</PageWidth>" +
              "  <PageHeight>11in</PageHeight>" +
              "  <MarginTop>0.25in</MarginTop>" +
              "  <MarginLeft>0.25in</MarginLeft>" +
              "  <MarginRight>0.25in</MarginRight>" +
              "  <MarginBottom>0.25in</MarginBottom>" +
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
        public void StartPrint(ArrayList dataSourceList)
        {
            m_streams = new List<Stream>();
            LocalReport report = new LocalReport();
            
            foreach (string ReportName in dataSourceList)
            {
                switch (ReportName)
                {
                    case "Report1":
                        report.ReportPath = @"..\..\Report\Report1.rdlc";
                        //report.DataSources.Add(new ReportDataSource("DataSet1", dataSource1))
                        break;
                    case"Report2":
                        report.ReportPath = @"..\..\Report\Report2.rdlc";
                    //report.DataSources.Add(new ReportDataSource("DataSet1", dataSource2))
                        break;
                    case "Report3":
                        report.ReportPath = @"..\..\Report\Report3.rdlc";
                        //report.DataSources.Add(new ReportDataSource("DataSet1", dataSource3))
                        break;
                    case "Report4":
                        report.ReportPath = @"..\..\Report\Report4.rdlc";
                        //report.DataSources.Add(new ReportDataSource("DataSet1", dataSource4))
                        break;
                    case "Report5":
                        report.ReportPath = @"..\..\Report\Report5.rdlc";
                        //report.DataSources.Add(new ReportDataSource("DataSet1", dataSource5))
                        break;
                    case "Report6":
                        report.ReportPath = @"..\..\Report\Report6.rdlc";
                        //report.DataSources.Add(new ReportDataSource("DataSet1", dataSource6))
                        break;
                    case "Report7":
                        report.ReportPath = @"..\..\Report\Report7.rdlc";
                        //report.DataSources.Add(new ReportDataSource("DataSet1", dataSource7))
                        break;
                    case "Report8":
                        report.ReportPath = @"..\..\Report\Report8.rdlc";
                        //report.DataSources.Add(new ReportDataSource("DataSet1", dataSource8))
                        break;
                    case "Report9":
                        report.ReportPath = @"..\..\Report\Report9.rdlc";
                        //report.DataSources.Add(new ReportDataSource("DataSet1", dataSource9))
                        break;
                    case "Report10":
                        report.ReportPath = @"..\..\Report\Report10.rdlc";
                        //report.DataSources.Add(new ReportDataSource("DataSet1", dataSource10))
                        break;
                    case "Report11":
                        report.ReportPath = @"..\..\Report\Report11.rdlc";
                        //report.DataSources.Add(new ReportDataSource("DataSet1", dataSource11))
                        break;
                    case "Report12":
                        report.ReportPath = @"..\..\Report\Report12.rdlc";
                        //report.DataSources.Add(new ReportDataSource("DataSet1", dataSource12))
                        break;
                }
                //将报表原始数据输出，并进行转换
                Export(report);
            }            
            m_currentPageIndex = 0;
            Print();
        }
    }
}
