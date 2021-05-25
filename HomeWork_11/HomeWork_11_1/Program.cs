using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HomeWork_11_1
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
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

            //根据订单号查询
            Console.WriteLine("根据订单号0查询：");
            service.Display(service.FindByID(1));

            //根据客户名查询
            Console.WriteLine("根据客户名David查询：");
            service.Display(service.FindByCustomer("David"));

            //根据订单金额查询
            Console.WriteLine("根据订单金额451查询：");
            service.Display(service.FindByCost(451));

            //修改订单客户名
            service.ModifyOrder(1, "Caul");
           
            //删除订单
            service.DeleteOrder(2);
        }
    }

}
