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
                ImgClick("Blank Box");
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                ImgClick("Coil");
            }
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox3.Image != null)
            {
                ImgClick("Control Box");
            }
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox4.Image != null)
            {
                ImgClick("Fan Box");
            }
        }

        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox5.Image != null)
            {
                ImgClick("Filter");
            }
        }

        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox6.Image != null)
            {
                ImgClick("Heat");
            }
        }

        private void pictureBox7_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox7.Image != null)
            {
                ImgClick("HRWheel");
            }
        }

        private void pictureBox8_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox8.Image != null)
            {
                ImgClick("MixingBox");
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
        static string SelectedImge = "Blank Box";//暂时设定为定值，测试用，模块串通时，动态赋值
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
    }

}
