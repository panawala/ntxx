using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Zutu.Unit
{
    public class UnitConstraint
    {
        public int UnitConstraintID { get; set; }
        public string PropertyName { get; set; }
        public string InfluencedPropertyName { get; set; }
    }
}
