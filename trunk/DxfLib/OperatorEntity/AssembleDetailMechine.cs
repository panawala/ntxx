using System;
using System.Collections.Generic;
using System.Linq;
using Model.Zutu;
using WW.Cad.Model;
namespace CadLib.OperatorEntity
{
  public  class AssembleDetailMechine
    {
       private static List<DLocation> storeDLocationList=new List<DLocation>();
        public static void assembleDetailMechine(List<PictureBoxInfo> imageNameList,DxfModel dxf, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space, double barHeight, double barWidth,string upOrDownLayer)
        {
            //List<DLocation> storeDLocationList = new List<DLocation>();
            if (storeDLocationList.Count > 0)
            {
                storeDLocationList.Clear();
            }
            for (int i = 0; i < imageNameList.Count; i++)
            {
                string imageName=imageNameList.ElementAt(i).name;
                if (imageName.Equals("FTA") || imageName.Equals("FTC") || imageName.Equals("FTF") || imageName.Equals("FTH"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeWholeSingleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
                        DoorRectangle.writeWholeSingleDoor(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.sinlgeheight, DoorInitHeightAndWidth.singlewidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.singlewidth, currentDLocation.Y, currentDLocation.Z));
                    }
                }
                else if(imageName.Equals("MBA")||imageName.Equals("MBB")||imageName.Equals("MBC")||imageName.Equals("MBD")||imageName.Equals("MBE")||imageName.Equals("MBF")||imageName.Equals("MBG")||imageName.Equals("MBH")||imageName.Equals("MBI")||imageName.Equals("MBJ")||imageName.Equals("MBK"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeWholeMachine(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
                        DoorRectangle.writeWholeMachine(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.doubleheight, DoorInitHeightAndWidth.doublewidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.doublewidth, currentDLocation.Y, currentDLocation.Z));
                    }
                }
                else if(imageName.Equals("PHA")||imageName.Equals("PHB")||imageName.Equals("PHC")||imageName.Equals("PHD"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeWholeDoubleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
                        DoorRectangle.writeWholeDoubleDoor(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.doubledoorheigt, DoorInitHeightAndWidth.doubledoorwidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.doubledoorwidth, DLocation.Y, DLocation.Z));
                    }
                }
                else if (imageName.Equals("HRA"))
                {

                    if (i == 0)
                    {
                        DoorRectangle.writeWholeSingleDoor(dxf, DLocation, DxfText, 2*height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
                        DoorRectangle.writeWholeSingleDoor(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.sinlgeheight*2, DoorInitHeightAndWidth.singlewidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.singlewidth, currentDLocation.Y, currentDLocation.Z));
                    }
                }
                else if (imageName.Equals("virtualHRA"))
                {
                    if (i == 0)
                    {
                       // DoorRectangle.writeWholeSingleDoor(dxf, DLocation, DxfText, 2 * height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
                       // DoorRectangle.writeWholeSingleDoor(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.sinlgeheight * 2, DoorInitHeightAndWidth.singlewidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.singlewidth, currentDLocation.Y, currentDLocation.Z));
                    }
                }
                else if (imageName.Equals("CLB") || imageName.Equals("CLC") || imageName.Equals("CLF") || imageName.Equals("CLG") || imageName.Equals("CLI") || imageName.Equals("CLM"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeWholeDoubleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
                        DoorRectangle.writeWholeDoubleDoor(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.doubledoorheigt, DoorInitHeightAndWidth.doubledoorwidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.doubledoorwidth, DLocation.Y, DLocation.Z));
                    }
                }
                else if (imageName.Equals("PEA") || imageName.Equals("PEC") || imageName.Equals("RFA") || imageName.Equals("SFA") || imageName.Equals("SFC") || imageName.Equals("SFD"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeWholeDoubleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
                        DoorRectangle.writeWholeDoubleDoor(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.doubledoorheigt, DoorInitHeightAndWidth.doubledoorwidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.doubledoorwidth, DLocation.Y, DLocation.Z));
                    }
                }
                else if (imageName.Equals("BBA") || imageName.Equals("BBB") || imageName.Equals("BBC") || imageName.Equals("BBD") || imageName.Equals("BBE"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeWholeDoubleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
                        DoorRectangle.writeWholeDoubleDoor(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.doubledoorheigt, DoorInitHeightAndWidth.doubledoorwidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.doubledoorwidth, DLocation.Y, DLocation.Z));
                    }
                }
                else if (imageName.Equals("TRA") || imageName.Equals("TRB") || imageName.Equals("TRC") || imageName.Equals("TRD") || imageName.Equals("TRE"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeWholeDoubleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(DLocation);
                        storeDLocationList.Add(new DLocation(DLocation.X + width, DLocation.Y, DLocation.Z));
                    }
                    else
                    {
                        DLocation currentDLocation = storeDLocationList.ElementAt(i);
                        DoorRectangle.writeWholeDoubleDoor(dxf, currentDLocation, DxfText, DoorInitHeightAndWidth.doubledoorheigt, DoorInitHeightAndWidth.doubledoorwidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeDLocationList.Add(new DLocation(currentDLocation.X + DoorInitHeightAndWidth.doubledoorwidth, DLocation.Y, DLocation.Z));
                    }
                }
            }

            //画标注
            DLocation firstDLocation=DLocation;
            DLocation secondDLocation=new DLocation(DLocation.X,DLocation.Y+6,DLocation.Z);
            DoorRectangle.writeDimension(dxf, DLocation, secondDLocation, 16, 3, 8, "left");
            DoorRectangle.writeDimension(dxf, secondDLocation, new DLocation(secondDLocation.X, secondDLocation.Y + 32, secondDLocation.Z), 16, 3, 8, "left");
        }

      //风中top或bottom的dimension
        public static void writeTopOrBottomDimension(List<DLocation> storeDLocationList,DxfModel dxf,string topOrBottom)
        {
            for (int i = 0; i < storeDLocationList.Count - 1; i++)
            {
                DLocation tempFirstDLocation = storeDLocationList.ElementAt(i);
                DLocation tempSecondDLocation = storeDLocationList.ElementAt(i + 1);

                DoorRectangle.writeDimension(dxf, tempFirstDLocation, tempSecondDLocation, 16, 3, 10, topOrBottom);

            }

            DoorRectangle.writeDimension(dxf, storeDLocationList.ElementAt(0), storeDLocationList.ElementAt(storeDLocationList.Count - 1), 16, 3, 15, topOrBottom);
        }

      //封装中right的dimension
        public static void writeRightDimension(List<DLocation> storeDLocationList,DxfModel dxf,double height,string upOrDownRightDimension)
        {
            if(upOrDownRightDimension.Equals("rightDownLayer")){
                //下层右边标注
                DLocation rightFirstDLocation = storeDLocationList.ElementAt(storeDLocationList.Count - 1);
                DoorRectangle.writeDimension(dxf, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y - 6, rightFirstDLocation.Z), rightFirstDLocation, 16, 3, 8, "right");
                DoorRectangle.writeDimension(dxf, rightFirstDLocation, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + 11, rightFirstDLocation.Z), 16, 3, 8, "right");
                DoorRectangle.writeDimension(dxf, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + 11, rightFirstDLocation.Z), new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + 33, rightFirstDLocation.Z), 16, 3, 8, "right");
                DoorRectangle.writeDimension(dxf, rightFirstDLocation, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + height, rightFirstDLocation.Z), 16, 3, 15, "right");
                DoorRectangle.writeDimension(dxf, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y - 6, rightFirstDLocation.Z), new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + height, rightFirstDLocation.Z), 16, 3, 23, "right");
            }
            else if(upOrDownRightDimension.Equals("rightUpLayer")){
                //上层右边标注
                DLocation rightFirstDLocation = storeDLocationList.ElementAt(storeDLocationList.Count - 1);
                //不包含下面的标注
                //DoorRectangle.writeDimension(dxf, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y - 6, rightFirstDLocation.Z), rightFirstDLocation, 16, 3, 8, "right");
                DoorRectangle.writeDimension(dxf, rightFirstDLocation, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + 11, rightFirstDLocation.Z), 16, 3, 8, "right");
                DoorRectangle.writeDimension(dxf, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + 11, rightFirstDLocation.Z), new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + 33, rightFirstDLocation.Z), 16, 3, 8, "right");
                DoorRectangle.writeDimension(dxf, rightFirstDLocation, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + height, rightFirstDLocation.Z), 16, 3, 15, "right");
                DoorRectangle.writeDimension(dxf, new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y, rightFirstDLocation.Z), new DLocation(rightFirstDLocation.X, rightFirstDLocation.Y + height, rightFirstDLocation.Z), 16, 3, 23, "right");
            }
        }

      //上下层组装和单层组装函数
        public static void assembleDetailMechine(List<PictureBoxInfo> imageNameList, DxfModel dxf, DLocation DLocation, DetailMechineConfigure dmc,int coolingType)
        {
            if (isTwoLayers(imageNameList))
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
                            realPictureBox.DLocation = new DLocation(imageNameList.ElementAt(i).DLocation.X,imageNameList.ElementAt(i).DLocation.Y+113+4,imageNameList.ElementAt(i).DLocation.Z);
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
                //判断上下层进行判断
                if (oneImageNameList.Count > 0 && twoImageNameList.Count > 0)
                {
                    //这里的DLocation.Y 是前台组图的Y坐标，他和dxf的启示坐标刚好相反，在左上角
                    if (oneImageNameList.ElementAt(0).DLocation.Y <twoImageNameList.ElementAt(0).DLocation.Y)
                    {
                        //下层
                        assembleDetailMechine(twoImageNameList, dxf, DLocation, dmc.DxfText, dmc.height, dmc.width,dmc.outer_mid_space,dmc.outer_in_space, dmc.barHeight, dmc.barWidth,"downLayer");
                        writeTopOrBottomDimension(storeDLocationList,dxf,"bottom");
                        writeRightDimension(storeDLocationList, dxf, dmc.height, "rightDownLayer");
                        //上层
                        DLocation upDLocation = TotalWidthAndHeight.getUpLayerDLocation(twoImageNameList, oneImageNameList, coolingType);
                        assembleDetailMechine(oneImageNameList, dxf, new DLocation(DLocation.X+upDLocation.X,DLocation.Y+upDLocation.Y,DLocation.Z), dmc.DxfText, dmc.height, dmc.width, dmc.outer_mid_space,dmc.outer_in_space, dmc.barHeight, dmc.barWidth,"upLayer");
                        writeRightDimension(storeDLocationList, dxf, dmc.height, "rightUpLayer");
                    }
                    else
                    {
                        //下层
                        assembleDetailMechine(oneImageNameList, dxf, DLocation, dmc.DxfText, dmc.height, dmc.width, dmc.outer_mid_space, dmc.outer_in_space, dmc.barHeight, dmc.barWidth,"upLayer");
                        writeTopOrBottomDimension(storeDLocationList, dxf, "bottom");
                        writeRightDimension(storeDLocationList, dxf, dmc.height, "rightDownLayer");
                        //上层
                        DLocation upDLocation = TotalWidthAndHeight.getUpLayerDLocation(oneImageNameList,twoImageNameList, coolingType);
                        assembleDetailMechine(twoImageNameList, dxf, new DLocation(DLocation.X + upDLocation.X, DLocation.Y + upDLocation.Y, DLocation.Z), dmc.DxfText, dmc.height, dmc.width, dmc.outer_mid_space, dmc.outer_in_space, dmc.barHeight, dmc.barWidth,"upLayer");
                        writeRightDimension(storeDLocationList, dxf, dmc.height, "rightUpLayer");
                    }
                }
            }
                //单层情况
            else
            {
                assembleDetailMechine(imageNameList, dxf, DLocation, dmc.DxfText, dmc.height, dmc.width, dmc.outer_mid_space,dmc.outer_in_space, dmc.barHeight, dmc.barWidth,"downLayer");
                writeTopOrBottomDimension(storeDLocationList, dxf, "bottom");
                writeRightDimension(storeDLocationList, dxf, dmc.height, "rightDownLayer");
            } 
        }

      //判断是否要花双层
        public static Boolean isTwoLayers(List<PictureBoxInfo> imageNameList)
        {
            double flag=0;
            for (int i = 0, len = imageNameList.Count; i < len;i++ )
            {
                if (i == 0)
                {
                    flag = imageNameList.ElementAt(i).DLocation.Y;
                }
                if (flag != imageNameList.ElementAt(i).DLocation.Y)
                {
                    //为双层返回true
                    return true;
                }
            }
            return false;
        }
      
      //返回上下层中最长的列表
        public static List<PictureBoxInfo> getUpOrDownPictrueBoxInfoList(List<PictureBoxInfo> pictrueBoxInfoList)
        {

            if (isTwoLayers(pictrueBoxInfoList))
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
