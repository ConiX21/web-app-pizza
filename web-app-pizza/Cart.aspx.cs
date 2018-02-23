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
        private List<PizzaCart> _CartPizzas { get; set; }

        public ClientProvider UserProvider { get; set; }
        public Cart()
        {
            PizzaCartRepository = new PizzaCartRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _CartPizzas = PizzaCartRepository.Read();


            if (!IsPostBack)
            {

                PizzaCartRepeater.DataSource = _CartPizzas;
                PizzaCartRepeater.DataBind();
            }


        }

        protected override void OnLoadComplete(EventArgs e)
        {

            TotalPrice.Text = String.Format("{0:c2}", ((PizzaCartRepository)PizzaCartRepository).ComputePrice());
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

            _CartPizzas = PizzaCartRepository.Read();

            PizzaCartRepeater.DataSource = _CartPizzas;
            PizzaCartRepeater.DataBind();

        }

        protected void PizzaCartRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }


        protected override void OnPreRender(EventArgs e)
        {

            if (_CartPizzas.Count() > 0)
            {
                checkout.Enabled = true;
            }
            else
            {
                checkout.Enabled = false;
            }

            base.OnPreRender(e);


        }

        protected void checkout_Click(object sender, EventArgs e)
        {
            Response.Redirect("validationOrder.aspx");
        }
    }
}