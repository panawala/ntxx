using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using netDxf;
//using DxfLib.OperatorEntity;
//using netDxf.Header;
using Annon.ZuTu.GraphicControl;
//using DxfLib.OperatorEntity;
using EntityFrameworkTryBLL.ZutuManager;
using Model.Zutu;
//using DxfLib.Entity;
using WW.Cad.Model;
using CadLib.OperatorEntity;
using CadLib.Entity;
using WW.Cad.IO;
using Annon.Zutu.FrontPhoto;
using Annon.Module_Detail;
using Annon.Xuanxing;
using EntityFrameworkTryBLL.OrderManager;

namespace Annon.Zutu
{
    public partial class OperatePhoto : Form
    {
        public OperatePhoto()
        {
            InitializeComponent();
            //测试阶段，首页先加载这一部分代码，到时候要删除
            List<string> strTest = new List<string>();
            strTest.Add("(FTA) Small Flat Filter");
            strTest.Add("(FTC) Catridge Filter");
            strTest.Add("(FTF) Large Flat Filter");
            strTest.Add("(FTH) Combination Filter");
           // strTest.Add("(FTA)Small Flat");
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            addLeftPictureBoxToLeftPanel(strTest, panel4, "filter");
            FrontPhotoService.leftStartX = panel3.Width - 300;
           imageBoxList=FrontPhotoService.initSingleLayerOPeratorPhoto(imageBoxList, coolingType);
           panel3.RowImageEntities = imageBoxList;
           panel3.OnEntityClick += new CustomForm.EntityClicked(panel3_OnEntityClick);
           panel3.OnEntityDBClick += new CustomForm.EntityDBClicked(panel3_OnEntityDBClick);
        }


      

         private bool pictureBox1Flag{ set; get; }
        private bool pictureBox2Flag { set; get; }
        private List<PictureBox> rightPictrueBoxList = new List<PictureBox>();
        private Dictionary<string, PictureBox> rightPictureBoxDictionary = new Dictionary<string, PictureBox>();
        private Dictionary<string, PictureBox> leftPictureBoxDictionary = new Dictionary<string, PictureBox>();
        private Dictionary<string, Label> leftLabelDictionary = new Dictionary<string, Label>();
        //当前右边面板中选中的PictureBox
        private PictureBox rightPanelCurrentSeclectedPictureBox;

        //2012-7-20 begin
        private List<ImageEntity> imageBoxList = new List<ImageEntity>();
        private List<ImageEntity> leftTopImageBoxList = new List<ImageEntity>();
         //放大缩小因子
        double saveFactor = 1;
        double zoomInFactor = 2;
        double zoomOutFactor = 0.5;
        //end

        //冷量类型,默认时为,从别处获得
        int coolingType = 5;

        //当前选中了那个TagIndex
        int tagIndex = 0;

        //mirror控制参数
        bool mirrorLeft = false;
        bool mirrorRight = true;

        //负责创建右边窗口显示的PictureBox
        private void CreatePictureBox(PictureBox pictureBox,string picName)
        {
            PictureBox pic = new PictureBox();
            //如果是要加入两层的控件PictureBox,进入if，普通的一层进入else
            if (RightImageRangeType.imageRangeType.Contains(getPictureBoxToImageName(pictureBox.Name)))
            {
                pic.Width = pictureBox.Width;
                pic.Height = pictureBox.Height * 2+4;
                pic.Name = picName;
                Bitmap tempImageBitMap = new Bitmap(pictureBox.Image,new Size(85,227));
                pic.Image = tempImageBitMap;
                bottomPanel.Controls.Add(pic);
            }
            else
            {
                pic.Width = pictureBox.Width;
                pic.Height = pictureBox.Height;
                pic.Image = pictureBox.Image;
                pic.Name = picName;
                bottomPanel.Controls.Add(pic);
            }
            pic.MouseDown += new MouseEventHandler(pic_MouseDown);
            pic.MouseMove += new MouseEventHandler(pic_MouseMove);
            pic.MouseUp += new MouseEventHandler(pic_MouseUp);
            //右边pictureBox单击事件
            pic.Click += new EventHandler(pic_Click);
        }
        //右边picturebox事件响应函数
        void pic_Click(object sender, EventArgs e)
        {
            foreach(Control c in bottomPanel.Controls){
                if (c is PictureBox)
                {
                    PictureBox allPb = (PictureBox)c;
                    allPb.BorderStyle = BorderStyle.None;
                }
            }
            PictureBox p = (PictureBox)sender;
            p.BorderStyle = BorderStyle.Fixed3D;

            height.Text = "Height:"+p.Height;
            type.Text="Type:"+p.Name;
            widthLabel.Text = "Width:"+p.Width;

            rightPanelCurrentSeclectedPictureBox = p;
           // p.Paint+=new PaintEventHandler(pic_Paint);
            //MessageBox.Show("dkdk");
        }


        
        //右边panel拖动鼠标放开时，响应的事件，主要是取panel中PictureBox
        void pic_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pic = sender as PictureBox;
                if (null == pic) return;
                string name = pic.Name; // 取出pictureBox的名称
                foreach (Control c in bottomPanel.Controls)
                {
                    if (c is PictureBox)
                    {
                        if(!rightPictureBoxDictionary.ContainsKey(c.GetHashCode().ToString()))
                        rightPictureBoxDictionary.Add(c.GetHashCode().ToString(),(PictureBox)c);
                    }

                }
                pic.Cursor = Cursors.Hand;
                //绘制右边面板中PictureBox
                createPanelImageList();
            }
        }

        void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pic = sender as PictureBox;
                if (null == pic) return;
                string name = pic.Name; // 取出pictureBox的名称
               
                
                    pic.BringToFront();
                    if (Control.MousePosition.X >= (panel2.Width - pic.Width / 2))
                        pic.Location = new Point(Control.MousePosition.X - SystemInformation.FrameBorderSize.Width - panel2.Width - pic.Width / 2, Control.MousePosition.Y - SystemInformation.FrameBorderSize.Height - pic.Height / 2);
                
            }
        }

        
        //绘画选中框
        void pic_Paint(object sender, PaintEventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            Pen pp = new Pen(System.Drawing.Color.Blue);
            pp.Width = 5;
            p.BorderStyle = BorderStyle.Fixed3D;
            e.Graphics.DrawRectangle(pp, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.X + e.ClipRectangle.Width - 1, e.ClipRectangle.Y + e.ClipRectangle.Height - 1);
        }

        //鼠标按下便鼠标图标
        private void pic_MouseDown(object sender,MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pic = sender as PictureBox;
                if (null == pic) return;
                string name = pic.Name; // 取出pictureBox的名称
                //  pic.Location = new Point(e.X,e.Y);
                    pic.Cursor = Cursors.Hand;
            }
        }


        //绘制右边Panel的函数封装
        private void createPanelImageList()
        {
            if (rightPictureBoxDictionary != null&&rightPictureBoxDictionary.Count>0)
            {
               // panel3.Controls.Clear();
                List<KeyValuePair<string, PictureBox>> tempPaintImageList = getPaintImageList(rightPictureBoxDictionary);
                createPaintPictureBox(tempPaintImageList);
            }
        }

        //拖动时，在右边Panel中绘制出所有的PictureBox
        private void createPaintPictureBox(List<KeyValuePair<string,PictureBox>> tempPaintImageList)
        {
            //定义sortRangeList用来存储设好坐标的PictureBox
            List<PictureBox> sortRangeList = new List<PictureBox>();
            for (int i = 0; i < tempPaintImageList.Count; i++)
            {
                if (i == 0)
                {
                    bottomPanel.Controls.Add((PictureBox)tempPaintImageList.ElementAt(i).Value);
                    //第一存放好的PictureBox
                    sortRangeList.Add(tempPaintImageList.ElementAt(i).Value);
                }
                else
                {
                    //PictureBox tempPbBefor=tempPaintImageList.ElementAt(i-1).Value;
                    
                    PictureBox tempPbAfter = tempPaintImageList.ElementAt(i).Value;
                    PictureBox tempPbBefor = getMostRecentPictureBox(tempPbAfter, sortRangeList);
                    if (Math.Abs(tempPbAfter.Location.Y - tempPbBefor.Location.Y) < tempPbAfter.Height)
                        tempPbAfter.Location = new Point(tempPbBefor.Location.X + tempPbBefor.Width, tempPbBefor.Location.Y);
                    else if (Math.Abs(tempPbAfter.Location.Y - tempPbBefor.Location.Y)<1.5*tempPbAfter.Height&&Math.Abs(tempPbAfter.Location.Y-tempPbBefor.Location.Y)>0.9*tempPbAfter.Height)
                    {
                        int y_site = tempPbAfter.Location.Y > tempPbBefor.Location.Y ? (tempPbBefor.Location.Y + tempPbBefor.Height + 4) : Math.Abs(tempPbBefor.Location.Y - tempPbBefor.Height - 4);
                        tempPbAfter.Location = new Point(tempPbBefor.Location.X, y_site);
                    }
                    //其他已经拖动好的PictureBox,存放其中
                    sortRangeList.Add(tempPbAfter);
                    //添加到右边面板中
                    bottomPanel.Controls.Add(tempPbAfter);
                }
            }
        }
        //绘制右边面板PictureBox时，根据离他最近的控件进行定位
        private PictureBox getMostRecentPictureBox(PictureBox tempPbAfter,List<PictureBox> sortRangeList)
        {
            int min = Int32.MaxValue;
            PictureBox tempPb=null;
            foreach(PictureBox pb in sortRangeList){
                string strDoubleLayers = getPictureBoxToImageName(pb.Name);
                int tempNum = 0;
                //如果是两层控件时要注意，可以将它看成分布在两层的两个控件，下层去他的中间坐标，进行定位，效果不错
                if (RightImageRangeType.imageRangeType.Contains(strDoubleLayers))
                {
                    tempNum = (Math.Abs(pb.Location.X - tempPbAfter.Location.X) + Math.Abs(pb.Location.Y - tempPbAfter.Location.Y));
                    if (min > tempNum)
                    {
                        min = tempNum;
                        tempPb = pb;
                    }
                    tempNum = (Math.Abs(pb.Location.X - tempPbAfter.Location.X) + Math.Abs(pb.Location.Y+pb.Height/2 - tempPbAfter.Location.Y));
                    if (min > tempNum)
                    {
                        //返回中间的虚拟PictureBox，仅用于坐标定位
                        PictureBox virtualPictureBox = new PictureBox();
                        //这里的virtualpictureBox.location.y中+2的原因是因为，中间间隔为4
                        virtualPictureBox.Location = new Point(pb.Location.X-12, pb.Location.Y + pb.Height / 2+2);
                        min = tempNum;
                        tempPb = virtualPictureBox;
                    }
                }
                else
                {
                    tempNum = (Math.Abs(pb.Location.X - tempPbAfter.Location.X) + Math.Abs(pb.Location.Y - tempPbAfter.Location.Y));
                    if (min > tempNum)
                    {
                        min = tempNum;
                        tempPb = pb;
                    }
                }     
            }
            return tempPb;
        }

        //将存储PictureBox的Dictionary存储结构变为List
        private List<KeyValuePair<string, PictureBox>> getPaintImageList(Dictionary<string, PictureBox> dictionary)
        {
            List<KeyValuePair<string,PictureBox>> tempList = dictionary.AsEnumerable<KeyValuePair<string,PictureBox>>().ToList<KeyValuePair<string,PictureBox>>();
            tempList.Sort(comparison);
            return tempList;
        }
        //用于List排序的比较器
        private int comparison(KeyValuePair<string,PictureBox> keyValueString1,KeyValuePair<string,PictureBox> keyValueString2)
        {
            return keyValueString1.Value.Location.X.CompareTo(keyValueString2.Value.Location.X);
        }
        /// <summary>
        /// 这个函数的功能就是读取图片，初始化左边面板图片列表
        /// </summary>
        /// <param name="strLabelList"></param>
        /// <param name="str"></param>
        private void createLeftPictureBoxList(List<string> strLabelList, string str = "filter", string mirrorDirection= "mirrorRight", int coolingType = 5)
        {
            string imagePath = "../../image/" + str;
       
            ImageList imageList = getLeftImageUrl(imagePath);
           
            
            //两个If防止清空作用
            if (leftPictureBoxDictionary != null && leftPictureBoxDictionary.Count > 0)
            {
                leftPictureBoxDictionary.Clear();
            }
            if (leftLabelDictionary != null && leftLabelDictionary.Count > 0)
            {
                leftLabelDictionary.Clear();
            }
           
            
            if (imageList != null)
            {
                if (imageList.Images.Count == strLabelList.Count)
                {
                    //设置pictruebox 中文件名称需要，他的长度和imageList相同，同时文件名称一一对应

                   // string[] imagePathArray = Directory.GetFiles(imagePath);
                   // List<string> tempImageFileNameList = getimageFileName(imagePathArray);
                    //修改时间2012-7-12
                    List<GraphicText> tempImageFileNameList = GraphicControlService.initLeftGraphicText(str);
                    List<string> imageEntityNameList = ImageBlockBLL.getImageNames(coolingType);
                    for (int i = 0; i < imageList.Images.Count; i++)
                    {
                        string simpleImageEntityName = tempImageFileNameList.ElementAt(i).realLetterAndNumName.ToString().Substring(1, 3);
                        if(imageEntityNameList.Contains(simpleImageEntityName)){
                            PictureBox leftPb = new PictureBox();
                            // leftPb.Name = "pictrueBox" + tempImageFileNameList.ElementAt(i).ToString();
                            //注意此处必须进行这样命名
                            //leftPb.Name = "pictrueBox" + tempImageFileNameList.ElementAt(i).realLetterAndNumName.ToString().Substring(1,3);
                            leftPb.Name = tempImageFileNameList.ElementAt(i).realLetterAndNumName.ToString().Substring(1, 3);                           
                            if (mirrorDirection.Equals("mirrorRight"))
                            {
                                leftPb.Image = imageList.Images[i];
                            }
                            else
                            {
                                Bitmap bmp = new Bitmap(imageList.Images[i]);
                                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                                leftPb.Image = bmp;
                            }                           
                            leftPb.Width = imageList.Images[i].Width + 2;
                            leftPb.Height = imageList.Images[i].Height + 3;
                            leftPictureBoxDictionary.Add(leftPb.GetHashCode().ToString(), leftPb);

                            Label leftLabel = new Label();
                            leftLabel.Text = strLabelList.ElementAt(i).ToString();
                            leftLabelDictionary.Add(leftPb.GetHashCode().ToString(), leftLabel);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("图片数目和图片说明数量不一致!");
                }
            }
        }
        /// <summary>
        /// 这个函数的功能就是根据图片路径返回图片列表
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        private ImageList getLeftImageUrl(string imagePath)
        {
            if (Directory.Exists(imagePath))
            {
                string[] imagePathArray = Directory.GetFiles(imagePath);
                List<string> tempLeftImageList = imagePathArray.ToList<string>();
                ImageList tempImageList = new ImageList();
                for (int i=0; i < tempLeftImageList.Count; i++)
                {
                 
                    Image tempImage = Image.FromFile(tempLeftImageList.ElementAt(i).ToString());
                   
                    Bitmap imageBitMap = new Bitmap(tempImage,tempImage.Width,tempImage.Height);
                   
                    tempImageList.ImageSize = new System.Drawing.Size(85, 110);
                    tempImageList.Images.Add(imageBitMap);
                }
                return tempImageList;
            }
            return null;
        }
        //提取图评路径中文件的名称
        private List<string> getimageFileName(string[] pathArray)
        {
            List<string> imageFileName = new List<string>();
            foreach (string str in pathArray)
            {
                string strTemp = str.Substring(str.LastIndexOf("\\")+1,str.LastIndexOf(".")-str.LastIndexOf("\\")-1);
                imageFileName.Add(strTemp);
            }
            return imageFileName;
        }

        //获取PictureBox的所对应的图像名称，唯一的标识一个图像源
        private string getPictureBoxToImageName(string pictureBoxName)
        {
            return pictureBoxName.Substring(pictureBoxName.LastIndexOf("x") + 1);
        }

       
        /// <summary>
        /// 将PictureBox加入到左边面板中
        /// </summary>
        /// <param name="strLabelList"></param>
        /// <param name="panel"></param>
        /// <param name="str"></param>
        private void addLeftPictureBoxToLeftPanel(List<string> strLabelList,Panel panel, string str = "filter",string mirrorDirection="mirrorRight",int coolingType=5)
        {
            createLeftPictureBoxList(strLabelList, str, mirrorDirection, coolingType);
            if (leftPictureBoxDictionary != null)
            {
                for (int i = 0; i < leftPictureBoxDictionary.Count; i++)
                {
                    if (i == 0)
                    {
                        PictureBox firstPb = (PictureBox)leftPictureBoxDictionary.ElementAt(i).Value;
                        firstPb.Location = new Point(panel.Width / 4, 3);
                        panel.Controls.Add(firstPb);                    
                        Label firstLabel = (Label)leftLabelDictionary.ElementAt(i).Value;
                        firstLabel.Location = new Point(firstPb.Location.X, firstPb.Location.Y + firstPb.Height + 2);
                        firstLabel.AutoSize = false;
                        firstLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        firstLabel.Width = 85;
                        firstLabel.Height = 50;
                        panel.Controls.Add(firstLabel);

                        //PictrueBox注册事件
                        firstPb.Click += new EventHandler(firstPb_Click);
             
                    }
                    else
                    {
                        Label beforLabel = (Label)leftLabelDictionary.ElementAt(i - 1).Value;
                        PictureBox beforPb = (PictureBox)leftPictureBoxDictionary.ElementAt(i - 1).Value;
                        PictureBox nextPb = (PictureBox)leftPictureBoxDictionary.ElementAt(i).Value;
                        nextPb.Location = new Point(beforPb.Location.X,beforLabel.Location.Y + beforLabel.Height + 2);
                        panel.Controls.Add(nextPb);
                        Label nextLabel = (Label)leftLabelDictionary.ElementAt(i).Value;
                        nextLabel.Location = new Point(nextPb.Location.X, nextPb.Location.Y + nextPb.Height + 2);
                        nextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        nextLabel.Width = 85;
                        nextLabel.Height = 50;
                        nextLabel.AutoSize = false;
                        panel.Controls.Add(nextLabel);
                        nextPb.Click += new EventHandler(nextPb_Click);
                    }
                }
            }
        }
        
        void nextPb_Paint(object sender, PaintEventArgs e)
        {
            
            PictureBox  p = (PictureBox)sender;
            Pen pp = new Pen(System.Drawing.Color.Blue);
            pp.Width = 5;
            p.BorderStyle = BorderStyle.Fixed3D;
            e.Graphics.DrawRectangle(pp, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.X + e.ClipRectangle.Width - 1, e.ClipRectangle.Y + e.ClipRectangle.Height - 1);
            
           
        }

        void firstPb_Paint(object sender, PaintEventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            Pen pp = new Pen(System.Drawing.Color.Blue);
            pp.Width = 5;
            p.BorderStyle = BorderStyle.Fixed3D;
            e.Graphics.DrawRectangle(pp, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.X + e.ClipRectangle.Width - 1, e.ClipRectangle.Y + e.ClipRectangle.Height - 1);
        }

        //非第一个
        void nextPb_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pb.BorderStyle = BorderStyle.Fixed3D;
            createImageBox(pb, 5);           
        }
        //左边Panel中PictureBox的绘画事件
        void pb_Paint(object sender, PaintEventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            Pen pp = new Pen(System.Drawing.Color.Blue);
            pp.Width = 5;
            p.BorderStyle = BorderStyle.Fixed3D;
            e.Graphics.DrawRectangle(pp, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.X + e.ClipRectangle.Width - 1, e.ClipRectangle.Y + e.ClipRectangle.Height - 1);
        }
      //左边第一个PictureBox点击事件
        void firstPb_Click(object sender, EventArgs e)
        {
           
            PictureBox pb = sender as PictureBox;
            pb.BorderStyle = BorderStyle.Fixed3D;
            createImageBox(pb, 5);
        }
        /// <summary>
        /// tabControl事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tc=sender as TabControl;
            tagIndex = tc.SelectedIndex;
            switch (tc.SelectedIndex)
            {
                case 0: setTabPages("filter", 4, panel4, FrontPhotoService.mirrorDirection, coolingType); break;
                case 1: setTabPages("hrwheel", 1, panel5, FrontPhotoService.mirrorDirection, coolingType); break;
                case 2: setTabPages("mixbox", 10, panel6, FrontPhotoService.mirrorDirection, coolingType); break;
                case 3: setTabPages("heat", 4, panel7, FrontPhotoService.mirrorDirection, coolingType); break;
                case 4: setTabPages("coil", 6, panel8, FrontPhotoService.mirrorDirection, coolingType); break;
                case 5: setTabPages("fanbox", 6, panel9, FrontPhotoService.mirrorDirection, coolingType); break;
                case 6: setTabPages("blankbox", 5, panel2, FrontPhotoService.mirrorDirection, coolingType); break;
                case 7: setTabPages("controlbox", 5, panel10, FrontPhotoService.mirrorDirection, coolingType); break;
            }
            
        }

        private void refreshedByModAhUint(int tagIndex)
        {
            switch (tagIndex)
            {
                case 0: setTabPages("filter", 4, panel4,FrontPhotoService.mirrorDirection, coolingType); break;
                case 1: setTabPages("hrwheel", 1, panel5, FrontPhotoService.mirrorDirection, coolingType); break;
                case 2: setTabPages("mixbox", 10, panel6, FrontPhotoService.mirrorDirection, coolingType); break;
                case 3: setTabPages("heat", 4, panel7, FrontPhotoService.mirrorDirection, coolingType); break;
                case 4: setTabPages("coil", 6, panel8, FrontPhotoService.mirrorDirection, coolingType); break;
                case 5: setTabPages("fanbox", 6, panel9, FrontPhotoService.mirrorDirection, coolingType); break;
                case 6: setTabPages("blankbox", 5, panel2, FrontPhotoService.mirrorDirection, coolingType); break;
                case 7: setTabPages("controlbox", 5, panel10, FrontPhotoService.mirrorDirection, coolingType); break;
            }
        }

        /// <summary>
        /// 对addLeftPictureBoxToLeftPanel一层封装
        /// </summary>
        /// <param name="strClassfy"></param>
        /// <param name="imageNum"></param>
        /// <param name="panel"></param>
        private void setTabPages(string strClassfy, int imageNum,Panel panel,string mirrorDirection="mirrorRight",int coolingType=5)
        {
            //List<string> leftImageInstrustion = (new LeftImageInstrustion().getLeftImageInstrustion(strClassfy, imageNum));
            List<string> leftImageInstrustion = GraphicControlService.getGraphicText(strClassfy);
            if (leftImageInstrustion.Count > 0)
            {
                panel.Controls.Clear();
                addLeftPictureBoxToLeftPanel(leftImageInstrustion, panel, strClassfy, mirrorDirection, coolingType);
            }
        }
        //放大功能区
        /// <summary>
        /// 6-27
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zoomOut_Click(object sender, EventArgs e)
        {
            if (FrontPhotoService.factor <= 16)
            {
                imageBoxList = FrontPhotoService.zoomInImangeEntity(imageBoxList, zoomInFactor);
                FrontPhotoService.factor *= zoomInFactor;
                panel3.RowImageEntities = imageBoxList;
            }
        }
        /// <summary>
        /// 每次放大20px,height+10,width+10
        /// </summary>
        /// <param name="pictrueList"></param>
        /// <returns></returns>
        private List<PictureBox> getZoomOutPictureBoxList(List<KeyValuePair<string,PictureBox>> pictureList)
        {
            List<PictureBox> zoomOutList=new List<PictureBox>();
            int upOrDownLocation_Y=getMaxUpOrDownLocation_Y(pictureList);
            if(null!=pictureList&&0<pictureList.Count)
            {
                //upOrDownLocation_Y=pictureList.ElementAt(0).Value.Location.Y;
                for(int i=0,len=pictureList.Count;i<len;i++)
                {
                    PictureBox currentPictureBox=pictureList.ElementAt(i).Value;
                    string pictureName = getPictureBoxToImageName(currentPictureBox.Name);
                    if (upOrDownLocation_Y >currentPictureBox.Location.Y)
                    {
                        //位于上层
                        if (i == 0)
                        {
                            if (RightImageRangeType.imageRangeType.Contains(pictureName))
                            {
                                PictureBox zoomOutPictureBox = getCrossTwoZoomOutPictureBox(currentPictureBox);
                                zoomOutList.Add(zoomOutPictureBox);
                            }
                            else
                            {
                                PictureBox zoomOutPictureBox = getOneUpZoomOutPictureBox(currentPictureBox);
                                zoomOutList.Add(zoomOutPictureBox);
                            } 
                        }
                        else
                        {
                            PictureBox beforePictureBox = getMostRecentZoomOutOrInPictureBox(currentPictureBox, zoomOutList);
                            if (null != beforePictureBox)
                            {
                                PictureBox zoomOutPictureBox = getNextUpZoomOutPictrueBox(beforePictureBox, currentPictureBox);
                                zoomOutList.Add(zoomOutPictureBox);
                            }
                            else
                            {
                                if (RightImageRangeType.imageRangeType.Contains(pictureName))
                                {
                                    PictureBox zoomOutPictureBox = getCrossTwoZoomOutPictureBox(currentPictureBox);
                                    zoomOutList.Add(zoomOutPictureBox);
                                }
                                else
                                {
                                    PictureBox zoomOutPictureBox = getOneUpZoomOutPictureBox(currentPictureBox);
                                    zoomOutList.Add(zoomOutPictureBox);
                                } 
                            }
                        }
                        
                    }
                    else
                    {
                        //位于下层
                        if (i == 0)
                        {
                            PictureBox zoomOutPictureBox = getOneDownZoomOutPictureBox(currentPictureBox);
                            zoomOutList.Add(zoomOutPictureBox);
                        }
                        else
                        {
                            PictureBox beforePictureBox = getMostRecentZoomOutOrInPictureBox(currentPictureBox, zoomOutList);
                            if (null != beforePictureBox)
                            {
                                PictureBox zoomOutPictureBox = getNextDownZoomOutPictrueBox(beforePictureBox, currentPictureBox);
                                zoomOutList.Add(zoomOutPictureBox);
                            }
                            else
                            {
                                PictureBox zoomOutPictureBox = getOneDownZoomOutPictureBox(currentPictureBox);
                                zoomOutList.Add(zoomOutPictureBox);
                            }
                        }
                    }
                }
                return zoomOutList;   
            }
            
            return null;
        }
        /// <summary>
        /// 获得单个要放大的pictureBox
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <returns></returns>
        private PictureBox getOneUpZoomOutPictureBox(PictureBox pictureBox)
        {
            PictureBox zoomOutPictureBox=new PictureBox();
            Point point = new Point(pictureBox.Location.X - ZoomOutAndIn.out_X, pictureBox.Location.Y - ZoomOutAndIn.out_Y);
            zoomOutPictureBox.Location = point;
            zoomOutPictureBox.Width = pictureBox.Width + 2 * ZoomOutAndIn.out_X;
            zoomOutPictureBox.Height = pictureBox.Height + 2 * ZoomOutAndIn.out_Y;
            zoomOutPictureBox.Name = pictureBox.Name;
            Bitmap zoomOutBitmap = new Bitmap(pictureBox.Image, new Size(zoomOutPictureBox.Width, zoomOutPictureBox.Height));
            zoomOutPictureBox.Image = zoomOutBitmap;

            zoomOutPictureBox.MouseDown += new MouseEventHandler(pic_MouseDown);
            zoomOutPictureBox.MouseMove += new MouseEventHandler(pic_MouseMove);
            zoomOutPictureBox.MouseUp += new MouseEventHandler(pic_MouseUp);
            zoomOutPictureBox.Click += new EventHandler(pic_Click);
            return zoomOutPictureBox;
        }
        /// <summary>
        /// 获得下层的一个放大PictureBox
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <returns></returns>
        private PictureBox getOneDownZoomOutPictureBox(PictureBox pictureBox)
        {
            PictureBox zoomOutPictureBox = new PictureBox();
            Point point = new Point(pictureBox.Location.X - ZoomOutAndIn.out_X, pictureBox.Location.Y +ZoomOutAndIn.out_Y);
            zoomOutPictureBox.Location = point;
            zoomOutPictureBox.Width = pictureBox.Width + 2 * ZoomOutAndIn.out_X;
            zoomOutPictureBox.Height = pictureBox.Height + 2 * ZoomOutAndIn.out_Y;
            zoomOutPictureBox.Name = pictureBox.Name;
            Bitmap zoomOutBitmap = new Bitmap(pictureBox.Image, new Size(zoomOutPictureBox.Width, zoomOutPictureBox.Height));
            zoomOutPictureBox.Image = zoomOutBitmap;

            zoomOutPictureBox.MouseDown += new MouseEventHandler(pic_MouseDown);
            zoomOutPictureBox.MouseMove += new MouseEventHandler(pic_MouseMove);
            zoomOutPictureBox.MouseUp += new MouseEventHandler(pic_MouseUp);
            zoomOutPictureBox.Click += new EventHandler(pic_Click);

            return zoomOutPictureBox;
        }
        /// <summary>
        /// 获得贯穿两层的放大pictureBox
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <returns></returns>
        private PictureBox getCrossTwoZoomOutPictureBox(PictureBox pictureBox)
        {
            PictureBox zoomOutPictureBox = new PictureBox();
            Point point = new Point(pictureBox.Location.X - ZoomOutAndIn.out_X, pictureBox.Location.Y - ZoomOutAndIn.out_Y);
            zoomOutPictureBox.Location = point;
            zoomOutPictureBox.Width = pictureBox.Width + 2 * ZoomOutAndIn.out_X;
            zoomOutPictureBox.Height = pictureBox.Height + 4 * ZoomOutAndIn.out_Y;
            zoomOutPictureBox.Name = pictureBox.Name;
            Bitmap zoomOutBitmap = new Bitmap(pictureBox.Image, new Size(zoomOutPictureBox.Width, zoomOutPictureBox.Height));
            zoomOutPictureBox.Image = zoomOutBitmap;

            zoomOutPictureBox.MouseDown += new MouseEventHandler(pic_MouseDown);
            zoomOutPictureBox.MouseMove += new MouseEventHandler(pic_MouseMove);
            zoomOutPictureBox.MouseUp += new MouseEventHandler(pic_MouseUp);
            zoomOutPictureBox.Click+=new EventHandler(pic_Click);
            return zoomOutPictureBox;
        }
        /// <summary>
        /// 根据上一个，放大上层下一个PictureBox
        /// </summary>
        /// <param name="beforePictureBox"></param>
        /// <param name="nextPictureBox"></param>
        /// <returns></returns>
        private PictureBox getNextUpZoomOutPictrueBox(PictureBox beforePictureBox,PictureBox nextPictureBox)
        {
            PictureBox nextZoomOutPictureBox =nextPictureBox;
            string pictureName = getPictureBoxToImageName(nextPictureBox.Name);
            nextZoomOutPictureBox.Location = new Point(beforePictureBox.Location.X + beforePictureBox.Width, beforePictureBox.Location.Y);
            if (RightImageRangeType.imageRangeType.Contains(pictureName))
            {
                nextZoomOutPictureBox.Width += 2 * ZoomOutAndIn.out_X;
                nextZoomOutPictureBox.Height += 4 * ZoomOutAndIn.out_Y;
            }
            else
            {
                nextZoomOutPictureBox.Width += 2 * ZoomOutAndIn.out_X;
                nextZoomOutPictureBox.Height += 2 * ZoomOutAndIn.out_Y;
            }
            nextZoomOutPictureBox.Name = nextPictureBox.Name;
            Bitmap nextZoomOutBitmap=new Bitmap(nextPictureBox.Image,new Size(nextZoomOutPictureBox.Width,nextZoomOutPictureBox.Height));
            nextZoomOutPictureBox.Image = nextZoomOutBitmap;
            

            nextZoomOutPictureBox.MouseDown += new MouseEventHandler(pic_MouseDown);
            nextZoomOutPictureBox.MouseMove += new MouseEventHandler(pic_MouseMove);
            nextZoomOutPictureBox.MouseUp += new MouseEventHandler(pic_MouseUp);
            nextZoomOutPictureBox.Click += new EventHandler(pic_Click);

            return nextZoomOutPictureBox;
        }
        /// <summary>
        /// 根据上一个，放大下层下一个PictureBox
        /// </summary>
        /// <param name="beforePictureBox"></param>
        /// <param name="nextPictureBox"></param>
        /// <returns></returns>
        private PictureBox getNextDownZoomOutPictrueBox(PictureBox beforePictureBox, PictureBox nextPictureBox)
        {
            PictureBox nextZoomOutPictureBox = nextPictureBox;
            nextZoomOutPictureBox.Location = new Point(beforePictureBox.Location.X + beforePictureBox.Width, beforePictureBox.Location.Y);
            nextZoomOutPictureBox.Width += 2 * ZoomOutAndIn.out_X;
            nextZoomOutPictureBox.Height += 2 * ZoomOutAndIn.out_Y;
            nextZoomOutPictureBox.Name = nextPictureBox.Name;
            Bitmap nextZoomOutBitmap = new Bitmap(nextPictureBox.Image, new Size(nextZoomOutPictureBox.Width, nextZoomOutPictureBox.Height));
            nextZoomOutPictureBox.Image = nextZoomOutBitmap;

            nextZoomOutPictureBox.MouseDown += new MouseEventHandler(pic_MouseDown);
            nextZoomOutPictureBox.MouseMove += new MouseEventHandler(pic_MouseMove);
            nextZoomOutPictureBox.MouseUp += new MouseEventHandler(pic_MouseUp);
            nextZoomOutPictureBox.Click += new EventHandler(pic_Click);

            return nextZoomOutPictureBox;
        }
        /// <summary>
        /// 这个和拖动图片的功能函数，稍微有区别，在于要不要返回PictureBox的width,height
        /// </summary>
        /// <param name="tempPbAfter"></param>
        /// <param name="zoomOutList"></param>
        /// <returns></returns>
        private PictureBox getMostRecentZoomOutOrInPictureBox(PictureBox tempPbAfter, List<PictureBox> zoomOutList)
        {
            int min = Int32.MaxValue;
            PictureBox tempPb = null;
            foreach (PictureBox pb in zoomOutList)
            {
                string strDoubleLayers = getPictureBoxToImageName(pb.Name);
                int tempNum = 0;
                //如果是两层控件时要注意，可以将它看成分布在两层的两个控件，下层去他的中间坐标，进行定位，效果不错
                if (RightImageRangeType.imageRangeType.Contains(strDoubleLayers))
                {
                    tempNum = (Math.Abs(pb.Location.X - tempPbAfter.Location.X) + Math.Abs(pb.Location.Y - tempPbAfter.Location.Y));
                    if (min > tempNum)
                    {
                        min = tempNum;
                        tempPb = pb;
                    }
                    tempNum = (Math.Abs(pb.Location.X - tempPbAfter.Location.X) + Math.Abs(pb.Location.Y + pb.Height / 2 - tempPbAfter.Location.Y));
                    if (min > tempNum)
                    {
                        //返回中间的虚拟PictureBox，仅用于坐标定位
                        PictureBox virtualPictureBox = new PictureBox();
                       // virtualPictureBox.Location = new Point(pb.Location.X - 12, pb.Location.Y + pb.Height / 2);
                        virtualPictureBox.Location = new Point(pb.Location.X, pb.Location.Y + pb.Height / 2+2);
                        //两个上下picturebox中间隔4,这个无形也模拟了两个pictureBox，故减去2
                        virtualPictureBox.Height = pb.Height / 2 - 2;
                        virtualPictureBox.Width = pb.Width;
                        min = tempNum;
                        tempPb = virtualPictureBox;
                    }
                }
                else
                {
                    tempNum = (Math.Abs(pb.Location.X - tempPbAfter.Location.X) + Math.Abs(pb.Location.Y - tempPbAfter.Location.Y));
                    if (min > tempNum&&(Math.Abs(pb.Location.Y-tempPbAfter.Location.Y)==ZoomOutAndIn.out_Y))
                    {
                        min = tempNum;
                        tempPb = pb;
                    }
                }
            }
            return tempPb;
        }
        /// <summary>
        /// 绘制放大好的PictureBox
        /// </summary>
        /// <param name="pictureBoxList"></param>
        /// <param name="panel"></param>
        private void paintZoomOutPictureBox(List<PictureBox> pictureBoxList,Panel panel)
        {
            foreach (PictureBox pb in pictureBoxList)
            {
                panel.Controls.Add(pb);
               // MessageBox.Show(pb.Name+":height="+pb.Height+" y="+pb.Location.Y);
            }
        }
        /// <summary>
        /// 获得最大的Location.y，同时也起到了判断是不是两层
        /// </summary>
        /// <param name="pictureBoxList"></param>
        /// <returns></returns>
        private int getMaxUpOrDownLocation_Y(List<KeyValuePair<string,PictureBox>> pictureBoxList)
        {
            int maxValue = Int32.MinValue;
            int minValue = Int32.MaxValue;
            int isTwoLayers = 0;
            if (null != pictureBoxList && 0 < pictureBoxList.Count)
            {
                for (int i = 0, len = pictureBoxList.Count; i < len; i++)
                {
                    if (maxValue < pictureBoxList.ElementAt(i).Value.Location.Y)
                    {
                        maxValue = pictureBoxList.ElementAt(i).Value.Location.Y;      
                    }
                    if(minValue>pictureBoxList.ElementAt(i).Value.Location.Y){
                        minValue = pictureBoxList.ElementAt(i).Value.Location.Y;
                    }
                   
                }
                if (maxValue != Int32.MinValue&&minValue!=Int32.MaxValue && (maxValue - minValue) != 0)
                {
                    isTwoLayers++;
                }
            }
            if (isTwoLayers > 0)
            {
                return maxValue;
            }
            return Int32.MaxValue;
        }
        /// <summary>
        /// 缩小功能区，类似于放大功能去
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void zoomIn_Click(object sender, EventArgs e)
        {
            if (FrontPhotoService.factor >= 0.125)
            {
                imageBoxList = FrontPhotoService.zoomOutImageEntity(imageBoxList, zoomOutFactor);
                FrontPhotoService.factor *= zoomOutFactor;
                panel3.RowImageEntities = imageBoxList;
            }
        }


        private List<PictureBox> getZoomInPictureBoxList(List<KeyValuePair<string, PictureBox>> pictureList)
        {
            List<PictureBox> zoomInList = new List<PictureBox>();
            int upOrDownLocation_Y = getMaxUpOrDownLocation_Y(pictureList);
            if (null != pictureList && 0 < pictureList.Count)
            {
                //upOrDownLocation_Y=pictureList.ElementAt(0).Value.Location.Y;
                for (int i = 0, len = pictureList.Count; i < len; i++)
                {
                    PictureBox currentPictureBox = pictureList.ElementAt(i).Value;
                    string pictureName = getPictureBoxToImageName(currentPictureBox.Name);
                    if (upOrDownLocation_Y > currentPictureBox.Location.Y)
                    {
                        //位于上层
                        if (i == 0)
                        {
                            if (RightImageRangeType.imageRangeType.Contains(pictureName))
                            {
                                PictureBox zoomInPictureBox = getCrossTwoZoomInPictureBox(currentPictureBox);
                                zoomInList.Add(zoomInPictureBox);
                            }
                            {
                                PictureBox zoomInPictureBox = getOneUpZoomInPictureBox(currentPictureBox);
                                zoomInList.Add(zoomInPictureBox);
                            }
                           
                        }
                        else
                        {
                            PictureBox beforePictureBox = getMostRecentZoomOutOrInPictureBox(currentPictureBox, zoomInList);
                            if (null != beforePictureBox)
                            {
                                PictureBox zoomInPictureBox = getNextUpZoomInPictrueBox(beforePictureBox, currentPictureBox);
                                zoomInList.Add(zoomInPictureBox);
                            }
                            else
                            {
                                if (RightImageRangeType.imageRangeType.Contains(pictureName))
                                {
                                    PictureBox zoomInPictureBox = getCrossTwoZoomInPictureBox(currentPictureBox);
                                    zoomInList.Add(zoomInPictureBox);
                                }
                                else
                                {
                                    PictureBox zoomInPictureBox = getOneUpZoomInPictureBox(currentPictureBox);
                                    zoomInList.Add(zoomInPictureBox);
                                } 
                            }
                        }

                    }
                    else
                    {
                        //位于下层
                        if (i == 0)
                        {
                            if (RightImageRangeType.imageRangeType.Contains(currentPictureBox.Name))
                            {
                                PictureBox zoomInPictureBox = getCrossTwoZoomInPictureBox(currentPictureBox);
                                zoomInList.Add(zoomInPictureBox);
                            }
                            else
                            {
                                PictureBox zoomInPictureBox = getOneDownZoomInPictureBox(currentPictureBox);
                                zoomInList.Add(zoomInPictureBox);
                            }
                        }
                        else
                        {
                            PictureBox beforePictureBox = getMostRecentZoomOutOrInPictureBox(currentPictureBox, zoomInList);
                            if (null != beforePictureBox)
                            {
                                PictureBox zoomInPictureBox = getNextDownZoomInPictrueBox(beforePictureBox, currentPictureBox);
                                zoomInList.Add(zoomInPictureBox);
                            }
                            else
                            {
                                if (RightImageRangeType.imageRangeType.Contains(currentPictureBox.Name))
                                {
                                    PictureBox zoomInPictureBox = getCrossTwoZoomInPictureBox(currentPictureBox);
                                    zoomInList.Add(zoomInPictureBox);
                                }
                                else
                                {
                                    PictureBox zoomInPictureBox = getOneDownZoomInPictureBox(currentPictureBox);
                                    zoomInList.Add(zoomInPictureBox);
                                }  
                            }
                        }
                    }
                }
                return zoomInList;
            }

            return null;
        }

        /// <summary>
        /// 获得单个要缩小的pictureBox
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <returns></returns>
        private PictureBox getOneUpZoomInPictureBox(PictureBox pictureBox)
        {
            PictureBox zoomInPictureBox = new PictureBox();
            Point point = new Point(pictureBox.Location.X + ZoomOutAndIn.in_X, pictureBox.Location.Y + ZoomOutAndIn.in_Y);
            zoomInPictureBox.Location = point;
            zoomInPictureBox.Width = pictureBox.Width - 2 * ZoomOutAndIn.out_X;
            zoomInPictureBox.Height = pictureBox.Height - 2 * ZoomOutAndIn.out_Y;
            zoomInPictureBox.Name = pictureBox.Name;
            Bitmap zoomOutBitmap = new Bitmap(pictureBox.Image, new Size(zoomInPictureBox.Width, zoomInPictureBox.Height));
            zoomInPictureBox.Image = zoomOutBitmap;

            zoomInPictureBox.MouseDown += new MouseEventHandler(pic_MouseDown);
            zoomInPictureBox.MouseMove += new MouseEventHandler(pic_MouseMove);
            zoomInPictureBox.MouseUp += new MouseEventHandler(pic_MouseUp);
            zoomInPictureBox.Click += new EventHandler(pic_Click);
            return zoomInPictureBox;
        }

        /// <summary>
        /// 获得下层的一个缩小PictureBox
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <returns></returns>
        private PictureBox getOneDownZoomInPictureBox(PictureBox pictureBox)
        {
            PictureBox zoomInPictureBox = new PictureBox();
            Point point = new Point(pictureBox.Location.X + ZoomOutAndIn.out_X, pictureBox.Location.Y - ZoomOutAndIn.out_Y);
            zoomInPictureBox.Location = point;
            zoomInPictureBox.Width = pictureBox.Width - 2 * ZoomOutAndIn.out_X;
            zoomInPictureBox.Height = pictureBox.Height - 2 * ZoomOutAndIn.out_Y;
            zoomInPictureBox.Name = pictureBox.Name;
            Bitmap zoomOutBitmap = new Bitmap(pictureBox.Image, new Size(zoomInPictureBox.Width, zoomInPictureBox.Height));
            zoomInPictureBox.Image = zoomOutBitmap;

            zoomInPictureBox.MouseDown += new MouseEventHandler(pic_MouseDown);
            zoomInPictureBox.MouseMove += new MouseEventHandler(pic_MouseMove);
            zoomInPictureBox.MouseUp += new MouseEventHandler(pic_MouseUp);
            zoomInPictureBox.Click += new EventHandler(pic_Click);
            return zoomInPictureBox;
        }

        /// <summary>
        /// 获得贯穿两层的缩小pictureBox
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <returns></returns>
        private PictureBox getCrossTwoZoomInPictureBox(PictureBox pictureBox)
        {
            PictureBox zoomInPictureBox = new PictureBox();
            Point point = new Point(pictureBox.Location.X + ZoomOutAndIn.in_X, pictureBox.Location.Y + ZoomOutAndIn.in_Y);
            zoomInPictureBox.Location = point;
            zoomInPictureBox.Width = pictureBox.Width - 2 * ZoomOutAndIn.in_X;
            zoomInPictureBox.Height = pictureBox.Height - 4 * ZoomOutAndIn.in_Y;
            zoomInPictureBox.Name = pictureBox.Name;
            Bitmap zoomInBitmap = new Bitmap(pictureBox.Image, new Size(zoomInPictureBox.Width, zoomInPictureBox.Height));
            zoomInPictureBox.Image = zoomInBitmap;

            zoomInPictureBox.MouseDown += new MouseEventHandler(pic_MouseDown);
            zoomInPictureBox.MouseMove += new MouseEventHandler(pic_MouseMove);
            zoomInPictureBox.MouseUp += new MouseEventHandler(pic_MouseUp);
            zoomInPictureBox.Click += new EventHandler(pic_Click);
            return zoomInPictureBox;
        }

        /// <summary>
        /// 根据上一个，缩小上层下一个PictureBox
        /// </summary>
        /// <param name="beforePictureBox"></param>
        /// <param name="nextPictureBox"></param>
        /// <returns></returns>
        private PictureBox getNextUpZoomInPictrueBox(PictureBox beforePictureBox, PictureBox nextPictureBox)
        {
            PictureBox nextZoomInPictureBox = nextPictureBox;
            string pictureName = getPictureBoxToImageName(nextPictureBox.Name);
            nextZoomInPictureBox.Location = new Point(beforePictureBox.Location.X + beforePictureBox.Width, beforePictureBox.Location.Y);
            if (RightImageRangeType.imageRangeType.Contains(pictureName))
            {
                nextZoomInPictureBox.Width -= 2 * ZoomOutAndIn.out_X;
                nextZoomInPictureBox.Height -= 4 * ZoomOutAndIn.out_Y;
            }
            else
            {
                nextZoomInPictureBox.Width -= 2 * ZoomOutAndIn.out_X;
                nextZoomInPictureBox.Height -= 2 * ZoomOutAndIn.out_Y;
            }
            nextZoomInPictureBox.Name = nextPictureBox.Name;
            Bitmap nextZoomInBitmap = new Bitmap(nextPictureBox.Image, new Size(nextZoomInPictureBox.Width, nextZoomInPictureBox.Height));
            nextZoomInPictureBox.Image = nextZoomInBitmap;


            nextZoomInPictureBox.MouseDown += new MouseEventHandler(pic_MouseDown);
            nextZoomInPictureBox.MouseMove += new MouseEventHandler(pic_MouseMove);
            nextZoomInPictureBox.MouseUp += new MouseEventHandler(pic_MouseUp);
            nextZoomInPictureBox.Click += new EventHandler(pic_Click);

            return nextZoomInPictureBox;
        }
        /// <summary>
        /// 根据上一个，缩小下层下一个PictureBox
        /// </summary>
        /// <param name="beforePictureBox"></param>
        /// <param name="nextPictureBox"></param>
        /// <returns></returns>
        private PictureBox getNextDownZoomInPictrueBox(PictureBox beforePictureBox, PictureBox nextPictureBox)
        {
            PictureBox nextZoomInPictureBox = nextPictureBox;
            string pictureName = getPictureBoxToImageName(nextPictureBox.Name);
            nextZoomInPictureBox.Location = new Point(beforePictureBox.Location.X + beforePictureBox.Width, beforePictureBox.Location.Y);
            if (RightImageRangeType.imageRangeType.Contains(pictureName))
            {
                nextZoomInPictureBox.Width -= 2 * ZoomOutAndIn.out_X;
                nextZoomInPictureBox.Height -= 4 * ZoomOutAndIn.out_Y;
            }
            else
            {
                nextZoomInPictureBox.Width -= 2 * ZoomOutAndIn.out_X;
                nextZoomInPictureBox.Height -= 2 * ZoomOutAndIn.out_Y;
            }    
            nextZoomInPictureBox.Name = nextPictureBox.Name;
            Bitmap nextZoomOutBitmap = new Bitmap(nextPictureBox.Image, new Size(nextZoomInPictureBox.Width, nextZoomInPictureBox.Height));
            nextZoomInPictureBox.Image = nextZoomOutBitmap;

            nextZoomInPictureBox.MouseDown += new MouseEventHandler(pic_MouseDown);
            nextZoomInPictureBox.MouseMove += new MouseEventHandler(pic_MouseMove);
            nextZoomInPictureBox.MouseUp += new MouseEventHandler(pic_MouseUp);
            nextZoomInPictureBox.Click += new EventHandler(pic_Click);
            return nextZoomInPictureBox;
        }

        /// <summary>
        /// 绘制缩小好的PictureBox
        /// </summary>
        /// <param name="pictureBoxList"></param>
        /// <param name="panel"></param>
        private void paintZoomInPictureBox(List<PictureBox> pictureBoxList, Panel panel)
        {
            foreach (PictureBox pb in pictureBoxList)
            {
                panel.Controls.Add(pb);
                // MessageBox.Show(pb.Name+":height="+pb.Height+" y="+pb.Location.Y);
            }
        }
        /// <summary>
        /// 左右移动功能区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftMove_Click(object sender, EventArgs e)
        {
            if(!mirrorLeft){
                FrontPhotoService.mirrorDirection = "mirrorLeft";
                refreshedByModAhUint(tagIndex);
                imageBoxList = FrontPhotoService.calculateMirrorPosition(imageBoxList, panel3.Width);
                panel3.RowImageEntities = imageBoxList;
                panel3.Invalidate();
            }
           //右边镜像可以操作
            mirrorLeft = true;
            mirrorRight = false;
         
        }

        //左右移动函数
        private void leftMoveAndrightMovePicture(string leftOrRight,PictureBox currentSelectedBox)
        {
            if (rightPictureBoxDictionary != null && rightPictureBoxDictionary.Count > 0)
            {
                // panel3.Controls.Clear();
                List<KeyValuePair<string, PictureBox>> tempPaintImageList = getPaintImageList(rightPictureBoxDictionary);
                List<PictureBox> movePictureList = getMovePictureList(leftOrRight, currentSelectedBox, tempPaintImageList);
                if (0 < movePictureList.Count)
                {
                    bottomPanel.Controls.Clear();
                }
                for (int i = 0,len=movePictureList.Count; i <len ;i++ )
                {
                    bottomPanel.Controls.Add(movePictureList.ElementAt(i));
                }
            }
        }
        //移动后的列表
        private List<PictureBox> getMovePictureList(string leftOrRight,PictureBox currentSelectedBox,List<KeyValuePair<string,PictureBox>> tempPaintImageList)
        {
            List<PictureBox> movePictureList = new List<PictureBox>();
            if (leftOrRight.Equals("leftMove"))
            {
                for(int i=0;i<tempPaintImageList.Count;i++){
                    PictureBox tempPictureBox=tempPaintImageList.ElementAt(i).Value;
                    movePictureList.Add(tempPictureBox);
                    if (currentSelectedBox.Location.X.Equals(tempPictureBox.Location.X) && currentSelectedBox.Location.Y.Equals(tempPictureBox.Location.Y)) 
                    {
                        if (i > 0)
                        {
                            PictureBox tempBeforePictureBox = movePictureList.ElementAt(i - 1);
                            PictureBox tempCurrentSecletedBox=new PictureBox();
                            tempCurrentSecletedBox.Height = currentSelectedBox.Height;
                            tempCurrentSecletedBox.Width = currentSelectedBox.Width;
                            tempCurrentSecletedBox.Image=currentSelectedBox.Image;
                            tempCurrentSecletedBox.Name=currentSelectedBox.Name;
                            tempCurrentSecletedBox.Location = currentSelectedBox.Location;
                            if (tempBeforePictureBox.Location.Y.Equals(currentSelectedBox.Location.Y))
                            {
                                currentSelectedBox.Location = tempBeforePictureBox.Location;
                                movePictureList[i - 1] = currentSelectedBox;
                                tempBeforePictureBox.Location = tempCurrentSecletedBox.Location;
                                movePictureList[i] = tempBeforePictureBox;
                            }
                            else
                            {
                                if (i > 1)
                                {
                                    PictureBox tempMoreBeforePictureBox = movePictureList.ElementAt(i - 2);
                                    if (currentSelectedBox.Location.Y.Equals(tempMoreBeforePictureBox.Location.Y))
                                    {
                                        currentSelectedBox.Location = tempMoreBeforePictureBox.Location;
                                        movePictureList[i - 2] = currentSelectedBox;
                                        tempMoreBeforePictureBox.Location = tempCurrentSecletedBox.Location;
                                        movePictureList[i] = tempMoreBeforePictureBox;
                                    }
                                }
                            }
                        }
                    }
                }

            }
            else if (leftOrRight.Equals("rightMove"))
            {
                for (int i = 0; i < tempPaintImageList.Count; i++)
                {
                    PictureBox tempPictureBox = tempPaintImageList.ElementAt(i).Value;
                    movePictureList.Add(tempPictureBox);
                    if (currentSelectedBox.Location.X.Equals(tempPictureBox.Location.X) && currentSelectedBox.Location.Y.Equals(tempPictureBox.Location.Y))
                    {
                        if (i<tempPaintImageList.Count-1)
                        {
                            PictureBox tempAfterPictureBox = tempPaintImageList.ElementAt(i+1).Value;
                            PictureBox tempCurrentSecletedBox = new PictureBox();
                            tempCurrentSecletedBox.Height = currentSelectedBox.Height;
                            tempCurrentSecletedBox.Width = currentSelectedBox.Width;
                            tempCurrentSecletedBox.Image = currentSelectedBox.Image;
                            tempCurrentSecletedBox.Name = currentSelectedBox.Name;
                            tempCurrentSecletedBox.Location = currentSelectedBox.Location;
                            if (tempAfterPictureBox.Location.Y.Equals(currentSelectedBox.Location.Y))
                            {
                                currentSelectedBox.Location = tempAfterPictureBox.Location;
                                if (movePictureList.Count == i + 1)
                                {
                                    //插入最后一个位置
                                    movePictureList.Insert(i + 1, currentSelectedBox);
                                } 
                                else{
                                    movePictureList[i+1]=currentSelectedBox;
                                }
                                tempAfterPictureBox.Location = tempCurrentSecletedBox.Location;
                                movePictureList[i] = tempAfterPictureBox;
                            }
                            else
                            {
                                if (i < tempPaintImageList.Count-2)
                                {
                                    PictureBox tempMoreAfterPictureBox = tempPaintImageList.ElementAt(i + 2).Value;
                                    if (currentSelectedBox.Location.Y.Equals(tempMoreAfterPictureBox.Location.Y))
                                    {
                                        currentSelectedBox.Location = tempMoreAfterPictureBox.Location;
                                        if (movePictureList.Count == i + 2)
                                        {
                                            movePictureList.Insert(i + 2, currentSelectedBox);
                                        }
                                        else
                                        {
                                            movePictureList[i + 2] = currentSelectedBox;
                                        }
                                        tempMoreAfterPictureBox.Location = tempCurrentSecletedBox.Location;
                                        movePictureList[i] = tempMoreAfterPictureBox;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return movePictureList;
        }

        private void rightMove_Click(object sender, EventArgs e)
        {
            if(!mirrorRight){
                FrontPhotoService.leftStartX = panel3.Width - 300;
                FrontPhotoService.mirrorDirection = "mirrorRight";
                refreshedByModAhUint(tagIndex);
                imageBoxList = FrontPhotoService.calculateMirrorPosition(imageBoxList, panel3.Width);
                panel3.Invalidate();
            }
            //左边镜像按钮可以操作
            mirrorLeft = false;
            mirrorRight = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DxfDocument dxf = new DxfDocument();
            DxfModel dxf = new DxfModel(DxfVersion.Dxf15);
            //缩放到真实比例
            List<ImageEntity> dxfPaintImageBoxList = new List<ImageEntity>();
            for (int i = 0; i < imageBoxList.Count;i++ )
            {
                ImageEntity dxfPaintEntity = new ImageEntity();
                dxfPaintEntity.Name = imageBoxList.ElementAt(i).Name;
                dxfPaintEntity.Rect = imageBoxList.ElementAt(i).Rect;
                dxfPaintEntity.Type = imageBoxList.ElementAt(i).Type;
                dxfPaintEntity.Url = imageBoxList.ElementAt(i).Url;
                dxfPaintEntity.Text = imageBoxList.ElementAt(i).Text;
                dxfPaintEntity.firstDistance = imageBoxList.ElementAt(i).firstDistance;
                dxfPaintEntity.secondDistance = imageBoxList.ElementAt(i).secondDistance;
                dxfPaintEntity.coolingType = imageBoxList.ElementAt(i).coolingType;
                dxfPaintImageBoxList.Add(dxfPaintEntity);
            }
                dxfPaintImageBoxList = FrontPhotoService.zoomOutImageEntity(dxfPaintImageBoxList, 1 / FrontPhotoService.factor);         
            List<PictureBoxInfo> dxfReflectPictureNameList = new List<PictureBoxInfo>();
            for (int i = 0, len = dxfPaintImageBoxList.Count; i < len; i++)
            {
                ImageEntity imageEntity = dxfPaintImageBoxList.ElementAt(i);
                if(imageEntity.Name!="virtualHRA"){
                     PictureBoxInfo pbi = new PictureBoxInfo();
                //pbi.location = new Location(tempDxfRelectPictureBox.Location.X,tempDxfRelectPictureBox.Location.Y,0);
                     pbi.DLocation = new DLocation(imageEntity.Rect.X, imageEntity.Rect.Y, 0);
                     pbi.height = imageEntity.Rect.Height;
                     pbi.width = imageEntity.Rect.Width;
                     pbi.name = imageEntity.Name;
                     pbi.text = TextSplitService.textSplit(imageEntity.Text);
                     pbi.firstDistance = imageEntity.firstDistance;
                     pbi.secondDistance = imageEntity.secondDistance;
                     pbi.coolingType = imageEntity.coolingType;
                     dxfReflectPictureNameList.Add(pbi);
                }
            }

            //dxfReflectPictureNameList = FrontPhotoService.getRanglePictureInfoList(dxfReflectPictureNameList);

            DataCenter dataCenter = new DataCenter();
            dataCenter.SectionEntity = new SectionEntity("40", "60");
            dataCenter.OrderEntity = new OrderEntity("jobname", "unittag");
            dataCenter.Configurations = new List<string>()
            {
                "baby baby one more time",
                "baby baby one more time",
                "baby baby one more time",
                "baby baby one more time"
            };
            dataCenter.detailMechineConfigure=new DetailMechineConfigure(dxfReflectPictureNameList,
                 new string[] { "hello", "world", "helloworld" }, 44.0f, 18, 2.0f, 2.86f, 2.0f, 2.0f);
            dataCenter.topViewConfigure = new TopViewConfigure(dxfReflectPictureNameList, dxf, null, 50.0f, 18.0f, 2.0f, 2.86f, 2.0f, 2.0f);
            
            
            //float totalWidth = TotalWidthAndHeight.getWidth(dxfReflectPictureNameList);
            double totalWidth = TotalWidthAndHeight.getWidth(dxfReflectPictureNameList);
            if (AssembleDetailMechine.isTwoLayers(dxfReflectPictureNameList)!=-1)
            {
                //float[] upOrDownHeightOrViewHieght = new float[3];
                double[] upOrDownHeightOrViewHieght = new double[3];
                upOrDownHeightOrViewHieght = TotalWidthAndHeight.getEachLayerHight(dxfReflectPictureNameList);
                dataCenter.BoxEntity = new BoxEntity { DownHeight = upOrDownHeightOrViewHieght[0], UpHeight = upOrDownHeightOrViewHieght[1], Width = totalWidth, TopViewHeight = upOrDownHeightOrViewHieght[2], IsLeft = false };
            }
            else
            {
                //float[] upOrDownHeightOrViewHieght = new float[3];
                double[] upOrDownHeightOrViewHieght = new double[3];
                upOrDownHeightOrViewHieght = TotalWidthAndHeight.getEachLayerHight(dxfReflectPictureNameList);
                dataCenter.BoxEntity = new BoxEntity { DownHeight = upOrDownHeightOrViewHieght[0], UpHeight = 0, Width = totalWidth, TopViewHeight = upOrDownHeightOrViewHieght[2], IsLeft = false };
            }
            
            OuterBox outerBox = new OuterBox();
            outerBox.dataCenter = dataCenter;
            //outerBox.Draw(dxf, new Location(500, 500), 306, 188, dxfReflectPictureNameList,5);
            outerBox.Draw(dxf, new DLocation(FrontPhotoService.leftStartX, FrontPhotoService.leftStartY), 306, 188, dxfReflectPictureNameList, 5);

            //dxf.Save("AutoCad2007.dxf", DxfVersion.AutoCad2007);
            //dxf.Save("AutoCad2004.dxf", DxfVersion.AutoCad2004);
            //dxf.Save("AutoCad2000.dxf", DxfVersion.AutoCad2000);
            //dxf.Save("AutoCad12.dxf", DxfVersion.AutoCad12);

            DxfWriter.Write("DxfWriteExample-R15-ascii.dxf", dxf, false);
            DxfWriter.Write("DxfWriteExample-R15-bin.dxf", dxf, true);

            DxfViewer dv = new DxfViewer();
            dv.setDxfFile("DxfWriteExample-R15-ascii.dxf");
            dv.Show();

            //MessageBox.Show("图纸生成成功！");
        }

        void createImageBox(PictureBox pictureBox, int coolingType)
        {
            ImageBlock imageBlock = ImageBlockBLL.getImageBlocksByNames(pictureBox.Name, coolingType);
            int imageWidth = Convert.ToInt32(imageBlock.ImageLength * FrontPhotoService.factor);

            int imageHeight = Convert.ToInt32(imageBlock.ImageHeight * FrontPhotoService.factor);
            if (RightImageRangeType.imageRangeTypeArray[0].Equals(pictureBox.Name))
            {
                imageHeight = Convert.ToInt32((imageBlock.ImageHeight - 2) * FrontPhotoService.factor) + 2;
            }
            //将绘制的图像对象添加到ImageBoxList中
            string imagePath = ImageBoxService.getImageUrl(pictureBox.Name);
            string imageEntityText = imageBlock.Text;
            //这里从数据空获得，数据还没提供
            double firstDistance = imageBlock.FirstDistance;
            double secondDistance = imageBlock.SecondDistance;
            int imageEntityCoolingType = coolingType;
            bool isSelected = false;
            string parentName = imageBlock.ParentName;
            string gUid =  Guid.NewGuid().ToString("N");
            leftTopImageBoxList.Add(new ImageEntity {Guid=gUid, 
                Name = pictureBox.Name, 
                Url = imagePath, 
                Rect = new Rectangle(0, 0, imageWidth, imageHeight),
                Type = "over", 
                Text = imageEntityText,
                firstDistance = firstDistance, 
                secondDistance = secondDistance, 
                coolingType = imageEntityCoolingType, 
                isSelected = isSelected,
                moduleTag = "", 
                parentName = imageBlock.ParentName });
            panel3.OverImageEntities = leftTopImageBoxList;

        }

        private void panel3_OnEntityMove(ImageEntity srcEntity, ImageEntity destEntity)
        {
            if (srcEntity.Type == "row")
            {
                //removeListImageEntity(imageBoxList, srcEntity);
                if (FrontPhotoService.mirrorDirection.Equals("mirrorRight"))
                {
                    FrontPhotoService.leftStartX = panel3.Width - 300;
                    imageBoxList = FrontPhotoService.calculateImageEntityPosition(imageBoxList, srcEntity, destEntity, "mirrorRight");
                }
                else
                {
                    FrontPhotoService.leftStartX = 200;
                    imageBoxList = FrontPhotoService.calculateImageEntityPosition(imageBoxList, srcEntity, destEntity, "mirrorLeft");
                }
                
                //  panel3.Invalidate();
                panel3.RowImageEntities = imageBoxList;
            }
            else if (srcEntity.Type == "over")
            {
                if (srcEntity.Rect.X != destEntity.Rect.X || srcEntity.Rect.Y != destEntity.Rect.Y)
                {
                    if (FrontPhotoService.mirrorDirection.Equals("mirrorRight"))
                    {
                        FrontPhotoService.leftStartX = panel3.Width - 300;
                        leftTopImageBoxList = FrontPhotoService.removeListImageEntity(leftTopImageBoxList, srcEntity);
                        imageBoxList = FrontPhotoService.calculateImageEntityPosition(imageBoxList, srcEntity, destEntity, "mirrorRight");
                    }
                    else
                    {
                        FrontPhotoService.leftStartX = 200;
                        leftTopImageBoxList = FrontPhotoService.removeListImageEntity(leftTopImageBoxList, srcEntity);
                        imageBoxList = FrontPhotoService.calculateImageEntityPosition(imageBoxList, srcEntity, destEntity, "mirrorLeft");
                    }
                    
                    panel3.RowImageEntities = imageBoxList;
                }          
            }
        }

        void panel3_OnEntityDBClick(ImageEntity imageEntity)
        {
            for (int i = 0; i < imageBoxList.Count; i++)
            {
                if (imageEntity.Rect.X == imageBoxList.ElementAt(i).Rect.X && imageEntity.Rect.Y == imageBoxList.ElementAt(i).Rect.Y && imageEntity.Name == imageBoxList.ElementAt(i).Name)
                {
                    imageBoxList.ElementAt(i).isSelected = true;
                }
                else
                {
                    imageBoxList.ElementAt(i).isSelected = false;
                }
            }
            panel3.RowImageEntities = imageBoxList;
            panel3.Invalidate();
              
        }

        void panel3_OnEntityClick(ImageEntity imageEntity)
        {
            for (int i = 0; i < imageBoxList.Count; i++)
            {
                if (imageEntity.Rect.X == imageBoxList.ElementAt(i).Rect.X && imageEntity.Rect.Y == imageBoxList.ElementAt(i).Rect.Y && imageEntity.Name == imageBoxList.ElementAt(i).Name)
                {
                    imageBoxList.ElementAt(i).isSelected = true;
                }
                else
                {
                    imageBoxList.ElementAt(i).isSelected = false;
                }
            }
            panel3.RowImageEntities = imageBoxList;
            panel3.Invalidate();
        }
        //约束检查
        private void btn_FinalCheck_Click(object sender, EventArgs e)
        {
            string message = null;
            if(FrontPhotoConstraintService.isControlBoxStartEnd(imageBoxList)){
                message += "Control Box Can Not be Placed at Unit End Position" + "\n";
            }
            if(FrontPhotoConstraintService.isUpLayerExceedDownLayer(imageBoxList)){
                message += "Module Position Error"+"\n";
            }
            if(FrontPhotoConstraintService.isMustChoiceControlBox(imageBoxList)){
                message += "Control Box Needed for this Application"+"\n";
            }
            if(FrontPhotoConstraintService.isMixingExistFanRight(imageBoxList)){
                message += "Fan Selection Not Recommended"+"\n";
            }
            if (message != null)
                MessageBox.Show(message, "UNIT ERROR");
            else
                MessageBox.Show("No Error Found","UNIT ERROR");
        }

        private void btn_UnitBasic_Click(object sender, EventArgs e)
        {
            ModAHUnit mhu = new ModAHUnit();
            mhu.InitialForm(FrontPhotoImageModelService.orderSale, this);
            mhu.ShowDialog();
            //new ModuleDetail().Show();
        }

        public void setOperatePhotoNeedData(OperatePhotoNeedData operatePhotoNeedData,int orderSale=-1)
        {
            coolingType = Convert.ToInt32(operatePhotoNeedData.unitSize);
            FrontPhotoImageModelService.orderId=operatePhotoNeedData.orderID;
            FrontPhotoImageModelService.orderSale = orderSale;
        }

        private void btn_ModuleDetail_Click(object sender, EventArgs e)
        {
            new ModuleDetail(FrontPhotoImageModelService.getImageModelList(imageBoxList)).ShowDialog();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                int flag1=ImageModelBLL.insertList(FrontPhotoImageModelService.getImageModelList(imageBoxList));
                int flag2 = OrderDetailBLL.InsertOD(FrontPhotoImageModelService.orderSale, FrontPhotoImageModelService.orderId,"M"+FrontPhotoImageModelService.orderSale+ "-"+FrontPhotoImageModelService.orderId);
                if (flag1 > 0&&flag2>0)
                {
                    //MessageBox.Show("save success!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("save fail!");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("Save Fail");
            }
            
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr=MessageBox.Show("Save Unit Information?","Close Unit",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if(dr==DialogResult.OK){
                try
                {
                    int flag1 = ImageModelBLL.insertList(FrontPhotoImageModelService.getImageModelList(imageBoxList));
                    //int flag2 = OrderDetailBLL.InsertOrderDetail(Front);
                    if (flag1 > 0)
                    {
                        //MessageBox.Show("save success!");
                    }
                    else
                    {
                        MessageBox.Show("save fail!");
                    }
                    this.Close();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Save Fail");
                }
            }
            this.Close();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (imageBoxList.ElementAt(0).Name.Equals("virtualHRA") && imageBoxList.Count == 2)
            {
                MessageBox.Show("Cann't delete the last one!");
                return;
            }
           else if (imageBoxList.Count == 1)
            {
                MessageBox.Show("Cann't delete the last one!");
                return;
            }
           
            ImageEntity deleteImageEntity = new ImageEntity();
            for (int i = 0; i < imageBoxList.Count; i++)
            {

                if (imageBoxList.ElementAt(i).isSelected)
                {
                    deleteImageEntity = imageBoxList.ElementAt(i);
                }               
            }
           imageBoxList=FrontPhotoService.deleteImageEntityPosition(imageBoxList, deleteImageEntity, "mirrorRight");
            panel3.RowImageEntities = imageBoxList;
           
            panel3.Invalidate();
        }
        //这个有点难
        private void btn_Center_Click(object sender, EventArgs e)
        {

        }

        private void btn_LeftAlignment_Click(object sender, EventArgs e)
        {

        }

        private void btn_RightAlignment_Click(object sender, EventArgs e)
        {

        }
    }
}
