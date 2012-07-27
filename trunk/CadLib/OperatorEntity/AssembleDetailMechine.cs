
﻿using System;
using System.Collections.Generic;
using System.Linq;
using Model.Zutu;
using WW.Cad.Model;
namespace CadLib.OperatorEntity
{
  public  class AssembleDetailMechine
    {
       private static List<DLocation> storeDLocationList=new List<DLocation>();
       public static void assembleDetailMechine(PictureBoxInfo pictureBoxInfo, DxfModel dxf, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space, double barHeight, double barWidth, string upOrDownLayer="downUpLayer")
        {
            string imageName = pictureBoxInfo.name;
                        
                if (imageName.Equals("FTA") || imageName.Equals("FTC") || imageName.Equals("FTF") || imageName.Equals("FTH"))
                {
                   // DoorRectangle.writeRighStand(dxf, DLocation, 6 , 3, outer_in_space/21);
                    DoorRectangle.writeWholeSingleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);     

                }
                else if(imageName.Equals("MBA")||imageName.Equals("MBD")||imageName.Equals("MBG"))
                {

                    DoorRectangle.writeLeftFasnSingleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                                         
                }
                else if (imageName.Equals("MBE") || imageName.Equals("MBB"))
                {
                    DoorRectangle.writeTopFanSingleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                }
                else if (imageName.Equals("MBH") || imageName.Equals("MBJ"))
                {
                    DoorRectangle.writeTopLeftFasnSingleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                }
                else if (imageName.Equals("MBF") || imageName.Equals("MBI"))
                {
                    DoorRectangle.writeBottoFanSingleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                }
                else if (imageName.Equals("MBC") || imageName.Equals("MBK"))
                {
                    DoorRectangle.writeLeftBottomFansSingleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                }
                else if (imageName.Equals("PHB"))
                {
                    DoorRectangle.writeWholeSingleDoorTwoCirle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);

                }
                else if (imageName.Equals("PHA"))
                {
                    DoorRectangle.writeDoorRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                }
                else if (imageName.Equals("PHC") || imageName.Equals("PHD"))
                {
                    DoorRectangle.writeWholeSingleTwoBarAndTwoCirle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
                }

                else if (imageName.Equals("HRA"))
                {

                    DoorRectangle.writeWholeSingleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);

                }
                else if (imageName.Equals("virtualHRA"))
                {

                }
                else if (imageName.Equals("CLC") || imageName.Equals("CLB") || imageName.Equals("CLM") || imageName.Equals("CLG") || imageName.Equals("CLI"))
                {
                    DoorRectangle.writeWholeSingleDoorTwoCirle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                }
                else if (imageName.Equals("CLF"))
                {
                    DoorRectangle.writeFourCircleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                }
                else if (imageName.Equals("SFA") || imageName.Equals("SFC"))
                {

                    DoorRectangle.writeWholeDoorFourHandle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);

                }
                else if (imageName.Equals("PEA") || imageName.Equals("PEC") || imageName.Equals("RFA"))
                {
                    DoorRectangle.writeWholeSingleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                }
                else if (imageName.Equals("SFD"))
                {
                    DoorRectangle.writeWholeSingleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                }
                else if (imageName.Equals("BBA") || imageName.Equals("BBB") || imageName.Equals("BBC") || imageName.Equals("BBD") || imageName.Equals("BBE"))
                {

                    DoorRectangle.writeDoorRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);


                }
                else if (imageName.Equals("TRA") || imageName.Equals("TRB") || imageName.Equals("TRC") || imageName.Equals("TRD") || imageName.Equals("TRE"))
                {
                    DoorRectangle.writeDoorRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
                }
        }
      //封装左边或右边一次画两个标注
        public static void writeLeftOrRightDimension(PictureBoxInfo pictureBoxInfo, DLocation DLocation, DxfModel dxf, string leftOrRight,double DxfTextHeight = 16, double DxfTextWidth = 3, double dimensionHeight = 8)
        {
            if (leftOrRight.Equals("right"))
            {
                DLocation secondDLocation = new DLocation(DLocation.X+pictureBoxInfo.width, DLocation.Y + pictureBoxInfo.firstDistance, DLocation.Z);
                DoorRectangle.writeDimension(dxf, new DLocation(DLocation.X+pictureBoxInfo.width,DLocation.Y,DLocation.Z), secondDLocation, DxfTextHeight, DxfTextWidth, dimensionHeight, leftOrRight);
                DoorRectangle.writeDimension(dxf, secondDLocation, new DLocation(secondDLocation.X, secondDLocation.Y + pictureBoxInfo.secondDistance, secondDLocation.Z), DxfTextHeight, DxfTextWidth, dimensionHeight, leftOrRight);                    
            }
            else if (leftOrRight.Equals("left"))
            {
                DLocation secondDLocation = new DLocation(DLocation.X, DLocation.Y + pictureBoxInfo.firstDistance, DLocation.Z);
                DoorRectangle.writeDimension(dxf, DLocation, secondDLocation, DxfTextHeight, DxfTextWidth, dimensionHeight, leftOrRight);
                DoorRectangle.writeDimension(dxf, secondDLocation, new DLocation(secondDLocation.X, secondDLocation.Y + pictureBoxInfo.secondDistance, secondDLocation.Z), DxfTextHeight, DxfTextWidth, dimensionHeight, leftOrRight);                    
            }              
        }
      //封装左右单一dimension
        public static void writeRightSecondDimension(DLocation  startDLocation, DLocation  secondDLocation, DxfModel dxf, string leftOrRight, double DxfTextHeight = 16, double DxfTextWidth = 3, double dimensionHeight = 8)
        {
            DoorRectangle.writeDimension(dxf, startDLocation, secondDLocation, DxfTextHeight, DxfTextWidth, dimensionHeight, leftOrRight);
        }

      //风中top或bottom的dimension
        public static void writeTopOrBottomDimension(PictureBoxInfo pictureBoxInfo, DxfModel dxf, string topOrBottom, double DxfTextHeight = 16, double DxfTextWidth = 3, double dimensionHeight = 8)
        {
            if (topOrBottom.Equals("top"))
            {
                DLocation secondDLocation = new DLocation(pictureBoxInfo.DLocation.X + pictureBoxInfo.width, pictureBoxInfo.DLocation.Y+pictureBoxInfo.height, pictureBoxInfo.DLocation.Z);
                DoorRectangle.writeDimension(dxf, new DLocation(pictureBoxInfo.DLocation.X,pictureBoxInfo.DLocation.Y+pictureBoxInfo.height,pictureBoxInfo.DLocation.Z), secondDLocation, DxfTextHeight, DxfTextWidth, dimensionHeight, topOrBottom);           
            }
            else if (topOrBottom.Equals("bottom"))
            {
                DLocation secondDLocation = new DLocation(pictureBoxInfo.DLocation.X + pictureBoxInfo.width, pictureBoxInfo.DLocation.Y, pictureBoxInfo.DLocation.Z);
                DoorRectangle.writeDimension(dxf, pictureBoxInfo.DLocation, secondDLocation, DxfTextHeight, DxfTextWidth, dimensionHeight, topOrBottom);           
            }
            
        }
        public static void writeTotalBottomDimension(PictureBoxInfo startpictureBoxInfo,int totalWidth,DxfModel dxf, string topOrBottom, double DxfTextHeight = 16, double DxfTextWidth = 3, double dimensionHeight = 8)
        {
            DLocation secondDLocation = new DLocation(startpictureBoxInfo.DLocation.X + totalWidth, startpictureBoxInfo.DLocation.Y, startpictureBoxInfo.DLocation.Z);
            DoorRectangle.writeDimension(dxf, startpictureBoxInfo.DLocation, secondDLocation, DxfTextHeight, DxfTextWidth, dimensionHeight, topOrBottom);
        }

      //封装中right的dimension
        public static void writeRightDimension(List<DLocation> storeDLocationList, DxfModel dxf, double height, string upOrDownRightDimension)
        {
            DLocation rightFirstDLocation = storeDLocationList.ElementAt(storeDLocationList.Count - 1);
            DoorRectangle.writeDimension(dxf, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y - 6, rightFirstDLocation.Z), rightFirstDLocation, 16, 3, 8, "right");
            DoorRectangle.writeDimension(dxf, rightFirstDLocation, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + 11, rightFirstDLocation.Z), 16, 3, 8, "right");
            DoorRectangle.writeDimension(dxf, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + 11, rightFirstDLocation.Z), new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + 33, rightFirstDLocation.Z), 16, 3, 8, "right");
            DoorRectangle.writeDimension(dxf, rightFirstDLocation, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + height, rightFirstDLocation.Z), 16, 3, 15, "right");
            DoorRectangle.writeDimension(dxf, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y - 6, rightFirstDLocation.Z), new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + height, rightFirstDLocation.Z), 16, 3, 23, "right");

        }

      //画底部支架
        public static void writeBottomStand(DxfModel dxf, DLocation DLocation, double height, double width, double outer_in_space,string leftOrRight)
        {
            if (leftOrRight.Equals("left"))
            {
                DoorRectangle.writeLeftStand(dxf, DLocation, height, width, outer_in_space);
            }
            else
            {
                DoorRectangle.writeRighStand(dxf, DLocation, height, width, outer_in_space);
            }
        }

      //画支架dimension
        public static void writeBottomStandDimension(DLocation startDLocation, DLocation secondDLocation, DxfModel dxf, string leftOrRight, double DxfTextHeight = 16, double DxfTextWidth = 3, double dimensionHeight = 8)
        {
            DoorRectangle.writeDimension(dxf, startDLocation, secondDLocation, DxfTextHeight, DxfTextWidth, dimensionHeight, leftOrRight);
        }

      //上下层组装和单层组装函数
        public static void assembleDetailMechine(List<PictureBoxInfo> imageNameList, DxfModel dxf, DLocation DLocation, DetailMechineConfigure dmc,int coolingType)
        {
            int firstLayerWidth = 0;
            int upFirstElement=isTwoLayers(imageNameList);
            if (upFirstElement!=-1)
            {
                if (isExistTwoLayerElement(imageNameList))
                {
                    for (int i = 0; i < imageNameList.Count; i++)
                    {
                        if(i>=upFirstElement)
                        {
                            if (imageNameList.ElementAt(i).name.Equals("HRA"))
                            {
                                PictureBoxInfo pictureBoxInfo = imageNameList.ElementAt(i);
                                //消除间隙，此时不存在双层元素
                                pictureBoxInfo.DLocation.Y += (pictureBoxInfo.height-2)/2+ 2;
                                assembleDetailMechine(pictureBoxInfo, dxf, pictureBoxInfo.DLocation,pictureBoxInfo.text, Convert.ToDouble(pictureBoxInfo.height), Convert.ToDouble(pictureBoxInfo.width), dmc.outer_mid_space, dmc.outer_in_space, dmc.barHeight, dmc.barWidth);
                            }
                            else
                            {

                                PictureBoxInfo pictureBoxInfo = imageNameList.ElementAt(i);
                                //消除间隙，此时不存在双层元素
                                pictureBoxInfo.DLocation.Y += pictureBoxInfo.height * 2 + 4;
                                
                                assembleDetailMechine(pictureBoxInfo, dxf, pictureBoxInfo.DLocation, pictureBoxInfo.text, Convert.ToDouble(pictureBoxInfo.height), Convert.ToDouble(pictureBoxInfo.width), dmc.outer_mid_space, dmc.outer_in_space, dmc.barHeight, dmc.barWidth);

                                //top层dimensiong
                                PictureBoxInfo topPictureBoxInfo = imageNameList.ElementAt(i);
                                writeTopOrBottomDimension(topPictureBoxInfo, dxf, "top", 16, 3, 8);
                            }
                        }
                        else
                        {
                            
                             PictureBoxInfo pictureBoxInfo = imageNameList.ElementAt(i);
                             //下层的总宽度
                             firstLayerWidth += pictureBoxInfo.width;
                             assembleDetailMechine(pictureBoxInfo, dxf, pictureBoxInfo.DLocation, pictureBoxInfo.text, Convert.ToDouble(pictureBoxInfo.height), Convert.ToDouble(pictureBoxInfo.width), dmc.outer_mid_space, dmc.outer_in_space, dmc.barHeight, dmc.barWidth);

                             //bottom
                             writeTopOrBottomDimension(pictureBoxInfo, dxf, "bottom");


                             DLocation standDLocation = imageNameList.ElementAt(i).DLocation;
                             if (i == 0)
                             {
                                 writeBottomStand(dxf, new DLocation(standDLocation.X, standDLocation.Y - 6, standDLocation.Z), 6, 2, dmc.outer_in_space / 26, "left");
                             }
                             else
                             {
                                 writeBottomStand(dxf, new DLocation(standDLocation.X - 2, standDLocation.Y - 6, standDLocation.Z), 6, 2, dmc.outer_in_space / 26, "left");
                                 writeBottomStand(dxf, new DLocation(standDLocation.X, standDLocation.Y - 6, standDLocation.Z), 6, 2, dmc.outer_in_space / 26, "right");

                             }
                        }   
                    }

                    //后一个小支架
                    DLocation lastDLocation = new DLocation(imageNameList.ElementAt(upFirstElement - 1).DLocation.X + imageNameList.ElementAt(upFirstElement - 1).width, imageNameList.ElementAt(upFirstElement - 1).DLocation.Y, imageNameList.ElementAt(upFirstElement - 1).DLocation.Z);
                    writeBottomStand(dxf, new DLocation(lastDLocation.X - 2, lastDLocation.Y - 6, lastDLocation.Z), 6, 2, dmc.outer_in_space / 26, "left");
                    //支架dimension
                    writeBottomStandDimension(new DLocation(lastDLocation.X, lastDLocation.Y - 6, lastDLocation.Z), lastDLocation, dxf, "right", 16, 3, 15);

                    //画左边的dimension
                    if (imageNameList.ElementAt(upFirstElement).name.Equals("HRA"))
                    {
                        //这里还不知它的数据
                    }
                    else
                    {
                        //一层左边deminsion
                        PictureBoxInfo firstPictureBoxInfo = imageNameList.ElementAt(0);
                        writeLeftOrRightDimension(firstPictureBoxInfo, firstPictureBoxInfo.DLocation, dxf, "left");
                        PictureBoxInfo upFirstPictureBoxInfo = imageNameList.ElementAt(upFirstElement);
                        writeLeftOrRightDimension(upFirstPictureBoxInfo, upFirstPictureBoxInfo.DLocation, dxf, "left");

                        
                    }
                    //画右边的dimension
                    if (imageNameList.ElementAt(imageNameList.Count - 1).Equals("HRA"))
                    {
                        //这里没有数据还没画
                    }
                    else
                    {
                        //一层右边第一层dimensiong
                        PictureBoxInfo firstRightPictureBoxInfo = imageNameList.ElementAt(upFirstElement - 1);
                        writeLeftOrRightDimension(firstRightPictureBoxInfo, firstRightPictureBoxInfo.DLocation, dxf, "right");

                        //一层右边第二层
                        PictureBoxInfo oneSecondRightPictureBoxInfo = imageNameList.ElementAt(upFirstElement - 1);
                        DLocation one_startDLocation = new DLocation(oneSecondRightPictureBoxInfo.DLocation.X + oneSecondRightPictureBoxInfo.width, oneSecondRightPictureBoxInfo.DLocation.Y, oneSecondRightPictureBoxInfo.DLocation.Z);
                        DLocation one_secondDLocation = new DLocation(oneSecondRightPictureBoxInfo.DLocation.X + oneSecondRightPictureBoxInfo.width, oneSecondRightPictureBoxInfo.DLocation.Y + oneSecondRightPictureBoxInfo.height, oneSecondRightPictureBoxInfo.DLocation.Z);
                        writeRightSecondDimension(one_startDLocation, one_secondDLocation, dxf, "right", 16, 3, 15);

                        //二层右边第一层
                        PictureBoxInfo upLastPictureBoxInfo = imageNameList.ElementAt(imageNameList.Count - 1);
                        writeLeftOrRightDimension(upLastPictureBoxInfo, upLastPictureBoxInfo.DLocation, dxf, "right", 16, 3, 8);

                        //二层右边第二层dimesion
                        PictureBoxInfo twoSecondRightPictureBoxInfo = imageNameList.ElementAt(imageNameList.Count - 1);
                        DLocation two_startDLocation = new DLocation(twoSecondRightPictureBoxInfo.DLocation.X + twoSecondRightPictureBoxInfo.width, twoSecondRightPictureBoxInfo.DLocation.Y, twoSecondRightPictureBoxInfo.DLocation.Z);
                        DLocation two_secondDLocation = new DLocation(twoSecondRightPictureBoxInfo.DLocation.X + twoSecondRightPictureBoxInfo.width, twoSecondRightPictureBoxInfo.DLocation.Y + twoSecondRightPictureBoxInfo.height, twoSecondRightPictureBoxInfo.DLocation.Z);

                        writeRightSecondDimension(two_startDLocation, two_secondDLocation, dxf, "right", 16, 3, 15);
                    }

                    //bottom最外层
                    PictureBoxInfo startRightPictureBoxInfo = imageNameList.ElementAt(0);
                    writeTotalBottomDimension(startRightPictureBoxInfo, firstLayerWidth, dxf, "bottom", 16, 3, 15);

                    //画垫层的dimension,他和别的标注函数雷同，就不重写了，直接调用
                    if (imageNameList.ElementAt(upFirstElement).name.Equals("HRA"))
                    {
                        //画在最后
                        PictureBoxInfo lastPictureInfo=imageNameList.ElementAt(imageNameList.Count-1);
                        DLocation cushionDLocation = new DLocation(lastPictureInfo.DLocation.X + lastPictureInfo.width, lastPictureInfo.DLocation.Y, lastPictureInfo.DLocation.Z);
                        writeRightSecondDimension(new DLocation(cushionDLocation.X, cushionDLocation.Y - 2, cushionDLocation.Z), cushionDLocation, dxf, "right", 16, 1, 5);
                    }
                    else if (imageNameList.ElementAt(imageNameList.Count - 1).name.Equals("HRA"))
                    {
                        //画在开始
                        PictureBoxInfo upFirstPictureInfo = imageNameList.ElementAt(upFirstElement);
                        DLocation cushionDLocation = new DLocation(upFirstPictureInfo.DLocation.X, upFirstPictureInfo.DLocation.Y, upFirstPictureInfo.DLocation.Z);
                        writeRightSecondDimension(new DLocation(cushionDLocation.X, cushionDLocation.Y - 2, cushionDLocation.Z), cushionDLocation, dxf, "left", 16, 1, 5);
                    }
                    else
                    {
                        //画在最后
                        PictureBoxInfo lastPictureInfo = imageNameList.ElementAt(imageNameList.Count - 1);
                        DLocation cushionDLocation = new DLocation(lastPictureInfo.DLocation.X + lastPictureInfo.width, lastPictureInfo.DLocation.Y, lastPictureInfo.DLocation.Z);
                        writeRightSecondDimension(new DLocation(cushionDLocation.X, cushionDLocation.Y - 2, cushionDLocation.Z), cushionDLocation, dxf, "right", 16, 1, 5);
                    }

                    
                }
                else
                {
                    for (int i = 0; i < imageNameList.Count; i++)
                    {
                        if (i >= upFirstElement)
                        {
                            PictureBoxInfo pictureBoxInfo = imageNameList.ElementAt(i);
                            //消除间隙，此时不存在双层元素
                            pictureBoxInfo.DLocation.Y += pictureBoxInfo.height * 2 + 2;
                            assembleDetailMechine(pictureBoxInfo, dxf, pictureBoxInfo.DLocation, pictureBoxInfo.text, Convert.ToDouble(pictureBoxInfo.height), Convert.ToDouble(pictureBoxInfo.width), dmc.outer_mid_space, dmc.outer_in_space, dmc.barHeight, dmc.barWidth);

                            //top层dimensiong
                            PictureBoxInfo topPictureBoxInfo = imageNameList.ElementAt(i);
                            writeTopOrBottomDimension(topPictureBoxInfo, dxf, "top", 16, 3, 8);
                        }
                        else
                        {
                            //第一层Y位置保持不变
                            PictureBoxInfo pictureBoxInfo = imageNameList.ElementAt(i);
                            firstLayerWidth += pictureBoxInfo.width;
                            assembleDetailMechine(pictureBoxInfo, dxf, pictureBoxInfo.DLocation, pictureBoxInfo.text, Convert.ToDouble(pictureBoxInfo.height), Convert.ToDouble(pictureBoxInfo.width), dmc.outer_mid_space, dmc.outer_in_space, dmc.barHeight, dmc.barWidth);
                            //bottom
                            writeTopOrBottomDimension(pictureBoxInfo, dxf, "bottom");

                            DLocation standDLocation = imageNameList.ElementAt(i).DLocation;
                            if (i == 0)
                            {
                                writeBottomStand(dxf, new DLocation(standDLocation.X, standDLocation.Y - 6, standDLocation.Z), 6, 2, dmc.outer_in_space / 26, "left");
                            }
                            else
                            {
                                writeBottomStand(dxf, new DLocation(standDLocation.X - 2, standDLocation.Y - 6, standDLocation.Z), 6, 2, dmc.outer_in_space / 26, "left");
                                writeBottomStand(dxf, new DLocation(standDLocation.X, standDLocation.Y - 6, standDLocation.Z), 6, 2, dmc.outer_in_space / 26, "right");

                            }
                        }
                    }

                    //后一个小支架
                    DLocation lastDLocation = new DLocation(imageNameList.ElementAt(upFirstElement - 1).DLocation.X + imageNameList.ElementAt(upFirstElement - 1).width, imageNameList.ElementAt(upFirstElement - 1).DLocation.Y, imageNameList.ElementAt(upFirstElement - 1).DLocation.Z);
                    writeBottomStand(dxf, new DLocation(lastDLocation.X - 2, lastDLocation.Y - 6, lastDLocation.Z), 6, 2, dmc.outer_in_space / 26, "left");
                    //支架dimension
                    writeBottomStandDimension(new DLocation(lastDLocation.X, lastDLocation.Y - 6, lastDLocation.Z), lastDLocation, dxf, "right", 16, 3, 15);

                    //左边deminsion
                    PictureBoxInfo firstPictureBoxInfo = imageNameList.ElementAt(0);
                    writeLeftOrRightDimension(firstPictureBoxInfo, firstPictureBoxInfo.DLocation, dxf, "left");
                    PictureBoxInfo upFirstPictureBoxInfo = imageNameList.ElementAt(upFirstElement);
                    writeLeftOrRightDimension(upFirstPictureBoxInfo, upFirstPictureBoxInfo.DLocation, dxf, "left");
                    //一层右边第一层dimensiong
                    PictureBoxInfo firstRightPictureBoxInfo = imageNameList.ElementAt(upFirstElement-1);
                    writeLeftOrRightDimension(firstRightPictureBoxInfo, firstRightPictureBoxInfo.DLocation, dxf, "right");
                    
                    //一层右边第二层
                     PictureBoxInfo oneSecondRightPictureBoxInfo = imageNameList.ElementAt(upFirstElement- 1);
                     DLocation one_startDLocation = new DLocation(oneSecondRightPictureBoxInfo.DLocation.X + oneSecondRightPictureBoxInfo.width, oneSecondRightPictureBoxInfo.DLocation.Y, oneSecondRightPictureBoxInfo.DLocation.Z);
                     DLocation one_secondDLocation = new DLocation(oneSecondRightPictureBoxInfo.DLocation.X + oneSecondRightPictureBoxInfo.width, oneSecondRightPictureBoxInfo.DLocation.Y + oneSecondRightPictureBoxInfo.height, oneSecondRightPictureBoxInfo.DLocation.Z);
                     writeRightSecondDimension(one_startDLocation, one_secondDLocation, dxf, "right", 16, 3, 15);

                    //二层右边第一层
                    PictureBoxInfo upLastPictureBoxInfo = imageNameList.ElementAt(imageNameList.Count-1);
                    writeLeftOrRightDimension(upLastPictureBoxInfo, upLastPictureBoxInfo.DLocation, dxf, "right",16,3,8);

                    //二层右边第二层dimesion
                    PictureBoxInfo twoSecondRightPictureBoxInfo = imageNameList.ElementAt(imageNameList.Count - 1);
                    DLocation two_startDLocation = new DLocation(twoSecondRightPictureBoxInfo.DLocation.X + twoSecondRightPictureBoxInfo.width, twoSecondRightPictureBoxInfo.DLocation.Y, twoSecondRightPictureBoxInfo.DLocation.Z);
                    DLocation two_secondDLocation = new DLocation(twoSecondRightPictureBoxInfo.DLocation.X + twoSecondRightPictureBoxInfo.width, twoSecondRightPictureBoxInfo.DLocation.Y + twoSecondRightPictureBoxInfo.height, twoSecondRightPictureBoxInfo.DLocation.Z);
                    //计算dimension高度用
                 //   double secondDimensionHeiht = imageNameList.ElementAt(upFirstElement - 1).DLocation.X - imageNameList.ElementAt(imageNameList.Count - 1).DLocation.X + imageNameList.ElementAt(upFirstElement - 1).width;
                 //   if (imageNameList.ElementAt(upFirstElement - 1).DLocation.X - imageNameList.ElementAt(imageNameList.Count - 1).DLocation.X > 0)
                 //   {
                    //     writeRightSecondDimension(two_startDLocation, two_secondDLocation, dxf, "right", 16, 3, 15 + secondDimensionHeiht);
                  //  }
                   // else
                    //{
                        writeRightSecondDimension(two_startDLocation, two_secondDLocation, dxf, "right", 16, 3, 15);
                   // }

                    //一、二层右边第三层dimension
                    //PictureBoxInfo twoThirdSecondRightPictureBoxInfo = imageNameList.ElementAt(imageNameList.Count - 1);
                    //PictureBoxInfo twoThirdStartRightPicureBoxInfo = imageNameList.ElementAt(upFirstElement - 1);
                    //DLocation two_startThirdDLocation = new DLocation(twoThirdStartRightPicureBoxInfo.DLocation.X + twoThirdStartRightPicureBoxInfo.width, twoThirdStartRightPicureBoxInfo.DLocation.Y, twoThirdStartRightPicureBoxInfo.DLocation.Z);
                    //DLocation two_secondThirdDLocation = new DLocation(twoThirdSecondRightPictureBoxInfo.DLocation.X + twoThirdSecondRightPictureBoxInfo.width, twoThirdSecondRightPictureBoxInfo.DLocation.Y + twoThirdSecondRightPictureBoxInfo.height, twoThirdSecondRightPictureBoxInfo.DLocation.Z);

                    //writeRightSecondDimension(two_startThirdDLocation, two_secondThirdDLocation, dxf, "right", 16, 3, 15);
                  

                    //bottom最外层
                    PictureBoxInfo startRightPictureBoxInfo = imageNameList.ElementAt(0);
                    writeTotalBottomDimension(startRightPictureBoxInfo, firstLayerWidth, dxf, "bottom", 16, 3, 15);
                }
            }
            else
            {
                for (int i = 0; i < imageNameList.Count; i++)
                {
                    PictureBoxInfo pictureBoxInfo = imageNameList.ElementAt(i);
                    firstLayerWidth += pictureBoxInfo.width;
                    assembleDetailMechine(pictureBoxInfo, dxf, pictureBoxInfo.DLocation, pictureBoxInfo.text, Convert.ToDouble(pictureBoxInfo.height), Convert.ToDouble(pictureBoxInfo.width), dmc.outer_mid_space, dmc.outer_in_space, dmc.barHeight, dmc.barWidth);
                    //每个图框底部的dimension
                    writeTopOrBottomDimension(pictureBoxInfo, dxf, "bottom", 16, 3, 8);

                    DLocation standDLocation = imageNameList.ElementAt(i).DLocation;
                    if (i == 0)
                    {
                        writeBottomStand(dxf, new DLocation(standDLocation.X, standDLocation.Y - 6, standDLocation.Z), 6, 2, dmc.outer_in_space / 26, "left");
                    }
                    else
                    {
                        writeBottomStand(dxf, new DLocation(standDLocation.X - 2, standDLocation.Y - 6, standDLocation.Z), 6, 2, dmc.outer_in_space / 26, "left");
                        writeBottomStand(dxf, new DLocation(standDLocation.X, standDLocation.Y - 6, standDLocation.Z), 6, 2, dmc.outer_in_space / 26, "right");
                                                     
                    }
                   
                }

                //后一个小支架
                DLocation lastDLocation = new DLocation(imageNameList.ElementAt(imageNameList.Count - 1).DLocation.X + imageNameList.ElementAt(imageNameList.Count - 1).width, imageNameList.ElementAt(imageNameList.Count - 1).DLocation.Y, imageNameList.ElementAt(imageNameList.Count - 1).DLocation.Z);
                writeBottomStand(dxf, new DLocation(lastDLocation.X - 2, lastDLocation.Y - 6, lastDLocation.Z), 6, 2, dmc.outer_in_space/ 26, "left");
                 //支架dimension
                writeBottomStandDimension(new DLocation(lastDLocation.X, lastDLocation.Y - 6, lastDLocation.Z), lastDLocation, dxf,"right", 16, 3, 15);

                //注意这里还要封装冷量类型，没有做
                PictureBoxInfo firstLeftPictureBoxInfo = imageNameList.ElementAt(0);
                writeLeftOrRightDimension(firstLeftPictureBoxInfo, firstLeftPictureBoxInfo.DLocation, dxf, "left");
                //右边第一层dimension
                PictureBoxInfo firstRightPictureBoxInfo = imageNameList.ElementAt(imageNameList.Count - 1);
                writeLeftOrRightDimension(firstRightPictureBoxInfo, firstRightPictureBoxInfo.DLocation, dxf, "right");
                //右边第二层dimesion
                PictureBoxInfo secondRightPictureBoxInfo = imageNameList.ElementAt(imageNameList.Count - 1);
                DLocation startDLocation = new DLocation(secondRightPictureBoxInfo.DLocation.X + secondRightPictureBoxInfo.width, secondRightPictureBoxInfo.DLocation.Y, secondRightPictureBoxInfo.DLocation.Z);
                DLocation secondDLocation = new DLocation(secondRightPictureBoxInfo.DLocation.X + secondRightPictureBoxInfo.width, secondRightPictureBoxInfo.DLocation.Y + secondRightPictureBoxInfo.height, secondRightPictureBoxInfo.DLocation.Z);
                writeRightSecondDimension(startDLocation, secondDLocation, dxf, "right", 16, 3, 15);
                //右边第三层dimension
                //还没做

                //bottom最外层
                PictureBoxInfo startRightPictureBoxInfo = imageNameList.ElementAt(0);
                writeTotalBottomDimension(startRightPictureBoxInfo, firstLayerWidth, dxf, "bottom", 16, 3, 15);

               

            } 
        }

      //判断是否要花双层
        public static int isTwoLayers(List<PictureBoxInfo> imageList)
        {
            List<PictureBoxInfo> downList = new List<PictureBoxInfo>();
            List<PictureBoxInfo> upList = new List<PictureBoxInfo>();
            for (int i = 0; i < imageList.Count; i++)
            {
                if (i == 0)
                {
                    downList.Add(imageList.ElementAt(0));

                }
                else
                {
                    PictureBoxInfo firstDownElement = imageList.ElementAt(0);
                    if ((firstDownElement.DLocation.Y == imageList.ElementAt(i).DLocation.Y && imageList.ElementAt(i).name != "HRA"))
                    {
                        downList.Add(imageList.ElementAt(i));
                    }
                    else
                    {
                        upList.Add(imageList.ElementAt(i));
                    }
                }
            }                 
            //如果存在上层，就记录下上层第一个元素的位置
            int upFirstElement = -1;
            if (upList.Count > 0)
            {
               upFirstElement = downList.Count;
               return upFirstElement;
            }
            else
            {
               upFirstElement = -1;
               return upFirstElement;
            }        
        }

        //判断是否存在两层元素
        public static Boolean isExistTwoLayerElement(List<PictureBoxInfo> imageList)
        {
            for (int i = 0; i < imageList.Count;i++ )
            {
                if (imageList.ElementAt(i).name.Equals("HRA"))
                {
                    return true;
                }
            }
            return false;
        }
      
      
      //返回上下层中最长的列表
        public static List<PictureBoxInfo> getUpOrDownPictrueBoxInfoList(List<PictureBoxInfo> pictrueBoxInfoList)
        {

            if (isTwoLayers(pictrueBoxInfoList)!=-1)
            {
                List<PictureBoxInfo> oneImageNameList = new List<PictureBoxInfo>();
                List<PictureBoxInfo> twoImageNameList = new List<PictureBoxInfo>();
                for (int i = 0, len = pictrueBoxInfoList.Count; i < len; i++)
                {
                    if (i == 0)
                    {
                        oneImageNameList.Add(pictrueBoxInfoList.ElementAt(i));
                    }
                    else
                    {
                        if (oneImageNameList.ElementAt(0).DLocation.Y == pictrueBoxInfoList.ElementAt(i).DLocation.Y)
                        {
                            oneImageNameList.Add(pictrueBoxInfoList.ElementAt(i));
                        }
                        else
                        {
                            twoImageNameList.Add(pictrueBoxInfoList.ElementAt(i));
                        }
                    }
                }
                return oneImageNameList.Count > twoImageNameList.Count ? oneImageNameList : twoImageNameList;
            }
            else
            {
                return pictrueBoxInfoList;
            }
            
        }

     }
}
