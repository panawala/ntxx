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
        public bool RMisClick=false;
        public bool RLisClick = false;
        public bool CLisClick = false;
        public bool LLisClick = false;
        public bool BLisClick = false;
        public bool HBisClick = false;

        public AddNewUnit()
        {
            InitializeComponent();
            
        }
 
        void btn_RMRN_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            int ModelID = CatalogBLL.initialOrder(1);
            XuanxingUI Xuanxing = new XuanxingUI(ModelID);
            Xuanxing.Show();
        }

        private void AddNewUnit_Load(object sender, EventArgs e)
        {
            btn_RMRN.DoubleClick += new EventHandler(btn_RMRN_DoubleClick);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AAonRating.aaon.DeviceID = 2;
            ModAHUnit Mod = new ModAHUnit();
            Mod.InitialForm(0,null);
            Mod.OrderIDToMod = OrderSale;
            Mod.Show();
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            int ModelOrder=CatalogBLL.initialOrder(1);
            if (RMisClick || RLisClick || CLisClick || LLisClick || BLisClick || HBisClick)
            {
                XuanxingUI XuUi = new XuanxingUI(ModelOrder);
                XuUi.Show();
            }
            this.Close();
        }

        private void btn_RMRN_Click(object sender, EventArgs e)
        {
            RMisClick = true;
            AAonRating.aaon.DeviceID = 1;
        }

        private void btn_RL_Click(object sender, EventArgs e)
        {
            RMisClick = true;
            AAonRating.aaon.DeviceID = 1;
            //RLisClick = true;
        }

        private void btn_CL_Click(object sender, EventArgs e)
        {
            CLisClick = true;
        }

        private void btn_LL_Click(object sender, EventArgs e)
        {
            LLisClick = true;
        }

        private void btn_BL_Click(object sender, EventArgs e)
        {
            BLisClick = true;
        }

        private void btn_HB_Click(object sender, EventArgs e)
        {
            HBisClick = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Controls cor = new Controls();
            cor.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            RnCurb rc = new RnCurb();
            rc.Show();
        }

        private void btn_RMRN_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RMisClick = true;
            AAonRating.aaon.DeviceID = 1;
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int ModelOrder = CatalogBLL.initialOrder(1);
            XuanxingUI XuUi = new XuanxingUI(ModelOrder);
            XuUi.Show();
        }

    }

}