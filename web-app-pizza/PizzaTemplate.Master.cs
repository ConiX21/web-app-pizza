using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_app_pizza
{
    public partial class PizzaTemplate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }


        protected override void OnInit(EventArgs e)
        {
            //base.OnInit(e);
            //var ci = Session["culture"].ToString();
            //Thread.CurrentThread.CurrentCulture = new CultureInfo(ci);
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(ci);
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Session["culture"] = "en-US";
        }
    }
}