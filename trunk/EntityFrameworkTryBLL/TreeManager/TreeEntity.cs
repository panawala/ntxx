using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkTryBLL.TreeManager
{
    public class TreeEntity
    {
        /// <summary>
        /// 树节点构造函数
        /// </summary>
        /// <param name="propertyId"></param>
        public TreeEntity(string propertyId)
        {
            this.PropertyId = propertyId;
            this.SubTreeEntities = new List<TreeEntity>();
            this.ParentTreePath = new List<TreeEntity>();
        }
        public string PropertyId { get; set; }
        public List<TreeEntity> SubTreeEntities { get; set; }
        public List<TreeEntity> ParentTreePath { get; set; }
    }
}
