using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Newtonsoft.Json;

namespace web_app_pizza.Models
{
    public class PizzaCartRepository : IRepository<PizzaCart>
    {

        public void AddPizzaSessionCart(PizzaCart pizzaCart)
        {
            var pizzasJson = String.Empty;
            var PizzasCartSession = new List<PizzaCart>();

            try
            {
                PizzasCartSession = this.Read();
                var PizzaCartSession = PizzasCartSession.Find(pcs => pcs.Pizza.IDPizza == pizzaCart.Pizza.IDPizza);

                if(PizzaCartSession != null)
                {
                    PizzaCartSession.Quantity++;
                }
                else
                {
                    PizzasCartSession.Add(pizzaCart);
                }


                pizzasJson = JsonConvert.SerializeObject(PizzasCartSession);
            }
            catch (Exception ex)
            {
                pizzasJson = JsonConvert.SerializeObject(new List<PizzaCart> {
                      pizzaCart
                } );

            }

            HttpContext.Current.Session.Add("Pizzas", pizzasJson);
        }

        public List<PizzaCart> Read()
        {
            List<PizzaCart> PizzasCart = null;

            try
            {
                PizzasCart = JsonConvert.DeserializeObject<List<PizzaCart>>((string)HttpContext.Current.Session["Pizzas"]);
            }
            catch (Exception ex)
            {
                PizzasCart = new List<PizzaCart>();
            }

            return PizzasCart;
        }

        public List<PizzaCart> Read(Func<PizzaCart, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public PizzaCart Read(int id)
        {
            var query = JsonConvert.DeserializeObject<List<PizzaCart>>((string)HttpContext.Current.Session["Pizzas"]);
            
            return query.Find(p => p.Pizza.IDPizza == id);
        }
    }
}