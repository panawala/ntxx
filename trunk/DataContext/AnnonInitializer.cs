using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Model.Property;
using Model.Device;
using Model.Zutu;

namespace DataContext
{
    public class AnnonInitializer : DropCreateDatabaseIfModelChanges<AnnonContext>
    {
        protected override void Seed(AnnonContext context)
        {
            var properties = new List<Property>
            {
                new Property { PropertyName = "冷量",  PropertyParentID=0, PropertyDefaultValueID=0,PropertyType="默认",CatalogName=""},
                new Property { PropertyName = "电压",  PropertyParentID=0, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName=""},
                new Property { PropertyName = "内部防腐/送风方向",  PropertyParentID=0, PropertyDefaultValueID=0,PropertyType="默认",CatalogName="" },
                new Property { PropertyName = "制冷形式",  PropertyParentID=0, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="A"}  ,
                new Property { PropertyName = "制冷组合",  PropertyParentID=0, PropertyDefaultValueID=0,PropertyType="默认",CatalogName=""},
                new Property { PropertyName = "盘管防腐涂层",  PropertyParentID=0, PropertyDefaultValueID=0,PropertyType="默认",CatalogName="" },
                new Property { PropertyName = "制冷/热泵级数",  PropertyParentID=0, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName=""},
                new Property { PropertyName = "加热方式",  PropertyParentID=0, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="B"} ,
                new Property { PropertyName = "加热组合",  PropertyParentID=0, PropertyDefaultValueID=0,PropertyType="默认",CatalogName=""},
                new Property { PropertyName = "制热级数",  PropertyParentID=0, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName=""},
                new Property { PropertyName = "新回风选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认",CatalogName="1A" },
                new Property { PropertyName = "回风机/排风机组合选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="1B"},
                new Property { PropertyName = "回风机/排风机叶轮选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认",CatalogName="1C"},
                new Property { PropertyName = "回风机/排风机电机选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="1D"},
                new Property { PropertyName = "新风控制选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="2"},
                new Property { PropertyName = "加热选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="3"}  ,
                new Property { PropertyName = "维护选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认",CatalogName="4"},
                new Property { PropertyName = "送风机组合选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="5A"},
                new Property { PropertyName = "送风机叶轮选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="5B"},
                new Property { PropertyName = "送风机电机选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="5C"},
                new Property { PropertyName = "初效过滤器选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认",CatalogName="6A"},
                new Property { PropertyName = "机组过滤器选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="6B"},
                new Property { PropertyName = "过滤器配件选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="6C"},
                new Property { PropertyName = "制冷系统保护选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="7"} ,
                new Property { PropertyName = "制冷系统选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认",CatalogName="8"},
                new Property { PropertyName = "制冷配件选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="9"},
                new Property { PropertyName = "空气开关选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="10"},
                new Property { PropertyName = "安全选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="11"}  ,
                new Property { PropertyName = "机组控制选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认",CatalogName="12"},
                new Property { PropertyName = "特殊控制选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认",CatalogName="13" },
                new Property { PropertyName = "新风预热选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="14A"},
                new Property { PropertyName = "预热量选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="14B"},
                new Property { PropertyName = "加湿选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认",CatalogName="15A"},
                new Property { PropertyName = "加湿量选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认",CatalogName="15B" },
                new Property { PropertyName = "加湿控制选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="15C"},
                new Property { PropertyName = "箱体选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="16"}   ,
                new Property { PropertyName = "认证选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认",CatalogName="17"},
                new Property { PropertyName = "包装选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="18"},
                new Property { PropertyName = "水冷冷凝器选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="19"},
                new Property { PropertyName = "控制器品牌选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认",CatalogName="20" }  ,
                new Property { PropertyName = "其他选项",  PropertyParentID=1, PropertyDefaultValueID=0,PropertyType="默认" ,CatalogName="21"}   
            };
            properties.ForEach(s => context.Properties.Add(s));
            context.SaveChanges();

            var propertyValues = new List<PropertyValue>
           {
               new PropertyValue{PropertyID=1,ValueCodeID=1,ValueCode="8",ValueDescription="8KW",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=1,ValueCodeID=2,ValueCode="9",ValueDescription="9KW",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=1,ValueCodeID=3,ValueCode="10",ValueDescription="10KW",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=1,ValueCodeID=4,ValueCode="11",ValueDescription="11KW",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=1,ValueCodeID=5,ValueCode="12",ValueDescription="12KW",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=1,ValueCodeID=6,ValueCode="13",ValueDescription="13KW",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=2,ValueCodeID=7,ValueCode="3",ValueDescription="460V/3Ø/60Hz",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=2,ValueCodeID=8,ValueCode="6",ValueDescription="380V/415V/3Ø/50Hz",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=3,ValueCodeID=9,ValueCode="0",ValueDescription="送风箱体",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=3,ValueCodeID=10,ValueCode="A",ValueDescription="R22",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=3,ValueCodeID=11,ValueCode="B",ValueDescription="R410A",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=3,ValueCodeID=12,ValueCode="E",ValueDescription="R410A 数码涡旋",DeviceID=1,PropertyValueType="价格计算"},
               new PropertyValue{PropertyID=3,ValueCodeID=13,ValueCode="G",ValueDescription="R410A直流变频",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=4,ValueCodeID=14,ValueCode="0",ValueDescription="无制冷",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=4,ValueCodeID=15,ValueCode="A",ValueDescription="风冷冷凝器（单冷+ 标准蒸发盘管）",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=4,ValueCodeID=16,ValueCode="B",ValueDescription="风冷冷凝器（单冷+ 6排蒸发盘管）",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=4,ValueCodeID=17,ValueCode="J",ValueDescription="水冷冷凝器（单冷+ 标准蒸发盘管）",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=4,ValueCodeID=18,ValueCode="K",ValueDescription="水冷冷凝器（单冷+ 6排蒸发盘管）",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=4,ValueCodeID=19,ValueCode="P",ValueDescription="风冷冷凝器（单冷+ 6排蒸发盘管 + 混合风旁通）",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=4,ValueCodeID=20,ValueCode="Q",ValueDescription="风冷冷凝器（单冷+ 6排蒸发盘管 + 回风旁通）",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=4,ValueCodeID=21,ValueCode="R",ValueDescription="水冷冷凝器（单冷+ 6排蒸发盘管 + 回风旁通）",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=4,ValueCodeID=22,ValueCode="T",ValueDescription="水冷冷凝器（单冷+ 6排蒸发盘管 + 混合风旁通）",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=4,ValueCodeID=23,ValueCode="U",ValueDescription="标准冷冻水盘管",DeviceID=1,PropertyValueType="附件"},
               new PropertyValue{PropertyID=4,ValueCodeID=24,ValueCode="W",ValueDescription="6排冷冻水盘管",DeviceID=1,PropertyValueType="附件"},
               new PropertyValue{PropertyID=4,ValueCodeID=25,ValueCode="2",ValueDescription="无压缩机（分体内机+ 标准蒸发盘管）",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=4,ValueCodeID=26,ValueCode="4",ValueDescription="无压缩机（分体内机+ 6排蒸发盘管）",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=4,ValueCodeID=27,ValueCode="6",ValueDescription="风冷冷凝器（热泵）",DeviceID=1,PropertyValueType="普通"},
               new PropertyValue{PropertyID=4,ValueCodeID=28,ValueCode="7",ValueDescription="水源热泵",DeviceID=1,PropertyValueType="普通"}
           };
            propertyValues.ForEach(s => context.PropertyValues.Add(s));
            context.SaveChanges();

            var currentDivices = new List<CurrentDevice>
            {
                new CurrentDevice{ DeviceID=1,OrderDetailID=1,PropertyID=1,PropertyValueArray="",PropertyValueId=1},
                new CurrentDevice{ DeviceID=1,OrderDetailID=1,PropertyID=2,PropertyValueArray="",PropertyValueId=7},
                new CurrentDevice{ DeviceID=1,OrderDetailID=1,PropertyID=3,PropertyValueArray="",PropertyValueId=10},
                new CurrentDevice{ DeviceID=1,OrderDetailID=1,PropertyID=4,PropertyValueArray="",PropertyValueId=17}
            };
            currentDivices.ForEach(s => context.CurrentDevices.Add(s));
            context.SaveChanges();

            var propertyConstraints = new List<PropertyConstraint>
            {
                new PropertyConstraint{PropertyID=1,PropertyValueIdRange="1,2,3",InfluencedPtyID=2,InfluencedPtyValueIdRange="7",ConstraintRules="约束筛选",InfluencedPtyDefaultValue="8",DeviceID=1},
                new PropertyConstraint{PropertyID=4,PropertyValueIdRange="14,15,16,17,18,19,20",InfluencedPtyID=2,InfluencedPtyValueIdRange="7",ConstraintRules="约束筛选",InfluencedPtyDefaultValue="11",DeviceID=1},
                new PropertyConstraint{PropertyID=3,PropertyValueIdRange="9,10,11",InfluencedPtyID=2,InfluencedPtyValueIdRange="7",ConstraintRules="约束筛选",InfluencedPtyDefaultValue="8",DeviceID=1},
                new PropertyConstraint{PropertyID=1,PropertyValueIdRange="4,5,6",InfluencedPtyID=2,InfluencedPtyValueIdRange="8",ConstraintRules="约束筛选",InfluencedPtyDefaultValue="10",DeviceID=1},
                new PropertyConstraint{PropertyID=4,PropertyValueIdRange="21,22,23,24,25,26,27,28",InfluencedPtyID=2,InfluencedPtyValueIdRange="8",ConstraintRules="约束筛选",InfluencedPtyDefaultValue="3",DeviceID=1}, 
                new PropertyConstraint{PropertyID=3,PropertyValueIdRange="12,13",InfluencedPtyID=2,InfluencedPtyValueIdRange="8",ConstraintRules="约束筛选",InfluencedPtyDefaultValue="10",DeviceID=1}
            };
            propertyConstraints.ForEach(s => context.PropertyConstraints.Add(s));
            context.SaveChanges();


            var propertyPriceConstraints = new List<PropertyPriceConstraint> 
            {
                new PropertyPriceConstraint{PropertyID=1,PropertyValue="3",InfluencedPtyID=2,InfluencedPtyValue="7",InfluencedPtyPrice=1},
                new PropertyPriceConstraint{PropertyID=1,PropertyValue="4",InfluencedPtyID=2,InfluencedPtyValue="8",InfluencedPtyPrice=2}
            };
            propertyPriceConstraints.ForEach(s => context.PropertyPriceConstraints.Add(s));
            context.SaveChanges();

            //小数据库中使用
            var devices = new List<Device>
            {
                new Device{DeviceName="测试设备",DeviceType="测试",
                    PropertyArray="1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41",
                    PropertyValueArray="1,7,9,13,19,34,58,97,104,126,170,190,204,211,230,253,260,271,284,293,312,320,326,331,363,378,390,397,406,422,428,437,450,455,480,487,495,501,505,537,545"}
            };
            devices.ForEach(s => context.Devices.Add(s));
            context.SaveChanges();

            //var accessories = new List<Accessory>
            //{
            //    new Accessory{DeviceID=1,PropertyID=4,PropertyValueCodeId=13,AccessoryName="附件1",AccessoryDescription="测试2",AcessoryPrice=1050,AccessoryNo="R37890"},
            //    new Accessory{DeviceID=1,PropertyID=4,PropertyValueCodeId=14,AccessoryName="附件2",AccessoryDescription="测试2",AcessoryPrice=2050,AccessoryNo="R37890"}
            //};
            //accessories.ForEach(s => context.Accessories.Add(s));
            //context.SaveChanges();

            var imageBlocks = new List<ImageBlock>
            {
                new ImageBlock{CoolingPower=5,ImageName="BBA",ImageLength=18f,ImageWidth=50f,ImageHeight=32f},
                new ImageBlock{CoolingPower=5,ImageName="BBB",ImageLength=24f,ImageWidth=50f,ImageHeight=32f},
                new ImageBlock{CoolingPower=5,ImageName="BBC",ImageLength=26f,ImageWidth=50f,ImageHeight=32f},
                new ImageBlock{CoolingPower=5,ImageName="BBD",ImageLength=32f,ImageWidth=50f,ImageHeight=32f},
                new ImageBlock{CoolingPower=5,ImageName="BBE",ImageLength=36f,ImageWidth=50f,ImageHeight=32f}
            };
            imageBlocks.ForEach(s => context.ImageBlocks.Add(s));
            context.SaveChanges();

        }
    }
}
