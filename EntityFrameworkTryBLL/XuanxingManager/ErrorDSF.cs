using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Model.Xuanxing;
using EntityFrameworkTryBLL.XuanxingManager;

namespace EntityFrameworkTryBLL.XuanxingManager
{
    public class ErrorDSF
    {
        //暂时记录属性详细值
        Queue<CatalogModel> queue = new Queue<CatalogModel>();
        //记录错误约束
        public  ArrayList errorArr = new ArrayList();
        //记录最后可选的属性值集合
        public List<CatalogModel> savecatalogModel = new List<CatalogModel>(); 
        public void Traverse(List<CatalogModel> test, int orderId, int deviceId,string parentName)
        {
            if (test != null)
            {
                //检测要访问的属性的值是否已经存在已访问的队列中
                foreach (CatalogModel catalogMod in test)
                {
                    catalogMod.IsSelected = true;

                    catalogMod.ParentName = parentName;
 
                    foreach (CatalogModel savemodel in savecatalogModel)
                    {
                        if (savemodel.IsSelected == true
                            && catalogMod.PropertyName == savemodel.PropertyName
                            && catalogMod.Value != savemodel.Value)
                        {
                            catalogMod.IsSelected = false;
                            //检查错误约束，将错误约束记录到ArrayList数组中
                            errorArr.Add(catalogMod.PropertyName + catalogMod.Value);
                            string parentList = catalogMod.ParentName;
                            foreach (CatalogModel error in savecatalogModel)
                            {
                                if (parentList == error.PropertyName)
                                {
                                    errorArr.Add(error.PropertyName + error.Value);
                                    parentList = error.ParentName;
                                }
                            }
                        }
                        
                    }
                }
                //将可以继续递归的属性值加入到队列中，并递归
                List<CatalogModel> temp = new List<CatalogModel>();
                foreach (CatalogModel v in test)
                {
                    if (v.IsSelected == true)
                    {
                        //queue.Enqueue(v);
                        //parentVisted.Add(v);
                        savecatalogModel.Add(v);

                        //while (queue.Count > 0)
                        //{
                            
                            temp=CatalogBLL.getAllByCon(v.PropertyName, orderId, deviceId);

                            if (temp != null&&temp.Count()!=0)
                            {
                                foreach (CatalogModel childModel in temp)
                                {                                  
                                        string name = v.PropertyName;
                                        childModel.ParentNode = v;
                                        Traverse(temp, orderId, deviceId, name);
                                        //queue.Dequeue();                                  
                                }
                            }
                            else
                            {
                                if (parentName != "Root")
                                {
                                    v.ParentNode.ResultValue = true;
                                    break;
                                }
                            }
                      
                    }
                }

            }
        }

    }
}
