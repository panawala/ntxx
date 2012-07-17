using System;
using System.Collections.Generic;
using System.Linq;
using Model.Zutu;
using EntityFrameworkTryBLL.ZutuManager;
using CadLib.OperatorEntity;
using WW.Cad.Model;

namespace CadLib.Entity
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

        public DetailMechineConfigure getDetailMechineCnfigure(List<PictureBoxInfo> pictureBoxNameList, DxfModel dxf,
                DLocation DLocation)
        {
            return new DetailMechineConfigure(pictureBoxNameList,
                new string[] { "hello", "world", "helloworld" }, 44.0d, 18, 2.0d, 2.86f, 2.0d, 2.0d);
        }

        public TopViewConfigure getTopViewConfigure(List<PictureBoxInfo> pictureBoxNameList, DxfModel dxf,
                DLocation DLocation)
        {
            return new TopViewConfigure(pictureBoxNameList, dxf,
                 null, 50.0d, 18.0d, 2.0d, 2.86f, 2.0d, 2.0d);
        }

        public double getTotalWidth(List<PictureBoxInfo> pictureBoxInfoList)
        {
            //5代表的是冷量类型
            List<ImageBlock> tempImageBlockList = ImageBlockBLL.getImageBlocksByNames(pictureBoxInfoList, 5);
            return TotalWidthAndHeight.getTotalWidth(tempImageBlockList);    
        }


    }
}
