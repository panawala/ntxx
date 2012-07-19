using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Zutu.Content
{
    /// <summary>
    /// 图块内容选型默认值
    /// </summary>
    public class ContentDefaultValue
    {
        public int ContentDefaultValueID { get; set; }
        //属性名称
        public string PropertyName { get; set; }
        //属性值ID
        public int ValueCodeID { get; set; }
        //属性所属的类型
        public string Type { get; set; }
        //所属图块的ID
        public int ImageBlockID { get; set; }

        //是否被锁定，锁定时界面该属性无效
        public bool IsLocked { get; set; }
    }
}
