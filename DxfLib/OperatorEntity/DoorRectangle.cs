using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using netDxf;
using netDxf.Entities;
using System.Drawing;
using netDxf.Tables;
using Model.Zutu;
namespace DxfLib.OperatorEntity
{
    class DoorRectangle
    {
        //画无门栓的矩形框
        public static void writeDoorRectangle(DxfDocument doc, Location location, string[] text, float height, float width, float outer_mid_space, float outer_in_space)
        {
            Layer doorRectangleLayer = new Layer("nonDoorBarLayer");
            //最外围矩形
            writeOuterDoorRectangle(doc,location,height,width);
            //中间矩形
            Line midBottomLine=new Line(new Vector3f(location.X+outer_mid_space,location.Y+outer_mid_space,location.Z),new Vector3f(location.X+width-outer_mid_space,location.Y+outer_mid_space,location.Z));
            midBottomLine.Layer=doorRectangleLayer;
            Line midLeftLine=new Line(new Vector3f(location.X+outer_mid_space,location.Y+outer_mid_space,location.Z),new Vector3f(location.X+outer_mid_space,location.Y+height-outer_mid_space,location.Z));
            midLeftLine.Layer=doorRectangleLayer;
            Line midTopLine=new Line(new Vector3f(location.X+outer_mid_space,location.Y+height-outer_mid_space,location.Z),new Vector3f(location.X+width-outer_mid_space,location.Y+height-outer_mid_space,location.Z));
            midTopLine.Layer=doorRectangleLayer;
            Line midRightLine = new Line(new Vector3f(location.X + width - outer_mid_space, location.Y + height - outer_mid_space, location.Z), new Vector3f(location.X + width - outer_mid_space, location.Y + outer_mid_space, location.Z));
            midRightLine.Layer = doorRectangleLayer;

            doc.AddEntity(midBottomLine);
            doc.AddEntity(midLeftLine);
            doc.AddEntity(midTopLine);
            doc.AddEntity(midRightLine);

            //内部矩形
            Line inBottomLine = new Line(new Vector3f(location.X + outer_in_space, location.Y + outer_in_space, location.Z), new Vector3f(location.X + width - outer_in_space, location.Y + outer_in_space, location.Z));
            inBottomLine.Layer = doorRectangleLayer;
            Line inLeftLine = new Line(new Vector3f(location.X + outer_in_space, location.Y + outer_in_space, location.Z), new Vector3f(location.X + outer_in_space, location.Y + height - outer_in_space, location.Z));
            inLeftLine.Layer = doorRectangleLayer;
            Line inTopLine = new Line(new Vector3f(location.X + outer_in_space, location.Y + height - outer_in_space, location.Z), new Vector3f(location.X + width - outer_in_space, location.Y + height - outer_in_space, location.Z));
            inTopLine.Layer = doorRectangleLayer;
            Line inRightLine = new Line(new Vector3f(location.X + width - outer_in_space, location.Y + height - outer_in_space, location.Z), new Vector3f(location.X + width - outer_in_space, location.Y + outer_in_space, location.Z));
            inRightLine.Layer = doorRectangleLayer;

            doc.AddEntity(inBottomLine);
            doc.AddEntity(inLeftLine);
            doc.AddEntity(inTopLine);
            doc.AddEntity(inRightLine);

            //门中文字
            float textHeight=DoorInitHeightAndWidth.textHeight;
            for(int i=0;i<text.Length;i++){
                Text doorRectangleText = new Text(text[i], new Vector3f(location.X + width / 3, location.Y + 3*height / 4- i * textHeight, location.Z), textHeight);
                doorRectangleText.Layer = doorRectangleLayer;
                doc.AddEntity(doorRectangleText);
            }
        }
         //最外围矩形
        public static void writeOuterDoorRectangle(DxfDocument doc, Location location,float height, float width)
        {
            //最外围矩形
            Layer doorRectangleLayer = new Layer("DoorRectangleLayer");
            Line outerBottomLine = new Line(new Vector3f(location.X, location.Y, location.Z), new Vector3f(location.X + width, location.Y, location.Z));
            outerBottomLine.Layer = doorRectangleLayer;
            Line outerLeftLine = new Line(new Vector3f(location.X, location.Y, location.Z), new Vector3f(location.X, location.Y + height, location.Z));
            outerLeftLine.Layer = doorRectangleLayer;
            Line outerTopLine = new Line(new Vector3f(location.X, location.Y + height, location.Z), new Vector3f(location.X + width, location.Y + height, location.Z));
            outerTopLine.Layer = doorRectangleLayer;
            Line outerRightLine = new Line(new Vector3f(location.X + width, location.Y + height, location.Z), new Vector3f(location.X + width, location.Y, location.Z));
            outerRightLine.Layer = doorRectangleLayer;

            doc.AddEntity(outerBottomLine);
            doc.AddEntity(outerLeftLine);
            doc.AddEntity(outerTopLine);
            doc.AddEntity(outerRightLine);
        }

        //画单门有门闩的矩形框
        public static void writeDoorBarRectangle(DxfDocument doc, Location location, string[] text, float height, float width, float outer_mid_space, float outer_in_space,float barHeight,float barWidth)
        {
            //最外围矩形
            writeOuterDoorRectangle(doc, location, height, width);
            Layer doorBarRectangle = new Layer("DoorBarRectangle");

            //中间矩形
            Line midBottomLine = new Line(new Vector3f(location.X + outer_mid_space, location.Y + outer_mid_space, location.Z), new Vector3f(location.X + width - outer_mid_space, location.Y + outer_mid_space, location.Z));
            midBottomLine.Layer = doorBarRectangle;
            Line midDownLeftLine = new Line(new Vector3f(location.X + outer_mid_space, location.Y + outer_mid_space, location.Z), new Vector3f(location.X + outer_mid_space, location.Y + height / 4, location.Z));
            midDownLeftLine.Layer = doorBarRectangle;
            Line midMidLeftLine = new Line(new Vector3f(location.X + outer_mid_space, location.Y + height / 4 + barHeight, location.Z), new Vector3f(location.X + outer_mid_space, location.Y + 3 * height / 4 - barHeight, location.Z));
            midMidLeftLine.Layer = doorBarRectangle;
            Line midUpLeftLine = new Line(new Vector3f(location.X + outer_mid_space, location.Y + 3*height / 4, location.Z), new Vector3f(location.X + outer_mid_space, location.Y +height-outer_mid_space, location.Z));
            midUpLeftLine.Layer = doorBarRectangle;
            Line midTopLine = new Line(new Vector3f(location.X + outer_mid_space, location.Y + height - outer_mid_space, location.Z), new Vector3f(location.X + width - outer_mid_space, location.Y + height - outer_mid_space, location.Z));
            midTopLine.Layer = doorBarRectangle;
            Line midRightLine = new Line(new Vector3f(location.X + width - outer_mid_space, location.Y + height - outer_mid_space, location.Z), new Vector3f(location.X + width - outer_mid_space, location.Y + outer_mid_space, location.Z));
            midRightLine.Layer = doorBarRectangle;

            doc.AddEntity(midBottomLine);
            doc.AddEntity(midDownLeftLine);
            doc.AddEntity(midMidLeftLine);
            doc.AddEntity(midUpLeftLine);
            doc.AddEntity(midTopLine);
            doc.AddEntity(midRightLine);

            //内部矩形
            
            Line inBottomLine = new Line(new Vector3f(location.X + outer_in_space, location.Y + outer_in_space, location.Z), new Vector3f(location.X + width - outer_in_space, location.Y + outer_in_space, location.Z));
            inBottomLine.Layer = doorBarRectangle;
            Line inDownLeftLine = new Line(new Vector3f(location.X + outer_in_space, location.Y + outer_in_space, location.Z), new Vector3f(location.X + outer_in_space, location.Y + height/4, location.Z));
            inDownLeftLine.Layer = doorBarRectangle;
            Line inmidLeftLine = new Line(new Vector3f(location.X + outer_in_space, location.Y + height / 4 + barHeight, location.Z), new Vector3f(location.X + outer_in_space, location.Y + 3*height/4 - barHeight, location.Z));
            inmidLeftLine.Layer = doorBarRectangle;
            Line inUpLeftLine = new Line(new Vector3f(location.X + outer_in_space, location.Y + 3*height / 4, location.Z), new Vector3f(location.X + outer_in_space, location.Y + height-outer_in_space, location.Z));
            inUpLeftLine.Layer = doorBarRectangle;
            Line inTopLine = new Line(new Vector3f(location.X + outer_in_space, location.Y + height - outer_in_space, location.Z), new Vector3f(location.X + width - outer_in_space, location.Y + height - outer_in_space, location.Z));
            inTopLine.Layer = doorBarRectangle;
            Line inRightLine = new Line(new Vector3f(location.X + width - outer_in_space, location.Y + height - outer_in_space, location.Z), new Vector3f(location.X + width - outer_in_space, location.Y + outer_in_space, location.Z));
            inRightLine.Layer = doorBarRectangle;

            doc.AddEntity(inBottomLine);
            doc.AddEntity(inDownLeftLine);
            doc.AddEntity(inmidLeftLine);
            doc.AddEntity(inUpLeftLine);
            doc.AddEntity(inTopLine);
            doc.AddEntity(inRightLine);

            //门中文字
            float textHeight = DoorInitHeightAndWidth.textHeight;
            for (int i = 0; i < text.Length; i++)
            {
                Text doorRectangleText = new Text(text[i], new Vector3f(location.X + width / 3, location.Y + 3 * height / 4 - i * textHeight, location.Z), textHeight);
                doorRectangleText.Layer = doorBarRectangle;
                doc.AddEntity(doorRectangleText);
            }

        }

        //画两个门无门闩的设备
        public static void writeDoubleDoorRectangle(DxfDocument doc,Location location,string [] text,float height,float width,float outer_mid_space,float outer_in_space)
        {
            Layer doorLineLayer=new Layer("doorLineLayer");
            Line outerLeftLine=new Line(new Vector3f(location.X+width/2-width/14,location.Y+outer_mid_space,location.Z),new Vector3f(location.X+width/2-width/14,location.Y+height-outer_mid_space,location.Z));
            outerLeftLine.Layer = doorLineLayer;
            Line inLeftLine = new Line(new Vector3f(location.X + width / 2 - width / 14 + 0.5f, location.Y + outer_in_space, location.Z), new Vector3f(location.X + width / 2 - width / 14 + 0.5f, location.Y + height - outer_in_space, location.Z));
            inLeftLine.Layer = doorLineLayer;
            Line inRightLine = new Line(new Vector3f(location.X + width / 2 + width / 14, location.Y + outer_in_space, location.Z), new Vector3f(location.X + width / 2 + width / 14, location.Y + height - outer_in_space, location.Z));
            inRightLine.Layer = doorLineLayer;
            Line outerRightLine = new Line(new Vector3f(location.X + width / 2 + width / 14 + 0.5f, location.Y + outer_mid_space, location.Z), new Vector3f(location.X + width / 2 + width / 14 + 0.5f, location.Y + height - outer_mid_space, location.Z));
            outerRightLine.Layer = doorLineLayer;
            
            doc.AddEntity(outerLeftLine);
            doc.AddEntity(inLeftLine);
            doc.AddEntity(inRightLine);
            doc.AddEntity(outerRightLine);
            writeDoorRectangle(doc, location,text, height, width, outer_mid_space, outer_in_space);
        }

        //画两个门有门闩的设备
        public static void writeDoubleDoorBarRectangle(DxfDocument doc, Location location, string[] text, float height, float width, float outer_mid_space, float outer_in_space,float barHeight,float barWidth)
        {
            Layer doorLineLayer = new Layer("DoubleDoorBarRectangle");
            Line outerLeftLine = new Line(new Vector3f(location.X + width / 2 - width / 14, location.Y + outer_mid_space, location.Z), new Vector3f(location.X + width / 2 - width / 14, location.Y + height - outer_mid_space, location.Z));
            outerLeftLine.Layer = doorLineLayer;
            Line inLeftLine = new Line(new Vector3f(location.X + width / 2 - width / 14 + 0.5f, location.Y + outer_in_space, location.Z), new Vector3f(location.X + width / 2 - width / 14 + 0.5f, location.Y + height - outer_in_space, location.Z));
            inLeftLine.Layer = doorLineLayer;
            Line inDownRightLine = new Line(new Vector3f(location.X + width / 2 + width / 14, location.Y + outer_in_space, location.Z), new Vector3f(location.X + width / 2 + width / 14, location.Y + height/4, location.Z));
            inDownRightLine.Layer = doorLineLayer;
            Line inMidRightLine = new Line(new Vector3f(location.X + width / 2 + width / 14, location.Y + height / 4 + barHeight, location.Z), new Vector3f(location.X + width / 2 + width / 14, location.Y + 3 * height / 4 - barHeight, location.Z));
            inMidRightLine.Layer = doorLineLayer;
            Line inUpRightLine = new Line(new Vector3f(location.X + width / 2 + width / 14, location.Y + 3*height / 4, location.Z), new Vector3f(location.X + width / 2 + width / 14, location.Y + height-outer_in_space, location.Z));
            inUpRightLine.Layer = doorLineLayer;
            Line outerDownRightLine = new Line(new Vector3f(location.X + width / 2 + width / 14 + 0.5f, location.Y + outer_mid_space, location.Z), new Vector3f(location.X + width / 2 + width / 14 + 0.5f, location.Y + height/4, location.Z));
            outerDownRightLine.Layer = doorLineLayer;
            Line outerMidRightLine = new Line(new Vector3f(location.X + width / 2 + width / 14 + 0.5f, location.Y + height/4+barHeight, location.Z), new Vector3f(location.X + width / 2 + width / 14 + 0.5f, location.Y + 3*height / 4-barHeight, location.Z));
            outerMidRightLine.Layer = doorLineLayer;
            Line outerUpRightLine = new Line(new Vector3f(location.X + width / 2 + width / 14 + 0.5f, location.Y + 3*height / 4, location.Z), new Vector3f(location.X + width / 2 + width / 14 + 0.5f, location.Y + height-outer_in_space, location.Z));
            outerUpRightLine.Layer = doorLineLayer;

            doc.AddEntity(outerLeftLine);
            doc.AddEntity(inLeftLine);
            doc.AddEntity(inDownRightLine);
            doc.AddEntity(inMidRightLine);
            doc.AddEntity(inUpRightLine);
            doc.AddEntity(outerDownRightLine);
            doc.AddEntity(outerMidRightLine);
            doc.AddEntity(outerUpRightLine);
            writeDoorBarRectangle(doc, location, text, height, width, outer_mid_space, outer_in_space,barHeight,barWidth);
        }

        //画表示门闩的小矩形
        public static void writeRepresentDoorBarRectangle(DxfDocument doc, Location location, string[] text, float height, float width, float outer_mid_space, float outer_in_space, float barHeight, float barWidth)
        {
            Layer representDoorBarRectangleLayer = new Layer("RepresentDoorBarRectangle");
            Line bottomLine = new Line(new Vector3f(location.X, location.Y, location.Z), new Vector3f(location.X + barWidth, location.Y, location.Z));
            bottomLine.Layer = representDoorBarRectangleLayer;
            Line leftLine = new Line(new Vector3f(location.X, location.Y, location.Z), new Vector3f(location.X, location.Y + barHeight, location.Z));
            leftLine.Layer = representDoorBarRectangleLayer;
            Line topLine = new Line(new Vector3f(location.X, location.Y + barHeight, location.Z), new Vector3f(location.X + barWidth, location.Y + barHeight, location.Z));
            topLine.Layer = representDoorBarRectangleLayer;
            Line rightLine = new Line(new Vector3f(location.X + barWidth, location.Y + barHeight, location.Z), new Vector3f(location.X + barWidth, location.Y, location.Z));
            rightLine.Layer = representDoorBarRectangleLayer;

           //内部折线
            Line upLine = new Line(new Vector3f(location.X + barWidth / 2-(outer_in_space-outer_mid_space)/2, location.Y + barHeight, location.Z), new Vector3f(location.X + barWidth / 2-(outer_in_space-outer_mid_space)/2, location.Y + barHeight / 2, location.Z));
            upLine.Layer = representDoorBarRectangleLayer;
            Line midLine = new Line(new Vector3f(location.X + barWidth / 2 - (outer_in_space - outer_mid_space) / 2, location.Y + barHeight / 2, location.Z), new Vector3f(location.X + barWidth / 2 + (outer_in_space - outer_mid_space) / 2,location.Y+barHeight/2,location.Z));
            midLine.Layer = representDoorBarRectangleLayer;
            Line downLine = new Line(new Vector3f(location.X + barWidth / 2 + (outer_in_space - outer_mid_space) / 2, location.Y + barHeight / 2, location.Z), new Vector3f(location.X+barWidth/2+(outer_in_space-outer_mid_space)/2, location.Y, location.Z));
            downLine.Layer = representDoorBarRectangleLayer;
            doc.AddEntity(bottomLine);
            doc.AddEntity(leftLine);
            doc.AddEntity(topLine);
            doc.AddEntity(rightLine);
            doc.AddEntity(upLine);
            doc.AddEntity(midLine);
            doc.AddEntity(downLine);
        }

        //画标注
        public static void writeDimension(DxfDocument doc,Location firstLocation,Location secondLocation,float textHeight,float textWidth,float dimensionHeight,string dimensionDirection)
        {
            float numWidth;
            string strNumWidth = "";
            Layer dimensionLayer=new Layer("dimensionLayer");
            Line line1 = new Line();
            Line line2 = new Line();
            Line leftLine = new Line();
            Line rightLine = new Line();
            Line upLeftLine = new Line();
            Line downLeftLine = new Line();
            Line upRightLine = new Line();
            Line downRightLine = new Line();
            Text strText = new Text();
            line1.Layer = dimensionLayer;
            line2.Layer = dimensionLayer;
            leftLine.Layer = dimensionLayer;
            rightLine.Layer = dimensionLayer;
            upLeftLine.Layer = dimensionLayer;
            downLeftLine.Layer = dimensionLayer;
            upRightLine.Layer = dimensionLayer;
            downRightLine.Layer = dimensionLayer;
            strText.Layer = dimensionLayer;
            if (dimensionDirection.Equals("top"))
            {
                line1.StartPoint = new Vector3f(firstLocation.X, firstLocation.Y, firstLocation.Z);
                line1.EndPoint = new Vector3f(firstLocation.X, firstLocation.Y + dimensionHeight, firstLocation.Z);
                line2.StartPoint = new Vector3f(secondLocation.X,secondLocation.Y,secondLocation.Z);
                line2.EndPoint = new Vector3f(secondLocation.X,secondLocation.Y+dimensionHeight,secondLocation.Z);
                leftLine.StartPoint = new Vector3f(firstLocation.X, firstLocation.Y + 7 * dimensionHeight / 8,firstLocation.Z);
                leftLine.EndPoint = new Vector3f(firstLocation.X+Math.Abs(firstLocation.X-secondLocation.X)/2-textWidth/2,firstLocation.Y+7*dimensionHeight/8, firstLocation.Z);
                upLeftLine.StartPoint = new Vector3f(firstLocation.X, firstLocation.Y + 7 * dimensionHeight / 8,firstLocation.Z);
                upLeftLine.EndPoint = new Vector3f(firstLocation.X + 0.2f, firstLocation.Y + 7 * dimensionHeight / 8+0.2f,firstLocation.Z);
                downLeftLine.StartPoint = new Vector3f(firstLocation.X, firstLocation.Y + 7 * dimensionHeight / 8, firstLocation.Z);
                downLeftLine.EndPoint = new Vector3f(firstLocation.X + 0.2f, firstLocation.Y + 7 * dimensionHeight / 8 - 0.2f, firstLocation.Z);
                upRightLine.StartPoint = new Vector3f(secondLocation.X, secondLocation.Y + 7 * dimensionHeight/8,secondLocation.Z);
                upRightLine.EndPoint = new Vector3f(secondLocation.X - 0.2f, secondLocation.Y + 7 * dimensionHeight / 8 + 0.2f, secondLocation.Z);
                downRightLine.StartPoint = new Vector3f(secondLocation.X,secondLocation.Y+7*dimensionHeight/8,secondLocation.Z);
                downRightLine.EndPoint = new Vector3f(secondLocation.X-0.2f,secondLocation.Y+7*dimensionHeight/8-0.2f,secondLocation.Z);

                rightLine.StartPoint = new Vector3f(secondLocation.X,secondLocation.Y+7*dimensionHeight/8,secondLocation.Z);
                rightLine.EndPoint = new Vector3f(secondLocation.X-Math.Abs(firstLocation.X-secondLocation.X)/2+textWidth/2,secondLocation.Y+7*dimensionHeight/8,secondLocation.Z);

                numWidth = secondLocation.X - firstLocation.X;
                strNumWidth = "" + numWidth;
               strText.BasePoint=new Vector3f(firstLocation.X+Math.Abs(firstLocation.X-secondLocation.X)/2-textWidth/2+0.2f,firstLocation.Y+7*dimensionHeight/8, firstLocation.Z);
               strText.Height=0.5f;
                strText.Value=strNumWidth;
            }
            else if(dimensionDirection.Equals("bottom")){
                line1.StartPoint = new Vector3f(firstLocation.X, firstLocation.Y, firstLocation.Z);
                line1.EndPoint = new Vector3f(firstLocation.X, firstLocation.Y - dimensionHeight, firstLocation.Z);
                line2.StartPoint = new Vector3f(secondLocation.X, secondLocation.Y, secondLocation.Z);
                line2.EndPoint = new Vector3f(secondLocation.X, secondLocation.Y - dimensionHeight, secondLocation.Z);
                leftLine.StartPoint = new Vector3f(firstLocation.X, firstLocation.Y - 7 * dimensionHeight / 8, firstLocation.Z);
                leftLine.EndPoint = new Vector3f(firstLocation.X + Math.Abs(firstLocation.X - secondLocation.X) / 2 - textWidth / 2, firstLocation.Y - 7 * dimensionHeight / 8, firstLocation.Z);
                upLeftLine.StartPoint = new Vector3f(firstLocation.X, firstLocation.Y - 7 * dimensionHeight / 8, firstLocation.Z);
                upLeftLine.EndPoint = new Vector3f(firstLocation.X + 0.2f, firstLocation.Y - 7 * dimensionHeight / 8 + 0.2f, firstLocation.Z);
                downLeftLine.StartPoint = new Vector3f(firstLocation.X, firstLocation.Y - 7 * dimensionHeight / 8, firstLocation.Z);
                downLeftLine.EndPoint = new Vector3f(firstLocation.X + 0.2f, firstLocation.Y - 7 * dimensionHeight / 8 - 0.2f, firstLocation.Z);
                upRightLine.StartPoint = new Vector3f(secondLocation.X, secondLocation.Y - 7 * dimensionHeight / 8, secondLocation.Z);
                upRightLine.EndPoint = new Vector3f(secondLocation.X - 0.2f, secondLocation.Y - 7 * dimensionHeight / 8 + 0.2f, secondLocation.Z);
                downRightLine.StartPoint = new Vector3f(secondLocation.X, secondLocation.Y - 7 * dimensionHeight / 8, secondLocation.Z);
                downRightLine.EndPoint = new Vector3f(secondLocation.X - 0.2f, secondLocation.Y - 7 * dimensionHeight / 8 - 0.2f, secondLocation.Z);

                rightLine.StartPoint = new Vector3f(secondLocation.X, secondLocation.Y - 7 * dimensionHeight / 8, secondLocation.Z);
                rightLine.EndPoint = new Vector3f(secondLocation.X - Math.Abs(firstLocation.X - secondLocation.X) / 2 + textWidth / 2, secondLocation.Y - 7 * dimensionHeight / 8, secondLocation.Z);


                numWidth = secondLocation.X - firstLocation.X;
                strNumWidth = "" + numWidth;
                strText.BasePoint=new Vector3f(firstLocation.X+Math.Abs(firstLocation.X-secondLocation.X)/2-textWidth/2+0.2f,firstLocation.Y-7*dimensionHeight/8, firstLocation.Z);
               strText.Height=0.5f;
                strText.Value=strNumWidth;
            }
            else if(dimensionDirection.Equals("left")){
                line1.StartPoint = new Vector3f(firstLocation.X, firstLocation.Y, firstLocation.Z);
                line1.EndPoint = new Vector3f(firstLocation.X - dimensionHeight, firstLocation.Y, firstLocation.Z);
                line2.StartPoint = new Vector3f(secondLocation.X, secondLocation.Y, secondLocation.Z);
                line2.EndPoint = new Vector3f(secondLocation.X - dimensionHeight, secondLocation.Y, secondLocation.Z);
                leftLine.StartPoint = new Vector3f(firstLocation.X - 7 * dimensionHeight / 8, firstLocation.Y, firstLocation.Z);
                leftLine.EndPoint = new Vector3f(firstLocation.X - 7 * dimensionHeight / 8, firstLocation.Y + Math.Abs(firstLocation.Y - secondLocation.Y) / 2 - textWidth / 2, firstLocation.Z);
                upLeftLine.StartPoint = new Vector3f(firstLocation.X - 7 * dimensionHeight / 8, firstLocation.Y, firstLocation.Z);
                upLeftLine.EndPoint = new Vector3f(firstLocation.X - 7 * dimensionHeight / 8 - 0.2f, firstLocation.Y + 0.2f, firstLocation.Z);
                downLeftLine.StartPoint = new Vector3f(firstLocation.X - 7 * dimensionHeight / 8, firstLocation.Y, firstLocation.Z);
                downLeftLine.EndPoint = new Vector3f(firstLocation.X - 7 * dimensionHeight / 8 + 0.2f, firstLocation.Y+0.2f, firstLocation.Z);
                upRightLine.StartPoint = new Vector3f(secondLocation.X - 7 * dimensionHeight / 8, secondLocation.Y, secondLocation.Z);
                upRightLine.EndPoint = new Vector3f(secondLocation.X - 7 * dimensionHeight / 8 - 0.2f, secondLocation.Y - 0.2f, secondLocation.Z);
                downRightLine.StartPoint = new Vector3f(secondLocation.X - 7 * dimensionHeight / 8, secondLocation.Y, secondLocation.Z);
                downRightLine.EndPoint = new Vector3f(secondLocation.X - 7 * dimensionHeight / 8 + 0.2f, secondLocation.Y-0.2f, secondLocation.Z);

                rightLine.StartPoint = new Vector3f(secondLocation.X - 7 * dimensionHeight / 8, secondLocation.Y, secondLocation.Z);
                rightLine.EndPoint = new Vector3f(secondLocation.X - 7 * dimensionHeight / 8, secondLocation.Y - Math.Abs(firstLocation.Y - secondLocation.Y) / 2 + textWidth / 2, secondLocation.Z);


                numWidth = secondLocation.Y - firstLocation.Y;
                strNumWidth = "" + numWidth;
                strText.BasePoint = new Vector3f(firstLocation.X - 7 * dimensionHeight / 8, firstLocation.Y + Math.Abs(firstLocation.Y - secondLocation.Y) / 2 - textWidth / 2 + 0.2f, firstLocation.Z);
               strText.Height=0.5f;
                strText.Value=strNumWidth;
            }
            else if (dimensionDirection.Equals("right"))
            {
                line1.StartPoint = new Vector3f(firstLocation.X, firstLocation.Y, firstLocation.Z);
                line1.EndPoint = new Vector3f(firstLocation.X + dimensionHeight, firstLocation.Y, firstLocation.Z);
                line2.StartPoint = new Vector3f(secondLocation.X, secondLocation.Y, secondLocation.Z);
                line2.EndPoint = new Vector3f(secondLocation.X + dimensionHeight, secondLocation.Y, secondLocation.Z);
                leftLine.StartPoint = new Vector3f(firstLocation.X + 7 * dimensionHeight / 8, firstLocation.Y, firstLocation.Z);
                leftLine.EndPoint = new Vector3f(firstLocation.X + 7 * dimensionHeight / 8, firstLocation.Y + Math.Abs(firstLocation.Y - secondLocation.Y) / 2 - textWidth / 2, firstLocation.Z);
                upLeftLine.StartPoint = new Vector3f(firstLocation.X + 7 * dimensionHeight / 8, firstLocation.Y, firstLocation.Z);
                upLeftLine.EndPoint = new Vector3f(firstLocation.X + 7 * dimensionHeight / 8 - 0.2f, firstLocation.Y + 0.2f, firstLocation.Z);
                downLeftLine.StartPoint = new Vector3f(firstLocation.X + 7 * dimensionHeight / 8, firstLocation.Y, firstLocation.Z);
                downLeftLine.EndPoint = new Vector3f(firstLocation.X + 7 * dimensionHeight / 8 + 0.2f, firstLocation.Y + 0.2f, firstLocation.Z);
                upRightLine.StartPoint = new Vector3f(secondLocation.X + 7 * dimensionHeight / 8, secondLocation.Y, secondLocation.Z);
                upRightLine.EndPoint = new Vector3f(secondLocation.X + 7 * dimensionHeight / 8 - 0.2f, secondLocation.Y - 0.2f, secondLocation.Z);
                downRightLine.StartPoint = new Vector3f(secondLocation.X + 7 * dimensionHeight / 8, secondLocation.Y, secondLocation.Z);
                downRightLine.EndPoint = new Vector3f(secondLocation.X + 7 * dimensionHeight / 8 + 0.2f, secondLocation.Y - 0.2f, secondLocation.Z);

                rightLine.StartPoint = new Vector3f(secondLocation.X + 7 * dimensionHeight / 8, secondLocation.Y, secondLocation.Z);
                rightLine.EndPoint = new Vector3f(secondLocation.X + 7 * dimensionHeight / 8, secondLocation.Y - Math.Abs(firstLocation.Y - secondLocation.Y) / 2 + textWidth / 2, secondLocation.Z);


                numWidth = secondLocation.Y - firstLocation.Y;
                strNumWidth = "" + numWidth;
                strText.BasePoint=new Vector3f(firstLocation.X + 7 * dimensionHeight / 8, firstLocation.Y + Math.Abs(firstLocation.Y - secondLocation.Y) / 2 - textWidth / 2+0.2f, firstLocation.Z);
               strText.Height=0.5f;
                strText.Value=strNumWidth;
            }
            doc.AddEntity(line1);
            doc.AddEntity(line2);
            doc.AddEntity(leftLine);
            doc.AddEntity(rightLine);
            doc.AddEntity(upLeftLine);
            doc.AddEntity(downLeftLine);
            doc.AddEntity(upRightLine);
            doc.AddEntity(downRightLine);
            doc.AddEntity(strText);
        }

        //画带有四个小矩形的俯视图矩形
        public static void writeTopViewRectangle(DxfDocument dxf, Location location, string[] text, float height, float width, float outer_mid_space, float outer_in_space)
        {
            //outer_in_space模拟height,outer_in_space - outer_mid_space模拟width
            //主要矩形
            writeOuterDoorRectangle(dxf, location, height, width);
            //左上角矩形
            writeOuterDoorRectangle(dxf, new Location(location.X, location.Y + height, location.Z), outer_in_space, outer_in_space - outer_mid_space);
            //右上角
            writeOuterDoorRectangle(dxf, new Location(location.X + width - outer_in_space + outer_mid_space, location.Y + height, location.Z), outer_in_space, outer_in_space - outer_mid_space);
            //左下角
            writeOuterDoorRectangle(dxf, new Location(location.X, location.Y - outer_in_space, location.Z), outer_in_space, outer_in_space - outer_mid_space);
            //右下角
            writeOuterDoorRectangle(dxf, new Location(location.X + width - outer_in_space + outer_mid_space, location.Y - outer_in_space, location.Z), outer_in_space, outer_in_space - outer_mid_space);

        }

        //画完整的一个单门（门闩，把手，支架）
        public static void writeWholeSingleDoor(DxfDocument dxf, Location location, string[] text, float height, float width, float outer_mid_space, float outer_in_space, float barHeight, float barWidth,string upOrDownLayer)
        {
            writeDoorBarRectangle(dxf, location, text, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            float downLeftX=location.X+outer_mid_space-barWidth/2+(outer_in_space-outer_mid_space)/2;
            float downLeftY=location.Y + height / 4;
            writeRepresentDoorBarRectangle(dxf, new Location(downLeftX,downLeftY , location.Z), text, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            float upLeftX = downLeftX;
            float upLeftY = location.Y + 3 * height / 4 - barHeight;
            writeRepresentDoorBarRectangle(dxf, new Location(upLeftX,upLeftY , location.Z), text, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
           
            //画小支架
            if (upOrDownLayer.Equals("downLayer"))
            {
                //左下角
                writeOuterDoorRectangle(dxf, new Location(location.X, location.Y - outer_in_space, location.Z), outer_in_space, outer_in_space - outer_mid_space);
                //右下角
                writeOuterDoorRectangle(dxf, new Location(location.X + width + outer_mid_space - outer_in_space, location.Y - outer_in_space, location.Z), outer_in_space, outer_in_space - outer_mid_space);
            }
            //画门把手
            Handle.Draw(dxf, new Location(location.X + 3 * width / 4, location.Y + 3 * height / 4 - barHeight, location.Z));
            Handle.Draw(dxf, new Location(location.X + 3 * width / 4, location.Y + height / 4, location.Z));
        }

        //画完整的带支架的设备矩形框
        public static void writeWholeMachine(DxfDocument dxf, Location location, string[] text, float height, float width, float outer_mid_space, float outer_in_space, float barHeight, float barWidth,string upOrDownLayer)
        {
            writeDoorRectangle(dxf,location,text,height,width,outer_mid_space,outer_in_space);
            //画小支架
            if (upOrDownLayer.Equals("downLayer"))
            {
                //左下角
                writeOuterDoorRectangle(dxf, new Location(location.X, location.Y - outer_in_space, location.Z), outer_in_space, outer_in_space - outer_mid_space);
                //右下角
                writeOuterDoorRectangle(dxf, new Location(location.X + width + outer_mid_space - outer_in_space, location.Y - outer_in_space, location.Z), outer_in_space, outer_in_space - outer_mid_space);
            }
        }

        //画完整的双门闩的门
        public static void writeWholeDoubleDoor(DxfDocument dxf, Location location, string[] text, float height, float width, float outer_mid_space, float outer_in_space, float barHeight, float barWidth,string upOrDownLayer)
        {
            
            writeDoubleDoorBarRectangle(dxf, location, text, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            //左边的门闩小矩形
            float downLeftX = location.X + outer_mid_space - barWidth / 2 + (outer_in_space - outer_mid_space) / 2;
            float downLeftY = location.Y + height / 4;
            writeRepresentDoorBarRectangle(dxf, new Location(downLeftX, downLeftY, location.Z), text, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            float upLeftX = downLeftX;
            float upLeftY = location.Y + 3 * height / 4 - barHeight;
            writeRepresentDoorBarRectangle(dxf, new Location(upLeftX, upLeftY, location.Z), text, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            //右边的门闩的小矩形
            float downRightX = location.X + width / 2 + width / 14 - barWidth / 2 + (outer_in_space - outer_mid_space) / 2;
            float downRightY = location.Y + height / 4;
            writeRepresentDoorBarRectangle(dxf, new Location(downRightX, downRightY, location.Z), text, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);
            float upRightX = downRightX;
            float upRightY = location.Y + 3 * height / 4 - barHeight;
            writeRepresentDoorBarRectangle(dxf, new Location(upRightX, upRightY, location.Z), text, height, width, outer_mid_space, outer_in_space, barHeight, barWidth);

            //画小支架
            if (upOrDownLayer.Equals("downLayer"))
            {
                //左下角
                writeOuterDoorRectangle(dxf, new Location(location.X, location.Y - outer_in_space, location.Z), outer_in_space, outer_in_space - outer_mid_space);
                //右下角
                writeOuterDoorRectangle(dxf, new Location(location.X + width + outer_mid_space - outer_in_space, location.Y - outer_in_space, location.Z), outer_in_space, outer_in_space - outer_mid_space);
            }
        }
    }
}
