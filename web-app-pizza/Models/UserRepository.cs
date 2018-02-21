using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_app_pizza.Models
{
    public class UserRepository : IRepository<User>
    {
        public User Add(User user)
        {
            Global.Users.Add(user);
            return user;
        }

        public List<User> Read()
        {
            throw new NotImplementedException();
        }

        public List<User> Read(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public User Read(int id)
        {
            throw new NotImplementedException();

        }

        public bool Authenticate(string text1, string text2)
        {
           
            if (Global.Users.Find(u => u.Login == text1 && u.Password == text2) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}