using System;
using System.Collections.Generic;
using System.Linq;
using Model.Zutu;
using WW.Cad.Model;
using WW.Math;
using WW.Cad.Model.Entities;

namespace CadLib.OperatorEntity
{
    public class Configuration
    {
        public static void Draw(DxfModel dxf, DLocation DLocation,List<string> configurations)
        {
            Point3D confStrPoint3D = new Point3D(DLocation.X + 5.0d, DLocation.Y - 5.0d, DLocation.Z);
            DxfText DxfText1 = new DxfText("CONFIGURATION:                   NOTE:  Assembly drawing for overall dimesions,  actual door size and handle position may vary",
                confStrPoint3D, 2.0d);
            //DxfText1.Layer.Color.Index = 8;
            dxf.Entities.Add(DxfText1);

            for (int i = 0; i < configurations.Count(); i++)
            {
                Point3D confPoint3D = new Point3D(DLocation.X+10.0d, DLocation.Y - 5.0d * (i + 2), DLocation.Z);
                DxfText DxfText = new DxfText(configurations[i], confPoint3D, 2.0d);
                dxf.Entities.Add(DxfText);
            }

        }
    }
}
