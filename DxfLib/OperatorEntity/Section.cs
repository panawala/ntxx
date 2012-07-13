using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using netDxf;
using netDxf.Entities;
using netDxf.Tables;
using Model.Zutu;
using DxfLib.Entity;

namespace DxfLib.OperatorEntity
{
    public class Section
    {
     /// <summary>
     /// 绘制左下角区域的Section块
     /// </summary>
     /// <param name="dxf"></param>
     /// <param name="location"></param>
     /// <param name="configurations"></param>
        public static void Draw(DxfDocument dxf, Location location,SectionEntity sectionEntity)
        {
            float factor=0.6f;
            Vector3f v1 = new Vector3f(location.X, location.Y + 40.0f*factor, location.Z);
            Vector3f v2 = new Vector3f(location.X + 50.0f * factor, location.Y + 40.0f * factor, location.Z);
            Vector3f v3 = new Vector3f(location.X + 90.0f * factor, location.Y + 40.0f * factor, location.Z);
            Vector3f v4 = new Vector3f(location.X + 140.0f * factor, location.Y + 40.0f * factor, location.Z);

            Vector3f v5 = new Vector3f(location.X, location.Y + 50.0f * factor, location.Z);    
            Vector3f v6 = new Vector3f(location.X + 140.0f * factor, location.Y + 50.0f * factor, location.Z);

            Vector3f v7 = new Vector3f(location.X, location.Y + 60.0f * factor, location.Z);
            Vector3f v8 = new Vector3f(location.X + 140.0f * factor, location.Y + 60.0f * factor, location.Z);

            Vector3f v9 = new Vector3f(location.X, location.Y + 70.0f * factor, location.Z);
            Vector3f v10 = new Vector3f(location.X + 50.0f * factor, location.Y + 70.0f * factor, location.Z);
            Vector3f v11 = new Vector3f(location.X + 90.0f * factor, location.Y + 70.0f * factor, location.Z);
            Vector3f v12 = new Vector3f(location.X + 140.0f * factor, location.Y + 70.0f * factor, location.Z);

            Layer layer = new Layer("line");

            //横向四道
            Line line14 = new Line(v1, v4);
            line14.Layer = layer;
            //line14.Layer.Color.Index = 8;
            dxf.AddEntity(line14);

            Line line56 = new Line(v5, v6);
            line56.Layer = layer;
            //line56.Layer.Color.Index = 8;
            dxf.AddEntity(line56);

            Line line78 = new Line(v7, v8);
            line78.Layer = layer;
            //line78.Layer.Color.Index = 8;
            dxf.AddEntity(line78);

            Line line912 = new Line(v9, v12);
            line912.Layer = layer;
            //line912.Layer.Color.Index = 8;
            dxf.AddEntity(line912);

            //纵向四道
            Line line91 = new Line(v9, v1);
            line91.Layer = layer;
            //line91.Layer.Color.Index = 8;
            dxf.AddEntity(line91);

            Line line210 = new Line(v2, v10);
            line210.Layer = layer;
            //line210.Layer.Color.Index = 8;
            dxf.AddEntity(line210);

            Line line311 = new Line(v3, v11);
            line311.Layer = layer;
            //line311.Layer.Color.Index = 8;
            dxf.AddEntity(line311);

            Line line412 = new Line(v4, v12);
            line412.Layer = layer;
            //line412.Layer.Color.Index = 8;
            dxf.AddEntity(line412);

            //Layer textLayer = new Layer("text");

            TextStyle style = new TextStyle("True type font", "Arial.ttf");
            Vector3f vt1 = new Vector3f(v1.X+1.0f, v1.Y+2.5f, v1.Z);
            Text t1 = new Text("COIL", vt1, 2.0f, style);
            t1.Layer = layer;
            //t1.Layer.Color.Index = 8;
            t1.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t1);


            Vector3f vt2 = new Vector3f(v2.X + 1.0f, v2.Y + 2.5f, v2.Z);
            Text t2 = new Text("CLF", vt2, 2.0f, style);
            t2.Layer = layer;
            //t2.Layer.Color.Index = 8;
            t2.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t2);


            Vector3f vt3 = new Vector3f(v3.X + 1.0f, v3.Y + 2.5f, v3.Z);
            Text t3 = new Text(sectionEntity.CoolValue, vt3, 2.0f, style);
            t3.Layer = layer;
            //t3.Layer.Color.Index = 8;
            t3.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t3);

            Vector3f vt4 = new Vector3f(v5.X + 1.0f, v5.Y + 2.5f, v5.Z);
            Text t4 = new Text("FILTER", vt4, 2.0f, style);
            t4.Layer = layer;
            //t4.Layer.Color.Index = 8;
            t4.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t4);


            Vector3f vt5 = new Vector3f(v2.X + 1.0f, v5.Y + 2.5f, v5.Z);
            Text t5 = new Text("FTA", vt5, 2.0f, style);
            t5.Layer = layer;
            //t5.Layer.Color.Index = 8;
            t5.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t5);


            Vector3f vt6 = new Vector3f(v3.X + 1.0f, v5.Y + 2.5f, v5.Z);
            Text t6 = new Text(sectionEntity.FilterValue, vt6, 2.0f, style);
            t6.Layer = layer;
            //t6.Layer.Color.Index = 8;
            t6.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t6);


            Vector3f vt7 = new Vector3f(v7.X + 1.0f, v7.Y + 2.5f, v7.Z);
            Text t7 = new Text("SECTION", vt7, 2.0f, style);
            t7.Layer = layer;
            //t7.Layer.Color.Index = 8;
            t7.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t7);


            Vector3f vt8 = new Vector3f(v2.X + 1.0f, v7.Y + 2.5f, v7.Z);
            Text t8 = new Text("MODULE", vt8, 2.0f, style);
            t8.Layer = layer;
            //t8.Layer.Color.Index = 8;
            t8.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t8);

            Vector3f vt9 = new Vector3f(v3.X + 1.0f, v7.Y + 2.5f, v7.Z);
            Text t9 = new Text("CLEARANCE", vt9, 2.0f, style);
            t9.Layer = layer;
            //t9.Layer.Color.Index = 8;
            t9.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(t9);

        }
    }
}
