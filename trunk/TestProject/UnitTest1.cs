using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataContext;
using Model.Device;
using Model.Property;
using System.Data.Entity;
using EntityFrameworkTryBLL;
using EntityFrameworkTryBLL.TreeManager;
using EntityFrameworkTryBLL.UnitManager;
using EntityFrameworkTryBLL.ZutuManager;


namespace TestProject
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        //[TestInitialize()]
        public void CodeFisrtTestInitialize()
        {
            //Database.SetInitializer<NorthwindContext>(new DropCreateDatabaseIfModelChanges<NorthwindContext>());
            Database.SetInitializer<AnnonContext>(new AnnonInitializer());
        }
        
        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
            //using (var context = new NorthwindContext())
            //{

            //    try
            //    {
            //        context.Departments.Add(new Department()
            //                       {
            //                           DeparmentName = "IT Department"
            //                       });
            //        context.SaveChanges();
            //        Assert.AreEqual(1, context.Departments.Count());

            //    }
            //    catch (Exception e)
            //    {

            //    }
            //}
            try
            {

                using (var context = new AnnonContext())
                {
                    try
                    {
                        var contentCurrentValue = context.ContentCurrentValues;
                    }
                    catch (Exception e)
                    { 
                    }
                    
                }

             

                //var list = UnitBLL.getAllByCondition("Unit Size", 1);

                var contentList = ContentBLL.getAllByCondition("DRAIN PAN TYPE", 1, 5, "BBA", "102-113");

                var entity = TreeEntityBLL.addToParentEntity(new TreeEntity("1"));
                List<TreeEntity> treeEntities = entity.ParentTreePath;


                // var entity = TreeEntityBLL.addToParentEntity(new TreeEntity("44"));
                var currentRedPtyModels = PropertyBLL.GetDirectRedPtyModels(1, 11, "170", 1);

                var currentPropertyValues = PropertyBLL.GetAvaliablePtyValueRange(1, 14, 1);

                var currentPropertyModels = PropertyBLL.GetAvaliableValueRange(1, 14, 1);
                //得到当前的每个属性的取值范围。如果某个属性不存在。说明出错。
                var currentPropertyModelss = PropertyBLL.GetAvailablePtyModels(1, 1);

                //得到当前需要变红的属性及变红后的值
                var redModel = PropertyBLL.GetRedPropertyModel(1, 1);
                while (redModel != null)
                {
                    redModel = PropertyBLL.GetRedPropertyModel(1, 1);
                }

                //List<Device> devices = DeviceBLL.GetAllDevices();

                //List<Property> properties = PropertyBLL.GetPropertiesByDeviceId(1);

                //List<InfluencedProperty> influencedpties = PropertyBLL.GetPtyContsByDeviceandPtyId(1, 4, "T");

                //DeviceBLL.InitialDevices(1, 1);

                //var propertyValues = PropertyBLL.GetCurrentPtyValues(1, "冷量", 1);

                //var propertyModels = PropertyBLL.SetCurrentPtyValues(1, "电压", 1, "6");
                //string result = DeviceBLL.Intersect("1,2,3", "2,5,3,4");
                //string reuslt = DeviceBLL.GetPropertyValueString(1, 1, 1);
            }
            catch (Exception e)
            {

            }


        }
    }
}
