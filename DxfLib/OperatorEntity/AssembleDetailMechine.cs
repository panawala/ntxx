using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using netDxf;
using Model.Zutu;
namespace DxfLib.OperatorEntity
{
  public  class AssembleDetailMechine
    {
       private static List<Location> storeLocationList=new List<Location>();
        public static void assembleDetailMechine(List<PictureBoxInfo> imageNameList,DxfDocument dxf, Location location, string[] text, float height, float width, float outer_mid_space, float outer_in_space, float barHeight, float barWidth,string upOrDownLayer)
        {
            //List<Location> storeLocationList = new List<Location>();
            if (storeLocationList.Count > 0)
            {
                storeLocationList.Clear();
            }
            for (int i = 0; i < imageNameList.Count; i++)
            {
                string imageName=imageNameList.ElementAt(i).name;
                if(i==0)
                //if (imageName.Equals("singledoor"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeWholeSingleDoor(dxf, location, text, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeLocationList.Add(location);
                        storeLocationList.Add(new Location(location.X + width, location.Y, location.Z));
                    }
                    else
                    {
                        Location currentLocation = storeLocationList.ElementAt(i);
                        DoorRectangle.writeWholeSingleDoor(dxf, currentLocation, text, DoorInitHeightAndWidth.sinlgeheight, DoorInitHeightAndWidth.singlewidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeLocationList.Add(new Location(currentLocation.X + DoorInitHeightAndWidth.singlewidth, currentLocation.Y, currentLocation.Z));
                    }
                }
                else if(i==1)
               // else if(imageName.Equals("doublerectangle"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeWholeMachine(dxf, location, text, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeLocationList.Add(location);
                        storeLocationList.Add(new Location(location.X + width, location.Y, location.Z));
                    }
                    else
                    {
                        Location currentLocation = storeLocationList.ElementAt(i);
                        DoorRectangle.writeWholeMachine(dxf, currentLocation, text, DoorInitHeightAndWidth.doubleheight, DoorInitHeightAndWidth.doublewidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeLocationList.Add(new Location(currentLocation.X + DoorInitHeightAndWidth.doublewidth, currentLocation.Y, currentLocation.Z));
                    }
                }
                else if(i>1)
               // else if(imageName.Equals("doubledoor"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeWholeDoubleDoor(dxf, location, text, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeLocationList.Add(location);
                        storeLocationList.Add(new Location(location.X + width, location.Y, location.Z));
                    }
                    else
                    {
                        Location currentLocation = storeLocationList.ElementAt(i);
                        DoorRectangle.writeWholeDoubleDoor(dxf, currentLocation, text, DoorInitHeightAndWidth.doubledoorheigt, DoorInitHeightAndWidth.doubledoorwidth, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);
                        storeLocationList.Add(new Location(currentLocation.X + DoorInitHeightAndWidth.doubledoorwidth, location.Y, location.Z));
                    }
                }
            }

            //画标注
            Location firstLocation=location;
            Location secondLocation=new Location(location.X,location.Y+6,location.Z);
            DoorRectangle.writeDimension(dxf, location, secondLocation, 16, 3, 8, "left");
            DoorRectangle.writeDimension(dxf, secondLocation, new Location(secondLocation.X, secondLocation.Y + 32, secondLocation.Z), 16, 3, 8, "left");
        }

      //风中top或bottom的dimension
        public static void writeTopOrBottomDimension(List<Location> storeLocationList,DxfDocument dxf,string topOrBottom)
        {
            for (int i = 0; i < storeLocationList.Count - 1; i++)
            {
                Location tempFirstLocation = storeLocationList.ElementAt(i);
                Location tempSecondLocation = storeLocationList.ElementAt(i + 1);

                DoorRectangle.writeDimension(dxf, tempFirstLocation, tempSecondLocation, 16, 3, 10, topOrBottom);

            }

            DoorRectangle.writeDimension(dxf, storeLocationList.ElementAt(0), storeLocationList.ElementAt(storeLocationList.Count - 1), 16, 3, 15, topOrBottom);
        }

      //封装中right的dimension
        public static void writeRightDimension(List<Location> storeLocationList,DxfDocument dxf,float height,string upOrDownRightDimension)
        {
            if(upOrDownRightDimension.Equals("rightDownLayer")){
                //下层右边标注
                Location rightFirstLocation = storeLocationList.ElementAt(storeLocationList.Count - 1);
                DoorRectangle.writeDimension(dxf, new Location(rightFirstLocation.X, rightFirstLocation.Y - 6, rightFirstLocation.Z), rightFirstLocation, 16, 3, 8, "right");
                DoorRectangle.writeDimension(dxf, rightFirstLocation, new Location(rightFirstLocation.X, rightFirstLocation.Y + 11, rightFirstLocation.Z), 16, 3, 8, "right");
                DoorRectangle.writeDimension(dxf, new Location(rightFirstLocation.X, rightFirstLocation.Y + 11, rightFirstLocation.Z), new Location(rightFirstLocation.X, rightFirstLocation.Y + 33, rightFirstLocation.Z), 16, 3, 8, "right");
                DoorRectangle.writeDimension(dxf, rightFirstLocation, new Location(rightFirstLocation.X, rightFirstLocation.Y + height, rightFirstLocation.Z), 16, 3, 15, "right");
                DoorRectangle.writeDimension(dxf, new Location(rightFirstLocation.X, rightFirstLocation.Y - 6, rightFirstLocation.Z), new Location(rightFirstLocation.X, rightFirstLocation.Y + height, rightFirstLocation.Z), 16, 3, 23, "right");
            }
            else if(upOrDownRightDimension.Equals("rightUpLayer")){
                //上层右边标注
                Location rightFirstLocation = storeLocationList.ElementAt(storeLocationList.Count - 1);
                //不包含下面的标注
                //DoorRectangle.writeDimension(dxf, new Location(rightFirstLocation.X, rightFirstLocation.Y - 6, rightFirstLocation.Z), rightFirstLocation, 16, 3, 8, "right");
                DoorRectangle.writeDimension(dxf, rightFirstLocation, new Location(rightFirstLocation.X, rightFirstLocation.Y + 11, rightFirstLocation.Z), 16, 3, 8, "right");
                DoorRectangle.writeDimension(dxf, new Location(rightFirstLocation.X, rightFirstLocation.Y + 11, rightFirstLocation.Z), new Location(rightFirstLocation.X, rightFirstLocation.Y + 33, rightFirstLocation.Z), 16, 3, 8, "right");
                DoorRectangle.writeDimension(dxf, rightFirstLocation, new Location(rightFirstLocation.X, rightFirstLocation.Y + height, rightFirstLocation.Z), 16, 3, 15, "right");
                DoorRectangle.writeDimension(dxf, new Location(rightFirstLocation.X, rightFirstLocation.Y, rightFirstLocation.Z), new Location(rightFirstLocation.X, rightFirstLocation.Y + height, rightFirstLocation.Z), 16, 3, 23, "right");
            }
        }

      //上下层组装和单层组装函数
        public static void assembleDetailMechine(List<PictureBoxInfo> imageNameList, DxfDocument dxf, Location location, DetailMechineConfigure dmc,int coolingType)
        {
            if (isTwoLayers(imageNameList))
            {
                List<PictureBoxInfo> oneImageNameList = new List<PictureBoxInfo>();
                List<PictureBoxInfo> twoImageNameList = new List<PictureBoxInfo>();
                for (int i = 0, len = imageNameList.Count; i < len; i++)
                {
                    if (i == 0)
                    {
                        oneImageNameList.Add(imageNameList.ElementAt(i));
                    }
                    else
                    {
                        if (oneImageNameList.ElementAt(0).location.Y == imageNameList.ElementAt(i).location.Y)
                        {
                            oneImageNameList.Add(imageNameList.ElementAt(i));
                        }
                        else
                        {
                            twoImageNameList.Add(imageNameList.ElementAt(i));
                        }
                    }
                }
                //判断上下层进行判断
                if (oneImageNameList.Count > 0 && twoImageNameList.Count > 0)
                {
                    //这里的location.Y 是前台组图的Y坐标，他和dxf的启示坐标刚好相反，在左上角
                    if (oneImageNameList.ElementAt(0).location.Y <twoImageNameList.ElementAt(0).location.Y)
                    {
                        //下层
                        assembleDetailMechine(twoImageNameList, dxf, location, dmc.text, dmc.height, dmc.width,dmc.outer_mid_space,dmc.outer_in_space, dmc.barHeight, dmc.barWidth,"downLayer");
                        writeTopOrBottomDimension(storeLocationList,dxf,"bottom");
                        writeRightDimension(storeLocationList, dxf, dmc.height, "rightDownLayer");
                        //上层
                        Location upLocation = TotalWidthAndHeight.getUpLayerLocation(twoImageNameList, oneImageNameList, coolingType);
                        assembleDetailMechine(oneImageNameList, dxf, new Location(location.X+upLocation.X,location.Y+upLocation.Y,location.Z), dmc.text, dmc.height, dmc.width, dmc.outer_mid_space,dmc.outer_in_space, dmc.barHeight, dmc.barWidth,"upLayer");
                        writeRightDimension(storeLocationList, dxf, dmc.height, "rightUpLayer");
                    }
                    else
                    {
                        //下层
                        assembleDetailMechine(oneImageNameList, dxf, location, dmc.text, dmc.height, dmc.width, dmc.outer_mid_space, dmc.outer_in_space, dmc.barHeight, dmc.barWidth,"upLayer");
                        writeTopOrBottomDimension(storeLocationList, dxf, "bottom");
                        writeRightDimension(storeLocationList, dxf, dmc.height, "rightDownLayer");
                        //上层
                        Location upLocation = TotalWidthAndHeight.getUpLayerLocation(oneImageNameList,twoImageNameList, coolingType);
                        assembleDetailMechine(twoImageNameList, dxf, new Location(location.X + upLocation.X, location.Y + upLocation.Y, location.Z), dmc.text, dmc.height, dmc.width, dmc.outer_mid_space, dmc.outer_in_space, dmc.barHeight, dmc.barWidth,"upLayer");
                        writeRightDimension(storeLocationList, dxf, dmc.height, "rightUpLayer");
                    }
                }
            }
                //单层情况
            else
            {
                assembleDetailMechine(imageNameList, dxf, location, dmc.text, dmc.height, dmc.width, dmc.outer_mid_space,dmc.outer_in_space, dmc.barHeight, dmc.barWidth,"downLayer");
                writeTopOrBottomDimension(storeLocationList, dxf, "bottom");
                writeRightDimension(storeLocationList, dxf, dmc.height, "rightDownLayer");
            } 
        }

      //判断是否要花双层
        public static Boolean isTwoLayers(List<PictureBoxInfo> imageNameList)
        {
            float flag=0;
            for (int i = 0, len = imageNameList.Count; i < len;i++ )
            {
                if (i == 0)
                {
                    flag = imageNameList.ElementAt(i).location.Y;
                }
                if (flag != imageNameList.ElementAt(i).location.Y)
                {
                    //为双层返回true
                    return true;
                }
            }
            return false;
        }
      

     }
}
