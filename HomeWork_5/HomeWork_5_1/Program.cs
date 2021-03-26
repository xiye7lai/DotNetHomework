using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_5_1
{
    class OrderNumException : Exception
    {
        public OrderNumException(string message) : base(message)
        {
        }
    }

    public class Commodity
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Commodity(string name,int price)
        {
            Name = name;
            Price = price;
        }
    }
    public class Order
    {
        private int _id;
        private string _customer;
        private int _cost;
        private OrderDetails _details;

        public Order(int id,string customer,int cost, Dictionary<Commodity, int> commodity)
        {
            ID = id;
            Customer = customer;
            Cost = cost;
            Details = new OrderDetails(commodity);
        }
        public int ID { get => _id; set => _id = value; }
        public string Customer { get => _customer; set => _customer = value; }
        public int Cost { get => _cost; set => _cost = value; }
        public OrderDetails Details { get => _details; set => _details = value; }
    }

    public class OrderDetails
    {
        //key表示商品，value表示商品数量
        public Dictionary<Commodity, int> CommodityNum { get; set; }

        public OrderDetails(Dictionary<Commodity, int> n)
        {
            CommodityNum = n;
        }
    }

    public class OrderService
    {
        private static int orderNum = 0;
        //商品列表
        public Commodity banana = new Commodity("banana", 10);
        public Commodity apple = new Commodity("apple", 20);
        public Commodity bottle = new Commodity("bottle", 1);
        public Commodity bird = new Commodity("bird", 100);

        //订单List
        List<Order> Orders = new List<Order>();
        
        //添加订单
        public void AddOrder(string customer, Dictionary<Commodity, int> myCommodity)
        {
            int cost = 0;
            foreach (var item in myCommodity)
            {
                cost += (item.Key.Price * item.Value);
            }
            Orders.Add(new Order(orderNum, customer,cost,myCommodity));
            orderNum++;
        }
        public void DeleteOrder(int id)
        {
            if (id < 0 || id >= Orders.Count) throw new OrderNumException("不存在该订单编号");
            Orders.RemoveAt(id);
        }
        //修改order以修改客户名字为例
        public void ModifyOrder(int id,string newName)
        {
            if (id < 0 || id >= Orders.Count) throw new OrderNumException("不存在该订单编号");
            Orders[id].Customer = newName;
        }
        
        //通过订单号查询Order
        public List<Order> FindByID(int id)
        {
            var query = Orders
                .Where(s => s.ID == id)
                .OrderBy(s => s.Cost);
            return query.ToList<Order>();
        }
        //通过客户名查询Order
        public List<Order> FindByCustomer(string name)
        {
            var query = Orders
                .Where(s => s.Customer == name)
                .OrderBy(s => s.Cost);
            return query.ToList<Order>();
        }
        //通过订单金额查询Order
        public List<Order> FindByCost(int cost)
        {
            var query = Orders
                .Where(s => s.Cost == cost)
                .OrderBy(s => s.Cost);
            return query.ToList<Order>();
        }
        //通过商品名称查询Order
        public List<Order> FindByCommodity(string name)
        {

            var query = Orders
                .Where(s => {
                    List<Commodity> list = s.Details.CommodityNum.Keys.ToList<Commodity>();
                    foreach (var item in list)
                    {
                        if (item.Name == name) return true;
                    }
                    return false;
                    })
                .OrderBy(s=>s.Cost);
            return query.ToList<Order>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
