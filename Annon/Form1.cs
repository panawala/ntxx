using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityFrameworkTryBLL.XuanxingManager;
using Model.Xuanxing;
using System.Collections;
using Annon.Xuanxing;
using Annon.Zutu;


namespace Annon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CatalogBLL.saveOrder(1, 35, "制冷形式", "0");
            //CatalogBLL.saveOrder(1, 35, "电压", "3");
            //CatalogBLL.saveOrder(1, 35, "制冷组合", "0");


            //int orderid = 35;
            //CatalogBLL.saveOrder(1, orderid, "制冷形式", "E");

            ////CatalogBLL.saveOrder(1, 4, "水冷冷凝器选项", "A");

            //List<CatalogModel> temp = new List<CatalogModel>();
            //temp = CatalogBLL.getAllByCon("制冷形式", orderid, 1);

            //ErrorDSF clObject = new ErrorDSF();
            //CatalogModel tempMod = new CatalogModel();

            //tempMod.PropertyName = "制冷形式";
            //tempMod.Value = "E";
            //tempMod.IsSelected = true;
            //clObject.savecatalogModel.Add(tempMod);
            
            //clObject.Traverse(temp, orderid, 1, "Root");
            //ArrayList test = new ArrayList();
            
            //test = clObject.errorArr;
            //test.Add(tempMod.PropertyName + tempMod.Value);
            (new AAonRating()).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new Form2()).Show();
        }
    }
}
