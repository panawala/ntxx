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
    public partial class Coil : Form
    {
        public Coil()
        {
            InitializeComponent();
        }

        private void Coil_Load(object sender, EventArgs e)
        {

        }
        public void InitialValue(string textBoxStr, ArrayList cbBoxFSarr, ArrayList cbBoxDParr, ArrayList cbBoxSparr)
        {

            CoilData CoilDetail = new CoilData();
            textBoxTag.Text = CoilDetail.CoilDataTag(textBoxStr);
            cbBoxFS.DataSource = CoilDetail.cbBoxFS(cbBoxFSarr);
            cbBoxDP.DataSource = CoilDetail.cbBoxDP(cbBoxDParr);
            cbBoxSp.DataSource = CoilDetail.cbBoxSp(cbBoxSparr);
        }
    }
}
