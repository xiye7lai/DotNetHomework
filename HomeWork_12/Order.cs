using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace HomeWork_12
{
    public delegate int func(object obj1, object obj2);
    public class OrderNumException : Exception
    {
        public OrderNumException(string message) : base(message)
        {
        }
    }

    public class Commodity
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Commodity()
        {

        }

        public Commodity(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return "商品名称：" + Name + " 商品单价：" + Price;
        }
    }
    public class Order : IComparable
    {
        private int _id;
        private string _customer;
        private int _cost;
        private OrderDetails _details;

        public Order()
        {
            ID = 0;
            Customer = "";
            Cost = 0;
            Details = null;
        }
        public Order(int id, string customer, int cost, Dictionary<string, int> commodity)
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

        public int CompareTo(object obj)
        {
            Order order = obj as Order;
            if (order == null) throw new System.ArgumentNullException();
            return ID.CompareTo(order.ID);
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   ID == order.ID &&
                   Customer == order.Customer &&
                   Cost == order.Cost;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Customer, Cost);
        }

        public override string ToString()
        {
            return "订单号：" + ID + " 客户名：" + Customer + " 总金额：" + Cost + " 订单详情：\n" + Details;
        }
    }

    public class OrderDetails
    {
        //key表示商品，value表示商品数量
        public Dictionary<string, int> CommodityNum { get; set; }

        public OrderDetails()
        {
            CommodityNum = new Dictionary<string, int>();
        }

        public OrderDetails(Dictionary<string, int> n)
        {
            CommodityNum = n;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   EqualityComparer<Dictionary<string, int>>.Default.Equals(CommodityNum, details.CommodityNum);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CommodityNum);
        }

        public override string ToString()
        {
            string s = "";
            foreach (var item in CommodityNum)
            {
                s += item.Key + " 购买数量：" + item.Value + "\n";
            }
            return s;
        }
    }

    public class OrderService
    {
        private static int orderNum = 0;
        //商品列表
        public static Commodity banana = new Commodity("banana", 10);
        public static Commodity apple = new Commodity("apple", 20);
        public static Commodity bottle = new Commodity("bottle", 1);
        public static Commodity bird = new Commodity("bird", 100);

        //订单List
        public List<Order> Orders = new List<Order>();
        public int GivePrice(string s){
            if(s==banana.Name) return banana.Price;
            if(s==apple.Name) return apple.Price;
            if(s==bottle.Name) return bottle.Price;
            if(s==bird.Name) return bird.Price;
            else return 0;
        }

        //添加订单
        public bool AddOrder(string customer, Dictionary<string, int> myCommodity)
        {
            int cost = 0;
            foreach (var item in myCommodity)
            {
                cost += (GivePrice(item.Key) * item.Value);
            }
            Order newOrder = new Order(orderNum, customer, cost, myCommodity);
            //判断是否有相同order或orderdetails
            foreach (var item in Orders)
            {
                if (newOrder.Equals(item)) return false;
            }
            Orders.Add(new Order(orderNum, customer, cost, myCommodity));
            orderNum++;
            Console.WriteLine("交易添加成功");
            return true;
        }
        public void DeleteOrder(int id)
        {
            //if (id < 0 || id >= Orders.Count) throw new OrderNumException("不存在该订单编号");
            for(int i = 0; i < Orders.Count; i++)
            {
                if(id==Orders[i].ID) Orders.RemoveAt(i);
            }
        }
        //修改order以修改客户名字为例
        public void ModifyOrder(int id, string newName)
        {
            //if (id < 0 || id >= Orders.Count) throw new OrderNumException("不存在该订单编号");
            for (int i = 0; i < Orders.Count; i++)
            {
                if (id == Orders[i].ID) Orders[i].Customer = newName;
            }
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
                    List<string> list = s.Details.CommodityNum.Keys.ToList<string>();
                    foreach (var item in list)
                    {
                        if (item == name) return true;
                    }
                    return false;
                })
                .OrderBy(s => s.Cost);
            return query.ToList<Order>();
        }

        //输出order List
        public void Display(List<Order> t)
        {
            foreach (var item in t)
            {
                Console.WriteLine(item);
            }
        }
        //排序功能(默认按照ID排序)
        public void SortOrder()
        {
            Orders.Sort();
        }
        //排序功能(按照lambda表达式排序)
        public void SortOrder(Comparison<Order> t)
        {
            Orders.Sort(t);
        }

        //订单序列化为XML文件
        public void Export(string s)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));
            using (FileStream fs = new FileStream(s, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, Orders.ToArray());
            }
        }

        //从xml文件导入订单
        public void Import(string s)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));
            using (FileStream fs = new FileStream(s, FileMode.Open))
            {
                Order[] orders = (Order[])xmlSerializer.Deserialize(fs);
                Array.ForEach(orders, p => Orders.Add(p));
            }
        }
    }

}
