using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Order;
using DataContext;

namespace EntityFrameworkTryBLL.OrderManager
{
    public class OrderBLL
    {
        public static List<ordersinfo> getAllOrders(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var ordersinfoes = context.ordersinfoes
                        .Where(s=>s.OrderNo==orderId)
                        .ToList();
                    return ordersinfoes;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public static int InsertIntoOrder(int orderId)
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    ordersinfo oi = new ordersinfo
                    {
                        OrderNo=orderId,
                        OrderTotal=23,
                        ordersinfoID=1
                    };
                    context.ordersinfoes.Add(oi);
                    return context.SaveChanges();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }


        public static int DeleteAll()
        {
            using (var context = new AnnonContext())
            {
                try
                {
                    var ois = context.ordersinfoes;
                    foreach (var oi in ois)
                    {
                        context.ordersinfoes.Remove(oi);
                    }
                   return context.SaveChanges(); 
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

    }
}
