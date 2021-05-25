using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11_1
{
    public class OrderService
    {
        public int orderNum = 0;
        public int detailNum = 0;
        public int commodityNum = 0;
        //商品列表
        public static Commodity banana = new Commodity("banana", 10);
        public static Commodity apple = new Commodity("apple", 20);
        public static Commodity bottle = new Commodity("bottle", 1);
        public static Commodity bird = new Commodity("bird", 100);

        public Commodity GiveCommodity(string s)
        {
            if (s == "banana") return new Commodity("banana", 10);
            if (s == "apple") return new Commodity("apple", 20);
            if (s == "bottle") return new Commodity("bottle", 1);
            if (s == "bird") return new Commodity("bird", 100);
            else return null;
        }

        //添加订单
        public bool AddOrder(string customer, Dictionary<Commodity, int> myCommodity)
        {
            using (var context = new OrderContext())
            {
                var order = new Order(customer, myCommodity);
                context.Orders.Add(order);
                context.SaveChanges();
                orderNum = order.OrderId;
            }
            Console.WriteLine("交易添加成功");
            return true;
        }
        public void DeleteOrder(int id)
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders.Include("Details").FirstOrDefault(p => p.OrderId == id);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
            }
        }
        //修改order以修改客户名字为例
        public void ModifyOrder(int id, string newName)
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders.FirstOrDefault(o => o.OrderId == id);
                if (order != null)
                {
                    order.Customer = newName;
                    context.SaveChanges();
                }
            }
        }

        //通过订单号查询Order
        public List<Order> FindByID(int id)
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders
                    .SingleOrDefault(b => b.OrderId == id);
                return new List<Order>() { order};
            }
        }
        //通过客户名查询Order
        public List<Order> FindByCustomer(string name)
        {
            using (var context = new OrderContext())
            {
                var query = context.Orders
                    .Where(b => b.Customer == name);
                return query.ToList<Order>();
            }
        }
        //通过订单金额查询Order
        public List<Order> FindByCost(int cost)
        {
            using (var context = new OrderContext())
            {
                var query = context.Orders
                    .Where(b => b.Cost == cost);
                return query.ToList<Order>();
            }
        }

        //输出order List
        public void Display(List<Order> t)
        {
            foreach (var item in t)
            {
                Console.WriteLine(item);
            }
        }
    }
}
