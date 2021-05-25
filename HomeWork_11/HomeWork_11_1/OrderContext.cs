using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11_1
{

  public class OrderContext : DbContext
    {
    public OrderContext() : base("OrderDataBase") {
      Database.SetInitializer(
        new DropCreateDatabaseIfModelChanges<OrderContext>());
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> Details { get; set; }
    public DbSet<Commodity> Commodities { get; set; }

  }
}
