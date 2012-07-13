using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Model;
using Model.Device;
using Model.Property;
using Model.Zutu;

namespace DataContext
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext()
            : base()
        { }

        public NorthwindContext(string connName)
            : base()
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyValue> PropertyValues { get; set; }
        public DbSet<PropertyConstraint> PropertyConstraints { get; set; }
        public DbSet<PropertyPriceConstraint> PropertyPriceConstraints { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<CurrentDevice> CurrentDevices { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<ImageBlock> ImageBlocks { get; set; }
    }
}
