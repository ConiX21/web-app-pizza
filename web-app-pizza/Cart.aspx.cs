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

        protected override void OnLoadComplete(EventArgs e)
        {

            TotalPrice.Text = String.Format("{0:c2}",((PizzaCartRepository)PizzaCartRepository).ComputePrice());
        }

        protected void PizzaCartRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Button commandButton = ((Button)e.CommandSource);
            var id = Convert.ToInt32(e.CommandArgument);

            switch (commandButton.ID)
            {
                case "ButtonPlus":
                    ((PizzaCartRepository)PizzaCartRepository).UpQuantity(id);
                    break;
                case "ButtonMinus":
                    ((PizzaCartRepository)PizzaCartRepository).DownQuantity(id);
                    break;
                case "ButtonRemove":
                    ((PizzaCartRepository)PizzaCartRepository).RemovePizzaCart(id);
                    break;
            }

            PizzaCartRepeater.DataSource = PizzaCartRepository.Read();
            PizzaCartRepeater.DataBind();

        }

        protected void PizzaCartRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}