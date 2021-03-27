using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_5_1
{
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

        public Commodity(string name,int price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return "商品名称："+Name+" 商品单价："+Price;
        }
    }
    public class Order : IComparable
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
            return "订单号："+ID+" 客户名："+Customer+" 总金额："+Cost+" 订单详情：\n"+Details;
        }
    }

    public class OrderDetails
    {
        //key表示商品，value表示商品数量
        public Dictionary<Commodity, int> CommodityNum { get; set; }

        public OrderDetails(Dictionary<Commodity, int> n)
        {
            CommodityNum = n;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   EqualityComparer<Dictionary<Commodity, int>>.Default.Equals(CommodityNum, details.CommodityNum);
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
        public bool AddOrder(string customer, Dictionary<Commodity, int> myCommodity)
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
            Orders.Add(new Order(orderNum, customer,cost,myCommodity));
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderService service = new OrderService();
            //模拟购物1
            Dictionary<Commodity, int> customer_1 = new Dictionary<Commodity, int>() 
            { { OrderService.banana, 3 }, { OrderService.apple, 10 } };
            service.AddOrder("David", customer_1);
            //模拟购物2
            Dictionary<Commodity, int> customer_2 = new Dictionary<Commodity, int>() 
            { { OrderService.apple, 5 }, { OrderService.bird, 1 }, { OrderService.bottle, 10 } };
            service.AddOrder("Caul", customer_2);
            //模拟购物3
            Dictionary<Commodity, int> customer_3 = new Dictionary<Commodity, int>()
            { {OrderService.banana,1},{OrderService.apple,1},{OrderService.bird,1},{OrderService.bottle,1}};
            service.AddOrder("kkk", customer_3);
            //模拟购物4
            Dictionary<Commodity, int> customer_4 = new Dictionary<Commodity, int>()
            { {OrderService.banana,5},{OrderService.apple,5},{OrderService.bird,3},{OrderService.bottle,1}};
            service.AddOrder("David", customer_4);

            //根据订单号查询(已重写toString())
            Console.WriteLine("根据订单号0查询：");
            service.Display(service.FindByID(0));

            //根据客户名查询(已重写toString())
            Console.WriteLine("根据客户名David查询：");
            service.Display(service.FindByCustomer("David"));

            //根据商品名查询(已重写toString())
            Console.WriteLine("根据商品名banana查询：");
            service.Display(service.FindByCommodity("banana"));

            //根据订单金额查询(已重写toString())
            Console.WriteLine("根据订单金额451查询：");
            service.Display(service.FindByCost(451));

            //修改订单客户名
            try
            {
                service.ModifyOrder(0, "Caul");
            }
            catch (OrderNumException e)
            {
                Console.WriteLine("修改失败  "+e.Message);
            }

            //删除订单
            try
            {
                service.DeleteOrder(3);
            }
            catch (OrderNumException e)
            {

                Console.WriteLine("删除失败  " + e.Message);
            }

            //排序订单
            service.SortOrder((p1, p2) => p1.Cost - p2.Cost);
            Console.WriteLine("按照cost排序如下：");
            service.Display(service.Orders);
        }
    }
}
