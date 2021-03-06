﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using Model.Zutu;
using Annon.Zutu.FrontPhoto;

namespace Annon.Zutu
{
    public class CustomForm : Control
    {
        //判断鼠标是否选中了当前的某个图块
        private bool rectExist = false;

        //判断是否选中图块
        private bool isHitted = false;

        //鼠标按下的点
        private Point downPoint;

        //鼠标即将拖动的图块的起始坐标
        private Point beginPoint;

        //鼠标选中图块之后的红色矩形框
        private Rectangle selectedRectangle ;//= new Rectangle(50, 50, 50, 50);

        //鼠标选中的当前的图块
        private ImageEntity selectedImageEntity = new ImageEntity();

        //连线选中   代理声明
        public delegate void EntityMoved(ImageEntity srcEntity, ImageEntity destEntity);
        public event EntityMoved OnEntityMove;

        //图块双击事件
        public delegate void EntityDBClicked(ImageEntity imageEntity);
        public event EntityDBClicked OnEntityDBClick;

        //图块单击事件
        public delegate void EntityClicked(ImageEntity imageEntity);
        public event EntityClicked OnEntityClick;

        public CustomForm()
        {
            //注册控件的鼠标事件
            this.MouseDown += new MouseEventHandler(CustomForm_MouseDown);
            this.MouseMove += new MouseEventHandler(CustomForm_MouseMove);
            this.MouseUp += new MouseEventHandler(CustomForm_MouseUp);
            this.MouseDoubleClick += new MouseEventHandler(CustomForm_MouseDoubleClick);
            //this.MouseHover += new EventHandler(CustomForm_MouseHover);
        }

    

        void CustomForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //如果当前的点击在图片区域内，则形成一个矩形框,此处作为判断并列的图块的判断
            if (rowImageEntities.Count > 0)
            {
                foreach (var imageEntity in rowImageEntities)
                {
                    if (imageEntity.HitTest(new Point(e.X,e.Y)))
                    {
                        //设置矩形框存在，并且将矩形框的rect设置为当前选中的图块的rect
                        //并保存矩形框的起始点.一旦有图块被选中，则终止循环判断
                        //设置选中的图块为该图块
                        selectedRectangle = imageEntity.Rect;
                        //如果双击则触发事件
                        if (OnEntityDBClick != null)
                            OnEntityDBClick(imageEntity);

                        break;

                    }
                }
                this.Invalidate();
            }
        }

        /// <summary>
        /// 外部传入的图块列表，并排
        /// </summary>
        private List<ImageEntity> rowImageEntities ;//

        public List<ImageEntity> RowImageEntities
        {
            get { return rowImageEntities; }
            set { rowImageEntities = value;
            this.Invalidate();
            }
        }

        /// <summary>
        /// 外部传入的图块列表，重叠
        /// </summary>
        private List<ImageEntity> overlapImageEntities;
      
        public List<ImageEntity> OverImageEntities
        {
            get { return overlapImageEntities; }
            set { overlapImageEntities = value; this.Invalidate(); }
        }

        public List<string> TopInfo { get; set; }
        public List<string> TopRightInfo { get; set; }


        void CustomForm_MouseUp(object sender, MouseEventArgs e)
        {
            //设置矩形框标记为false,即不在绘制矩形框
            rectExist = false;
            //如果是单击事件
            if (e.X == downPoint.X && e.Y == downPoint.Y)
            {
                //如果当前的点击在图片区域内，则形成一个矩形框,此处作为判断并列的图块的判断
                if (rowImageEntities.Count > 0)
                {
                    foreach (var imageEntity in rowImageEntities)
                    {
                        if (imageEntity.HitTest(downPoint))
                        {
                            //消除virtualHRA影响
                            if (imageEntity.Name.Equals("virtualHRA"))
                            {
                                foreach (var hraEntity in rowImageEntities)
                                {
                                    if (hraEntity.Name.Equals(RightImageRangeType.imageRangeType.ElementAt(0).ToString()))
                                    {
                                        //如果双击则触发事件
                                        if (OnEntityClick != null)
                                            OnEntityClick(hraEntity);
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                //如果双击则触发事件
                                if (OnEntityClick != null)
                                    OnEntityClick(imageEntity);
                                return;
                            }
                            
                        }
                    }
                }
                //如果在重叠图块内
                if (overlapImageEntities != null && overlapImageEntities.Count > 0)
                {
                    var lastImageEntity = overlapImageEntities.Last();
                    if (lastImageEntity.HitTest(downPoint))
                    {
                        //如果双击则触发事件
                        if (OnEntityClick != null)
                            OnEntityClick(lastImageEntity);
                        return;
                    }
                }
            }
            
            //如果当前未选中任何图块不做事情，如果选中如下：
            if (isHitted)
            {
                //对目标图块赋值
                ImageEntity destImageEntity = new ImageEntity();
                destImageEntity.Rect = selectedRectangle;
                destImageEntity.Name = selectedImageEntity.Name;
                destImageEntity.Type = "row";
                destImageEntity.Url = selectedImageEntity.Url;
                destImageEntity.coolingType = selectedImageEntity.coolingType;
                destImageEntity.firstDistance = selectedImageEntity.firstDistance;
                destImageEntity.secondDistance = selectedImageEntity.secondDistance;
                destImageEntity.Text = selectedImageEntity.Text;
                destImageEntity.parentName = selectedImageEntity.parentName;
                destImageEntity.orderId = selectedImageEntity.orderId;
                destImageEntity.moduleTag = selectedImageEntity.moduleTag;
                destImageEntity.isSelected = selectedImageEntity.isSelected;
                destImageEntity.Guid = selectedImageEntity.Guid;
                destImageEntity.thirdDistance = selectedImageEntity.thirdDistance;
                destImageEntity.topViewFirstDistance = selectedImageEntity.topViewFirstDistance;
                destImageEntity.topViewSecondDistance = selectedImageEntity.topViewSecondDistance;
                destImageEntity.imageWidth = selectedImageEntity.imageWidth;
                //触发移动事件
                if (OnEntityMove != null)
                    OnEntityMove(selectedImageEntity, destImageEntity);

                //if (selectedImageEntity.Type.Equals("over"))
                //{
                //    selectedImageEntity.Type = "row";
                //    //rowImageEntities.Add(selectedImageEntity);
                //    //overlapImageEntities.Remove(selectedImageEntity);
                //}
                //selectedImageEntity.Rect = selectedRectangle;
                isHitted = false;
            }

            this.Invalidate();
        }

        void CustomForm_MouseMove(object sender, MouseEventArgs e)
        {
            //判断鼠标位置不能超出客户区域
            if (e.X > ClientRectangle.X
                && e.X < ClientRectangle.X + ClientRectangle.Width
                && e.Y > ClientRectangle.Y
                && e.Y < ClientRectangle.Y + ClientRectangle.Height
                && rectExist)
            {
                selectedRectangle = new Rectangle(beginPoint.X + e.X - downPoint.X, beginPoint.Y + e.Y - downPoint.Y, selectedRectangle.Width, selectedRectangle.Height);

                this.Invalidate();
            }

            if (e.X > ClientRectangle.X
               && e.X < ClientRectangle.X + ClientRectangle.Width
               && e.Y > ClientRectangle.Y
               && e.Y < ClientRectangle.Y + ClientRectangle.Height
               && !rectExist)
            {
                //如果当前的点击在图片区域内，则形成一个矩形框,此处作为判断并列的图块的判断
                if (rowImageEntities.Count > 0)
                {
                    foreach (var imageEntity in rowImageEntities)
                    {
                        if (imageEntity.HitTest(new Point(e.X,e.Y)))
                        {
                            myRectangle = new Rectangle(e.X-30, e.Y+20, 200, 50);
                            infoText = "width:" + imageEntity.Rect.Width + ";height:" + imageEntity.Rect.Height;
                            this.Invalidate();
                            return;
                        }
                    }
                }
                myRectangle = Rectangle.Empty;
                this.Invalidate();
            }
        }
        private string infoText = string.Empty;
        private Rectangle myRectangle = Rectangle.Empty;
        void CustomForm_MouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("test");
            // Determine the initial rectangle coordinates...
            downPoint = new Point(e.X, e.Y);
            
            //如果当前的点击在图片区域内，则形成一个矩形框,此处作为判断并列的图块的判断
            if (rowImageEntities.Count > 0)
            {
                foreach (var imageEntity in rowImageEntities)
                {
                    if (imageEntity.HitTest(downPoint))
                    {
                        //设置矩形框存在，并且将矩形框的rect设置为当前选中的图块的rect
                        //并保存矩形框的起始点.一旦有图块被选中，则终止循环判断
                        //设置选中的图块为该图块
                        rectExist = true;
                        //selectedRectangle = imageEntity.Rect;
                        //2012-9-4修改消除HRA花矩形框影响
                        if (imageEntity.Name.Equals("virtualHRA"))
                        {
                            foreach(var hraEntity in rowImageEntities)
                            {
                                if (hraEntity.Name.Equals(RightImageRangeType.imageRangeType.ElementAt(0).ToString()))
                                {
                                    selectedRectangle = hraEntity.Rect;
                                    selectedImageEntity = hraEntity;
                                    //单击按下选中为画网格做准
                                    //2012-9-4
                                    selectedImageEntity.isSelected = true;
                                    foreach (var cancelSelected in rowImageEntities)
                                    {
                                        if (cancelSelected.Name != selectedImageEntity.Name || cancelSelected.Rect != selectedImageEntity.Rect)
                                        {
                                            cancelSelected.isSelected = false;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        else
                        {
                            selectedRectangle = imageEntity.Rect;
                            selectedImageEntity = imageEntity;
                            //单击按下选中为画网格做准
                            //2012-9-4
                            selectedImageEntity.isSelected = true;
                            foreach(var cancelSelected in rowImageEntities){
                                
                                if (cancelSelected.Name != selectedImageEntity.Name || cancelSelected.Rect != selectedImageEntity.Rect)
                                {
                                    cancelSelected.isSelected = false;
                                }
                            }
                        }
                        
                        beginPoint = new Point(selectedRectangle.X, selectedRectangle.Y);
                        //确认选中
                        isHitted = true;
                        this.Invalidate();
                        return;
                    }
                }
            }
            
            //如果在重叠图块内
            if (overlapImageEntities!=null&&overlapImageEntities.Count>0)
            {
                var lastImageEntity = overlapImageEntities.Last();
                if (lastImageEntity.HitTest(downPoint))
                {
                    rectExist = true;
                    selectedRectangle = lastImageEntity.Rect;
                    selectedImageEntity = lastImageEntity;
                    beginPoint = new Point(selectedRectangle.X, selectedRectangle.Y);
                    isHitted = true;
                   //this.Invalidate();
                    return;
                }
            }
            isHitted = false;
            
            this.Invalidate();
            
        }
       

        //根据图片绘制图形
        private void DrawImageRect(PaintEventArgs e, ImageEntity imageEntity)
        {
            if (!imageEntity.Name.Equals("virtualHRA"))
            {
                // Create image.

                if (FrontPhotoService.mirrorDirection.Equals("mirrorRight"))
                {
                    Image newImage = Image.FromFile(imageEntity.Url);
                    // Draw image to screen.
                    e.Graphics.DrawImage(newImage, imageEntity.Rect);
                }
                else
                {
                    Image newImage = Image.FromFile(imageEntity.Url);
                    Bitmap bmp = new Bitmap(newImage);
                    bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    e.Graphics.DrawImage(bmp, imageEntity.Rect);
                }
               
            }
        }

        /// <summary>
        /// 绘制网格
        /// </summary>
        /// <param name="e"></param>
        /// <param name="rect"></param>
        private void DrawImageMesh(PaintEventArgs e, Rectangle rect)
        {
            Pen pen=new Pen(new SolidBrush(Color.Red),1);
            int pixels = 5;
            int columnCount = rect.Width / pixels;
            int rowCount = rect.Height / pixels;
            for (int i = 0; i < rowCount; i++)
            {
                e.Graphics.DrawLine(pen,new Point(rect.X, rect.Y + i * pixels), new Point(rect.X + rect.Width, rect.Y + i * pixels));
            }
            for (int j = 0; j < columnCount; j++)
            {
                e.Graphics.DrawLine(pen, new Point(rect.X + j * pixels, rect.Y), new Point(rect.X + j * pixels, rect.Y + rect.Height));
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            #region 双缓冲处理
            base.OnPaint(e);
            Bitmap bp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            Graphics newGraphics = Graphics.FromImage(bp);
            try
            {
                SetStyle(ControlStyles.UserPaint, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true); //禁止擦除背景.
                SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
                // 消锯齿(可选项)
                newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                //高质量
                newGraphics.SmoothingMode = SmoothingMode.HighQuality;

               
            #endregion


                #region 绘图区域

                //绘制并排存在的图块
                foreach (var imageEntity in rowImageEntities)
                {
                    DrawImageRect(e, imageEntity);
                    if (imageEntity.isSelected)
                        DrawImageMesh(e, imageEntity.Rect);
                } 

                //绘制重叠存在的图块,从底部向上部绘制
                if (overlapImageEntities != null)
                {
                    for (int i = 0; i < overlapImageEntities.Count; i++)
                    {
                        DrawImageRect(e, overlapImageEntities[i]);
                        if (overlapImageEntities[i].isSelected)
                            DrawImageMesh(e, overlapImageEntities[i].Rect);
                    }

                }
               

                //绘制图中可能鼠标拖动期间的矩形框
                if (rectExist)
                {
                    e.Graphics.DrawRectangle(new Pen(Color.Red, 4), selectedRectangle);
                }

                //绘制中间文字
                Font font = new Font("宋体", 9f);
                int middleX=this.Width/2-150;
                int middleY=20;
                if (TopInfo != null && TopInfo.Count != 0)
                {
                    int i = 1;
                    foreach (var info in TopInfo)
                    {
                        i++;
                        e.Graphics.DrawString(info, font, new SolidBrush(Color.Black), new Point(middleX, middleY * i));
                    }
                }
                //绘制右上角文字
                int rightX = this.Width - 200;
                int rightY = 20;
                if (TopRightInfo != null && TopRightInfo.Count != 0)
                {
                    int i = 1;
                    foreach (var info in TopRightInfo)
                    {
                        i++;
                        e.Graphics.DrawString(info, font, new SolidBrush(Color.Black), new Point(rightX, rightY * i));
                    }
                }
                font.Dispose();

                //绘制下方箭头
                if (FrontPhotoService.mirrorDirection.Equals("mirrorRight"))
                {
                    string flowArrowUrl="../../image/flowarrow/flowArrow.gif";
                      Image newImage = Image.FromFile(flowArrowUrl);
                      e.Graphics.DrawImage(newImage, new Point(this.Width/3,this.Height-150));
                }
                else
                {
                    string flowArrowUrl = "../../image/flowarrow/flowArrow.gif";
                    Image newImage = Image.FromFile(flowArrowUrl);
                    Bitmap bitImage = new Bitmap(newImage);
                    bitImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    e.Graphics.DrawImage(bitImage, new Point(this.Width/3,this.Height-150));
                }

                #endregion


           #region 双缓冲处理
                // 将缓冲位图绘制到输出
                e.Graphics.DrawImage(bp, Point.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine("MainForm-->drawPanel_Paint:" + ex.Message);
            }
            finally
            {
                newGraphics.Dispose();
            } 
                #endregion

        }
    }
}
