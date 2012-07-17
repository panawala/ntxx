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
    public class Section
    {
     /// <summary>
     /// 绘制左下角区域的Section块
     /// </summary>
     /// <param name="dxf"></param>
     /// <param name="DLocation"></param>
     /// <param name="configurations"></param>
        public static void Draw(DxfModel dxf, DLocation DLocation,SectionEntity sectionEntity)
        {
            double factor=0.6f;
            Point3D v1 = new Point3D(DLocation.X, DLocation.Y + 40.0d*factor, DLocation.Z);
            Point3D v2 = new Point3D(DLocation.X + 50.0d * factor, DLocation.Y + 40.0d * factor, DLocation.Z);
            Point3D v3 = new Point3D(DLocation.X + 90.0d * factor, DLocation.Y + 40.0d * factor, DLocation.Z);
            Point3D v4 = new Point3D(DLocation.X + 140.0d * factor, DLocation.Y + 40.0d * factor, DLocation.Z);

            Point3D v5 = new Point3D(DLocation.X, DLocation.Y + 50.0d * factor, DLocation.Z);    
            Point3D v6 = new Point3D(DLocation.X + 140.0d * factor, DLocation.Y + 50.0d * factor, DLocation.Z);

            Point3D v7 = new Point3D(DLocation.X, DLocation.Y + 60.0d * factor, DLocation.Z);
            Point3D v8 = new Point3D(DLocation.X + 140.0d * factor, DLocation.Y + 60.0d * factor, DLocation.Z);

            Point3D v9 = new Point3D(DLocation.X, DLocation.Y + 70.0d * factor, DLocation.Z);
            Point3D v10 = new Point3D(DLocation.X + 50.0d * factor, DLocation.Y + 70.0d * factor, DLocation.Z);
            Point3D v11 = new Point3D(DLocation.X + 90.0d * factor, DLocation.Y + 70.0d * factor, DLocation.Z);
            Point3D v12 = new Point3D(DLocation.X + 140.0d * factor, DLocation.Y + 70.0d * factor, DLocation.Z);

            //横向四道
            DxfLine DxfLine14 = new DxfLine(v1, v4);
            dxf.Entities.Add(DxfLine14);

            DxfLine DxfLine56 = new DxfLine(v5, v6);
            dxf.Entities.Add(DxfLine56);

            DxfLine DxfLine78 = new DxfLine(v7, v8);
            dxf.Entities.Add(DxfLine78);

            DxfLine DxfLine912 = new DxfLine(v9, v12);
            dxf.Entities.Add(DxfLine912);

            //纵向四道
            DxfLine DxfLine91 = new DxfLine(v9, v1);
            dxf.Entities.Add(DxfLine91);

            DxfLine DxfLine210 = new DxfLine(v2, v10);
            dxf.Entities.Add(DxfLine210);

            DxfLine DxfLine311 = new DxfLine(v3, v11);
            dxf.Entities.Add(DxfLine311);

            DxfLine DxfLine412 = new DxfLine(v4, v12);
            dxf.Entities.Add(DxfLine412);


            //new DxfDxfText("Line, DxfCircle, DxfArc, dimension, DxfText (R12)", new Point3D(0, 18d, 0d), 1.5d,)

            //DxfTextStyle style = new DxfTextStyle("True type font", "Arial.ttf");
            Point3D vt1 = new Point3D(v1.X+1.0d, v1.Y+2.5f, v1.Z);
            DxfText t1 = new DxfText("COIL", vt1, 2.0d);
            dxf.Entities.Add(t1);


            Point3D vt2 = new Point3D(v2.X + 1.0d, v2.Y + 2.5f, v2.Z);
            DxfText t2 = new DxfText("CLF", vt2, 2.0d);
            dxf.Entities.Add(t2);


            Point3D vt3 = new Point3D(v3.X + 1.0d, v3.Y + 2.5f, v3.Z);
            DxfText t3 = new DxfText(sectionEntity.CoolValue, vt3, 2.0d);
            dxf.Entities.Add(t3);

            Point3D vt4 = new Point3D(v5.X + 1.0d, v5.Y + 2.5f, v5.Z);
            DxfText t4 = new DxfText("FILTER", vt4, 2.0d);
 
            dxf.Entities.Add(t4);


            Point3D vt5 = new Point3D(v2.X + 1.0d, v5.Y + 2.5f, v5.Z);
            DxfText t5 = new DxfText("FTA", vt5, 2.0d);
            dxf.Entities.Add(t5);


            Point3D vt6 = new Point3D(v3.X + 1.0d, v5.Y + 2.5f, v5.Z);
            DxfText t6 = new DxfText(sectionEntity.FilterValue, vt6, 2.0d);
            dxf.Entities.Add(t6);


            Point3D vt7 = new Point3D(v7.X + 1.0d, v7.Y + 2.5f, v7.Z);
            DxfText t7 = new DxfText("SECTION", vt7, 2.0d);
            dxf.Entities.Add(t7);


            Point3D vt8 = new Point3D(v2.X + 1.0d, v7.Y + 2.5f, v7.Z);
            DxfText t8 = new DxfText("MODULE", vt8, 2.0d);
            dxf.Entities.Add(t8);

            Point3D vt9 = new Point3D(v3.X + 1.0d, v7.Y + 2.5f, v7.Z);
            DxfText t9 = new DxfText("CLEARANCE", vt9, 2.0d);
            dxf.Entities.Add(t9);

        }
    }
}
