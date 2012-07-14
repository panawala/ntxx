﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Zutu;
using DxfLib.OperatorEntity;
using EntityFrameworkTryBLL.TreeManager;
using EntityFrameworkTryBLL.ZutuManager;

namespace DxfLib.OperatorEntity
{
    class TotalWidthAndHeight
    {
        public static float getTotalWidth(List<ImageBlock> imageBlockList)
        {
            float totalWidth=0f;
            for (int i = 0; i < imageBlockList.Count; i++)
            {
                totalWidth+= imageBlockList.ElementAt(i).ImageLength;
            }
            return totalWidth;
        }

        public static float getPartTotalLength(List<ImageBlock> imageBlockList,int endPosintion)
        {
            float totalWidth = 0f;
            for (int i = 0; i < endPosintion; i++)
            {
                totalWidth += imageBlockList.ElementAt(i).ImageLength;
            }
            return totalWidth;
        }

        //计算上层第一个图的Location
        public static Location getUpLayerLocation(List<PictureBoxInfo> downImageNameList, List<PictureBoxInfo> UpImageNameList,int coolingType)
        {
            float min = Int32.MaxValue;
            int flag = 0;
            for (int i = 0, j = 0, len1 = downImageNameList.Count; i < len1; i++)
            {
                float tempValue = Math.Abs(downImageNameList.ElementAt(i).location.X - UpImageNameList.ElementAt(j).location.X);
                if (min > tempValue)
                {
                    min = tempValue;
                    flag = i;
                }
            }
            //计算的是相对坐标，还没有加上下层的参照物坐标
            List<ImageBlock> downLayerPartImageList = ImageBlockBLL.getImageBlocksByNames(downImageNameList, coolingType, flag);
            return new Location(getPartTotalLength(downLayerPartImageList, flag) + Math.Abs(downImageNameList.ElementAt(flag).location.X - UpImageNameList.ElementAt(0).location.X),downLayerPartImageList[downLayerPartImageList.Count-1].ImageWidth-6,0);
        }
    }
}