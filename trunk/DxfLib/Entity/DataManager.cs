﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using netDxf;
using Model.Zutu;
using EntityFrameworkTryBLL.ZutuManager;
using DxfLib.OperatorEntity;

namespace DxfLib.Entity
{
    public class DataManager
    {
        /// <summary>
        /// 获得dxf图的配置信息
        /// </summary>
        /// <returns></returns>
        public List<string> getConfiguration()
        {
            List<string> confstr = new List<string>()
            {
                "baby baby one more time",
            "baby baby one more time",
            "baby baby one more time",
            "baby baby one more time"
            };
            return confstr;
        }


        public SectionEntity getSectionEntity()
        {
            return new SectionEntity("40", "60");
        }

        public OrderEntity getOrderEntity()
        {
            return new OrderEntity("jobname", "unittag");
        }

        public DetailMechineConfigure getDetailMechineCnfigure(List<string> pictureBoxNameList, DxfDocument dxf,
                Location location)
        {
            return new DetailMechineConfigure(pictureBoxNameList, dxf,
                location, new string[] { "hello", "world", "helloworld" }, 44.0f, 18, 2.0f, 2.86f, 2.0f, 2.0f);
        }

        public TopViewConfigure getTopViewConfigure(List<string> pictureBoxNameList, DxfDocument dxf,
                Location location)
        {
            return new TopViewConfigure(pictureBoxNameList, dxf,
                location, null, 50.0f, 18.0f, 2.0f, 2.86f, 2.0f, 2.0f);
        }

        public float getTotalWidth(List<PictureBoxInfo> pictureBoxInfoList)
        {
            List<ImageBlock> tempImageBlockList = ImageBlockBLL.getImageBlocksByNames(pictureBoxInfoList, 5);
            return TotalWidthAndHeight.getTotalWidth(tempImageBlockList);    
        }


    }
}
