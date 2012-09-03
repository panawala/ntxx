using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WW.Cad.Model;
using WW.Cad.IO;
using WW.Cad.Model.Entities;
using Model.Zutu;
using WW.Math;
using WW.Cad.Model.Tables;
using Model.Pintu;

namespace Annon.Pintu
{
   public class PuzzleService
    {
        public static List<Point3D> positionList = new List<Point3D>();
        public static List<TextValue> textValueList = new List<TextValue>();
        private static DLocation location;//拼到一个图纸中后，Entity应该参照那个的左下角坐标
        private static DLocation relativeStartLocation; //源图纸中Entity的左下角坐标
        private static DLocation rightLocation;
        private static DLocation firstDimensionLocation;
        private static DLocation lastDimensionLocation;
        private static DLocation rightTopDimensionLocation;
        private static DLocation largestLocation;
        private static DLocation topViewLocation;//图纸中应该对应的坐标
        private static DLocation topViewRelativeLocation;//自己本身的相对坐标
        private static DLocation topViewRightLocation;//下一个坐标
        private static DxfModel testModel;
        private static Double frameLastLineX;//frame最后一个vertical Line的位置
        private static DxfTextStyle textStyle = new DxfTextStyle("myStyle", "times.ttf");//字体样式

        public static void puzzle(List<string> dxfFileNameList,List<string> dxfTopViewList,List<TextValue> valueList,string frameName)
        {
            DxfModel targetModel=new DxfModel();
            testModel = targetModel;
            targetModel.TextStyles.Add(textStyle);
            CloneContext cloneContext = new CloneContext(targetModel, ReferenceResolutionType.CloneMissing);
            for (int i = 0; i < dxfFileNameList.Count;i++ )
            {
                    DxfModel sourceModel = DxfReader.Read(dxfFileNameList[i]);
                    //第一个图形作为初始
                    if (i == 0)
                    {
                        //拼到一个图纸中后，Entity应该参照那个的左下角坐标
                        location = getRelativeStartLocation(sourceModel);
                        //源图纸中Entity的左下角坐标
                        relativeStartLocation = getRelativeStartLocation(sourceModel);
                        //保存第一个算好的左下角坐标
                        firstDimensionLocation = location;
                        foreach (DxfEntity entity in sourceModel.Entities)
                        {
                            DxfEntity clonedEntity = (DxfEntity)entity.Clone(cloneContext);
                            clonedEntity = getCaculateLocationEntity(clonedEntity, location, relativeStartLocation);
                            targetModel.Entities.Add(clonedEntity);
                        }
                        rightLocation = getNextStartLocation(positionList);
                        //记录最后一点坐标
                        lastDimensionLocation = rightLocation;
                        //清空坐标位置链表
                        positionList.RemoveAll(name => { return true;});

                        //花标注
                        DxfDimension.Aligned dxfDimension = new DxfDimension.Aligned(targetModel.DefaultDimensionStyle);
                        dxfDimension.ExtensionLine1StartPoint = new Point3D(location.X, location.Y, location.Z);
                        dxfDimension.ExtensionLine2StartPoint = new Point3D(rightLocation.X, rightLocation.Y, rightLocation.Z);
                        dxfDimension.DimensionStyleOverrides.TextHeight = 56d;
                        dxfDimension.DimensionStyleOverrides.ArrowSize = 10d;
                        dxfDimension.Text = getDimensionText(dxfDimension);
                        // dxfDimension.DimensionLineLocation = new Point3D((location.X+rightLocation.X)/2,location.Y-8,location.Z);
                        targetModel.Entities.Add(dxfDimension);
                    }
                    else
                    {
                        location = rightLocation;
                        relativeStartLocation = getRelativeStartLocation(sourceModel);
                        foreach (DxfEntity entity in sourceModel.Entities)
                        {
                            DxfEntity clonedEntity = (DxfEntity)entity.Clone(cloneContext);
                            clonedEntity = getCaculateLocationEntity(clonedEntity, location, relativeStartLocation);
                            targetModel.Entities.Add(clonedEntity);
                        }
                        rightLocation = getNextStartLocation(positionList);
                        lastDimensionLocation = rightLocation;
                        //计算最后一个元素右上角坐标
                        if (i == dxfFileNameList.Count - 1)
                        {
                            rightTopDimensionLocation = getRightTopLocation(positionList);
                            largestLocation = getLargestXLocation(positionList);
                        }

                        positionList.RemoveAll(name => { return true; });

                        //花标注
                        DxfDimension.Aligned dxfDimension = new DxfDimension.Aligned(targetModel.DefaultDimensionStyle);
                        dxfDimension.ExtensionLine1StartPoint = new Point3D(location.X, location.Y, location.Z);
                        dxfDimension.ExtensionLine2StartPoint = new Point3D(rightLocation.X, rightLocation.Y, rightLocation.Z);
                        dxfDimension.DimensionStyleOverrides.TextHeight = 56d;
                        dxfDimension.DimensionStyleOverrides.ArrowSize = 10d;
                        dxfDimension.Text = getDimensionText(dxfDimension);
                        targetModel.Entities.Add(dxfDimension);
                    }    
            }

            DxfDimension.Aligned wholeDxfDimension = new DxfDimension.Aligned(targetModel.DefaultDimensionStyle);
            wholeDxfDimension.ExtensionLine1StartPoint = new Point3D(firstDimensionLocation.X, firstDimensionLocation.Y, firstDimensionLocation.Z);
            wholeDxfDimension.ExtensionLine2StartPoint = new Point3D(lastDimensionLocation.X, lastDimensionLocation.Y, lastDimensionLocation.Z);
            wholeDxfDimension.DimensionStyleOverrides.TextHeight = 56d;
            wholeDxfDimension.DimensionStyleOverrides.ArrowSize = 10d;
            wholeDxfDimension.Text = getDimensionText(wholeDxfDimension);
            wholeDxfDimension.DimensionLineLocation = new Point3D(firstDimensionLocation.X+lastDimensionLocation.X,firstDimensionLocation.Y-1000,firstDimensionLocation.Z);
            targetModel.Entities.Add(wholeDxfDimension);

            DxfDimension.Aligned rightDimension = new DxfDimension.Aligned(targetModel.DefaultDimensionStyle);
            rightDimension.ExtensionLine1StartPoint = new Point3D(lastDimensionLocation.X, lastDimensionLocation.Y, lastDimensionLocation.Z);
            rightDimension.ExtensionLine2StartPoint = new Point3D(rightTopDimensionLocation.X, rightTopDimensionLocation.Y, rightTopDimensionLocation.Z);
            rightDimension.DimensionStyleOverrides.TextHeight = 56d;
            rightDimension.DimensionStyleOverrides.ArrowSize = 10d;
            rightDimension.Text = getDimensionText(rightDimension);
            rightDimension.DimensionLineLocation = new Point3D(largestLocation.X + 200, firstDimensionLocation.Y, firstDimensionLocation.Z);
            targetModel.Entities.Add(rightDimension);

            //绘制俯视图
            for (int i = 0; i < dxfTopViewList.Count;i++ )
            {
                DxfModel topViewSourceModel = new DxfModel();
                topViewSourceModel = DxfReader.Read(dxfTopViewList[i]);
                if (i == 0)
                {
                    topViewLocation = new DLocation(firstDimensionLocation.X, rightTopDimensionLocation.Y + RelativeDistance.yTopViewDistance, firstDimensionLocation.Z);
                    topViewRelativeLocation = getTopViewRelativeStartLocation(topViewSourceModel);
                }
                else
                {
                    topViewLocation = topViewRightLocation;
                        DxfModel filterModel = getFilterBottomNotLineDxfModel(topViewSourceModel);
                        topViewRelativeLocation = getTopViewRelativeStartLocation(filterModel);
                   
                 
                }

                foreach(DxfEntity entity in topViewSourceModel.Entities)
                {
                    DxfEntity clonedEntity = (DxfEntity)entity.Clone(cloneContext);
                    clonedEntity = getCaculateLocationEntity(clonedEntity, topViewLocation, topViewRelativeLocation);
                    targetModel.Entities.Add(clonedEntity);
                }
                topViewRightLocation = getTopViewNextStartLocation(positionList);
                positionList.RemoveAll(name=>{return true;});
            }

            // 复制frame框体
            DxfModel sourceFrameModel = new DxfModel();
            sourceFrameModel = DxfReader.Read(frameName);
            DLocation frameLeftDownLocation = getFrameLeftDownLocation(sourceFrameModel);
            frameLastLineX = getFrameLastVerticalLineX(sourceFrameModel);
            Point2D frameRightPoint2D = getFrameRightPoint(sourceFrameModel);
            //这里求的是宽度比较，因为Frame的最后位置还没确定，不能单纯的考个别点进行位置大小比较
            if ((largestLocation.X-firstDimensionLocation.X+RelativeDistance.xDistance)>= (frameRightPoint2D.X-frameLeftDownLocation.X))
            {
                RelativeDistance.increaseWidth = (largestLocation.X - firstDimensionLocation.X + RelativeDistance.xDistance) - (frameRightPoint2D.X - frameLeftDownLocation.X) + RelativeDistance.xDistance;
            }
            else
            {
                RelativeDistance.increaseWidth = 0;
            }
            foreach (DxfEntity entity in sourceFrameModel.Entities)
            {
                DxfEntity clonedEntity = (DxfEntity)entity.Clone(cloneContext);
                clonedEntity = getFrameEntity(clonedEntity, firstDimensionLocation, frameLeftDownLocation, RelativeDistance.increaseWidth);
                targetModel.Entities.Add(clonedEntity);
            }

            //传递表单数据值
            foreach(TextValue textValue in textValueList){
                foreach(TextValue transFormValue in valueList){
                    if (textValue.text.Equals(transFormValue.text))
                    {
                        DxfText dxfText = new DxfText();
                        dxfText.Text = transFormValue.value;
                        dxfText.Height = textValue.height;
                        dxfText.Thickness = 0.5d;
                        dxfText.AlignmentPoint1 = new Point3D(textValue.valuePosition.X, textValue.valuePosition.Y, textValue.valuePosition.Z);
                        dxfText.AlignmentPoint2 = dxfText.AlignmentPoint1;
                        targetModel.Entities.Add(dxfText);
                    }
                }
            }

            cloneContext.ResolveReferences();

            DxfWriter.Write("cloneTest.dxf", targetModel);
        }
        /// <summary>
        /// 获取计算好的entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="location"></param>
        /// <param name="relativeStartLocation"></param>
        /// <returns></returns>
        public static DxfEntity getCaculateLocationEntity(DxfEntity entity,DLocation location,DLocation relativeStartLocation)
        {
            switch (entity.EntityType){
                case "LINE":
                    {
                    DxfLine dxfLine = (DxfLine)entity;
                    double lineLenght = dxfLine.End.X - dxfLine.Start.X;
                    double lineHeight=dxfLine.End.Y-dxfLine.Start.Y;
                    dxfLine.Start = new Point3D(dxfLine.Start.X - relativeStartLocation.X + location.X, dxfLine.Start.Y - relativeStartLocation.Y + location.Y, location.Z);
                    dxfLine.End = new Point3D(dxfLine.Start.X+lineLenght,dxfLine.Start.Y+lineHeight,location.Z);
                    //只需要将Line的坐标加入，每个图形底部都存在Line
                    if (dxfLine.Start.Y == dxfLine.End.Y||dxfLine.Start.X==dxfLine.End.X)
                    {
                        positionList.Add(dxfLine.Start);
                        positionList.Add(dxfLine.End);
                    } 
                    return dxfLine;
                    };
                case "ARC":
                    {
                    DxfArc dxfArc = (DxfArc)entity;
                    int flag = 0;
                    if (dxfArc.Center.X < 0)
                    {
                        flag = 1;
                    }
                    dxfArc.Center = new Point3D(Math.Abs(dxfArc.Center.X)-relativeStartLocation.X+location.X,dxfArc.Center.Y-relativeStartLocation.Y+location.Y,dxfArc.Center.Z);

                    if (flag == 1)
                    {
                        dxfArc.Center = new Point3D(0 - dxfArc.Center.X, dxfArc.Center.Y, dxfArc.Center.Z);
                    }
                    return dxfArc;
                    };
                case "CIRCLE":
                    {
                        DxfCircle dxfCircle =(DxfCircle)entity;
                        dxfCircle.Center = new Point3D(dxfCircle.Center.X-relativeStartLocation.X+location.X,dxfCircle.Center.Y-relativeStartLocation.Y+location.Y,dxfCircle.Center.Z);
                        return dxfCircle;
                    }
                case "POINT":
                    {
                        DxfPoint dxfPoint = (DxfPoint)entity;
                        dxfPoint.Position = new Point3D(dxfPoint.Position.X - relativeStartLocation.X + location.X, dxfPoint.Position.Y - relativeStartLocation.Y + location.Y, dxfPoint.Position.Z);
                        return dxfPoint;
                    }
                case "TEXT":
                    {
                        DxfText dxfText =(DxfText)entity;
                        dxfText.AlignmentPoint1 = new Point3D(dxfText.AlignmentPoint1.X-relativeStartLocation.X+location.X,dxfText.AlignmentPoint1.Y-relativeStartLocation.Y+location.Y,dxfText.AlignmentPoint1.Z);
                        dxfText.AlignmentPoint2 = dxfText.AlignmentPoint1;
                        return dxfText;
                    }
                case "ELLIPSE":
                    {
                        DxfEllipse dxfEllipse = (DxfEllipse)entity;
                        dxfEllipse.Center = new Point3D(dxfEllipse.Center.X - relativeStartLocation.X + location.X, dxfEllipse.Center.Y - relativeStartLocation.Y + location.Y, dxfEllipse.Center.Z);
                        return dxfEllipse;
                    }
                case "LWPOLYLINE":
                    {
                        DxfLwPolyline dxfLwPolyLine = (DxfLwPolyline)entity;
                        int len = dxfLwPolyLine.Vertices.Count;
                        for (int i = 0; i < len; i++)
                        {
                            dxfLwPolyLine.Vertices[i].Position = new Point2D(dxfLwPolyLine.Vertices[i].Position.X - relativeStartLocation.X + location.X, dxfLwPolyLine.Vertices[i].Position.Y - relativeStartLocation.Y + location.Y);
                        }

                        return dxfLwPolyLine;
                    }
                case "DIMENSION":
                    {
                        DxfDimension.Aligned dxfDimension =(DxfDimension.Aligned)entity;
                        DxfDimension.Aligned tempDemsion = new DxfDimension.Aligned(testModel.DefaultDimensionStyle);
                        dxfDimension.ExtensionLine1StartPoint = new Point3D(dxfDimension.ExtensionLine1StartPoint.X-relativeStartLocation.X+location.X,dxfDimension.ExtensionLine1StartPoint.Y-relativeStartLocation.Y+location.Y,location.Z);
                        dxfDimension.ExtensionLine2StartPoint = new Point3D(dxfDimension.ExtensionLine2StartPoint.X-relativeStartLocation.X+location.X,dxfDimension.ExtensionLine2StartPoint.Y-relativeStartLocation.Y+location.Y,location.Z);
                       // dxfDimension.DimensionLineLocation = new Point3D(dxfDimension.DimensionLineLocation.X-relativeStartLocation.X+location.X,dxfDimension.DimensionLineLocation.Y-relativeStartLocation.Y+location.Y,dxfDimension.DimensionLineLocation.Z);
                        tempDemsion.ExtensionLine1StartPoint = dxfDimension.ExtensionLine1StartPoint;
                        tempDemsion.ExtensionLine2StartPoint = dxfDimension.ExtensionLine2StartPoint;
                        tempDemsion.Color = dxfDimension.Color;
                        tempDemsion.DimensionStyleOverrides.TextHeight = 56d;
                        tempDemsion.DimensionStyleOverrides.ArrowSize = 20d;
                        if (Math.Round(dxfDimension.ExtensionLine1StartPoint.X * 100) / 100 == Math.Round(dxfDimension.ExtensionLine2StartPoint.X * 100) / 100)
                        {
                            tempDemsion.Text = "" + Convert.ToInt32(Math.Abs(dxfDimension.ExtensionLine1StartPoint.Y - dxfDimension.ExtensionLine2StartPoint.Y) + 0.5);
                        }
                        else
                        {
                            tempDemsion.Text = "" + Convert.ToInt32(Math.Abs(dxfDimension.ExtensionLine1StartPoint.X - dxfDimension.ExtensionLine2StartPoint.X) + 0.5);
                        }
                        
                        tempDemsion.DimensionLineLocation = new Point3D(dxfDimension.DimensionLineLocation.X - relativeStartLocation.X + location.X, dxfDimension.DimensionLineLocation.Y - relativeStartLocation.Y + location.Y, dxfDimension.DimensionLineLocation.Z);

                        return tempDemsion;

                    }
                case "INSERT":
                    {
                        DxfInsert dxfInsert = (DxfInsert)entity;

                        //可行，但是存在很多点点
                        dxfInsert.InsertionPoint = new Point3D(dxfInsert.InsertionPoint.X - relativeStartLocation.X + location.X, dxfInsert.InsertionPoint.Y - relativeStartLocation.Y + location.Y, dxfInsert.InsertionPoint.Z);
                        return dxfInsert;
                    }
                case "HATCH":
                    {
                        DxfHatch dxfHatch = (DxfHatch)entity;
                        int len = dxfHatch.BoundaryPaths.Count;
                        for (int i = 0; i < len; i++)
                        {
                            int len1 = dxfHatch.BoundaryPaths[i].Edges.Count;
                            for (int j = 0; j < len1;j++ )
                            {
                                DxfHatch.BoundaryPath.LineEdge lineEdge = (DxfHatch.BoundaryPath.LineEdge)dxfHatch.BoundaryPaths[i].Edges[j];
                                lineEdge.Start = new Point2D(lineEdge.Start.X-relativeStartLocation.X+location.X,lineEdge.Start.Y-relativeStartLocation.Y+location.Y);
                                lineEdge.End = new Point2D(lineEdge.End.X-relativeStartLocation.X+location.X,lineEdge.End.Y-relativeStartLocation.Y+location.Y);
                            }
                        }
                            return dxfHatch;
                    }
                default:return entity;
            }
        }
        /// <summary>
        /// 获取entity右下角坐标(已经计算好的，实体组件计算）
        /// </summary>
        /// <param name="pList"></param>
        /// <param name="relativeStartLocation"></param>
        /// <returns></returns>
        public static DLocation getNextStartLocation(List<Point3D> pList)
        {
            double minY = Double.MaxValue;
            double minX = Double.MinValue;
            DLocation nextStartLocation=new DLocation();
            for (int i = 0; i < pList.Count;i++ )
            {
                if(minY>=pList[i].Y){
                    minY = pList[i].Y;
                    if (minX <= pList[i].X)
                    {
                        minX = pList[i].X;
                        nextStartLocation.X = pList[i].X;
                        nextStartLocation.Y = pList[i].Y;
                        nextStartLocation.Z = pList[i].Z;
                    }
                }
            }
            return nextStartLocation;
        }
       /// <summary>
       /// 计算俯视图下一个坐标使用
       /// </summary>
       /// <param name="pList"></param>
       /// <returns></returns>
        public static DLocation getTopViewNextStartLocation(List<Point3D> pList)
        {
            double minY = Double.MaxValue;
            double minX = Double.MinValue;
            DLocation nextStartLocation = new DLocation();
            for (int i = 0; i < pList.Count; i++)
            {
             
                if (Math.Round(minY*10000)/10000 >= Math.Round(pList[i].Y*10000)/10000)
                {
                    
                    if (Math.Round(minX*10000/10000) <=Math.Round(pList[i].X*10000)/10000)
                    {
                        minY = pList[i].Y;
                        minX = pList[i].X;
                        nextStartLocation.X = pList[i].X;
                        nextStartLocation.Y = pList[i].Y;
                        nextStartLocation.Z = pList[i].Z;
                    }
                }
            }
            return nextStartLocation;
        }
        /// <summary>
        /// 获取实体自己的左下角坐标（没有进行坐标运算前，专门扶着预算实体组件）
        /// </summary>
        /// <param name="sourceModel"></param>
        /// <returns></returns>
        public static DLocation getRelativeStartLocation(DxfModel sourceModel)
        {
            DLocation relativeStartLocation = new DLocation();
            double minX = Double.MaxValue;
            double minY = Double.MaxValue;
            foreach(DxfEntity entity in sourceModel.Entities){
                switch(entity.EntityType){
                    case "LINE":
                        {
                            DxfLine dxfLine = (DxfLine)entity;

                            if (minY >= dxfLine.Start.Y)
                            {
                                minY = dxfLine.Start.Y;
                                if(minX>dxfLine.Start.X){
                                    minX = dxfLine.Start.X;
                                    relativeStartLocation.X = dxfLine.Start.X;
                                    relativeStartLocation.Y = dxfLine.Start.Y;
                                    relativeStartLocation.Z = dxfLine.Start.Z;
                                }
                            }
                            //消除画图人员错误绘制
                            if(minY>=dxfLine.End.Y){
                                minY = dxfLine.End.Y;
                                if(minX>dxfLine.End.X){
                                    minX = dxfLine.End.X;
                                    relativeStartLocation.X = dxfLine.End.X;
                                    relativeStartLocation.Y = dxfLine.End.Y;
                                    relativeStartLocation.Z = dxfLine.End.Z;
                                }
                            }
                        };continue;
                }
            }
            return relativeStartLocation;
        }
       /// <summary>
       /// 负责计算俯视图的函数
       /// </summary>
       /// <param name="sourceModel"></param>
       /// <returns></returns>
        public static DLocation getTopViewRelativeStartLocation(DxfModel sourceModel)
        {


            DLocation relativeStartLocation = new DLocation();
            double minX = Double.MaxValue;
            double minY = Double.MaxValue;

            foreach (DxfEntity entity in sourceModel.Entities)
            {
                switch (entity.EntityType)
                {
                    case "LINE":
                        {
                            DxfLine dxfLine = (DxfLine)entity;

                            if (Math.Round(dxfLine.Start.Y*10000)/10000 == Math.Round(dxfLine.End.Y*10000)/10000)
                            {
                                if (Math.Round(minX*10000)/10000 >= Math.Round(dxfLine.Start.X*10000)/10000)
                                {
                                    if (Math.Round(minY*10000)/10000 >= Math.Round(dxfLine.Start.Y*10000)/10000)
                                    {
                                        minY = dxfLine.Start.Y;
                                        minX = dxfLine.Start.X;
                                        relativeStartLocation.X = dxfLine.Start.X;
                                        relativeStartLocation.Y = dxfLine.Start.Y;
                                        relativeStartLocation.Z = dxfLine.Start.Z;
                                    }
                                }
                            }
                            
                            //消除画图人员错误绘制
                            if (Math.Round(dxfLine.Start.Y * 10000) / 10000 == Math.Round(dxfLine.End.Y * 10000) / 10000)
                            {
                                if (Math.Round(minX * 10000) / 10000 >= Math.Round(dxfLine.End.X * 10000) / 10000)
                                {
                                    if (Math.Round(minY * 10000) / 10000 >= Math.Round(dxfLine.End.Y * 10000) / 10000)
                                    {
                                        minX = dxfLine.End.X;
                                        minY = dxfLine.End.Y;
                                        relativeStartLocation.X = dxfLine.End.X;
                                        relativeStartLocation.Y = dxfLine.End.Y;
                                        relativeStartLocation.Z = dxfLine.End.Z;
                                    }
                                }
                            }
                            
                        }; continue;
                }
            }
            return relativeStartLocation;
        }
       /// <summary>
       /// 过滤掉不符合条件的底部部分，是底部为平整的直线实体，方便计算最左边的顶点
       /// </summary>
       /// <param name="sourceModel"></param>
       /// <returns></returns>
        public static DxfModel getFilterBottomNotLineDxfModel(DxfModel sourceModel)
        {
            DLocation relativeStartLocation = new DLocation();
            double minX = Double.MaxValue;

            foreach (DxfEntity entity in sourceModel.Entities)
            {
                switch (entity.EntityType)
                {
                    case "LINE":
                        {
                            DxfLine dxfLine = (DxfLine)entity;

                            if (Math.Round(dxfLine.Start.Y * 10000) / 10000 == Math.Round(dxfLine.End.Y * 10000) / 10000)
                            {
                                if (Math.Round(minX * 10000) / 10000 >= Math.Round(dxfLine.Start.X * 10000) / 10000)
                                {
                                    minX = dxfLine.Start.X;
                                }
                            }

                            //消除画图人员错误绘制
                            if (Math.Round(dxfLine.Start.Y * 10000) / 10000 == Math.Round(dxfLine.End.Y * 10000) / 10000)
                            {
                                if (Math.Round(minX * 10000) / 10000 >= Math.Round(dxfLine.End.X * 10000) / 10000)
                                {
                                    minX = dxfLine.End.X;
                                }
                            }

                        }; continue;
                }
            }
            //将符合条件的entity加入到DxfModel中
            DxfModel filterModel = new DxfModel();
            foreach(DxfEntity entity in sourceModel.Entities)
            {
                switch(entity.EntityType)
                {
                    case "LINE":
                        {
                            DxfLine dxfLine = (DxfLine)entity;
                            //程序员绘画不规则造成
                            if (Math.Round(dxfLine.Start.X * 10000) / 10000 == Math.Round(minX*10000)/10000||Math.Round(dxfLine.End.X*10000)/10000==Math.Round(minX*10000)/10000)
                            {
                                filterModel.Entities.Add(dxfLine);
                            }
                        }continue;
                }
            }
            return filterModel;
        }
       /// <summary>
       /// 计算最后一个元素右上角坐标
       /// </summary>
       /// <param name="pList"></param>
       /// <returns></returns>
        public static DLocation getRightTopLocation(List<Point3D> pList)
        {
            double minY = Double.MinValue;
            double minX = Double.MinValue;
            DLocation rightTopLocation = new DLocation();
            for (int i = 0; i < pList.Count; i++)
            {
                if (minY <= pList[i].Y)
                {
                    minY = pList[i].Y;
                    if (minX <= pList[i].X)
                    {
                        minX = pList[i].X;
                        rightTopLocation.X = pList[i].X;
                        rightTopLocation.Y = pList[i].Y;
                        rightTopLocation.Z = pList[i].Z;
                    }
                }
            }
            return rightTopLocation;
        }
       /// <summary>
       /// 获得最大的X坐标是为了做标注使用
       /// </summary>
       /// <param name="pList"></param>
       /// <returns></returns>
        public static DLocation getLargestXLocation(List<Point3D> pList)
        {
            double minX = Double.MinValue;
            DLocation largeLocation = new DLocation();
            for (int i = 0; i < pList.Count; i++)
            {
                    if (minX <= pList[i].X)
                    {
                        minX = pList[i].X;
                        largeLocation.X = pList[i].X;
                        largeLocation.Y = pList[i].Y;
                        largeLocation.Z = pList[i].Z;
                    }
                
            }
            return largeLocation;
        }
       /// <summary>
       /// 获得Frame的左下角坐标
       /// </summary>
       /// <param name="sourceModel"></param>
       /// <returns></returns>
        public static DLocation getFrameLeftDownLocation(DxfModel sourceModel)
        {
            DLocation dLocation = new DLocation(0, 0, 0);
            foreach(DxfEntity entity in sourceModel.Entities)
            {
                if (entity.EntityType.Equals("LWPOLYLINE"))
                {
                    DxfLwPolyline dxfLwPolyline=(DxfLwPolyline)entity;
                    DxfLwPolyline.VertexCollection vc = dxfLwPolyline.Vertices;
                    for (int i = 0; i < vc.Count;i++ )
                    {
                        if (i == 0)
                        {
                            dLocation.X = vc[i].Position.X;
                            dLocation.Y = vc[i].Position.Y;
                        }
                        if(dLocation.X>=vc[i].Position.X&&dLocation.Y>=vc[i].Position.Y){
                            dLocation.X = vc[i].Position.X;
                            dLocation.Y = vc[i].Position.Y;
                        }
                    }
                    break;
                }
            }
            return dLocation;

        }
       /// <summary>
       /// 单独用来处理frame的函数
       /// </summary>
       /// <param name="entity"></param>
       /// <param name="location"></param>
       /// <param name="relativeStartLocation"></param>
       /// <returns></returns>
        public static DxfEntity getFrameEntity(DxfEntity entity, DLocation location, DLocation relativeStartLocation,double increaseWidth)
        {
            switch (entity.EntityType)
            {
                case "LINE":
                    {
                        DxfLine dxfLine = (DxfLine)entity;
                        double lineLenght = dxfLine.End.X - dxfLine.Start.X;
                        double lineHeight = dxfLine.End.Y - dxfLine.Start.Y;
                        if (Math.Round(dxfLine.Start.Y * 1000) / 1000 == Math.Round(dxfLine.End.Y * 1000) / 1000)
                        {
                            //消除绘图人员的语法错误
                            if (dxfLine.Start.X > dxfLine.End.X)
                            {
                                dxfLine.Start = new Point3D(dxfLine.Start.X - relativeStartLocation.X + location.X - RelativeDistance.xDistance + increaseWidth, dxfLine.Start.Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfLine.ZAxis.Z);
                                dxfLine.End = new Point3D(dxfLine.Start.X + lineLenght, dxfLine.Start.Y + lineHeight, location.Z);
                            }
                            else
                            {
                                dxfLine.Start = new Point3D(dxfLine.Start.X - relativeStartLocation.X + location.X - RelativeDistance.xDistance, dxfLine.Start.Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfLine.ZAxis.Z);
                                dxfLine.End = new Point3D(dxfLine.Start.X + lineLenght+increaseWidth, dxfLine.Start.Y + lineHeight, location.Z);
                            }
                           
                        }
                        else
                        {
                            if (Math.Round(dxfLine.Start.X * 10) / 10 == Math.Round(frameLastLineX * 10) / 10)
                            {
                                double tempX = dxfLine.Start.X;
                                dxfLine.Start = new Point3D(dxfLine.Start.X - relativeStartLocation.X + location.X - RelativeDistance.xDistance+increaseWidth/2, dxfLine.Start.Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfLine.ZAxis.Z);
                                //因为此处的dxfLine.Start.x==dxfLineEnd.x所以不需要+increaseWidth
                                dxfLine.End = new Point3D(dxfLine.Start.X + lineLenght, dxfLine.Start.Y + lineHeight, location.Z);
                            }
                            else
                            {
                                dxfLine.Start = new Point3D(dxfLine.Start.X - relativeStartLocation.X + location.X - RelativeDistance.xDistance, dxfLine.Start.Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfLine.ZAxis.Z);
                                dxfLine.End = new Point3D(dxfLine.Start.X + lineLenght, dxfLine.Start.Y + lineHeight, location.Z);
                            }
                        }
                        return dxfLine;
                    };
                case "TEXT":
                    {
                        DxfText dxfText = (DxfText)entity;
                        //解决乱码问题
                        dxfText.Style = textStyle;
                        TextValue textValue = new TextValue();
                        if (dxfText.Text.Equals("产品代码:"))
                        {
                            dxfText.AlignmentPoint1 = new Point3D(dxfText.AlignmentPoint1.X - relativeStartLocation.X + location.X - RelativeDistance.xDistance, dxfText.AlignmentPoint1.Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfText.AlignmentPoint1.Z);
                            dxfText.AlignmentPoint2 = dxfText.AlignmentPoint1;
                            textValue.text = dxfText.Text;
                            textValue.height = dxfText.Height;
                            textValue.textPosition = new DLocation(dxfText.AlignmentPoint1.X,dxfText.AlignmentPoint1.Y,dxfText.AlignmentPoint1.Z);
                            textValue.valuePosition = new DLocation(textValue.textPosition.X+4*RelativeDistance.width,textValue.textPosition.Y,textValue.textPosition.Z);
                            textValueList.Add(textValue);
                        }
                        else if (dxfText.Text.Equals("项目名称:"))
                        {
                            dxfText.AlignmentPoint1 = new Point3D(dxfText.AlignmentPoint1.X - relativeStartLocation.X + location.X - RelativeDistance.xDistance, dxfText.AlignmentPoint1.Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfText.AlignmentPoint1.Z);
                            dxfText.AlignmentPoint2 = dxfText.AlignmentPoint1;
                            textValue.text = dxfText.Text;
                            textValue.height = dxfText.Height;
                            textValue.textPosition = new DLocation(dxfText.AlignmentPoint1.X, dxfText.AlignmentPoint1.Y, dxfText.AlignmentPoint1.Z);
                            textValue.valuePosition = new DLocation(textValue.textPosition.X + 4 * RelativeDistance.width, textValue.textPosition.Y, textValue.textPosition.Z);
                            textValueList.Add(textValue);
                        }
                        else if (dxfText.Text.Equals("设备描述:"))
                        {
                            dxfText.AlignmentPoint1 = new Point3D(dxfText.AlignmentPoint1.X - relativeStartLocation.X + location.X - RelativeDistance.xDistance, dxfText.AlignmentPoint1.Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfText.AlignmentPoint1.Z);
                            dxfText.AlignmentPoint2 = dxfText.AlignmentPoint1;
                            textValue.text = dxfText.Text;
                            textValue.height = dxfText.Height;
                            textValue.textPosition = new DLocation(dxfText.AlignmentPoint1.X, dxfText.AlignmentPoint1.Y, dxfText.AlignmentPoint1.Z);
                            textValue.valuePosition = new DLocation(textValue.textPosition.X + 4 * RelativeDistance.width, textValue.textPosition.Y, textValue.textPosition.Z);
                            textValueList.Add(textValue);
                        }
                        else if (dxfText.Text.Equals("买方:"))
                        {
                            dxfText.AlignmentPoint1 = new Point3D(dxfText.AlignmentPoint1.X - relativeStartLocation.X + location.X - RelativeDistance.xDistance, dxfText.AlignmentPoint1.Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfText.AlignmentPoint1.Z);
                            dxfText.AlignmentPoint2 = dxfText.AlignmentPoint1;
                            textValue.text = dxfText.Text;
                            textValue.height = dxfText.Height;
                            textValue.textPosition = new DLocation(dxfText.AlignmentPoint1.X, dxfText.AlignmentPoint1.Y, dxfText.AlignmentPoint1.Z);
                            textValue.valuePosition = new DLocation(textValue.textPosition.X + 2 * RelativeDistance.width, textValue.textPosition.Y, textValue.textPosition.Z);
                            textValueList.Add(textValue);
                        }
                        else if (dxfText.Text.Equals("订单号:"))
                        {
                            dxfText.AlignmentPoint1 = new Point3D(dxfText.AlignmentPoint1.X - relativeStartLocation.X + location.X - RelativeDistance.xDistance, dxfText.AlignmentPoint1.Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfText.AlignmentPoint1.Z);
                            dxfText.AlignmentPoint2 = dxfText.AlignmentPoint1;
                            textValue.text = dxfText.Text;
                            textValue.height = dxfText.Height;
                            textValue.textPosition = new DLocation(dxfText.AlignmentPoint1.X, dxfText.AlignmentPoint1.Y, dxfText.AlignmentPoint1.Z);
                            textValue.valuePosition = new DLocation(textValue.textPosition.X + 3 * RelativeDistance.width, textValue.textPosition.Y, textValue.textPosition.Z);
                            textValueList.Add(textValue);
                        }
                        else if (dxfText.Text.Equals("买方联系人:"))
                        {
                            dxfText.AlignmentPoint1 = new Point3D(dxfText.AlignmentPoint1.X - relativeStartLocation.X + location.X - RelativeDistance.xDistance, dxfText.AlignmentPoint1.Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfText.AlignmentPoint1.Z);
                            dxfText.AlignmentPoint2 = dxfText.AlignmentPoint1;
                            textValue.text = dxfText.Text;
                            textValue.height = dxfText.Height;
                            textValue.textPosition = new DLocation(dxfText.AlignmentPoint1.X, dxfText.AlignmentPoint1.Y, dxfText.AlignmentPoint1.Z);
                            textValue.valuePosition = new DLocation(textValue.textPosition.X + 5 * RelativeDistance.width, textValue.textPosition.Y, textValue.textPosition.Z);
                            textValueList.Add(textValue);
                        }
                        else if (dxfText.Text.Equals("易龙销售:"))
                        {
                            dxfText.AlignmentPoint1 = new Point3D(dxfText.AlignmentPoint1.X - relativeStartLocation.X + location.X - RelativeDistance.xDistance, dxfText.AlignmentPoint1.Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfText.AlignmentPoint1.Z);
                            dxfText.AlignmentPoint2 = dxfText.AlignmentPoint1;
                            textValue.text = dxfText.Text;
                            textValue.height = dxfText.Height;
                            textValue.textPosition = new DLocation(dxfText.AlignmentPoint1.X, dxfText.AlignmentPoint1.Y, dxfText.AlignmentPoint1.Z);
                            textValue.valuePosition = new DLocation(textValue.textPosition.X + 4 * RelativeDistance.width, textValue.textPosition.Y, textValue.textPosition.Z);
                            textValueList.Add(textValue);
                        }
                        else if (dxfText.Text.Equals("软件序列号:"))
                        {
                            dxfText.AlignmentPoint1 = new Point3D(dxfText.AlignmentPoint1.X - relativeStartLocation.X + location.X - RelativeDistance.xDistance, dxfText.AlignmentPoint1.Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfText.AlignmentPoint1.Z);
                            dxfText.AlignmentPoint2 = dxfText.AlignmentPoint1;
                            textValue.text = dxfText.Text;
                            textValue.height = dxfText.Height;
                            textValue.textPosition = new DLocation(dxfText.AlignmentPoint1.X, dxfText.AlignmentPoint1.Y, dxfText.AlignmentPoint1.Z);
                            textValue.valuePosition = new DLocation(textValue.textPosition.X + 5 * RelativeDistance.width, textValue.textPosition.Y, textValue.textPosition.Z);
                            textValueList.Add(textValue);
                        }
                        else if (dxfText.Text.Equals("系列号:"))
                        {
                            dxfText.AlignmentPoint1 = new Point3D(dxfText.AlignmentPoint1.X - relativeStartLocation.X + location.X - RelativeDistance.xDistance, dxfText.AlignmentPoint1.Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfText.AlignmentPoint1.Z);
                            dxfText.AlignmentPoint2 = dxfText.AlignmentPoint1;
                            textValue.text = dxfText.Text;
                            textValue.height = dxfText.Height;
                            textValue.textPosition = new DLocation(dxfText.AlignmentPoint1.X, dxfText.AlignmentPoint1.Y, dxfText.AlignmentPoint1.Z);
                            textValue.valuePosition = new DLocation(textValue.textPosition.X + 3 * RelativeDistance.width, textValue.textPosition.Y, textValue.textPosition.Z);
                            textValueList.Add(textValue);
                        }
                        else if (dxfText.Text.Equals("时间:"))
                        {
                            dxfText.AlignmentPoint1 = new Point3D(dxfText.AlignmentPoint1.X - relativeStartLocation.X + location.X - RelativeDistance.xDistance + increaseWidth / 2, dxfText.AlignmentPoint1.Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfText.AlignmentPoint1.Z);
                            dxfText.AlignmentPoint2 = dxfText.AlignmentPoint1;
                            textValue.text = dxfText.Text;
                            textValue.height = dxfText.Height;
                            textValue.textPosition = new DLocation(dxfText.AlignmentPoint1.X, dxfText.AlignmentPoint1.Y, dxfText.AlignmentPoint1.Z);
                            textValue.valuePosition = new DLocation(textValue.textPosition.X + 2 * RelativeDistance.width, textValue.textPosition.Y, textValue.textPosition.Z);
                            textValueList.Add(textValue);
                        }
                        else
                        {
                            dxfText.AlignmentPoint1 = new Point3D(dxfText.AlignmentPoint1.X - relativeStartLocation.X + location.X - RelativeDistance.xDistance, dxfText.AlignmentPoint1.Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfText.AlignmentPoint1.Z);
                            dxfText.AlignmentPoint2 = dxfText.AlignmentPoint1;
                        }
                        return dxfText;
                    }
                case "ELLIPSE":
                    {
                        DxfEllipse dxfEllipse = (DxfEllipse)entity;
                        dxfEllipse.Center = new Point3D(dxfEllipse.Center.X - relativeStartLocation.X + location.X-RelativeDistance.xDistance, dxfEllipse.Center.Y - relativeStartLocation.Y + location.Y-RelativeDistance.yDistance, dxfEllipse.Center.Z);
                        return dxfEllipse;
                    }
                case "LWPOLYLINE":
                    {
                        DxfLwPolyline dxfLwPolyLine = (DxfLwPolyline)entity;
                        int len = dxfLwPolyLine.Vertices.Count;
                       
                        //获得Frame最右边的X值
                        Point2D rightPoint2d = getFrameRightX(dxfLwPolyLine.Vertices);

                        for (int i = 0; i < len; i++)
                        {
                            if (isPolyLinePoint(rightPoint2d, dxfLwPolyLine.Vertices[i].Position))
                            {
                                dxfLwPolyLine.Vertices[i].Position = new Point2D(dxfLwPolyLine.Vertices[i].Position.X - relativeStartLocation.X + location.X - RelativeDistance.xDistance+increaseWidth, dxfLwPolyLine.Vertices[i].Position.Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance);
                            }
                            else
                            {
                                dxfLwPolyLine.Vertices[i].Position = new Point2D(dxfLwPolyLine.Vertices[i].Position.X - relativeStartLocation.X + location.X - RelativeDistance.xDistance, dxfLwPolyLine.Vertices[i].Position.Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance);
                            }
                        }

                        return dxfLwPolyLine;
                    }
                case "SOLID":
                    {
                        DxfSolid dxfSolid = (DxfSolid)entity;
                        
                        int len = dxfSolid.Points.Count;
                        for (int i = 0; i < len;i++ )
                        {
                            //可能会出问题
                            if(i==1||i==3)
                            dxfSolid.Points[i] = new Point3D(dxfSolid.Points[i].X - relativeStartLocation.X + location.X - RelativeDistance.xDistance+increaseWidth, dxfSolid.Points[i].Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfSolid.Points[i].Z);
                            else
                            dxfSolid.Points[i] = new Point3D(dxfSolid.Points[i].X - relativeStartLocation.X + location.X - RelativeDistance.xDistance, dxfSolid.Points[i].Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfSolid.Points[i].Z);
                        }
                        return dxfSolid;
                    }
                case "SPLINE":
                    {
                        DxfSpline dxfSpline = (DxfSpline)entity;
                        int len=dxfSpline.ControlPoints.Count;
                        for (int i = 0; i < len;i++ )
                        {
                            dxfSpline.ControlPoints[i] = new Point3D(dxfSpline.ControlPoints[i].X - relativeStartLocation.X + location.X- RelativeDistance.xDistance, dxfSpline.ControlPoints[i].Y - relativeStartLocation.Y + location.Y - RelativeDistance.yDistance, dxfSpline.ControlPoints[i].Z);
                        }
                        return dxfSpline;
                    }
                default: return entity;
            }
        }
       /// <summary>
       /// 自动扩展Frame用的判段函数
       /// </summary>
       /// <param name="vertices"></param>
       /// <param name="point2d"></param>
       /// <returns></returns>
        public static Boolean isPolyLinePoint(Point2D rightPoint2d,Point2D point2d)
        {
            //Point2D tempPoint2D = new Point2D(0,0);
            //for (int i = 0; i < vertices.Count;i++ )
            //{
            //   if(i==0)
            //   {
            //       tempPoint2D = vertices[i].Position;
            //   }
            //   if(tempPoint2D.X<=vertices[i].Position.X&&tempPoint2D.Y<=vertices[i].Position.Y)
            //   {
            //       tempPoint2D.X = vertices[i].Position.X;
            //       tempPoint2D.Y = vertices[i].Position.Y;
            //   }
            //}
            if ((Math.Round(point2d.X * 10) / 10).Equals(Math.Round(rightPoint2d.X * 10) / 10))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       /// <summary>
       /// h 获取Frame最右边的点坐标，用来动态增加框体的宽度
       /// </summary>
       /// <param name="vertices"></param>
       /// <returns></returns>
        public static Point2D getFrameRightX(DxfLwPolyline.VertexCollection vertices)
        {
            Point2D tempPoint2D = new Point2D(0, 0);
            for (int i = 0; i < vertices.Count; i++)
            {
                if (i == 0)
                {
                    tempPoint2D = vertices[i].Position;
                }
                if (tempPoint2D.X <= vertices[i].Position.X && tempPoint2D.Y <= vertices[i].Position.Y)
                {
                    tempPoint2D.X = vertices[i].Position.X;
                    tempPoint2D.Y = vertices[i].Position.Y;
                }
            }

            return tempPoint2D;
        }
       /// <summary>
        /// 获取Frame最右边的点坐标，用来动态增加框体的宽度
       /// </summary>
       /// <param name="sourceFrameModel"></param>
       /// <returns></returns>
        public static Point2D getFrameRightPoint(DxfModel sourceFrameModel)
        {
            foreach(DxfEntity entity in sourceFrameModel.Entities)
            {
                switch (entity.EntityType)
                {
                    case "LWPOLYLINE":
                        {
                            DxfLwPolyline dxfLwPolyLine = (DxfLwPolyline)entity;
                            DxfLwPolyline.VertexCollection vertices = dxfLwPolyLine.Vertices;
                            return getFrameRightX(vertices);
                        }
                }
            }
            return new Point2D(0,0);
        }

       /// <summary>
       /// 设置标注的文本信息
       /// </summary>
       /// <param name="dxfDimension"></param>
       /// <returns></returns>
        public static string getDimensionText(DxfDimension.Aligned dxfDimension)
        {
            string text = "";
            if (Math.Round(dxfDimension.ExtensionLine1StartPoint.X * 100) / 100 == Math.Round(dxfDimension.ExtensionLine2StartPoint.X * 100) / 100)
            {
                text = "" + Convert.ToInt32(Math.Abs(dxfDimension.ExtensionLine1StartPoint.Y - dxfDimension.ExtensionLine2StartPoint.Y) + 0.5);
            }
            else
            {
                text = "" + Convert.ToInt32(Math.Abs(dxfDimension.ExtensionLine1StartPoint.X - dxfDimension.ExtensionLine2StartPoint.X) + 0.5);
            }
            return text;
        }
       /// <summary>
       /// 动态移动frame的最后一个vertical line的position
       /// </summary>
       /// <param name="frameModel"></param>
       /// <returns></returns>
        public static double getFrameLastVerticalLineX(DxfModel frameModel)
        {
            double tempX = Double.MinValue;
            foreach(DxfEntity entity in frameModel.Entities){
                switch(entity.EntityType){
                    case "LINE":
                        {
                            DxfLine dxfLine=(DxfLine)entity;
                            if (tempX <= dxfLine.Start.X)
                            {
                                tempX = dxfLine.Start.X;
                            }
                        }continue;
                }
            }
            return tempX;
        }

    }
}
