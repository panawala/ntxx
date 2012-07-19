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
        //主动属性取值ID的取值范围
        public string ValueCodeIDRange { get; set; }
        //被动属性名字
        public string InfluencedPropertyName { get; set; }
        //被动属性值的ID
        public string InfluencedValueCodeID { get; set; }
        //图块内容隶属的类型
        public string Type { get; set; }

        //约束对应的图块ID>可以将约束作用到每个图块上
        public int ImageBlockID { get; set; }
    }
}
