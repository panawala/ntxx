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
    public class Configuration
    {
        public static void Draw(DxfDocument dxf, Location location,List<string> configurations)
        {
            Vector3f confStrVector3f = new Vector3f(location.X + 5.0f, location.Y - 5.0f, location.Z);
            TextStyle style = new TextStyle("True type font", "Arial.ttf");
            Text text1 = new Text("CONFIGURATION:                   NOTE:  Assembly drawing for overall dimesions,  actual door size and handle position may vary",
                confStrVector3f, 2.0f, style);
            Layer layer = new Layer("text");
            text1.Layer = layer;
            //text1.Layer.Color.Index = 8;
            text1.Alignment = TextAlignment.TopLeft;
            dxf.AddEntity(text1);

            for (int i = 0; i < configurations.Count(); i++)
            {
                Vector3f confVector3f = new Vector3f(location.X+10.0f, location.Y - 5.0f * (i + 2), location.Z);
                Text text = new Text(configurations[i], confVector3f, 2.0f, style);
                text.Layer = layer;
                //text.Layer.Color.Index = 8;
                text.Alignment = TextAlignment.TopLeft;
                dxf.AddEntity(text);
            }

        }
    }
}
