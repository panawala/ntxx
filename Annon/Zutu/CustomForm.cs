using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using Model.Zutu;

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
            this.MouseClick += new MouseEventHandler(CustomForm_MouseClick);
        }

        void CustomForm_MouseClick(object sender, MouseEventArgs e)
        {
            //如果当前的点击在图片区域内，则形成一个矩形框,此处作为判断并列的图块的判断
            if (rowImageEntities.Count > 0)
            {
                foreach (var imageEntity in rowImageEntities)
                {
                    if (imageEntity.HitTest(new Point(e.X, e.Y)))
                    {
                        //设置矩形框存在，并且将矩形框的rect设置为当前选中的图块的rect
                        //并保存矩形框的起始点.一旦有图块被选中，则终止循环判断
                        //设置选中的图块为该图块
                        selectedRectangle = imageEntity.Rect;
                        //如果双击则触发事件
                        if (OnEntityClick != null)
                            OnEntityClick(imageEntity);
                        return;
                    }
                }
            }
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
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 外部传入的图块列表，并排
        /// </summary>
        private List<ImageEntity> rowImageEntities ;//
        //= new List<ImageEntity>()
        //{ 
        //    new ImageEntity{Name="test",Rect=new Rectangle(100,100,50,50),Url="sample.jpg",Type="row"},
        //    new ImageEntity{Name="test",Rect=new Rectangle(180,180,50,50),Url="sample.jpg",Type="row"}
        //};
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
        //    = new List<ImageEntity>()
        //{ 
        //    new ImageEntity{Name="test",Rect=new Rectangle(10,10,50,50),Url="sample.jpg",Type="over"},
        //    new ImageEntity{Name="test",Rect=new Rectangle(10,10,80,80),Url="sample.jpg",Type="over"}
        //};
        public List<ImageEntity> OverImageEntities
        {
            get { return overlapImageEntities; }
            set { overlapImageEntities = value; this.Invalidate(); }
        }


        void CustomForm_MouseUp(object sender, MouseEventArgs e)
        {
            //设置矩形框标记为false,即不在绘制矩形框
            rectExist = false;
            //如果当前之前未选中任何图块不做事情，如果选中如下：
            if (isHitted)
            {

                //对目标图块赋值
                ImageEntity destImageEntity = new ImageEntity();
                destImageEntity.Rect = selectedRectangle;
                destImageEntity.Name = selectedImageEntity.Name;
                destImageEntity.Type = "row";
                destImageEntity.Url = selectedImageEntity.Url;
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
   
        }

        void CustomForm_MouseDown(object sender, MouseEventArgs e)
        {
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
                        selectedRectangle = imageEntity.Rect;
                        selectedImageEntity = imageEntity;
                        beginPoint = new Point(selectedRectangle.X, selectedRectangle.Y);
                        isHitted = true;
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
                    return;
                }
            }
            isHitted = false;
        }
       

        //根据图片绘制图形
        private void DrawImageRect(PaintEventArgs e, ImageEntity imageEntity)
        {
            if (!imageEntity.Name.Equals("virtualHRA"))
            {
                // Create image.
                Image newImage = Image.FromFile(imageEntity.Url);
                // Draw image to screen.
                e.Graphics.DrawImage(newImage, imageEntity.Rect);
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

                //绘制并排存在的图块
                foreach (var imageEntity in rowImageEntities)
                {
                    DrawImageRect(e, imageEntity);
                } 
            #endregion


                #region 绘图区域
              
                //绘制重叠存在的图块,从底部向上部绘制
                if (overlapImageEntities != null)
                {
                    for (int i = 0; i < overlapImageEntities.Count; i++)
                    {
                        DrawImageRect(e, overlapImageEntities[i]);
                    }

                }
               

                //绘制图中可能鼠标拖动期间的矩形框
                if (rectExist)
                {
                    e.Graphics.DrawRectangle(new Pen(Color.Red, 4), selectedRectangle);
                }

                //绘制选中的矩形
                if (!rectExist)
                    DrawImageMesh(e, selectedRectangle);
                //Rectangle rect = selectedImageEntity.Rect;
                //Point v1 = new Point(rect.X, rect.Y);
                //Point v2 = new Point(rect.X + rect.Width, rect.Y);
                //Point v3 = new Point(rect.X + rect.Width, rect.Y + rect.Height);
                //Point v4 = new Point(rect.X, rect.Y + rect.Height);
                //e.Graphics.DrawLine(new Pen(Color.Red, 4), v1, v3);
                //e.Graphics.DrawLine(new Pen(Color.Red, 4), v2, v4);
               
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
