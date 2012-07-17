using System;
using System.Collections.Generic;
using System.Linq;
using Model.Zutu;
using CadLib.OperatorEntity;
using EntityFrameworkTryBLL.TreeManager;
using EntityFrameworkTryBLL.ZutuManager;

namespace CadLib.OperatorEntity
{
  public  class TotalWidthAndHeight
    {
        public static double getTotalWidth(List<ImageBlock> imageBlockList)
        {
            double totalWidth=0f;
            for (int i = 0; i < imageBlockList.Count; i++)
            {
                totalWidth+= imageBlockList.ElementAt(i).ImageLength;
            }
            return totalWidth;
        }

        public static double getPartTotalLength(List<ImageBlock> imageBlockList,int endPosintion)
        {
            double totalWidth = 0f;
            for (int i = 0; i < endPosintion; i++)
            {
                totalWidth += imageBlockList.ElementAt(i).ImageLength;
            }
            return totalWidth;
        }

        //计算上层第一个图的DLocation
        public static DLocation getUpLayerDLocation(List<PictureBoxInfo> downImageNameList, List<PictureBoxInfo> UpImageNameList,int coolingType)
        {
            double min = Int32.MaxValue;
            int flag = 0;
            for (int i = 0, j = 0, len1 = downImageNameList.Count; i < len1; i++)
            {
                double tempValue = Math.Abs(downImageNameList.ElementAt(i).DLocation.X - UpImageNameList.ElementAt(j).DLocation.X);
                if (min > tempValue)
                {
                    min = tempValue;
                    flag = i;
                }
                //方便到数据库中取数据时用，因为数据库中没有"virtureHRA"
                if (downImageNameList.ElementAt(i).name.Equals("virtualHRA"))
                {
                    //PictureBoxInfo virtualHraBox = new PictureBoxInfo();
                    //virtualHraBox.name = "HRA";
                    //virtualHraBox.DLocation = downImageNameList.ElementAt(i).DLocation;
                    //downImageNameList[i] = virtualHraBox;
                    downImageNameList.ElementAt(i).name = "HRA";
                }
            }
            //计算的是相对坐标，还没有加上下层的参照物坐标
            List<ImageBlock> downLayerPartImageList = ImageBlockBLL.getImageBlocksByNames(downImageNameList, coolingType, flag);
            return new DLocation(getPartTotalLength(downLayerPartImageList, flag) + Math.Abs(downImageNameList.ElementAt(flag).DLocation.X - UpImageNameList.ElementAt(0).DLocation.X),downLayerPartImageList[downLayerPartImageList.Count-1].ImageWidth-6,0);
        }

        //计算每一层的高度
        public static double[] getEachLayerHight(List<PictureBoxInfo> pictureBoxInfoList)
        {
            double[] upOrDownHeight = new double[3];
            //5代表的是冷量类型
            List<ImageBlock> tempImageBlockList = ImageBlockBLL.getImageBlocksByNames(pictureBoxInfoList, 5);
            if (tempImageBlockList != null)
            {
                upOrDownHeight[0] = tempImageBlockList.ElementAt(0).ImageWidth;
                upOrDownHeight[1] = tempImageBlockList.ElementAt(0).ImageWidth;
                upOrDownHeight[2] = tempImageBlockList.ElementAt(0).ImageWidth;
            }
            return upOrDownHeight;
        }

        public static double getWidth(List<PictureBoxInfo> pictureBoxInfoList)
        {
            //5代表的是冷量类型
            List<ImageBlock> tempImageBlockList = ImageBlockBLL.getImageBlocksByNames(pictureBoxInfoList, 5);
            return getTotalWidth(tempImageBlockList);
        }
    }
}
