using System;
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
            boxWidth = dataManager.getTotalWidth(pictureBoxInfoList);
            boxWidth += 240.0f;
            /****************************************************************************/
            //绘制最外框
            /****************************************************************************/
            Vector3f v1 = new Vector3f(location.X, location.Y, location.Z);
            Vector3f v2 = new Vector3f(location.X, location.Y - boxHeight, location.Z);
            Vector3f v3 = new Vector3f(location.X + boxWidth, location.Y - boxHeight, location.Z);
            Vector3f v4 = new Vector3f(location.X + boxWidth, location.Y, location.Z);


            LinePointer.Draw(dxf, location);
            Slash.Draw(dxf,new Location(v2.X,v2.Y,v2.Z));
            Fan.Draw(dxf, v2,v1,2);

            Layer layer = new Layer("outerline");
            Line line12 = new Line(v1, v2);
            line12.Layer = layer;
            //line12.Layer.Color.Index = 8;
            dxf.AddEntity(line12);

            Line line23 = new Line(v2, v3);
            line23.Layer = layer;
            //line23.Layer.Color.Index = 8;
            dxf.AddEntity(line23);

            Line line34 = new Line(v3, v4);
            line34.Layer = layer;
            //line34.Layer.Color.Index = 8;
            dxf.AddEntity(line34);

            Line line14 = new Line(v1, v4);
            line14.Layer = layer;
            //line14.Layer.Color.Index = 8;
            dxf.AddEntity(line14);



            /****************************************************************************/
            //绘制左上角的配置信息
            /****************************************************************************/
            //Configuration.Draw(dxf, new Location(v1.X,v1.Y), dataManager.getConfiguration());
            Configuration.Draw(dxf, new Location(v1.X, v1.Y), dataCenter.Configurations);

            /****************************************************************************/
            //绘制左下角的节信息
            /****************************************************************************/
            //SectionEntity sectionEntity=dataManager.getSectionEntity();
            //Section.Draw(dxf, new Location(v2.X, v2.Y), sectionEntity);
            Section.Draw(dxf, new Location(v2.X, v2.Y), dataCenter.SectionEntity);


            /****************************************************************************/
            //绘制底部的订单信息
            /****************************************************************************/
            //OrderEntity orderEntity = dataManager.getOrderEntity();
            //Order.Draw(dxf, new Location(v2.X,v2.Y),boxWidth, orderEntity);
            Order.Draw(dxf, new Location(v2.X, v2.Y), boxWidth, dataCenter.OrderEntity);



            float height1 = boxHeight / 4;
            float height2 = boxHeight / 4;

            //俯视图左下角的坐标点
            //Location v5 = new Location(location.X + boxWidth / 3, location.Y - 3 * height1 / 2, location.Z);
            Location v5 = new Location(location.X + 120.0f, location.Y - 3 * height1 / 2, location.Z);

            /****************************************************************************/
            //绘制俯视图
            /****************************************************************************/
            AssembleTopView.assembleTopView(pictureBoxInfoList, dxf,
                v5, null, 50.0f, 18.0f, 2.0f, 2.86f, 2.0f, 2.0f);


            //正视图左下角的坐标点
            //Location v6 = new Location(location.X + boxWidth / 3, location.Y - 2 * height1 -height2, location.Z);
            Location v6 = new Location(location.X + 120.0f, location.Y - 2 * height1 - height2, location.Z);


            /****************************************************************************/
            //绘制正视图
            /****************************************************************************/
            //AssembleDetailMechine.assembleDetailMechine(pictureBoxInfoList, dxf,
            //    v6, new string[] { "hello", "world", "helloworld" }, 44.0f, 18, 2.0f, 2.86f, 2.0f, 2.0f);
            AssembleDetailMechine.assembleDetailMechine(pictureBoxInfoList, dxf, location, dataManager.getDetailMechineCnfigure(pictureBoxInfoList, dxf, location), coolingType);


            //正视图两边的风向箭头位置
            //Location v7 = new Location(location.X + 2 * boxWidth / 9, location.Y - 2 * height1 - height2 / 2, location.Z);
            //Location v8 = new Location(location.X + 7 * boxWidth / 9, location.Y - 2 * height1 - height2 / 2, location.Z);
            Location v7 = new Location(location.X + 70.0f, location.Y - 2 * height1 - 2 * height2 / 3, location.Z);
            Location v8 = new Location(location.X + boxWidth - 50.0f, location.Y - 2 * height1 - 2 * height2 / 3, location.Z);


            /****************************************************************************/
            //绘制正视图两边的风向箭头
            /****************************************************************************/
            Wind.Draw(dxf, v7, true);
            Wind.Draw(dxf, v8, true);

        }
    }
}
