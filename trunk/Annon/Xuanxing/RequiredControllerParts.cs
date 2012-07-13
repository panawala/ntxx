using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityFrameworkTryBLL;

namespace Annon.Xuanxing
{
    public partial class RequiredControllerParts : Form
    {
        public RequiredControllerParts()
        {
            InitializeComponent();
        }

        public RequiredControllerParts(int deviceId, string propertyName, string propertyValueCode)
        {
            InitializeComponent();
            accessoryDataGridView.AutoGenerateColumns = false;
            //accessoryDataGridView.DataSource=AccessoryBLL.GetAccessoriesByPtyValue(deviceId, propertyName, propertyValueCode);
        }

    }
}
