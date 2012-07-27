
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Model.Zutu;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Math;
namespace CadLib.OperatorEntity
{
    class DoorRectangle
    {
        //画无门栓的矩形框
        public static void writeDoorRectangle(DxfModel doc, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space)
        {
            //最外围矩形
            writeOuterDoorRectangle(doc,DLocation,height,width);
            //中间矩形
            DxfLine midBottomDxfLine=new DxfLine(new Point3D(DLocation.X+outer_mid_space,DLocation.Y+outer_mid_space,DLocation.Z),new Point3D(DLocation.X+width-outer_mid_space,DLocation.Y+outer_mid_space,DLocation.Z));
            DxfLine midLeftDxfLine=new DxfLine(new Point3D(DLocation.X+outer_mid_space,DLocation.Y+outer_mid_space,DLocation.Z),new Point3D(DLocation.X+outer_mid_space,DLocation.Y+height-outer_mid_space,DLocation.Z));
            DxfLine midTopDxfLine=new DxfLine(new Point3D(DLocation.X+outer_mid_space,DLocation.Y+height-outer_mid_space,DLocation.Z),new Point3D(DLocation.X+width-outer_mid_space,DLocation.Y+height-outer_mid_space,DLocation.Z));
            DxfLine midRightDxfLine = new DxfLine(new Point3D(DLocation.X + width - outer_mid_space, DLocation.Y + height - outer_mid_space, DLocation.Z), new Point3D(DLocation.X + width - outer_mid_space, DLocation.Y + outer_mid_space, DLocation.Z));

            doc.Entities.Add(midBottomDxfLine);
            doc.Entities.Add(midLeftDxfLine);
            doc.Entities.Add(midTopDxfLine);
            doc.Entities.Add(midRightDxfLine);

            //内部矩形
            DxfLine inBottomDxfLine = new DxfLine(new Point3D(DLocation.X + outer_in_space, DLocation.Y + outer_in_space, DLocation.Z), new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + outer_in_space, DLocation.Z));
            DxfLine inLeftDxfLine = new DxfLine(new Point3D(DLocation.X + outer_in_space, DLocation.Y + outer_in_space, DLocation.Z), new Point3D(DLocation.X + outer_in_space, DLocation.Y + height - outer_in_space, DLocation.Z));
  
            DxfLine inTopDxfLine = new DxfLine(new Point3D(DLocation.X + outer_in_space, DLocation.Y + height - outer_in_space, DLocation.Z), new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + height - outer_in_space, DLocation.Z));
        
            DxfLine inRightDxfLine = new DxfLine(new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + height - outer_in_space, DLocation.Z), new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + outer_in_space, DLocation.Z));
    

            doc.Entities.Add(inBottomDxfLine);
            doc.Entities.Add(inLeftDxfLine);
            doc.Entities.Add(inTopDxfLine);
            doc.Entities.Add(inRightDxfLine);

            //门中文字
            double DxfTextHeight=DoorInitHeightAndWidth.DxfTextHeight;
            for(int i=0;i<DxfText.Length;i++){
                DxfText doorRectangleDxfText = new DxfText(DxfText[i], new Point3D(DLocation.X + width / 3, DLocation.Y + 3*height / 4- i * DxfTextHeight, DLocation.Z), DxfTextHeight);
                doc.Entities.Add(doorRectangleDxfText);
            }
        }
         //最外围矩形
        public static void writeOuterDoorRectangle(DxfModel doc, DLocation DLocation,double height, double width)
        {
            //最外围矩形
            DxfLine outerBottomDxfLine = new DxfLine(new Point3D(DLocation.X, DLocation.Y, DLocation.Z), new Point3D(DLocation.X + width, DLocation.Y, DLocation.Z));

            DxfLine outerLeftDxfLine = new DxfLine(new Point3D(DLocation.X, DLocation.Y, DLocation.Z), new Point3D(DLocation.X, DLocation.Y + height, DLocation.Z));

            DxfLine outerTopDxfLine = new DxfLine(new Point3D(DLocation.X, DLocation.Y + height, DLocation.Z), new Point3D(DLocation.X + width, DLocation.Y + height, DLocation.Z));

            DxfLine outerRightDxfLine = new DxfLine(new Point3D(DLocation.X + width, DLocation.Y + height, DLocation.Z), new Point3D(DLocation.X + width, DLocation.Y, DLocation.Z));


            doc.Entities.Add(outerBottomDxfLine);
            doc.Entities.Add(outerLeftDxfLine);
            doc.Entities.Add(outerTopDxfLine);
            doc.Entities.Add(outerRightDxfLine);
        }

        //画单门有门闩的矩形框
        public static void writeDoorBarRectangle(DxfModel doc, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space,double barHeight,double barWidth)
        {
            //最外围矩形
            writeOuterDoorRectangle(doc, DLocation, height, width);

            //中间矩形
            DxfLine midBottomDxfLine = new DxfLine(new Point3D(DLocation.X + outer_mid_space, DLocation.Y + outer_mid_space, DLocation.Z), new Point3D(DLocation.X + width - outer_mid_space, DLocation.Y + outer_mid_space, DLocation.Z));

            DxfLine midDownLeftDxfLine = new DxfLine(new Point3D(DLocation.X + outer_mid_space, DLocation.Y + outer_mid_space, DLocation.Z), new Point3D(DLocation.X + outer_mid_space, DLocation.Y + height / 4, DLocation.Z));

            DxfLine midMidLeftDxfLine = new DxfLine(new Point3D(DLocation.X + outer_mid_space, DLocation.Y + height / 4 + barHeight, DLocation.Z), new Point3D(DLocation.X + outer_mid_space, DLocation.Y + 3 * height / 4 - barHeight, DLocation.Z));

            DxfLine midUpLeftDxfLine = new DxfLine(new Point3D(DLocation.X + outer_mid_space, DLocation.Y + 3*height / 4, DLocation.Z), new Point3D(DLocation.X + outer_mid_space, DLocation.Y +height-outer_mid_space, DLocation.Z));

            DxfLine midTopDxfLine = new DxfLine(new Point3D(DLocation.X + outer_mid_space, DLocation.Y + height - outer_mid_space, DLocation.Z), new Point3D(DLocation.X + width - outer_mid_space, DLocation.Y + height - outer_mid_space, DLocation.Z));

            DxfLine midRightDxfLine = new DxfLine(new Point3D(DLocation.X + width - outer_mid_space, DLocation.Y + height - outer_mid_space, DLocation.Z), new Point3D(DLocation.X + width - outer_mid_space, DLocation.Y + outer_mid_space, DLocation.Z));
    

            doc.Entities.Add(midBottomDxfLine);
            doc.Entities.Add(midDownLeftDxfLine);
            doc.Entities.Add(midMidLeftDxfLine);
            doc.Entities.Add(midUpLeftDxfLine);
            doc.Entities.Add(midTopDxfLine);
            doc.Entities.Add(midRightDxfLine);

            //内部矩形
            
            DxfLine inBottomDxfLine = new DxfLine(new Point3D(DLocation.X + outer_in_space, DLocation.Y + outer_in_space, DLocation.Z), new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + outer_in_space, DLocation.Z));

            DxfLine inDownLeftDxfLine = new DxfLine(new Point3D(DLocation.X + outer_in_space, DLocation.Y + outer_in_space, DLocation.Z), new Point3D(DLocation.X + outer_in_space, DLocation.Y + height/4, DLocation.Z));
   
            DxfLine inmidLeftDxfLine = new DxfLine(new Point3D(DLocation.X + outer_in_space, DLocation.Y + height / 4 + barHeight, DLocation.Z), new Point3D(DLocation.X + outer_in_space, DLocation.Y + 3*height/4 - barHeight, DLocation.Z));

            DxfLine inUpLeftDxfLine = new DxfLine(new Point3D(DLocation.X + outer_in_space, DLocation.Y + 3*height / 4, DLocation.Z), new Point3D(DLocation.X + outer_in_space, DLocation.Y + height-outer_in_space, DLocation.Z));

            DxfLine inTopDxfLine = new DxfLine(new Point3D(DLocation.X + outer_in_space, DLocation.Y + height - outer_in_space, DLocation.Z), new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + height - outer_in_space, DLocation.Z));

            DxfLine inRightDxfLine = new DxfLine(new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + height - outer_in_space, DLocation.Z), new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + outer_in_space, DLocation.Z));
 

            doc.Entities.Add(inBottomDxfLine);
            doc.Entities.Add(inDownLeftDxfLine);
            doc.Entities.Add(inmidLeftDxfLine);
            doc.Entities.Add(inUpLeftDxfLine);
            doc.Entities.Add(inTopDxfLine);
            doc.Entities.Add(inRightDxfLine);

            //门中文字
            double DxfTextHeight = DoorInitHeightAndWidth.DxfTextHeight;
            for (int i = 0; i < DxfText.Length; i++)
            {
                DxfText doorRectangleDxfText = new DxfText(DxfText[i], new Point3D(DLocation.X + width / 3, DLocation.Y + 3 * height / 4 - i * DxfTextHeight, DLocation.Z), DxfTextHeight);

                doc.Entities.Add(doorRectangleDxfText);
            }

        }

        //画两个门无门闩的设备
        public static void writeDoubleDoorRectangle(DxfModel doc,DLocation DLocation,string [] DxfText,double height,double width,double outer_mid_space,double outer_in_space)
        {

            DxfLine outerLeftDxfLine=new DxfLine(new Point3D(DLocation.X+width/2-width/14,DLocation.Y+outer_mid_space,DLocation.Z),new Point3D(DLocation.X+width/2-width/14,DLocation.Y+height-outer_mid_space,DLocation.Z));
      
            DxfLine inLeftDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 - width / 14 + 0.5f, DLocation.Y + outer_in_space, DLocation.Z), new Point3D(DLocation.X + width / 2 - width / 14 + 0.5f, DLocation.Y + height - outer_in_space, DLocation.Z));
        
            DxfLine inRightDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 + width / 14, DLocation.Y + outer_in_space, DLocation.Z), new Point3D(DLocation.X + width / 2 + width / 14, DLocation.Y + height - outer_in_space, DLocation.Z));
       
            DxfLine outerRightDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 + width / 14 + 0.5f, DLocation.Y + outer_mid_space, DLocation.Z), new Point3D(DLocation.X + width / 2 + width / 14 + 0.5f, DLocation.Y + height - outer_mid_space, DLocation.Z));
    
            
            doc.Entities.Add(outerLeftDxfLine);
            doc.Entities.Add(inLeftDxfLine);
            doc.Entities.Add(inRightDxfLine);
            doc.Entities.Add(outerRightDxfLine);
            writeDoorRectangle(doc, DLocation,DxfText, height, width, outer_mid_space, outer_in_space);
        }

        //画两个门有门闩的设备
        public static void writeDoubleDoorBarRectangle(DxfModel doc, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space,double barHeight,double barWidth)
        {

            DxfLine outerLeftDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 - width / 14, DLocation.Y + outer_mid_space, DLocation.Z), new Point3D(DLocation.X + width / 2 - width / 14, DLocation.Y + height - outer_mid_space, DLocation.Z));
       
            DxfLine inLeftDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 - width / 14 + 0.5f, DLocation.Y + outer_in_space, DLocation.Z), new Point3D(DLocation.X + width / 2 - width / 14 + 0.5f, DLocation.Y + height - outer_in_space, DLocation.Z));
           
            DxfLine inDownRightDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 + width / 14, DLocation.Y + outer_in_space, DLocation.Z), new Point3D(DLocation.X + width / 2 + width / 14, DLocation.Y + height/4, DLocation.Z));
         
            DxfLine inMidRightDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 + width / 14, DLocation.Y + height / 4 + barHeight, DLocation.Z), new Point3D(DLocation.X + width / 2 + width / 14, DLocation.Y + 3 * height / 4 - barHeight, DLocation.Z));
    
            DxfLine inUpRightDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 + width / 14, DLocation.Y + 3*height / 4, DLocation.Z), new Point3D(DLocation.X + width / 2 + width / 14, DLocation.Y + height-outer_in_space, DLocation.Z));
    
            DxfLine outerDownRightDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 + width / 14 + 0.5f, DLocation.Y + outer_mid_space, DLocation.Z), new Point3D(DLocation.X + width / 2 + width / 14 + 0.5f, DLocation.Y + height/4, DLocation.Z));
 
            DxfLine outerMidRightDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 + width / 14 + 0.5f, DLocation.Y + height/4+barHeight, DLocation.Z), new Point3D(DLocation.X + width / 2 + width / 14 + 0.5f, DLocation.Y + 3*height / 4-barHeight, DLocation.Z));
     
            DxfLine outerUpRightDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 + width / 14 + 0.5f, DLocation.Y + 3*height / 4, DLocation.Z), new Point3D(DLocation.X + width / 2 + width / 14 + 0.5f, DLocation.Y + height-outer_in_space, DLocation.Z));
       

            doc.Entities.Add(outerLeftDxfLine);
            doc.Entities.Add(inLeftDxfLine);
            doc.Entities.Add(inDownRightDxfLine);
            doc.Entities.Add(inMidRightDxfLine);
            doc.Entities.Add(inUpRightDxfLine);
            doc.Entities.Add(outerDownRightDxfLine);
            doc.Entities.Add(outerMidRightDxfLine);
            doc.Entities.Add(outerUpRightDxfLine);
            writeDoorBarRectangle(doc, DLocation, DxfText, height, width, outer_mid_space, outer_in_space,barHeight,barWidth);
        }

        //画表示门闩的小矩形
        public static void writeRepresentDoorBarRectangle(DxfModel doc, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space, double barHeight, double barWidth)
        {

            DxfLine bottomDxfLine = new DxfLine(new Point3D(DLocation.X, DLocation.Y, DLocation.Z), new Point3D(DLocation.X + barWidth, DLocation.Y, DLocation.Z));
     
            DxfLine leftDxfLine = new DxfLine(new Point3D(DLocation.X, DLocation.Y, DLocation.Z), new Point3D(DLocation.X, DLocation.Y + barHeight, DLocation.Z));
    
            DxfLine topDxfLine = new DxfLine(new Point3D(DLocation.X, DLocation.Y + barHeight, DLocation.Z), new Point3D(DLocation.X + barWidth, DLocation.Y + barHeight, DLocation.Z));
  
            DxfLine rightDxfLine = new DxfLine(new Point3D(DLocation.X + barWidth, DLocation.Y + barHeight, DLocation.Z), new Point3D(DLocation.X + barWidth, DLocation.Y, DLocation.Z));
      

           //内部折线
            DxfLine upDxfLine = new DxfLine(new Point3D(DLocation.X + barWidth / 2-(outer_in_space-outer_mid_space)/2, DLocation.Y + barHeight, DLocation.Z), new Point3D(DLocation.X + barWidth / 2-(outer_in_space-outer_mid_space)/2, DLocation.Y + barHeight / 2, DLocation.Z));
            DxfLine midDxfLine = new DxfLine(new Point3D(DLocation.X + barWidth / 2 - (outer_in_space - outer_mid_space) / 2, DLocation.Y + barHeight / 2, DLocation.Z), new Point3D(DLocation.X + barWidth / 2 + (outer_in_space - outer_mid_space) / 2,DLocation.Y+barHeight/2,DLocation.Z));
   
            DxfLine downDxfLine = new DxfLine(new Point3D(DLocation.X + barWidth / 2 + (outer_in_space - outer_mid_space) / 2, DLocation.Y + barHeight / 2, DLocation.Z), new Point3D(DLocation.X+barWidth/2+(outer_in_space-outer_mid_space)/2, DLocation.Y, DLocation.Z));
    
            doc.Entities.Add(bottomDxfLine);
            doc.Entities.Add(leftDxfLine);
            doc.Entities.Add(topDxfLine);
            doc.Entities.Add(rightDxfLine);
            doc.Entities.Add(upDxfLine);
            doc.Entities.Add(midDxfLine);
            doc.Entities.Add(downDxfLine);
        }

        //画标注
        public static void writeDimension(DxfModel doc,DLocation firstDLocation,DLocation secondDLocation,double DxfTextHeight,double DxfTextWidth,double dimensionHeight,string dimensionDirection)
        {
            DxfDimension.Aligned dimension = new DxfDimension.Aligned(doc.DefaultDimensionStyle);
            dimension.ExtensionLine1StartPoint = new Point3D(firstDLocation.X, firstDLocation.Y, firstDLocation.Z);
            dimension.ExtensionLine2StartPoint = new Point3D(secondDLocation.X, secondDLocation.Y, secondDLocation.Z);
            if (dimensionDirection.Equals("top"))
                dimension.DimensionLineLocation = new Point3D((firstDLocation.X + secondDLocation.X) / 2, firstDLocation.Y + dimensionHeight, firstDLocation.Z);
            else if (dimensionDirection.Equals("bottom"))
                dimension.DimensionLineLocation = new Point3D((firstDLocation.X + secondDLocation.X) / 2, firstDLocation.Y - dimensionHeight, firstDLocation.Z);
            else if (dimensionDirection.Equals("left"))
                dimension.DimensionLineLocation = new Point3D(firstDLocation.X - dimensionHeight, (firstDLocation.Y + secondDLocation.Y) / 2, firstDLocation.Z);
            else if (dimensionDirection.Equals("right"))
                dimension.DimensionLineLocation = new Point3D(firstDLocation.X + dimensionHeight, (firstDLocation.Y + secondDLocation.Y) / 2, firstDLocation.Z);
            dimension.DimensionStyleOverrides.TextHeight = 1d;
            dimension.DimensionStyleOverrides.ArrowSize = 1d;
            doc.Entities.Add(dimension);
        }

        //画带有四个小矩形的俯视图矩形
        public static void writeTopViewRectangle(DxfModel dxf, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space)
        {
            //outer_in_space模拟height,outer_in_space - outer_mid_space模拟width
            //主要矩形
            writeOuterDoorRectangle(dxf, DLocation, height, width);
            //左上角矩形
            writeOuterDoorRectangle(dxf, new DLocation(DLocation.X, DLocation.Y + height, DLocation.Z), outer_in_space, outer_in_space - outer_mid_space);
            //右上角
            writeOuterDoorRectangle(dxf, new DLocation(DLocation.X + width - outer_in_space + outer_mid_space, DLocation.Y + height, DLocation.Z), outer_in_space, outer_in_space - outer_mid_space);
            //左下角
            writeOuterDoorRectangle(dxf, new DLocation(DLocation.X, DLocation.Y - outer_in_space, DLocation.Z), outer_in_space, outer_in_space - outer_mid_space);
            //右下角
            writeOuterDoorRectangle(dxf, new DLocation(DLocation.X + width - outer_in_space + outer_mid_space, DLocation.Y - outer_in_space, DLocation.Z), outer_in_space, outer_in_space - outer_mid_space);

        }

        //画完整的一个单门（门闩，把手，支架）
        /// <summary>
        /// fta等，sfd,pea,pec,rfa
        /// </summary>
        /// <param name="dxf"></param>
        /// <param name="DLocation"></param>
        /// <param name="DxfText"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="outer_mid_space"></param>
        /// <param name="outer_in_space"></param>
        /// <param name="barHeight"></param>
        /// <param name="barWidth"></param>
        /// <param name="upOrDownLayer"></param>
        public static void writeWholeSingleDoor(DxfModel dxf, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space, double barHeight, double barWidth,string upOrDownLayer)
        {
            writeDoorBarRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            double downLeftX=DLocation.X+outer_mid_space-barWidth/2+(outer_in_space-outer_mid_space)/2;
            double downLeftY=DLocation.Y + height / 4;
            writeRepresentDoorBarRectangle(dxf, new DLocation(downLeftX,downLeftY , DLocation.Z), DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            double upLeftX = downLeftX;
            double upLeftY = DLocation.Y + 3 * height / 4 - barHeight;
            writeRepresentDoorBarRectangle(dxf, new DLocation(upLeftX,upLeftY , DLocation.Z), DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
           
            //画小支架
            if (upOrDownLayer.Equals("downLayer"))
            {
                //左下角
                writeOuterDoorRectangle(dxf, new DLocation(DLocation.X, DLocation.Y - outer_in_space, DLocation.Z), outer_in_space, outer_in_space - outer_mid_space);
                //右下角
                writeOuterDoorRectangle(dxf, new DLocation(DLocation.X + width + outer_mid_space - outer_in_space, DLocation.Y - outer_in_space, DLocation.Z), outer_in_space, outer_in_space - outer_mid_space);
            }
            //画门把手
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + 3 * height / 4 - barHeight, DLocation.Z));
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + height / 4, DLocation.Z));
        }

        //画完整的带支架的设备矩形框
        public static void writeWholeMachine(DxfModel dxf, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space, double barHeight, double barWidth,string upOrDownLayer)
        {
            writeDoorRectangle(dxf,DLocation,DxfText,height,width,outer_mid_space,outer_in_space);
            //画小支架
            if (upOrDownLayer.Equals("downLayer"))
            {
                //左下角
                writeOuterDoorRectangle(dxf, new DLocation(DLocation.X, DLocation.Y - outer_in_space, DLocation.Z), outer_in_space, outer_in_space - outer_mid_space);
                //右下角
                writeOuterDoorRectangle(dxf, new DLocation(DLocation.X + width + outer_mid_space - outer_in_space, DLocation.Y - outer_in_space, DLocation.Z), outer_in_space, outer_in_space - outer_mid_space);
            }
        }

        //画完整的双门闩的门
        public static void writeWholeDoubleDoor(DxfModel dxf, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space, double barHeight, double barWidth,string upOrDownLayer)
        {
            
            writeDoubleDoorBarRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            //左边的门闩小矩形
            double downLeftX = DLocation.X + outer_mid_space - barWidth / 2 + (outer_in_space - outer_mid_space) / 2;
            double downLeftY = DLocation.Y + height / 4;
            writeRepresentDoorBarRectangle(dxf, new DLocation(downLeftX, downLeftY, DLocation.Z), DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            double upLeftX = downLeftX;
            double upLeftY = DLocation.Y + 3 * height / 4 - barHeight;
            writeRepresentDoorBarRectangle(dxf, new DLocation(upLeftX, upLeftY, DLocation.Z), DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            //右边的门闩的小矩形
            double downRightX = DLocation.X + width / 2 + width / 14 - barWidth / 2 + (outer_in_space - outer_mid_space) / 2;
            double downRightY = DLocation.Y + height / 4;
            writeRepresentDoorBarRectangle(dxf, new DLocation(downRightX, downRightY, DLocation.Z), DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            double upRightX = downRightX;
            double upRightY = DLocation.Y + 3 * height / 4 - barHeight;
            writeRepresentDoorBarRectangle(dxf, new DLocation(upRightX, upRightY, DLocation.Z), DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);

            //画小支架
            if (upOrDownLayer.Equals("downLayer"))
            {
                //左下角
                writeOuterDoorRectangle(dxf, new DLocation(DLocation.X, DLocation.Y - outer_in_space, DLocation.Z), outer_in_space, outer_in_space - outer_mid_space);
                //右下角
                writeOuterDoorRectangle(dxf, new DLocation(DLocation.X + width + outer_mid_space - outer_in_space, DLocation.Y - outer_in_space, DLocation.Z), outer_in_space, outer_in_space - outer_mid_space);
            }
        }
        /// <summary>
        /// 圆圈
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="DLocation"></param>
        /// <param name="radius"></param>
        public static void writeCirle(DxfModel doc, DLocation DLocation,double radius)
        {
            DxfCircle dxfCirle = new DxfCircle(new Point3D(DLocation.X, DLocation.Y, DLocation.Z), radius);
            doc.Entities.Add(dxfCirle);
        }
        /// <summary>
        /// clf类型的门窗,含有四个矩形框图,clm,clg,cli
        /// </summary>
        public static void writeFourCircleDoor(DxfModel doc, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space)
        {
            //三个矩形框
            writeDoorRectangle(doc,DLocation,DxfText,height,width,outer_mid_space,outer_in_space);
            //四个小圈
            //底部
            writeCirle(doc, new DLocation(DLocation.X + 2 * outer_in_space, DLocation.Y + 2 * outer_in_space, DLocation.Z), (outer_in_space - outer_mid_space) / 2);
            writeCirle(doc, new DLocation(DLocation.X +width*3/4, DLocation.Y + 2 * outer_in_space, DLocation.Z), (outer_in_space - outer_mid_space) / 2);

            //顶部
            writeCirle(doc,new DLocation(DLocation.X+2*outer_in_space,DLocation.Y+height-2*outer_in_space,DLocation.Z),(outer_in_space-outer_mid_space)/2);
            writeCirle(doc, new DLocation(DLocation.X + width / 2, DLocation.Y + height - 2 * outer_in_space, DLocation.Z), (outer_in_space - outer_mid_space) / 2);
        }

        /// <summary>
        /// sfa类型的双门，双门闩，4个把手的门,sfc
        /// </summary>
        /// <param name="dxf"></param>
        /// <param name="DLocation"></param>
        /// <param name="DxfText"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="outer_mid_space"></param>
        /// <param name="outer_in_space"></param>
        /// <param name="barHeight"></param>
        /// <param name="barWidth"></param>
        /// <param name="upOrDownLayer"></param>
        public static void writeWholeDoorFourHandle(DxfModel dxf, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space, double barHeight, double barWidth, string upOrDownLayer)
        {
            //有双门双门门闩的矩形
            writeWholeDoubleDoor(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth, upOrDownLayer);

            //画门把手
            //左边
            Handle.Draw(dxf, new DLocation(DLocation.X +  width /3, DLocation.Y + 3 * height / 4 - barHeight, DLocation.Z));
            Handle.Draw(dxf, new DLocation(DLocation.X +  width /3, DLocation.Y + height / 4, DLocation.Z));

           //右边
            Handle.Draw(dxf, new DLocation(DLocation.X + width-2*outer_in_space, DLocation.Y + 3 * height / 4 - barHeight, DLocation.Z));
            Handle.Draw(dxf, new DLocation(DLocation.X + width-2*outer_in_space, DLocation.Y + height / 4, DLocation.Z));
        }
        /// <summary>
        /// 画phb类型的，单门只含有两个cirle的完整门窗,clm也是这个类型
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="DLocation"></param>
        /// <param name="DxfText"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="outer_mid_space"></param>
        /// <param name="outer_in_space"></param>
        public static void writeWholeSingleDoorTwoCirle(DxfModel doc, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space)
        {
            writeDoorRectangle(doc, DLocation, DxfText, height, width, outer_mid_space, outer_in_space);
            //两个个小圈
            //底部
            writeCirle(doc, new DLocation(DLocation.X + width * 3 / 4, DLocation.Y + 2 * outer_in_space, DLocation.Z), (outer_in_space - outer_mid_space) / 2);

            //顶部
            writeCirle(doc, new DLocation(DLocation.X + width / 2, DLocation.Y + height - 2 * outer_in_space, DLocation.Z), (outer_in_space - outer_mid_space) / 2);
        }
        /// <summary>
        /// 单门有两门闩，和俩个把手的
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="DLocation"></param>
        /// <param name="DxfText"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="outer_mid_space"></param>
        /// <param name="outer_in_space"></param>
        /// <param name="barHeight"></param>
        /// <param name="barWidth"></param>
        public static void writeWholeSingleTwoBarAndTwoCirle(DxfModel doc, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space,double barHeight,double barWidth)
        {
            DxfLine outerLeftDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 - width / 14, DLocation.Y + outer_mid_space, DLocation.Z), new Point3D(DLocation.X + width / 2 - width / 14, DLocation.Y + height - outer_mid_space, DLocation.Z));

            DxfLine inLeftDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 - width / 14 + 0.5f, DLocation.Y + outer_in_space, DLocation.Z), new Point3D(DLocation.X + width / 2 - width / 14 + 0.5f, DLocation.Y + height - outer_in_space, DLocation.Z));

            DxfLine inDownRightDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 + width / 14, DLocation.Y + outer_in_space, DLocation.Z), new Point3D(DLocation.X + width / 2 + width / 14, DLocation.Y + height / 4, DLocation.Z));

            DxfLine inMidRightDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 + width / 14, DLocation.Y + height / 4 + barHeight, DLocation.Z), new Point3D(DLocation.X + width / 2 + width / 14, DLocation.Y + 3 * height / 4 - barHeight, DLocation.Z));

            DxfLine inUpRightDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 + width / 14, DLocation.Y + 3 * height / 4, DLocation.Z), new Point3D(DLocation.X + width / 2 + width / 14, DLocation.Y + height - outer_in_space, DLocation.Z));

            DxfLine outerDownRightDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 + width / 14 + 0.5f, DLocation.Y + outer_mid_space, DLocation.Z), new Point3D(DLocation.X + width / 2 + width / 14 + 0.5f, DLocation.Y + height / 4, DLocation.Z));

            DxfLine outerMidRightDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 + width / 14 + 0.5f, DLocation.Y + height / 4 + barHeight, DLocation.Z), new Point3D(DLocation.X + width / 2 + width / 14 + 0.5f, DLocation.Y + 3 * height / 4 - barHeight, DLocation.Z));

            DxfLine outerUpRightDxfLine = new DxfLine(new Point3D(DLocation.X + width / 2 + width / 14 + 0.5f, DLocation.Y + 3 * height / 4, DLocation.Z), new Point3D(DLocation.X + width / 2 + width / 14 + 0.5f, DLocation.Y + height - outer_in_space, DLocation.Z));


            doc.Entities.Add(outerLeftDxfLine);
            doc.Entities.Add(inLeftDxfLine);

            //左边的门闩小矩形
            double downLeftX = DLocation.X + outer_mid_space - barWidth / 2 + (outer_in_space - outer_mid_space) / 2;
            double downLeftY = DLocation.Y + height / 4;
            writeRepresentDoorBarRectangle(doc, new DLocation(downLeftX, downLeftY, DLocation.Z), DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            double upLeftX = downLeftX;
            double upLeftY = DLocation.Y + 3 * height / 4 - barHeight;
            writeRepresentDoorBarRectangle(doc, new DLocation(upLeftX, upLeftY, DLocation.Z), DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);

            //两个个小圈
            //底部
            writeCirle(doc, new DLocation(DLocation.X + width-2*outer_in_space, DLocation.Y + 2 * outer_in_space, DLocation.Z), (outer_in_space - outer_mid_space) / 2);

            //顶部
            writeCirle(doc, new DLocation(DLocation.X + width-2*outer_in_space, DLocation.Y + height - 2 * outer_in_space, DLocation.Z), (outer_in_space - outer_mid_space) / 2);

            //画门把手
            Handle.Draw(doc, new DLocation(DLocation.X + width / 4+outer_mid_space/2, DLocation.Y + 3 * height / 4 - barHeight, DLocation.Z));
            Handle.Draw(doc, new DLocation(DLocation.X + width / 4 + outer_mid_space/2, DLocation.Y + height / 4, DLocation.Z));
            writeDoorBarRectangle(doc, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
        }



        //画左支架
        public static void writeLeftStand(DxfModel dxf, DLocation DLocation, double height, double width, double outer_in_space)
        {
            DxfLine outLeft = new DxfLine(new Point3D(DLocation.X, DLocation.Y, DLocation.Z), new Point3D(DLocation.X + width, DLocation.Y, DLocation.Z));
            DxfLine outRight = new DxfLine(new Point3D(DLocation.X + width, DLocation.Y, DLocation.Z), new Point3D(DLocation.X + width, DLocation.Y + height, DLocation.Z));
            DxfLine outBottom = new DxfLine(new Point3D(DLocation.X, DLocation.Y, DLocation.Z), new Point3D(DLocation.X, DLocation.Y + height, DLocation.Z));
            DxfLine outTop = new DxfLine(new Point3D(DLocation.X, DLocation.Y + height, DLocation.Z), new Point3D(DLocation.X + width, DLocation.Y + height, DLocation.Z));
            dxf.Entities.Add(outLeft);
            dxf.Entities.Add(outRight);
            dxf.Entities.Add(outBottom);
            dxf.Entities.Add(outTop);

            DxfLine inLeft = new DxfLine(new Point3D(DLocation.X + outer_in_space, DLocation.Y + outer_in_space, DLocation.Z), new Point3D(DLocation.X + outer_in_space, DLocation.Y + height - outer_in_space, DLocation.Z));
            DxfLine inTop = new DxfLine(new Point3D(DLocation.X + outer_in_space, DLocation.Y + height - outer_in_space, DLocation.Z), new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + height - outer_in_space, DLocation.Z));
            DxfLine inBottom = new DxfLine(new Point3D(DLocation.X + outer_in_space, DLocation.Y + outer_in_space, DLocation.Z), new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + outer_in_space, DLocation.Z));
            DxfLine inRightTop = new DxfLine(new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + height - outer_in_space, DLocation.Z), new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + height - 7 * outer_in_space, DLocation.Z));
            DxfLine inRightBottom = new DxfLine(new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + outer_in_space, DLocation.Z), new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + 7 * outer_in_space, DLocation.Z));
            DxfLine inRightTopLine = new DxfLine(new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + height - 7 * outer_in_space, DLocation.Z), new Point3D(DLocation.X + width, DLocation.Y + height - 7 * outer_in_space, DLocation.Z));
            DxfLine inRightBettomLine = new DxfLine(new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + 7 * outer_in_space, DLocation.Z), new Point3D(DLocation.X + width, DLocation.Y + 7 * outer_in_space, DLocation.Z));


            dxf.Entities.Add(inTop);
            dxf.Entities.Add(inLeft);
            dxf.Entities.Add(inBottom);
            dxf.Entities.Add(inRightTop);
            dxf.Entities.Add(inRightBottom);
            dxf.Entities.Add(inRightTopLine);
            dxf.Entities.Add(inRightBettomLine);
        }

        //画右支架
        public static void writeRighStand(DxfModel dxf, DLocation DLocation, double height, double width, double outer_in_space)
        {
            DxfLine outLeft = new DxfLine(new Point3D(DLocation.X, DLocation.Y, DLocation.Z), new Point3D(DLocation.X + width, DLocation.Y, DLocation.Z));
            DxfLine outRight = new DxfLine(new Point3D(DLocation.X + width, DLocation.Y, DLocation.Z), new Point3D(DLocation.X + width, DLocation.Y + height, DLocation.Z));
            DxfLine outBottom = new DxfLine(new Point3D(DLocation.X, DLocation.Y, DLocation.Z), new Point3D(DLocation.X, DLocation.Y + height, DLocation.Z));
            DxfLine outTop = new DxfLine(new Point3D(DLocation.X, DLocation.Y + height, DLocation.Z), new Point3D(DLocation.X + width, DLocation.Y + height, DLocation.Z));
            dxf.Entities.Add(outLeft);
            dxf.Entities.Add(outRight);
            dxf.Entities.Add(outBottom);
            dxf.Entities.Add(outTop);

            DxfLine inRight = new DxfLine(new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + outer_in_space, DLocation.Z), new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + height - outer_in_space, DLocation.Z));
            DxfLine inTop = new DxfLine(new Point3D(DLocation.X + outer_in_space, DLocation.Y + height - outer_in_space, DLocation.Z), new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + height - outer_in_space, DLocation.Z));
            DxfLine inBottom = new DxfLine(new Point3D(DLocation.X + outer_in_space, DLocation.Y + outer_in_space, DLocation.Z), new Point3D(DLocation.X + width - outer_in_space, DLocation.Y + outer_in_space, DLocation.Z));

            DxfLine inLeftTop = new DxfLine(new Point3D(DLocation.X + outer_in_space, DLocation.Y + height - 7 * outer_in_space, DLocation.Z), new Point3D(DLocation.X + outer_in_space, DLocation.Y + height - outer_in_space, DLocation.Z));
            DxfLine inLeftBottom = new DxfLine(new Point3D(DLocation.X + outer_in_space, DLocation.Y + outer_in_space, DLocation.Z), new Point3D(DLocation.X + outer_in_space, DLocation.Y + 7 * outer_in_space, DLocation.Z));
            DxfLine inLeftTopLine = new DxfLine(new Point3D(DLocation.X, DLocation.Y + height - 7 * outer_in_space, DLocation.Z), new Point3D(DLocation.X + outer_in_space, DLocation.Y + height - 7 * outer_in_space, DLocation.Z));
            DxfLine inLeftBettomLine = new DxfLine(new Point3D(DLocation.X, DLocation.Y + 7 * outer_in_space, DLocation.Z), new Point3D(DLocation.X + outer_in_space, DLocation.Y + 7 * outer_in_space, DLocation.Z));


            dxf.Entities.Add(inTop);
            dxf.Entities.Add(inRight);
            dxf.Entities.Add(inBottom);
            dxf.Entities.Add(inLeftTop);
            dxf.Entities.Add(inLeftBottom);
            dxf.Entities.Add(inLeftTopLine);
            dxf.Entities.Add(inLeftBettomLine);
        }

        //画单门，包括上栅栏，包括2个左门闩，2个右把手
        public static void writeTopFanSingleDoor(DxfModel dxf, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space, double barHeight, double barWidth, string upOrDownLayer)
        {
            //画两个门闩
            writeDoorBarRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            double downLeftX=DLocation.X+outer_mid_space-barWidth/2+(outer_in_space-outer_mid_space)/2;
            double downLeftY=DLocation.Y + height / 4;
            writeRepresentDoorBarRectangle(dxf, new DLocation(downLeftX,downLeftY , DLocation.Z), DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            double upLeftX = downLeftX;
            double upLeftY = DLocation.Y + 3 * height / 4 - barHeight;
            writeRepresentDoorBarRectangle(dxf, new DLocation(upLeftX,upLeftY , DLocation.Z), DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
           
            //画门把手
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + 3 * height / 4 - barHeight, DLocation.Z));
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + height / 4, DLocation.Z));

            //画门把手
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + 3 * height / 4 - barHeight, DLocation.Z));
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + height / 4, DLocation.Z));           

            //上面位置栅栏
            Fan.Draw(dxf, new Point3D(DLocation.X + 2.3 * outer_mid_space, DLocation.Y + 1.7 * outer_mid_space + 6 * height / 8, DLocation.Z), new Point3D(DLocation.X + 2.3 * outer_mid_space + 1 * width / 2, DLocation.Y + 1.7 * outer_mid_space + 3 * height / 4, DLocation.Z), 0);

        }


        //画单门，包括下栅栏，包括2个左门闩，2个右把手
        public static void writeBottoFanSingleDoor(DxfModel dxf, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space, double barHeight, double barWidth, string upOrDownLayer)
        {
                       //画两个门闩
            writeDoorBarRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            double downLeftX=DLocation.X+outer_mid_space-barWidth/2+(outer_in_space-outer_mid_space)/2;
            double downLeftY=DLocation.Y + height / 4;
            writeRepresentDoorBarRectangle(dxf, new DLocation(downLeftX,downLeftY , DLocation.Z), DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            double upLeftX = downLeftX;
            double upLeftY = DLocation.Y + 3 * height / 4 - barHeight;
            writeRepresentDoorBarRectangle(dxf, new DLocation(upLeftX,upLeftY , DLocation.Z), DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
           
            //画门把手
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + 3 * height / 4 - barHeight, DLocation.Z));
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + height / 4, DLocation.Z));

            //画门把手
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + 3 * height / 4 - barHeight, DLocation.Z));
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + height / 4, DLocation.Z));    

            //下面位置栅栏
            Fan.Draw(dxf, new Point3D(DLocation.X + 2.3 * outer_mid_space, DLocation.Y + 2.3 * outer_mid_space, DLocation.Z), new Point3D(DLocation.X + 2.3 * outer_mid_space + 1 * width / 2, DLocation.Y + 2.3 * outer_mid_space, DLocation.Z), 0);

        }
        //画单门，包括左和上位置栅栏，包括2个左门闩，2个右把手
        public static void writeTopLeftFasnSingleDoor(DxfModel dxf, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space, double barHeight, double barWidth, string upOrDownLayer)
        {
                       //画两个门闩
            writeDoorBarRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            double downLeftX=DLocation.X+outer_mid_space-barWidth/2+(outer_in_space-outer_mid_space)/2;
            double downLeftY=DLocation.Y + height / 4;
            writeRepresentDoorBarRectangle(dxf, new DLocation(downLeftX,downLeftY , DLocation.Z), DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            double upLeftX = downLeftX;
            double upLeftY = DLocation.Y + 3 * height / 4 - barHeight;
            writeRepresentDoorBarRectangle(dxf, new DLocation(upLeftX,upLeftY , DLocation.Z), DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
           
            //画门把手
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + 3 * height / 4 - barHeight, DLocation.Z));
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + height / 4, DLocation.Z));

            //画门把手
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + 3 * height / 4 - barHeight, DLocation.Z));
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + height / 4, DLocation.Z));    

            //画上面位置栅栏
            Fan.Draw(dxf, new Point3D(DLocation.X + 2.3 * outer_mid_space, DLocation.Y + 1.7 * outer_mid_space + 6 * height / 8, DLocation.Z), new Point3D(DLocation.X + 2.3 * outer_mid_space + 1 * width / 2, DLocation.Y + 1.7 * outer_mid_space + 3 * height / 4, DLocation.Z), 0);
            //画左边位置栅栏
            Fan.Draw(dxf, new Point3D(DLocation.X + 2.1 * outer_mid_space, DLocation.Y + 1.8 * outer_in_space, DLocation.Z), new Point3D(DLocation.X + 2.1 * outer_mid_space, DLocation.Y + 2.4 * outer_in_space + 5 * height / 8, DLocation.Z), 0);
        }

        //画单门，包括左和下位置栅栏，包括2个左门闩，2个右把手
        public static void writeLeftBottomFansSingleDoor(DxfModel dxf, DLocation DLocation, string[] DxfText, double height, double width, double outer_mid_space, double outer_in_space, double barHeight, double barWidth, string upOrDownLayer)
        {
                        //画两个门闩
            writeDoorBarRectangle(dxf, DLocation, DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            double downLeftX=DLocation.X+outer_mid_space-barWidth/2+(outer_in_space-outer_mid_space)/2;
            double downLeftY=DLocation.Y + height / 4;
            writeRepresentDoorBarRectangle(dxf, new DLocation(downLeftX,downLeftY , DLocation.Z), DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            double upLeftX = downLeftX;
            double upLeftY = DLocation.Y + 3 * height / 4 - barHeight;
            writeRepresentDoorBarRectangle(dxf, new DLocation(upLeftX,upLeftY , DLocation.Z), DxfText, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
           
            //画门把手
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + 3 * height / 4 - barHeight, DLocation.Z));
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + height / 4, DLocation.Z));

            //画门把手
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + 3 * height / 4 - barHeight, DLocation.Z));
            Handle.Draw(dxf, new DLocation(DLocation.X + 3 * width / 4, DLocation.Y + height / 4, DLocation.Z));    

            //左边位置栅栏
            Fan.Draw(dxf, new Point3D(DLocation.X + 2.1 * outer_mid_space, DLocation.Y + 1.8 * outer_in_space, DLocation.Z), new Point3D(DLocation.X + 2.1 * outer_mid_space, DLocation.Y + 2.4 * outer_in_space + 5 * height / 8, DLocation.Z), 0);
            //下面位置栅栏
            Fan.Draw(dxf, new Point3D(DLocation.X + 2.3 * outer_mid_space, DLocation.Y + 2.3 * outer_mid_space, DLocation.Z), new Point3D(DLocation.X + 2.3 * outer_mid_space + 1 * width / 2, DLocation.Y + 2.3 * outer_mid_space, DLocation.Z), 0);

        }

    }
}

