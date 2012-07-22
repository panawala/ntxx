using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityFrameworkTryBLL.ZutuManager;
using Model.Zutu;
using Annon.Zutu;

namespace Annon.Module_Detail
{
    public partial class ModuleDetail : Form
    {

        ImgItem imgitem_blankBox = new ImgItem();
        ImgItem imgitem_fanBox = new ImgItem();
        ImgItem imgitem_coil = new ImgItem();
        ImgItem imgitem_controlBox = new ImgItem();
        ImgItem imgitem_filter = new ImgItem();
        ImgItem imgitem_heat=new ImgItem();
        ImgItem imgitem_HRWheel = new ImgItem();
        ImgItem imgitem_MixingBox = new ImgItem();

        public ModuleDetail(List<ImageEntity> imageBoxList)
        {
            InitializeComponent();
            int i = 0;
            foreach (ImageEntity imgEntity in imageBoxList)
            {
                i++;
                if (i == 1)
                {
                    Image tempImage = Image.FromFile(imgEntity.Url);
                    Bitmap imageBitMap = new Bitmap(tempImage, 85, 110);
                    pictureBox1.Image = imageBitMap;
                    pictureBox1.Location = new Point(panel1.Width / 4, 10);
                    panel1.Controls.Add(pictureBox1);
                    pictureBox1.Tag= imgEntity.parentName;
          
                    Label firstLabel = new Label() ;
                    firstLabel.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + pictureBox1.Height + 2);
                    firstLabel.AutoSize = false;
                    firstLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    firstLabel.Width = 85;
                    firstLabel.Height = 50;
                    firstLabel.Text = imgEntity.Text;
                    panel1.Controls.Add(firstLabel);

                }
                if (i == 2)
                {
                    Image tempImage = Image.FromFile(imgEntity.Url);
                    Bitmap imageBitMap = new Bitmap(tempImage, 85, 110);
                    pictureBox2.Image = imageBitMap;
                    pictureBox2.Location = new Point(panel1.Width / 4, 170);
                    panel1.Controls.Add(pictureBox2);
                    pictureBox2.Tag = imgEntity.parentName;


                    Label firstLabel = new Label();
                    firstLabel.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + pictureBox2.Height + 2);
                    firstLabel.AutoSize = false;
                    firstLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    firstLabel.Width = 85;
                    firstLabel.Height = 50;
                    firstLabel.Text = imgEntity.Text;
                    panel1.Controls.Add(firstLabel);
                }
                if (i == 3)
                {
                    Image tempImage = Image.FromFile(imgEntity.Url);
                    Bitmap imageBitMap = new Bitmap(tempImage, 85, 110);
                    pictureBox3.Image = imageBitMap;
                    pictureBox3.Location = new Point(panel1.Width / 4, 330);
                    panel1.Controls.Add(pictureBox3);
                    pictureBox3.Tag = imgEntity.parentName;


                    Label firstLabel = new Label();
                    firstLabel.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y + pictureBox3.Height + 2);
                    firstLabel.AutoSize = false;
                    firstLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    firstLabel.Width = 85;
                    firstLabel.Height = 50;
                    firstLabel.Text = imgEntity.Text;
                    panel1.Controls.Add(firstLabel);
                }
                if (i == 4)
                {
                    Image tempImage = Image.FromFile(imgEntity.Url);
                    Bitmap imageBitMap = new Bitmap(tempImage, 85, 110);
                    pictureBox4.Image = imageBitMap;
                    pictureBox4.Location = new Point(panel1.Width / 4, 430);
                    panel1.Controls.Add(pictureBox3);


                    Label firstLabel = new Label();
                    firstLabel.Location = new Point(pictureBox4.Location.X, pictureBox4.Location.Y + pictureBox4.Height + 2);
                    firstLabel.AutoSize = false;
                    firstLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    firstLabel.Width = 85;
                    firstLabel.Height = 50;
                    firstLabel.Text = imgEntity.Text;
                    panel1.Controls.Add(firstLabel);
                }

                
            }


            
            //List<ImgItem> imgItems = new List<ImgItem>()
            //{
            //    //new ImgItem{CoolingPower=5,ModuleTag="101-133",ImgageName="HRA",OrderID=1},
            //    //new ImgItem{CoolingPower=5,ModuleTag="102-133",ImgageName="CBB",OrderID=1},
            //    new ImgItem{CoolingPower=5,ModuleTag="103-133",ImgageName="MBB",OrderID=1},
            //    new ImgItem{CoolingPower=5,ModuleTag="104-133",ImgageName="MBA",OrderID=1}
            //};
            //foreach (var imgItem in imgItems)
            //{
            //    ContentBLL.InitialImageOrder(imgItem.ModuleTag, imgItem.CoolingPower, imgItem.ImgageName, imgItem.OrderID);
            //}
            imgitem_blankBox.CoolingPower = 5;
            imgitem_blankBox.ModuleTag = "101-133";
            imgitem_blankBox.ImgageName = "BBA";
            imgitem_blankBox.OrderID = 1;
            imgitem_blankBox.Type = "Blank Box";

            imgitem_coil.CoolingPower = 5;
            imgitem_coil.ModuleTag = "101-133";
            imgitem_coil.ImgageName = "CBA";
            imgitem_coil.OrderID = 1;
            imgitem_coil.Type = "Coil";

            imgitem_controlBox.CoolingPower = 5;
            imgitem_controlBox.ModuleTag = "101-133";
            imgitem_controlBox.ImgageName = "TRB";
            imgitem_controlBox.OrderID = 1;
            imgitem_controlBox.Type = "Control Box";

            imgitem_fanBox.CoolingPower = 5;
            imgitem_fanBox.ModuleTag = "101-133";
            imgitem_fanBox.ImgageName = "PEA";
            imgitem_fanBox.OrderID = 1;
            imgitem_fanBox.Type = "Fan Box";

            imgitem_filter.CoolingPower = 5;
            imgitem_filter.ModuleTag = "101-133";
            imgitem_filter.ImgageName = "FTA";
            imgitem_filter.OrderID = 1;
            imgitem_filter.Type = "Filter";

            imgitem_heat.CoolingPower = 5;
            imgitem_heat.ModuleTag = "101-133";
            imgitem_heat.ImgageName = "PHA";
            imgitem_heat.OrderID = 1;
            imgitem_heat.Type = "Heat";

            imgitem_HRWheel.CoolingPower = 5;
            imgitem_HRWheel.ModuleTag = "101-133";
            imgitem_HRWheel.ImgageName = "HRA";
            imgitem_HRWheel.OrderID = 1;
            imgitem_HRWheel.Type = "HR Wheel";

            imgitem_MixingBox.CoolingPower = 5;
            imgitem_MixingBox.ModuleTag = "101-133";
            imgitem_MixingBox.ImgageName = "MBA";
            imgitem_MixingBox.OrderID = 1;
            imgitem_MixingBox.Type = "Mixing Box";

        }

        public void ImgClick(ImageEntity imgEntity)
        {
            switch (imgEntity.Type)
            {
                case "Blank Box":
                    imgitem_blankBox.CoolingPower = imgEntity.coolingType;
                    imgitem_blankBox.ImgageName = imgEntity.Name;
                    imgitem_blankBox.ModuleTag=imgEntity.moduleTag;
                    imgitem_blankBox.OrderID=imgEntity.orderId;
                    imgitem_blankBox.Type = imgEntity.parentName;
                    break;
                case "Coil":
                    imgitem_coil.CoolingPower = imgEntity.coolingType;
                    imgitem_coil.ImgageName = imgEntity.Name;
                    imgitem_coil.ModuleTag=imgEntity.moduleTag;
                    imgitem_coil.OrderID=imgEntity.orderId;
                    imgitem_coil.Type = imgEntity.parentName;
                    break;
                case "Control Box":
                    imgitem_controlBox.CoolingPower = imgEntity.coolingType;
                    imgitem_controlBox.ImgageName = imgEntity.Name;
                    imgitem_controlBox.ModuleTag = imgEntity.moduleTag;
                    imgitem_controlBox.OrderID = imgEntity.orderId;
                    imgitem_controlBox.Type = imgEntity.parentName;
                    break;
                case "Fan Box":
                    imgitem_fanBox.CoolingPower = imgEntity.coolingType;
                    imgitem_fanBox.ImgageName = imgEntity.Name;
                    imgitem_fanBox.ModuleTag = imgEntity.moduleTag;
                    imgitem_fanBox.OrderID = imgEntity.orderId;
                    imgitem_fanBox.Type = imgEntity.parentName;
                    break;
                case "Filter":
                    imgitem_filter.CoolingPower = imgEntity.coolingType;
                    imgitem_filter.ImgageName = imgEntity.Name;
                    imgitem_filter.ModuleTag = imgEntity.moduleTag;
                    imgitem_filter.OrderID = imgEntity.orderId;
                    imgitem_filter.Type = imgEntity.parentName;
                    break;
                case "Heat":
                    imgitem_heat.CoolingPower = imgEntity.coolingType;
                    imgitem_heat.ImgageName = imgEntity.Name;
                    imgitem_heat.ModuleTag = imgEntity.moduleTag;
                    imgitem_heat.OrderID = imgEntity.orderId;
                    imgitem_heat.Type = imgEntity.parentName;
                    break;
                case "HRWheel":
                    imgitem_HRWheel.CoolingPower = imgEntity.coolingType;
                    imgitem_HRWheel.ImgageName = imgEntity.Name;
                    imgitem_HRWheel.ModuleTag = imgEntity.moduleTag;
                    imgitem_HRWheel.OrderID = imgEntity.orderId;
                    imgitem_HRWheel.Type = imgEntity.parentName;
                    break;
                case "MixingBox":
                    imgitem_MixingBox.CoolingPower = imgEntity.coolingType;
                    imgitem_MixingBox.ImgageName = imgEntity.Name;
                    imgitem_MixingBox.ModuleTag = imgEntity.moduleTag;
                    imgitem_MixingBox.OrderID = imgEntity.orderId;
                    imgitem_MixingBox.Type = imgEntity.parentName;
                    break;
            }
        }
        //鼠标单击相应图标，依据关键字调用相应winform窗体       
         private void ImgClick(string type)
        {
            RightPinal.Controls.Clear();
            string ImgName = type;
            switch (ImgName)
            {
                case  "Blank Box":
                    BlankBox frmblankBox = new BlankBox();
                    frmblankBox.TopLevel = false;
                    frmblankBox.Parent = RightPinal;
                    frmblankBox.Dock = DockStyle.Fill;
                    frmblankBox.OveroadForm(imgitem_blankBox);//传递参数用
                    frmblankBox.InitialValue(imgitem_blankBox,0);//获取点击的图标，传递其唯一标识，并赋值
                    frmblankBox.Show();
                     break;
                case "Coil":
                     Coil frmCoil = new Coil();
                     frmCoil.TopLevel = false;
                     frmCoil.Parent = RightPinal;
                     frmCoil.Dock = DockStyle.Fill;
                     frmCoil.OveroadForm(imgitem_coil);
                     frmCoil.InitialValue(imgitem_coil,0);
                     frmCoil.Show();
                    break;
                case "Control Box":
                    ControlBox frmControlBox = new ControlBox();
                    frmControlBox.TopLevel = false;
                    frmControlBox.Parent = RightPinal;
                    frmControlBox.Dock = DockStyle.Fill;
                    frmControlBox.OveroadForm(imgitem_controlBox);
                    frmControlBox.InitialValue(imgitem_controlBox,0);
                    frmControlBox.Show();
                    break;
                case "Fan Box":
                    FanBox frmFanBox = new FanBox();
                    frmFanBox.TopLevel = false;
                    frmFanBox.Parent = RightPinal;
                    frmFanBox.Dock = DockStyle.Fill;
                    frmFanBox.OveroadForm(imgitem_fanBox);
                    frmFanBox.InitialValue(imgitem_fanBox,0);
                    frmFanBox.Show();
                    break;
                case "Filter":
                    Filter frmFilter = new Filter();
                    frmFilter.TopLevel = false;
                    frmFilter.Parent = RightPinal;
                    frmFilter.Dock = DockStyle.Fill;
                    frmFilter.OveroadForm(imgitem_filter);
                    frmFilter.InitialValue(imgitem_filter,0);
                    frmFilter.Show();
                    break;
                case "Heat":
                    Heat frmHeat = new Heat();
                    frmHeat.TopLevel = false;
                    frmHeat.Parent = RightPinal;
                    frmHeat.Dock = DockStyle.Fill;
                    frmHeat.OveroadForm(imgitem_heat);
                    frmHeat.InitialValue(imgitem_heat,0);
                    frmHeat.Show();
                    break;
                case "HRWheel":
                    HRWheel frmHRWheel = new HRWheel();
                    frmHRWheel.TopLevel = false;
                    frmHRWheel.Parent = RightPinal;
                    frmHRWheel.Dock = DockStyle.Fill;
                    frmHRWheel.OveroadForm(imgitem_HRWheel);
                    frmHRWheel.InitialValue(imgitem_HRWheel,0);
                    frmHRWheel.Show();
                    break;
                case "MixingBox":
                    MixingBox frmMixingBox = new MixingBox();
                    frmMixingBox.TopLevel = false;
                    frmMixingBox.Parent = RightPinal;
                    frmMixingBox.Dock = DockStyle.Fill;
                    frmMixingBox.OveroadForm(imgitem_MixingBox);
                    frmMixingBox.InitialValue(imgitem_MixingBox,0);//获取点击的图标，传递其唯一标识
                    frmMixingBox.Show();
                    break;

            }

        }
        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                ImgClick(pictureBox1.Tag.ToString());
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                ImgClick(pictureBox2.Tag.ToString());
            }
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox3.Image != null)
            {
                ImgClick(pictureBox3.Tag.ToString());
            }
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox4.Image != null)
            {
                ImgClick(pictureBox4.Tag.ToString());
            }
        }

        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox5.Image != null)
            {
                ImgClick(pictureBox5.Tag.ToString());
            }
        }

        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox6.Image != null)
            {
                ImgClick(pictureBox6.Tag.ToString());
            }
        }

        private void pictureBox7_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox7.Image != null)
            {
                ImgClick(pictureBox7.Tag.ToString());
            }
        }

        private void pictureBox8_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox8.Image != null)
            {
                ImgClick(pictureBox8.Tag.ToString());
            }
        }

        //根据父窗口选择的进入其设置界面
        private void ModuleDetail_Load(object sender, EventArgs e)
        {
            ImgClick(SelectedImge);
        }



        // 从父窗口传回数据
        int orderId;
        List<TransData> ImgList;
        static string SelectedImge = "";//暂时设定为定值，测试用，模块串通时，动态赋值
        public void GetImgList(int OrderID,List<TransData> imgList,string SelectedImgType)
        {
            orderId = OrderID;
            ImgList = imgList;
            SelectedImge = SelectedImgType;
        }

        private void RightPinal_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class TransData
    {
        public string ImageGroupName { get; set; }
        public string ImageName { get; set; }
        public string ImgType { get; set; }
    }
    public class ImgItem
    {
        public int CoolingPower { get; set; }
        public int OrderID { get; set; }
        public string ImgageName { get; set; }
        public string ModuleTag { get; set; }
        public string Type { get; set; }
        public string PropertyName { set; get; }
    }

}
