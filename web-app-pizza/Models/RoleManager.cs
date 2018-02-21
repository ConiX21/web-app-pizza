using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace web_app_pizza.Models
{
    public class RoleManager : RoleProvider
    {
        public override string ApplicationName { get ; set; }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            //var roleHasUser = Global.Roles.Find(r => r.RoleName == roleName).Users.Find(u => u.Login == username);


            //if (roleHasUser != null)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            return new string[] {"Admin"};
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var roleHasUser = Global.Roles.Find(r => r.RoleName == roleName).Users.Find(u => u.Login == username);


            if (roleHasUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}