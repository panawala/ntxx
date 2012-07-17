using System;
using System.Collections.Generic;
using System.Linq;
using CadLib.OperatorEntity;

namespace CadLib.Entity
{
    public class DataCenter
    {
        public BoxEntity BoxEntity { get; set; }
        public OrderEntity OrderEntity { get; set; }
        public SectionEntity SectionEntity { get; set; }
        public List<string> Configurations { get; set; }
        public DetailMechineConfigure detailMechineConfigure { get; set; }
        public TopViewConfigure topViewConfigure{get;set;}
    }
}
