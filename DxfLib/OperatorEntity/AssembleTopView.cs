using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using netDxf;
using Model.Zutu;

namespace DxfLib.OperatorEntity
{
  public  class AssembleTopView
    {

        public static void assembleTopView(List<PictureBoxInfo> imageNameList, DxfDocument dxf, Location location, string[] text, float height, float width, float outer_mid_space, float outer_in_space, float barHeight, float barWidth)
        {
            
            List<Location> storeLocationList=new List<Location>(); 
            for (int i = 0; i < imageNameList.Count; i++)
            {
                string imageName = imageNameList.ElementAt(i).name;
                if(i==0)
                //if (imageName.Equals("singledoor"))
                {
                    if (i == 0){
                        DoorRectangle.writeTopViewRectangle(dxf, location, text, height, width, outer_mid_space, outer_in_space);
                        storeLocationList.Add(location);
                        storeLocationList.Add(new Location(location.X+width,location.Y,location.Z));
                    }
                    else
                    {
                        Location currentLocation = storeLocationList.ElementAt(i);
                        DoorRectangle.writeTopViewRectangle(dxf, currentLocation, text, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
                        storeLocationList.Add(new Location(currentLocation.X+DoorInitHeightAndWidth.tvSingleWidth,currentLocation.Y,currentLocation.Z));
                    }
                }
                else if(i==1)
               // else if (imageName.Equals("doublerectangle"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, location, text, height, width, outer_mid_space, outer_in_space);
                        storeLocationList.Add(location);
                        storeLocationList.Add(new Location(location.X + width, location.Y, location.Z));
                    }
                    else
                    {
                        Location currentLocation =storeLocationList.ElementAt(i); ;
                        DoorRectangle.writeTopViewRectangle(dxf, currentLocation, text, DoorInitHeightAndWidth.tvDoubleHeight, DoorInitHeightAndWidth.tvDoubleWidth, outer_mid_space, outer_in_space);
                        storeLocationList.Add(new Location(currentLocation.X+DoorInitHeightAndWidth.tvDoubleWidth,currentLocation.Y,currentLocation.Z));
                    }
                }
                else if(i>1)
               // else if (imageName.Equals("doubledoor"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, location, text, height, width, outer_mid_space, outer_in_space);
                        storeLocationList.Add(location);
                        storeLocationList.Add(new Location(location.X + width, location.Y, location.Z));
                    }
                    else
                    {
                        Location currentLocation = storeLocationList.ElementAt(i); ;
                        DoorRectangle.writeTopViewRectangle(dxf, currentLocation, text, DoorInitHeightAndWidth.tvDoubleDoorHeigt, DoorInitHeightAndWidth.tvDoubleDoorWidth, outer_mid_space, outer_in_space);
                        storeLocationList.Add(new Location(currentLocation.X + DoorInitHeightAndWidth.tvDoubleDoorWidth, currentLocation.Y, currentLocation.Z));
                    }
                }
            }
            
            //画标注
            Location firstLocation=storeLocationList.ElementAt(0);
            DoorRectangle.writeDimension(dxf, new Location(firstLocation.X, firstLocation.Y - outer_in_space, firstLocation.Z), firstLocation, 16f, 1f, 5, "left");
            DoorRectangle.writeDimension(dxf, firstLocation, new Location(firstLocation.X,firstLocation.Y+5,firstLocation.Z), 16f, 1f, 5, "left");
            DoorRectangle.writeDimension(dxf, new Location(firstLocation.X, firstLocation.Y + 5, firstLocation.Z), new Location(firstLocation.X, firstLocation.Y + 45, firstLocation.Z), 16f, 1f, 8, "left");
            
            //top
            Location lastLocation = storeLocationList.ElementAt(storeLocationList.Count-1);
            DoorRectangle.writeDimension(dxf, new Location(firstLocation.X, firstLocation.Y + height, firstLocation.Z), new Location(lastLocation.X, lastLocation.Y + height, firstLocation.Z), 16f, 1f, 10, "top");
            
            //right
            DoorRectangle.writeDimension(dxf, new Location(lastLocation.X, lastLocation.Y + 10, firstLocation.Z), new Location(lastLocation.X, lastLocation.Y + 40, firstLocation.Z), 16f, 1f, 5f, "right");
            DoorRectangle.writeDimension(dxf, new Location(lastLocation.X, lastLocation.Y , firstLocation.Z), new Location(lastLocation.X, lastLocation.Y + 10, firstLocation.Z), 16f, 1f, 5f, "right");
            DoorRectangle.writeDimension(dxf, new Location(lastLocation.X, lastLocation.Y, firstLocation.Z), new Location(lastLocation.X, lastLocation.Y + height, firstLocation.Z), 16f, 1f, 10f, "right");
            DoorRectangle.writeDimension(dxf, new Location(lastLocation.X, lastLocation.Y-6, firstLocation.Z), new Location(lastLocation.X, lastLocation.Y , firstLocation.Z), 16f, 1f, 10f, "right");
            DoorRectangle.writeDimension(dxf, new Location(lastLocation.X, lastLocation.Y - 6, firstLocation.Z), new Location(lastLocation.X, lastLocation.Y+height+outer_in_space, firstLocation.Z), 16f, 1f, 14f, "right");
        }

        public static void assembleTopView(List<PictureBoxInfo> imageNameList, DxfDocument dxf, Location location,TopViewConfigure tvc)
        {
            assembleTopView(imageNameList, dxf, location, tvc.text, tvc.height, tvc.width, tvc.outer_mid_space, tvc.outer_mid_space, tvc.barHeight, tvc.barWidth);
        }
    }
}
