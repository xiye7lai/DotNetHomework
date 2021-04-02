using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeWork_6_1;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_6_1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddOrderTest()
        {
            OrderService service = new OrderService();
            XmlDictionary<Commodity, int> customer_1 = new XmlDictionary<Commodity, int>()
            { { OrderService.banana, 3 }, { OrderService.apple, 10 } };
            service.AddOrder("David", customer_1);
            Order order = new Order(0, "David", 230, customer_1);
            List<Order> result = new List<Order>();
            result.Add(order);
            CollectionAssert.AreEqual(result, service.Orders);
        }

        [TestMethod()]
        [ExpectedException(typeof(OrderNumException))]
        public void DeleteOrderTest()
        {
            OrderService service = new OrderService();
            service.DeleteOrder(1);
        }

        [TestMethod()]
        [ExpectedException(typeof(OrderNumException))]
        public void ModifyOrderTest()
        {
            OrderService service = new OrderService();
            service.ModifyOrder(-1, "David");
        }

        [TestMethod()]
        public void FindByIDTest()
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

            Order order = new Order(4, "David", 451, customer_4);
            List<Order> result = new List<Order>();
            result.Add(order);
            service.Display(result);
            service.Display(service.FindByID(3));
            CollectionAssert.AreEqual(result, service.FindByID(4));
        }

        [TestMethod()]
        public void FindByCustomerTest()
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

            Order order1 = new Order(5, "David", 230, customer_1);
            Order order2 = new Order(8, "David", 451, customer_4);
            List<Order> result = new List<Order>();
            result.Add(order1);
            result.Add(order2);
            service.Display(service.FindByCustomer("David"));
            CollectionAssert.AreEqual(result, service.FindByCustomer("David"));
        }

        [TestMethod()]
        public void FindByCostTest()
        {
            OrderService service = new OrderService();
            //模拟购物1
            XmlDictionary<Commodity, int> customer_1 = new XmlDictionary<Commodity, int>()
            { { OrderService.banana, 3 }, { OrderService.apple, 10 } };
            service.AddOrder("David", customer_1);
            List<Order> target = service.FindByCost(230);

            Order order = new Order(9, "David", 230, customer_1);
            List<Order> result = new List<Order>();
            result.Add(order);
            service.Display(target);
            CollectionAssert.AreEqual(result, target);
        }

    }
}