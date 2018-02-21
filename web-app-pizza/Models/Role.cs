using System.Collections.Generic;

namespace web_app_pizza.Models
{
    public class Role
    {
        public string RoleName { get; set; }
        public List<User> Users { get; set; }

        public Role()
        {
            Users = new List<User>();
        }
    }
}