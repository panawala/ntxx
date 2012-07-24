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
        ImageModel imgSelectedModel = new ImageModel();
        List<ImageModel> imageModelist = new List<ImageModel>();
        int orderId=0;
        string SelectedImge;//暂时设定为定值，测试用
        ImageModel IntialSelectedImge_mode = new ImageModel();
        string IntialSelectedImge;

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
                        ContentBLL.InitialImageOrder(imgEntity.Guid, imgEntity.coolingType, imgEntity.Name, imgEntity.OrderId, imgEntity.ModuleTag);
                        IntialSelectedImge = imgEntity.ParentName;
                        IntialSelectedImge_mode = imgEntity;
                        if (imgEntity.IsSelected == true)
                        {
                            imgSelectedModel = imgEntity;
                            SelectedImge = imgEntity.ParentName;
                        }
                        if (i == 1)
                        {
                            orderId = imgEntity.OrderId;
                        }
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
                     BlankBox frmblankBox = new BlankBox();
                     frmblankBox.TopLevel = false;
                     frmblankBox.Parent = RightPinal;
                     frmblankBox.Dock = DockStyle.Fill;
                     frmblankBox.OveroadForm(imgEntity);//传递参数用
                     frmblankBox.InitialValue(imgEntity, imgEntity.OrderId);//获取点击的图标，传递其唯一标识，并赋值
                     frmblankBox.Show();
                     break;
                 case "Coil":
                     Coil frmCoil = new Coil();
                     frmCoil.TopLevel = false;
                     frmCoil.Parent = RightPinal;
                     frmCoil.Dock = DockStyle.Fill;
                     frmCoil.OveroadForm(imgEntity);
                     frmCoil.InitialValue(imgEntity, imgEntity.OrderId);
                     frmCoil.Show();
                     break;
                 case "Control Box":
                     ControlBox frmControlBox = new ControlBox();
                     frmControlBox.TopLevel = false;
                     frmControlBox.Parent = RightPinal;
                     frmControlBox.Dock = DockStyle.Fill;
                     frmControlBox.OveroadForm(imgEntity);
                     frmControlBox.InitialValue(imgEntity, imgEntity.OrderId);
                     frmControlBox.Show();
                     break;
                 case "Fan Box":
                     FanBox frmFanBox = new FanBox();
                     frmFanBox.TopLevel = false;
                     frmFanBox.Parent = RightPinal;
                     frmFanBox.Dock = DockStyle.Fill;
                     frmFanBox.OveroadForm(imgEntity);
                     frmFanBox.InitialValue(imgEntity, imgEntity.OrderId);
                     frmFanBox.Show();
                     break;
                 case "Filter":
                     Filter frmFilter = new Filter();
                     frmFilter.TopLevel = false;
                     frmFilter.Parent = RightPinal;
                     frmFilter.Dock = DockStyle.Fill;
                     frmFilter.OveroadForm(imgEntity);
                     frmFilter.InitialValue(imgEntity, imgEntity.OrderId);
                     frmFilter.Show();
                     break;
                 case "Heat":
                     Heat frmHeat = new Heat();
                     frmHeat.TopLevel = false;
                     frmHeat.Parent = RightPinal;
                     frmHeat.Dock = DockStyle.Fill;
                     frmHeat.OveroadForm(imgEntity);
                     frmHeat.InitialValue(imgEntity, imgEntity.OrderId);
                     frmHeat.Show();
                     break;
                 case "HRWheel":
                     HRWheel frmHRWheel = new HRWheel();
                     frmHRWheel.TopLevel = false;
                     frmHRWheel.Parent = RightPinal;
                     frmHRWheel.Dock = DockStyle.Fill;
                     frmHRWheel.OveroadForm(imgEntity);
                     frmHRWheel.InitialValue(imgEntity, imgEntity.OrderId);
                     frmHRWheel.Show();
                     break;
                 case "MixingBox":
                     MixingBox frmMixingBox = new MixingBox();
                     frmMixingBox.TopLevel = false;
                     frmMixingBox.Parent = RightPinal;
                     frmMixingBox.Dock = DockStyle.Fill;
                     frmMixingBox.OveroadForm(imgEntity);
                     frmMixingBox.InitialValue(imgEntity, imgEntity.OrderId);//获取点击的图标，传递其唯一标识
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
                    BlankBox frmblankBox = new BlankBox();
                    frmblankBox.TopLevel = false;
                    frmblankBox.Parent = RightPinal;
                    frmblankBox.Dock = DockStyle.Fill;
                    frmblankBox.OveroadForm(imgEntity);//传递参数用
                    frmblankBox.InitialValue(imgEntity, imgEntity.OrderId);//获取点击的图标，传递其唯一标识，并赋值
                    frmblankBox.Show();
                    break;
                case "Coil":
                    Coil frmCoil = new Coil();
                    frmCoil.TopLevel = false;
                    frmCoil.Parent = RightPinal;
                    frmCoil.Dock = DockStyle.Fill;
                    frmCoil.OveroadForm(imgEntity);
                    frmCoil.InitialValue(imgEntity, imgEntity.OrderId);
                    frmCoil.Show();
                    break;
                case "Control Box":
                    ControlBox frmControlBox = new ControlBox();
                    frmControlBox.TopLevel = false;
                    frmControlBox.Parent = RightPinal;
                    frmControlBox.Dock = DockStyle.Fill;
                    frmControlBox.OveroadForm(imgEntity);
                    frmControlBox.InitialValue(imgEntity, imgEntity.OrderId);
                    frmControlBox.Show();
                    break;
                case "Fan Box":
                    FanBox frmFanBox = new FanBox();
                    frmFanBox.TopLevel = false;
                    frmFanBox.Parent = RightPinal;
                    frmFanBox.Dock = DockStyle.Fill;
                    frmFanBox.OveroadForm(imgEntity);
                    frmFanBox.InitialValue(imgEntity, imgEntity.OrderId);
                    frmFanBox.Show();
                    break;
                case "Filter":
                    Filter frmFilter = new Filter();
                    frmFilter.TopLevel = false;
                    frmFilter.Parent = RightPinal;
                    frmFilter.Dock = DockStyle.Fill;
                    frmFilter.OveroadForm(imgEntity);
                    frmFilter.InitialValue(imgEntity, imgEntity.OrderId);
                    frmFilter.Show();
                    break;
                case "Heat":
                    Heat frmHeat = new Heat();
                    frmHeat.TopLevel = false;
                    frmHeat.Parent = RightPinal;
                    frmHeat.Dock = DockStyle.Fill;
                    frmHeat.OveroadForm(imgEntity);
                    frmHeat.InitialValue(imgEntity, imgEntity.OrderId);
                    frmHeat.Show();
                    break;
                case "HRWheel":
                    HRWheel frmHRWheel = new HRWheel();
                    frmHRWheel.TopLevel = false;
                    frmHRWheel.Parent = RightPinal;
                    frmHRWheel.Dock = DockStyle.Fill;
                    frmHRWheel.OveroadForm(imgEntity);
                    frmHRWheel.InitialValue(imgEntity, imgEntity.OrderId);
                    frmHRWheel.Show();
                    break;
                case "MixingBox":
                    MixingBox frmMixingBox = new MixingBox();
                    frmMixingBox.TopLevel = false;
                    frmMixingBox.Parent = RightPinal;
                    frmMixingBox.Dock = DockStyle.Fill;
                    frmMixingBox.OveroadForm(imgEntity);
                    frmMixingBox.InitialValue(imgEntity, imgEntity.OrderId);//获取点击的图标，传递其唯一标识
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

        public void ShowSelectedImg(string  imgSelected,ImageModel ImMo)
        {
            switch (imgSelected)
            {
                case "Blank Box":
                    BlankBox frmblankBox = new BlankBox();
                    frmblankBox.TopLevel = false;
                    frmblankBox.Parent = RightPinal;
                    frmblankBox.Dock = DockStyle.Fill;
                    frmblankBox.OveroadForm(ImMo);//传递参数用
                    frmblankBox.InitialValue(ImMo, orderId);//获取点击的图标，传递其唯一标识，并赋值
                    frmblankBox.Show();
                    break;
                case "Coil":
                    Coil frmCoil = new Coil();
                    frmCoil.TopLevel = false;
                    frmCoil.Parent = RightPinal;
                    frmCoil.Dock = DockStyle.Fill;
                    frmCoil.OveroadForm(ImMo);
                    frmCoil.InitialValue(ImMo, orderId);
                    frmCoil.Show();
                    break;
                case "Control Box":
                    ControlBox frmControlBox = new ControlBox();
                    frmControlBox.TopLevel = false;
                    frmControlBox.Parent = RightPinal;
                    frmControlBox.Dock = DockStyle.Fill;
                    frmControlBox.OveroadForm(ImMo);
                    frmControlBox.InitialValue(ImMo, orderId);
                    frmControlBox.Show();
                    break;
                case "Fan Box":
                    FanBox frmFanBox = new FanBox();
                    frmFanBox.TopLevel = false;
                    frmFanBox.Parent = RightPinal;
                    frmFanBox.Dock = DockStyle.Fill;
                    frmFanBox.OveroadForm(ImMo);
                    frmFanBox.InitialValue(ImMo, orderId);
                    frmFanBox.Show();
                    break;
                case "Filter":
                    Filter frmFilter = new Filter();
                    frmFilter.TopLevel = false;
                    frmFilter.Parent = RightPinal;
                    frmFilter.Dock = DockStyle.Fill;
                    frmFilter.OveroadForm(ImMo);
                    frmFilter.InitialValue(ImMo, orderId);
                    frmFilter.Show();
                    break;
                case "Heat":
                    Heat frmHeat = new Heat();
                    frmHeat.TopLevel = false;
                    frmHeat.Parent = RightPinal;
                    frmHeat.Dock = DockStyle.Fill;
                    frmHeat.OveroadForm(ImMo);
                    frmHeat.InitialValue(ImMo, orderId);
                    frmHeat.Show();
                    break;
                case "HRWheel":
                    HRWheel frmHRWheel = new HRWheel();
                    frmHRWheel.TopLevel = false;
                    frmHRWheel.Parent = RightPinal;
                    frmHRWheel.Dock = DockStyle.Fill;
                    frmHRWheel.OveroadForm(ImMo);
                    frmHRWheel.InitialValue(ImMo, orderId);
                    frmHRWheel.Show();
                    break;
                case "MixingBox":
                    MixingBox frmMixingBox = new MixingBox();
                    frmMixingBox.TopLevel = false;
                    frmMixingBox.Parent = RightPinal;
                    frmMixingBox.Dock = DockStyle.Fill;
                    frmMixingBox.OveroadForm(ImMo);
                    frmMixingBox.InitialValue(ImMo, orderId);//获取点击的图标，传递其唯一标识
                    frmMixingBox.Show();
                    break;
            }
        }

        //根据父窗口选择的进入其设置界面
        private void ModuleDetail_Load(object sender, EventArgs e)
        {
            if (SelectedImge != null)
            {
                ShowSelectedImg(SelectedImge, imgSelectedModel);
            }
            else
            {
                ShowSelectedImg(IntialSelectedImge, IntialSelectedImge_mode);
            }
        }

        // 从父窗口传回数据


        private void RightPinal_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
