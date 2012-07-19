﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Model;
using Model.Device;
using Model.Property;
using Model.Zutu;
using Model.Zutu.Content;

namespace DataContext
{
    public class AnnonContext : DbContext
    {
        public AnnonContext()
            : base()
        { }

        public AnnonContext(string connName)
            : base()
        { }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyValue> PropertyValues { get; set; }
        public DbSet<PropertyConstraint> PropertyConstraints { get; set; }
        public DbSet<PropertyPriceConstraint> PropertyPriceConstraints { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<CurrentDevice> CurrentDevices { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<ImageBlock> ImageBlocks { get; set; }
        public DbSet<ContentPropertyValue> ContentPropertyValues { get; set; }
    }
}
