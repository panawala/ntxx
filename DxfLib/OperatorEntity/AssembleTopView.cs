using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using netDxf;
using Model.Zutu;

namespace DxfLib.OperatorEntity
{
    public class AssembleTopView
    {

        public static void assembleTopView(List<PictureBoxInfo> imageNameList, DxfDocument dxf, Location location, string[] text, float height, float width, float outer_mid_space, float outer_in_space, float barHeight, float barWidth)
        {

            List<Location> storeLocationList = new List<Location>();
            for (int i = 0; i < imageNameList.Count; i++)
            {
                string imageName = imageNameList.ElementAt(i).name;
                if (imageName.Equals("FTA") || imageName.Equals("FTC") || imageName.Equals("FTF") || imageName.Equals("FTH"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, location, text, height, width, outer_mid_space, outer_in_space);
                        storeLocationList.Add(location);
                        storeLocationList.Add(new Location(location.X + width, location.Y, location.Z));
                    }
                    else
                    {
                        Location currentLocation = storeLocationList.ElementAt(i);
                        DoorRectangle.writeTopViewRectangle(dxf, currentLocation, text, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
                        storeLocationList.Add(new Location(currentLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentLocation.Y, currentLocation.Z));
                    }
                }
                else if (imageName.Equals("MBA") || imageName.Equals("MBB") || imageName.Equals("MBC") || imageName.Equals("MBD") || imageName.Equals("MBE") || imageName.Equals("MBF") || imageName.Equals("MBG") || imageName.Equals("MBH") || imageName.Equals("MBI") || imageName.Equals("MBJ") || imageName.Equals("MBK"))
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
                        DoorRectangle.writeTopViewRectangle(dxf, currentLocation, text, DoorInitHeightAndWidth.tvDoubleHeight, DoorInitHeightAndWidth.tvDoubleWidth, outer_mid_space, outer_in_space);
                        storeLocationList.Add(new Location(currentLocation.X + DoorInitHeightAndWidth.tvDoubleWidth, currentLocation.Y, currentLocation.Z));
                    }
                }
                else if (imageName.Equals("PHA") || imageName.Equals("PHB") || imageName.Equals("PHC") || imageName.Equals("PHD"))
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
                else if (imageName.Equals("HRA"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, location, text, height, width, outer_mid_space, outer_in_space);
                        storeLocationList.Add(location);
                        storeLocationList.Add(new Location(location.X + width, location.Y, location.Z));
                    }
                    else
                    {
                        Location currentLocation = storeLocationList.ElementAt(i);
                        DoorRectangle.writeTopViewRectangle(dxf, currentLocation, text, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
                        storeLocationList.Add(new Location(currentLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentLocation.Y, currentLocation.Z));
                    }
                }
                else if (imageName.Equals("virtualHRA"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, location, text, height, width, outer_mid_space, outer_in_space);
                        storeLocationList.Add(location);
                        storeLocationList.Add(new Location(location.X + width, location.Y, location.Z));
                    }
                    else
                    {
                        Location currentLocation = storeLocationList.ElementAt(i);
                        DoorRectangle.writeTopViewRectangle(dxf, currentLocation, text, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
                        storeLocationList.Add(new Location(currentLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentLocation.Y, currentLocation.Z));
                    }
                }
                else if (imageName.Equals("CLB") || imageName.Equals("CLC") || imageName.Equals("CLF") || imageName.Equals("CLG") || imageName.Equals("CLI") || imageName.Equals("CLM"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, location, text, height, width, outer_mid_space, outer_in_space);
                        storeLocationList.Add(location);
                        storeLocationList.Add(new Location(location.X + width, location.Y, location.Z));
                    }
                    else
                    {
                        Location currentLocation = storeLocationList.ElementAt(i);
                        DoorRectangle.writeTopViewRectangle(dxf, currentLocation, text, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
                        storeLocationList.Add(new Location(currentLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentLocation.Y, currentLocation.Z));
                    }
                }
                else if (imageName.Equals("PEA") || imageName.Equals("PEC") || imageName.Equals("RFA") || imageName.Equals("SFA") || imageName.Equals("SFC") || imageName.Equals("SFD"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, location, text, height, width, outer_mid_space, outer_in_space);
                        storeLocationList.Add(location);
                        storeLocationList.Add(new Location(location.X + width, location.Y, location.Z));
                    }
                    else
                    {
                        Location currentLocation = storeLocationList.ElementAt(i);
                        DoorRectangle.writeTopViewRectangle(dxf, currentLocation, text, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
                        storeLocationList.Add(new Location(currentLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentLocation.Y, currentLocation.Z));
                    }
                }
                else if (imageName.Equals("BBA") || imageName.Equals("BBB") || imageName.Equals("BBC") || imageName.Equals("BBD") || imageName.Equals("BBE"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, location, text, height, width, outer_mid_space, outer_in_space);
                        storeLocationList.Add(location);
                        storeLocationList.Add(new Location(location.X + width, location.Y, location.Z));
                    }
                    else
                    {
                        Location currentLocation = storeLocationList.ElementAt(i);
                        DoorRectangle.writeTopViewRectangle(dxf, currentLocation, text, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
                        storeLocationList.Add(new Location(currentLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentLocation.Y, currentLocation.Z));
                    }
                }
                else if (imageName.Equals("TRA") || imageName.Equals("TRB") || imageName.Equals("TRC") || imageName.Equals("TRD") || imageName.Equals("TRE"))
                {
                    if (i == 0)
                    {
                        DoorRectangle.writeTopViewRectangle(dxf, location, text, height, width, outer_mid_space, outer_in_space);
                        storeLocationList.Add(location);
                        storeLocationList.Add(new Location(location.X + width, location.Y, location.Z));
                    }
                    else
                    {
                        Location currentLocation = storeLocationList.ElementAt(i);
                        DoorRectangle.writeTopViewRectangle(dxf, currentLocation, text, DoorInitHeightAndWidth.tvSinlgeHeight, DoorInitHeightAndWidth.tvSingleWidth, outer_mid_space, outer_in_space);
                        storeLocationList.Add(new Location(currentLocation.X + DoorInitHeightAndWidth.tvSingleWidth, currentLocation.Y, currentLocation.Z));
                    }
                }
            }

            //画标注
            Location firstLocation = storeLocationList.ElementAt(0);
            DoorRectangle.writeDimension(dxf, new Location(firstLocation.X, firstLocation.Y - outer_in_space, firstLocation.Z), firstLocation, 16f, 1f, 5, "left");
            DoorRectangle.writeDimension(dxf, firstLocation, new Location(firstLocation.X, firstLocation.Y + 5, firstLocation.Z), 16f, 1f, 5, "left");
            DoorRectangle.writeDimension(dxf, new Location(firstLocation.X, firstLocation.Y + 5, firstLocation.Z), new Location(firstLocation.X, firstLocation.Y + 45, firstLocation.Z), 16f, 1f, 8, "left");

            //top
            Location lastLocation = storeLocationList.ElementAt(storeLocationList.Count - 1);
            DoorRectangle.writeDimension(dxf, new Location(firstLocation.X, firstLocation.Y + height, firstLocation.Z), new Location(lastLocation.X, lastLocation.Y + height, firstLocation.Z), 16f, 1f, 10, "top");

            //right
            DoorRectangle.writeDimension(dxf, new Location(lastLocation.X, lastLocation.Y + 10, firstLocation.Z), new Location(lastLocation.X, lastLocation.Y + 40, firstLocation.Z), 16f, 1f, 5f, "right");
            DoorRectangle.writeDimension(dxf, new Location(lastLocation.X, lastLocation.Y, firstLocation.Z), new Location(lastLocation.X, lastLocation.Y + 10, firstLocation.Z), 16f, 1f, 5f, "right");
            DoorRectangle.writeDimension(dxf, new Location(lastLocation.X, lastLocation.Y, firstLocation.Z), new Location(lastLocation.X, lastLocation.Y + height, firstLocation.Z), 16f, 1f, 10f, "right");
            DoorRectangle.writeDimension(dxf, new Location(lastLocation.X, lastLocation.Y - 6, firstLocation.Z), new Location(lastLocation.X, lastLocation.Y, firstLocation.Z), 16f, 1f, 10f, "right");
            DoorRectangle.writeDimension(dxf, new Location(lastLocation.X, lastLocation.Y - 6, firstLocation.Z), new Location(lastLocation.X, lastLocation.Y + height + outer_in_space, firstLocation.Z), 16f, 1f, 14f, "right");
        }

        public static void assembleTopView(List<PictureBoxInfo> imageNameList, DxfDocument dxf, Location location, TopViewConfigure tvc)
        {
            if (AssembleDetailMechine.isTwoLayers(imageNameList))
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
                            //virtualPictureBox.location = new Location(imageNameList.ElementAt(i).location.X, imageNameList.ElementAt(i).location.Y + 113 + 4, imageNameList.ElementAt(i).location.Z);
                            virtualPictureBox.location = new Location(imageNameList.ElementAt(i).location.X, imageNameList.ElementAt(i).location.Y, imageNameList.ElementAt(i).location.Z);
                            oneImageNameList.Add(virtualPictureBox);
                            PictureBoxInfo realPictureBox = new PictureBoxInfo();
                            realPictureBox.name = imageNameList.ElementAt(i).name;
                            realPictureBox.location = new Location(imageNameList.ElementAt(i).location.X, imageNameList.ElementAt(i).location.Y + 113 + 4, imageNameList.ElementAt(i).location.Z);
                            twoImageNameList.Add(realPictureBox);
                        }
                        else
                        {
                            oneImageNameList.Add(imageNameList.ElementAt(i));
                        }
                    }
                    else
                    {
                        if (oneImageNameList.ElementAt(0).location.Y == imageNameList.ElementAt(i).location.Y)
                        {

                            if (imageNameList.ElementAt(i).name.Equals("HRA"))
                            {
                                PictureBoxInfo virtualPictureBox = new PictureBoxInfo();
                                virtualPictureBox.name = "virtualHRA";
                                virtualPictureBox.location = new Location(imageNameList.ElementAt(i).location.X, imageNameList.ElementAt(i).location.Y + 113 + 4, imageNameList.ElementAt(i).location.Z);
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
                                virtualPictureBox.location = new Location(imageNameList.ElementAt(i).location.X, imageNameList.ElementAt(i).location.Y + 113 + 4, imageNameList.ElementAt(i).location.Z);
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
                    assembleTopView(oneImageNameList, dxf, location, tvc.text, tvc.height, tvc.width, tvc.outer_mid_space, tvc.outer_in_space, tvc.barHeight, tvc.barWidth);
                }
                else
                {
                    assembleTopView(twoImageNameList, dxf, location, tvc.text, tvc.height, tvc.width, tvc.outer_mid_space, tvc.outer_in_space, tvc.barHeight, tvc.barWidth);
                }
            }
            else
            {
                assembleTopView(imageNameList, dxf, location, tvc.text, tvc.height, tvc.width, tvc.outer_mid_space, tvc.outer_in_space, tvc.barHeight, tvc.barWidth);
            }
        }
    }
}
