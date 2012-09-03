using System;
using System.Collections.Generic;
using System.Linq;
using Model.Zutu;
using WW.Cad.Model;
using WW.Math;
using WW.Cad.Model.Entities;

namespace CadLib.OperatorEntity
{
    public class Wind
    {
        /// <summary>
        /// 风向绘制
        /// </summary>
        /// <param name="dxf"></param>
        /// <param name="DLocation"></param>
        /// <param name="isRight"></param>
        public static void Draw(DxfModel dxf, DLocation DLocation, bool isRight)
        {
            double factor = 0.5f;
            Point3D v1 = new Point3D();
            Point3D v2 = new Point3D();
            Point3D v3 = new Point3D();
            Point3D v4 = new Point3D();
            Point3D v5 = new Point3D();
            Point3D v6 = new Point3D();
            Point3D v7 = new Point3D();
            if (isRight)
            {
                v1 = new Point3D(10*factor + DLocation.X, DLocation.Y, DLocation.Z);
                v2 = new Point3D(DLocation.X, DLocation.Y + 10 * factor, DLocation.Z);
                v3 = new Point3D(DLocation.X + 10 * factor, DLocation.Y + 10 * factor, DLocation.Z);
                v4 = new Point3D(DLocation.X + 20 * factor, DLocation.Y + 15 * factor, DLocation.Z);
                v5 = new Point3D(DLocation.X, DLocation.Y + 20 * factor, DLocation.Z);
                v6 = new Point3D(DLocation.X + 10 * factor, DLocation.Y + 20 * factor, DLocation.Z);
                v7 = new Point3D(DLocation.X + 10 * factor, DLocation.Y + 30 * factor, DLocation.Z);
            }
            else
            {
                v1 = new Point3D(10 * factor + DLocation.X, DLocation.Y, DLocation.Z);
                v2 = new Point3D(DLocation.X + 20 * factor, DLocation.Y + 10 * factor, DLocation.Z);
                v3 = new Point3D(DLocation.X + 10 * factor, DLocation.Y + 10 * factor, DLocation.Z);
                v4 = new Point3D(DLocation.X, DLocation.Y + 15 * factor, DLocation.Z);
                v5 = new Point3D(DLocation.X + 20 * factor, DLocation.Y + 20 * factor, DLocation.Z);
                v6 = new Point3D(DLocation.X + 10 * factor, DLocation.Y + 20 * factor, DLocation.Z);
                v7 = new Point3D(DLocation.X + 10 * factor, DLocation.Y + 30 * factor, DLocation.Z);
            }
            DxfLine DxfLine23 = new DxfLine(v2, v3);
            dxf.Entities.Add(DxfLine23);

            DxfLine DxfLine56 = new DxfLine(v5, v6);
            dxf.Entities.Add(DxfLine56);

            DxfLine DxfLine14 = new DxfLine(v1, v4);
            dxf.Entities.Add(DxfLine14);

            DxfLine DxfLine74 = new DxfLine(v7, v4);
            dxf.Entities.Add(DxfLine74);

            DxfLine DxfLine25 = new DxfLine(v2, v5);
            dxf.Entities.Add(DxfLine25);

            DxfLine DxfLine71 = new DxfLine(v7, v1);
            dxf.Entities.Add(DxfLine71);

        }
        /// <summary>
        /// 绘制垂直风向箭头
        /// </summary>
        /// <param name="dxf"></param>
        /// <param name="DLocation"></param>
        public static void DrawVerticalWind(DxfModel dxf,DLocation DLocation)
        {
            double factor = 0.5f;
            Point3D v1 = new Point3D();
            Point3D v2 = new Point3D();
            Point3D v3 = new Point3D();
            Point3D v4 = new Point3D();
            Point3D v5 = new Point3D();
            Point3D v6 = new Point3D();
            Point3D v7 = new Point3D();
      
                v1 = new Point3D(DLocation.X, DLocation.Y, DLocation.Z);
                v2 = new Point3D(DLocation.X+10*factor, DLocation.Y, DLocation.Z);
                v3 = new Point3D(DLocation.X - 10 * factor, DLocation.Y + 10 * factor, DLocation.Z);
                v4 = new Point3D(DLocation.X, DLocation.Y + 10 * factor, DLocation.Z);
                v5 = new Point3D(DLocation.X+10*factor, DLocation.Y + 10* factor, DLocation.Z);
                v6 = new Point3D(DLocation.X + 20 * factor, DLocation.Y + 10 * factor, DLocation.Z);
                v7 = new Point3D(DLocation.X +5 * factor, DLocation.Y + 20 * factor, DLocation.Z);
            
            DxfLine DxfLine23 = new DxfLine(v1, v2);
            dxf.Entities.Add(DxfLine23);

            DxfLine DxfLine56 = new DxfLine(v3, v6);
            dxf.Entities.Add(DxfLine56);

            DxfLine DxfLine14 = new DxfLine(v1, v4);
            dxf.Entities.Add(DxfLine14);

            DxfLine DxfLine74 = new DxfLine(v2, v5);
            dxf.Entities.Add(DxfLine74);

            DxfLine DxfLine25 = new DxfLine(v3, v7);
            dxf.Entities.Add(DxfLine25);

            DxfLine DxfLine71 = new DxfLine(v6, v7);
            dxf.Entities.Add(DxfLine71);
        }
    }
}
