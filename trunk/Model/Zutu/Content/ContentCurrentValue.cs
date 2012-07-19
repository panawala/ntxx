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
        //属性名称
        public string PropertyName { get; set; }
        //属性值ID
        public int ValueCodeID { get; set; }
        //图块内容属性隶属的类型
        public string Type { get; set; }

        //每个图块的ID,可以取到每个图块的当前取值
        public int ImageBlockID { get; set; }
    }
}
