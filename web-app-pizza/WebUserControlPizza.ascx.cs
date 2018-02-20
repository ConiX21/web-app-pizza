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
    public partial class WebUserControlPizza : System.Web.UI.UserControl
    {
        //public delegate void EventHandler(object sender, EventArgs e);

        public event System.EventHandler EventArgButton;

        public Pizza Pizza { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
    }
}