using System;
using System.Collections.Generic;
using System.Linq;
using Model.Zutu;
using WW.Cad.Model;
using WW.Math;
using WW.Cad.Model.Entities;

namespace CadLib.OperatorEntity
{
    public class Fan
    {
        /// <summary>
        /// 绘制风扇
        /// </summary>
        /// <param name="dxf"></param>
        /// <param name="startPoint">风扇起点，如果为横置，由左向右；如果为竖置，由下到上</param>
        /// <param name="endPoint">风扇终点，如果为横置，由左向右；如果为竖置，由下到上</param>
        /// <param name="pointerDDLocation">箭头位置，默认=0为无，=1代表箭头在中间，=2代表箭头在底部</param>
        public static void Draw(DxfModel dxf, Point3D startPoint, Point3D endPoint, int pointerDDLocation = 0)
        {
            DxfLine DxfLine = new DxfLine(startPoint, endPoint);
            dxf.Entities.Add(DxfLine);

            //如果为横置
            if (startPoint.Y == endPoint.Y)
            {
                double segment = (endPoint.X - startPoint.X) / 4;
                Slash.Draw(dxf, new DLocation(startPoint.X + segment, startPoint.Y, startPoint.Z));
                Slash.Draw(dxf, new DLocation(startPoint.X + 2 * segment, startPoint.Y, startPoint.Z));
                Slash.Draw(dxf, new DLocation(startPoint.X + 3 * segment, startPoint.Y, startPoint.Z));
            }
            //如果为竖置
            else if (startPoint.X == endPoint.X)
            {
                double segment = (endPoint.Y - startPoint.Y) / 5;
                Slash.Draw(dxf, new DLocation(startPoint.X, startPoint.Y + segment, startPoint.Z));
                Slash.Draw(dxf, new DLocation(startPoint.X, startPoint.Y + 2 * segment, startPoint.Z));
                Slash.Draw(dxf, new DLocation(startPoint.X, startPoint.Y + 3 * segment, startPoint.Z));
                Slash.Draw(dxf, new DLocation(startPoint.X, startPoint.Y + 4 * segment, startPoint.Z));
                if (pointerDDLocation == 1)
                {
                    DxfLinePointer.Draw(dxf,new DLocation(startPoint.X,(startPoint.Y+endPoint.Y)/2,startPoint.Z));
                }
                else if(pointerDDLocation==2)
                {
                    DxfLinePointer.Draw(dxf, new DLocation(startPoint.X, startPoint.Y, startPoint.Z));
                }
            }

        }
    }
}
