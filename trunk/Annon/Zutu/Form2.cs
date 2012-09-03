using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Annon.Pintu;
using System.IO;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using Model.Pintu;
using WW.Cad.IO;
using WW.Math;
using WW.Cad.Model.Tables;

namespace Annon.Zutu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DxfViewer dv = new DxfViewer();
            dv.setDxfFile("cloneTest.dxf");
            dv.SetDesktopLocation(100, 100);
            dv.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //FecthDxfService fds = new FecthDxfService();
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.ShowDialog();
            //if (openFileDialog.FileName.Trim() != "")
            //{
            //    string path = openFileDialog.FileName;
            //    fds.fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            //    fds.sr = new StreamReader(fds.fs);
            //    fds.Read();
            //}

            //DxfModel dxfModel = new DxfModel();
            
            ////MessageBox.Show(fds.LineList.Count+"");
            //for (int i = 0; i < fds.LineList.Count;i++ )
            //{
            //    DxfLine dxfLine = new DxfLine();
            //    LINE tempLine = new LINE();
            //    tempLine = fds.LineList[i];
            //    dxfLine.Start = new WW.Math.Point3D(tempLine.StartX, tempLine.StartY, 0);
            //    dxfLine.End = new WW.Math.Point3D(tempLine.EndX, tempLine.EndY, 0);
            //    dxfModel.Entities.Add(dxfLine);
            //}

           
           
            
            //DxfWriter.Write("test1.dxf", dxfModel, false);
            //DxfWriter.Write("test2.dxf", dxfModel, true);

            //DxfModel surcedfm = new DxfModel();
            //surcedfm = DxfReader.Read("1.dxf");
            //DxfModel s2 = new DxfModel();
            //s2 = DxfReader.Read("2.dxf");
            //DxfModel s3 = new DxfModel();
            //s3= DxfReader.Read("3.dxf");
            DxfModel s4 = new DxfModel();
            s4 = DxfReader.Read("test.dxf");
            DxfModel targetModel = new DxfModel();

            //////// The ReferenceResolutionType.CloneMissing will result in the DASH_DOT line type created
            //////// above to also be cloned indirectly as a result of cloning the entities.
            CloneContext cloneContext = new CloneContext(targetModel, ReferenceResolutionType.CloneMissing);
            StreamWriter sw = new StreamWriter(@"EntityType.txt", true);
            //int x = 0;
            //int y = 0;
            //foreach (DxfEntity entity in surcedfm.Entities)
            //{
            //    DxfEntity clonedEntity = (DxfEntity)entity.Clone(cloneContext);
                
            //    //sw.WriteLine(clonedEntity.EntityType);
            //    string entityType=clonedEntity.EntityType;
                
            //    targetModel.Entities.Add(clonedEntity);

            //}

            //foreach (DxfEntity entity in s2.Entities)
            //{
            //    DxfEntity clonedEntity = (DxfEntity)entity.Clone(cloneContext);
            //    //sw.WriteLine(clonedEntity.EntityType);
            //    targetModel.Entities.Add(clonedEntity);
            //}

            //foreach (DxfEntity entity in s3.Entities)
            //{
            //    DxfEntity clonedEntity = (DxfEntity)entity.Clone(cloneContext);
            //   // sw.WriteLine(clonedEntity.EntityType);
            //    targetModel.Entities.Add(clonedEntity);
            //}

            foreach (DxfEntity entity in s4.Entities)
            {
                DxfEntity clonedEntity = (DxfEntity)entity.Clone(cloneContext);
                sw.WriteLine(clonedEntity.EntityType);
                targetModel.Entities.Add(clonedEntity);
            }

            //cloneContext.ResolveReferences();

            ////DxfWriter.Write("clone_source.dxf", sourceModel);
            DxfWriter.Write("clone_target1.dxf", targetModel);

           // DxfModel dxfM = new DxfModel();


           // DxfArc arc = new DxfArc();

           // arc.Center = new Point3D(-2d, 2d, 0);
           // arc.Radius=2d;
           // arc.StartAngle=0;
           // arc.EndAngle=Math.PI*0.3;

           
           // dxfM.Entities.Add(arc);
           //DxfWriter.Write("dxfArc.dxf", dxfM);

            DxfModel dxfModel = new DxfModel();
            Point2D [] p=new Point2D[4];
            p[0].X = 100;
            p[0].Y = 100;
            p[1].X = 1100;
            p[1].Y = 100;
            p[2].X = 1100;
            p[2].Y = 1100;
            p[3].X = 100;
            p[3].Y =1100;
            //p[4].X = 100;
            //p[4].Y = 100;
            DxfLwPolyline.VertexCollection vc = new DxfLwPolyline.VertexCollection(p);
            DxfLwPolyline testPolyLine = new DxfLwPolyline(p);
            testPolyLine.ConstantWidth = 10;
            testPolyLine.Plinegen = true;
            testPolyLine.Closed = true;
            dxfModel.Entities.Add(testPolyLine);
            DxfWriter.Write("test.dxf",dxfModel);

            DxfModel model = new DxfModel();

            DxfSolid solid = new DxfSolid();
            solid.Color = EntityColors.LightGreen;
            // A solid must have exactly 4 vertexes (the last 2 vertexes may be identical).
            solid.Points.Add(new Point3D(2d, 1d, 01));
            solid.Points.Add(new Point3D(6d, 1d, 01));
            // The 3rd and 4th vertexes are swapped always.
            solid.Points.Add(new Point3D(2d, 5d, 01));
            solid.Points.Add(new Point3D(6d, 5d, 01));
            model.Entities.Add(solid);

            DxfWriter.Write("DxfWriteSolidTest.dxf", model, false);
            Test1();

           if (comboBox1.Text != null && comboBox2 != null && comboBox2.Text != null && comboBox3.Text != null && comboBox4.Text != null)
           {
               //List<string> list = new List<string>() {"1.dxf", "2.dxf", "3.dxf", "4.dxf" };
               string frameName = "frame.dxf";
               //MessageBox.Show(comboBox1.Text);
               List<string> list = new List<string>();
               list.Add(comboBox1.Text);
               list.Add(comboBox2.Text);
               list.Add(comboBox3.Text);
               list.Add(comboBox4.Text);
               List<string> topViewList = new List<string>() { comboBox1.Text.Substring(0,1)+"E.dxf", comboBox2.Text.Substring(0,1)+"E.dxf", comboBox3.Text.Substring(0,1)+"E.dxf",comboBox4.Text.Substring(0,1)+"E.dxf"};
               List<TextValue> valueList = new List<TextValue>() {new TextValue{text="产品代码:",value="0000001"},
                   new TextValue{text="项目名称:",value="0000001"} ,
               new TextValue{text="设备描述:",value="0000002"} ,
               new TextValue{text="买方:",value="石宏伟"} ,
               new TextValue{text="订单号:",value="0000001"} ,
               new TextValue{text="系列号:",value="0000001"} ,
               new TextValue{text="时间:",value="2012-08-27"} ,
               new TextValue{text="买方联系人:",value="0000001"} ,
               new TextValue{text="易龙销售:",value="0000001"} ,
               new TextValue{text="软件序列号:",value="0000001"}};
               PuzzleService.puzzle(list, topViewList,valueList, frameName);
           }
           else
           {
               MessageBox.Show("请将排序图纸选全!");
           }
        }

        public void Test()
        {
            DxfModel model = new DxfModel(DxfVersion.Dxf14);

            DxfHatch hatch = new DxfHatch();
            hatch.Color = EntityColors.Green;
            hatch.ElevationPoint = new Point3D(10,10, 0);
            hatch.ZAxis = new Vector3D(0, 0, 0);

            // A boundary path bounded by lines.
            DxfHatch.BoundaryPath boundaryPath1 = new DxfHatch.BoundaryPath();
            boundaryPath1.Type = BoundaryPathType.None;
            hatch.BoundaryPaths.Add(boundaryPath1);
            boundaryPath1.Edges.Add(new DxfHatch.BoundaryPath.LineEdge(new Point2D(0, 0), new Point2D(1, 0)));
            boundaryPath1.Edges.Add(new DxfHatch.BoundaryPath.LineEdge(new Point2D(1, 0), new Point2D(1, 1)));
            boundaryPath1.Edges.Add(new DxfHatch.BoundaryPath.LineEdge(new Point2D(1, 1), new Point2D(0, 1)));
            boundaryPath1.Edges.Add(new DxfHatch.BoundaryPath.LineEdge(new Point2D(0, 1), new Point2D(0, 0)));

         

            // Define the hatch fill pattern.
            // Don't set a pattern for solid fill.
            hatch.Pattern = new DxfPattern();
            DxfPattern.Line patternLine = new DxfPattern.Line();
            hatch.Pattern.Lines.Add(patternLine);
            patternLine.Angle = System.Math.PI / 4d;
            patternLine.Offset = new Vector2D(0.02, -0.01d);
            patternLine.DashLengths.Add(0.02d);
            patternLine.DashLengths.Add(-0.01d);
            patternLine.DashLengths.Add(0d);
            patternLine.DashLengths.Add(-0.01d);

            model.Entities.Add(hatch);

            DxfWriter.Write("DxfWriteHatchTest.dxf", model, false);
        }

        public void Test1()
        {
            DxfModel model = new DxfModel(DxfVersion.Dxf14);

            // Create block.
            DxfBlock block = new DxfBlock("TEST_BLOCK");
            model.Blocks.Add(block);
            block.Entities.Add(new DxfCircle(EntityColors.Blue, Point3D.Zero, 2d));
            block.Entities.Add(new DxfLine(EntityColors.Red, Point3D.Zero, new Point3D(-1, 2, 1)));
            block.Entities.Add(new DxfLine(EntityColors.Green, Point3D.Zero, new Point3D(2, 0, 1)));

            // Insert block at 3 positions.
            model.Entities.Add(new DxfInsert(block, new Point3D(1, 0, 0)));
            model.Entities.Add(new DxfInsert(block, new Point3D(3, 1, 0)));
            model.Entities.Add(new DxfInsert(block, new Point3D(2, -3, 0)));

            DxfInsert dxfInsert = new DxfInsert();
            dxfInsert.InsertionPoint = new Point3D(10,10,0);
            model.Entities.Add(dxfInsert);

            DxfWriter.Write("DxfWriteInsertTest.dxf", model, false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Annon.Report.Form1().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Annon.Report.Form2().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Annon.Report.Form3().ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Annon.Report.Form4().ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Annon.Report.Form5().ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new Annon.Report.Form6().ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new Annon.Report.Form7().ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new Annon.Report.Form8().ShowDialog();
        }


    }
}
