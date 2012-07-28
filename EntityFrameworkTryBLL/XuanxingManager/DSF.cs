using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Model.Xuanxing;

namespace EntityFrameworkTryBLL.XuanxingManager
{
    public class DSF
    {
        ArrayList parentVisted = new ArrayList();//记录已经访问的属性名称
        public List<CatalogModel> savecatalogModel = new List<CatalogModel>();
        Queue<CatalogModel> queue = new Queue<CatalogModel>();//记录属性详细值
        public void Traverse(List<CatalogModel> test,int orderId,int deviceId)
        {
            if (test != null)
            {
                foreach (CatalogModel v in test)
                {
                    queue.Enqueue(v);
                    //if (parentVisted.IndexOf(v.PropertyName) != 0)
                    {
                        parentVisted.Add(v);
                        savecatalogModel.Add(v);
                        while (queue.Count > 0)
                        {
                            Traverse(CatalogBLL.getAllByCon(v.PropertyName, orderId, deviceId), orderId, deviceId);
                            queue.Dequeue();
                        }
                    }
                }
                //parentVisted.Remove(parentVisted.ToArray().Last().ToString());
            }
        }
    }
}
