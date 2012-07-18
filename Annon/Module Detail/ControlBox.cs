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
    public partial class ControlBox : Form
    {
        public ControlBox()
        {
            InitializeComponent();
        }

        private void ControlBox_Load(object sender, EventArgs e)
        {

        }
        public void InitialValue(string textBoxStr, ArrayList cbBoxSfarr, ArrayList cbBoxSparr)
        {

            ControlBoxData CBDetail = new ControlBoxData();
            textBoxTag.Text = CBDetail.textBoxTag(textBoxStr);
            cbBoxSf.DataSource = CBDetail.cbBoxSf(cbBoxSfarr);
            cbBoxSp.DataSource = CBDetail.cbBoxSp(cbBoxSparr);
        }
    }
}
