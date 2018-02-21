﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using web_app_pizza.Models;

namespace web_app_pizza
{
    public class Global : System.Web.HttpApplication
    {
        public static List<Pizza> CollectionPizzas { get; set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            

            PizzaModule p = new PizzaModule();
            Global.CollectionPizzas = new List<Pizza>()
            {
                new Pizza()
                {
                    IDPizza = 1,
                    Description = "Sauce tomate, jambon, champignon, fromage",
                    Name = "Reine",
                    Price = 10.20m,
                    Image = "images/pizza_1.jpg"
                },
                 new Pizza()
                {
                    IDPizza = 2,
                    Description = "Sauce tomate, jambon, champignon, viande, fromage",
                    Name = "Cannibale",
                    Price = 12,
                    Image = "images/pizza_3.jpg"
                }, new Pizza()
                {
                    IDPizza = 3,
                    Description = "Sauce tomate, jambon, champignon, fromage, bleu, chèvre, mozza",
                    Name = "4 Fromages",
                    Price = 10.20m,
                    Image = "images/pizza_2.jpg"
                }
            };
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["culture"] = "fr-FR";
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}