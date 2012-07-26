
﻿using System;
using System.Collections.Generic;
using System.Linq;
using CadLib.OperatorEntity;
using Model.Zutu;
using CadLib.Entity;
using WW.Cad.Model;
using WW.Math;
using WW.Cad.Model.Entities;

namespace CadLib.OperatorEntity
{
    public class OuterBox
    {
        public DataCenter dataCenter { get; set; }
        public void Draw(DxfModel dxf, DLocation DLocation, double boxWidth, double boxHeight, List<PictureBoxInfo> pictureBoxInfoList,int coolingType)
        {
            
            DataManager dataManager=new DataManager();
            //boxWidth = dataManager.getTotalWidth(pictureBoxInfoList);
            
            //得到框架信息
            var boxEntity = dataCenter.BoxEntity;


            DLocation = new DLocation(DLocation.X - 120d, DLocation.Y + boxEntity.TopViewHeight + 80.0d + boxEntity.UpHeight + boxEntity.DownHeight, 0);
            boxWidth = boxEntity.Width + 240.0d;
            boxHeight = boxEntity.TopViewHeight + boxEntity.UpHeight + boxEntity.DownHeight + 160.0d;
            /****************************************************************************/
            //绘制最外框
            /****************************************************************************/
            Point3D v1 = new Point3D(DLocation.X, DLocation.Y, DLocation.Z);
            Point3D v2 = new Point3D(DLocation.X, DLocation.Y - boxHeight, DLocation.Z);
            Point3D v3 = new Point3D(DLocation.X + boxWidth, DLocation.Y - boxHeight, DLocation.Z);
            Point3D v4 = new Point3D(DLocation.X + boxWidth, DLocation.Y, DLocation.Z);


            //DxfLinePointer.Draw(dxf, DLocation);
            //Slash.Draw(dxf,new DLocation(v2.X,v2.Y,v2.Z));
            //Fan.Draw(dxf, v2,v1,2);

            DxfLine DxfLine12 = new DxfLine(v1, v2);
            dxf.Entities.Add(DxfLine12);

            DxfLine DxfLine23 = new DxfLine(v2, v3);
            dxf.Entities.Add(DxfLine23);

            DxfLine DxfLine34 = new DxfLine(v3, v4);
            dxf.Entities.Add(DxfLine34);

            DxfLine DxfLine14 = new DxfLine(v1, v4);
            dxf.Entities.Add(DxfLine14);



            /****************************************************************************/
            //绘制左上角的配置信息
            /****************************************************************************/
            Configuration.Draw(dxf, new DLocation(v1.X, v1.Y), dataCenter.Configurations);

            /****************************************************************************/
            //绘制左下角的节信息
            /****************************************************************************/
            Section.Draw(dxf, new DLocation(v2.X, v2.Y), dataCenter.SectionEntity);


            /****************************************************************************/
            //绘制底部的订单信息
            /****************************************************************************/
            Order.Draw(dxf, new DLocation(v2.X, v2.Y), boxWidth, dataCenter.OrderEntity);




            //俯视图左下角的坐标点
            DLocation v5 = new DLocation(DLocation.X + 120.0d, DLocation.Y - boxEntity.TopViewHeight - 50.0d, DLocation.Z);

            /****************************************************************************/
            //绘制俯视图
            /****************************************************************************/
            //AssembleTopView.assembleTopView(pictureBoxInfoList, dxf,
            //    v5, null, 50.0d, 18.0d, 2.0d, 2.86f, 2.0d, 2.0d);
            AssembleTopView.assembleTopView(pictureBoxInfoList, dxf, v5, dataCenter.topViewConfigure);


            //正视图左下角的坐标点
            DLocation v6 = new DLocation(DLocation.X + 120.0d, DLocation.Y - boxEntity.TopViewHeight - 80.0d - boxEntity.UpHeight - boxEntity.DownHeight, DLocation.Z);



            /****************************************************************************/
            //绘制正视图
            /****************************************************************************/
            AssembleDetailMechine.assembleDetailMechine(pictureBoxInfoList, dxf,v6, dataCenter.detailMechineConfigure, coolingType);


            //正视图两边的风向箭头位置
            //存在第一层
            DLocation v7 = new DLocation(DLocation.X + 70.0d, DLocation.Y - 90.0d-boxEntity.TopViewHeight-boxEntity.UpHeight-boxEntity.DownHeight/2, DLocation.Z);
            DLocation v8 = new DLocation(DLocation.X + boxWidth - 50.0d, DLocation.Y - 90.0d - boxEntity.TopViewHeight - boxEntity.UpHeight - boxEntity.DownHeight / 2, DLocation.Z);

            /****************************************************************************/
            //绘制正视图两边的风向箭头
            /****************************************************************************/
            Wind.Draw(dxf, v7, boxEntity.IsLeft);
            Wind.Draw(dxf, v8, boxEntity.IsLeft);

            //如果存在第二层
            if (boxEntity.UpHeight != 0)
            {
                DLocation v9 = new DLocation(DLocation.X + 70.0d, DLocation.Y - 90.0d - boxEntity.TopViewHeight - boxEntity.UpHeight / 2, DLocation.Z);
                DLocation v10 = new DLocation(DLocation.X + boxWidth - 50.0d, DLocation.Y - 90.0d - boxEntity.TopViewHeight - boxEntity.UpHeight / 2, DLocation.Z);
                Wind.Draw(dxf, v9, !boxEntity.IsLeft);
                Wind.Draw(dxf, v10, !boxEntity.IsLeft);
            }           
        }
    }
}
