using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Annon.Zutu
{
    public partial class Form1 : Form
    {
        private bool pictureBox1Flag{ set; get; }
        private bool pictureBox2Flag { set; get; }
        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_DragEnter(object sender, DragEventArgs e)
        {
            MessageBox.Show("test");
            PictureBox pb = new PictureBox();
            pb.Height = 100;
            pb.Width = 200;
            pb.BackColor = Color.Red;
            splitContainer1.Panel2.Controls.Add(pb);
        }

        private void splitContainer1_Panel2_DragOver(object sender, DragEventArgs e)
        {
            MessageBox.Show("move");
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1Flag == true)
            {
               
                PictureBox p = (PictureBox)sender;
                Pen pp = new Pen(Color.Blue);
                pp.Width = 5;
                p.BorderStyle = BorderStyle.Fixed3D;
                e.Graphics.DrawRectangle(pp, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.X + e.ClipRectangle.Width - 1, e.ClipRectangle.Y + e.ClipRectangle.Height - 1);
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1Flag = true;
            pictureBox1.Invalidate();
            pictureBox1.Update();
            pictureBox2Flag=false;
            pictureBox2.Invalidate();
            pictureBox2.Update();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2Flag = true;
            pictureBox2.Invalidate();
            pictureBox2.Update();
            pictureBox1Flag = false;
            pictureBox1.Invalidate();
            pictureBox1.Update();
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox2Flag == true)
            {
                PictureBox p = (PictureBox)sender;
                Pen pp = new Pen(Color.Blue);
                pp.Width = 5;
                p.BorderStyle = BorderStyle.Fixed3D;
                e.Graphics.DrawRectangle(pp, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.X + e.ClipRectangle.Width - 1, e.ClipRectangle.Y + e.ClipRectangle.Height - 1);
            }
        }

      

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            CreatePictureBox(pictureBox1,pictureBox1.Name);
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            CreatePictureBox(pictureBox2, pictureBox2.Name);
        }

        private void CreatePictureBox(PictureBox pictureBox,string picName)
        {
            PictureBox pic = new PictureBox();
            pic.Width = pictureBox.Width;
            pic.Height = pictureBox.Height;
            pic.Image = pictureBox.Image;
            pic.Name = picName;
            splitContainer1.Panel2.Controls.Add(pic);
          
            pic.MouseDown += new MouseEventHandler(pic_MouseDown);
            pic.MouseMove += new MouseEventHandler(pic_MouseMove);
        }

        void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pic = sender as PictureBox;
                if (null == pic) return;
                string name = pic.Name; // 取出pictureBox的名称
                if (name == pictureBox1.Name)
                {
                    //控件至于顶层
                    pic.BringToFront();
                    if(Control.MousePosition.X>=(splitContainer1.Panel1.Width-pic.Width/2))
                    pic.Location = new Point(Control.MousePosition.X-SystemInformation.FrameBorderSize.Width-splitContainer1.Panel1.Width-pic.Width/2, Control.MousePosition.Y-SystemInformation.FrameBorderSize.Height-pic.Height/2);
                }
                if (name == pictureBox2.Name)
                {
                    pic.BringToFront();
                    if (Control.MousePosition.X >= (splitContainer1.Panel1.Width - pic.Width / 2))
                        pic.Location = new Point(Control.MousePosition.X - SystemInformation.FrameBorderSize.Width - splitContainer1.Panel1.Width - pic.Width / 2, Control.MousePosition.Y - SystemInformation.FrameBorderSize.Height - pic.Height / 2);
                }
            }
        }

        

        void pic_Paint(object sender, PaintEventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            Pen pp = new Pen(Color.Blue);
            pp.Width = 5;
            p.BorderStyle = BorderStyle.Fixed3D;
            e.Graphics.DrawRectangle(pp, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.X + e.ClipRectangle.Width - 1, e.ClipRectangle.Y + e.ClipRectangle.Height - 1);
        }


        private void pic_MouseDown(object sender,MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pic = sender as PictureBox;
                if (null == pic) return;
                string name = pic.Name; // 取出pictureBox的名称
                if (name == pictureBox1.Name)
                {
                    //  pic.Location = new Point(e.X,e.Y);
                    pic.Cursor = Cursors.Hand;
                }
                if (name == pictureBox2.Name)
                {
                    pic.Cursor = Cursors.Hand;
                } 
            }
        }
    }
}
