using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Zutu;
using System.Drawing;
using EntityFrameworkTryBLL.ZutuManager;
using Annon.Xuanxing;
using CadLib.OperatorEntity;

namespace Annon.Zutu.FrontPhoto
{
    class FrontPhotoService
    {
        //放大和缩小因子
         public  static double factor = 4;

        //组图左边为准时
       public static int leftStartX = 200;
       public static int leftStartY = 350;

        //上层第一个元素在imageboxList的位置
        static int upFirstElement = -1;
        //穿插两层元素在上下层的位置
        static int upCrossElement = -1;
        //穿越两层元素的x坐标
        static int xCrossPosition = -1;
        //下层最后一个元素位置
        static int downLastElement = -1;

        //mirror参数
       public static string mirrorDirection = "mirrorRight";

        //这个数据须是从数据库获取的真实数据
        
        public static int downTotalLength=0;
        public static int imageWidth = 0;
        public static int totalHeight = 0;
        public static string productionDescription = "";

        //单击后中间显示的数据
        public static  string selectedModule = "";
        public static string imageSerialNo = "";


        //下层选中
      public static bool rightAlignment = false;
      public static bool leftAlignment = false;
      public static int downSelectedElement = -1;
      public static int upSelectedElement = -1;


        //设置replace和add的参数
      public static Dictionary<string, int> tabControlImageIndex = new Dictionary<string, int>() { 
      { "Filter", 0 }, 
      { "HR Wheel", 1}, 
      { "Mixing Box", 2 },
      { "Heat", 3},
      { "Coil", 4 },
      { "Fan Box", 5 },
      { "Blank Box", 6 },
      { "Control Box", 7 },};

        //组图算法
        public static List<ImageEntity> calculateImageEntityPosition(List<ImageEntity> imageBoxList, ImageEntity srcImageEntity, ImageEntity destImageEntity, string mirrorDirection)
        {
            //定义sortRangeList用来存储设好坐标的PictureBox
            List<ImageEntity> sortRangeList = new List<ImageEntity>();
            if (srcImageEntity.Type == "row")
            {
                if (RightImageRangeType.imageRangeTypeArray[0].Equals(srcImageEntity.Name))
                {
                    //在两层元素前面的元素整体左移
                    if (destImageEntity.Rect.X < srcImageEntity.Rect.X)
                    {
                        for (int i = upCrossElement; i > upFirstElement; i--)
                        {
                            imageBoxList.ElementAt(i - 1).Rect = new Rectangle(imageBoxList.ElementAt(i - 1).Rect.X - (srcImageEntity.Rect.X - destImageEntity.Rect.X), imageBoxList.ElementAt(i - 1).Rect.Y, imageBoxList.ElementAt(i - 1).Rect.Width, imageBoxList.ElementAt(i - 1).Rect.Height);
                        }
                    }
                    ////在两层元素前面的元素整体右移
                    else
                    {
                        for (int i = upCrossElement + 1; i < imageBoxList.Count; i++)
                        {
                            imageBoxList.ElementAt(i).Rect = new Rectangle(imageBoxList.ElementAt(i).Rect.X + (destImageEntity.Rect.X - srcImageEntity.Rect.X), imageBoxList.ElementAt(i).Rect.Y, imageBoxList.ElementAt(i).Rect.Width, imageBoxList.ElementAt(i).Rect.Height);
                        }
                    }
                    removeListImageEntity(imageBoxList, srcImageEntity);
                    removeListImageEntity(imageBoxList, srcImageEntity.Rect.X, "virtualHRA");
                }
                else
                {
                    removeListImageEntity(imageBoxList, srcImageEntity);
                }

            }
            //添加新元素
            if (RightImageRangeType.imageRangeTypeArray[0].Equals(destImageEntity.Name))
            {

                ImageEntity virtualImageEntity = new ImageEntity();
                virtualImageEntity.Name = "virtualHRA";
                virtualImageEntity.Rect = new Rectangle(destImageEntity.Rect.X, destImageEntity.Rect.Y + (destImageEntity.Rect.Height-2)/2 +2, destImageEntity.Rect.Width, (destImageEntity.Rect.Height-2)/2);
                virtualImageEntity.Url = destImageEntity.Url;
                virtualImageEntity.Type = destImageEntity.Type;
                virtualImageEntity.coolingType = destImageEntity.coolingType;
                virtualImageEntity.orderId = destImageEntity.orderId;
                virtualImageEntity.moduleTag = destImageEntity.moduleTag;
                virtualImageEntity.parentName = destImageEntity.parentName;
                virtualImageEntity.firstDistance = destImageEntity.firstDistance;
                virtualImageEntity.secondDistance = destImageEntity.secondDistance;
                virtualImageEntity.topViewFirstDistance = destImageEntity.topViewFirstDistance;
                virtualImageEntity.topViewSecondDistance = destImageEntity.topViewSecondDistance;
                virtualImageEntity.imageWidth = destImageEntity.imageWidth;
                //向imageList中加入两个ImageEntity
                imageBoxList.Add(virtualImageEntity);
                imageBoxList.Add(destImageEntity);
            }
            else
            {
                imageBoxList.Add(destImageEntity);
            }

            //重新排序

            imageBoxList = getNewDoubleList(imageBoxList, mirrorDirection);

            for (int i = 0; i < imageBoxList.Count; i++)
            {


                if (i == 0)
                {
                    //记录双层元素的x坐标
                    if (imageBoxList.ElementAt(i).Name.Equals("virtualHRA"))
                    {
                        // xCrossPosition = imageBoxList.ElementAt(i).Rect.X;
                        xCrossPosition = leftStartX;
                    }
                    //设置好初始坐标
                    imageBoxList.ElementAt(i).Rect = new Rectangle(leftStartX, leftStartY, imageBoxList.ElementAt(i).Rect.Width, imageBoxList.ElementAt(i).Rect.Height);
                    sortRangeList.Add(imageBoxList.ElementAt(i));
                }
                else
                {
                    //PictureBox tempPbBefor=tempPaintImageList.ElementAt(i-1).Value;
                    //不存在两层元素
                    if (upCrossElement == -1)
                    {
                        ImageEntity tempPbAfter = imageBoxList.ElementAt(i);
                        ImageEntity tempPbBefor;
                        if (i < upFirstElement)
                        {
                            //右边镜像
                            if (mirrorDirection.Equals("mirrorRight"))
                            {
                                //以右边基准
                                //tempPbBefor = imageBoxList.ElementAt(i - 1);
                                ImageEntity mirrorRightDown = imageBoxList.ElementAt(downLastElement);
                                mirrorRightDown.Rect = new Rectangle(leftStartX, leftStartY, mirrorRightDown.Rect.Width, mirrorRightDown.Rect.Height);
                                for (int j = downLastElement; j > 0; j--)
                                {
                                    ImageEntity tempMirrorRightPbBefor = imageBoxList.ElementAt(j);
                                    ImageEntity tempMrrorRightPbAfter = imageBoxList.ElementAt(j - 1);
                                    tempMrrorRightPbAfter.Rect = new Rectangle(tempMirrorRightPbBefor.Rect.X - tempMrrorRightPbAfter.Rect.Width - 1, tempMirrorRightPbBefor.Rect.Y, tempMrrorRightPbAfter.Rect.Width, tempMrrorRightPbAfter.Rect.Height);
                                }
                                i = downLastElement;
                            }
                            else
                            {
                                tempPbBefor = imageBoxList.ElementAt(i - 1);
                                tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                            }                          
                        }
                        else
                        {
                            //单层情况
                            if (upFirstElement == -1)
                            {
                                //右边镜像
                                if (mirrorDirection.Equals("mirrorRight"))
                                {
                                    //以右边基准
                                    ImageEntity mirrorRightDown = imageBoxList.ElementAt(downLastElement);
                                    mirrorRightDown.Rect = new Rectangle(leftStartX, leftStartY, mirrorRightDown.Rect.Width, mirrorRightDown.Rect.Height);
                                    for (int j = downLastElement; j > 0;j-- )
                                    {
                                       ImageEntity tempMirrorRightPbBefor = imageBoxList.ElementAt(j);
                                       ImageEntity tempMrrorRightPbAfter = imageBoxList.ElementAt(j - 1);
                                       tempMrrorRightPbAfter.Rect = new Rectangle(tempMirrorRightPbBefor.Rect.X - tempMrrorRightPbAfter.Rect.Width - 1, tempMirrorRightPbBefor.Rect.Y, tempMrrorRightPbAfter.Rect.Width, tempMrrorRightPbAfter.Rect.Height);
                                    }
                                    i = downLastElement;
                                }
                                else
                                {
                                    tempPbBefor = imageBoxList.ElementAt(i - 1);
                                    tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                }
                            }
                            //双层情况
                            else
                            {
                                if (i == upFirstElement)
                                {
                                    //做上层自动移动
                                    if (srcImageEntity.Type == "over")
                                    {
                                        if (upFirstElement < imageBoxList.Count-1)
                                        {
                                            if (mirrorDirection.Equals("mirrorRight"))
                                            {
                                                //从左面添加
                                                if (destImageEntity.Rect.X == imageBoxList.ElementAt(upFirstElement).Rect.X)
                                                {
                                                    tempPbBefor = imageBoxList.ElementAt(upFirstElement + 1);
                                                    tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                }
                                                //右边添加
                                                else
                                                {
                                                    tempPbBefor = imageBoxList.ElementAt(upFirstElement);
                                                    tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                }
                                            }
                                            else
                                            {
                                                //从左面添加
                                                if (destImageEntity.Rect.X == imageBoxList.ElementAt(upFirstElement).Rect.X)
                                                {
                                                    tempPbBefor = imageBoxList.ElementAt(upFirstElement+1);
                                                    tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X-tempPbAfter.Rect.Width-1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                }
                                                //右边添加
                                                else
                                                {
                                                    //左边镜像，上层以左边为标准e（添加的事上层左边）
                                                    if (destImageEntity.Rect.X == imageBoxList.ElementAt(imageBoxList.Count - 1).Rect.X && destImageEntity.Rect.Y == imageBoxList.ElementAt(imageBoxList.Count - 1).Rect.Y)
                                                    {
                                                        ImageEntity mirrorLeftUpBefor = imageBoxList.ElementAt(imageBoxList.Count - 2);
                                                        ImageEntity mirrorLeftUpAfter = imageBoxList.ElementAt(imageBoxList.Count - 1);
                                                        mirrorLeftUpAfter.Rect = new Rectangle(mirrorLeftUpBefor.Rect.X, mirrorLeftUpBefor.Rect.Y, mirrorLeftUpAfter.Rect.Width, mirrorLeftUpAfter.Rect.Height);
                                                        for (int j = imageBoxList.Count - 1; j > upFirstElement; j--)
                                                        {
                                                            ImageEntity mirrorLeftTempPbBefor = imageBoxList.ElementAt(j);
                                                            ImageEntity mirrorLeftTmepPbAfter = imageBoxList.ElementAt(j - 1);
                                                            mirrorLeftTmepPbAfter.Rect = new Rectangle(mirrorLeftTempPbBefor.Rect.X - mirrorLeftTmepPbAfter.Rect.Width - 1, mirrorLeftTempPbBefor.Rect.Y, mirrorLeftTmepPbAfter.Rect.Width, mirrorLeftTmepPbAfter.Rect.Height);
                                                        }
                                                        break;
                                                    }
                                                    //添加为下层左边或右边或等其他情况时
                                                    else
                                                    {
                                                        //ImageEntity mirrorLeftUpBefor = imageBoxList.ElementAt(imageBoxList.Count - 2);
                                                        ImageEntity mirrorLeftUpAfter = imageBoxList.ElementAt(imageBoxList.Count - 1);
                                                        mirrorLeftUpAfter.Rect = new Rectangle(mirrorLeftUpAfter.Rect.X, mirrorLeftUpAfter.Rect.Y, mirrorLeftUpAfter.Rect.Width, mirrorLeftUpAfter.Rect.Height);
                                                        for (int j = imageBoxList.Count - 1; j > upFirstElement; j--)
                                                        {
                                                            ImageEntity mirrorLeftTempPbBefor = imageBoxList.ElementAt(j);
                                                            ImageEntity mirrorLeftTmepPbAfter = imageBoxList.ElementAt(j - 1);
                                                            mirrorLeftTmepPbAfter.Rect = new Rectangle(mirrorLeftTempPbBefor.Rect.X - mirrorLeftTmepPbAfter.Rect.Width - 1, mirrorLeftTempPbBefor.Rect.Y, mirrorLeftTmepPbAfter.Rect.Width, mirrorLeftTmepPbAfter.Rect.Height);
                                                        }
                                                        break;
                                                    }
                                                }
                                            }
                                           
                                           
                                        }
                                        else
                                        {
                                            if (mirrorDirection.Equals("mirrorRight"))
                                            {
                                                tempPbBefor = imageBoxList.ElementAt(0);
                                                tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X, tempPbBefor.Rect.Y - tempPbBefor.Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                            }
                                            else
                                            {
                                                tempPbBefor = imageBoxList.ElementAt(upFirstElement-1);
                                                tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X+tempPbBefor.Rect.Width-tempPbAfter.Rect.Width, tempPbBefor.Rect.Y - tempPbBefor.Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                            }
                                        }
                                    }
                                    else if (srcImageEntity.Type == "row")
                                    {

                                        if (i == imageBoxList.Count - 1)
                                        {
                                            if (destImageEntity.Rect.X == imageBoxList.ElementAt(i).Rect.X && destImageEntity.Rect.Y == imageBoxList.ElementAt(i).Rect.Y && destImageEntity.Name == imageBoxList.ElementAt(i).Name)
                                            {
                                                int upMoveLen = destImageEntity.Rect.X - srcImageEntity.Rect.X;
                                                int leftOrRightWidth = 0;
                                                //右移
                                                if (upMoveLen > 0)
                                                {
                                                    leftOrRightWidth = imageBoxList.ElementAt(upFirstElement - 1).Rect.X + imageBoxList.ElementAt(upFirstElement - 1).Rect.Width - srcImageEntity.Rect.X;
                                                    //消除边缘悬挂情况
                                                    upMoveLen += srcImageEntity.Rect.Width;
                                                    if (upMoveLen >= leftOrRightWidth)
                                                    {
                                                        tempPbBefor = imageBoxList.ElementAt(upFirstElement - 1);
                                                        tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width - tempPbAfter.Rect.Width, tempPbBefor.Rect.Y - tempPbBefor.Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                    }
                                                    else
                                                    {
                                                        tempPbBefor = imageBoxList.ElementAt(upFirstElement - 1);
                                                        tempPbAfter.Rect = new Rectangle(destImageEntity.Rect.X, tempPbBefor.Rect.Y - tempPbBefor.Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);

                                                    }
                                                }
                                                //左移
                                                else
                                                {
                                                    leftOrRightWidth = srcImageEntity.Rect.X - imageBoxList.ElementAt(0).Rect.X;
                                                    int upLeftLen = srcImageEntity.Rect.X - destImageEntity.Rect.X;
                                                    if (upLeftLen >= leftOrRightWidth)
                                                    {
                                                        tempPbBefor = imageBoxList.ElementAt(0);
                                                        tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X, tempPbBefor.Rect.Y - tempPbBefor.Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                    }
                                                    else
                                                    {
                                                        tempPbBefor = imageBoxList.ElementAt(0);
                                                        tempPbAfter.Rect = new Rectangle(destImageEntity.Rect.X, tempPbBefor.Rect.Y - tempPbBefor.Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //在原位置不变
                                                tempPbBefor = imageBoxList.ElementAt(i);
                                                tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                            }
                                           
                                        }
                                        else
                                        {
                                            //这里继续做,这么做是因为destImageEntiy已经加入了imageboxlist，如果if执行说明upFirstElement且此时移动了它
                                            if (destImageEntity.Rect.X == imageBoxList.ElementAt(i).Rect.X && destImageEntity.Rect.Y == imageBoxList.ElementAt(i).Rect.Y && destImageEntity.Name == imageBoxList.ElementAt(i).Name)
                                            {
                                                int upMoveLen = srcImageEntity.Rect.X - destImageEntity.Rect.X;
                                                int leftWidth = 0;
                                                if (upMoveLen >=0)
                                                {
                                                    leftWidth = srcImageEntity.Rect.X - imageBoxList.ElementAt(0).Rect.X;
                                                    if (srcImageEntity.Rect.X <= imageBoxList.ElementAt(0).Rect.X)
                                                    {
                                                        tempPbBefor = imageBoxList.ElementAt(0);
                                                        tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X, tempPbBefor.Rect.Y - tempPbBefor.Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                    }
                                                    else
                                                    {
                                                        if (destImageEntity.Rect.X >= imageBoxList.ElementAt(0).Rect.X)
                                                        {
                                                            tempPbBefor = imageBoxList.ElementAt(0);
                                                            tempPbAfter.Rect = new Rectangle(destImageEntity.Rect.X, tempPbBefor.Rect.Y - tempPbBefor.Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                        }
                                                        else
                                                        {
                                                            tempPbBefor = imageBoxList.ElementAt(0);
                                                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X, tempPbBefor.Rect.Y - tempPbBefor.Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                        }
                                                        for (int j = upFirstElement; j < imageBoxList.Count - 1; j++)
                                                        {
                                                            tempPbBefor = imageBoxList.ElementAt(j);
                                                            tempPbAfter = imageBoxList.ElementAt(j + 1);
                                                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                        }
                                                        //这里已经一次性将后面的元素排好故要跳出整个for循环
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    //左移超出了边界，左对准
                                                    tempPbBefor = imageBoxList.ElementAt(0);
                                                    tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X, tempPbBefor.Rect.Y - tempPbBefor.Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                   
                                                }
                                            }
                                            else
                                            {
                                                //tempPbBefor = imageBoxList.ElementAt(0);
                                                //tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X, tempPbBefor.Rect.Y - tempPbBefor.Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                //此时没有移动upFirstElement，保持不动
                                                tempPbBefor = imageBoxList.ElementAt(upFirstElement);
                                                tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                            }

                                        }
                                    }
                                }
                                else
                                {
                                    if (i == imageBoxList.Count - 1)
                                    {
                                        if (srcImageEntity.Type == "over")
                                        {
                                            tempPbBefor = imageBoxList.ElementAt(i - 1);
                                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                        }
                                        else if (srcImageEntity.Type == "row")
                                        {
                                            if (destImageEntity.Rect.X == imageBoxList.ElementAt(i).Rect.X && destImageEntity.Rect.Y == imageBoxList.ElementAt(i).Rect.Y && destImageEntity.Name == imageBoxList.ElementAt(i).Name)
                                            {
                                                int upMoreMoveLen = destImageEntity.Rect.X - srcImageEntity.Rect.X;
                                                int rightWidth = imageBoxList.ElementAt(upFirstElement - 1).Rect.Width + imageBoxList.ElementAt(upFirstElement - 1).Rect.X - srcImageEntity.Rect.X;
                                                if (upMoreMoveLen > 0)
                                                {
                                                    if (upMoreMoveLen >= rightWidth)
                                                    {
                                                        //最后一个元素的位置没有超出下层时
                                                        if (srcImageEntity.Rect.X < imageBoxList.ElementAt(upFirstElement - 1).Rect.X)
                                                        {
                                                            tempPbBefor = imageBoxList.ElementAt(upFirstElement - 1);
                                                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width - tempPbAfter.Rect.Width, tempPbBefor.Rect.Y - tempPbBefor.Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                            for (int j = i; j > upFirstElement; j--)
                                                            {
                                                                tempPbBefor = imageBoxList.ElementAt(j);
                                                                tempPbAfter = imageBoxList.ElementAt(j - 1);
                                                                tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X - tempPbAfter.Rect.Width - 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            tempPbBefor = imageBoxList.ElementAt(i - 1);
                                                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        tempPbBefor = imageBoxList.ElementAt(upFirstElement - 1);
                                                        tempPbAfter.Rect = new Rectangle(destImageEntity.Rect.X, tempPbBefor.Rect.Y - tempPbBefor.Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                        for (int j = i; j > upFirstElement; j--)
                                                        {
                                                            tempPbBefor = imageBoxList.ElementAt(j);
                                                            tempPbAfter = imageBoxList.ElementAt(j - 1);
                                                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X - tempPbAfter.Rect.Width - 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    tempPbBefor = imageBoxList.ElementAt(i - 1);
                                                    tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                                }
                                            }
                                            else
                                            {
                                                tempPbBefor = imageBoxList.ElementAt(i - 1);
                                                tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                            }

                                        }
                                    }
                                    else
                                    {
                                        tempPbBefor = imageBoxList.ElementAt(i - 1);
                                        tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                    }

                                }

                            }


                        }
                        //其他已经拖动好的PictureBox,存放其中
                        sortRangeList.Add(tempPbAfter);
                    }
                    //存在两层元素
                    else
                    {
                        ImageEntity tempPbAfter = imageBoxList.ElementAt(i);
                        ImageEntity tempPbBefor;
                        if (i < upFirstElement)
                        {

                            //右边镜像
                            if (mirrorDirection.Equals("mirrorRight"))
                            {
                                //以右边基准
                                ImageEntity mirrorRightDown = imageBoxList.ElementAt(downLastElement);
                                mirrorRightDown.Rect = new Rectangle(leftStartX, leftStartY, mirrorRightDown.Rect.Width, mirrorRightDown.Rect.Height);
                                if (mirrorRightDown.Name.Equals("virtualHRA"))
                                {
                                    xCrossPosition = mirrorRightDown.Rect.X;
                                }
                                for (int j = downLastElement; j > 0; j--)
                                {
                                    ImageEntity tempMirrorRightPbBefor = imageBoxList.ElementAt(j);
                                    ImageEntity tempMrrorRightPbAfter = imageBoxList.ElementAt(j - 1);
                                    tempMrrorRightPbAfter.Rect = new Rectangle(tempMirrorRightPbBefor.Rect.X - tempMrrorRightPbAfter.Rect.Width - 1, tempMirrorRightPbBefor.Rect.Y, tempMrrorRightPbAfter.Rect.Width, tempMrrorRightPbAfter.Rect.Height);
                                    if (tempMrrorRightPbAfter.Name.Equals("virtualHRA"))
                                    {
                                        xCrossPosition = tempMrrorRightPbAfter.Rect.X;
                                    }
                                }
                                i = downLastElement;
                            }
                            else
                            {
                                tempPbBefor = imageBoxList.ElementAt(i - 1);
                                tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);

                                //记录双层元素的x坐标
                                if (tempPbAfter.Name.Equals("virtualHRA"))
                                {
                                    xCrossPosition = tempPbAfter.Rect.X;
                                }
                                sortRangeList.Add(tempPbAfter);
                            }
                         

                            
                        }
                        else
                        {
                            if (i >= upFirstElement)
                            {
                                //此时要以crossElement元素为参照物
                                if (upCrossElement == upFirstElement && i == upFirstElement)
                                {
                                    tempPbBefor = imageBoxList.ElementAt(0);
                                    tempPbAfter.Rect = new Rectangle(xCrossPosition, tempPbBefor.Rect.Y - tempPbBefor.Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                    sortRangeList.Add(tempPbAfter);
                                }
                                else
                                {
                                    //将cross元素前边的元素一次性计算完
                                    if (i < upCrossElement)
                                    {
                                        for (int j = upCrossElement; j > upFirstElement; j--)
                                        {
                                            tempPbBefor = imageBoxList.ElementAt(j);
                                            if (j == upCrossElement)
                                            {
                                                tempPbBefor.Rect = new Rectangle(xCrossPosition, imageBoxList.ElementAt(0).Rect.Y - imageBoxList.ElementAt(0).Rect.Height - 2, tempPbBefor.Rect.Width, tempPbBefor.Rect.Height);
                                            }
                                            tempPbAfter = imageBoxList.ElementAt(j - 1);
                                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X - tempPbAfter.Rect.Width - 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                            sortRangeList.Add(tempPbAfter);
                                        }
                                        i = upCrossElement - 1;
                                    }
                                    //计算cross元素后边元素的位置
                                    else
                                    {
                                        if (i == upCrossElement)
                                        {
                                            tempPbBefor = imageBoxList.ElementAt(i);
                                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                            sortRangeList.Add(tempPbAfter);
                                        }
                                        else if (i > upCrossElement)
                                        {
                                            tempPbBefor = imageBoxList.ElementAt(i - 1);
                                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width+1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                            sortRangeList.Add(tempPbAfter);
                                        }

                                    }
                                }
                            }
                        }
                        //sortRangeList.Add(tempPbAfter);
                    }
                }
            }
            //复原xCrossPosition
            xCrossPosition = -1;
            // imageBoxList.Clear();
            // imageBoxList = sortRangeList;
            return imageBoxList;
        }

        //coolingtype变换后坐标计算
        public static List<ImageEntity> calculatePositionByCoolingType(List<ImageEntity> imageBoxList,string mirrorDirection)
        {
            //定义sortRangeList用来存储设好坐标的PictureBox
            List<ImageEntity> sortRangeList = new List<ImageEntity>();
           
           

            //重新排序

            imageBoxList = getNewDoubleList(imageBoxList, mirrorDirection);

            for (int i = 0; i < imageBoxList.Count; i++)
            {


                if (i == 0)
                {
                    //记录双层元素的x坐标
                    if (imageBoxList.ElementAt(i).Name.Equals("virtualHRA"))
                    {
                        // xCrossPosition = imageBoxList.ElementAt(i).Rect.X;
                        xCrossPosition = leftStartX;
                    }
                    //设置好初始坐标
                    imageBoxList.ElementAt(i).Rect = new Rectangle(leftStartX, leftStartY, imageBoxList.ElementAt(i).Rect.Width, imageBoxList.ElementAt(i).Rect.Height);
                    sortRangeList.Add(imageBoxList.ElementAt(i));
                }
                else
                {
                    //PictureBox tempPbBefor=tempPaintImageList.ElementAt(i-1).Value;
                    //不存在两层元素
                    if (upCrossElement == -1)
                    {
                        ImageEntity tempPbAfter = imageBoxList.ElementAt(i);
                        ImageEntity tempPbBefor;
                        if (i < upFirstElement)
                        {
                            //右边镜像
                            if (mirrorDirection.Equals("mirrorRight"))
                            {
                                //以右边基准
                                //tempPbBefor = imageBoxList.ElementAt(i - 1);
                                ImageEntity mirrorRightDown = imageBoxList.ElementAt(downLastElement);
                                mirrorRightDown.Rect = new Rectangle(leftStartX, leftStartY, mirrorRightDown.Rect.Width, mirrorRightDown.Rect.Height);
                                for (int j = downLastElement; j > 0; j--)
                                {
                                    ImageEntity tempMirrorRightPbBefor = imageBoxList.ElementAt(j);
                                    ImageEntity tempMrrorRightPbAfter = imageBoxList.ElementAt(j - 1);
                                    tempMrrorRightPbAfter.Rect = new Rectangle(tempMirrorRightPbBefor.Rect.X - tempMrrorRightPbAfter.Rect.Width - 1, tempMirrorRightPbBefor.Rect.Y, tempMrrorRightPbAfter.Rect.Width, tempMrrorRightPbAfter.Rect.Height);
                                }
                                i = downLastElement;
                            }
                            else
                            {
                                tempPbBefor = imageBoxList.ElementAt(i - 1);
                                tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                            }
                        }
                        else
                        {
                            //单层情况
                            if (upFirstElement == -1)
                            {
                                //右边镜像
                                if (mirrorDirection.Equals("mirrorRight"))
                                {
                                    //以右边基准
                                    ImageEntity mirrorRightDown = imageBoxList.ElementAt(downLastElement);
                                    mirrorRightDown.Rect = new Rectangle(leftStartX, leftStartY, mirrorRightDown.Rect.Width, mirrorRightDown.Rect.Height);
                                    for (int j = downLastElement; j > 0; j--)
                                    {
                                        ImageEntity tempMirrorRightPbBefor = imageBoxList.ElementAt(j);
                                        ImageEntity tempMrrorRightPbAfter = imageBoxList.ElementAt(j - 1);
                                        tempMrrorRightPbAfter.Rect = new Rectangle(tempMirrorRightPbBefor.Rect.X - tempMrrorRightPbAfter.Rect.Width - 1, tempMirrorRightPbBefor.Rect.Y, tempMrrorRightPbAfter.Rect.Width, tempMrrorRightPbAfter.Rect.Height);
                                    }
                                    i = downLastElement;
                                }
                                else
                                {
                                    tempPbBefor = imageBoxList.ElementAt(i - 1);
                                    tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                }
                            }
                            //双层情况
                            else
                            {
                                if (i == upFirstElement)
                                {

                                    tempPbBefor = imageBoxList.ElementAt(upFirstElement);
                                    tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X, imageBoxList.ElementAt(0).Rect.Y - imageBoxList.ElementAt(0).Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                }
                                else
                                {
                                    if (i == imageBoxList.Count - 1)
                                    {
                                       
                                          
                                               
                                         tempPbBefor = imageBoxList.ElementAt(i - 1);
                                          tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                               
                                         
                                    }
                                    else
                                    {
                                        tempPbBefor = imageBoxList.ElementAt(i - 1);
                                        tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                    }

                                }

                            }


                        }
                        //其他已经拖动好的PictureBox,存放其中
                        sortRangeList.Add(tempPbAfter);
                    }
                    //存在两层元素
                    else
                    {
                        ImageEntity tempPbAfter = imageBoxList.ElementAt(i);
                        ImageEntity tempPbBefor;
                        if (i < upFirstElement)
                        {

                            //右边镜像
                            if (mirrorDirection.Equals("mirrorRight"))
                            {
                                //以右边基准
                                ImageEntity mirrorRightDown = imageBoxList.ElementAt(downLastElement);
                                mirrorRightDown.Rect = new Rectangle(leftStartX, leftStartY, mirrorRightDown.Rect.Width, mirrorRightDown.Rect.Height);
                                if (mirrorRightDown.Name.Equals("virtualHRA"))
                                {
                                    xCrossPosition = mirrorRightDown.Rect.X;
                                }
                                for (int j = downLastElement; j > 0; j--)
                                {
                                    ImageEntity tempMirrorRightPbBefor = imageBoxList.ElementAt(j);
                                    ImageEntity tempMrrorRightPbAfter = imageBoxList.ElementAt(j - 1);
                                    tempMrrorRightPbAfter.Rect = new Rectangle(tempMirrorRightPbBefor.Rect.X - tempMrrorRightPbAfter.Rect.Width - 1, tempMirrorRightPbBefor.Rect.Y, tempMrrorRightPbAfter.Rect.Width, tempMrrorRightPbAfter.Rect.Height);
                                    if (tempMrrorRightPbAfter.Name.Equals("virtualHRA"))
                                    {
                                        xCrossPosition = tempMrrorRightPbAfter.Rect.X;
                                    }
                                }
                                i = downLastElement;
                            }
                            else
                            {
                                tempPbBefor = imageBoxList.ElementAt(i - 1);
                                tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);

                                //记录双层元素的x坐标
                                if (tempPbAfter.Name.Equals("virtualHRA"))
                                {
                                    xCrossPosition = tempPbAfter.Rect.X;
                                }
                                sortRangeList.Add(tempPbAfter);
                            }



                        }
                        else
                        {
                            if (i >= upFirstElement)
                            {
                                //此时要以crossElement元素为参照物
                                if (upCrossElement == upFirstElement && i == upFirstElement)
                                {
                                    tempPbBefor = imageBoxList.ElementAt(0);
                                    tempPbAfter.Rect = new Rectangle(xCrossPosition, tempPbBefor.Rect.Y - tempPbBefor.Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                    sortRangeList.Add(tempPbAfter);
                                }
                                else
                                {
                                    //将cross元素前边的元素一次性计算完
                                    if (i < upCrossElement)
                                    {
                                        for (int j = upCrossElement; j > upFirstElement; j--)
                                        {
                                            tempPbBefor = imageBoxList.ElementAt(j);
                                            if (j == upCrossElement)
                                            {
                                                tempPbBefor.Rect = new Rectangle(xCrossPosition, imageBoxList.ElementAt(0).Rect.Y - imageBoxList.ElementAt(0).Rect.Height - 2, tempPbBefor.Rect.Width, tempPbBefor.Rect.Height);
                                            }
                                            tempPbAfter = imageBoxList.ElementAt(j - 1);
                                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X - tempPbAfter.Rect.Width - 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                            sortRangeList.Add(tempPbAfter);
                                        }
                                        i = upCrossElement - 1;
                                    }
                                    //计算cross元素后边元素的位置
                                    else
                                    {
                                        if (i == upCrossElement)
                                        {
                                            tempPbBefor = imageBoxList.ElementAt(i);
                                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                            sortRangeList.Add(tempPbAfter);
                                        }
                                        else if (i > upCrossElement)
                                        {
                                            tempPbBefor = imageBoxList.ElementAt(i - 1);
                                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                            sortRangeList.Add(tempPbAfter);
                                        }

                                    }
                                }
                            }
                        }
                        //sortRangeList.Add(tempPbAfter);
                    }
                }
            }
            //复原xCrossPosition
            xCrossPosition = -1;
            // imageBoxList.Clear();
            // imageBoxList = sortRangeList;
            return imageBoxList;

        }

        //以左边对齐删除算法
        public static List<ImageEntity> deleteImageEntityPosition(List<ImageEntity> imageBoxList,ImageEntity deleteImageEntity,string mirrorDirection)
        {           
            //定义sortRangeList用来存储设好坐标的PictureBox
            List<ImageEntity> sortRangeList = new List<ImageEntity>();
            //判断 deleteImageEntity是否为第一个
            bool isDelUpFirst = isDeleteUpFirstElement(imageBoxList, deleteImageEntity);
          
            if (RightImageRangeType.imageRangeTypeArray[0].Equals(deleteImageEntity.Name))
            {
                removeListImageEntity(imageBoxList, deleteImageEntity);
                removeListImageEntity(imageBoxList, deleteImageEntity.Rect.X, "virtualHRA");
            }
            else
            {
                removeListImageEntity(imageBoxList, deleteImageEntity);
            }
            //重新排序

            imageBoxList = getNewDoubleList(imageBoxList, mirrorDirection);

            for (int i = 0; i < imageBoxList.Count; i++)
            {


                if (i == 0)
                {
                    //记录双层元素的x坐标
                    if (imageBoxList.ElementAt(i).Name.Equals("virtualHRA"))
                    {
                        // xCrossPosition = imageBoxList.ElementAt(i).Rect.X;
                        xCrossPosition = leftStartX;
                    }
                    //设置好初始坐标
                    imageBoxList.ElementAt(i).Rect = new Rectangle(leftStartX, leftStartY, imageBoxList.ElementAt(i).Rect.Width, imageBoxList.ElementAt(i).Rect.Height);
                    sortRangeList.Add(imageBoxList.ElementAt(i));
                }
                else
                {
                    //PictureBox tempPbBefor=tempPaintImageList.ElementAt(i-1).Value;
                    //不存在两层元素
                    if (upCrossElement == -1)
                    {
                        ImageEntity tempPbAfter = imageBoxList.ElementAt(i);
                        ImageEntity tempPbBefor;
                        if (i < upFirstElement)
                        {
                            //右边镜像
                            if (mirrorDirection.Equals("mirrorRight"))
                            {
                                //以右边基准
                                //tempPbBefor = imageBoxList.ElementAt(i - 1);
                                ImageEntity mirrorRightDown = imageBoxList.ElementAt(downLastElement);
                                mirrorRightDown.Rect = new Rectangle(mirrorRightDown.Rect.X,leftStartY, mirrorRightDown.Rect.Width, mirrorRightDown.Rect.Height);
                                for (int j = downLastElement; j > 0; j--)
                                {
                                    ImageEntity tempMirrorRightPbBefor = imageBoxList.ElementAt(j);
                                    ImageEntity tempMrrorRightPbAfter = imageBoxList.ElementAt(j - 1);
                                    tempMrrorRightPbAfter.Rect = new Rectangle(tempMirrorRightPbBefor.Rect.X - tempMrrorRightPbAfter.Rect.Width - 1, tempMirrorRightPbBefor.Rect.Y, tempMrrorRightPbAfter.Rect.Width, tempMrrorRightPbAfter.Rect.Height);
                                }
                                i = downLastElement;
                            }
                            else
                            {
                                tempPbBefor = imageBoxList.ElementAt(i - 1);
                                tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                            } 
                        }
                        else
                        {
                            //单层情况
                            if (upFirstElement == -1)
                            {
                                //右边镜像
                                if (mirrorDirection.Equals("mirrorRight"))
                                {
                                    //以右边基准
                                    //tempPbBefor = imageBoxList.ElementAt(i - 1);
                                    ImageEntity mirrorRightDown = imageBoxList.ElementAt(downLastElement);
                                    mirrorRightDown.Rect = new Rectangle(leftStartX, leftStartY, mirrorRightDown.Rect.Width, mirrorRightDown.Rect.Height);
                                    for (int j = downLastElement; j > 0; j--)
                                    {
                                        ImageEntity tempMirrorRightPbBefor = imageBoxList.ElementAt(j);
                                        ImageEntity tempMrrorRightPbAfter = imageBoxList.ElementAt(j - 1);
                                        tempMrrorRightPbAfter.Rect = new Rectangle(tempMirrorRightPbBefor.Rect.X - tempMrrorRightPbAfter.Rect.Width - 1, tempMirrorRightPbBefor.Rect.Y, tempMrrorRightPbAfter.Rect.Width, tempMrrorRightPbAfter.Rect.Height);
                                    }
                                    i = downLastElement;
                                }
                                else
                                {
                                    tempPbBefor = imageBoxList.ElementAt(i - 1);
                                    tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                } 
                            }
                            //双层情况
                            else
                            {
                                if (i == upFirstElement)
                                {
                                    if (isDelUpFirst)
                                    {
                                        tempPbBefor = deleteImageEntity;
                                        tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);

                                    }
                                    else
                                    {
                                        tempPbBefor = imageBoxList.ElementAt(upFirstElement);
                                        tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                    }
                                 }
                                else
                                {                                  
                                        tempPbBefor = imageBoxList.ElementAt(i - 1);
                                        tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);                                                                    
                                }

                            }


                        }
                        //其他已经拖动好的PictureBox,存放其中
                        sortRangeList.Add(tempPbAfter);
                    }
                    //存在两层元素
                    else
                    {
                        ImageEntity tempPbAfter = imageBoxList.ElementAt(i);
                        ImageEntity tempPbBefor;
                        if (i < upFirstElement)
                        {
                            tempPbBefor = imageBoxList.ElementAt(i - 1);
                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);

                            //记录双层元素的x坐标
                            if (tempPbAfter.Name.Equals("virtualHRA"))
                            {
                                xCrossPosition = tempPbAfter.Rect.X;
                            }
                            sortRangeList.Add(tempPbAfter);
                        }
                        else
                        {
                            if (i >= upFirstElement)
                            {
                                //此时要以crossElement元素为参照物
                                if (upCrossElement == upFirstElement && i == upFirstElement)
                                {
                                    tempPbBefor = imageBoxList.ElementAt(0);
                                    tempPbAfter.Rect = new Rectangle(xCrossPosition, tempPbBefor.Rect.Y - tempPbBefor.Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                    sortRangeList.Add(tempPbAfter);
                                }
                                else
                                {
                                    //将cross元素前边的元素一次性计算完
                                    if (i < upCrossElement)
                                    {
                                        for (int j = upCrossElement; j > upFirstElement; j--)
                                        {
                                            tempPbBefor = imageBoxList.ElementAt(j);
                                            if (j == upCrossElement)
                                            {
                                                tempPbBefor.Rect = new Rectangle(xCrossPosition, imageBoxList.ElementAt(0).Rect.Y - imageBoxList.ElementAt(0).Rect.Height - 2, tempPbBefor.Rect.Width, tempPbBefor.Rect.Height);
                                            }
                                            tempPbAfter = imageBoxList.ElementAt(j - 1);
                                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X - tempPbAfter.Rect.Width - 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                            sortRangeList.Add(tempPbAfter);
                                        }
                                        i = upCrossElement - 1;
                                    }
                                    //计算cross元素后边元素的位置
                                    else
                                    {
                                        if (i == upCrossElement)
                                        {
                                            tempPbBefor = imageBoxList.ElementAt(i);
                                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                            sortRangeList.Add(tempPbAfter);
                                        }
                                        else if (i > upCrossElement)
                                        {
                                            tempPbBefor = imageBoxList.ElementAt(i - 1);
                                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width+1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                                            sortRangeList.Add(tempPbAfter);
                                        }

                                    }
                                }
                            }
                        }
                        //sortRangeList.Add(tempPbAfter);
                    }
                }
            }
            //复原xCrossPosition
            xCrossPosition = -1;
            // imageBoxList.Clear();
            // imageBoxList = sortRangeList;
            return imageBoxList;
        }
        //排序函数
        private static List<ImageEntity> getRangleImageEntityList(List<ImageEntity> imageBoxList)
        {
            imageBoxList.Sort(comparison);
            return imageBoxList;
        }
        //比较器
        private static int comparison(PictureBoxInfo pictureInfo1, PictureBoxInfo pictureInfo2)
        {
            return pictureInfo1.DLocation.X.CompareTo(pictureInfo2.DLocation.X);
        }

        //排序函数
        public static List<PictureBoxInfo> getRanglePictureInfoList(List<PictureBoxInfo> imageBoxList)
        {
            imageBoxList.Sort(comparison);
            return imageBoxList;
        }
        //比较器
        private static int comparison(ImageEntity imageEntity1, ImageEntity imageEntity2)
        {
            return imageEntity1.Rect.X.CompareTo(imageEntity2.Rect.X);
        }

        //双层链表排序函数
        private static List<ImageEntity> getNewDoubleList(List<ImageEntity> imageList, string leftOrRight)
        {
            int j = 0;
            List<ImageEntity> downList = new List<ImageEntity>();
            List<ImageEntity> upList = new List<ImageEntity>();
           // imageList = getRangleImageEntityList(imageList);
            for (int i = 0; i < imageList.Count; i++)
            {
                ImageBlock imageBlock=ImageBlockBLL.getImageBlocksByNames(imageList.ElementAt(i).Name,imageList.ElementAt(i).coolingType);
                if (i == 0)
                {
                    imageList.ElementAt(0).moduleTag = "101-" + imageBlock.ParentName;
                    downList.Add(imageList.ElementAt(0));

                }
                else
                {
                    ImageEntity firstDownElement = imageList.ElementAt(0);
                    if ((firstDownElement.Rect.Y == imageList.ElementAt(i).Rect.Y || Math.Abs(firstDownElement.Rect.Y - imageList.ElementAt(i).Rect.Y) < 0.6 * imageList.ElementAt(i).Rect.Height || firstDownElement.Rect.Y - imageList.ElementAt(i).Rect.Y < 0 || imageList.ElementAt(i).Name == "virtualHRA"||FrontPhotoConstraintService.onlyExistDownLayerElement.Contains(imageList.ElementAt(i).Name)) && imageList.ElementAt(i).Name != "HRA")
                    {
                        imageList.ElementAt(i).moduleTag = "1" + (i < 10 ? "0" +( i+1)+"-" : i+"-")+ imageBlock.ParentName;
                        downList.Add(imageList.ElementAt(i));
                    }
                    else
                    {
                        j++;
                        imageList.ElementAt(i).moduleTag = "2" + (j < 10 ? "0" + j +"-": j + "-")+ imageBlock.ParentName;
                        upList.Add(imageList.ElementAt(i));
                    }
                }
            }
            //上下链表分别排序
            if (downList.Count > 0)
            {
                downList = getRangleImageEntityList(downList);
                downLastElement = downList.Count - 1;

            }
            if (upList.Count > 0)
            {
                upList = getRangleImageEntityList(upList);
            }
            //清空imageList
            imageList.Clear();
            for (int i = 0; i < downList.Count; i++)
            {
                imageList.Add(downList.ElementAt(i));
            }
            for (int i = 0; i < upList.Count; i++)
            {
                imageList.Add(upList.ElementAt(i));
            }
            //如果存在上层，就记录下上层第一个元素的位置
            if (upList.Count > 0)
            {
                upFirstElement = downList.Count;
            }
            else
            {
                upFirstElement = -1;
            }
            //查找crossImageEntity位置
            int upCrossflag = -1;
            for (int i = 0; i < imageList.Count; i++)
            {
                if (RightImageRangeType.imageRangeTypeArray[0].Equals(imageList.ElementAt(i).Name))
                {
                    upCrossflag = i;
                }
            }
            upCrossElement = upCrossflag;

            return imageList;

        }

        public static List<ImageEntity> removeListImageEntity(List<ImageEntity> srcList, ImageEntity srcEntity)
        {
            for (int i = 0; i < srcList.Count; i++)
            {
                ImageEntity tempImageEntity = srcList.ElementAt(i);
                if (tempImageEntity.Rect.X == srcEntity.Rect.X && tempImageEntity.Rect.Y == srcEntity.Rect.Y && tempImageEntity.Rect.Width == srcEntity.Rect.Width && tempImageEntity.Rect.Height == srcEntity.Rect.Height)
                {
                    if (srcList.Count > 0)
                        srcList.RemoveAt(i);
                }
            }
            return srcList;
        }

        //专门用来删除virtualHRA
        public static List<ImageEntity> removeListImageEntity(List<ImageEntity> srcList, int xPosition, string Name)
        {
            for (int i = 0; i < srcList.Count; i++)
            {
                ImageEntity tempImageEntity = srcList.ElementAt(i);
                if (tempImageEntity.Rect.X == xPosition && tempImageEntity.Name == Name)
                {
                    if (srcList.Count > 0)
                        srcList.RemoveAt(i);
                }
            }
            return srcList;
        }

        public static List<ImageEntity> initSingleLayerOPeratorPhoto(List<ImageEntity> imageBoxList,int coolingType=5)
        {
            int startXPosition = 200;
            int startYPosition = 350;
            //if (5 == coolingType)
            //{
                ImageBlock imageBlock;

                ImageEntity imageEntityFTA = new ImageEntity();
                imageEntityFTA.Name = "FTA";
                imageBlock = ImageBlockBLL.getImageBlocksByNames(imageEntityFTA.Name, coolingType);
                int ftaWidth = Convert.ToInt32(imageBlock.ImageLength * factor);
                int ftaHight = Convert.ToInt32(imageBlock.ImageHeight * factor);
                imageEntityFTA.Rect = new Rectangle(startXPosition, startYPosition, ftaWidth, ftaHight);
                imageEntityFTA.Url = ImageBoxService.getImageUrl(imageEntityFTA.Name);
                imageEntityFTA.Type = "row";
                imageEntityFTA.Text = imageBlock.Text;
                imageEntityFTA.firstDistance = imageBlock.FirstDistance;
                imageEntityFTA.secondDistance = imageBlock.SecondDistance;
                imageEntityFTA.coolingType = coolingType;
                imageEntityFTA.isSelected = false;
                imageEntityFTA.moduleTag = "101-"+imageBlock.ParentName;
                imageEntityFTA.parentName = imageBlock.ParentName;
                imageEntityFTA.Guid = Guid.NewGuid().ToString("N");
                imageEntityFTA.orderId = FrontPhotoImageModelService.orderId;
                imageEntityFTA.imageWidth =Convert.ToInt32(imageBlock.ImageWidth);
                imageEntityFTA.thirdDistance = imageBlock.ThirdDistance;
                imageEntityFTA.topViewFirstDistance = imageBlock.TopViewFirstDistance;
                imageEntityFTA.topViewSecondDistance = imageBlock.TopViewSecondDistance;


                ImageEntity imageEntityCLF = new ImageEntity();
                
                imageEntityCLF.Name = "CLF";
                imageBlock = ImageBlockBLL.getImageBlocksByNames(imageEntityCLF.Name, coolingType);
                int clfWidth = Convert.ToInt32(imageBlock.ImageLength * factor);
                int clfHeight = Convert.ToInt32(imageBlock.ImageHeight * factor);
                imageEntityCLF.Url = ImageBoxService.getImageUrl(imageEntityCLF.Name);
                imageEntityCLF.Rect = new Rectangle(imageEntityFTA.Rect.X + imageEntityFTA.Rect.Width + 1, imageEntityFTA.Rect.Y, clfWidth, clfHeight);
                imageEntityCLF.Type = "row";
                imageEntityCLF.Text = imageBlock.Text;
                imageEntityCLF.firstDistance = imageBlock.FirstDistance;
                imageEntityCLF.secondDistance = imageBlock.SecondDistance;
                imageEntityCLF.coolingType = coolingType;
                imageEntityCLF.isSelected = false;
                imageEntityCLF.moduleTag = "102-"+imageBlock.ParentName;
                imageEntityCLF.parentName = imageBlock.ParentName;
                imageEntityCLF.Guid = Guid.NewGuid().ToString("N");
                imageEntityCLF.orderId = FrontPhotoImageModelService.orderId;
                imageEntityCLF.imageWidth = Convert.ToInt32(imageBlock.ImageWidth);
                imageEntityCLF.thirdDistance = imageBlock.ThirdDistance;
                imageEntityCLF.topViewFirstDistance = imageBlock.TopViewFirstDistance;
                imageEntityCLF.topViewSecondDistance = imageBlock.TopViewSecondDistance;


                ImageEntity imageEntitySFA = new ImageEntity();
                
                imageEntitySFA.Name = "SFA";
                imageBlock = ImageBlockBLL.getImageBlocksByNames(imageEntitySFA.Name, coolingType);
                int sfaWidth = Convert.ToInt32(imageBlock.ImageLength * factor);
                int sfaHeight = Convert.ToInt32(imageBlock.ImageHeight * factor);
                imageEntitySFA.Url = ImageBoxService.getImageUrl(imageEntitySFA.Name);
                imageEntitySFA.Rect = new Rectangle(imageEntityCLF.Rect.X + imageEntityCLF.Rect.Width + 1, imageEntityCLF.Rect.Y, sfaWidth, sfaHeight);
                imageEntitySFA.Type = "row";
                imageEntitySFA.Text = imageBlock.Text;
                imageEntitySFA.firstDistance = imageBlock.FirstDistance;
                imageEntitySFA.secondDistance = imageBlock.SecondDistance;
                imageEntitySFA.coolingType = coolingType;
                imageEntitySFA.isSelected = false;
                imageEntitySFA.moduleTag = "103-"+imageBlock.ParentName;
                imageEntitySFA.parentName = imageBlock.ParentName;
                imageEntitySFA.Guid = Guid.NewGuid().ToString("N");
                imageEntitySFA.orderId = FrontPhotoImageModelService.orderId;
                imageEntitySFA.imageWidth = Convert.ToInt32(imageBlock.ImageWidth);
                imageEntitySFA.thirdDistance = imageBlock.ThirdDistance;
                imageEntitySFA.topViewFirstDistance = imageBlock.TopViewFirstDistance;
                imageEntitySFA.topViewSecondDistance = imageBlock.TopViewSecondDistance;


                imageBoxList.Add(imageEntityFTA);
                imageBoxList.Add(imageEntityCLF);
                imageBoxList.Add(imageEntitySFA);
            //}
            return imageBoxList;
        }

        //缩小函数

        public static List<ImageEntity> zoomOutImageEntity(List<ImageEntity> imageBoxList,double factor)
        {
            //为判断是否存在两层做准备
           imageBoxList=getNewDoubleList(imageBoxList,"left");
           List<ImageEntity> storeImageEntityList = new List<ImageEntity>();
            int width=0;
            int height=0;
            int x = 0;
            int y = 0;
            //记录存在两层元素而且在第一个时，y应该设置的坐标
            int changeY = 0;
            //确定leftX位置
            leftStartX = imageBoxList.ElementAt(0).Rect.X;
           for (int i = 0; i < imageBoxList.Count;i++)
           {
               //无两层
               ImageEntity imageEntity = imageBoxList.ElementAt(i);
               width = Convert.ToInt32(imageEntity.Rect.Width * factor);
               if (RightImageRangeType.imageRangeType.Contains(imageEntity.Name))
               {
                   height = Convert.ToInt32((imageEntity.Rect.Height-2) * factor)+2;
               }
               else
               {
                   height = Convert.ToInt32(imageEntity.Rect.Height * factor);
               }
          
               if (upFirstElement == -1)
               {

                   if (i == 0)
                   {                    
                       imageEntity.Rect = new Rectangle(leftStartX, leftStartY, width, height);

                   }
                   else
                   {
                        x = imageBoxList.ElementAt(i - 1).Rect.X + imageBoxList.ElementAt(i - 1).Rect.Width;
                        y = imageBoxList.ElementAt(i - 1).Rect.Y;
                       imageEntity.Rect = new Rectangle(x,y,width,height);
                   }
               }
               //存在两层
               else
               {
                   if (i == 0)
                   {
                           changeY = imageEntity.Rect.Height - height;
                           imageEntity.Rect = new Rectangle(leftStartX, leftStartY, width, height);
                                        
                   }
                   else
                   {
                       int currentDistance = imageEntity.Rect.X - leftStartX;
                       //表示在第一个元素的右边
                       if (currentDistance >= 0)
                       {
                           if (i == upFirstElement)
                           {
                               if (RightImageRangeType.imageRangeType.Contains(imageEntity.Name))
                               {
                                   x = Convert.ToInt32(leftStartX + currentDistance * factor);
                                   y = Convert.ToInt32(imageEntity.Rect.Y + changeY);
                                   imageEntity.Rect = new Rectangle(x, y, width, height);
                               }
                               else
                               {
                                   x = Convert.ToInt32(leftStartX +currentDistance * factor);
                                   y = Convert.ToInt32(imageEntity.Rect.Y +imageEntity.Rect.Height -height);
                                   imageEntity.Rect = new Rectangle(x, y, width, height);
                               }
                           }
                           else
                           {

                               x = Convert.ToInt32(imageBoxList.ElementAt(i - 1).Rect.X + imageBoxList.ElementAt(i - 1).Rect.Width);
                               y = Convert.ToInt32(imageBoxList.ElementAt(i - 1).Rect.Y);
                               imageEntity.Rect = new Rectangle(x, y, width, height);


                           }
                       }
                       else
                       {
                           
                           if (i == upFirstElement)
                           {        
                               
                                   ImageEntity tempImageEntity = imageBoxList.ElementAt(imageBoxList.Count - 1);
                                   currentDistance = Math.Abs(tempImageEntity.Rect.X - leftStartX);
                                   width = Convert.ToInt32(tempImageEntity.Rect.Width * factor);
                                   if (RightImageRangeType.imageRangeType.Contains(tempImageEntity.Name))
                                   {
                                       height = Convert.ToInt32((tempImageEntity.Rect.Height - 2) * factor) + 2;
                                   }
                                   else
                                   {
                                       height = Convert.ToInt32(tempImageEntity.Rect.Height * factor);
                                   }
                                   if (RightImageRangeType.imageRangeType.Contains(tempImageEntity.Name))
                                   {          
                                       //changeY由第一个确定(i=0)，当virtualHRA为第一个，HRA为最后一个时
                                       y = Convert.ToInt32(tempImageEntity.Rect.Y + changeY);                                   
                                   }
                                   else
                                   {
                                       y = Convert.ToInt32(tempImageEntity.Rect.Y + imageEntity.Rect.Height - height);                                    
                                   }   
                                   x = Convert.ToInt32(leftStartX + currentDistance * factor);
                                  // y = Convert.ToInt32(tempImageEntity.Rect.Y + imageEntity.Rect.Height - height);
                                   tempImageEntity.Rect = new Rectangle(x, y, width, height);
                                                             
                               for (int j = imageBoxList.Count - 1; j > i;j-- )
                               {
                                   ImageEntity tempBeforeImageEntity = imageBoxList.ElementAt(j);
                                   ImageEntity tempAfterImageEntity = imageBoxList.ElementAt(j - 1);

                                   width = Convert.ToInt32(tempAfterImageEntity.Rect.Width * factor);
                                   if (RightImageRangeType.imageRangeType.Contains(tempAfterImageEntity.Name))
                                   {
                                       height = Convert.ToInt32((tempAfterImageEntity.Rect.Height - 2) * factor) + 2;
                                   }
                                   else
                                   {
                                       height = Convert.ToInt32(tempAfterImageEntity.Rect.Height * factor);
                                   }
                                
                                   if (RightImageRangeType.imageRangeType.Contains(tempAfterImageEntity.Name))
                                   {
                                       x = Convert.ToInt32(tempBeforeImageEntity.Rect.X - width);
                                       y = Convert.ToInt32(tempAfterImageEntity.Rect.Y + changeY);
                                       tempAfterImageEntity.Rect = new Rectangle(x, y, width, height);
                                   }
                                   else
                                   {
                                       x = Convert.ToInt32(tempBeforeImageEntity.Rect.X - width);
                                       y = Convert.ToInt32(tempAfterImageEntity.Rect.Y + tempAfterImageEntity.Rect.Height - height);
                                       tempAfterImageEntity.Rect = new Rectangle(x, y, width, height);
                                   }                                                              
                               }
                               // currentDistance = Math.Abs(tempImageEntity.Rect.X - leftStartX);
                               //x = Convert.ToInt32(imageEntity.Rect.X + currentDistance * factor);
                               //y = Convert.ToInt32(imageEntity.Rect.Y+imageEntity.Rect.Height-height);
                               //imageEntity.Rect = new Rectangle(x, y, width, height);
                               break;
                           }
                           else
                           {
                               //x = Convert.ToInt32(imageBoxList.ElementAt(i - 1).Rect.X + imageBoxList.ElementAt(i - 1).Rect.Width);
                               //y = Convert.ToInt32(imageBoxList.ElementAt(i - 1).Rect.Y);
                               //imageEntity.Rect = new Rectangle(x, y, width, height);
                           }
                       }                 
                   }    
               }
           }
            

            return imageBoxList;
        }

        //放大函数
        public static List<ImageEntity> zoomInImangeEntity(List<ImageEntity> imageBoxList,double factor)
        {
            imageBoxList = getNewDoubleList(imageBoxList, "left");
            List<ImageEntity> storeImageEntityList = new List<ImageEntity>();
            int width = 0;
            int height = 0;
            int x = 0;
            int y = 0;
            //记录存在两层元素而且在第一个时，y应该设置的坐标
            int changeY = 0;
            //确定leftX位置
            leftStartX = imageBoxList.ElementAt(0).Rect.X;
            for (int i = 0; i < imageBoxList.Count; i++)
            {
                //无两层
                ImageEntity imageEntity = imageBoxList.ElementAt(i);
                width = Convert.ToInt32(imageEntity.Rect.Width * factor);
                if (RightImageRangeType.imageRangeType.Contains(imageEntity.Name))
                {
                    height = Convert.ToInt32((imageEntity.Rect.Height - 2) * factor) + 2;
                }
                else
                {
                    height = Convert.ToInt32(imageEntity.Rect.Height * factor);
                }
                if (upFirstElement == -1)
                {

                    if (i == 0)
                    {
                        imageEntity.Rect = new Rectangle(leftStartX, leftStartY, width, height);

                    }
                    else
                    {
                        x = imageBoxList.ElementAt(i - 1).Rect.X + imageBoxList.ElementAt(i - 1).Rect.Width;
                        y = imageBoxList.ElementAt(i - 1).Rect.Y;
                        imageEntity.Rect = new Rectangle(x, y, width, height);
                    }
                }
                //存在两层
                else
                {
                    if (i == 0)
                    {
                        changeY =height- imageEntity.Rect.Height;
                        imageEntity.Rect = new Rectangle(leftStartX, leftStartY, width, height);
                    }
                    else
                    {
                        int currentDistance = imageEntity.Rect.X - leftStartX;
                        //表示在第一个元素的右边
                        if (currentDistance >= 0)
                        {
                            if (i == upFirstElement)
                            {
                                if (RightImageRangeType.imageRangeType.Contains(imageEntity.Name))
                                {
                                    x = Convert.ToInt32(leftStartX + currentDistance * factor);
                                    y = Convert.ToInt32(imageEntity.Rect.Y - changeY);
                                    imageEntity.Rect = new Rectangle(x, y, width, height);
                                }
                                else
                                {
                                    x = Convert.ToInt32(leftStartX + currentDistance * factor);
                                    y = Convert.ToInt32(imageEntity.Rect.Y -(height-imageEntity.Rect.Height));
                                    imageEntity.Rect = new Rectangle(x, y, width, height);
                                }
                            }
                            else
                            {

                                x = Convert.ToInt32(imageBoxList.ElementAt(i - 1).Rect.X + imageBoxList.ElementAt(i - 1).Rect.Width);
                                y = Convert.ToInt32(imageBoxList.ElementAt(i - 1).Rect.Y);
                                imageEntity.Rect = new Rectangle(x, y, width, height);


                            }
                        }
                        else
                        {
                            currentDistance = Math.Abs(imageEntity.Rect.X - leftStartX);
                            if (i == upFirstElement)
                            {
                                x = Convert.ToInt32(imageEntity.Rect.X -(currentDistance * factor-currentDistance));
                                y = Convert.ToInt32(imageEntity.Rect.Y -( height-imageEntity.Rect.Height));
                                imageEntity.Rect = new Rectangle(x, y, width, height);
                            }
                            else
                            {
                                x = Convert.ToInt32(imageBoxList.ElementAt(i - 1).Rect.X + imageBoxList.ElementAt(i - 1).Rect.Width);
                                y = Convert.ToInt32(imageBoxList.ElementAt(i - 1).Rect.Y);
                                imageEntity.Rect = new Rectangle(x, y, width, height);
                            }
                        }
                    }
                }
            }
            return imageBoxList;
        }

        //删除元素是否为第一个
        public static bool isDeleteUpFirstElement(List<ImageEntity> imageList,ImageEntity deleteImageElement)
        {
            List<ImageEntity> downList = new List<ImageEntity>();
            List<ImageEntity> upList = new List<ImageEntity>();
            for (int i = 0; i < imageList.Count; i++)
            {
                ImageBlock imageBlock = ImageBlockBLL.getImageBlocksByNames(imageList.ElementAt(i).Name, imageList.ElementAt(i).coolingType);
                if (i == 0)
                {
                    downList.Add(imageList.ElementAt(0));

                }
                else
                {
                    ImageEntity firstDownElement = imageList.ElementAt(0);
                    if ((firstDownElement.Rect.Y == imageList.ElementAt(i).Rect.Y || Math.Abs(firstDownElement.Rect.Y - imageList.ElementAt(i).Rect.Y) < 0.6 * imageList.ElementAt(i).Rect.Height || firstDownElement.Rect.Y - imageList.ElementAt(i).Rect.Y < 0 || imageList.ElementAt(i).Name == "virtualHRA" || FrontPhotoConstraintService.onlyExistDownLayerElement.Contains(imageList.ElementAt(i).Name)) && imageList.ElementAt(i).Name != "HRA")
                    {                   
                        downList.Add(imageList.ElementAt(i));
                    }
                    else
                    {                    
                        upList.Add(imageList.ElementAt(i));
                    }
                }
            }
            if(upList.Count>0){
                if (deleteImageElement.Rect.X == upList.ElementAt(0).Rect.X && deleteImageElement.Rect.Y == upList.ElementAt(0).Rect.Y && deleteImageElement.Name == upList.ElementAt(0).Name)
                {
                    return true;
                }
            }
            return false;
        }

        //镜像坐标计算
        public static List<ImageEntity> calculateMirrorPosition(List<ImageEntity> imageList,int panelWidth)
        {
            for (int i = 0; i < imageList.Count;i++ )
            {
                ImageEntity imageEntity = imageList.ElementAt(i);
                imageEntity.Rect = new Rectangle(panelWidth - imageEntity.Rect.X-imageEntity.Rect.Width, imageEntity.Rect.Y, imageEntity.Rect.Width, imageEntity.Rect.Height);
            }
            imageList = getNewDoubleList(imageList, "");
            return imageList;
        }

        //左右对齐算法
        public static List<ImageEntity> calculateAlignmentLeftOrRight(List<ImageEntity> imageList,int downSelectedElement,int upSelectedElement)
        {
            //获得上层第一个元素的位置
            imageList = getNewDoubleList(imageList, null);
           
                if(leftAlignment){
                    ImageEntity upSelectedImageEntity = imageList.ElementAt(upSelectedElement);
                    ImageEntity downSelectedImageEntity = imageList.ElementAt(downSelectedElement);
                    upSelectedImageEntity.Rect = new Rectangle(downSelectedImageEntity.Rect.X,upSelectedImageEntity.Rect.Y,upSelectedImageEntity.Rect.Width,upSelectedImageEntity.Rect.Height);
                    for (int i = upSelectedElement; i > upFirstElement;i-- )
                    {
                        ImageEntity upPbBefore = imageList.ElementAt(i);
                        ImageEntity upPbAfter = imageList.ElementAt(i - 1);
                        upPbAfter.Rect = new Rectangle(upPbBefore.Rect.X-upPbAfter.Rect.Width-1,upPbBefore.Rect.Y,upPbAfter.Rect.Width,upPbAfter.Rect.Height);
                    }
                    for (int i = upSelectedElement+1; i < imageList.Count;i++ )
                    {
                        ImageEntity upPbBefore = imageList.ElementAt(i-1);
                        ImageEntity upPbAfter = imageList.ElementAt(i);
                        upPbAfter.Rect = new Rectangle(upPbBefore.Rect.X+upPbBefore.Rect.Width+1,upPbBefore.Rect.Y,upPbAfter.Rect.Width,upPbAfter.Rect.Height);
                    }
                }
                else if(rightAlignment){
                    ImageEntity upSelectedImageEntity = imageList.ElementAt(upSelectedElement);
                    ImageEntity downSelectedImageEntity = imageList.ElementAt(downSelectedElement);
                    upSelectedImageEntity.Rect = new Rectangle(downSelectedImageEntity.Rect.X+downSelectedImageEntity.Rect.Width-upSelectedImageEntity.Rect.Width, upSelectedImageEntity.Rect.Y, upSelectedImageEntity.Rect.Width, upSelectedImageEntity.Rect.Height);
                    for (int i = upSelectedElement; i > upFirstElement; i--)
                    {
                        ImageEntity upPbBefore = imageList.ElementAt(i);
                        ImageEntity upPbAfter = imageList.ElementAt(i - 1);
                        upPbAfter.Rect = new Rectangle(upPbBefore.Rect.X - upPbAfter.Rect.Width - 1, upPbBefore.Rect.Y, upPbAfter.Rect.Width, upPbAfter.Rect.Height);
                    }
                    for (int i = upSelectedElement + 1; i < imageList.Count; i++)
                    {
                        ImageEntity upPbBefore = imageList.ElementAt(i - 1);
                        ImageEntity upPbAfter = imageList.ElementAt(i);
                        upPbAfter.Rect = new Rectangle(upPbBefore.Rect.X + upPbBefore.Rect.Width + 1, upPbBefore.Rect.Y, upPbAfter.Rect.Width, upPbAfter.Rect.Height);
                    }
                }
          
            return imageList;
        }

        //将左对齐和右对齐参数复位
        public static void recoveryLeftOrRightParamerter()
        {
            leftAlignment = false;
            rightAlignment = false;
            upSelectedElement = -1;
            downSelectedElement = -1;
        }

        //判断是否包含穿越两层的元素
        public static bool isExistCrossElement(List<ImageEntity> imageList)
        {
            for (int i = 0; i < imageList.Count;i++ )
            {
                if(imageList.ElementAt(i).Name.Equals("HRA")){
                    return true;
                }
            }
            return false;
        }

        //imageBoxList内部元素全部设为没有别选中
        public static void setAllElement(List<ImageEntity> imageList)
        {
            for (int i = 0; i < imageList.Count;i++ )
            {
                imageList.ElementAt(i).isSelected = false;
            }
        }

        //判断当前是否有选中的image(imageBoxList和leftImageBoxlist)
        public static int getIsExistSelected(List<ImageEntity> imageOrLeftList)
        {
            for (int i = 0; i < imageOrLeftList.Count;i++ )
            {
                if(imageOrLeftList.ElementAt(i).isSelected){
                    return i;
                }
            }
            return -1;
        }

        //替换当前选中的算法(imageBoxList)
        public static List<ImageEntity> replaceCurrent(List<ImageEntity> imageList,ImageEntity imageEntity,string mirrorDirection)
        {
            for (int i = 0; i < imageList.Count;i++ )
            {
                if (imageList.ElementAt(i).isSelected)
                {
                    imageEntity.Rect =new Rectangle(imageList.ElementAt(i).Rect.X,imageList.ElementAt(i).Rect.Y,imageEntity.Rect.Width,imageEntity.Rect.Height);
                    imageEntity.Type = imageList.ElementAt(i).Type;
                    imageList[i] = imageEntity;
                    break;
                }
            }
            imageList=calculateImageEntityPosition(imageList, imageEntity, imageEntity, mirrorDirection);
            return imageList;
        }

        //替换左上角元素的算法
        public static List<ImageEntity> replaceLeftTopCurrent(List<ImageEntity> leftTopImageList,ImageEntity imageEntity)
        {
            for (int i = leftTopImageList.Count-1; i >=0;i-- )
            {
                if (leftTopImageList.ElementAt(i).isSelected)
                {
                    imageEntity.Rect = new Rectangle(leftTopImageList.ElementAt(i).Rect.X, leftTopImageList.ElementAt(i).Rect.Y, imageEntity.Rect.Width, imageEntity.Rect.Height);
                    imageEntity.Type = leftTopImageList.ElementAt(i).Type;
                    leftTopImageList[i] = imageEntity;
                    break;
                }
            }
            return leftTopImageList;
        }

        //居中算法
        public static List<ImageEntity> setCenter(List<ImageEntity> imageList,int panelWidth,string mirrorDirection)
        {
            int  downWidth = 0;
            double  leftStart = 0;
            double  rightEnd = 0;
            int downLastElementPosition=0;
            for (int i = 0; i < imageList.Count;i++ )
            {
                if (imageList.ElementAt(0).Rect.Y == imageList.ElementAt(i).Rect.Y)
                {
                    downWidth += imageList.ElementAt(i).Rect.Width;
                    downLastElementPosition=i;
                }
                else
                {
                    break;
                }
            }

            leftStart  = (panelWidth - downWidth) / 2;
            rightEnd = leftStart + downWidth;

            if (mirrorDirection.Equals("mirrorRight"))
            {
                if (imageList.ElementAt(downLastElementPosition).Rect.X > rightEnd)
                {
                    double distance = imageList.ElementAt(downLastElementPosition).Rect.X - rightEnd;
                    for (int i = 0; i < imageList.Count; i++)
                    {
                        ImageEntity imageEntity = imageList.ElementAt(i);
                        imageEntity.Rect = new Rectangle(Convert.ToInt32(imageEntity.Rect.X - distance), imageEntity.Rect.Y, imageEntity.Rect.Width, imageEntity.Rect.Height);
                    }
                    leftStartX = Convert.ToInt32(rightEnd - imageList.ElementAt(downLastElementPosition).Rect.Width);
                }
                else
                {
                    double distance =rightEnd-imageList.ElementAt(downLastElementPosition).Rect.X;
                    for (int i = 0; i < imageList.Count; i++)
                    {
                        ImageEntity imageEntity = imageList.ElementAt(i);
                        imageEntity.Rect = new Rectangle(Convert.ToInt32(imageEntity.Rect.X + distance), imageEntity.Rect.Y, imageEntity.Rect.Width, imageEntity.Rect.Height);
                    }
                    leftStartX = Convert.ToInt32(rightEnd - imageList.ElementAt(downLastElementPosition).Rect.Width);
                }
                
            }
            else
            {
               
                if (imageList.ElementAt(0).Rect.X > leftStart)
                {
                    double distance = imageList.ElementAt(downLastElementPosition).Rect.X -leftStart;
                    for (int i = 0; i < imageList.Count; i++)
                    {
                        ImageEntity imageEntity = imageList.ElementAt(i);
                        imageEntity.Rect = new Rectangle(Convert.ToInt32(imageEntity.Rect.X - distance), imageEntity.Rect.Y, imageEntity.Rect.Width, imageEntity.Rect.Height);
                    }
                    leftStartX = Convert.ToInt32(leftStart);
                }
                else
                {
                    double distance = leftStart - imageList.ElementAt(0).Rect.X;
                    for (int i = 0; i < imageList.Count; i++)
                    {
                        ImageEntity imageEntity = imageList.ElementAt(i);
                        imageEntity.Rect = new Rectangle(Convert.ToInt32(imageEntity.Rect.X + distance), imageEntity.Rect.Y, imageEntity.Rect.Width, imageEntity.Rect.Height);
                    }
                    leftStartX = Convert.ToInt32(leftStart);
                }    
            }
            return imageList;
        }

        //自动缩小，判断能否自动缩小
        public static bool isZoomOut(List<ImageEntity> imageList,int panelWidth)
        {
            for (int i = 0; i < imageList.Count;i++ )
            {
                if ((imageList.ElementAt(i).Rect.X+imageList.ElementAt(i).Rect.Width) > panelWidth * 7 / 8)
                {
                    return true;
                }

            }

            return false;
        }

        //获取下层链表
        public static List<ImageEntity> getDownList(List<ImageEntity> imageList)
        {
            List<ImageEntity> tempDownList = new List<ImageEntity>();
            for (int i = 0; i < imageList.Count; i++)
            {
                if (imageList.ElementAt(0).Rect.Y == imageList.ElementAt(i).Rect.Y)
                {
                    tempDownList.Add(imageList.ElementAt(i));
                }
            }
            return tempDownList;
        }

        //初始画右上角信息
        public static void initRightTopInformation(OperatePhotoNeedData operatePhotoNeedData,List<ImageEntity> downList,List<ImageEntity> imageBoxList,int coolintType=5)
        {
            productionDescription = "M2-H-"+operatePhotoNeedData.unitSize+"-"+operatePhotoNeedData.supplyAirFlow+"-"+operatePhotoNeedData.voltage+"-"+operatePhotoNeedData.assembly+"-"+operatePhotoNeedData.wring+"-"+operatePhotoNeedData.paining+"-"+operatePhotoNeedData.baseRail+"-"+operatePhotoNeedData.uniteSpecial;
            downTotalLength =Convert.ToInt32(TotalWidthAndHeight.getWidth(downList, coolintType));
            //图片的真实宽度
            ImageBlock imageBlock = ImageBlockBLL.getImageBlocksByNames(downList.ElementAt(0).Name, coolintType);
            imageWidth =Convert.ToInt32(imageBlock.ImageWidth);
            if (isTowLayers(imageBoxList))
            {
                totalHeight = 2 * Convert.ToInt32(imageBlock.ImageHeight);
            }
            else
            {
                totalHeight = Convert.ToInt32(imageBlock.ImageHeight);
            }
            
        }

        //判断是否为两层
        public static bool isTowLayers(List<ImageEntity> imageList)
        {
            for (int i = 0; i < imageList.Count; i++)
            {
                if (imageList.ElementAt(0).Rect.Y != imageList.ElementAt(i).Rect.Y)
                {
                    return true;
                }
            }
            return false;
        }

        //将右上角的文字信息生成链表
        public static List<string> getTopRightEquipmentInformation(string pDes,int totalLength,int height,int width)
        {
            List<string> equipmentInfromationList = new List<string>();
            equipmentInfromationList.Add(pDes);
            equipmentInfromationList.Add("Overall Dimensions [inches]");
            equipmentInfromationList.Add("Length = " + totalLength);
            equipmentInfromationList.Add("Height = " + height);
            equipmentInfromationList.Add("Widht = " + width);
            return equipmentInfromationList;
        }
        //将中间的文字信息返回
        public static List<string> getMiddleEachInformation(string parentName,string eachImageSerialNo)
        {
            List<string> eachImageInformationList = new List<string>();
            eachImageInformationList.Add("Selected Module:" + parentName);
            eachImageInformationList.Add(eachImageSerialNo);
            return eachImageInformationList;
        }
    }
}
