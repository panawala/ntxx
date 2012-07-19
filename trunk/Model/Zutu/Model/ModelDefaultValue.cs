using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Zutu.Model
{
    /// <summary>
    /// 前期model选型，默认属性值
    /// </summary>
    public class ModelDefaultValue
    {
        public int ModelDefaultValueID { get; set; }
        //属性名字
        public string PropertyName{get;set;}
        //属性默认值ValueCode的ID
        public int ValueCodeID { get; set; }
    }
}
