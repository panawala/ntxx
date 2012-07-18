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
    public partial class HRWheel : Form
    {
        public HRWheel()
        {
            InitializeComponent();
        }

        private void HRWheel_Load(object sender, EventArgs e)
        {

        }
        public void InitialValue(string textBoxStr, ArrayList cbBoxWSarr, ArrayList cbBoxSparr)
        {

            HRWheelData HRWDetail = new HRWheelData();
            textBoxTag.Text = HRWDetail.textBoxTag(textBoxStr);

            cbBoxWS.DataSource = HRWDetail.cbBoxWS(cbBoxWSarr);
            cbBoxSp.DataSource = HRWDetail.cbBoxSp(cbBoxSparr);

        }
    }
}
