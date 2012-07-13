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
    public class Handle
    {
        /// <summary>
        /// 门把手绘制
        /// </summary>
        /// <param name="dxf"></param>
        /// <param name="location"></param>
        public static void Draw(DxfDocument dxf, Location location)
        {
             float factor = 0.05f;
             float distance = 30;
            //底部小圆的圆心
             Vector3f sCircle = new Vector3f(location.X + 10 * factor, location.Y, location.Z);
            //上部同心圆圆心
             Vector3f bCircle = new Vector3f(location.X + 10 * factor, location.Y + 5 * factor + distance*factor, location.Z);

             double alpha = Math.Asin(3 / distance);
             double beta = Math.Acos(0.8);

             Vector3f v1 = new Vector3f(
                 location.X + 10 * factor - float.Parse((5 * factor * Math.Cos(alpha)).ToString()),
                 location.Y + 5 * factor - float.Parse((5 * factor * Math.Sin(alpha)).ToString()), 
                 location.Z);

             Vector3f v2 = new Vector3f(
                  location.X + 10 * factor + float.Parse((5 * factor * Math.Cos(alpha)).ToString()),
                  location.Y + 5 * factor - float.Parse((5 * factor * Math.Sin(alpha)).ToString()),
                  location.Z);


             Vector3f v4 = new Vector3f(
                 location.X + 10 * factor -float.Parse((8*factor* Math.Cos(alpha)).ToString()),
                 location.Y + 5 * factor + distance * factor - float.Parse((8 * factor * Math.Sin(alpha)).ToString()),
                 location.Z
                 );

             Vector3f v5 = new Vector3f(
             location.X + 10 * factor  + float.Parse((8*factor*Math.Cos(alpha)).ToString()),
             location.Y + 5 * factor + distance * factor - float.Parse((8 * factor * Math.Sin(alpha)).ToString()),
             location.Z
             );
             Layer layer = new Layer("line");
             Line line14 = new Line(v1, v4);
             line14.Layer = layer;
             line14.Layer.Color.Index = 6;
             dxf.AddEntity(line14);

             Line line25 = new Line(v2, v5);
             line25.Layer = new Layer("line");
             line25.Layer = layer;
             dxf.AddEntity(line25);


             //arc
             Arc arc = new Arc(
                 new Vector3f(location.X + 10 * factor, location.Y + 5 * factor, location.Z),
                 5 * factor, Convert.ToInt32(180 + alpha * 180 / Math.PI), Convert.ToInt32(360 - alpha * 180 / Math.PI));
             arc.Layer = layer;
             //arc.Layer = layer;
             dxf.AddEntity(arc);


             //arcup
             Arc arcup = new Arc(
                 new Vector3f(location.X + 10 * factor, location.Y + 5 * factor + distance * factor, location.Z),
                 8 * factor, Convert.ToInt32(-alpha * 180 / Math.PI), Convert.ToInt32(180 + alpha * 180 / Math.PI));
             arcup.Layer = layer;
             //arcup.Layer.Color.Index = 8;
             dxf.AddEntity(arcup);

             //arcround
             Arc arcround = new Arc(
                 new Vector3f(location.X + 10 * factor, location.Y + 5 * factor + distance * factor, location.Z),
                 10 * factor, 
                 Convert.ToInt32(-(alpha +beta) * 180 / Math.PI),
                 Convert.ToInt32(180 + (alpha +beta) * 180 / Math.PI));
             arcround.Layer = layer;
             //arcround.Layer.Color.Index = 8;
             dxf.AddEntity(arcround);

             //circle
             Vector3f extrusion = new Vector3f(0, 0, 1);
             Vector3f centerWCS = new Vector3f(location.X+10*factor, location.Y+5*factor+distance*factor, location.Z);
             Vector3d centerOCS = MathHelper.Transform((Vector3d)centerWCS,
                                                       (Vector3d)extrusion,
                                                       MathHelper.CoordinateSystem.World,
                                                       MathHelper.CoordinateSystem.Object);

             Circle circle = new Circle((Vector3f)centerOCS, 7*factor);
             circle.Layer = layer;
             //circle.Layer.Color = AciColor.Yellow;
             circle.LineType = LineType.Continuous;
             circle.Normal = extrusion;
             dxf.AddEntity(circle);

             //上部同心圆圆心
             Vector3f t1 = new Vector3f(
                 location.X + 8 * factor,
                 location.Y + 5 * factor + (distance - 7) * factor * 0.7f,
                 location.Z);
             Vector3f t2 = new Vector3f(
                 location.X + 8 * factor,
                 location.Y + 5 * factor + (distance - 7) * factor * 0.5f,
                 location.Z);
             Vector3f t3 = new Vector3f(
                 location.X + 8 * factor, 
                 location.Y + 5 * factor + (distance - 7) * factor * 0.3f, 
                 location.Z);
             Vector3f t4 = new Vector3f(
                 location.X + 8 * factor, 
                 location.Y + 5 * factor + (distance - 7) * factor * 0.1f, 
                 location.Z);
             

             //text
             TextStyle style = new TextStyle("True type font", "Arial.ttf");
             Text text1 = new Text("A", t1, 0.2f, style);
             text1.Layer = layer;
             //text1.Layer.Color.Index = 8;
             text1.Alignment = TextAlignment.TopLeft;
             dxf.AddEntity(text1);

             //text
             Text text2 = new Text("A", t2, 0.2f, style);
             text2.Layer = layer;
             //text2.Layer.Color.Index = 8;
             text2.Alignment = TextAlignment.TopLeft;
             dxf.AddEntity(text2);

             //text
             Text text3 = new Text("O", t3, 0.2f, style);
             text3.Layer = layer;
             //text3.Layer.Color.Index = 8;
             text3.Alignment = TextAlignment.TopLeft;
             dxf.AddEntity(text3);

             //text
             Text text4 = new Text("N", t4, 0.2f, style);
             text4.Layer = layer;
             //text4.Layer.Color.Index = 8;
             text4.Alignment = TextAlignment.TopLeft;
             dxf.AddEntity(text4);


        }
    }
}
