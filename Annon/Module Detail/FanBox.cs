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
    public partial class FanBox : Form
    {
        public FanBox()
        {
            InitializeComponent();
        }

        private void FanBox_Load(object sender, EventArgs e)
        {

        }
        public void InitialValue(string textBoxStr, ArrayList cbBoxMSarr, ArrayList cbBoxMTarr, ArrayList cbBoxSCarr, ArrayList cbBoxSparr)
        {

            FanBoxData FBDetail = new FanBoxData();
            textBoxTag.Text = FBDetail.textBoxTag(textBoxStr);
            cbBoxMS.DataSource = FBDetail.cbBoxMS(cbBoxMSarr);
            cbBoxMT.DataSource = FBDetail.cbBoxMT(cbBoxMTarr);
            cbBoxSC.DataSource = FBDetail.cbBoxSC(cbBoxSCarr);
            cbBoxSp.DataSource = FBDetail.cbBoxSp(cbBoxSparr);
        }
    }
}
