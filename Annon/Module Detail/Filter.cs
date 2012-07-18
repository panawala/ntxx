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
    public partial class Filter : Form
    {
        public Filter()
        {
            InitializeComponent();
        }

        private void Filter_Load(object sender, EventArgs e)
        {

        }
        public void InitialValue(string textBoxStr, string textBoxFTstr, string textBoxDAstr, ArrayList cbBoxFSarr, ArrayList cbBoxSfarr, ArrayList cbBox2FTarr, ArrayList cbBox2FSarr, ArrayList cbBoxFOarr, ArrayList cbBoxSparr)
        {

            FilterData FilterDetail = new FilterData();
            textBoxTag.Text = FilterDetail.textBoxTag(textBoxStr);
            textBoxFT.Text = FilterDetail.textBoxFT(textBoxFTstr);
            textBoxDA.Text = FilterDetail.textBoxDA(textBoxDAstr);
            cbBoxFS.DataSource = FilterDetail.cbBoxFS(cbBoxFSarr);
            cbBoxSf.DataSource = FilterDetail.cbBoxSf(cbBoxSfarr);
            cbBox2FT.DataSource = FilterDetail.cbBox2FT(cbBox2FTarr);
            cbBox2FS.DataSource = FilterDetail.cbBox2FS(cbBox2FSarr);
            cbBoxFO.DataSource=FilterDetail.cbBoxFO(cbBoxFOarr);
            cbBoxSp.DataSource = FilterDetail.cbBoxSp(cbBoxSparr);
        }
    }
}
