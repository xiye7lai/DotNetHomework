using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;


namespace HomeWork_11_1
{

    public class Commodity
    {
        [Key]
        public int CommodityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [ForeignKey("OrderDetailsId")]
        public int OrderDetailsId { get; set; }
        public OrderDetails OrderDetails { get; set; }

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
        public Order()
        {
            OrderId = 0;
            Customer = "";
            Cost = 0;
        }
        public Order( string customer, Dictionary<Commodity, int> commodity)
        { 
            Customer = customer;
            int cost = 0;
            Details = new List<OrderDetails>();
            foreach (var item in commodity)
            {
                cost += (item.Key.Price * item.Value);
                OrderDetails d1 = new OrderDetails(item.Key, item.Value);
                Details.Add(d1);
            }
            Cost = cost;
        }

        [Key, Column(Order = 1)]
        public int OrderId { get ; set ; }
        [Required]
        public string Customer { get ; set; }
        [Required]
        public int Cost { get; set ; }
        public List<OrderDetails> Details { get; set ; }

        public int CompareTo(object obj)
        {
            Order order = obj as Order;
            if (order == null) throw new System.ArgumentNullException();
            return OrderId.CompareTo(order.OrderId);
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   OrderId == order.OrderId &&
                   Customer == order.Customer &&
                   Cost == order.Cost;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OrderId, Customer, Cost);
        }

        public override string ToString()
        {
            return "订单号：" + OrderId + " 客户名：" + Customer + " 总金额：" + Cost + " 订单详情：\n" + Details;
        }
    }

    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }
        [Required]
        public int Num { get; set; }
        public Commodity Commodity { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public OrderDetails()
        {
            Num = 0;
        }

        public OrderDetails(Commodity c,int n)
        {
            Commodity = c;
            Num = n;
        }

        public override string ToString()
        {
            string s = "";
            s += Commodity.Name + " 购买数量：" + Num + "\n";
            return s;
        }
    }


}
