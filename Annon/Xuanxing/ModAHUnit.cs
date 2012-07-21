using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Annon
{
    public partial class NewUnitForm : Form
    {
        public NewUnitForm()
        {
            InitializeComponent();
            unitType.Text = "H";
            unitSize.Text = "008[2000-4 400CFM]";
            SupplyAiFl.Text = "R = Right Hand Flow";
            voltage.Text = "2=230V / 3P / 60HZ";
            assembly.Text = "A= Factory Assembled";
            wiring.Text = "A = Ctl Wired in Fan Box";
            painting.Text = "0";
            baseRail.Text = "C = 6 inches High";
            unitSpec.Text = "0 = None";
        }

        private void NewUnitForm_Load(object sender, EventArgs e)
        {

        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
