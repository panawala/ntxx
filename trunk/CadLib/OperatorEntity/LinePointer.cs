using System;
using System.Collections.Generic;
using System.Linq;
using Model.Zutu;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Math;

namespace CadLib.OperatorEntity
{
    public class DxfLinePointer
    {
        public static void Draw(DxfModel dxf, DLocation DLocation)
        {
            Point3D v1 = new Point3D(DLocation.X - 2.0d, DLocation.Y + 4.0d, DLocation.Z);
            Point3D v2 = new Point3D(DLocation.X + 2.0d, DLocation.Y + 4.0d, DLocation.Z);
            Point3D v0=new Point3D(DLocation.X,DLocation.Y,DLocation.Z);

            DxfLine DxfLine10 = new DxfLine(v0, v1);
            dxf.Entities.Add(DxfLine10);

            DxfLine DxfLine20 = new DxfLine(v0, v2);
            dxf.Entities.Add(DxfLine20);
        }
    }
}
