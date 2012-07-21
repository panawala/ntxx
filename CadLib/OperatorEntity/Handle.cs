using System;
using System.Collections.Generic;
using System.Linq;
using Model.Zutu;
using WW.Cad.Model;
using WW.Math;
using WW.Cad.Model.Entities;

namespace CadLib.OperatorEntity
{
    public class Handle
    {
        /// <summary>
        /// 门把手绘制
        /// </summary>
        /// <param name="dxf"></param>
        /// <param name="DLocation"></param>
        public static void Draw(DxfModel dxf, DLocation DLocation)
        {
             double factor = 0.05f;
             double distance = 30;
            //底部小圆的圆心
             Point3D sDxfCircle = new Point3D(DLocation.X + 10 * factor, DLocation.Y, DLocation.Z);
            //上部同心圆圆心
             Point3D bDxfCircle = new Point3D(DLocation.X + 10 * factor, DLocation.Y + 5 * factor + distance*factor, DLocation.Z);

             double alpha = Math.Asin(3 / distance);
             double beta = Math.Acos(0.8);

             Point3D v1 = new Point3D(
                 DLocation.X + 10 * factor - double.Parse((5 * factor * Math.Cos(alpha)).ToString()),
                 DLocation.Y + 5 * factor - double.Parse((5 * factor * Math.Sin(alpha)).ToString()), 
                 DLocation.Z);

             Point3D v2 = new Point3D(
                  DLocation.X + 10 * factor + double.Parse((5 * factor * Math.Cos(alpha)).ToString()),
                  DLocation.Y + 5 * factor - double.Parse((5 * factor * Math.Sin(alpha)).ToString()),
                  DLocation.Z);


             Point3D v4 = new Point3D(
                 DLocation.X + 10 * factor -double.Parse((8*factor* Math.Cos(alpha)).ToString()),
                 DLocation.Y + 5 * factor + distance * factor - double.Parse((8 * factor * Math.Sin(alpha)).ToString()),
                 DLocation.Z
                 );

             Point3D v5 = new Point3D(
             DLocation.X + 10 * factor  + double.Parse((8*factor*Math.Cos(alpha)).ToString()),
             DLocation.Y + 5 * factor + distance * factor - double.Parse((8 * factor * Math.Sin(alpha)).ToString()),
             DLocation.Z
             );
             DxfLine DxfLine14 = new DxfLine(v1, v4);
             dxf.Entities.Add(DxfLine14);

             DxfLine DxfLine25 = new DxfLine(v2, v5);
             dxf.Entities.Add(DxfLine25);


             //DxfArc
             DxfArc DxfArc = new DxfArc(
                 new Point3D(DLocation.X + 10 * factor, DLocation.Y + 5 * factor, DLocation.Z),
                 5 * factor, Convert.ToInt32(180 + alpha * 180 / Math.PI), Convert.ToInt32(360 - alpha * 180 / Math.PI));
             dxf.Entities.Add(DxfArc);


             //DxfArcup
             DxfArc DxfArcup = new DxfArc(
                 new Point3D(DLocation.X + 10 * factor, DLocation.Y + 5 * factor + distance * factor, DLocation.Z),
                 8 * factor, Convert.ToInt32(-alpha * 180 / Math.PI), Convert.ToInt32(180 + alpha * 180 / Math.PI));
             dxf.Entities.Add(DxfArcup);

             //DxfArcround
             DxfArc DxfArcround = new DxfArc(
                 new Point3D(DLocation.X + 10 * factor, DLocation.Y + 5 * factor + distance * factor, DLocation.Z),
                 10 * factor, 
                 Convert.ToInt32(-(alpha +beta) * 180 / Math.PI),
                 Convert.ToInt32(180 + (alpha +beta) * 180 / Math.PI));
             dxf.Entities.Add(DxfArcround);

             //DxfCircle
             Point3D centerWCS = new Point3D(DLocation.X+10*factor, DLocation.Y+5*factor+distance*factor, DLocation.Z);
             DxfCircle DxfCircle = new DxfCircle((Point3D)centerWCS, 7 * factor);
             dxf.Entities.Add(DxfCircle);

             //上部同心圆圆心
             Point3D t1 = new Point3D(
                 DLocation.X + 8 * factor,
                 DLocation.Y + 5 * factor + (distance - 7) * factor * 0.7f,
                 DLocation.Z);
             Point3D t2 = new Point3D(
                 DLocation.X + 8 * factor,
                 DLocation.Y + 5 * factor + (distance - 7) * factor * 0.5f,
                 DLocation.Z);
             Point3D t3 = new Point3D(
                 DLocation.X + 8 * factor, 
                 DLocation.Y + 5 * factor + (distance - 7) * factor * 0.3f, 
                 DLocation.Z);
             Point3D t4 = new Point3D(
                 DLocation.X + 8 * factor, 
                 DLocation.Y + 5 * factor + (distance - 7) * factor * 0.1f, 
                 DLocation.Z);
             

             //DxfText
             DxfText DxfText1 = new DxfText("A", t1, 0.2f);
             dxf.Entities.Add(DxfText1);

             //DxfText
             DxfText DxfText2 = new DxfText("A", t2, 0.2f);
             dxf.Entities.Add(DxfText2);

             //DxfText
             DxfText DxfText3 = new DxfText("O", t3, 0.2f);
             dxf.Entities.Add(DxfText3);

             //DxfText
             DxfText DxfText4 = new DxfText("N", t4, 0.2f);
             dxf.Entities.Add(DxfText4);


        }
    }
}
