using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_app_pizza.Models;

namespace web_app_pizza
{
    public partial class Detail : System.Web.UI.Page
    {
        public Pizza Pizza { get; set; }
        public IRepository<Pizza> PizzaRepository { get; set; }


        public Detail()
        {
            PizzaRepository = new PizzaRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);
            Pizza = PizzaRepository.Read(id);
        }
    }
}