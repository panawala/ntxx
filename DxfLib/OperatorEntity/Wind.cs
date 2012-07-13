using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using netDxf;
using netDxf.Entities;
using netDxf.Tables;
using Model.Zutu;

namespace DxfLib.OperatorEntity
{
    public class Wind
    {
        /// <summary>
        /// 风向绘制
        /// </summary>
        /// <param name="dxf"></param>
        /// <param name="location"></param>
        /// <param name="isRight"></param>
        public static void Draw(DxfDocument dxf, Location location, bool isRight)
        {
            float factor = 0.5f;
            Vector3f v1 = new Vector3f();
            Vector3f v2 = new Vector3f();
            Vector3f v3 = new Vector3f();
            Vector3f v4 = new Vector3f();
            Vector3f v5 = new Vector3f();
            Vector3f v6 = new Vector3f();
            Vector3f v7 = new Vector3f();
            if (isRight)
            {
                v1 = new Vector3f(10*factor + location.X, location.Y, location.Z);
                v2 = new Vector3f(location.X, location.Y + 10 * factor, location.Z);
                v3 = new Vector3f(location.X + 10 * factor, location.Y + 10 * factor, location.Z);
                v4 = new Vector3f(location.X + 20 * factor, location.Y + 15 * factor, location.Z);
                v5 = new Vector3f(location.X, location.Y + 20 * factor, location.Z);
                v6 = new Vector3f(location.X + 10 * factor, location.Y + 20 * factor, location.Z);
                v7 = new Vector3f(location.X + 10 * factor, location.Y + 30 * factor, location.Z);
            }
            else
            {
                v1 = new Vector3f(10 * factor + location.X, location.Y, location.Z);
                v2 = new Vector3f(location.X + 20 * factor, location.Y + 10 * factor, location.Z);
                v3 = new Vector3f(location.X + 10 * factor, location.Y + 10 * factor, location.Z);
                v4 = new Vector3f(location.X, location.Y + 15 * factor, location.Z);
                v5 = new Vector3f(location.X + 20 * factor, location.Y + 20 * factor, location.Z);
                v6 = new Vector3f(location.X + 10 * factor, location.Y + 20 * factor, location.Z);
                v7 = new Vector3f(location.X + 10 * factor, location.Y + 30 * factor, location.Z);
            }
            Layer layer = new Layer("line"); 
            Line line23 = new Line(v2, v3);
            line23.Layer = layer;
            //line23.Layer.Color = AciColor.Default;
            dxf.AddEntity(line23);

            Line line56 = new Line(v5, v6);
            line56.Layer = layer;
            //line56.Layer.Color = AciColor.Default;
            dxf.AddEntity(line56);

            Line line14 = new Line(v1, v4);
            line14.Layer = layer;
            //line14.Layer.Color = AciColor.Default;
            dxf.AddEntity(line14);

            Line line74 = new Line(v7, v4);
            line74.Layer = layer;
            //line74.Layer.Color = AciColor.Default;
            dxf.AddEntity(line74);

            Line line25 = new Line(v2, v5);
            line25.Layer = layer;
            //line25.Layer.Color = AciColor.Default;
            dxf.AddEntity(line25);

            Line line71 = new Line(v7, v1);
            line71.Layer = new Layer("line");
            //line71.Layer.Color = AciColor.Default;
            dxf.AddEntity(line71);

        }
    }
}
