using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_app_pizza.Models
{
    public class Clients_Roles
    {
        public Client Client { get; set; }
        public string Role { get; set; }
        public Clients_Roles(Client client, string role)
        {
            Client = client;
            Role = role;
        }
    }
}