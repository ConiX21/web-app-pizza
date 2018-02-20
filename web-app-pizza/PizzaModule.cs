using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;  
using Ninject;
using web_app_pizza.Models;

namespace web_app_pizza
{
    public class PizzaModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Pizza>>().To<PizzaRepository>();
        }
    }
}

