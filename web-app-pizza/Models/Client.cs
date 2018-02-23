using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Security;


namespace web_app_pizza.Models
{
    //[Table]
    public class Client
    {
        private string _username;
        
        public Guid IDClient = Guid.Empty;
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public bool IsOnline { get; set; }

        public IEnumerable<Clients_Roles> Users_Roles { get; set; }

        private  Client()
        {
            Users_Roles = new HashSet<Clients_Roles>();
        }

        public Client(string username, string password) : this()
        {
            _username = username;
            Password = password;
        }
    }
}