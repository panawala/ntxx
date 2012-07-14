using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using netDxf;
using netDxf.Tables;
using netDxf.Entities;
using Model.Zutu;
using DxfLib.Entity;

namespace DxfLib.OperatorEntity
{
    public class Order
    {
        /// <summary>
        /// 绘制订单信息块
        /// </summary>
        /// <param name="dxf"></param>
        /// <param name="location"></param>
        /// <param name="boxWidth"></param>
        /// <param name="configurations"></param>
        public static void Draw(DxfDocument dxf, Location location,float boxWidth, OrderEntity orderEntity)
        {
            float factor = 0.6f;
            Vector3f v1 = new Vector3f(location.X,location.Y,location.Z);
            Vector3f v2 = new Vector3f(location.X + boxWidth, location.Y, location.Z);
            Vector3f v3 = new Vector3f(location.X + boxWidth, location.Y + 40.0f * factor, location.Z);
            Vector3f v4 = new Vector3f(location.X, location.Y + 40.0f * factor, location.Z);


            Vector3f v5 = new Vector3f(location.X, location.Y + 10.0f * factor, location.Z);
            Vector3f v6 = new Vector3f(location.X + boxWidth / 4, location.Y + 10.0f * factor, location.Z);
            Vector3f v7 = new Vector3f(location.X + boxWidth / 2, location.Y + 10.0f * factor, location.Z);
            Vector3f v8 = new Vector3f(location.X + boxWidth * 3 / 4, location.Y + 10.0f * factor, location.Z);
            Vector3f v9 = new Vector3f(location.X + boxWidth * 7 / 8, location.Y + 10.0f * factor, location.Z);

            Vector3f v10 = new Vector3f(location.X + boxWidth / 4, location.Y + 20.0f * factor, location.Z);
            Vector3f v11 = new Vector3f(location.X + boxWidth / 2, location.Y + 20.0f * factor, location.Z);
            Vector3f v12 = new Vector3f(location.X + boxWidth * 3 / 4, location.Y + 20.0f * factor, location.Z);
            Vector3f v13 = new Vector3f(location.X + boxWidth * 7 / 8, location.Y + 20.0f * factor, location.Z);
            Vector3f v14 = new Vector3f(location.X + boxWidth, location.Y + 20.0f * factor, location.Z);

            Vector3f v15 = new Vector3f(location.X + boxWidth / 4, location.Y + 40.0f * factor, location.Z);
            Vector3f v16 = new Vector3f(location.X + boxWidth * 3 / 4, location.Y + 40.0f * factor, location.Z);

            Vector3f v17 = new Vector3f(location.X + boxWidth / 4, location.Y, location.Z);
            Vector3f v18 = new Vector3f(location.X + boxWidth / 2, location.Y, location.Z);
            Vector3f v19 = new Vector3f(location.X + boxWidth * 3 / 4, location.Y, location.Z);

            Vector3f v20 = new Vector3f(location.X + boxWidth, location.Y + 10.0f * factor, location.Z);

            Layer layer = new Layer("line");

            //横向四道
            Line line12 = new Line(v1, v2);
            line12.Layer = layer;
            dxf.AddEntity(line12);

            Line line520 = new Line(v5, v20);
            line520.Layer = layer;
            dxf.AddEntity(line520);

            Line line1014 = new Line(v10, v14);
            line1014.Layer = layer;
            dxf.AddEntity(line1014);

            Line line43 = new Line(v4, v3);
            line43.Layer = layer;
            dxf.AddEntity(line43);

            //纵向6道
            Line line41 = new Line(v4, v1);
            line41.Layer = layer;
            dxf.AddEntity(line41);

            Line line1517 = new Line(v15, v17);
            line1517.Layer = layer;
            dxf.AddEntity(line1517);

            Line line1118 = new Line(v11, v18);
            line1118.Layer = layer;
            dxf.AddEntity(line1118);

            Line line1619 = new Line(v16, v19);
            line1619.Layer = layer;
            dxf.AddEntity(line1619);

            Line line139 = new Line(v13, v9);
            line139.Layer = layer;
            dxf.AddEntity(line139);

            Line line32= new Line(v3, v2);
            line32.Layer = layer;
            dxf.AddEntity(line32);


            //文字

            TextStyle style = new TextStyle("True type font", "Arial.ttf");
            Vector3f vt1 = new Vector3f(v1.X + 1.0f, v1.Y + 2.5f, v1.Z);
            Text t1 = new Text("Celebrity 1.0.0", vt1, 2.0f, style);
            t1.Layer = layer;
            t1.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t1);



            Vector3f vt2 = new Vector3f(v17.X + 1.0f, v17.Y + 2.5f, v1.Z);
            Text t2 = new Text("PREPARER:  "+orderEntity.Preparer, vt2, 2.0f, style);
            t2.Layer = layer;
            t1.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t2);


            Vector3f vt3 = new Vector3f(v18.X + 1.0f, v18.Y + 2.5f, v1.Z);
            Text t3 = new Text("ENGINEER:  "+orderEntity.Engineer, vt3, 2.0f, style);
            t3.Layer = layer;
            t3.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t3);


            Vector3f vt4 = new Vector3f(v19.X + 1.0f, v19.Y + 2.5f, v1.Z);
            Text t4 = new Text("SHIP ORDER NO:  "+orderEntity.ShipOrderNo, vt4, 2.0f, style);
            t4.Layer = layer;
            t4.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t4);

            Vector3f vt5 = new Vector3f(v4.X + 1.0f, v10.Y + 2.5f, v1.Z);
            Text t5= new Text("     AAON  COIL  PRODUCTS  inc.", vt5, 3.0f, style);
            t5.Layer = layer;
            t5.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t5);

            Vector3f vt6 = new Vector3f(v5.X + 1.0f, v5.Y + 2.5f, v1.Z);
            Text t6 = new Text("LONGVIEW  TEXAS", vt6, 2.0f, style);
            t6.Layer = layer;
            t6.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t6);

            Vector3f vt7 = new Vector3f(v6.X + 1.0f, v6.Y + 2.5f, v1.Z);
            Text t7 = new Text("PURCHASER:  " + orderEntity.Purchaser, vt7, 2.0f, style);
            t7.Layer = layer;
            t7.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t7);


            Vector3f vt8 = new Vector3f(v7.X + 1.0f, v7.Y + 2.5f, v1.Z);
            Text t8 = new Text("PURCHASE ORDER:  " + orderEntity.PurchaseOrder, vt8, 2.0f, style);
            t8.Layer = layer;
            t8.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t8);


            Vector3f vt9 = new Vector3f(v8.X + 1.0f, v8.Y + 2.5f, v1.Z);
            Text t9 = new Text("SERIAL NO:  " + orderEntity.SeriaNo, vt9, 2.0f, style);
            t9.Layer = layer;
            t9.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t9);


            Vector3f vt10 = new Vector3f(v9.X + 1.0f, v9.Y + 2.5f, v1.Z);
            Text t10 = new Text("DATE: "+DateTime.Now.ToShortDateString(), vt10, 2.0f, style);
            t10.Layer = layer;
            t10.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t10);


            Vector3f vt11 = new Vector3f(v15.X + 1.0f, v15.Y - 7.5f, v1.Z);
            Text t11 = new Text("JOB NAME:", vt11, 2.0f, style);
            t11.Layer = layer;
            t11.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t11);


            Vector3f vt12 = new Vector3f(v10.X + 10.0f, v10.Y + 2.5f, v1.Z);
            Text t12 = new Text(orderEntity.JobName, vt12, 2.0f, style);
            t12.Layer = layer;
            t12.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t12);


            Vector3f vt13 = new Vector3f(v16.X + 1.0f, v16.Y - 7.5f, v1.Z);
            Text t13 = new Text("UNIT TAG:", vt13, 2.0f, style);
            t13.Layer = layer;
            t13.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t13);


            Vector3f vt14 = new Vector3f(v12.X + 20.0f, v12.Y + 2.5f, v1.Z);
            Text t14 = new Text(orderEntity.UnitTag, vt14, 2.0f, style);
            t14.Layer = layer;
            t14.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t14);


        }
    }
}
