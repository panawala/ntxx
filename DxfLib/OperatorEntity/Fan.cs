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
    public class Fan
    {
        /// <summary>
        /// 绘制风扇
        /// </summary>
        /// <param name="dxf"></param>
        /// <param name="startPoint">风扇起点，如果为横置，由左向右；如果为竖置，由下到上</param>
        /// <param name="endPoint">风扇终点，如果为横置，由左向右；如果为竖置，由下到上</param>
        /// <param name="pointerLocation">箭头位置，默认=0为无，=1代表箭头在中间，=2代表箭头在底部</param>
        public static void Draw(DxfDocument dxf, Vector3f startPoint, Vector3f endPoint,int pointerLocation=0)
        {
            Layer layer = new Layer("line");
            Line line = new Line(startPoint, endPoint);
            line.Layer = layer;
            dxf.AddEntity(line);

            //如果为横置
            if (startPoint.Y == endPoint.Y)
            {
                float segment = (endPoint.X - startPoint.X) / 4;
                Slash.Draw(dxf, new Location(startPoint.X + segment, startPoint.Y, startPoint.Z));
                Slash.Draw(dxf, new Location(startPoint.X + 2 * segment, startPoint.Y, startPoint.Z));
                Slash.Draw(dxf, new Location(startPoint.X + 3 * segment, startPoint.Y, startPoint.Z));
            }
            //如果为竖置
            else if (startPoint.X == endPoint.X)
            {
                float segment = (endPoint.Y - startPoint.Y) / 5;
                Slash.Draw(dxf, new Location(startPoint.X, startPoint.Y + segment, startPoint.Z));
                Slash.Draw(dxf, new Location(startPoint.X, startPoint.Y + 2 * segment, startPoint.Z));
                Slash.Draw(dxf, new Location(startPoint.X, startPoint.Y + 3 * segment, startPoint.Z));
                Slash.Draw(dxf, new Location(startPoint.X, startPoint.Y + 4 * segment, startPoint.Z));
                if (pointerLocation == 1)
                {
                    LinePointer.Draw(dxf,new Location(startPoint.X,(startPoint.Y+endPoint.Y)/2,startPoint.Z));
                }
                else if(pointerLocation==2)
                {
                    LinePointer.Draw(dxf, new Location(startPoint.X, startPoint.Y, startPoint.Z));
                }
            }

        }
    }
}
