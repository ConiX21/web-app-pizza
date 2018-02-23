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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var c = Global.Clients;
        }

        protected override void InitializeCulture()
        {
            var ci = Session["culture"].ToString();
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ci);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(ci);
            base.InitializeCulture();
        }


    }
}