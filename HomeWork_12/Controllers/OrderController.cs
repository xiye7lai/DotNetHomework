using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HomeWork_12.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        public static OrderService service=new OrderService();
        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
            // Dictionary<string, int> mystring1 = new Dictionary<string, int>() { { OrderService.banana.Name,10},{ OrderService.apple.Name,10} ,{ OrderService.bird.Name,1},{ OrderService.bottle.Name,1} };
            // Dictionary<string, int> mystring2 = new Dictionary<string, int>() { { OrderService.banana.Name, 1 }, { OrderService.apple.Name, 1 }, { OrderService.bird.Name, 1 }, { OrderService.bottle.Name, 1 } };
            // service.AddOrder("小明", mystring1);
            // service.AddOrder("Kane", mystring2);
            // string json = System.Text.Json.JsonSerializer.Serialize(service.Orders[1]);
            // Console.WriteLine(json);
        }

        [HttpGet]
        public ActionResult<List<Order>> GetOrder()
        {
            return service.Orders.Where(s => s.Customer.Contains("")).ToList<Order>();
        }
        [HttpGet("{id}")]
        public ActionResult<List<Order>> GetOrder(int id)
        {
            return service.FindByID(id);
        }
        [HttpGet("{customer}")]
        public ActionResult<List<Order>> GetOrder(string customer)
        {
            return service.FindByCustomer(customer);
        }
        [HttpPost]
        public ActionResult<Order> PostOrder(string json)
        {
            try{
            Order s=JsonSerializer.Deserialize<Order>(json);
            service.Orders.Add(s);
            return s;
            }catch(Exception e){
                return BadRequest(e.InnerException.Message);
            }
        }
        [HttpPut("{customer}")]
        public ActionResult<Order> PutOrder(string customer,string json){
            try{
            Order s=JsonSerializer.Deserialize<Order>(json);
            service.ModifyOrder(s.ID,customer);
            return s;
            }catch(Exception e){
                return BadRequest(e.InnerException.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<List<Order>> DeleteOrder(int id){
            try{
            service.DeleteOrder(id);
            return service.Orders;
            }catch(Exception e){
                return BadRequest(e.InnerException.Message);
            }
        }
    }
}
