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
    public class LinePointer
    {
        public static void Draw(DxfDocument dxf, Location location)
        {
            Vector3f v1 = new Vector3f(location.X - 2.0f, location.Y + 4.0f, location.Z);
            Vector3f v2 = new Vector3f(location.X + 2.0f, location.Y + 4.0f, location.Z);
            Vector3f v0=new Vector3f(location.X,location.Y,location.Z);
            Layer layer = new Layer("line");

            Line line10 = new Line(v0, v1);
            line10.Layer = layer;
            dxf.AddEntity(line10);

            Line line20 = new Line(v0, v2);
            line20.Layer = layer;
            dxf.AddEntity(line20);
        }
    }
}
