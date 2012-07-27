using System;
using System.Collections.Generic;
using System.Linq;
using Model.Zutu;
using WW.Cad.Model;
using WW.Math;
using WW.Cad.Model.Entities;

namespace CadLib.OperatorEntity
{
    public class Slash
    {
        public static void Draw(DxfModel dxf, DLocation DLocation)
        {
            Point3D v1 = new Point3D(DLocation.X - 0.5d, DLocation.Y - 1.0d, DLocation.Z);
            Point3D v2 = new Point3D(DLocation.X + 0.5d, DLocation.Y + 1.0d, DLocation.Z);

            DxfLine DxfLine12 = new DxfLine(v1, v2);
            dxf.Entities.Add(DxfLine12);
        }
    }
}
