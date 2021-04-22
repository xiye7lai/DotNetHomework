using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HomeWork_8_1
{
    public partial class 订单管理系统 : Form
    {
        private OrderService service;
        public OrderService Service { set => service = value; get => service; }
        public 订单管理系统()
        {
            InitializeComponent();
            Service = new OrderService();
            XmlDictionary<Commodity, int> myCommodity1 = new XmlDictionary<Commodity, int>() { { OrderService.banana,10},{ OrderService.apple,10} ,{ OrderService.bird,1},{ OrderService.bottle,1} };
            XmlDictionary<Commodity, int> myCommodity2 = new XmlDictionary<Commodity, int>() { { OrderService.banana, 1 }, { OrderService.apple, 1 }, { OrderService.bird, 1 }, { OrderService.bottle, 1 } };
            service.AddOrder("小明", myCommodity1);
            service.AddOrder("Kane", myCommodity2);
            OrderbindingSource.DataSource = Service.Orders;
        }

        //使用输入关键字即可查询
        private void button1_Click(object sender, EventArgs e)
        {

            OrderbindingSource.DataSource = Service.Orders.Where(s => s.Customer.Contains(textBox1.Text));
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Form2 addForm = new Form2(ref service, false);
            addForm.ShowDialog();
            OrderbindingSource.ResetBindings(false);
        }

        private void Delte_Click(object sender, EventArgs e)
        {
            if(OrderbindingSource.Current==null)
            {
                MessageBox.Show("请选择要删除的订单！");
                return;
            }
            if (MessageBox.Show("确定要删除该订单吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                service.DeleteOrder(((Order)OrderbindingSource.Current).ID);

            }
            OrderbindingSource.ResetBindings(false);
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            if (OrderbindingSource.Current == null)
            {
                MessageBox.Show("请选择要修改的订单！");
                return;
            }
            Dictionary<Commodity, int> myCommodity= ((Order)OrderbindingSource.Current).Details.CommodityNum;
            Form2 modifyForm = new Form2(ref service, true,
                ((Order)OrderbindingSource.Current).ID, 
                ((Order)OrderbindingSource.Current).Customer,
                myCommodity[OrderService.apple],myCommodity[OrderService.banana],myCommodity[OrderService.bottle],myCommodity[OrderService.bird]);
            modifyForm.ShowDialog();
            OrderbindingSource.ResetBindings(false);
        }

        private void export_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));
                using (System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile())
                {
                    xmlSerializer.Serialize(fs, service.Orders.ToArray());
                }
                MessageBox.Show("导出成功！");
            }
        }

        private void import_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));
                using (System.IO.FileStream fs=(System.IO.FileStream)openFileDialog1.OpenFile())
                {
                    Order[] orders = (Order[])xmlSerializer.Deserialize(fs);
                    Array.ForEach(orders, p => service.Orders.Add(p));
                }
                MessageBox.Show("导入成功！");
            }
            OrderbindingSource.ResetBindings(false);
        }
    }
}
