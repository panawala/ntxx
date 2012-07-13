using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Property
{
    public class InfluencedProperty
    {
        public Property Property { get; set; }
        public IEnumerable<PropertyValue> PropertyValues { get; set; }
    }
}
