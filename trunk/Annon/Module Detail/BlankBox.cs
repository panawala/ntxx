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
    public partial class BlankBox : Form
    {
        public BlankBox()
        {
            InitializeComponent();
        }

        private void BlankBox_Load(object sender, EventArgs e)
        {

        }
        public void InitialValue(string textBoxStr, ArrayList cbBoxDParr, ArrayList cbBoxAWarr, ArrayList cbBoxSfarr, ArrayList cbBoxSparr)
        {

            BlankBoxData BBDetail = new BlankBoxData();
            textBoxTag.Text = BBDetail.textBoxTag(textBoxStr);
            cbBoxDP.DataSource = BBDetail.cbBoxDP(cbBoxDParr);
            cbBoxAW.DataSource = BBDetail.cbBoxAW(cbBoxAWarr);
            cbBoxSf.DataSource = BBDetail.cbBoxSf(cbBoxSfarr);
            cbBoxSp.DataSource = BBDetail.cbBoxSp(cbBoxSparr);
        }

    }
}
