
﻿using System;
using System.Collections.Generic;
using System.Linq;
using Model.Zutu;
using WW.Cad.Model;

namespace CadLib.OperatorEntity
{
    public class AssembleTopView
    {

        public static void assembleTopView(List<PictureBoxInfo> imageNameList, DxfModel dxf, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space, double barHeight, double barWidth,int upFirstElement=-1)
        {

            List<DLocation> storeDLocationList = new List<DLocation>();
            for (int i = 0; i < imageNameList.Count; i++)
            {
                string imageName = imageNameList.ElementAt(i).name;
                int coolingType=imageNameList.ElementAt(i).coolingType;
                height = imageNameList.ElementAt(i).topViewHeight;
                width = imageNameList.ElementAt(i).width;
                if (upFirstElement == -1)
                {
                    if (imageName.Equals("FTA") || imageName.Equals("FTC") || imageName.Equals("FTF") || imageName.Equals("FTH")||imageName.Equals("FTE"))
                    {
                        if (i == 0)
                        {
                            DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                            storeDLocationList.Add(DLocation);

                        }
                        else
                        {
                            DLocation currentDLocation = storeDLocationList.ElementAt(i);
                            DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, height, width, outer_mid_space, outer_in_space);

                        }
                    }
                    else if (imageName.Equals("MBA") || imageName.Equals("MBB") || imageName.Equals("MBC") || imageName.Equals("MBD") || imageName.Equals("MBE") || imageName.Equals("MBF") || imageName.Equals("MBG") || imageName.Equals("MBH") || imageName.Equals("MBI") || imageName.Equals("MBJ") || imageName.Equals("MBK"))
                    {
                        if (i == 0)
                        {
                            DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                            storeDLocationList.Add(DLocation);

                        }
                        else
                        {
                            DLocation currentDLocation = storeDLocationList.ElementAt(i); ;
                            DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, height, width, outer_mid_space, outer_in_space);

                        }
                    }
                    else if (imageName.Equals("PHA") || imageName.Equals("PHB") || imageName.Equals("PHC") || imageName.Equals("PHD"))
                    {
                        if (i == 0)
                        {
                            DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                            storeDLocationList.Add(DLocation);

                        }
                        else
                        {
                            DLocation currentDLocation = storeDLocationList.ElementAt(i); ;
                            DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, height, width, outer_mid_space, outer_in_space);

                        }
                    }
                    else if (imageName.Equals("HRA"))
                    {
                        if (i == 0)
                        {
                            DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                            storeDLocationList.Add(DLocation);

                        }
                        else
                        {
                            DLocation currentDLocation = storeDLocationList.ElementAt(i);
                            DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, height, width, outer_mid_space, outer_in_space);

                        }
                    }
                    else if (imageName.Equals("virtualHRA"))
                    {
                        if (i == 0)
                        {
                            DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                            storeDLocationList.Add(DLocation);

                        }
                        else
                        {
                            DLocation currentDLocation = storeDLocationList.ElementAt(i);
                            DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, height, width, outer_mid_space, outer_in_space);

                        }
                    }
                    else if (imageName.Equals("CLB") || imageName.Equals("CLC") || imageName.Equals("CLF") || imageName.Equals("CLG") || imageName.Equals("CLI") || imageName.Equals("CLM"))
                    {
                        if (i == 0)
                        {
                            DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                            storeDLocationList.Add(DLocation);

                        }
                        else
                        {
                            DLocation currentDLocation = storeDLocationList.ElementAt(i);
                            DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, height, width, outer_mid_space, outer_in_space);

                        }
                    }
                    else if (imageName.Equals("PEA") || imageName.Equals("PEC") || imageName.Equals("RFA") || imageName.Equals("SFA") || imageName.Equals("SFC") || imageName.Equals("SFD") || imageName.Equals("SDB") || imageName.Equals("SDD") || imageName.Equals("EDB") || imageName.Equals("RDB"))
                    {
                        if (i == 0)
                        {
                            DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                            storeDLocationList.Add(DLocation);

                        }
                        else
                        {
                            DLocation currentDLocation = storeDLocationList.ElementAt(i);
                            DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, height, width, outer_mid_space, outer_in_space);

                            //俯视图封口向上时
                            if (i ==imageNameList.Count-1)
                            {
                                if (imageName.Equals("SFC") || imageName.Equals("SDD"))
                                {
                                   List<AirFlowUpDimension> airFlowList=AirFlowUpDimensionConfigure.getAirFlowList();
                                   AirFlowUpDimension currentAirFlowDimension = new AirFlowUpDimension();
                                   foreach (var airFlowDimension in airFlowList)
                                   {
                                       if (coolingType.Equals(airFlowDimension.coolingType) && imageName.Equals(airFlowDimension.imageName))
                                       {
                                           currentAirFlowDimension = airFlowDimension;
                                           DLocation airFlowDLocation=new DLocation(currentDLocation.X+currentAirFlowDimension.topLeftDimension,currentDLocation.Y+currentAirFlowDimension.rightDownDimension,currentDLocation.Z);
                                           DoorRectangle.writeOuterDoorRectangle(dxf,airFlowDLocation,currentAirFlowDimension.rightUpDimension,currentAirFlowDimension.topRightDimension);
                                           //画标注上边
                                           DoorRectangle.writeDimension(dxf, new DLocation(currentDLocation.X, currentDLocation.Y + currentAirFlowDimension.rightUpDimension + currentAirFlowDimension.rightDownDimension, currentDLocation.Z), new DLocation(currentDLocation.X + airFlowDimension.topLeftDimension, currentDLocation.Y + airFlowDimension.rightDownDimension+airFlowDimension.rightUpDimension, currentDLocation.Z), 16f, 1f, 5, "top");
                                           DoorRectangle.writeDimension(dxf, new DLocation(currentDLocation.X + airFlowDimension.topLeftDimension, currentDLocation.Y + airFlowDimension.rightDownDimension + airFlowDimension.rightUpDimension, currentDLocation.Z), new DLocation(currentDLocation.X + airFlowDimension.topLeftDimension+airFlowDimension.topRightDimension, currentDLocation.Y + airFlowDimension.rightDownDimension + airFlowDimension.rightUpDimension, currentDLocation.Z), 16f, 1f, 5, "top");
                                           //画右边标注
                                           DoorRectangle.writeDimension(dxf, new DLocation(currentDLocation.X + airFlowDimension.topLeftDimension+airFlowDimension.topRightDimension, currentDLocation.Y, currentDLocation.Z), new DLocation(currentDLocation.X + airFlowDimension.topLeftDimension + airFlowDimension.topRightDimension, currentDLocation.Y + airFlowDimension.rightDownDimension, currentDLocation.Z), 16f, 1f, 3, "right");
                                           DoorRectangle.writeDimension(dxf, new DLocation(currentDLocation.X + airFlowDimension.topLeftDimension + airFlowDimension.topRightDimension, currentDLocation.Y+airFlowDimension.rightDownDimension, currentDLocation.Z), new DLocation(currentDLocation.X + airFlowDimension.topLeftDimension + airFlowDimension.topRightDimension, currentDLocation.Y + airFlowDimension.rightDownDimension+airFlowDimension.rightUpDimension, currentDLocation.Z), 16f, 1f, 3, "right");
                                           continue;
                                       }
                                   }
                                }
                            }

                        }
                    }
                    else if (imageName.Equals("BBA") || imageName.Equals("BBB") || imageName.Equals("BBC") || imageName.Equals("BBD") || imageName.Equals("BBE") || imageName.Equals("BBF"))
                    {
                        if (i == 0)
                        {
                            DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                            storeDLocationList.Add(DLocation);

                        }
                        else
                        {
                            DLocation currentDLocation = storeDLocationList.ElementAt(i);
                            DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, height, width, outer_mid_space, outer_in_space);

                        }
                    }
                    else if (imageName.Equals("TRA") || imageName.Equals("TRB") || imageName.Equals("TRC") || imageName.Equals("TRD") || imageName.Equals("TRE") || imageName.Equals("TRF"))
                    {
                        if (i == 0)
                        {
                            DoorRectangle.writeTopViewRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                            storeDLocationList.Add(DLocation);

                        }
                        else
                        {
                            DLocation currentDLocation = storeDLocationList.ElementAt(i);
                            DoorRectangle.writeTopViewRectangle(dxf, currentDLocation, DxfText, height, width, outer_mid_space, outer_in_space);

                        }
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeOuterDoorRectangle(dxf, DLocation, height, width);
                        storeDLocationList.Add(DLocation);
                        //处理向上的风口问题
                        if (imageName.Equals("PEC") || imageName.Equals("EDD"))
                        {
                            List<AirFlowUpDimension> airFlowList = AirFlowUpDimensionConfigure.getAirFlowList();
                            AirFlowUpDimension currentAirFlowDimension = new AirFlowUpDimension();
                            foreach (var airFlowDimension in airFlowList)
                            {
                                if (coolingType.Equals(airFlowDimension.coolingType) && imageName.Equals(airFlowDimension.imageName))
                                {
                                    currentAirFlowDimension = airFlowDimension;
                                    DLocation airFlowDLocation = new DLocation(DLocation.X + currentAirFlowDimension.topLeftDimension, DLocation.Y + currentAirFlowDimension.rightDownDimension, DLocation.Z);
                                    DoorRectangle.writeOuterDoorRectangle(dxf, airFlowDLocation, currentAirFlowDimension.rightUpDimension, currentAirFlowDimension.topRightDimension);
                                    //画标注上边
                                    DoorRectangle.writeDimension(dxf, new DLocation(DLocation.X, DLocation.Y + currentAirFlowDimension.rightUpDimension + currentAirFlowDimension.rightDownDimension, DLocation.Z), new DLocation(DLocation.X + airFlowDimension.topLeftDimension, DLocation.Y + airFlowDimension.rightDownDimension + airFlowDimension.rightUpDimension, DLocation.Z), 16f, 1f, 5, "top");
                                    DoorRectangle.writeDimension(dxf, new DLocation(DLocation.X + airFlowDimension.topLeftDimension, DLocation.Y + airFlowDimension.rightDownDimension + airFlowDimension.rightUpDimension, DLocation.Z), new DLocation(DLocation.X + airFlowDimension.topLeftDimension + airFlowDimension.topRightDimension, DLocation.Y + airFlowDimension.rightDownDimension + airFlowDimension.rightUpDimension, DLocation.Z), 16f, 1f, 5, "top");
                                    //画右边标注
                                    DoorRectangle.writeDimension(dxf, new DLocation(DLocation.X + airFlowDimension.topLeftDimension + airFlowDimension.topRightDimension, DLocation.Y, DLocation.Z), new DLocation(DLocation.X + airFlowDimension.topLeftDimension + airFlowDimension.topRightDimension, DLocation.Y + airFlowDimension.rightDownDimension, DLocation.Z), 16f, 1f, 3, "right");
                                    DoorRectangle.writeDimension(dxf, new DLocation(DLocation.X + airFlowDimension.topLeftDimension + airFlowDimension.topRightDimension, DLocation.Y + airFlowDimension.rightDownDimension, DLocation.Z), new DLocation(DLocation.X + airFlowDimension.topLeftDimension + airFlowDimension.topRightDimension, DLocation.Y + airFlowDimension.rightDownDimension + airFlowDimension.rightUpDimension, DLocation.Z), 16f, 1f, 3, "right");
                                    continue;
                                }
                            }
                        }

                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
                        DoorRectangle.writeOuterDoorRectangle(dxf, currentDLocation, height, width);

                    }
                    
                }
                storeDLocationList.Add(new DLocation(storeDLocationList.ElementAt(i).X + width, storeDLocationList.ElementAt(i).Y, storeDLocationList.ElementAt(i).Z));
                
            }
            //第一层
            if (upFirstElement == -1)
            {
                //画标注
                PictureBoxInfo firstPictureInfo = imageNameList.ElementAt(0);
                DLocation firstDLocation = storeDLocationList.ElementAt(0);
                DoorRectangle.writeDimension(dxf, new DLocation(firstDLocation.X, firstDLocation.Y - outer_in_space, firstDLocation.Z), firstDLocation, 16f, 1f, 5, "left");
                DoorRectangle.writeDimension(dxf, firstDLocation, new DLocation(firstDLocation.X, firstDLocation.Y + firstPictureInfo.topViewFirstDistance, firstDLocation.Z), 16f, 1f, 8, "left");
                DoorRectangle.writeDimension(dxf, new DLocation(firstDLocation.X, firstDLocation.Y + firstPictureInfo.topViewFirstDistance, firstDLocation.Z), new DLocation(firstDLocation.X, firstDLocation.Y + firstPictureInfo.topViewSecondDistance, firstDLocation.Z), 16f, 1f, 8, "left");

                //top
                DLocation lastDLocation = storeDLocationList.ElementAt(storeDLocationList.Count - 1);
                DoorRectangle.writeDimension(dxf, new DLocation(firstDLocation.X, firstDLocation.Y + height, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y + height, firstDLocation.Z), 16f, 1f, 10, "top");

                //right
                PictureBoxInfo lastPictureInfo = imageNameList.ElementAt(imageNameList.Count - 1);
                DoorRectangle.writeDimension(dxf, new DLocation(lastDLocation.X, lastDLocation.Y + lastPictureInfo.topViewFirstDistance, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y + lastPictureInfo.topViewSecondDistance, firstDLocation.Z), 16f, 1f, 5f, "right");
                DoorRectangle.writeDimension(dxf, new DLocation(lastDLocation.X, lastDLocation.Y, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y + lastPictureInfo.topViewFirstDistance, firstDLocation.Z), 16f, 1f, 5f, "right");
                DoorRectangle.writeDimension(dxf, new DLocation(lastDLocation.X, lastDLocation.Y, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y + height, firstDLocation.Z), 16f, 1f, 10f, "right");
                DoorRectangle.writeDimension(dxf, new DLocation(lastDLocation.X, lastDLocation.Y - BaseRail.baseRail, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y, firstDLocation.Z), 16f, 1f, 10f, "right");
                DoorRectangle.writeDimension(dxf, new DLocation(lastDLocation.X, lastDLocation.Y - BaseRail.baseRail, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y + height + outer_in_space, firstDLocation.Z), 16f, 1f, 14f, "right");
            }
            //第二层
            else
            {
                //画标注
                PictureBoxInfo firstPictureInfo = imageNameList.ElementAt(0);
                DLocation firstDLocation = storeDLocationList.ElementAt(0);
                DoorRectangle.writeDimension(dxf, firstDLocation, new DLocation(firstDLocation.X, firstDLocation.Y + firstPictureInfo.topViewFirstDistance, firstDLocation.Z), 16f, 1f, 8, "left");
                DoorRectangle.writeDimension(dxf, new DLocation(firstDLocation.X, firstDLocation.Y + firstPictureInfo.topViewFirstDistance, firstDLocation.Z), new DLocation(firstDLocation.X, firstDLocation.Y + firstPictureInfo.topViewSecondDistance, firstDLocation.Z), 16f, 1f, 8, "left");

                //right
                DLocation lastDLocation = storeDLocationList.ElementAt(storeDLocationList.Count - 1);
                PictureBoxInfo lastPictureInfo = imageNameList.ElementAt(imageNameList.Count - 1);
                DoorRectangle.writeDimension(dxf, new DLocation(lastDLocation.X, lastDLocation.Y + lastPictureInfo.topViewFirstDistance, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y + lastPictureInfo.topViewSecondDistance, firstDLocation.Z), 16f, 1f, 5f, "right");
                DoorRectangle.writeDimension(dxf, new DLocation(lastDLocation.X, lastDLocation.Y, firstDLocation.Z), new DLocation(lastDLocation.X, lastDLocation.Y + lastPictureInfo.topViewFirstDistance, firstDLocation.Z), 16f, 1f, 5f, "right");
            }
           
        }

        public static void assembleTopView(List<PictureBoxInfo> imageNameList, DxfModel dxf, DLocation DLocation, TopViewConfigure tvc)
        {
            int upFirstElement = AssembleDetailMechine.isTwoLayers(imageNameList);
            if (upFirstElement!= -1)
            {
                List<PictureBoxInfo> oneImageNameList = new List<PictureBoxInfo>();
                List<PictureBoxInfo> twoImageNameList = new List<PictureBoxInfo>();
                for (int i = 0, len = imageNameList.Count; i < len; i++)
                {
                    if (i == 0)
                    {

                        //if (imageNameList.ElementAt(i).name.Equals("HRA"))
                        //{
                        //    //这里的virtralPictrueBox和realPictureBox中设置的Y坐标只是为后面onelist和twolist判断是其作用，其他没什么实质作用
                        //    PictureBoxInfo virtualPictureBox = new PictureBoxInfo();
                        //    virtualPictureBox.name = "virtualHRA";
                        //    //主要为了记录虚拟的框的坐标，为了画dxf是提供依据
                        //    //virtualPictureBox.DLocation = new DLocation(imageNameList.ElementAt(i).DLocation.X, imageNameList.ElementAt(i).DLocation.Y + 113 + 4, imageNameList.ElementAt(i).DLocation.Z);
                        //    virtualPictureBox.DLocation = new DLocation(imageNameList.ElementAt(i).DLocation.X, imageNameList.ElementAt(i).DLocation.Y, imageNameList.ElementAt(i).DLocation.Z);
                        //    oneImageNameList.Add(virtualPictureBox);
                        //    PictureBoxInfo realPictureBox = new PictureBoxInfo();
                        //    realPictureBox.name = imageNameList.ElementAt(i).name;
                        //    realPictureBox.DLocation = new DLocation(imageNameList.ElementAt(i).DLocation.X, imageNameList.ElementAt(i).DLocation.Y + 113 + 4, imageNameList.ElementAt(i).DLocation.Z);
                        //    twoImageNameList.Add(realPictureBox);
                        //}
                        //else
                        //{
                            oneImageNameList.Add(imageNameList.ElementAt(i));
                        //}
                    }
                    else
                    {
                        if (oneImageNameList.ElementAt(0).DLocation.Y == imageNameList.ElementAt(i).DLocation.Y)
                        {

                            //if (imageNameList.ElementAt(i).name.Equals("HRA"))
                            //{
                            //    PictureBoxInfo virtualPictureBox = new PictureBoxInfo();
                            //    virtualPictureBox.name = "virtualHRA";
                            //    virtualPictureBox.DLocation = new DLocation(imageNameList.ElementAt(i).DLocation.X, imageNameList.ElementAt(i).DLocation.Y + 113 + 4, imageNameList.ElementAt(i).DLocation.Z);                       
                            //    oneImageNameList.Add(virtualPictureBox);
                            //    twoImageNameList.Add(imageNameList.ElementAt(i));
                            //}
                            //else
                            //{
                                oneImageNameList.Add(imageNameList.ElementAt(i));
                            //}
                        }
                        else
                        {
                            //if (imageNameList.ElementAt(i).name.Equals("HRA"))
                            //{
                            //    PictureBoxInfo virtualPictureBox = new PictureBoxInfo();
                            //    virtualPictureBox.name = "virtualHRA";
                            //    virtualPictureBox.DLocation = new DLocation(imageNameList.ElementAt(i).DLocation.X, imageNameList.ElementAt(i).DLocation.Y + 113 + 4, imageNameList.ElementAt(i).DLocation.Z);
                            //    twoImageNameList.Add(virtualPictureBox);
                            //    oneImageNameList.Add(imageNameList.ElementAt(i));
                            //}
                            //else
                            //{
                                twoImageNameList.Add(imageNameList.ElementAt(i));
                            //}
                        }
                    }
                }
                if (oneImageNameList.ElementAt(0).DLocation.Y> twoImageNameList.ElementAt(0).DLocation.Y)
                {
                    //第一层
                    assembleTopView(oneImageNameList, dxf, DLocation, tvc.DxfText, tvc.height, tvc.width, tvc.outer_mid_space, tvc.outer_in_space, tvc.barHeight, tvc.barWidth,-1);
                    //DLocation为oneImageNamelist第一个元素的坐标
                    assembleTopView(twoImageNameList, dxf,new DLocation(twoImageNameList.ElementAt(0).DLocation.X,DLocation.Y,DLocation.Z), tvc.DxfText, tvc.height, tvc.width, tvc.outer_mid_space, tvc.outer_in_space, tvc.barHeight, tvc.barWidth,upFirstElement);
                }
                else
                {
                    //第一层
                    assembleTopView(twoImageNameList, dxf, DLocation, tvc.DxfText, tvc.height, tvc.width, tvc.outer_mid_space, tvc.outer_in_space, tvc.barHeight, tvc.barWidth,-1);
                    
                    assembleTopView(oneImageNameList, dxf, DLocation, tvc.DxfText, tvc.height, tvc.width, tvc.outer_mid_space, tvc.outer_in_space, tvc.barHeight, tvc.barWidth, upFirstElement);
                }
            }
            else
            {
                assembleTopView(imageNameList, dxf, DLocation, tvc.DxfText, tvc.height, tvc.width, tvc.outer_mid_space, tvc.outer_in_space, tvc.barHeight, tvc.barWidth);
            }
        }

        //将第二层的Y只设置为和第一层相同
        public static List<PictureBoxInfo> setSecondLayerY(List<PictureBoxInfo> secondLayerList,double firstLayerY)
        {
            for (int i = 0; i < secondLayerList.Count; i++)
            {
                secondLayerList.ElementAt(i).DLocation.Y = firstLayerY;
            }
            return secondLayerList;
        }
    }
}
