﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_app_pizza.Models;

namespace web_app_pizza
{
    public partial class AddPizza : System.Web.UI.Page
    {
        Pizza Pizza { get; set; }
        public IRepository<Pizza> PizzaRepository { get; set; }
        public AddPizza()
        {
            Pizza = new Pizza();
            PizzaRepository = new PizzaRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            FormView1.DefaultMode = FormViewMode.Insert;
            //if (IsPostBack && IsValid)
            //{
            //    PizzaRepository.Add(Pizza);
            //}
        }
    }
}