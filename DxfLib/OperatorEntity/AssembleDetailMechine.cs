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

        public static void assembleDetailMechine(List<PictureBoxInfo> imageNameList,DxfDocument dxf, Location location, string[] text, float height, float width, float outer_mid_space, float outer_in_space, float barHeight, float barWidth)
        {
            List<Location> storeLocationList = new List<Location>();
            for (int i = 0; i < imageNameList.Count; i++)
            {
                string imageName=imageNameList.ElementAt(i).name;
                if(i==0)
                //if (imageName.Equals("singledoor"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeWholeSingleDoor(dxf,location,text,height,width,outer_mid_space,outer_in_space,barHeight,barWidth);
                        storeLocationList.Add(location);
                        storeLocationList.Add(new Location(location.X + width, location.Y, location.Z));
                    }
                    else
                    {
                        Location currentLocation = storeLocationList.ElementAt(i);
                        DoorRectangle.writeWholeSingleDoor(dxf, currentLocation, text, DoorInitHeightAndWidth.sinlgeheight, DoorInitHeightAndWidth.singlewidth, outer_mid_space, outer_in_space, barHeight, barWidth);
                        storeLocationList.Add(new Location(currentLocation.X + DoorInitHeightAndWidth.singlewidth, currentLocation.Y, currentLocation.Z));
                    }
                }
                else if(i==1)
               // else if(imageName.Equals("doublerectangle"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeWholeMachine(dxf, location, text, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
                        storeLocationList.Add(location);
                        storeLocationList.Add(new Location(location.X + width, location.Y, location.Z));
                    }
                    else
                    {
                        Location currentLocation = storeLocationList.ElementAt(i);
                        DoorRectangle.writeWholeMachine(dxf, currentLocation, text, DoorInitHeightAndWidth.doubleheight, DoorInitHeightAndWidth.doublewidth, outer_mid_space, outer_in_space, barHeight, barWidth);
                        storeLocationList.Add(new Location(currentLocation.X + DoorInitHeightAndWidth.doublewidth, currentLocation.Y, currentLocation.Z));
                    }
                }
                else if(i>1)
               // else if(imageName.Equals("doubledoor"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeWholeDoubleDoor(dxf, location, text, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
                        storeLocationList.Add(location);
                        storeLocationList.Add(new Location(location.X + width, location.Y, location.Z));
                    }
                    else
                    {
                        Location currentLocation = storeLocationList.ElementAt(i);
                        DoorRectangle.writeWholeDoubleDoor(dxf, currentLocation, text, DoorInitHeightAndWidth.doubledoorheigt, DoorInitHeightAndWidth.doubledoorwidth, outer_mid_space, outer_in_space, barHeight, barWidth);
                        storeLocationList.Add(new Location(currentLocation.X + DoorInitHeightAndWidth.doubledoorwidth, location.Y, location.Z));
                    }
                }
            }

            //画标注
            Location firstLocation=location;
            Location secondLocation=new Location(location.X,location.Y+6,location.Z);
            DoorRectangle.writeDimension(dxf, location, secondLocation, 16, 3, 8, "left");
            DoorRectangle.writeDimension(dxf, secondLocation, new Location(secondLocation.X, secondLocation.Y + 32, secondLocation.Z), 16, 3, 8, "left");

            //右边标注
            Location rightFirstLocation = storeLocationList.ElementAt(storeLocationList.Count - 1);
            DoorRectangle.writeDimension(dxf, new Location(rightFirstLocation.X, rightFirstLocation.Y - 6, rightFirstLocation.Z), rightFirstLocation, 16, 3, 8, "right");
            DoorRectangle.writeDimension(dxf, rightFirstLocation, new Location(rightFirstLocation.X, rightFirstLocation.Y + 11, rightFirstLocation.Z), 16, 3, 8, "right");
            DoorRectangle.writeDimension(dxf, new Location(rightFirstLocation.X, rightFirstLocation.Y + 11, rightFirstLocation.Z),new Location(rightFirstLocation.X, rightFirstLocation.Y + 33, rightFirstLocation.Z),16, 3, 8, "right");
            DoorRectangle.writeDimension(dxf, rightFirstLocation, new Location(rightFirstLocation.X, rightFirstLocation.Y + height, rightFirstLocation.Z), 16, 3, 15, "right");
            DoorRectangle.writeDimension(dxf, new Location(rightFirstLocation.X, rightFirstLocation.Y - 6, rightFirstLocation.Z), new Location(rightFirstLocation.X, rightFirstLocation.Y + height, rightFirstLocation.Z), 16, 3, 23, "right");



            for (int i = 0; i < storeLocationList.Count-1; i++)
            {
                Location tempFirstLocation=storeLocationList.ElementAt(i);
                Location tempSecondLocation=storeLocationList.ElementAt(i+1);
               
                    DoorRectangle.writeDimension(dxf, tempFirstLocation, tempSecondLocation, 16, 3, 10, "bottom");
                
               
            }

            DoorRectangle.writeDimension(dxf, storeLocationList.ElementAt(0), storeLocationList.ElementAt(storeLocationList.Count - 1), 16, 3, 15, "bottom");


        }

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
                    if (oneImageNameList.ElementAt(0).location.Y > twoImageNameList.ElementAt(0).location.Y)
                    {
                        //下层
                        assembleDetailMechine(twoImageNameList, dxf, location, dmc.text, dmc.height, dmc.width, dmc.outer_mid_space, dmc.outer_mid_space, dmc.barHeight, dmc.barWidth);
                        //上层
                        Location upLocation = TotalWidthAndHeight.getUpLayerLocation(twoImageNameList, oneImageNameList, coolingType);
                        assembleDetailMechine(oneImageNameList, dxf, new Location(location.X+upLocation.X,location.Y+upLocation.Y,location.Z), dmc.text, dmc.height, dmc.width, dmc.outer_mid_space, dmc.outer_mid_space, dmc.barHeight, dmc.barWidth);
                    }
                    else
                    {
                        //下层
                        assembleDetailMechine(oneImageNameList, dxf, location, dmc.text, dmc.height, dmc.width, dmc.outer_mid_space, dmc.outer_mid_space, dmc.barHeight, dmc.barWidth);
                        //上层
                        Location upLocation = TotalWidthAndHeight.getUpLayerLocation(twoImageNameList, oneImageNameList, coolingType);
                        assembleDetailMechine(twoImageNameList, dxf, new Location(location.X + upLocation.X, location.Y + upLocation.Y, location.Z), dmc.text, dmc.height, dmc.width, dmc.outer_mid_space, dmc.outer_mid_space, dmc.barHeight, dmc.barWidth);
                    }
                }
            }
                //单层情况
            else
            {
                assembleDetailMechine(imageNameList, dxf, location, dmc.text, dmc.height, dmc.width, dmc.outer_mid_space, dmc.outer_mid_space, dmc.barHeight, dmc.barWidth);
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
