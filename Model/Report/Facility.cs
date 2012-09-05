using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Report
{
    public class Facility
    {
        public int FacilityID { get; set; }
        public string PropertyParent { get; set; }
        public string PropertyName { get; set; }
        public string Value { get; set; }
        public string ValueDescription { get; set; }
        public string Type { get; set; }
    }
}
