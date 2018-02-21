using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_app_pizza.Models;
using Newtonsoft.Json;

namespace web_app_pizza
{
    public partial class Pizzas : System.Web.UI.Page
    {
        public IRepository<Pizza> PizzaRepository { get; set; }
        public IRepository<PizzaCart> PizzaCartRepository { get; set; }

        public Pizzas()
        {
            PizzaRepository = new PizzaRepository();
            PizzaCartRepository = new PizzaCartRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                RepeaterPizzas.DataSource = PizzaRepository.Read();
                RepeaterPizzas.DataBind();
            }
        }

        protected void RepeaterPizzas_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Button aspButton = (Button)e.CommandSource;
            Button aspButton2 = e.CommandSource as Button;
            var idPizza = Convert.ToInt32(e.CommandArgument);
            var Pizza = PizzaRepository.Read(idPizza);

            ((PizzaCartRepository)PizzaCartRepository).Add(new PizzaCart(){ Pizza = Pizza});

        }

    }

}