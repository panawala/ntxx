using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Zutu.Content
{
    public class ContentOrder
    {
        public int ContentOrderID { get; set; }
        //选中图块的唯一标识
        public string ModuleTag { get; set; }
        //属性名称
        public string PropertyName { get; set; }
        //属性当前选中的值
        public string Value { get; set; }
        /**************************************************/
        //冷量和图块名称唯一确定一个图块
        /**************************************************/
        //每个图块的名称,可以取到每个图块的当前取值
        public string ImageName { get; set; }
        //保存当前情况下的冷量
        public int CoolingPower { get; set; }
        //订单ID
        public int OrderID { get; set; }

        public int Guid { get; set; }
    }
}
