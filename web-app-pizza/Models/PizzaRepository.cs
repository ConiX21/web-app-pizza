using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_app_pizza.Models
{
    public class PizzaRepository : IRepository<Pizza>
    {

        public PizzaRepository()
        {

        }

        public List<Pizza> Read()
        {
            return Global.CollectionPizzas;
        }

        public List<Pizza> Read(Func<Pizza, bool> predicate)
        {
            return Global.CollectionPizzas.Where(predicate).ToList() ;
        }

        public Pizza Read(int id)
        {
            return Global.CollectionPizzas.Find(p => p.IDPizza == id);
        }
    }
}