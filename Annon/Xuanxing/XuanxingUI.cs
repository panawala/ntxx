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

namespace Annon.Xuanxing
{
    public partial class XuanxingUI : Form
    {

        //string[] s1 = { "RM", "-", "015", "-", "3", "-", "0", "-", "A", "A", "0", "2", "-", "0", "0", "0", ":", "0", "0", "0", "0", "-", "0", "0", "0", "-", "0", "0", "0", "-", "0", "0", "0", "-", "0", "0", "0", "0", "0", "0", "0", "-", "0", "0", "-", "0", "0", "0","0","0","0","0","0","B" };
        //string[] s2 = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        //string[] s3 = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        //string[] s4 = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        //string[] s5 = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };


        Hashtable h1 = new Hashtable();
        Hashtable h2 = new Hashtable();
        Hashtable h3 = new Hashtable();//保存label的backcolor;
        Hashtable h4 = new Hashtable();//保存label的text内容;

        List<CatalogProperty> mdlist = new List<CatalogProperty>();
        List<CatalogPropertyValue> prolist = new List<CatalogPropertyValue>();

        public int ModelOptID;
        public string ModelPropertyName;
        public int PropID;

        public Label tmplb = new Label();


        public string ProCode;
        public string lbName;//datagridview2中保存上一次显示的label的text;

        public int OrderID;
        public List<CatalogModel> CatModelList=new List<CatalogModel>();
        public XuanxingUI(int ModOrder)
        {
            InitializeComponent();


            //for (int i = 0; i < 53; i++)
            //    h3.Add(CatModelList[i].Value, panel1.BackColor);
            //MoniXuanxing();
            

            OrderID = ModOrder;
        }

        //动态生成label;
        //private void LabelProduct(string[] s)
        //{
        //    panel1.Controls.Clear();
        //    int labelwidth = panel1.Width/54;
        //    int j = 0;
        //    for (int i = 0; i < 54; i++)
        //    {
        //        Label lab = new Label();
        //        lab.Anchor = AnchorStyles.Right|AnchorStyles.Left | AnchorStyles.Bottom|AnchorStyles.Top;
        //        lab.Text = s[i];
        //        lab.TextAlign = ContentAlignment.MiddleCenter;
        //        lab.Size = new Size(labelwidth, labelwidth);
        //        lab.Location = new Point(i*labelwidth+labelwidth,labelwidth-10);
        //        panel1.Controls.Add(lab);
        //        if (s[i] != "-" && s[i] != ":")
        //        {
        //            lab.Name = "lab" + j;
        //            lab.Click += new EventHandler(lab_Click);
        //            if (j < 10)
        //            {
        //                //h1.Add(ss[j], lab);
        //                //h2.Add(lab.Name, ss[j]);
        //                //lab.BackColor = (Color)h3[ss[j]];
        //                //h4.Add(lab, s[i]);
        //            }
        //            j++;

        //        }
        //    }
        //}

        private void LabelProduct(List<CatalogModel> CatList)
        {
            panel1.Controls.Clear();
            h1.Clear();
            h2.Clear();
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
                
                h1.Add(CatList[j].PropertyName, lab);
                h2.Add(lab.Name, CatList[j].PropertyName);
                if (!h3.ContainsKey(CatList[j].PropertyName))
                    h3.Add(CatList[j].PropertyName, panel1.BackColor);
                j++;
                lab.TextAlign = ContentAlignment.MiddleCenter;
                lab.Location = new Point(i * labelwidth + labelwidth, labelwidth-10);
                panel1.Controls.Add(lab);
            }

        }
        //void lab_Click(object sender, EventArgs e)
        //{
        //    Label label = sender as Label;
        //    tmplb.BackColor = Color.Red;
        //    label.BackColor = Color.Yellow;
        //    tmplb = label;
        //    string str = h2[label.Name].ToString();
        //    List<ModelOptions> modellist = new List<ModelOptions>();
        //    List<Property> PropertyList = new List<Property>();

        //    foreach (var md in mdlist)
        //    {
        //        if (md.ModelOptionsName == str)
        //        {
        //            foreach (var pro in prolist)
        //            {
        //                if (pro.ModelID == md.ModelOptionsID)
        //                {
        //                    PropertyList.Add(pro);
        //                }
        //            }
        //        }
        //    }
        //    dataGridView2.DataSource = PropertyList;
        //}

        private void XuanxingUI_Load(object sender, EventArgs e)
        {
            CatModelList = CatalogBLL.getInitialLabels(1, OrderID);//得到标签的属性;
            LabelProduct(CatModelList);
            mdlist = CatalogBLL.getProperties(1);
            dataGridView1.DataSource = mdlist;
            //dataGridView2.DataSource = prolist;

            
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                List<CatalogModel> mol = new List<CatalogModel>();
 
                //tmplb.Text = lbName;
                //tmplb.BackColor = panel1.BackColor;
                Label tlb = new Label();
               
                ModelPropertyName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                tlb = (Label)h1[ModelPropertyName];
                tlb.BackColor = Color.Yellow;

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
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                
                ProCode = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                CatalogBLL.saveOrder(1, OrderID, ModelPropertyName, ProCode);

                var RedList = CatalogBLL.getAllByCondition(ModelPropertyName, OrderID, 1);

                foreach (var mol in CatModelList)
                {
                    if (mol.PropertyName == ModelPropertyName)
                    {
                        ((Label)h1[mol.PropertyName]).Text = ProCode;
                        h3[mol.PropertyName] = Color.Yellow;
                    }

                    if (RedList.Select(s => s.PropertyName).Contains(mol.PropertyName))
                    {
                        ((Label)h1[mol.PropertyName]).Text = mol.Value;
                        h3[mol.PropertyName] = Color.Red;
                    }
                    else
                    {
                        h3[mol.PropertyName] = panel1.BackColor;
                    }
                    ((Label)h1[mol.PropertyName]).BackColor = (Color)h3[mol.PropertyName];

                }

            }
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            LabelProduct(CatModelList);
        }


    }
}
