using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Annon.Module_Detail
{
    public partial class ModuleDetail : Form
    {
        public ModuleDetail()
        {
            InitializeComponent();
        }
        //无数据时，用于测试用的构造数据
        ArrayList one = new ArrayList();
        ArrayList two = new ArrayList();
        ArrayList three = new ArrayList();
        ArrayList four = new ArrayList();
        ArrayList five = new ArrayList();
        ArrayList six = new ArrayList();
        string tag;
        //鼠标单击相应图标，依据关键字调用相应winform窗体       
         private void ImgClick(string ModuleName)
        {
            //构造数据
             tag = "Test";
             one.Add(1);
             two.Add(2);
             three.Add(3);
             four.Add(4);
             five.Add(5);
             six.Add(6);

            RightPinal.Controls.Clear();
            string ImgName = ModuleName;
            switch (ImgName)
            {
                case  "blankBox":
                    BlankBox frmblankBox = new BlankBox();
                    frmblankBox.TopLevel = false;
                    frmblankBox.Parent = RightPinal;
                    frmblankBox.Dock = DockStyle.Fill;
                    frmblankBox.InitialValue(tag,one,two,three,four);//获取点击的图标，传递其唯一标识
                    frmblankBox.Show();
                     break;
                case "Coil":
                     Coil frmCoil = new Coil();
                     frmCoil.TopLevel = false;
                     frmCoil.Parent = RightPinal;
                     frmCoil.Dock = DockStyle.Fill;
                     frmCoil.InitialValue(tag, one, two, three);
                     frmCoil.Show();
                    break;
                case "ControlBox":
                    ControlBox frmControlBox = new ControlBox();
                    frmControlBox.TopLevel = false;
                    frmControlBox.Parent = RightPinal;
                    frmControlBox.Dock = DockStyle.Fill;
                    frmControlBox.InitialValue(tag, one, two);
                    frmControlBox.Show();
                    break;
                case "FanBox":
                    FanBox frmFanBox = new FanBox();
                    frmFanBox.TopLevel = false;
                    frmFanBox.Parent = RightPinal;
                    frmFanBox.Dock = DockStyle.Fill;
                    frmFanBox.InitialValue(tag, one, two, three, four);
                    frmFanBox.Show();
                    break;
                case "Filter":
                    Filter frmFilter = new Filter();
                    frmFilter.TopLevel = false;
                    frmFilter.Parent = RightPinal;
                    frmFilter.Dock = DockStyle.Fill;
                    frmFilter.InitialValue(tag,tag,tag, one, two, three, four,five,six);
                    frmFilter.Show();
                    break;
                case "Heat":
                    Heat frmHeat = new Heat();
                    frmHeat.TopLevel = false;
                    frmHeat.Parent = RightPinal;
                    frmHeat.Dock = DockStyle.Fill;
                    frmHeat.InitialValue(tag, tag, one, two, three, four);
                    frmHeat.Show();
                    break;
                case "HRWheel":
                    HRWheel frmHRWheel = new HRWheel();
                    frmHRWheel.TopLevel = false;
                    frmHRWheel.Parent = RightPinal;
                    frmHRWheel.Dock = DockStyle.Fill;
                    frmHRWheel.InitialValue(tag,  one, two);
                    frmHRWheel.Show();
                    break;
                case "MixingBox":
                    MixingBox frmMixingBox = new MixingBox();
                    frmMixingBox.TopLevel = false;
                    frmMixingBox.Parent = RightPinal;
                    frmMixingBox.Dock = DockStyle.Fill;
                    frmMixingBox.InitialValue(tag,tag,one,two,three ,four,five);//获取点击的图标，传递其唯一标识
                    frmMixingBox.Show();
                    break;

            }

        }
        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        { 
            ImgClick("blankBox");
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            ImgClick("Coil");
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            ImgClick("ControlBox");
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            ImgClick("FanBox");
        }

        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {
            ImgClick("Filter");
        }

        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {
            ImgClick("Heat");
        }

        private void pictureBox7_MouseClick(object sender, MouseEventArgs e)
        {
            ImgClick("HRWheel");
        }

        private void pictureBox8_MouseClick(object sender, MouseEventArgs e)
        {
            ImgClick("MixingBox");
        }

        private void ModuleDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
