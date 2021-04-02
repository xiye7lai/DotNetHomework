using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace HomeWork_6_1
{
    //因为c#本身Dictionary无法xml序列化，copy来网上的可序列化的dictionary子类
    [XmlRoot("XmlDictionary")]
    [Serializable]
    public class XmlDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {
        #region 构造函数
        public XmlDictionary()
        { }

        public XmlDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary)
        { }

        public XmlDictionary(IEqualityComparer<TKey> comparer) : base(comparer)
        { }
        public XmlDictionary(int capacity) : base(capacity)
        { }
        public XmlDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(capacity, comparer)
        { }
        protected XmlDictionary(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
        #endregion 构造函数

        #region IXmlSerializable Members
        public XmlSchema GetSchema() => null;
        public void ReadXml(XmlReader xr)
        {
            if (xr.IsEmptyElement)
                return;
            var ks = new XmlSerializer(typeof(TKey));
            var vs = new XmlSerializer(typeof(TValue));
            xr.Read();
            while (xr.NodeType != XmlNodeType.EndElement)
            {
                xr.ReadStartElement("Item");
                xr.ReadStartElement("Key");
                var key = (TKey)ks.Deserialize(xr);
                xr.ReadEndElement();
                xr.ReadStartElement("Value");
                var value = (TValue)vs.Deserialize(xr);
                xr.ReadEndElement();
                Add(key, value);
                xr.ReadEndElement();
                xr.MoveToContent();
            }
            xr.ReadEndElement();
        }
        public void WriteXml(XmlWriter xw)
        {
            var ks = new XmlSerializer(typeof(TKey));
            var vs = new XmlSerializer(typeof(TValue));
            foreach (var key in Keys)
            {
                xw.WriteStartElement("Item");
                xw.WriteStartElement("Key");
                ks.Serialize(xw, key);
                xw.WriteEndElement();
                xw.WriteStartElement("Value");
                vs.Serialize(xw, this[key]);
                xw.WriteEndElement();
                xw.WriteEndElement();
            }
        }
        #endregion IXmlSerializable Members
    }
    public delegate int func(object obj1, object obj2);
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
        public Order(int id, string customer, int cost, XmlDictionary<Commodity, int> commodity)
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
        public XmlDictionary<Commodity, int> CommodityNum { get; set; }

        public OrderDetails()
        {
            CommodityNum = new XmlDictionary<Commodity, int>();
        }

        public OrderDetails(XmlDictionary<Commodity, int> n)
        {
            CommodityNum = n;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   EqualityComparer<XmlDictionary<Commodity, int>>.Default.Equals(CommodityNum, details.CommodityNum);
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

        //添加订单
        public bool AddOrder(string customer, XmlDictionary<Commodity, int> myCommodity)
        {
            int cost = 0;
            foreach (var item in myCommodity)
            {
                cost += (item.Key.Price * item.Value);
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
            if (id < 0 || id >= Orders.Count) throw new OrderNumException("不存在该订单编号");
            Orders.RemoveAt(id);
        }
        //修改order以修改客户名字为例
        public void ModifyOrder(int id, string newName)
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
        public void Export()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));
            using (FileStream fs =new FileStream("order.xml",FileMode.Create))
            {
                xmlSerializer.Serialize(fs, Orders.ToArray());
            }
        }

        //从xml文件导入订单
        public void Import()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));
            using (FileStream fs = new FileStream("order.xml", FileMode.Open))
            {
                Order[] orders = (Order[])xmlSerializer.Deserialize(fs);
                Array.ForEach(orders, p => Orders.Add(p));
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderService service = new OrderService();
            //模拟购物1
            XmlDictionary<Commodity, int> customer_1 = new XmlDictionary<Commodity, int>()
            { { OrderService.banana, 3 }, { OrderService.apple, 10 } };
            service.AddOrder("David", customer_1);
            //模拟购物2
            XmlDictionary<Commodity, int> customer_2 = new XmlDictionary<Commodity, int>()
            { { OrderService.apple, 5 }, { OrderService.bird, 1 }, { OrderService.bottle, 10 } };
            service.AddOrder("Caul", customer_2);
            //模拟购物3
            XmlDictionary<Commodity, int> customer_3 = new XmlDictionary<Commodity, int>()
            { {OrderService.banana,1},{OrderService.apple,1},{OrderService.bird,1},{OrderService.bottle,1}};
            service.AddOrder("kkk", customer_3);
            //模拟购物4
            XmlDictionary<Commodity, int> customer_4 = new XmlDictionary<Commodity, int>()
            { {OrderService.banana,5},{OrderService.apple,5},{OrderService.bird,3},{OrderService.bottle,1}};
            service.AddOrder("David", customer_4);

            //xml序列化
            service.Export();
            Console.WriteLine("<------------------------------------->");
            Console.WriteLine("xml序列化");
            Console.WriteLine(File.ReadAllText("order.xml"));

            //新建服务并且从xml文件中导入订单
            OrderService service1 = new OrderService();
            service1.Import();
            Console.WriteLine("<------------------------------------->");
            Console.WriteLine("从xml文件中导入订单");
            service1.Display(service1.Orders);
        }
    }
}
