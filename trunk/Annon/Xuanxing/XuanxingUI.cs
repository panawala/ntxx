using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityFrameworkTryBLL.XuanxingManager;
using Model.Xuanxing;
using EntityFrameworkTryBLL.OrderManager;
using Model.Order;

namespace Annon.Xuanxing
{
    public partial class XuanxingUI : Form
    {
        
        public Hashtable h1 = new Hashtable();
        public Hashtable h2 = new Hashtable();
        public Hashtable h3 = new Hashtable();//保存label的backcolor;
        public Hashtable h4 = new Hashtable();//保存label对应的类型，用于model和featrues之间的切换

        List<CatalogProperty> mdlist = new List<CatalogProperty>();
        List<CatalogPropertyValue> prolist = new List<CatalogPropertyValue>();

        public int ModelOptID;
        public string ModelPropertyName;
        public int PropID;

        public Label tmplb = new Label();


        public string ProCode;
        public string lbName;//datagridview2中保存上一次显示的label的text

        public int OrderID;
        public List<CatalogModel> CatModelList=new List<CatalogModel>();

        public string ModelOrderInfo;

        public XuanxingUI(int ModOrder)
        {
            InitializeComponent();
            OrderID = ModOrder;
            
        }

        
        //动态生成
        private void LabelProduct(List<CatalogModel> CatList)
        {
            panel1.Controls.Clear();
            h1.Clear();
            h2.Clear();
            h4.Clear();
            int labelwidth = panel1.Width / 53;
            int j = 0;
            for (int i = 0; i < 53; i++)
            {
                Label lab = new Label();
                lab.Name = "lab" + i;
                lab.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
                lab.Size = new Size(labelwidth, labelwidth);
                if (i == 1 || i == 3 || i == 5 || i == 7 || i == 12 || i == 21 || i == 25 || i == 29 || i == 33 || i == 41 || i == 44)
                {
                    lab.Text = "-";
                    lab.TextAlign = ContentAlignment.MiddleCenter;
                    lab.Location = new Point(i * labelwidth + labelwidth, labelwidth - 10);
                    panel1.Controls.Add(lab);
                    continue;
                }
                if (i == 16)
                {
                    lab.Text = ":";
                    lab.TextAlign = ContentAlignment.MiddleCenter;
                    lab.Location = new Point(i * labelwidth + labelwidth, labelwidth - 10);
                    panel1.Controls.Add(lab);
                    continue;
                }
                
                lab.Text = CatList[j].Value ; 
                lab.TextAlign = ContentAlignment.MiddleCenter;
                lab.Location = new Point(i * labelwidth + labelwidth, labelwidth-10);
                
                h1.Add(CatList[j].PropertyName, lab);
                h2.Add(lab.Name, CatList[j].PropertyName);
                h4.Add(lab.Name,CatList[j].Type);

                //h3初始化;
                if (!h3.ContainsKey(CatList[j].PropertyName))
                    h3.Add(CatList[j].PropertyName, panel1.BackColor);
                lab.BackColor = (Color)h3[CatList[j].PropertyName];
                j++;

                lab.Click+=new EventHandler(lab_Click);
                panel1.Controls.Add(lab);
            }

        }
        //处理Label点击事件;
        void lab_Click(object sender, EventArgs e)
        {
            Label label= sender as Label;
            List<CatalogPropertyValue> LL = new List<CatalogPropertyValue>();
            string namestr = h2[label.Name].ToString();
            string typestr = h4[label.Name].ToString();
            ModelPropertyName = namestr;
            string textstr = label.Text;

            if (typestr == "model")
            {
                mdlist = CatalogBLL.getProperties(1, "model");
                dataGridView1.DataSource = mdlist;
            }
            if (typestr == "feature")
            {
                mdlist = CatalogBLL.getProperties(1, "feature");
                dataGridView1.DataSource = mdlist;

            }
            //datagridview1选中行效果
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (namestr == row.Cells[1].Value.ToString())
                    row.Selected = true;
            }

            LL = CatalogBLL.getAvaliableOptions(namestr, OrderID, 1);
            dataGridView2.DataSource = LL;
            
            //datagridview2 选中行效果；
            foreach(DataGridViewRow row in dataGridView2.Rows)
            {
                if (textstr == row.Cells[0].Value.ToString())
                    row.Selected = true;
            }

            foreach (var colhash in CatModelList)
            {
                if (colhash.PropertyName == namestr)
                    h3[colhash.PropertyName] = Color.Yellow;
                else
                    h3[colhash.PropertyName] = panel1.BackColor;
                ((Label)h1[colhash.PropertyName]).BackColor = (Color)h3[colhash.PropertyName];
            }


        }

        private void XuanxingUI_Load(object sender, EventArgs e)
        {
            CatModelList = CatalogBLL.getInitialLabels(1, OrderID);//得到标签的属性;
            LabelProduct(CatModelList);
            mdlist = CatalogBLL.getProperties(1,"model");
            dataGridView1.DataSource = mdlist;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;

            string name = dataGridView1.Rows[0].Cells[1].Value.ToString();
            ModelPropertyName = name;
            Label label = (Label)h1[name];
            label.BackColor = Color.Yellow;
            foreach (var colhash in CatModelList)
            {
                if (colhash.PropertyName == name)
                    h3[colhash.PropertyName] = Color.Yellow;
                else
                    h3[colhash.PropertyName] = panel1.BackColor;
                ((Label)h1[colhash.PropertyName]).BackColor = (Color)h3[colhash.PropertyName];
            }

            prolist = CatalogBLL.getAvaliableOptions(name, OrderID, 1);
            dataGridView2.DataSource = prolist;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (label.Text == row.Cells[0].Value.ToString())
                    row.Selected = true;
            }

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                List<CatalogModel> mol = new List<CatalogModel>();
                
                Label tlb = new Label();
                ModelPropertyName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                tlb = (Label)h1[ModelPropertyName];
                tlb.BackColor = Color.Yellow;
                string textstr1 = tlb.Text;
  

                //还原Label的颜色；
                foreach (var colhash in CatModelList)
                {
                    if (colhash.PropertyName == ModelPropertyName)
                        h3[colhash.PropertyName] = Color.Yellow;
                    else
                        h3[colhash.PropertyName] = panel1.BackColor;
                    ((Label)h1[colhash.PropertyName]).BackColor = (Color)h3[colhash.PropertyName];
                }

                prolist = CatalogBLL.getAvaliableOptions(ModelPropertyName,OrderID,1);
                dataGridView2.DataSource = prolist;

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (textstr1 == row.Cells[0].Value.ToString())
                        row.Selected = true;
                }
            }
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            LabelProduct(CatModelList);
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                decimal price = (decimal)dataGridView2.Rows[e.RowIndex].Cells[2].Value;
                ProCode = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                CatalogBLL.saveOrder(1, OrderID, ModelPropertyName, ProCode,price);
                

                var RedList = CatalogBLL.getAllByCondition(ModelPropertyName, OrderID, 1);
                foreach (var mol in CatModelList)
                {
                    h3[mol.PropertyName] = panel1.BackColor;
                    if (mol.PropertyName == ModelPropertyName)
                    {
                        ((Label)h1[mol.PropertyName]).Text = ProCode;
                        h3[mol.PropertyName] = Color.Yellow;
                    }

                    if (RedList != null)
                    {
                        if (RedList.Select(s => s.PropertyName).Contains(mol.PropertyName))
                        {
                            ((Label)h1[mol.PropertyName]).Text = RedList
                                .Where(s => s.PropertyName==mol.PropertyName)
                                .First()
                                .Value;
                            h3[mol.PropertyName] = Color.Red;
                        }
                    }

                    ((Label)h1[mol.PropertyName]).BackColor = (Color)h3[mol.PropertyName];

                }

            }
        }
        //完成订单填写,OK保存Label信息
        private void button2_Click(object sender, EventArgs e)
        {

            List<orderDetailInfo> OdDtl = new List<orderDetailInfo>();
            
         
            int i = 0;
            foreach (var modlist in CatModelList)
            {
                if (i == 1 || i == 3 || i == 5 || i == 7 || i == 12 || i == 21 || i == 25 || i == 29 || i == 33 || i == 41 || i == 44)
                {
                    ModelOrderInfo += "-";
                }
                if (i == 16)
                    ModelOrderInfo += ":";

                Label label = new Label();
                label = (Label)h1[modlist.PropertyName];
                ModelOrderInfo += label.Text;
                i++;    
            }

            //增加订单详情
            if (AAonRating.aaon.AddOrderDetail)
            {
                OdDtl = OrderDetailBLL.GetOrderDetail(AAonRating.aaon.RowIndex);
                AAonRating.aaon.OrderDtlRowNo = OdDtl.Last().OdDetlNum + 1;
                if (OrderDetailBLL.InsertOD1(AAonRating.aaon.OrderDtlRowNo, AAonRating.aaon.RowIndex, OrderID, ModelOrderInfo, tb_qty.Text,1,AAonRating.aaon.DeviceID) != -1)
                {
                    OdDtl = OrderDetailBLL.GetOrderDetail(AAonRating.aaon.RowIndex);
                    AAonRating.aaon.dataGridView2.DataSource = OdDtl;
                    CatalogBLL.copyCurrentToOrder(OrderID, 1);
                    //AAonRating.aaon.OrderDtlRowNo = OdDtl.Last().OdDetlNum + 1 ;
                    this.Close();
                }
            }

            //修改订单详情
            else
            {

                if (OrderDetailBLL.EditOD(AAonRating.aaon.RowIndex, AAonRating.aaon.RowIndexDGV2, ModelOrderInfo, tb_qty.Text) != -1)
                {
                    OdDtl = OrderDetailBLL.GetOrderDetail(AAonRating.aaon.RowIndex);
                    AAonRating.aaon.dataGridView2.DataSource = OdDtl;
                    AAonRating.aaon.AddOrderDetail = true;
                    CatalogBLL.copyCurrentToOrder(OrderID, 1);
                    this.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Model_Click(object sender, EventArgs e)
        {
            mdlist = CatalogBLL.getProperties(1, "model");
            dataGridView1.DataSource = mdlist;

            string name = dataGridView1.Rows[0].Cells[1].Value.ToString();
            ModelPropertyName = name;
            Label label = (Label)h1[name];
            label.BackColor = Color.Yellow;

            foreach (var colhash in CatModelList)
            {
                if (colhash.PropertyName == name)
                    h3[colhash.PropertyName] = Color.Yellow;
                else
                    h3[colhash.PropertyName] = panel1.BackColor;
                ((Label)h1[colhash.PropertyName]).BackColor = (Color)h3[colhash.PropertyName];
            }

            prolist = CatalogBLL.getAvaliableOptions(name, OrderID, 1);
            dataGridView2.DataSource = prolist;

            //datagridview2 选中行效果；
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (label.Text == row.Cells[0].Value.ToString())
                    row.Selected = true;
            }
        }

        private void btn_features_Click(object sender, EventArgs e)
        {
            mdlist = CatalogBLL.getProperties(1, "feature");
            dataGridView1.DataSource = mdlist;

            string name = dataGridView1.Rows[0].Cells[1].Value.ToString();
            ModelPropertyName = name;
            Label label = new Label();
            label.BackColor = Color.Yellow;

            foreach (var colhash in CatModelList)
            {
                if (colhash.PropertyName == name)
                    h3[colhash.PropertyName] = Color.Yellow;
                else
                    h3[colhash.PropertyName] = panel1.BackColor;
                ((Label)h1[colhash.PropertyName]).BackColor = (Color)h3[colhash.PropertyName];
            }

            prolist = CatalogBLL.getAvaliableOptions(name, OrderID, 1);
            dataGridView2.DataSource = prolist;
        }


    }
}
