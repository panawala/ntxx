
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
                        DoorRectangle.writeWholeSingleDoor(dxf,DLocation, DxfText,height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                           
                }
                else if(imageName.Equals("MBA")||imageName.Equals("MBB")||imageName.Equals("MBC")||imageName.Equals("MBD")||imageName.Equals("MBE")||imageName.Equals("MBF")||imageName.Equals("MBG")||imageName.Equals("MBH")||imageName.Equals("MBI")||imageName.Equals("MBJ")||imageName.Equals("MBK"))
                {

                        DoorRectangle.writeWholeMachine(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                   
                }
                else if(imageName.Equals("PHA")||imageName.Equals("PHB")||imageName.Equals("PHC")||imageName.Equals("PHD"))
                {                   
                   
                        DoorRectangle.writeWholeDoubleDoor(dxf, DLocation, DxfText, DoorInitHeightAndWidth.doubledoorheigt, DoorInitHeightAndWidth.doubledoorwidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                    
                }
                else if (imageName.Equals("HRA"))
                {
                    
                        DoorRectangle.writeWholeSingleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                    
                }
                else if (imageName.Equals("virtualHRA"))
                {
                   
                }
                else if (imageName.Equals("CLB") || imageName.Equals("CLC") || imageName.Equals("CLF") || imageName.Equals("CLG") || imageName.Equals("CLI") || imageName.Equals("CLM"))
                {                    
                        DoorRectangle.writeWholeDoubleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                   
                  
                }
                else if (imageName.Equals("PEA") || imageName.Equals("PEC") || imageName.Equals("RFA") || imageName.Equals("SFA") || imageName.Equals("SFC") || imageName.Equals("SFD"))
                {
                    
                        DoorRectangle.writeWholeDoubleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                      
                }
                else if (imageName.Equals("BBA") || imageName.Equals("BBB") || imageName.Equals("BBC") || imageName.Equals("BBD") || imageName.Equals("BBE"))
                {
                    
                        DoorRectangle.writeWholeDoubleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                     
                   
                }
                else if (imageName.Equals("TRA") || imageName.Equals("TRB") || imageName.Equals("TRC") || imageName.Equals("TRD") || imageName.Equals("TRE"))
                {
                    
                        DoorRectangle.writeWholeDoubleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                   
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
                            }
                        }
                        else
                        {
                             PictureBoxInfo pictureBoxInfo = imageNameList.ElementAt(i);
                             assembleDetailMechine(pictureBoxInfo, dxf, pictureBoxInfo.DLocation, pictureBoxInfo.text, Convert.ToDouble(pictureBoxInfo.height), Convert.ToDouble(pictureBoxInfo.width), dmc.outer_mid_space, dmc.outer_in_space, dmc.barHeight, dmc.barWidth);
                        }   
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
                        }
                    }
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
                    writeTopOrBottomDimension(pictureBoxInfo, dxf, "bottom", 16, 3, 8);

                }
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
//=======
//﻿using System;
//using System.Collections.Generic;
//using System.Linq;
//using Model.Zutu;
//using WW.Cad.Model;
//namespace CadLib.OperatorEntity
//{
//  public  class AssembleDetailMechine
//    {
//       private static List<DLocation> storeDLocationList=new List<DLocation>();
//        public static void assembleDetailMechine(List<PictureBoxInfo> imageNameList,DxfModel dxf, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space, double barHeight, double barWidth,string upOrDownLayer)
//        {
//            //List<DLocation> storeDLocationList = new List<DLocation>();
//            if (storeDLocationList.Count > 0)
//            {
//                storeDLocationList.Clear();
//            }
//            for (int i = 0; i < imageNameList.Count; i++)
//            {
//                string imageName=imageNameList.ElementAt(i).name;
//                if (imageName.Equals("FTA") || imageName.Equals("FTC") || imageName.Equals("FTF") || imageName.Equals("FTH"))
//                {
//                    if (i == 0)
//                    {
//                        DoorRectangle.writeWholeSingleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
//                        DoorRectangle.writeWholeSingleDoor(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.sinlgeheight, DoorInitHeightAndWidth.singlewidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.singlewidth, currentDLocation.Y, currentDLocation.Z));
//                    }
//                }
//                else if(imageName.Equals("MBA")||imageName.Equals("MBB")||imageName.Equals("MBC")||imageName.Equals("MBD")||imageName.Equals("MBE")||imageName.Equals("MBF")||imageName.Equals("MBG")||imageName.Equals("MBH")||imageName.Equals("MBI")||imageName.Equals("MBJ")||imageName.Equals("MBK"))
//                {
//                    if (i == 0)
//                    {
//                        DoorRectangle.writeWholeMachine(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
//                        DoorRectangle.writeWholeMachine(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.doubleheight, DoorInitHeightAndWidth.doublewidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.doublewidth, currentDLocation.Y, currentDLocation.Z));
//                    }
//                }
//                else if(imageName.Equals("PHA")||imageName.Equals("PHB")||imageName.Equals("PHC")||imageName.Equals("PHD"))
//                {
//                    if (i == 0)
//                    {
//                        DoorRectangle.writeWholeDoubleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
//                        DoorRectangle.writeWholeDoubleDoor(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.doubledoorheigt, DoorInitHeightAndWidth.doubledoorwidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.doubledoorwidth, DLocation.Y, DLocation.Z));
//                    }
//                }
//                else if (imageName.Equals("HRA"))
//                {

//                    if (i == 0)
//                    {
//                        DoorRectangle.writeWholeSingleDoor(dxf, DLocation, DxfText, 2*height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
//                        DoorRectangle.writeWholeSingleDoor(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.sinlgeheight*2, DoorInitHeightAndWidth.singlewidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.singlewidth, currentDLocation.Y, currentDLocation.Z));
//                    }
//                }
//                else if (imageName.Equals("virtualHRA"))
//                {
//                    if (i == 0)
//                    {
//                       // DoorRectangle.writeWholeSingleDoor(dxf, DLocation, DxfText, 2 * height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
//                       // DoorRectangle.writeWholeSingleDoor(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.sinlgeheight * 2, DoorInitHeightAndWidth.singlewidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.singlewidth, currentDLocation.Y, currentDLocation.Z));
//                    }
//                }
//                else if (imageName.Equals("CLB") || imageName.Equals("CLC") || imageName.Equals("CLF") || imageName.Equals("CLG") || imageName.Equals("CLI") || imageName.Equals("CLM"))
//                {
//                    if (i == 0)
//                    {
//                        DoorRectangle.writeWholeDoubleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
//                        DoorRectangle.writeWholeDoubleDoor(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.doubledoorheigt, DoorInitHeightAndWidth.doubledoorwidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.doubledoorwidth, DLocation.Y, DLocation.Z));
//                    }
//                }
//                else if (imageName.Equals("PEA") || imageName.Equals("PEC") || imageName.Equals("RFA") || imageName.Equals("SFA") || imageName.Equals("SFC") || imageName.Equals("SFD"))
//                {
//                    if (i == 0)
//                    {
//                        DoorRectangle.writeWholeDoubleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
//                        DoorRectangle.writeWholeDoubleDoor(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.doubledoorheigt, DoorInitHeightAndWidth.doubledoorwidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.doubledoorwidth, DLocation.Y, DLocation.Z));
//                    }
//                }
//                else if (imageName.Equals("BBA") || imageName.Equals("BBB") || imageName.Equals("BBC") || imageName.Equals("BBD") || imageName.Equals("BBE"))
//                {
//                    if (i == 0)
//                    {
//                        DoorRectangle.writeWholeDoubleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
//                        DoorRectangle.writeWholeDoubleDoor(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.doubledoorheigt, DoorInitHeightAndWidth.doubledoorwidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.doubledoorwidth, DLocation.Y, DLocation.Z));
//                    }
//                }
//                else if (imageName.Equals("TRA") || imageName.Equals("TRB") || imageName.Equals("TRC") || imageName.Equals("TRD") || imageName.Equals("TRE"))
//                {
//                    if (i == 0)
//                    {
//                        DoorRectangle.writeWholeDoubleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(DLocation);
//                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
//                    }
//                    else
//                    {
//                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
//                        DoorRectangle.writeWholeDoubleDoor(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.doubledoorheigt, DoorInitHeightAndWidth.doubledoorwidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
//                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.doubledoorwidth, DLocation.Y, DLocation.Z));
//                    }
//                }
//            }

//            //画标注
//            DLocation firstDLocation=DLocation;
//            DLocation secondDLocation=new DLocation(DLocation.X,DLocation.Y+6,DLocation.Z);
//            DoorRectangle.writeDimension(dxf, DLocation, secondDLocation, 16, 3, 8, "left");
//            DoorRectangle.writeDimension(dxf, secondDLocation, new DLocation(secondDLocation.X, secondDLocation.Y + 32, secondDLocation.Z), 16, 3, 8, "left");
//        }

//      //风中top或bottom的dimension
//        public static void writeTopOrBottomDimension(List<DLocation> storeDLocationList,DxfModel dxf,string topOrBottom)
//        {
//            for (int i = 0; i < storeDLocationList.Count - 1; i++)
//            {
//                DLocation tempFirstDLocation = storeDLocationList.ElementAt(i);
//                DLocation tempSecondDLocation = storeDLocationList.ElementAt(i + 1);

//                DoorRectangle.writeDimension(dxf, tempFirstDLocation, tempSecondDLocation, 16, 3, 10, topOrBottom);

//            }

//            DoorRectangle.writeDimension(dxf, storeDLocationList.ElementAt(0), storeDLocationList.ElementAt(storeDLocationList.Count - 1), 16, 3, 15, topOrBottom);
//        }

//      //封装中right的dimension
//        public static void writeRightDimension(List<DLocation> storeDLocationList,DxfModel dxf,double height,string upOrDownRightDimension)
//        {
//            if(upOrDownRightDimension.Equals("rightDownLayer")){
//                //下层右边标注
//                DLocation rightFirstDLocation = storeDLocationList.ElementAt(storeDLocationList.Count - 1);
//                DoorRectangle.writeDimension(dxf, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y - 6, rightFirstDLocation.Z), rightFirstDLocation, 16, 3, 8, "right");
//                DoorRectangle.writeDimension(dxf, rightFirstDLocation, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + 11, rightFirstDLocation.Z), 16, 3, 8, "right");
//                DoorRectangle.writeDimension(dxf, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + 11, rightFirstDLocation.Z), new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + 33, rightFirstDLocation.Z), 16, 3, 8, "right");
//                DoorRectangle.writeDimension(dxf, rightFirstDLocation, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + height, rightFirstDLocation.Z), 16, 3, 15, "right");
//                DoorRectangle.writeDimension(dxf, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y - 6, rightFirstDLocation.Z), new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + height, rightFirstDLocation.Z), 16, 3, 23, "right");
//            }
//            else if(upOrDownRightDimension.Equals("rightUpLayer")){
//                //上层右边标注
//                DLocation rightFirstDLocation = storeDLocationList.ElementAt(storeDLocationList.Count - 1);
//                //不包含下面的标注
//                //DoorRectangle.writeDimension(dxf, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y - 6, rightFirstDLocation.Z), rightFirstDLocation, 16, 3, 8, "right");
//                DoorRectangle.writeDimension(dxf, rightFirstDLocation, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + 11, rightFirstDLocation.Z), 16, 3, 8, "right");
//                DoorRectangle.writeDimension(dxf, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + 11, rightFirstDLocation.Z), new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + 33, rightFirstDLocation.Z), 16, 3, 8, "right");
//                DoorRectangle.writeDimension(dxf, rightFirstDLocation, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + height, rightFirstDLocation.Z), 16, 3, 15, "right");
//                DoorRectangle.writeDimension(dxf, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y, rightFirstDLocation.Z), new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + height, rightFirstDLocation.Z), 16, 3, 23, "right");
//            }
//        }

//      //上下层组装和单层组装函数
//        public static void assembleDetailMechine(List<PictureBoxInfo> imageNameList, DxfModel dxf, DLocation DLocation, DetailMechineConfigure dmc,int coolingType)
//        {
//            if (isTwoLayers(imageNameList))
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
//                            realPictureBox.DLocation = new DLocation(imageNameList.ElementAt(i).DLocation.X,imageNameList.ElementAt(i).DLocation.Y+113+4,imageNameList.ElementAt(i).DLocation.Z);
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
//                //判断上下层进行判断
//                if (oneImageNameList.Count > 0 && twoImageNameList.Count > 0)
//                {
//                    //这里的DLocation.Y 是前台组图的Y坐标，他和dxf的启示坐标刚好相反，在左上角
//                    if (oneImageNameList.ElementAt(0).DLocation.Y <twoImageNameList.ElementAt(0).DLocation.Y)
//                    {
//                        //下层
//                        assembleDetailMechine(twoImageNameList, dxf, DLocation, dmc.DxfText, dmc.height, dmc.width,dmc.outer_mid_space,dmc.outer_in_space, dmc.barHeight, dmc.barWidth,"downLayer");
//                        writeTopOrBottomDimension(storeDLocationList,dxf,"bottom");
//                        writeRightDimension(storeDLocationList, dxf, dmc.height, "rightDownLayer");
//                        //上层
//                        DLocation upDLocation = TotalWidthAndHeight.getUpLayerDLocation(twoImageNameList, oneImageNameList, coolingType);
//                        assembleDetailMechine(oneImageNameList, dxf, new DLocation(DLocation.X+upDLocation.X,DLocation.Y+upDLocation.Y,DLocation.Z), dmc.DxfText, dmc.height, dmc.width, dmc.outer_mid_space,dmc.outer_in_space, dmc.barHeight, dmc.barWidth,"upLayer");
//                        writeRightDimension(storeDLocationList, dxf, dmc.height, "rightUpLayer");
//                    }
//                    else
//                    {
//                        //下层
//                        assembleDetailMechine(oneImageNameList, dxf, DLocation, dmc.DxfText, dmc.height, dmc.width, dmc.outer_mid_space, dmc.outer_in_space, dmc.barHeight, dmc.barWidth,"upLayer");
//                        writeTopOrBottomDimension(storeDLocationList, dxf, "bottom");
//                        writeRightDimension(storeDLocationList, dxf, dmc.height, "rightDownLayer");
//                        //上层
//                        DLocation upDLocation = TotalWidthAndHeight.getUpLayerDLocation(oneImageNameList,twoImageNameList, coolingType);
//                        assembleDetailMechine(twoImageNameList, dxf, new DLocation(DLocation.X + upDLocation.X, DLocation.Y + upDLocation.Y, DLocation.Z), dmc.DxfText, dmc.height, dmc.width, dmc.outer_mid_space, dmc.outer_in_space, dmc.barHeight, dmc.barWidth,"upLayer");
//                        writeRightDimension(storeDLocationList, dxf, dmc.height, "rightUpLayer");
//                    }
//                }
//            }
//                //单层情况
//            else
//            {
//                assembleDetailMechine(imageNameList, dxf, DLocation, dmc.DxfText, dmc.height, dmc.width, dmc.outer_mid_space,dmc.outer_in_space, dmc.barHeight, dmc.barWidth,"downLayer");
//                writeTopOrBottomDimension(storeDLocationList, dxf, "bottom");
//                writeRightDimension(storeDLocationList, dxf, dmc.height, "rightDownLayer");
//            } 
//        }

//      //判断是否要花双层
//        public static Boolean isTwoLayers(List<PictureBoxInfo> imageNameList)
//        {
//            double flag=0;
//            for (int i = 0, len = imageNameList.Count; i < len;i++ )
//            {
//                if (i == 0)
//                {
//                    flag = imageNameList.ElementAt(i).DLocation.Y;
//                }
//                if (flag != imageNameList.ElementAt(i).DLocation.Y)
//                {
//                    //为双层返回true
//                    return true;
//                }
//            }
//            return false;
//        }
      
//      //返回上下层中最长的列表
//        public static List<PictureBoxInfo> getUpOrDownPictrueBoxInfoList(List<PictureBoxInfo> pictrueBoxInfoList)
//        {

//            if (isTwoLayers(pictrueBoxInfoList))
//            {
//                List<PictureBoxInfo> oneImageNameList = new List<PictureBoxInfo>();
//                List<PictureBoxInfo> twoImageNameList = new List<PictureBoxInfo>();
//                for (int i = 0, len = pictrueBoxInfoList.Count; i < len; i++)
//                {
//                    if (i == 0)
//                    {
//                        oneImageNameList.Add(pictrueBoxInfoList.ElementAt(i));
//                    }
//                    else
//                    {
//                        if (oneImageNameList.ElementAt(0).DLocation.Y == pictrueBoxInfoList.ElementAt(i).DLocation.Y)
//                        {
//                            oneImageNameList.Add(pictrueBoxInfoList.ElementAt(i));
//                        }
//                        else
//                        {
//                            twoImageNameList.Add(pictrueBoxInfoList.ElementAt(i));
//                        }
//                    }
//                }
//                return oneImageNameList.Count > twoImageNameList.Count ? oneImageNameList : twoImageNameList;
//            }
//            else
//            {
//                return pictrueBoxInfoList;
//            }
            
//        }

//     }
//}
//>>>>>>> .r46
