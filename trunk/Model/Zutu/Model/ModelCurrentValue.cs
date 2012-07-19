using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Zutu.Model
{
    /// <summary>
    /// model选型当前选择的值。与订单挂钩
    /// </summary>
    public class ModelCurrentValue
    {
        public int ModelCurrentValueID { get; set; }
        //属性名字
        public string PropertyName { get; set; }
        //属性默认值ValueCode的ID
        public int ValueCodeID { get; set; }
        //对应订单ID
        public int OrderDetailID { get; set; }
    }
}
