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
    public partial class MixingBox : Form
    {
        public MixingBox()
        {
            InitializeComponent();
        }

        private void MixingBox_Load(object sender, EventArgs e)
        {

        }
        public void InitialValue(string textBoxStr, string textBoxDAstr, ArrayList cbBoxATarr, ArrayList cbBoxFSarr, ArrayList cbBoxSfarr, ArrayList cbBoxFOarr, ArrayList cbBoxSparr)
        {

            MixingBoxData MBDetail = new MixingBoxData();
            textBoxTag.Text = MBDetail.textBoxTag(textBoxStr);
            textBoxDA.Text = MBDetail.textBoxDA(textBoxDAstr);

            cbBoxAT.DataSource = MBDetail.cbBoxAT(cbBoxATarr);
            cbBoxFS.DataSource = MBDetail.cbBoxFS(cbBoxFSarr);
            cbBoxSf.DataSource = MBDetail.cbBoxSf(cbBoxSfarr);
            cbBoxFO.DataSource = MBDetail.cbBoxFO(cbBoxFOarr);
            cbBoxSp.DataSource = MBDetail.cbBoxSp(cbBoxSparr);
        }
    }
}
