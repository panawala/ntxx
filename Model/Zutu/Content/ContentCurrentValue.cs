using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Zutu.Content
{
    /// <summary>
    /// 图块内容当前选择值的表
    /// </summary>
    public class ContentCurrentValue
    {
        public int ContentCurrentValueID { get; set; }
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

        //该项选择的价格
        public decimal Price { get; set; }
        /// <summary>
        /// 定位一个属性值的GUID
        /// </summary>
        public string Guid { get; set; }

        //下拉选项值
        public string Items { get; set; }
    }
}
