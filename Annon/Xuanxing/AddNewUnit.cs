using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityFrameworkTryBLL.XuanxingManager;

namespace Annon.Xuanxing
{
    public partial class AddNewUnit : Form
    {

        public int OrderSale { get; set; }
        public bool RMisClick = false;
        public bool RLisClick = false;
        public bool CLisClick = false;
        public bool LLisClick = false;
        public bool BLisClick = false;
        public bool HBisClick = false;
        public bool ModisClick = false;
        public bool CAisClick = false;
        public bool RNisClick = false;


        public AddNewUnit()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
            
            RMisClick = true;
            //这句话将来要去掉
            RMandRL.RMorRL = "RM";
            AAonRating.aaon.DeviceID = 1;

            RLisClick = false;
            CLisClick = false;
            LLisClick = false;
            BLisClick = false;
            HBisClick = false;
            ModisClick = false;
            CAisClick = false;
            RNisClick = false;

            Image pImage1 = Image.FromFile(@"../../Resources/11.PNG");
            pictureBox1.Image = pImage1;

            Image pImage2 = Image.FromFile(@"../../Resources/2.PNG");
            pictureBox2.Image = pImage2;

            Image pImage3 = Image.FromFile(@"../../Resources/3.PNG");
            pictureBox3.Image = pImage3;

            Image pImage4 = Image.FromFile(@"../../Resources/4.PNG");
            pictureBox4.Image = pImage4;

            Image pImage5 = Image.FromFile(@"../../Resources/5.PNG");
            pictureBox5.Image = pImage5;

            Image pImage6 = Image.FromFile(@"../../Resources/6.PNG");
            pictureBox6.Image = pImage6;

            Image pImage7 = Image.FromFile(@"../../Resources/7.PNG");
            pictureBox7.Image = pImage7;

            Image pImage8 = Image.FromFile(@"../../Resources/8.PNG");
            pictureBox8.Image = pImage8;

            Image pImage9 = Image.FromFile(@"../../Resources/9.PNG");
            pictureBox9.Image = pImage9;


           
        }

        void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            Pen pp = new Pen(System.Drawing.Color.Blue);
            pp.Width = 5;
            p.BorderStyle = BorderStyle.Fixed3D;
            e.Graphics.DrawRectangle(pp, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.X + e.ClipRectangle.Width - 1, e.ClipRectangle.Y + e.ClipRectangle.Height - 1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            RLisClick = true;
            //这句话将来要去掉
            RMandRL.RMorRL = "RL";
            AAonRating.aaon.DeviceID = 1;
            //RLisClick = true;

            RMisClick = false;
            CLisClick = false;
            LLisClick = false;
            BLisClick = false;
            HBisClick = false;
            ModisClick = false;
            CAisClick = false;
            RNisClick = false;

            Image pImage1 = Image.FromFile(@"../../Resources/1.PNG");
            pictureBox1.Image = pImage1;

            Image pImage2 = Image.FromFile(@"../../Resources/12.PNG");
            pictureBox2.Image = pImage2;

            Image pImage3 = Image.FromFile(@"../../Resources/3.PNG");
            pictureBox3.Image = pImage3;

            Image pImage4 = Image.FromFile(@"../../Resources/4.PNG");
            pictureBox4.Image = pImage4;

            Image pImage5 = Image.FromFile(@"../../Resources/5.PNG");
            pictureBox5.Image = pImage5;

            Image pImage6 = Image.FromFile(@"../../Resources/6.PNG");
            pictureBox6.Image = pImage6;

            Image pImage7 = Image.FromFile(@"../../Resources/7.PNG");
            pictureBox7.Image = pImage7;

            Image pImage8 = Image.FromFile(@"../../Resources/8.PNG");
            pictureBox8.Image = pImage8;

            Image pImage9 = Image.FromFile(@"../../Resources/9.PNG");
            pictureBox9.Image = pImage9;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            CLisClick = true;

            RMisClick = false;
            RLisClick = false;
            LLisClick = false;
            BLisClick = false;
            HBisClick = false;
            ModisClick = false;
            CAisClick = false;
            RNisClick = false;

            Image pImage1 = Image.FromFile(@"../../Resources/1.PNG");
            pictureBox1.Image = pImage1;

            Image pImage2 = Image.FromFile(@"../../Resources/2.PNG");
            pictureBox2.Image = pImage2;

            Image pImage3 = Image.FromFile(@"../../Resources/13.PNG");
            pictureBox3.Image = pImage3;

            Image pImage4 = Image.FromFile(@"../../Resources/4.PNG");
            pictureBox4.Image = pImage4;

            Image pImage5 = Image.FromFile(@"../../Resources/5.PNG");
            pictureBox5.Image = pImage5;

            Image pImage6 = Image.FromFile(@"../../Resources/6.PNG");
            pictureBox6.Image = pImage6;

            Image pImage7 = Image.FromFile(@"../../Resources/7.PNG");
            pictureBox7.Image = pImage7;

            Image pImage8 = Image.FromFile(@"../../Resources/8.PNG");
            pictureBox8.Image = pImage8;

            Image pImage9 = Image.FromFile(@"../../Resources/9.PNG");
            pictureBox9.Image = pImage9;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
            LLisClick = true;

            RMisClick = false;
            RLisClick = false;
            LLisClick = false;
            BLisClick = false;
            HBisClick = false;
            ModisClick = false;
            CAisClick = false;
            RNisClick = false;

            Image pImage1 = Image.FromFile(@"../../Resources/1.PNG");
            pictureBox1.Image = pImage1;

            Image pImage2 = Image.FromFile(@"../../Resources/2.PNG");
            pictureBox2.Image = pImage2;

            Image pImage3 = Image.FromFile(@"../../Resources/3.PNG");
            pictureBox3.Image = pImage3;

            Image pImage4 = Image.FromFile(@"../../Resources/14.PNG");
            pictureBox4.Image = pImage4;

            Image pImage5 = Image.FromFile(@"../../Resources/5.PNG");
            pictureBox5.Image = pImage5;

            Image pImage6 = Image.FromFile(@"../../Resources/6.PNG");
            pictureBox6.Image = pImage6;

            Image pImage7 = Image.FromFile(@"../../Resources/7.PNG");
            pictureBox7.Image = pImage7;

            Image pImage8 = Image.FromFile(@"../../Resources/8.PNG");
            pictureBox8.Image = pImage8;

            Image pImage9 = Image.FromFile(@"../../Resources/9.PNG");
            pictureBox9.Image = pImage9;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
            BLisClick = true;

            RMisClick = false;
            RLisClick = false;
            LLisClick = false;
            LLisClick = false;
            HBisClick = false;
            ModisClick = false;
            CAisClick = false;
            RNisClick = false;

            Image pImage1 = Image.FromFile(@"../../Resources/1.PNG");
            pictureBox1.Image = pImage1;

            Image pImage2 = Image.FromFile(@"../../Resources/2.PNG");
            pictureBox2.Image = pImage2;

            Image pImage3 = Image.FromFile(@"../../Resources/3.PNG");
            pictureBox3.Image = pImage3;

            Image pImage4 = Image.FromFile(@"../../Resources/4.PNG");
            pictureBox4.Image = pImage4;

            Image pImage5 = Image.FromFile(@"../../Resources/15.PNG");
            pictureBox5.Image = pImage5;

            Image pImage6 = Image.FromFile(@"../../Resources/6.PNG");
            pictureBox6.Image = pImage6;

            Image pImage7 = Image.FromFile(@"../../Resources/7.PNG");
            pictureBox7.Image = pImage7;

            Image pImage8 = Image.FromFile(@"../../Resources/8.PNG");
            pictureBox8.Image = pImage8;

            Image pImage9 = Image.FromFile(@"../../Resources/9.PNG");
            pictureBox9.Image = pImage9;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
            HBisClick = true;


            RMisClick = false;
            RLisClick = false;
            LLisClick = false;
            LLisClick = false;
            BLisClick = false;
            ModisClick = false;
            CAisClick = false;
            RNisClick = false;

            Image pImage1 = Image.FromFile(@"../../Resources/1.PNG");
            pictureBox1.Image = pImage1;

            Image pImage2 = Image.FromFile(@"../../Resources/2.PNG");
            pictureBox2.Image = pImage2;

            Image pImage3 = Image.FromFile(@"../../Resources/3.PNG");
            pictureBox3.Image = pImage3;

            Image pImage4 = Image.FromFile(@"../../Resources/4.PNG");
            pictureBox4.Image = pImage4;

            Image pImage5 = Image.FromFile(@"../../Resources/5.PNG");
            pictureBox5.Image = pImage5;

            Image pImage6 = Image.FromFile(@"../../Resources/16.PNG");
            pictureBox6.Image = pImage6;

            Image pImage7 = Image.FromFile(@"../../Resources/7.PNG");
            pictureBox7.Image = pImage7;

            Image pImage8 = Image.FromFile(@"../../Resources/8.PNG");
            pictureBox8.Image = pImage8;

            Image pImage9 = Image.FromFile(@"../../Resources/9.PNG");
            pictureBox9.Image = pImage9;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ModisClick = true;

            RMisClick = false;
            RLisClick = false;
            LLisClick = false;
            LLisClick = false;
            BLisClick = false;
            HBisClick = false;
            CAisClick = false;
            RNisClick = false;

            Image pImage1 = Image.FromFile(@"../../Resources/1.PNG");
            pictureBox1.Image = pImage1;

            Image pImage2 = Image.FromFile(@"../../Resources/2.PNG");
            pictureBox2.Image = pImage2;

            Image pImage3 = Image.FromFile(@"../../Resources/3.PNG");
            pictureBox3.Image = pImage3;

            Image pImage4 = Image.FromFile(@"../../Resources/4.PNG");
            pictureBox4.Image = pImage4;

            Image pImage5 = Image.FromFile(@"../../Resources/5.PNG");
            pictureBox5.Image = pImage5;

            Image pImage6 = Image.FromFile(@"../../Resources/6.PNG");
            pictureBox6.Image = pImage6;

            Image pImage7 = Image.FromFile(@"../../Resources/17.PNG");
            pictureBox7.Image = pImage7;

            Image pImage8 = Image.FromFile(@"../../Resources/8.PNG");
            pictureBox8.Image = pImage8;

            Image pImage9 = Image.FromFile(@"../../Resources/9.PNG");
            pictureBox9.Image = pImage9;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            CAisClick = true;

            RMisClick = false;
            RLisClick = false;
            LLisClick = false;
            LLisClick = false;
            BLisClick = false;
            HBisClick = false;
            ModisClick = false;
            RNisClick = false;

            Image pImage1 = Image.FromFile(@"../../Resources/1.PNG");
            pictureBox1.Image = pImage1;

            Image pImage2 = Image.FromFile(@"../../Resources/2.PNG");
            pictureBox2.Image = pImage2;

            Image pImage3 = Image.FromFile(@"../../Resources/3.PNG");
            pictureBox3.Image = pImage3;

            Image pImage4 = Image.FromFile(@"../../Resources/4.PNG");
            pictureBox4.Image = pImage4;

            Image pImage5 = Image.FromFile(@"../../Resources/5.PNG");
            pictureBox5.Image = pImage5;

            Image pImage6 = Image.FromFile(@"../../Resources/6.PNG");
            pictureBox6.Image = pImage6;

            Image pImage7 = Image.FromFile(@"../../Resources/7.PNG");
            pictureBox7.Image = pImage7;

            Image pImage8 = Image.FromFile(@"../../Resources/18.PNG");
            pictureBox8.Image = pImage8;

            Image pImage9 = Image.FromFile(@"../../Resources/9.PNG");
            pictureBox9.Image = pImage9;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            RNisClick = true;

            RMisClick = false;
            RLisClick = false;
            LLisClick = false;
            LLisClick = false;
            BLisClick = false;
            HBisClick = false;
            CAisClick = false;
            ModisClick = false;

            Image pImage1 = Image.FromFile(@"../../Resources/1.PNG");
            pictureBox1.Image = pImage1;

            Image pImage2 = Image.FromFile(@"../../Resources/2.PNG");
            pictureBox2.Image = pImage2;

            Image pImage3 = Image.FromFile(@"../../Resources/3.PNG");
            pictureBox3.Image = pImage3;

            Image pImage4 = Image.FromFile(@"../../Resources/4.PNG");
            pictureBox4.Image = pImage4;

            Image pImage5 = Image.FromFile(@"../../Resources/5.PNG");
            pictureBox5.Image = pImage5;

            Image pImage6 = Image.FromFile(@"../../Resources/6.PNG");
            pictureBox6.Image = pImage6;

            Image pImage7 = Image.FromFile(@"../../Resources/7.PNG");
            pictureBox7.Image = pImage7;

            Image pImage8 = Image.FromFile(@"../../Resources/8.PNG");
            pictureBox8.Image = pImage8;

            Image pImage9 = Image.FromFile(@"../../Resources/19.PNG");
            pictureBox9.Image = pImage9;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            int ModelOrder = CatalogBLL.initialOrder(1);
            XuanxingUI XuUi = new XuanxingUI(ModelOrder);
            XuUi.ShowDialog();
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox4_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox5_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox6_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox7_DoubleClick(object sender, EventArgs e)
        {
            AAonRating.aaon.DeviceID = 2;
            ModAHUnit Mod = new ModAHUnit();
            Mod.InitialForm(0, null);
            Mod.OrderIDToMod = OrderSale;
            Mod.ShowDialog();
        }

        private void pictureBox8_DoubleClick(object sender, EventArgs e)
        {
            ControlsAndAccessories cor = new ControlsAndAccessories();
            cor.orderID = OrderSale;
            cor.ShowDialog();
        }

        private void pictureBox9_DoubleClick(object sender, EventArgs e)
        {

            RnCurb rc = new RnCurb();
            rc.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ModelOrder = CatalogBLL.initialOrder(1);
            if (RMisClick)
            {
                XuanxingUI XuUi = new XuanxingUI(ModelOrder);
                XuUi.ShowDialog();
            }
            else if(ModisClick){
                AAonRating.aaon.DeviceID = 2;
                ModAHUnit Mod = new ModAHUnit();
                Mod.InitialForm(0, null);
                Mod.OrderIDToMod = OrderSale;
                Mod.ShowDialog();
            }
            else if (RNisClick)
            {
                RnCurb rc = new RnCurb();
                rc.ShowDialog();
            }
            else if(CAisClick){
                ControlsAndAccessories cor = new ControlsAndAccessories();
                cor.orderID = OrderSale;
                cor.ShowDialog();
            }
            else if(RLisClick){
                XuanxingUI XuUi = new XuanxingUI(ModelOrder);
                XuUi.ShowDialog();
            }
            this.Close();
        }
    }
}
