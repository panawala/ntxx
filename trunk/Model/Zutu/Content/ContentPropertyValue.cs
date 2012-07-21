using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Zutu.Content
{
    /// <summary>
    /// 图块内容选型,属性值对应表
    /// </summary>
    public class ContentPropertyValue
    {
        public int ContentPropertyValueID { get; set; }
        
        /**************************************************/
        //冷量和图块名称唯一确定一个图块
        /**************************************************/
        //冷量筛选
        public int CoolingPower { get; set; }
        //所属图块的名称
        public string ImageName { get; set; }
        //图块内容属性名字
        public string PropertyName { get; set; }
        //属性名值ID
        public int ValueCodeID { get; set; }
        //属性值
        public string Value { get; set; }
        //属性值描述
        public string ValueDescription { get; set; }
        
        //某个属性值对应的价格
        public decimal Price { get; set; }
        //默认值
        public string Default { get; set; } 
        public string IsReadOnly { get; set; }
        //隶属的类型，包括8种类型
        public string Type { get; set; }

        //该属性取值的时候的属性约束
        public string Condition { get; set; }
    }
}
