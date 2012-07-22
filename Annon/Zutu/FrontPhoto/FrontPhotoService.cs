using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Zutu;
using System.Drawing;
using EntityFrameworkTryBLL.ZutuManager;

namespace Annon.Zutu.FrontPhoto
{
    class FrontPhotoService
    {
        //放大和缩小因子
      public  static double factor = 4;

        //组图左边为准时
        static int leftStartX = 200;
        static int leftStartY = 350;

        //上层第一个元素在imageboxList的位置
        static int upFirstElement = -1;
        //穿插两层元素在上下层的位置
        static int upCrossElement = -1;
        //穿越两层元素的x坐标
        static int xCrossPosition = -1;


        public static List<ImageEntity> calculateImageEntityPosition(List<ImageEntity> imageBoxList, ImageEntity srcImageEntity, ImageEntity destImageEntity, string leftOrRight)
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
                //向imageList中加入两个ImageEntity
                imageBoxList.Add(virtualImageEntity);
                imageBoxList.Add(destImageEntity);
            }
            else
            {
                imageBoxList.Add(destImageEntity);
            }

            //重新排序

            imageBoxList = getNewDoubleList(imageBoxList, leftOrRight);

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
                            tempPbBefor = imageBoxList.ElementAt(i - 1);
                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
                        }
                        else
                        {
                            //单层情况
                            if (upFirstElement == -1)
                            {
                                tempPbBefor = imageBoxList.ElementAt(i - 1);
                                tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X + tempPbBefor.Rect.Width + 1, tempPbBefor.Rect.Y, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
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
                                            tempPbBefor = imageBoxList.ElementAt(0);
                                            tempPbAfter.Rect = new Rectangle(tempPbBefor.Rect.X, tempPbBefor.Rect.Y - tempPbBefor.Rect.Height - 2, tempPbAfter.Rect.Width, tempPbAfter.Rect.Height);
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
                        imageList.ElementAt(i).moduleTag = "1" + (i < 10 ? "0" + i+"-" : i+"-")+ imageBlock.ParentName;
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

        public static List<ImageEntity> initSingleLayerOPeratorPhoto(List<ImageEntity> imageBoxList,int coolingType)
        {
            int startXPosition = 200;
            int startYPosition = 350;
            if (5 == coolingType)
            {
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

                imageBoxList.Add(imageEntityFTA);
                imageBoxList.Add(imageEntityCLF);
                imageBoxList.Add(imageEntitySFA);
            }
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
                                   x = Convert.ToInt32(leftStartX + currentDistance * factor);
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
                           currentDistance = Math.Abs(imageEntity.Rect.X - leftStartX);
                           if (i == upFirstElement)
                           {
                               x = Convert.ToInt32(imageEntity.Rect.X + currentDistance * factor);
                               y = Convert.ToInt32(imageEntity.Rect.Y+imageEntity.Rect.Height-height);
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
    }
}
