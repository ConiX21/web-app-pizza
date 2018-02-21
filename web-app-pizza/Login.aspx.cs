using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_app_pizza.Models;

namespace web_app_pizza
{
    public partial class Login : System.Web.UI.Page
    {
        public UserRepository UserRepository { get; set; }
        public Login()
        {
            UserRepository = new UserRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Page.Validate();

            if (!Page.IsValid) return;

            //if (Login1..Authenticate(Login1.UserName, Login1.Password))
            //{
            //    Response.Redirect("cart.aspx");
            //}
            //else {
            //    LegendStatus.Text = "Invalid username or password!";
            //}
        }

       
    }

   
}