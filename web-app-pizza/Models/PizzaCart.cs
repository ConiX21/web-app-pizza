using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_app_pizza.Models
{
    public class PizzaCart
    {
        public Pizza Pizza { get; set; }
        public int Quantity { get; set; }
        public PizzaCart()
        {
            Quantity = 1;
        }

        public decimal TotalRow()
        {
            return Pizza.Price * Quantity;
        }

    }
}