using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Zutu
{
    /// <summary>
    /// 图块内容选型的属性之间的约束
    /// </summary>
    public class ContentConstraint
    {
        public int ContentConstraintID { get; set; }
        //主动属性名字
        public string PropertyName { get; set; }
        //被动属性的名字
        public string InfluencedPropertyName { get; set; }
        //图块内容隶属的类型
        public int CoolingPower { get; set; }

        //约束对应的图块名称>可以将约束作用到每个图块上
        public string ImageName { get; set; }
    }
}
