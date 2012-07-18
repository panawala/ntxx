using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using netDxf;
using netDxf.Tables;
using netDxf.Entities;
using Model.Zutu;

namespace DxfLib.OperatorEntity
{
    public class Slash
    {
        public static void Draw(DxfDocument dxf, Location location)
        {
            Vector3f v1 = new Vector3f(location.X - 2.0f, location.Y - 4.0f, location.Z);
            Vector3f v2 = new Vector3f(location.X + 2.0f, location.Y + 4.0f, location.Z);
            Layer layer = new Layer("line");

            Line line12 = new Line(v1, v2);
            line12.Layer = layer;
            dxf.AddEntity(line12);
        }
    }
}
