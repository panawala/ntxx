using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Property
{
    public class PropertyModel
    {
        //public string PropertyName { get; set; }
        public int PropertyId { get; set; }
        public int PropertyValueId { get; set; }
        
    }
    /// <summary>
    /// 业务逻辑类
    /// </summary>
    public class PropertyModelLogic
    {
        public string PropertyName { get; set; }
        public string ValueCode { get; set; }
    }
}
