using System;
using System.Collections.Generic;
using System.Drawing;
using WW.Actions;
using WW.Cad.Drawing;
using WW.Cad.Drawing.GDI;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;
using WW.Cad.IO;
using System.IO;
using System.Drawing.Printing;
using WW.Cad.Base;
using System.Windows.Forms;

namespace CustomControl
{
    /// <summary>
    /// This is a control that shows a DxfModel.
    /// Dragging with the mouse pans the drawing.
    /// Clicking on the drawing selects the closest entity and
    /// shows it in the property grid.
    /// Using the scroll wheel zooms in on the mouse position.
    /// </summary>
    public partial class ViewControl : UserControl {
        private DxfModel model;
        private GDIGraphics3D gdiGraphics3D;
        private Bounds3D bounds;
        private Matrix4D from2DTransform;
        private Point mouseClickLocation;
        private bool mouseDown;
        private bool shiftPressed;

        #region zooming and panning
        private SimpleTransformationProvider3D transformationProvider;
        private SimplePanInteractor panInteractor;
        private SimpleRectZoomInteractor rectZoomInteractor;
        private SimpleZoomWheelInteractor zoomWheelInteractor;
        private IInteractorWinFormsDrawable rectZoomInteractorDrawable;
        private IInteractorWinFormsDrawable currentInteractorDrawable;
        #endregion

        //public event EventHandler<EntityEventArgs> EntitySelected;

        public ViewControl() {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            GraphicsConfig graphicsConfig = new GraphicsConfig();
            //graphicsConfig.BackColor = BackColor;
            graphicsConfig.CorrectColorForBackgroundColor = true;
            gdiGraphics3D = new GDIGraphics3D(graphicsConfig);
            bounds = new Bounds3D();

            transformationProvider = new SimpleTransformationProvider3D();
            transformationProvider.TransformsChanged += new EventHandler(transformationProvider_TransformsChanged);
            panInteractor = new SimplePanInteractor(transformationProvider);
            rectZoomInteractor = new SimpleRectZoomInteractor(transformationProvider);
            zoomWheelInteractor = new SimpleZoomWheelInteractor(transformationProvider);
            rectZoomInteractorDrawable = new SimpleRectZoomInteractor.WinFormsDrawable(rectZoomInteractor);
        }

        public DxfModel Model {
            get { 
                return model; 
            }
            set { 
                model = value;
                if (model != null) {
                    gdiGraphics3D.CreateDrawables(model);
                    // Uncomment for rotation example.
                    //			transformationProvider.WorldTransform = Transformation4D.RotateX(-30d * Math.PI / 180d) *
                    //				Transformation4D.RotateZ(150d * Math.PI / 180d);
                    gdiGraphics3D.BoundingBox(bounds, transformationProvider.WorldTransform);
                    transformationProvider.ResetTransforms(bounds);
                    CalculateTo2DTransform();
                    Invalidate();
                }
            }
        }

        public void PrintDwf()
        {
            //�����ĵ���
            printDocument.DocumentName = "������";//���������ڴ�ӡ�Ի��򼰶�������ʾ��Ĭ����ʾdocument��

            //����ֽ�Ŵ�С�����Բ�����ȡ��ȡĬ�����ã�
            PaperSize ps = new PaperSize("Your Paper Name", 100, 70);
            ps.RawKind = 150; //������Զ���ֽ�ţ���Ҫ����118����A4ֵΪ9����ϸֽ��������ֵ�Ķ����뿴http://msdn.microsoft.com/zh-tw/library/system.drawing.printing.papersize.rawkind(v=vs.85).aspx��
            printDocument.DefaultPageSettings.PaperSize = ps;

            //��ӡ��ʼǰ
            printDocument.BeginPrint += new PrintEventHandler(printDocument_BeginPrint);
            //��ӡ��������̣�
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            //��ӡ����
            printDocument.EndPrint += new PrintEventHandler(printDocument_EndPrint);

            //������ӡ�Ի����ṩ��ӡ�������ӻ����ã���ѡ���ĸ���ӡ����ӡ���ĵ���
            PrintDialog pd = new PrintDialog();
            pd.Document = printDocument;
            if (DialogResult.OK == pd.ShowDialog()) //���ȷ�ϣ����Ḳ�����еĴ�ӡ��������
            {
                //ҳ�����öԻ��򣨿��Բ�ʹ�ã���ʵPrintDialog�Ի������ṩҳ�����ã�
                PageSetupDialog psd = new PageSetupDialog();
                psd.Document = printDocument;
                if (DialogResult.OK == psd.ShowDialog())
                {
                    //��ӡԤ��
                    PrintPreviewDialog ppd = new PrintPreviewDialog();
                    ppd.Document = printDocument;
                    if (DialogResult.OK == ppd.ShowDialog())
                        printDocument.Print();          //��ӡ
                }
            }
            
        }



        //PrintDocument����ʵ�ִ�ӡ���ܵĺ��ģ�����װ�˴�ӡ�йص����ԡ��¼����ͷ���
        PrintDocument printDocument = new PrintDocument();


        void printDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            //Ҳ���԰�һЩ��ӡ�Ĳ������ڴ˴�����
        }

        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            //��ӡɶ����������д��
            Graphics g = e.Graphics;
            Brush b = new SolidBrush(System.Drawing.Color.Black);
            Font titleFont = new Font("����", 16);
            string title = "���ֵ�÷��������������վ ������";
            g.DrawString(title, titleFont, b, new PointF((e.PageBounds.Width - g.MeasureString(title, titleFont).Width) / 2, 20));
            //g.DrawLine(new Pen(System.Drawing.Color.White), new Point(1, 1), new Point(200, 200));
            g.Clear(System.Drawing.Color.White);
            gdiGraphics3D.Draw(g, e.PageBounds, CalculateTo2DTransform(), System.Drawing.Color.White);

            //e.Cancel//��ȡ�������Ƿ�ȡ����ӡ
            //e.HasMorePages    //Ϊtrueʱ���ú���ִ����Ϻ󻹻�����ִ��һ�飨�����ڶ�̬��ҳ��
        }

        void printDocument_EndPrint(object sender, PrintEventArgs e)
        {
            //��ӡ��������ز���
        }


        public void Export(string outfile)
        {
            //string outfile = sfd.FileName;//= Path.GetFileNameWithoutExtension(Path.GetFullPath(filename));
            Stream stream;

            BoundsCalculator boundsCalculator = new BoundsCalculator();
            boundsCalculator.GetBounds(model);
            Bounds3D bounds = boundsCalculator.Bounds;
            PaperSize paperSize = PaperSizes.GetPaperSize(PaperKind.Letter);
            // Lengths in inches.
            float pageWidth = (float)paperSize.Width / 100f;
            float pageHeight = (float)paperSize.Height / 100f;
            float margin = 0.5f;
            // Scale and transform such that its fits max width/height
            // and the top left middle of the cad drawing will match the 
            // top middle of the pdf page.
            // The transform transforms to pdf pixels.
            Matrix4D to2DTransform = DxfUtil.GetScaleTransform(
                bounds.Corner1,
                bounds.Corner2,
                new Point3D(bounds.Center.X, bounds.Corner2.Y, 0d),
                new Point3D(new Vector3D(margin, margin, 0d) * PdfExporter.InchToPixel),
                new Point3D(new Vector3D(pageWidth - margin, pageHeight - margin, 0d) * PdfExporter.InchToPixel),
                new Point3D(new Vector3D(pageWidth / 2d, pageHeight - margin, 0d) * PdfExporter.InchToPixel)
            );
            using (stream = File.Create(outfile))
            {
                PdfExporter pdfGraphics = new PdfExporter(stream);
                pdfGraphics.DrawPage(
                    model,
                    GraphicsConfig.WhiteBackgroundCorrectForBackColor,
                    to2DTransform,
                    paperSize
                );
                pdfGraphics.EndDocument();
            }

        }


        public Point2D GetModelSpaceCoordinates(Point2D screenSpaceCoordinates) {
            return from2DTransform.TransformTo2D(screenSpaceCoordinates);
        }

        protected override void OnPaint(PaintEventArgs e) {
            Graphics gr = e.Graphics;
            gdiGraphics3D.Draw(e.Graphics, ClientRectangle, CalculateTo2DTransform(), System.Drawing.Color.White);
            if (currentInteractorDrawable != null)
            {
                currentInteractorDrawable.Draw(
                    e,
                    new InteractorDrawableContext(
                        GetClientRectangle2D(),
                        transformationProvider.CompleteTransform,
                        new ArgbColor(BackColor.ToArgb())
                    )
                );
            }
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            CalculateTo2DTransform();
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);
            mouseClickLocation = e.Location;
            mouseDown = true;
            shiftPressed = ModifierKeys == Keys.Shift;
            if (shiftPressed) {
                rectZoomInteractor.Activate();
                rectZoomInteractor.ProcessMouseButtonDown(new CanonicalMouseEventArgs(e), GetInteractionContext());
                currentInteractorDrawable = rectZoomInteractorDrawable;
            } else {
                panInteractor.Activate();
                panInteractor.ProcessMouseButtonDown(new CanonicalMouseEventArgs(e), GetInteractionContext());
            }
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);
            if (mouseDown == true) {
                if (shiftPressed) {
                    rectZoomInteractor.ProcessMouseMove(new CanonicalMouseEventArgs(e), GetInteractionContext());
                } else {
                    panInteractor.ProcessMouseMove(new CanonicalMouseEventArgs(e), GetInteractionContext());
                }
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
            mouseDown = false;

            // Use shift key for rectangle zoom.
            if (shiftPressed) {
                rectZoomInteractor.ProcessMouseButtonUp(new CanonicalMouseEventArgs(e), GetInteractionContext());
                rectZoomInteractor.Deactivate();
                Invalidate();
            } else {
                panInteractor.Deactivate();

                // Select entity at mouse location if mouse didn't move
                // and show entity in property grid.
                if (mouseClickLocation == e.Location) {
                    Point2D referencePoint = new Point2D(e.X, e.Y);
                    double distance;
                    IList<RenderedEntityInfo> closestEntities =
                        EntitySelector.GetClosestEntities(
                            model,
                            GraphicsConfig.BlackBackgroundCorrectForBackColor,
                            gdiGraphics3D.To2DTransform,
                            referencePoint,
                            out distance
                        );
                    if (closestEntities.Count > 0) {
                        DxfEntity entity = closestEntities[0].Entity;
                        //OnEntitySelected(new EntityEventArgs(entity));
                    }
                }
            }
            currentInteractorDrawable = null;
        }

        protected override void OnMouseWheel(MouseEventArgs e) {
            base.OnMouseWheel(e);

            zoomWheelInteractor.Activate();
            zoomWheelInteractor.ProcessMouseWheel(new CanonicalMouseEventArgs(e), GetInteractionContext());
            zoomWheelInteractor.Deactivate();

            Invalidate();
        }

        //protected virtual void OnEntitySelected(EntityEventArgs e) {
        //    if (EntitySelected != null) {
        //        EntitySelected(this, e);
        //    }
        //}

        private Matrix4D CalculateTo2DTransform() {
            if (transformationProvider == null)
                transformationProvider = new SimpleTransformationProvider3D();
            transformationProvider.ViewWindow = GetClientRectangle2D();
            Matrix4D to2DTransform = Matrix4D.Identity;
            if (model != null && bounds != null)
            {
                to2DTransform = transformationProvider.CompleteTransform;
            }
            //if (gdiGraphics3D == null)
            //{
            //    GraphicsConfig graphicsConfig = new GraphicsConfig();
            //    graphicsConfig.BackColor = BackColor;
            //    graphicsConfig.CorrectColorForBackgroundColor = true;
            //    gdiGraphics3D = new GDIGraphics3D(graphicsConfig);
            //}
            if (gdiGraphics3D != null)
            {
                gdiGraphics3D.To2DTransform = to2DTransform;
                from2DTransform = gdiGraphics3D.To2DTransform.GetInverse();
            }
               
            return to2DTransform;
        }

        private Rectangle2D GetClientRectangle2D() {
            return new Rectangle2D(
                ClientRectangle.Left,
                ClientRectangle.Top,
                ClientRectangle.Right,
                ClientRectangle.Bottom
            );
        }

        private void transformationProvider_TransformsChanged(object sender, EventArgs e) {
            CalculateTo2DTransform();
            Invalidate();
        }

        private InteractionContext GetInteractionContext() {
            return new InteractionContext(
                transformationProvider.CompleteTransform, 
                new Size2D(ClientSize.Width, ClientSize.Height)
            );
        }
    }
}
