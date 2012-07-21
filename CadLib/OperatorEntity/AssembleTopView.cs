
﻿using System;
using System.Collections.Generic;
using System.Linq;
using Model.Zutu;
using WW.Cad.Model;

namespace CadLib.OperatorEntity
{
    public class AssembleTopView
    {

        public static void assembleTopView(List<PictureBoxInfo> imageNameList, DxfModel dxf, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space, double barHeight, double barWidth)
        {

            List<DLocation> storeDLocationList = new List<DLocation>();
            for (int i = 0; i < imageNameList.Count; i++)
            {
                string imageName = imageNameList.ElementAt(i).name;
                if (imageName.Equals("FTA") || imageName.Equals("FTC") || imageName.Equals("FTF") || imageName.Equals("FTH"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentDLocation.Y, currentDLocation.Z));
                    }
                }
                else if (imageName.Equals("MBA") || imageName.Equals("MBB") || imageName.Equals("MBC") || imageName.Equals("MBD") || imageName.Equals("MBE") || imageName.Equals("MBF") || imageName.Equals("MBG") || imageName.Equals("MBH") || imageName.Equals("MBI") || imageName.Equals("MBJ") || imageName.Equals("MBK"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i); ;
                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvDoubleHeight, DoorInitHeightAndWidth.tvDoubleWidth, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvDoubleWidth, currentDLocation.Y, currentDLocation.Z));
                    }
                }
                else if (imageName.Equals("PHA") || imageName.Equals("PHB") || imageName.Equals("PHC") || imageName.Equals("PHD"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i); ;
                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvDoubleDoorHeigt, DoorInitHeightAndWidth.tvDoubleDoorWidth, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvDoubleDoorWidth, currentDLocation.Y, currentDLocation.Z));
                    }
                }
                else if (imageName.Equals("HRA"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentDLocation.Y, currentDLocation.Z));
                    }
                }
                else if (imageName.Equals("virtualHRA"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentDLocation.Y, currentDLocation.Z));
                    }
                }
                else if (imageName.Equals("CLB") || imageName.Equals("CLC") || imageName.Equals("CLF") || imageName.Equals("CLG") || imageName.Equals("CLI") || imageName.Equals("CLM"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentDLocation.Y, currentDLocation.Z));
                    }
                }
                else if (imageName.Equals("PEA") || imageName.Equals("PEC") || imageName.Equals("RFA") || imageName.Equals("SFA") || imageName.Equals("SFC") || imageName.Equals("SFD"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentDLocation.Y, currentDLocation.Z));
                    }
                }
                else if (imageName.Equals("BBA") || imageName.Equals("BBB") || imageName.Equals("BBC") || imageName.Equals("BBD") || imageName.Equals("BBE"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentDLocation.Y, currentDLocation.Z));
                    }
                }
                else if (imageName.Equals("TRA") || imageName.Equals("TRB") || imageName.Equals("TRC") || imageName.Equals("TRD") || imageName.Equals("TRE"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentDLocation.Y, currentDLocation.Z));
                    }
                }
            }

            //画标注
            DLocation firstDLocation = storeDLocationList.ElementAt(0);
            DoorRectangle.writeDimension(dxf, new DLocation(firstDLocation.X, firstDLocation.Y - outer_in_space, firstDLocation.Z), firstDLocation, 16f, 1f, 5, "left");
            DoorRectangle.writeDimension(dxf, firstDLocation, new DLocation(firstDLocation.X, firstDLocation.Y + 5, firstDLocation.Z), 16f, 1f, 5, "left");
            DoorRectangle.writeDimension(dxf, new DLocation(firstDLocation.X, firstDLocation.Y + 5, firstDLocation.Z), new DLocation(firstDLocation.X, firstDLocation.Y + 45, firstDLocation.Z), 16f, 1f, 8, "left");

            //top
            DLocation lastDLocation = storeDLocationList.ElementAt(storeDLocationList.Count - 1);
            DoorRectangle.writeDimension(dxf, new DLocation(firstDLocation.X, firstDLocation.Y + height, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y + height, firstDLocation.Z), 16f, 1f, 10, "top");

            //right
            DoorRectangle.writeDimension(dxf, new DLocation(lastDLocation.X, lastDLocation.Y + 10, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y + 40, firstDLocation.Z), 16f, 1f, 5f, "right");
            DoorRectangle.writeDimension(dxf, new DLocation(lastDLocation.X, lastDLocation.Y, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y + 10, firstDLocation.Z), 16f, 1f, 5f, "right");
            DoorRectangle.writeDimension(dxf, new DLocation(lastDLocation.X, lastDLocation.Y, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y + height, firstDLocation.Z), 16f, 1f, 10f, "right");
            DoorRectangle.writeDimension(dxf, new DLocation(lastDLocation.X, lastDLocation.Y - 6, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y, firstDLocation.Z), 16f, 1f, 10f, "right");
            DoorRectangle.writeDimension(dxf, new DLocation(lastDLocation.X, lastDLocation.Y - 6, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y + height + outer_in_space, firstDLocation.Z), 16f, 1f, 14f, "right");
        }

        public static void assembleTopView(List<PictureBoxInfo> imageNameList, DxfModel dxf, DLocation DLocation, TopViewConfigure tvc)
        {
            if (AssembleDetailMechine.isTwoLayers(imageNameList)!=-1)
            {
                List<PictureBoxInfo> oneImageNameList = new List<PictureBoxInfo>();
                List<PictureBoxInfo> twoImageNameList = new List<PictureBoxInfo>();
                for (int i = 0, len = imageNameList.Count; i < len; i++)
                {
                    if (i == 0)
                    {

                        if (imageNameList.ElementAt(i).name.Equals("HRA"))
                        {
                            //这里的virtralPictrueBox和realPictureBox中设置的Y坐标只是为后面onelist和twolist判断是其作用，其他没什么实质作用
                            PictureBoxInfo virtualPictureBox = new PictureBoxInfo();
                            virtualPictureBox.name = "virtualHRA";
                            //主要为了记录虚拟的框的坐标，为了画dxf是提供依据
                            //virtualPictureBox.DLocation = new DLocation(imageNameList.ElementAt(i).DLocation.X, imageNameList.ElementAt(i).DLocation.Y + 113 + 4, imageNameList.ElementAt(i).DLocation.Z);
                            virtualPictureBox.DLocation = new DLocation(imageNameList.ElementAt(i).DLocation.X, imageNameList.ElementAt(i).DLocation.Y, imageNameList.ElementAt(i).DLocation.Z);
                            oneImageNameList.Add(virtualPictureBox);
                            PictureBoxInfo realPictureBox = new PictureBoxInfo();
                            realPictureBox.name = imageNameList.ElementAt(i).name;
                            realPictureBox.DLocation = new DLocation(imageNameList.ElementAt(i).DLocation.X, imageNameList.ElementAt(i).DLocation.Y + 113 + 4, imageNameList.ElementAt(i).DLocation.Z);
                            twoImageNameList.Add(realPictureBox);
                        }
                        else
                        {
                            oneImageNameList.Add(imageNameList.ElementAt(i));
                        }
                    }
                    else
                    {
                        if (oneImageNameList.ElementAt(0).DLocation.Y == imageNameList.ElementAt(i).DLocation.Y)
                        {

                            if (imageNameList.ElementAt(i).name.Equals("HRA"))
                            {
                                PictureBoxInfo virtualPictureBox = new PictureBoxInfo();
                                virtualPictureBox.name = "virtualHRA";
                                virtualPictureBox.DLocation = new DLocation(imageNameList.ElementAt(i).DLocation.X, imageNameList.ElementAt(i).DLocation.Y + 113 + 4, imageNameList.ElementAt(i).DLocation.Z);
                                oneImageNameList.Add(virtualPictureBox);
                                twoImageNameList.Add(imageNameList.ElementAt(i));
                            }
                            else
                            {
                                oneImageNameList.Add(imageNameList.ElementAt(i));
                            }
                        }
                        else
                        {
                            if (imageNameList.ElementAt(i).name.Equals("HRA"))
                            {
                                PictureBoxInfo virtualPictureBox = new PictureBoxInfo();
                                virtualPictureBox.name = "virtualHRA";
                                virtualPictureBox.DLocation = new DLocation(imageNameList.ElementAt(i).DLocation.X, imageNameList.ElementAt(i).DLocation.Y + 113 + 4, imageNameList.ElementAt(i).DLocation.Z);
                                twoImageNameList.Add(virtualPictureBox);
                                oneImageNameList.Add(imageNameList.ElementAt(i));
                            }
                            else
                            {
                                twoImageNameList.Add(imageNameList.ElementAt(i));
                            }
                        }
                    }
                }
                if (oneImageNameList.Count > twoImageNameList.Count)
                {
                    assembleTopView(oneImageNameList, dxf, DLocation, tvc.DxfText, tvc.height, tvc.width, tvc.outer_mid_space, tvc.outer_in_space, tvc.barHeight, tvc.barWidth);
                }
                else
                {
                    assembleTopView(twoImageNameList, dxf, DLocation, tvc.DxfText, tvc.height, tvc.width, tvc.outer_mid_space, tvc.outer_in_space, tvc.barHeight, tvc.barWidth);
                }
            }
            else
            {
                assembleTopView(imageNameList, dxf, DLocation, tvc.DxfText, tvc.height, tvc.width, tvc.outer_mid_space, tvc.outer_in_space, tvc.barHeight, tvc.barWidth);
            }
        }
    }
}
//=======
//﻿using System;
//using System.Collections.Generic;
//using System.Linq;
//using Model.Zutu;
//using WW.Cad.Model;

//namespace CadLib.OperatorEntity
//{
//    public class AssembleTopView
//    {

//        public static void assembleTopView(List<PictureBoxInfo> imageNameList, DxfModel dxf, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space, double barHeight, double barWidth)
//        {

//            List<DLocation> storeDLocationList = new List<DLocation>();
//            for (int i = 0; i < imageNameList.Count; i++)
//            {
//                string imageName = imageNameList.ElementAt(i).name;
//                if (imageName.Equals("FTA") || imageName.Equals("FTC") || imageName.Equals("FTF") || imageName.Equals("FTH"))
//                {
//                    if (i == 0)
//                    {
//                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
//                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentDLocation.Y, currentDLocation.Z));
//                    }
//                }
//                else if (imageName.Equals("MBA") || imageName.Equals("MBB") || imageName.Equals("MBC") || imageName.Equals("MBD") || imageName.Equals("MBE") || imageName.Equals("MBF") || imageName.Equals("MBG") || imageName.Equals("MBH") || imageName.Equals("MBI") || imageName.Equals("MBJ") || imageName.Equals("MBK"))
//                {
//                    if (i == 0)
//                    {
//                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i); ;
//                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvDoubleHeight, DoorInitHeightAndWidth.tvDoubleWidth, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvDoubleWidth, currentDLocation.Y, currentDLocation.Z));
//                    }
//                }
//                else if (imageName.Equals("PHA") || imageName.Equals("PHB") || imageName.Equals("PHC") || imageName.Equals("PHD"))
//                {
//                    if (i == 0)
//                    {
//                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i); ;
//                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvDoubleDoorHeigt, DoorInitHeightAndWidth.tvDoubleDoorWidth, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvDoubleDoorWidth, currentDLocation.Y, currentDLocation.Z));
//                    }
//                }
//                else if (imageName.Equals("HRA"))
//                {
//                    if (i == 0)
//                    {
//                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
//                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentDLocation.Y, currentDLocation.Z));
//                    }
//                }
//                else if (imageName.Equals("virtualHRA"))
//                {
//                    if (i == 0)
//                    {
//                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
//                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentDLocation.Y, currentDLocation.Z));
//                    }
//                }
//                else if (imageName.Equals("CLB") || imageName.Equals("CLC") || imageName.Equals("CLF") || imageName.Equals("CLG") || imageName.Equals("CLI") || imageName.Equals("CLM"))
//                {
//                    if (i == 0)
//                    {
//                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
//                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentDLocation.Y, currentDLocation.Z));
//                    }
//                }
//                else if (imageName.Equals("PEA") || imageName.Equals("PEC") || imageName.Equals("RFA") || imageName.Equals("SFA") || imageName.Equals("SFC") || imageName.Equals("SFD"))
//                {
//                    if (i == 0)
//                    {
//                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
//                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentDLocation.Y, currentDLocation.Z));
//                    }
//                }
//                else if (imageName.Equals("BBA") || imageName.Equals("BBB") || imageName.Equals("BBC") || imageName.Equals("BBD") || imageName.Equals("BBE"))
//                {
//                    if (i == 0)
//                    {
//                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
//                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentDLocation.Y, currentDLocation.Z));
//                    }
//                }
//                else if (imageName.Equals("TRA") || imageName.Equals("TRB") || imageName.Equals("TRC") || imageName.Equals("TRD") || imageName.Equals("TRE"))
//                {
//                    if (i == 0)
//                    {
//                        DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
//                        DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentDLocation.Y, currentDLocation.Z));
//                    }
//                }
//            }

//            //画标注
//            DLocation firstDLocation = storeDLocationList.ElementAt(0);
//            DoorRectangle.writeDimension(dxf, new DLocation(firstDLocation.X, firstDLocation.Y - outer_in_space, firstDLocation.Z), firstDLocation, 16f, 1f, 5, "left");
//            DoorRectangle.writeDimension(dxf, firstDLocation, new DLocation(firstDLocation.X, firstDLocation.Y + 5, firstDLocation.Z), 16f, 1f, 5, "left");
//            DoorRectangle.writeDimension(dxf, new DLocation(firstDLocation.X, firstDLocation.Y + 5, firstDLocation.Z), new DLocation(firstDLocation.X, firstDLocation.Y + 45, firstDLocation.Z), 16f, 1f, 8, "left");

//            //top
//            DLocation lastDLocation = storeDLocationList.ElementAt(storeDLocationList.Count - 1);
//            DoorRectangle.writeDimension(dxf, new DLocation(firstDLocation.X, firstDLocation.Y + height, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y + height, firstDLocation.Z), 16f, 1f, 10, "top");

//            //right
//            DoorRectangle.writeDimension(dxf, new DLocation(lastDLocation.X, lastDLocation.Y + 10, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y + 40, firstDLocation.Z), 16f, 1f, 5f, "right");
//            DoorRectangle.writeDimension(dxf, new DLocation(lastDLocation.X, lastDLocation.Y, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y + 10, firstDLocation.Z), 16f, 1f, 5f, "right");
//            DoorRectangle.writeDimension(dxf, new DLocation(lastDLocation.X, lastDLocation.Y, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y + height, firstDLocation.Z), 16f, 1f, 10f, "right");
//            DoorRectangle.writeDimension(dxf, new DLocation(lastDLocation.X, lastDLocation.Y - 6, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y, firstDLocation.Z), 16f, 1f, 10f, "right");
//            DoorRectangle.writeDimension(dxf, new DLocation(lastDLocation.X, lastDLocation.Y - 6, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y + height + outer_in_space, firstDLocation.Z), 16f, 1f, 14f, "right");
//        }

//        public static void assembleTopView(List<PictureBoxInfo> imageNameList, DxfModel dxf, DLocation DLocation, TopViewConfigure tvc)
//        {
//            if (AssembleDetailMechine.isTwoLayers(imageNameList))
//            {
//                List<PictureBoxInfo> oneImageNameList = new List<PictureBoxInfo>();
//                List<PictureBoxInfo> twoImageNameList = new List<PictureBoxInfo>();
//                for (int i = 0, len = imageNameList.Count; i < len; i++)
//                {
//                    if (i == 0)
//                    {

//                        if (imageNameList.ElementAt(i).name.Equals("HRA"))
//                        {
//                            //这里的virtralPictrueBox和realPictureBox中设置的Y坐标只是为后面onelist和twolist判断是其作用，其他没什么实质作用
//                            PictureBoxInfo virtualPictureBox = new PictureBoxInfo();
//                            virtualPictureBox.name = "virtualHRA";
//                            //主要为了记录虚拟的框的坐标，为了画dxf是提供依据
//                            //virtualPictureBox.DLocation = new DLocation(imageNameList.ElementAt(i).DLocation.X, imageNameList.ElementAt(i).DLocation.Y + 113 + 4, imageNameList.ElementAt(i).DLocation.Z);
//                            virtualPictureBox.DLocation = new DLocation(imageNameList.ElementAt(i).DLocation.X, imageNameList.ElementAt(i).DLocation.Y, imageNameList.ElementAt(i).DLocation.Z);
//                            oneImageNameList.Add(virtualPictureBox);
//                            PictureBoxInfo realPictureBox = new PictureBoxInfo();
//                            realPictureBox.name = imageNameList.ElementAt(i).name;
//                            realPictureBox.DLocation = new DLocation(imageNameList.ElementAt(i).DLocation.X, imageNameList.ElementAt(i).DLocation.Y + 113 + 4, imageNameList.ElementAt(i).DLocation.Z);
//                            twoImageNameList.Add(realPictureBox);
//                        }
//                        else
//                        {
//                            oneImageNameList.Add(imageNameList.ElementAt(i));
//                        }
//                    }
//                    else
//                    {
//                        if (oneImageNameList.ElementAt(0).DLocation.Y == imageNameList.ElementAt(i).DLocation.Y)
//                        {

//                            if (imageNameList.ElementAt(i).name.Equals("HRA"))
//                            {
//                                PictureBoxInfo virtualPictureBox = new PictureBoxInfo();
//                                virtualPictureBox.name = "virtualHRA";
//                                virtualPictureBox.DLocation = new DLocation(imageNameList.ElementAt(i).DLocation.X, imageNameList.ElementAt(i).DLocation.Y + 113 + 4, imageNameList.ElementAt(i).DLocation.Z);
//                                oneImageNameList.Add(virtualPictureBox);
//                                twoImageNameList.Add(imageNameList.ElementAt(i));
//                            }
//                            else
//                            {
//                                oneImageNameList.Add(imageNameList.ElementAt(i));
//                            }
//                        }
//                        else
//                        {
//                            if (imageNameList.ElementAt(i).name.Equals("HRA"))
//                            {
//                                PictureBoxInfo virtualPictureBox = new PictureBoxInfo();
//                                virtualPictureBox.name = "virtualHRA";
//                                virtualPictureBox.DLocation = new DLocation(imageNameList.ElementAt(i).DLocation.X, imageNameList.ElementAt(i).DLocation.Y + 113 + 4, imageNameList.ElementAt(i).DLocation.Z);
//                                twoImageNameList.Add(virtualPictureBox);
//                                oneImageNameList.Add(imageNameList.ElementAt(i));
//                            }
//                            else
//                            {
//                                twoImageNameList.Add(imageNameList.ElementAt(i));
//                            }
//                        }
//                    }
//                }
//                if (oneImageNameList.Count > twoImageNameList.Count)
//                {
//                    assembleTopView(oneImageNameList, dxf, DLocation, tvc.DxfText, tvc.height, tvc.width, tvc.outer_mid_space, tvc.outer_in_space, tvc.barHeight, tvc.barWidth);
//                }
//                else
//                {
//                    assembleTopView(twoImageNameList, dxf, DLocation, tvc.DxfText, tvc.height, tvc.width, tvc.outer_mid_space, tvc.outer_in_space, tvc.barHeight, tvc.barWidth);
//                }
//            }
//            else
//            {
//                assembleTopView(imageNameList, dxf, DLocation, tvc.DxfText, tvc.height, tvc.width, tvc.outer_mid_space, tvc.outer_in_space, tvc.barHeight, tvc.barWidth);
//            }
//        }
//    }
//}
//>>>>>>> .r46
