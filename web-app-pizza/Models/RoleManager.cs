using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace web_app_pizza.Models
{
    public class RoleManager : RoleProvider
    {
        public override string ApplicationName { get; set; }
       

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public void AddUserToRoles(string username, string[] roleNames)
        {
            var client = Global.Clients.Single(u => u.UserName == username);

            if (client != null)
            {
                foreach (var role in roleNames)
                {
                    Global.Clients_Roles.Add(new Clients_Roles(client, role));
                }

            }
        }


        public override void CreateRole(string roleName)
        {
            if (!RoleExists(roleName))
                Global.Roles.Add(roleName);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            var query = from client in Global.Clients.Cast<Client>()
                        join client_role in Global.Clients_Roles on client.IDClient equals client_role.Client.IDClient
                        where client_role.Role == roleName && usernameToMatch == client.UserName
                        select client.UserName ;

            return query.ToArray();
        }

        public override string[] GetAllRoles()
        {
            return Global.Roles.ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {

            var query = from client_role in Global.Clients_Roles
                        where client_role.Client.UserName == username
                        select client_role.Role;

          
            return query.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var query = from client_role in Global.Clients_Roles
                        where client_role.Client.UserName == username && client_role.Role == roleName
                        select client_role;

            return (query.Count() > 0) ? true : false;
                       
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            return Global.Roles.Exists(s => s == roleName);
        }
    }
}