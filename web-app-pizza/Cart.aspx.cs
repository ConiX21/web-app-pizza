using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_app_pizza.Models;

namespace web_app_pizza
{
    public partial class Cart : System.Web.UI.Page
    {
        public IRepository<PizzaCart> PizzaCartRepository { get; set; }

        public Cart()
        {
            PizzaCartRepository = new PizzaCartRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PizzaCartRepeater.DataSource = PizzaCartRepository.Read();
                PizzaCartRepeater.DataBind();
            }

        }

        protected void PizzaCartRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Button commandButton = ((Button)e.CommandSource);

            switch(commandButton.ID)
            {
                case "ButtonPlus":
                    IncrementQuantity();
                    break;
                case "ButtonMinus":
                    DecrementQuantity();
                    break;
            }

            PizzaCartRepeater.DataSource = PizzaCartRepository.Read();
            PizzaCartRepeater.DataBind();

        }


        public void IncrementQuantity()
        {
            Debug.WriteLine("Increment");
        }
        public void DecrementQuantity()
        {
            Debug.WriteLine("Decrement");

        }

    }
}