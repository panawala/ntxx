using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using Model.Pintu;

namespace Annon.Pintu
{
    class FecthDxfService
    {
        public  FileStream fs{get;set;}
        public StreamReader sr { get; set;}
        public List<LAYER> LayerList = new List<LAYER>();
        public List<LINE> LineList = new List<LINE>();
        public List<ARC> ArcList = new List<ARC>();
        public List<ELLIPSE> EllipseList = new List<ELLIPSE>();
        public List<LWPOLYLINE> LwopolylineList = new List<LWPOLYLINE>();
        public List<SPLINE> SplineList = new List<SPLINE>();
        private string[] str = new string[2];
        private int count;
        private double leftx;
        private double lefty;
        private double rightx;
        private double righty;

        private string[] ReadPair()
        {
            string code = sr.ReadLine().Trim();
            string codedata = sr.ReadLine().Trim();
            count += 2;
            string[] result = new string[2] { code, codedata };
            return result;
        }

        public void Read()
        {
            while (sr.Peek() != -1)
            {
                str = ReadPair();
                if (str[1] == "SECTION")
                {
                    str = ReadPair();
                    switch (str[1])
                    {
                        case "HEADER": ReadHeader();
                            break;
                        case "TABLES": ReadTable();
                            break;
                        case "ENTITIES": ReadEntities();
                            break;
                    }
                }
            }
            sr.Close();
            fs.Close();
            count = 0;

        }

        private void ReadTable()
        {
            while (str[1] != "ENDSEC")
            {
                while (str[0] != "2" || str[1] != "LAYER")
                {
                    str = ReadPair();
                }
                while (str[0] != "0" || str[1] != "LAYER")
                {
                    str = ReadPair();
                }
                while (str[0] == "0" && str[1] == "LAYER")
                {
                    ReadLAYER();
                }
                while (str[1] != "ENDSEC")
                {
                    str = ReadPair();
                }
            }
        }

        private void ReadLAYER()
        {
            LAYER newlayer = new LAYER();
            while (str[1] != "ENDTAB")
            {
                str = ReadPair();
                switch (str[0])
                {
                    case "2": newlayer.name = str[1];
                        break;
                    case "62": newlayer.colornum = str[1];
                        break;
                    case "6": newlayer.lstyle = str[1];
                        break;
                    case "370": newlayer.lwidth = str[1];
                        break;
                }
                if (str[0] == "0" && str[1] == "LAYER")
                {
                    LayerList.Add(newlayer);
                    return;
                }
            }
            LayerList.Add(newlayer);
        }


        private void ReadEntities()
        {
            while (str[1] != "ENDSEC")
            {
                switch (str[1])
                {
                    case "LINE": ReadLine();
                        break;
                    case "ARC": ReadArc();
                        break;
                    case "CIRCLE": ReadArc();
                        break;
                    case "ELLIPSE": ReadEllipse();
                        break;
                    case "LWPOLYLINE": ReadLwpolyline();
                        break;
                    case "SPLINE": ReadSpline();
                        break;
                    default: str = ReadPair();
                        break;
                }

            }
        }

        private void ReadArc()
        {
            ARC newarc = new ARC();
            while (str[1] != "ENDSEC")
            {
                str = ReadPair();
                switch (str[0])
                {
                    case "8": newarc.LName = str[1];
                        break;
                    case "10": newarc.CenterX = Double.Parse(str[1]);
                        break;
                    case "20": newarc.CenterY = Double.Parse(str[1]);
                        break;
                    case "40": newarc.Radiu = Double.Parse(str[1]);
                        break;
                    case "50": newarc.SAngle = Double.Parse(str[1]);
                        break;
                    case "51": newarc.EAngle = Double.Parse(str[1]);
                        break;
                    case "370": newarc.lwidth = str[1];
                        break;
                    case "0": ArcList.Add(newarc);
                        return;
                }
            }
        }

        private void ReadLine()
        {
            LINE newline = new LINE();
            while (str[1] != "ENDSEC")
            {
                str = ReadPair();
                switch (str[0])
                {
                    case "8": newline.LName = str[1];
                        break;
                    case "10": newline.StartX = Double.Parse(str[1]);
                        break;
                    case "20": newline.StartY = Double.Parse(str[1]);
                        break;
                    case "11": newline.EndX = Double.Parse(str[1]);
                        break;
                    case "21": newline.EndY = Double.Parse(str[1]);
                        break;
                    case "62": newline.colornum = str[1];
                        break;
                    case "370": newline.lwidth = str[1];
                        break;
                    case "0": LineList.Add(newline);
                        return;
                }
            }
        }

        private void ReadEllipse()
        {
            ELLIPSE newellipse = new ELLIPSE();
            while (str[1] != "ENDSEC")
            {
                str = ReadPair();
                switch (str[0])
                {
                    case "8": newellipse.LName = str[1];
                        break;
                    case "10": newellipse.CenterX = Double.Parse(str[1]);
                        break;
                    case "20": newellipse.CenterY = Double.Parse(str[1]);
                        break;
                    case "11": newellipse.DeltaX = Double.Parse(str[1]);
                        break;
                    case "21": newellipse.DeltaY = Double.Parse(str[1]);
                        break;
                    case "40": newellipse.Radio = Double.Parse(str[1]);
                        break;
                    case "41": newellipse.PSAngle = Double.Parse(str[1]);
                        break;
                    case "42": newellipse.PEAngle = Double.Parse(str[1]);
                        break;
                    case "370": newellipse.lwidth = str[1];
                        break;
                    case "0": EllipseList.Add(newellipse);
                        return;
                }
            }
        }

        private void ReadLwpolyline()
        {
            LWPOLYLINE newlw = new LWPOLYLINE();
            while (str[1] != "ENDSEC")
            {
                str = ReadPair();
                switch (str[0])
                {
                    case "8": newlw.LName = str[1];
                        break;
                    case "370": newlw.lwidth = str[1];
                        break;
                    case "62": newlw.colornum = str[1];
                        break;
                    case "90": newlw.PointCount = Int32.Parse(str[1]);
                        break;
                    case "70": newlw.Flag = Int32.Parse(str[1]);
                        break;
                    case "10": newlw.pointx = new double[newlw.PointCount];
                        newlw.pointy = new double[newlw.PointCount];
                        //if (newlw.Flag == 1)
                        newlw.converxity = new double[newlw.PointCount];
                        //else
                        //newlw.converxity = new double[newlw.PointCount - 1];
                        newlw.pointx[0] = Double.Parse(str[1]);
                        str = ReadPair();
                        newlw.pointy[0] = Double.Parse(str[1]);
                        for (int i = 1; i < newlw.PointCount; i++)
                        {
                            string temp = sr.ReadLine().Trim();
                            if (temp == "42")
                            {
                                newlw.converxity[i - 1] = Double.Parse(sr.ReadLine().Trim());
                                i--;
                            }
                            else if (temp == "20")
                            {
                                string r = sr.ReadLine().Trim();
                                newlw.pointy[i] = Double.Parse(r);
                            }
                            else
                            {
                                string r = sr.ReadLine().Trim();
                                newlw.pointx[i] = Double.Parse(r);
                                i--;
                            }
                        }
                        string s = sr.ReadLine().Trim();
                        if (s == "42")
                            newlw.converxity[newlw.PointCount - 1] = Double.Parse(sr.ReadLine().Trim());
                        else if (s == "0")
                        {
                            sr.ReadLine();
                            LwopolylineList.Add(newlw);
                            return;
                        }
                        else sr.ReadLine();
                        break;
                    case "0": LwopolylineList.Add(newlw);
                        return;
                }
            }
        }

        public void ReadSpline()
        {
            SPLINE newspline = new SPLINE();
            while (str[1] != "ENDSEC")
            {
                str = ReadPair();
                switch (str[0])
                {
                    case "8": newspline.LName = str[1];
                        break;
                    case "370": newspline.lwidth = str[1];
                        break;
                    case "62": newspline.colornum = str[1];
                        break;
                    case "70": newspline.Flag = Int32.Parse(str[1]);
                        break;
                    case "74": newspline.Count = Int32.Parse(str[1]);
                        newspline.throughpx = new double[Int32.Parse(str[1])];
                        newspline.throughpy = new double[Int32.Parse(str[1])];
                        break;
                    case "12": newspline.SVertorX = Double.Parse(str[1]);
                        break;
                    case "22": newspline.SVertorY = Double.Parse(str[1]);
                        break;
                    case "13": newspline.EVertorX = Double.Parse(str[1]);
                        break;
                    case "23": newspline.EVertorY = Double.Parse(str[1]);
                        break;
                    case "11": newspline.throughpx[0] = Double.Parse(str[1]);
                        str = ReadPair();
                        newspline.throughpy[0] = Double.Parse(str[1]);
                        str = ReadPair();
                        for (int i = 1; i < newspline.throughpx.Length; i++)
                        {
                            str = ReadPair();
                            if (str[0] == "11")
                            {
                                newspline.throughpx[i] = Double.Parse(str[1]);
                                i--;
                            }
                            else if (str[0] == "21")
                            {
                                newspline.throughpy[i] = Double.Parse(str[1]);
                                i--;
                            }
                        }
                        if (newspline.Flag == 11)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                str = ReadPair();
                            }
                        }
                        break;
                    case "0": SplineList.Add(newspline);
                        return;
                }
            }
        }

        public void ReadHeader()
        {
            while (str[1] != "ENDSEC")
            {
                str = ReadPair();
                switch (str[1])
                {
                    case "$EXTMIN": str = ReadPair();
                        leftx = Double.Parse(str[1]);
                        str = ReadPair();
                        lefty = Double.Parse(str[1]);
                        break;
                    case "$EXTMAX": str = ReadPair();
                        rightx = Double.Parse(str[1]);
                        str = ReadPair();
                        righty = Double.Parse(str[1]);
                        break;
                }
            }
        }
    }
}
