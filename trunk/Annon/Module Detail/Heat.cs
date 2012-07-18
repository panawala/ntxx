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
    public partial class Heat : Form
    {
        public Heat()
        {
            InitializeComponent();
        }

        private void Heat_Load(object sender, EventArgs e)
        {

        }
        public void InitialValue(string textBoxStr, string textBoxDAstr, ArrayList cbBoxFunarr, ArrayList cbBoxFiarr, ArrayList cbBoxFOarr, ArrayList cbBoxSparr)
        {

            HeatData HeatDetail = new HeatData();
            textBoxTag.Text = HeatDetail.textBoxTag(textBoxStr);
            textBoxDA.Text = HeatDetail.textBoxDA(textBoxDAstr);

            cbBoxFun.DataSource = HeatDetail.cbBoxFun(cbBoxFunarr);
            cbBoxFi.DataSource = HeatDetail.cbBoxFi(cbBoxFiarr);
            cbBoxFO.DataSource = HeatDetail.cbBoxFO(cbBoxFOarr);
            cbBoxSp.DataSource = HeatDetail.cbBoxSp(cbBoxSparr);
        }
    }
}
