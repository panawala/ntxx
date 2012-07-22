using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Model;
using Model.Device;
using Model.Property;
using Model.Zutu;
using Model.Zutu.Content;
using Model.Order;
using Model.Zutu.Unit;
using Model.Zutu.ImageModel;

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
        public DbSet<ContentCurrentValue> ContentCurrentValues { get; set; }
        public DbSet<ContentConstraint> ContentConstraints { get; set; }
        public DbSet<ContentOrder> ContentOrders { get; set; }
        public DbSet<orderDetailInfo> orderDetailInfoes { get; set; }
        public DbSet<ordersinfo> ordersinfoes { get; set; }
        public DbSet<UnitModel> UnitModels { get; set; }
        public DbSet<UnitConstraint> UnitConstraints { get; set; }
        public DbSet<UnitCurrentValue> UnitCurrentValues { get; set; }
        public DbSet<UnitOrder> UnitOrders { get; set; }
        public DbSet<ImageModel> ImageModels { get; set; }
        
    }
}
