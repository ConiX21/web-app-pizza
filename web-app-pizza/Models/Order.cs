using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_app_pizza.Models
{
    public class Order
    {
        public int IDOrder { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public decimal TotalOrder { get; set; }
        public IEnumerable<OrderLine> OrderLines { get; set; }

        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
        }
    }
}