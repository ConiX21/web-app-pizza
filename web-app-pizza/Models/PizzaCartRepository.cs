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

        public PizzaCart Add(PizzaCart pizzaCart)
        {
            var pizzasJson = String.Empty;
            var PizzasCartSession = new List<PizzaCart>();

            try
            {
                PizzasCartSession = this.Read();
                var PizzaCartSession = PizzasCartSession.Find(pcs => pcs.Pizza.IDPizza == pizzaCart.Pizza.IDPizza);

                if (PizzaCartSession != null)
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
                });

            }

            HttpContext.Current.Session.Add("Pizzas", pizzasJson);
            return pizzaCart;
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

        public void UpQuantity(int id)
        {
            var pizzasJson = String.Empty;
            var PizzasCartSession = new List<PizzaCart>();

            PizzasCartSession = this.Read();
            var PizzaCartSession = PizzasCartSession.Find(pcs => pcs.Pizza.IDPizza == id);

            PizzaCartSession.Quantity++;

            pizzasJson = JsonConvert.SerializeObject(PizzasCartSession);

            HttpContext.Current.Session.Add("Pizzas", pizzasJson);
        }

        public void DownQuantity(int id)
        {
            var pizzasJson = String.Empty;
            var PizzasCartSession = new List<PizzaCart>();

            PizzasCartSession = this.Read();
            var PizzaCartSession = PizzasCartSession.Find(pcs => pcs.Pizza.IDPizza == id);

            if (PizzaCartSession.Quantity == 1)
            {
                PizzasCartSession.Remove(PizzaCartSession);
            }
            else
            {
                PizzaCartSession.Quantity--;
            }


            pizzasJson = JsonConvert.SerializeObject(PizzasCartSession);

            HttpContext.Current.Session.Add("Pizzas", pizzasJson);
        }

        public void RemovePizzaCart(int id)
        {
            var PizzasCartSession = new List<PizzaCart>();
            PizzasCartSession = this.Read();

            var PizzaCartSession = PizzasCartSession.Find(pcs => pcs.Pizza.IDPizza == id);
            PizzasCartSession.Remove(PizzaCartSession);

            var pizzasJson = JsonConvert.SerializeObject(PizzasCartSession);
            HttpContext.Current.Session.Add("Pizzas", pizzasJson);

        }

        public decimal ComputePrice()
        {
            decimal total;
            List<PizzaCart> PizzasCartSession;
            try
            {

                PizzasCartSession = this.Read();
                if (PizzasCartSession == null)
                    throw new Exception();

                total = PizzasCartSession.Sum(pc => pc.TotalRow());
            }
            catch (Exception)
            {
                total = 0.0m;
            }


            return total;
        }

    }
}