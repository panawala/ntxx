using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Annon.Report
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList n = new ArrayList();
            List<Facility2> orderList1 = new List<Facility2> { 
            new Facility2(){
           Type="A",
           Option="aad",
           Code="dfd",
           Describe="df",
           StandPrice=12,
           AgentPrice=21,
           ClientPrice=232
            },
            new Facility2(){
           Type="A",
           Option="aad",
           Code="dfd",
           Describe="df",
           StandPrice=12,
           AgentPrice=21,
           ClientPrice=232
            },
            new Facility2(){
           Type="A",
           Option="aad",
           Code="dfd",
           Describe="df",
           StandPrice=12,
           AgentPrice=21,
           ClientPrice=232
            }
           };
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
            n.Add(orderList1);
            //n.Add(orderList);
            PrintReport PR = new PrintReport();
            PR.StartPrint(n);
        }
    }
}
