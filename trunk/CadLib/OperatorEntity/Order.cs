using System;
using System.Collections.Generic;
using System.Linq;
using Model.Zutu;
using CadLib.Entity;
using WW.Cad.Model;
using WW.Math;
using WW.Cad.Model.Entities;

namespace CadLib.OperatorEntity
{
    public class Order
    {
        /// <summary>
        /// 绘制订单信息块
        /// </summary>
        /// <param name="dxf"></param>
        /// <param name="DLocation"></param>
        /// <param name="boxWidth"></param>
        /// <param name="configurations"></param>
        public static void Draw(DxfModel dxf, DLocation DLocation,double boxWidth, OrderEntity orderEntity)
        {
            double factor = 0.6f;
            Point3D v1 = new Point3D(DLocation.X,DLocation.Y,DLocation.Z);
            Point3D v2 = new Point3D(DLocation.X + boxWidth, DLocation.Y, DLocation.Z);
            Point3D v3 = new Point3D(DLocation.X + boxWidth, DLocation.Y + 40.0d * factor, DLocation.Z);
            Point3D v4 = new Point3D(DLocation.X, DLocation.Y + 40.0d * factor, DLocation.Z);


            Point3D v5 = new Point3D(DLocation.X, DLocation.Y + 10.0d * factor, DLocation.Z);
            Point3D v6 = new Point3D(DLocation.X + boxWidth / 4, DLocation.Y + 10.0d * factor, DLocation.Z);
            Point3D v7 = new Point3D(DLocation.X + boxWidth / 2, DLocation.Y + 10.0d * factor, DLocation.Z);
            Point3D v8 = new Point3D(DLocation.X + boxWidth * 3 / 4, DLocation.Y + 10.0d * factor, DLocation.Z);
            Point3D v9 = new Point3D(DLocation.X + boxWidth * 7 / 8, DLocation.Y + 10.0d * factor, DLocation.Z);

            Point3D v10 = new Point3D(DLocation.X + boxWidth / 4, DLocation.Y + 20.0d * factor, DLocation.Z);
            Point3D v11 = new Point3D(DLocation.X + boxWidth / 2, DLocation.Y + 20.0d * factor, DLocation.Z);
            Point3D v12 = new Point3D(DLocation.X + boxWidth * 3 / 4, DLocation.Y + 20.0d * factor, DLocation.Z);
            Point3D v13 = new Point3D(DLocation.X + boxWidth * 7 / 8, DLocation.Y + 20.0d * factor, DLocation.Z);
            Point3D v14 = new Point3D(DLocation.X + boxWidth, DLocation.Y + 20.0d * factor, DLocation.Z);

            Point3D v15 = new Point3D(DLocation.X + boxWidth / 4, DLocation.Y + 40.0d * factor, DLocation.Z);
            Point3D v16 = new Point3D(DLocation.X + boxWidth * 3 / 4, DLocation.Y + 40.0d * factor, DLocation.Z);

            Point3D v17 = new Point3D(DLocation.X + boxWidth / 4, DLocation.Y, DLocation.Z);
            Point3D v18 = new Point3D(DLocation.X + boxWidth / 2, DLocation.Y, DLocation.Z);
            Point3D v19 = new Point3D(DLocation.X + boxWidth * 3 / 4, DLocation.Y, DLocation.Z);

            Point3D v20 = new Point3D(DLocation.X + boxWidth, DLocation.Y + 10.0d * factor, DLocation.Z);

            //横向四道
            DxfLine DxfLine12 = new DxfLine(v1, v2);
            dxf.Entities.Add(DxfLine12);

            DxfLine DxfLine520 = new DxfLine(v5, v20);
            dxf.Entities.Add(DxfLine520);

            DxfLine DxfLine1014 = new DxfLine(v10, v14);
            dxf.Entities.Add(DxfLine1014);

            DxfLine DxfLine43 = new DxfLine(v4, v3);
            dxf.Entities.Add(DxfLine43);

            //纵向6道
            DxfLine DxfLine41 = new DxfLine(v4, v1);
            dxf.Entities.Add(DxfLine41);

            DxfLine DxfLine1517 = new DxfLine(v15, v17);
            dxf.Entities.Add(DxfLine1517);

            DxfLine DxfLine1118 = new DxfLine(v11, v18);
            dxf.Entities.Add(DxfLine1118);

            DxfLine DxfLine1619 = new DxfLine(v16, v19);
            dxf.Entities.Add(DxfLine1619);

            DxfLine DxfLine139 = new DxfLine(v13, v9);
            dxf.Entities.Add(DxfLine139);

            DxfLine DxfLine32= new DxfLine(v3, v2);
            dxf.Entities.Add(DxfLine32);


            //文字

            Point3D vt1 = new Point3D(v1.X + 1.0d, v1.Y + 2.5f, v1.Z);
            DxfText t1 = new DxfText("Celebrity 1.0.0", vt1, 2.0d);
            dxf.Entities.Add(t1);



            Point3D vt2 = new Point3D(v17.X + 1.0d, v17.Y + 2.5f, v1.Z);
            DxfText t2 = new DxfText("PREPARER:  "+orderEntity.Preparer, vt2, 2.0d);
            dxf.Entities.Add(t2);


            Point3D vt3 = new Point3D(v18.X + 1.0d, v18.Y + 2.5f, v1.Z);
            DxfText t3 = new DxfText("ENGINEER:  "+orderEntity.Engineer, vt3, 2.0d);
            dxf.Entities.Add(t3);


            Point3D vt4 = new Point3D(v19.X + 1.0d, v19.Y + 2.5f, v1.Z);
            DxfText t4 = new DxfText("SHIP ORDER NO:  "+orderEntity.ShipOrderNo, vt4, 2.0d);
            dxf.Entities.Add(t4);

            Point3D vt5 = new Point3D(v4.X + 1.0d, v10.Y + 2.5f, v1.Z);
            DxfText t5= new DxfText("     AAON  COIL  PRODUCTS  inc.", vt5, 3.0d);
            dxf.Entities.Add(t5);

            Point3D vt6 = new Point3D(v5.X + 1.0d, v5.Y + 2.5f, v1.Z);
            DxfText t6 = new DxfText("LONGVIEW  TEXAS", vt6, 2.0d);
            dxf.Entities.Add(t6);

            Point3D vt7 = new Point3D(v6.X + 1.0d, v6.Y + 2.5f, v1.Z);
            DxfText t7 = new DxfText("PURCHASER:  " + orderEntity.Purchaser, vt7, 2.0d);
            dxf.Entities.Add(t7);


            Point3D vt8 = new Point3D(v7.X + 1.0d, v7.Y + 2.5f, v1.Z);
            DxfText t8 = new DxfText("PURCHASE ORDER:  " + orderEntity.PurchaseOrder, vt8, 2.0d);
            dxf.Entities.Add(t8);


            Point3D vt9 = new Point3D(v8.X + 1.0d, v8.Y + 2.5f, v1.Z);
            DxfText t9 = new DxfText("SERIAL NO:  " + orderEntity.SeriaNo, vt9, 2.0d);
            dxf.Entities.Add(t9);


            Point3D vt10 = new Point3D(v9.X + 1.0d, v9.Y + 2.5f, v1.Z);
            DxfText t10 = new DxfText("DATE: "+DateTime.Now.ToShortDateString(), vt10, 2.0d);
            dxf.Entities.Add(t10);


            Point3D vt11 = new Point3D(v15.X + 1.0d, v15.Y - 7.5f, v1.Z);
            DxfText t11 = new DxfText("JOB NAME:", vt11, 2.0d);
            dxf.Entities.Add(t11);


            Point3D vt12 = new Point3D(v10.X + 10.0d, v10.Y + 2.5f, v1.Z);
            DxfText t12 = new DxfText(orderEntity.JobName, vt12, 2.0d);
            dxf.Entities.Add(t12);


            Point3D vt13 = new Point3D(v16.X + 1.0d, v16.Y - 7.5f, v1.Z);
            DxfText t13 = new DxfText("UNIT TAG:", vt13, 2.0d);
            dxf.Entities.Add(t13);


            Point3D vt14 = new Point3D(v12.X + 20.0d, v12.Y + 2.5f, v1.Z);
            DxfText t14 = new DxfText(orderEntity.UnitTag, vt14, 2.0d);
            dxf.Entities.Add(t14);


        }
    }
}
