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
using EntityFrameworkTryBLL.UnitManager;
using Model.Order;

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
            if (FrontPhotoImageModelService.route.Equals("AAnonRating"))
            {
                imageBoxList = FrontPhotoImageModelService.imageEntityFromAAonRatingList;
                
            }
            else
            {
                imageBoxList = FrontPhotoService.initSingleLayerOPeratorPhoto(imageBoxList, coolingType);
            }
            //设置右上角信息
           downImageEnityList = FrontPhotoService.getDownList(imageBoxList);
           FrontPhotoService.initRightTopInformation(FrontPhotoImageModelService.operatePhotoNeedData, downImageEnityList,imageBoxList, coolingType);
           rightTopInfoList = FrontPhotoService.getTopRightEquipmentInformation(FrontPhotoService.productionDescription, FrontPhotoService.downTotalLength, FrontPhotoService.totalHeight, FrontPhotoService.imageWidth);


           panel3.RowImageEntities = imageBoxList;
           panel3.TopRightInfo = rightTopInfoList;
           panel3.OnEntityClick += new CustomForm.EntityClicked(panel3_OnEntityClick);
           panel3.OnEntityDBClick += new CustomForm.EntityDBClicked(panel3_OnEntityDBClick);


          // panel3.MouseDown += new MouseEventHandler(panel3_MouseDown);
        }
    

      

         private bool pictureBox1Flag{ set; get; }
        private bool pictureBox2Flag { set; get; }
        private Dictionary<string, PictureBox> leftPictureBoxDictionary = new Dictionary<string, PictureBox>();
        private Dictionary<string, Label> leftLabelDictionary = new Dictionary<string, Label>();

        //2012-7-20 begin
        private List<ImageEntity> imageBoxList = new List<ImageEntity>();
        private List<ImageEntity> leftTopImageBoxList = new List<ImageEntity>();
        private List<ImageEntity> downImageEnityList = new List<ImageEntity>();
        //信息说明
        private List<string> rightTopInfoList = new List<string>();
        private List<string> centerTopInfoList = new List<string>();
         //放大缩小因子
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


        //add和replace切换参数
        bool isAddOrReplace = false;


        
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
            if (tabControl1.SelectedIndex == 0)
            {
                createImageBox(pb, coolingType);
                tabControl1.SelectedIndex = 1;
                tab_Replace.SelectedIndex = tabControlEx1.SelectedIndex;
                reFreshEdByReplace(tabControlEx1.SelectedIndex);
                isAddOrReplace = true;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                ImageEntity imageEntity = getReplaceImageEntity(pb, coolingType);
                int flag1 = FrontPhotoService.getIsExistSelected(leftTopImageBoxList);
                int flag2 = FrontPhotoService.getIsExistSelected(imageBoxList);
                if (flag2 >= 0)
                {
                    imageBoxList = FrontPhotoService.replaceCurrent(imageBoxList, imageEntity, FrontPhotoService.mirrorDirection);
                    panel3.RowImageEntities = imageBoxList;
                }
                else if (flag1 >= 0)
                {
                    leftTopImageBoxList = FrontPhotoService.replaceLeftTopCurrent(leftTopImageBoxList, imageEntity);
                    panel3.OverImageEntities = leftTopImageBoxList;
                }
            }
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
            if (tabControl1.SelectedIndex == 0)
            {
                createImageBox(pb, coolingType);
                tabControl1.SelectedIndex = 1;
                tab_Replace.SelectedIndex = tabControlEx1.SelectedIndex;
                reFreshEdByReplace(tabControlEx1.SelectedIndex);
                isAddOrReplace = true;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                ImageEntity imageEntity = getReplaceImageEntity(pb,coolingType);
                //这里判断是imageBoxLis被选中，还是leftTopImageBoxList
                int flag1 = FrontPhotoService.getIsExistSelected(leftTopImageBoxList);
                int flag2 = FrontPhotoService.getIsExistSelected(imageBoxList);
                if(flag2>=0){
                    imageBoxList = FrontPhotoService.replaceCurrent(imageBoxList, imageEntity,FrontPhotoService.mirrorDirection);
                     panel3.RowImageEntities = imageBoxList;
                }
                else if(flag1>=0){
                    leftTopImageBoxList = FrontPhotoService.replaceLeftTopCurrent(leftTopImageBoxList, imageEntity);
                    panel3.OverImageEntities = leftTopImageBoxList;
                }
                
            }
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


        //Add的更新函数
        public void refreshedByModAhUint(int tagIndex)
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
        //replace更新函数
        public void reFreshEdByReplace(int tagIndex)
        {
            
            switch (tagIndex)
            {
                case 0: setTabPages("filter", 4, panel11, FrontPhotoService.mirrorDirection, coolingType); break;
                case 1: setTabPages("hrwheel", 1, panel12, FrontPhotoService.mirrorDirection, coolingType); break;
                case 2: setTabPages("mixbox", 10, panel13, FrontPhotoService.mirrorDirection, coolingType); break;
                case 3: setTabPages("heat", 4, panel14, FrontPhotoService.mirrorDirection, coolingType); break;
                case 4: setTabPages("coil", 6, panel15, FrontPhotoService.mirrorDirection, coolingType); break;
                case 5: setTabPages("fanbox", 6, panel16, FrontPhotoService.mirrorDirection, coolingType); break;
                case 6: setTabPages("blankbox", 5, panel17, FrontPhotoService.mirrorDirection, coolingType); break;
                case 7: setTabPages("controlbox", 5, panel18, FrontPhotoService.mirrorDirection, coolingType); break;
            }
        }

        //coolingType变化时刷新右边面板的,这里的imageBoxList是全局的
        public void reFreshRightPanelByCoolingType(int coolingType)
        {
            for (int i = 0; i < imageBoxList.Count;i++ )
            {
                ImageEntity imageEntityByCoolingType=imageBoxList.ElementAt(i);
                ImageBlock imageBlock=ImageBlockBLL.getImageBlocksByNames(imageEntityByCoolingType.Name,coolingType);
                int tempHeight = 0;
                if (imageBoxList.ElementAt(i).Equals("HRA"))
                {
                    tempHeight = Convert.ToInt32((imageBlock.ImageHeight - 2) * FrontPhotoService.factor + 2);
                }
                else if (imageBoxList.ElementAt(0).Equals("virtualHRA"))
                {
                    tempHeight = Convert.ToInt32((imageBlock.ImageHeight - 2) / 2 * FrontPhotoService.factor);
                }
                else
                {
                    tempHeight = Convert.ToInt32(imageBlock.ImageHeight * FrontPhotoService.factor);
                }

                imageEntityByCoolingType.Rect = new Rectangle(imageEntityByCoolingType.Rect.X, imageEntityByCoolingType.Rect.Y, Convert.ToInt32(imageBlock.ImageLength*FrontPhotoService.factor), tempHeight);
            }
            imageBoxList = FrontPhotoService.calculatePositionByCoolingType(imageBoxList,FrontPhotoService.mirrorDirection);
            panel3.RowImageEntities = imageBoxList;
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

                //居中计算
                imageBoxList = FrontPhotoService.setCenter(imageBoxList,panel3.Width,FrontPhotoService.mirrorDirection);

                FrontPhotoService.factor *= zoomInFactor;
                panel3.RowImageEntities = imageBoxList;
            }
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

                //居中计算
                imageBoxList = FrontPhotoService.setCenter(imageBoxList, panel3.Width, FrontPhotoService.mirrorDirection);

                FrontPhotoService.factor *= zoomOutFactor;
                panel3.RowImageEntities = imageBoxList;
            }
        }

        /// <summary>
        /// 左镜像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftMove_Click(object sender, EventArgs e)
        {
            if(!mirrorLeft){
                FrontPhotoService.mirrorDirection = "mirrorLeft";
                FrontPhotoService.leftStartX = imageBoxList.ElementAt(0).Rect.X;
                refreshedByModAhUint(tagIndex);
                reFreshEdByReplace(tagIndex);
             

                imageBoxList = FrontPhotoService.calculateMirrorPosition(imageBoxList, panel3.Width);

                //计算进行居中
                imageBoxList = FrontPhotoService.setCenter(imageBoxList, panel3.Width, FrontPhotoService.mirrorDirection);

                panel3.RowImageEntities = imageBoxList;
                panel3.Invalidate();
            }
           //右边镜像可以操作
            mirrorLeft = true;
            mirrorRight = false;
         
        }

        /// <summary>
        /// 向右的镜像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rightMove_Click(object sender, EventArgs e)
        {
            if(!mirrorRight){
                FrontPhotoService.leftStartX = panel3.Width - 300;
                FrontPhotoService.mirrorDirection = "mirrorRight";
                refreshedByModAhUint(tagIndex);
                reFreshEdByReplace(tagIndex);
                

                imageBoxList = FrontPhotoService.calculateMirrorPosition(imageBoxList, panel3.Width);

                //居中计算
                imageBoxList = FrontPhotoService.setCenter(imageBoxList, panel3.Width, FrontPhotoService.mirrorDirection);

                panel3.Invalidate();
            }
            //左边镜像按钮可以操作
            mirrorLeft = false;
            mirrorRight = true;
            
        }
        /// <summary>
        /// 生成浏览dxf代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
               // if(imageEntity.Name!="virtualHRA"){
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
               // }
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
                 new string[] { "hello", "world", "helloworld" }, 44.0f, 18, 1.0f, 1.56f, 2.0f, 2.0f);
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

        //返回替代的ImageEntity
        ImageEntity getReplaceImageEntity(PictureBox pictureBox, int coolingType=5)
        {
            FrontPhotoService.recoveryLeftOrRightParamerter();

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
            bool isSelected = true;
            string parentName = imageBlock.ParentName;
            string gUid = Guid.NewGuid().ToString("N");
            return new ImageEntity {Guid=gUid, 
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
                parentName = imageBlock.ParentName };
        }
        /// <summary>
        /// 创建右边的图片
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="coolingType"></param>
        void createImageBox(PictureBox pictureBox, int coolingType=5)
        {
           
            //imageBoxList内元素置为没有选中
            FrontPhotoService.setAllElement(imageBoxList);

            FrontPhotoService.recoveryLeftOrRightParamerter();

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
            bool isSelected = true;
            string parentName = imageBlock.ParentName;
            string gUid =  Guid.NewGuid().ToString("N");
            int imageRealWidth =Convert.ToInt32(imageBlock.ImageWidth);
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
                parentName = imageBlock.ParentName,
                imageWidth=imageRealWidth});
            panel3.OverImageEntities = leftTopImageBoxList;
           
        }

        private void panel3_OnEntityMove(ImageEntity srcEntity, ImageEntity destEntity)
        {
            if (srcEntity.Type == "row")
            {
                //removeListImageEntity(imageBoxList, srcEntity);
                if (FrontPhotoService.mirrorDirection.Equals("mirrorRight"))
                {
                    //居中
                  //  imageBoxList = FrontPhotoService.setCenter(imageBoxList, panel3.Width, FrontPhotoService.mirrorDirection);

                    //FrontPhotoService.leftStartX = panel3.Width - 400;
                    imageBoxList = FrontPhotoService.calculateImageEntityPosition(imageBoxList, srcEntity, destEntity, "mirrorRight");

                    //判断是否自动缩小，超出了panel一定的边界
                    if (FrontPhotoService.isZoomOut(imageBoxList, panel3.Width))
                    {
                        imageBoxList = FrontPhotoService.zoomOutImageEntity(imageBoxList, zoomOutFactor);
                        FrontPhotoService.factor *= zoomOutFactor;

                        //缩小后居中
                        imageBoxList = FrontPhotoService.setCenter(imageBoxList, panel3.Width, FrontPhotoService.mirrorDirection);
                    }


                    ////居中
                    if (imageBoxList.ElementAt(0).Rect.X < panel3.Width / 8)
                    {
                        imageBoxList = FrontPhotoService.setCenter(imageBoxList, panel3.Width, FrontPhotoService.mirrorDirection);
                    }    
                    
                    
                }
                else
                {
                    //居中
                  //  imageBoxList = FrontPhotoService.setCenter(imageBoxList, panel3.Width, FrontPhotoService.mirrorDirection);

                   // FrontPhotoService.leftStartX = 200;
                    
                    imageBoxList = FrontPhotoService.calculateImageEntityPosition(imageBoxList, srcEntity, destEntity, "mirrorLeft");

                    //判断是否自动缩小，超出了panel一定的边界
                    if (FrontPhotoService.isZoomOut(imageBoxList, panel3.Width))
                    {
                        imageBoxList = FrontPhotoService.zoomOutImageEntity(imageBoxList, zoomOutFactor);
                        FrontPhotoService.factor *= zoomOutFactor;

                        //缩小后居中
                        imageBoxList = FrontPhotoService.setCenter(imageBoxList, panel3.Width, FrontPhotoService.mirrorDirection);
                    }

                    ////居中
                    if (imageBoxList.ElementAt(0).Rect.X < panel3.Width / 8)
                    {
                        imageBoxList = FrontPhotoService.setCenter(imageBoxList, panel3.Width, FrontPhotoService.mirrorDirection);
                    }    
                   
                }
                //画右边信息
                downImageEnityList = FrontPhotoService.getDownList(imageBoxList);
                FrontPhotoService.initRightTopInformation(FrontPhotoImageModelService.operatePhotoNeedData, downImageEnityList, imageBoxList, coolingType);
                rightTopInfoList = FrontPhotoService.getTopRightEquipmentInformation(FrontPhotoService.productionDescription, FrontPhotoService.downTotalLength, FrontPhotoService.totalHeight, FrontPhotoService.imageWidth);

                panel3.RowImageEntities = imageBoxList;
                panel3.TopRightInfo = rightTopInfoList;
            }
            else if (srcEntity.Type == "over")
            {
                if (srcEntity.Rect.X != destEntity.Rect.X || srcEntity.Rect.Y != destEntity.Rect.Y)
                {
                    if (FrontPhotoService.mirrorDirection.Equals("mirrorRight"))
                    {

                      //  FrontPhotoService.leftStartX = panel3.Width - 400;

                        leftTopImageBoxList = FrontPhotoService.removeListImageEntity(leftTopImageBoxList, srcEntity);
                        imageBoxList = FrontPhotoService.calculateImageEntityPosition(imageBoxList, srcEntity, destEntity, "mirrorRight");
                       // 判断是否自动缩小，超出了panel一定的边界
                        if (FrontPhotoService.isZoomOut(imageBoxList, panel3.Width))
                        {
                            imageBoxList = FrontPhotoService.zoomOutImageEntity(imageBoxList, zoomOutFactor);
                            FrontPhotoService.factor *= zoomOutFactor;

                            //缩小后居中
                            imageBoxList = FrontPhotoService.setCenter(imageBoxList, panel3.Width, FrontPhotoService.mirrorDirection);
                        }

                        ////居中
                        if (imageBoxList.ElementAt(0).Rect.X < panel3.Width / 8)
                        {
                            imageBoxList = FrontPhotoService.setCenter(imageBoxList, panel3.Width, FrontPhotoService.mirrorDirection);
                        }                       
                    }
                    else
                    {
                        //FrontPhotoService.leftStartX = 200;
                        leftTopImageBoxList = FrontPhotoService.removeListImageEntity(leftTopImageBoxList, srcEntity);
                        imageBoxList = FrontPhotoService.calculateImageEntityPosition(imageBoxList, srcEntity, destEntity, "mirrorLeft");

                        //判断是否自动缩小，超出了panel一定的边界
                        if (FrontPhotoService.isZoomOut(imageBoxList, panel3.Width))
                        {
                            imageBoxList = FrontPhotoService.zoomOutImageEntity(imageBoxList, zoomOutFactor);
                            FrontPhotoService.factor *= zoomOutFactor;
                            //缩小后居中
                            imageBoxList = FrontPhotoService.setCenter(imageBoxList, panel3.Width, FrontPhotoService.mirrorDirection);
                        }

                        ////居中
                        if (imageBoxList.ElementAt(0).Rect.X < panel3.Width / 8)
                        {
                            imageBoxList = FrontPhotoService.setCenter(imageBoxList, panel3.Width, FrontPhotoService.mirrorDirection);
                        }   
                    }

                    //画右边信息
                    downImageEnityList = FrontPhotoService.getDownList(imageBoxList);
                    FrontPhotoService.initRightTopInformation(FrontPhotoImageModelService.operatePhotoNeedData, downImageEnityList, imageBoxList, coolingType);
                    rightTopInfoList = FrontPhotoService.getTopRightEquipmentInformation(FrontPhotoService.productionDescription, FrontPhotoService.downTotalLength, FrontPhotoService.totalHeight, FrontPhotoService.imageWidth);
                    
                    panel3.RowImageEntities = imageBoxList;
                    panel3.TopRightInfo = rightTopInfoList;
                }          
            }
        }

        void panel3_OnEntityDBClick(ImageEntity imageEntity)
        {
            FrontPhotoService.recoveryLeftOrRightParamerter();
            imageBoxList = FrontPhotoImageModelService.getTagModuleImageList(imageBoxList);
            new ModuleDetail(FrontPhotoImageModelService.getImageModelList(imageBoxList)).ShowDialog();
                
        }

        void panel3_OnEntityClick(ImageEntity imageEntity)
        {
            for (int i = 0; i < imageBoxList.Count; i++)
            {
                if (imageEntity.Rect.X == imageBoxList.ElementAt(i).Rect.X && imageEntity.Rect.Y == imageBoxList.ElementAt(i).Rect.Y && imageEntity.Name == imageBoxList.ElementAt(i).Name)
                {
                    imageBoxList.ElementAt(i).isSelected = true;
                    //设置replace被选中              
                        tabControl1.SelectedIndex = 1;

                        string imageName = imageBoxList.ElementAt(i).Name == "virtualHRA" ? "HR Wheel": imageBoxList.ElementAt(i).parentName;


                        int tabIndex = FrontPhotoService.tabControlImageIndex[imageName];
                        tab_Replace.SelectedIndex = tabIndex;
                        reFreshEdByReplace(tabIndex);
                        isAddOrReplace = true;
                    //生成图片选中文字信息，在中间显示
                        FrontPhotoService.selectedModule = imageBoxList.ElementAt(i).parentName;
                        FrontPhotoService.imageSerialNo = "" + imageBoxList.ElementAt(i).Name
                            + "-" + imageBoxList.ElementAt(i).moduleTag
                            + "-P" + "-A" + i + "-000" + i + "-000" + i + "-0" + "-0";
                        centerTopInfoList = FrontPhotoService.getMiddleEachInformation(FrontPhotoService.selectedModule, FrontPhotoService.imageSerialNo);

                   //设置选中图片的位置
                    if (FrontPhotoService.rightAlignment || FrontPhotoService.leftAlignment)
                    {
                        if (imageBoxList.ElementAt(i).Rect.Y < FrontPhotoService.leftStartY)
                        {
                            FrontPhotoService.upSelectedElement = i;
                        }
                        else
                        {
                            FrontPhotoService.downSelectedElement = i;
                        }
                    }
                }
                else
                {
                    imageBoxList.ElementAt(i).isSelected = false;
                }
            }
            if (FrontPhotoService.upSelectedElement > -1 && FrontPhotoService.downSelectedElement > -1)
            {
                imageBoxList = FrontPhotoService.calculateAlignmentLeftOrRight(imageBoxList,FrontPhotoService.downSelectedElement, FrontPhotoService.upSelectedElement);
                panel3.TopInfo = centerTopInfoList;
                panel3.RowImageEntities = imageBoxList;
                panel3.Invalidate();
            }
            else
            {
                panel3.TopInfo = centerTopInfoList;
                panel3.RowImageEntities = imageBoxList;
                panel3.Invalidate();
            }  
        }
        //约束检查
        private void btn_FinalCheck_Click(object sender, EventArgs e)
        {
            FrontPhotoService.recoveryLeftOrRightParamerter();
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
            FrontPhotoService.recoveryLeftOrRightParamerter();
            ModAHUnit mhu = new ModAHUnit();
            mhu.InitialForm(FrontPhotoImageModelService.orderId, this);
            mhu.ShowDialog();
            //new ModuleDetail().Show();
        }
        
        public void setOperatePhotoNeedData(OperatePhotoNeedData operatePhotoNeedData,int orderSale=-1)
        {
            coolingType = Convert.ToInt32(operatePhotoNeedData.unitSize);
            FrontPhotoImageModelService.orderId=operatePhotoNeedData.orderID;
            FrontPhotoImageModelService.orderSale = orderSale;
            FrontPhotoImageModelService.operatePhotoNeedData = operatePhotoNeedData;
        }

        private void btn_ModuleDetail_Click(object sender, EventArgs e)
        {
            FrontPhotoService.recoveryLeftOrRightParamerter();
            FrontPhotoImageModelService.currentTagIndex = tabControl1.SelectedIndex;
            new ModuleDetail(FrontPhotoImageModelService.getImageModelList(imageBoxList)).ShowDialog();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < imageBoxList.Count;i++ )
                {
                    ImageEntity imageEntityCopy = imageBoxList.ElementAt(i);
                    ContentBLL.InitialImageOrder(imageEntityCopy.Guid, imageEntityCopy.coolingType, imageEntityCopy.Name, imageEntityCopy.orderId, imageEntityCopy.moduleTag);
                }
                int flag1=ImageModelBLL.insertList(FrontPhotoImageModelService.getImageModelList(imageBoxList));
                int flag2 = OrderDetailBLL.InsertOD(FrontPhotoImageModelService.orderSale, FrontPhotoImageModelService.orderId,"M"+FrontPhotoImageModelService.orderSale+ "-"+FrontPhotoImageModelService.orderId);
                int flag3 = ContentBLL.copyCurrentToOrder(FrontPhotoImageModelService.orderId);
                int flag4 = UnitBLL.copyCurrentToOrder(FrontPhotoImageModelService.orderId);
                //int flag5 = ImageModelBLL.insertList(FrontPhotoImageModelService.getImageModelList(imageBoxList));
                if(flag1 > 0 && flag2 > 0 && flag3>0&&flag4>0)
                {
                    //MessageBox.Show("save success!");
                    this.Close();
                    List<orderDetailInfo> odlist = new List<orderDetailInfo>();
                    odlist = OrderDetailBLL.GetAllOrderDetail();
                    AAonRating.aaon.dataGridView2.DataSource = odlist;
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
             FrontPhotoService.recoveryLeftOrRightParamerter();

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
            //画右边信息
            downImageEnityList = FrontPhotoService.getDownList(imageBoxList);
            FrontPhotoService.initRightTopInformation(FrontPhotoImageModelService.operatePhotoNeedData, downImageEnityList, imageBoxList, coolingType);
            rightTopInfoList = FrontPhotoService.getTopRightEquipmentInformation(FrontPhotoService.productionDescription, FrontPhotoService.downTotalLength, FrontPhotoService.totalHeight, FrontPhotoService.imageWidth);
           
            panel3.RowImageEntities = imageBoxList;
            panel3.TopRightInfo = rightTopInfoList;
            panel3.Invalidate();
        }
        //这个有点难
        private void btn_Center_Click(object sender, EventArgs e)
        {
            FrontPhotoService.recoveryLeftOrRightParamerter();
           imageBoxList= FrontPhotoService.setCenter(imageBoxList,panel3.Width,FrontPhotoService.mirrorDirection);
           panel3.RowImageEntities = imageBoxList;
           panel3.Invalidate();
        }

        private void btn_LeftAlignment_Click(object sender, EventArgs e)
        {
            if (FrontPhotoService.isExistCrossElement(imageBoxList))
            {
                FrontPhotoService.recoveryLeftOrRightParamerter();
            }
            else
            {
                FrontPhotoService.leftAlignment = true;
                FrontPhotoService.rightAlignment = false;
            } 
        }

        private void btn_RightAlignment_Click(object sender, EventArgs e)
        {
            if (FrontPhotoService.isExistCrossElement(imageBoxList))
            {
                FrontPhotoService.recoveryLeftOrRightParamerter();
            }
            else
            {
                FrontPhotoService.leftAlignment = false;
                FrontPhotoService.rightAlignment = true;
            } 
        }
        /// <summary>
        /// replace事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tc = sender as TabControl;
            if (isAddOrReplace)
            {
                tabControl1.SelectedIndex = tc.SelectedIndex;
                isAddOrReplace = false;
            }
            else
            {
                int flag1 = FrontPhotoService.getIsExistSelected(imageBoxList);
                int flag2 = FrontPhotoService.getIsExistSelected(leftTopImageBoxList);
                if (flag1 >= 0 || flag2 >= 0)
                {
                    tabControl1.SelectedIndex = 1;
                    tab_Replace.SelectedIndex = tabControlEx1.SelectedIndex;
                    isAddOrReplace = true;
                }
                else
                {
                    tabControl1.SelectedIndex = 0;
                }
            }
        }
        /// <summary>
        /// replaceTab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tab_Replace_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            TabControl tc = sender as TabControl;
            if (isAddOrReplace)
            {
              //  if (!isrightAddOrReplace)
              //  {
                    tabControl1.SelectedIndex = 0;
                    tabControlEx1.SelectedIndex = tc.SelectedIndex;
                    isAddOrReplace = false;
                //}
            }                            
        }

        public void setImageListFromModelFeature(List<ImageEntity> imageList)
        {
            imageBoxList = imageList;
        }
    }
}
