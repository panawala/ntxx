﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using netDxf;
using netDxf.Tables;
using netDxf.Entities;
using DxfLib.OperatorEntity;
using Model.Zutu;
using DxfLib.Entity;

namespace DxfLib.OperatorEntity
{
    public class OuterBox
    {
        public DataCenter dataCenter { get; set; }
        public void Draw(DxfDocument dxf, Location location, float boxWidth, float boxHeight, List<PictureBoxInfo> pictureBoxInfoList,int coolingType)
        {
            DataManager dataManager=new DataManager();
            //boxWidth = dataManager.getTotalWidth(pictureBoxInfoList);
            
            //得到框架信息
            var boxEntity = dataCenter.BoxEntity;
            boxWidth = boxEntity.Width + 240.0f;
            boxHeight = boxEntity.TopViewHeight + boxEntity.UpHeight + boxEntity.DownHeight + 160.0f;
            /****************************************************************************/
            //绘制最外框
            /****************************************************************************/
            Vector3f v1 = new Vector3f(location.X, location.Y, location.Z);
            Vector3f v2 = new Vector3f(location.X, location.Y - boxHeight, location.Z);
            Vector3f v3 = new Vector3f(location.X + boxWidth, location.Y - boxHeight, location.Z);
            Vector3f v4 = new Vector3f(location.X + boxWidth, location.Y, location.Z);


            //LinePointer.Draw(dxf, location);
            //Slash.Draw(dxf,new Location(v2.X,v2.Y,v2.Z));
            //Fan.Draw(dxf, v2,v1,2);

            Layer layer = new Layer("outerline");
            Line line12 = new Line(v1, v2);
            line12.Layer = layer;
            dxf.AddEntity(line12);

            Line line23 = new Line(v2, v3);
            line23.Layer = layer;
            dxf.AddEntity(line23);

            Line line34 = new Line(v3, v4);
            line34.Layer = layer;
            dxf.AddEntity(line34);

            Line line14 = new Line(v1, v4);
            line14.Layer = layer;
            dxf.AddEntity(line14);



            /****************************************************************************/
            //绘制左上角的配置信息
            /****************************************************************************/
            Configuration.Draw(dxf, new Location(v1.X, v1.Y), dataCenter.Configurations);

            /****************************************************************************/
            //绘制左下角的节信息
            /****************************************************************************/
            Section.Draw(dxf, new Location(v2.X, v2.Y), dataCenter.SectionEntity);


            /****************************************************************************/
            //绘制底部的订单信息
            /****************************************************************************/
            Order.Draw(dxf, new Location(v2.X, v2.Y), boxWidth, dataCenter.OrderEntity);




            //俯视图左下角的坐标点
            Location v5 = new Location(location.X + 120.0f, location.Y - boxEntity.TopViewHeight - 50.0f, location.Z);

            /****************************************************************************/
            //绘制俯视图
            /****************************************************************************/
            //AssembleTopView.assembleTopView(pictureBoxInfoList, dxf,
            //    v5, null, 50.0f, 18.0f, 2.0f, 2.86f, 2.0f, 2.0f);
            AssembleTopView.assembleTopView(pictureBoxInfoList, dxf, v5, dataCenter.topViewConfigure);


            //正视图左下角的坐标点
            Location v6 = new Location(location.X + 120.0f, location.Y - boxEntity.TopViewHeight - 80.0f - boxEntity.UpHeight - boxEntity.DownHeight, location.Z);



            /****************************************************************************/
            //绘制正视图
            /****************************************************************************/
            AssembleDetailMechine.assembleDetailMechine(pictureBoxInfoList, dxf, v6, dataCenter.detailMechineConfigure, coolingType);


            //正视图两边的风向箭头位置
            //存在第一层
            Location v7 = new Location(location.X + 70.0f, location.Y - 90.0f-boxEntity.TopViewHeight-boxEntity.UpHeight-boxEntity.DownHeight/2, location.Z);
            Location v8 = new Location(location.X + boxWidth - 50.0f, location.Y - 90.0f - boxEntity.TopViewHeight - boxEntity.UpHeight - boxEntity.DownHeight / 2, location.Z);

            /****************************************************************************/
            //绘制正视图两边的风向箭头
            /****************************************************************************/
            Wind.Draw(dxf, v7, boxEntity.IsLeft);
            Wind.Draw(dxf, v8, boxEntity.IsLeft);

            //如果存在第二层
            if (boxEntity.UpHeight != 0)
            {
                Location v9 = new Location(location.X + 70.0f, location.Y - 90.0f - boxEntity.TopViewHeight - boxEntity.UpHeight / 2, location.Z);
                Location v10 = new Location(location.X + boxWidth - 50.0f, location.Y - 90.0f - boxEntity.TopViewHeight - boxEntity.UpHeight / 2, location.Z);
                Wind.Draw(dxf, v9, !boxEntity.IsLeft);
                Wind.Draw(dxf, v10, !boxEntity.IsLeft);
            }


            

        }
    }
}
