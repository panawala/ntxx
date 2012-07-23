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
using Model.Zutu.ImageModel;
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
        ImgItem imgitem_heat = new ImgItem();
        ImgItem imgitem_HRWheel = new ImgItem();
        ImgItem imgitem_MixingBox = new ImgItem();
        List<ImageModel> imageModelist = new List<ImageModel>();
        public ModuleDetail(List<ImageModel> imageModelList)
        {
            for (int i = 0; i < imageModelList.Count; i++)
            {
                if (imageModelList.ElementAt(i).Name.Equals("virtualHRA"))
                {
                    imageModelList.RemoveAt(i);
                    break;
                }
            }
            List<Label> storeLabel=new List<Label>();
            this.imageModelist = imageModelList;
            InitializeComponent();
            ContentBLL.deleteOrder(imageModelist.First().OrderId);
                for (int i = 0; i < imageModelist.Count; i++)
                {                    
                    ImageModel imgEntity = imageModelist.ElementAt(i);
                        ContentBLL.InitialImageOrder(imgEntity.ModuleTag, imgEntity.coolingType, imgEntity.Name, imgEntity.OrderId);
                        if (i == 0)
                        {
                            Image tempImage = Image.FromFile(imgEntity.Url);
                            Bitmap imageBitMap = new Bitmap(tempImage, 85, 110);
                            PictureBox firstPb = new PictureBox();
                            firstPb.Width = 85;
                            firstPb.Height = 110;
                            firstPb.Image = imageBitMap;
                            firstPb.Name = imgEntity.ModuleTag + "" + imgEntity.Name;
                            firstPb.Location = new Point(panel1.Width / 4, 10);

                                panel1.Controls.Add(firstPb);
                           
                            Label firstLabel = new Label();
                            firstLabel.Location = new Point(firstPb.Location.X, firstPb.Location.Y + firstPb.Height + 2);
                            firstLabel.AutoSize = false;
                            firstLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            firstLabel.Width = 85;
                            firstLabel.Height = 50;
                            firstLabel.Text = imgEntity.Text;
                            panel1.Controls.Add(firstLabel);

                                storeLabel.Add(firstLabel);
                           

                            //PictrueBox注册事件
                            firstPb.Click += new EventHandler(firstPb_Click);

                        }
                        else
                        {
                            ImageModel beforimgEntity = imageModelist.ElementAt(i - 1);
                            ImageModel nowimgEntity = imageModelist.ElementAt(i);
                            PictureBox nextPb = new PictureBox();
                            nextPb.Width = 85;
                            nextPb.Height = 110;
                            nextPb.Name = nowimgEntity.ModuleTag + "" + nowimgEntity.Name;
                            Image picImage = Image.FromFile(nowimgEntity.Url);
                            nextPb.Image = new Bitmap(picImage, 85, 110);
                            Label beforLabel = storeLabel[i - 1];
                            nextPb.Location = new Point(beforLabel.Location.X, beforLabel.Location.Y + beforLabel.Height + 2);
                            panel1.Controls.Add(nextPb);

                            Label nextLabel = new Label();
                            nextLabel.Text = imageModelist.ElementAt(i).Text;
                            nextLabel.Height = 50;
                            nextLabel.Width = 80;
                            nextLabel.Location = new Point(nextPb.Location.X, nextPb.Location.Y + nextPb.Height + 2);
                            storeLabel.Add(nextLabel);
                            panel1.Controls.Add(nextLabel);
                            nextPb.Click += new EventHandler(nextPb_Click);

                        }
                   
                }
                
                    
        }
        void nextPb_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            ImageModel imgEntity = getImageModel(pb.Name, imageModelist);
             RightPinal.Controls.Clear();
             switch (imgEntity.ParentName)
             {
                 case "Blank Box":
                     imgitem_blankBox.CoolingPower = imgEntity.coolingType;
                     imgitem_blankBox.OrderID = imgEntity.OrderId;
                     imgitem_blankBox.ModuleTag = imgEntity.ModuleTag;
                     imgitem_blankBox.Type = imgEntity.ParentName;
                     imgitem_blankBox.ImgageName = imgEntity.Name;
                     BlankBox frmblankBox = new BlankBox();
                     frmblankBox.TopLevel = false;
                     frmblankBox.Parent = RightPinal;
                     frmblankBox.Dock = DockStyle.Fill;
                     frmblankBox.OveroadForm(imgitem_blankBox);//传递参数用
                     frmblankBox.InitialValue(imgitem_blankBox, 0);//获取点击的图标，传递其唯一标识，并赋值
                     frmblankBox.Show();
                     break;
                 case "Coil":
                     imgitem_coil.CoolingPower = imgEntity.coolingType;
                     imgitem_coil.OrderID = imgEntity.OrderId;
                     imgitem_coil.ModuleTag = imgEntity.ModuleTag;
                     imgitem_coil.Type = imgEntity.ParentName;
                     imgitem_coil.ImgageName = imgEntity.Name;
                     Coil frmCoil = new Coil();
                     frmCoil.TopLevel = false;
                     frmCoil.Parent = RightPinal;
                     frmCoil.Dock = DockStyle.Fill;
                     frmCoil.OveroadForm(imgitem_coil);
                     frmCoil.InitialValue(imgitem_coil, 0);
                     frmCoil.Show();
                     break;
                 case "Control Box":
                     imgitem_controlBox.CoolingPower = imgEntity.coolingType;
                     imgitem_controlBox.OrderID = imgEntity.OrderId;
                     imgitem_controlBox.ModuleTag = imgEntity.ModuleTag;
                     imgitem_controlBox.Type = imgEntity.ParentName;
                     imgitem_controlBox.ImgageName = imgEntity.Name;
                     ControlBox frmControlBox = new ControlBox();
                     frmControlBox.TopLevel = false;
                     frmControlBox.Parent = RightPinal;
                     frmControlBox.Dock = DockStyle.Fill;
                     frmControlBox.OveroadForm(imgitem_controlBox);
                     frmControlBox.InitialValue(imgitem_controlBox, 0);
                     frmControlBox.Show();
                     break;
                 case "Fan Box":
                     imgitem_fanBox.CoolingPower = imgEntity.coolingType;
                     imgitem_fanBox.OrderID = imgEntity.OrderId;
                     imgitem_fanBox.ModuleTag = imgEntity.ModuleTag;
                     imgitem_fanBox.Type = imgEntity.ParentName;
                     imgitem_fanBox.ImgageName = imgEntity.Name;
                     FanBox frmFanBox = new FanBox();
                     frmFanBox.TopLevel = false;
                     frmFanBox.Parent = RightPinal;
                     frmFanBox.Dock = DockStyle.Fill;
                     frmFanBox.OveroadForm(imgitem_fanBox);
                     frmFanBox.InitialValue(imgitem_fanBox, 0);
                     frmFanBox.Show();
                     break;
                 case "Filter":
                     imgitem_filter.CoolingPower = imgEntity.coolingType;
                     imgitem_filter.OrderID = imgEntity.OrderId;
                     imgitem_filter.ModuleTag = imgEntity.ModuleTag;
                     imgitem_filter.Type = imgEntity.ParentName;
                     imgitem_filter.ImgageName = imgEntity.Name;
                     Filter frmFilter = new Filter();
                     frmFilter.TopLevel = false;
                     frmFilter.Parent = RightPinal;
                     frmFilter.Dock = DockStyle.Fill;
                     frmFilter.OveroadForm(imgitem_filter);
                     frmFilter.InitialValue(imgitem_filter, 0);
                     frmFilter.Show();
                     break;
                 case "Heat":
                     imgitem_heat.CoolingPower = imgEntity.coolingType;
                     imgitem_heat.OrderID = imgEntity.OrderId;
                     imgitem_heat.ModuleTag = imgEntity.ModuleTag;
                     imgitem_heat.Type = imgEntity.ParentName;
                     imgitem_heat.ImgageName = imgEntity.Name;
                     Heat frmHeat = new Heat();
                     frmHeat.TopLevel = false;
                     frmHeat.Parent = RightPinal;
                     frmHeat.Dock = DockStyle.Fill;
                     frmHeat.OveroadForm(imgitem_heat);
                     frmHeat.InitialValue(imgitem_heat, 0);
                     frmHeat.Show();
                     break;
                 case "HRWheel":
                     imgitem_HRWheel.CoolingPower = imgEntity.coolingType;
                     imgitem_HRWheel.OrderID = imgEntity.OrderId;
                     imgitem_HRWheel.ModuleTag = imgEntity.ModuleTag;
                     imgitem_HRWheel.Type = imgEntity.ParentName;
                     imgitem_HRWheel.ImgageName = imgEntity.Name;
                     HRWheel frmHRWheel = new HRWheel();
                     frmHRWheel.TopLevel = false;
                     frmHRWheel.Parent = RightPinal;
                     frmHRWheel.Dock = DockStyle.Fill;
                     frmHRWheel.OveroadForm(imgitem_HRWheel);
                     frmHRWheel.InitialValue(imgitem_HRWheel, 0);
                     frmHRWheel.Show();
                     break;
                 case "MixingBox":
                     imgitem_MixingBox.CoolingPower = imgEntity.coolingType;
                     imgitem_MixingBox.OrderID = imgEntity.OrderId;
                     imgitem_MixingBox.ModuleTag = imgEntity.ModuleTag;
                     imgitem_MixingBox.Type = imgEntity.ParentName;
                     imgitem_MixingBox.ImgageName = imgEntity.Name;
                     MixingBox frmMixingBox = new MixingBox();
                     frmMixingBox.TopLevel = false;
                     frmMixingBox.Parent = RightPinal;
                     frmMixingBox.Dock = DockStyle.Fill;
                     frmMixingBox.OveroadForm(imgitem_MixingBox);
                     frmMixingBox.InitialValue(imgitem_MixingBox, 0);//获取点击的图标，传递其唯一标识
                     frmMixingBox.Show();
                     break;
             }

        }



        void firstPb_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            ImageModel imgEntity = getImageModel(pb.Name, imageModelist);
            switch (imgEntity.ParentName)
            {
                case "Blank Box":
                    imgitem_blankBox.CoolingPower = imgEntity.coolingType;
                    imgitem_blankBox.OrderID = imgEntity.OrderId;
                    imgitem_blankBox.ModuleTag = imgEntity.ModuleTag;
                    imgitem_blankBox.Type = imgEntity.ParentName;
                    imgitem_blankBox.ImgageName = imgEntity.Name;
                    BlankBox frmblankBox = new BlankBox();
                    frmblankBox.TopLevel = false;
                    frmblankBox.Parent = RightPinal;
                    frmblankBox.Dock = DockStyle.Fill;
                    frmblankBox.OveroadForm(imgitem_blankBox);//传递参数用
                    frmblankBox.InitialValue(imgitem_blankBox, 0);//获取点击的图标，传递其唯一标识，并赋值
                    frmblankBox.Show();
                    break;
                case "Coil":
                    imgitem_coil.CoolingPower = imgEntity.coolingType;
                    imgitem_coil.OrderID = imgEntity.OrderId;
                    imgitem_coil.ModuleTag = imgEntity.ModuleTag;
                    imgitem_coil.Type = imgEntity.ParentName;
                    imgitem_coil.ImgageName = imgEntity.Name;
                    Coil frmCoil = new Coil();
                    frmCoil.TopLevel = false;
                    frmCoil.Parent = RightPinal;
                    frmCoil.Dock = DockStyle.Fill;
                    frmCoil.OveroadForm(imgitem_coil);
                    frmCoil.InitialValue(imgitem_coil, 0);
                    frmCoil.Show();
                    break;
                case "Control Box":
                    imgitem_controlBox.CoolingPower = imgEntity.coolingType;
                    imgitem_controlBox.OrderID = imgEntity.OrderId;
                    imgitem_controlBox.ModuleTag = imgEntity.ModuleTag;
                    imgitem_controlBox.Type = imgEntity.ParentName;
                    imgitem_controlBox.ImgageName = imgEntity.Name;
                    ControlBox frmControlBox = new ControlBox();
                    frmControlBox.TopLevel = false;
                    frmControlBox.Parent = RightPinal;
                    frmControlBox.Dock = DockStyle.Fill;
                    frmControlBox.OveroadForm(imgitem_controlBox);
                    frmControlBox.InitialValue(imgitem_controlBox, 0);
                    frmControlBox.Show();
                    break;
                case "Fan Box":
                    imgitem_fanBox.CoolingPower = imgEntity.coolingType;
                    imgitem_fanBox.OrderID = imgEntity.OrderId;
                    imgitem_fanBox.ModuleTag = imgEntity.ModuleTag;
                    imgitem_fanBox.Type = imgEntity.ParentName;
                    imgitem_fanBox.ImgageName = imgEntity.Name;
                    FanBox frmFanBox = new FanBox();
                    frmFanBox.TopLevel = false;
                    frmFanBox.Parent = RightPinal;
                    frmFanBox.Dock = DockStyle.Fill;
                    frmFanBox.OveroadForm(imgitem_fanBox);
                    frmFanBox.InitialValue(imgitem_fanBox, 0);
                    frmFanBox.Show();
                    break;
                case "Filter":
                    imgitem_filter.CoolingPower = imgEntity.coolingType;
                    imgitem_filter.OrderID = imgEntity.OrderId;
                    imgitem_filter.ModuleTag = imgEntity.ModuleTag;
                    imgitem_filter.Type = imgEntity.ParentName;
                    imgitem_filter.ImgageName = imgEntity.Name;
                    Filter frmFilter = new Filter();
                    frmFilter.TopLevel = false;
                    frmFilter.Parent = RightPinal;
                    frmFilter.Dock = DockStyle.Fill;
                    frmFilter.OveroadForm(imgitem_filter);
                    frmFilter.InitialValue(imgitem_filter, 0);
                    frmFilter.Show();
                    break;
                case "Heat":
                    imgitem_heat.CoolingPower = imgEntity.coolingType;
                    imgitem_heat.OrderID = imgEntity.OrderId;
                    imgitem_heat.ModuleTag = imgEntity.ModuleTag;
                    imgitem_heat.Type = imgEntity.ParentName;
                    imgitem_heat.ImgageName = imgEntity.Name;
                    Heat frmHeat = new Heat();
                    frmHeat.TopLevel = false;
                    frmHeat.Parent = RightPinal;
                    frmHeat.Dock = DockStyle.Fill;
                    frmHeat.OveroadForm(imgitem_heat);
                    frmHeat.InitialValue(imgitem_heat, 0);
                    frmHeat.Show();
                    break;
                case "HRWheel":
                    imgitem_HRWheel.CoolingPower = imgEntity.coolingType;
                    imgitem_HRWheel.OrderID = imgEntity.OrderId;
                    imgitem_HRWheel.ModuleTag = imgEntity.ModuleTag;
                    imgitem_HRWheel.Type = imgEntity.ParentName;
                    imgitem_HRWheel.ImgageName = imgEntity.Name;
                    HRWheel frmHRWheel = new HRWheel();
                    frmHRWheel.TopLevel = false;
                    frmHRWheel.Parent = RightPinal;
                    frmHRWheel.Dock = DockStyle.Fill;
                    frmHRWheel.OveroadForm(imgitem_HRWheel);
                    frmHRWheel.InitialValue(imgitem_HRWheel, 0);
                    frmHRWheel.Show();
                    break;
                case "MixingBox":
                    imgitem_MixingBox.CoolingPower = imgEntity.coolingType;
                    imgitem_MixingBox.OrderID = imgEntity.OrderId;
                    imgitem_MixingBox.ModuleTag = imgEntity.ModuleTag;
                    imgitem_MixingBox.Type = imgEntity.ParentName;
                    imgitem_MixingBox.ImgageName = imgEntity.Name;
                    MixingBox frmMixingBox = new MixingBox();
                    frmMixingBox.TopLevel = false;
                    frmMixingBox.Parent = RightPinal;
                    frmMixingBox.Dock = DockStyle.Fill;
                    frmMixingBox.OveroadForm(imgitem_MixingBox);
                    frmMixingBox.InitialValue(imgitem_MixingBox, 0);//获取点击的图标，传递其唯一标识
                    frmMixingBox.Show();
                    break;
            }

        }

        public ImageModel getImageModel(string pbName,List<ImageModel> imageModelList)
        {
            for (int i = 0; i < imageModelList.Count;i++ )
            {
                ImageModel imageModel = imageModelList.ElementAt(i);
                string nameModel = imageModel.ModuleTag + "" + imageModel.Name;
                if (pbName.Equals(nameModel))
                {
                    return imageModel;
                }
            }
            return null;
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

        //根据父窗口选择的进入其设置界面
        private void ModuleDetail_Load(object sender, EventArgs e)
        {
            //ImgClick(SelectedImge);
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
