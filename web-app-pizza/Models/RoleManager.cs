using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace web_app_pizza.Models
{
    public class RoleManager : RoleProvider
    {
        private pizzaDBEntities _Context { get; set; }
        public RoleManager()
        {
            _Context = new pizzaDBEntities();
        }

        public override string ApplicationName { get; set; }


        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public void AddUserToRoles(string username, string[] roleNames)
        {
            var client = _Context.Client.First(u => u.UserName == username);

            if (client != null)
            {
                foreach (var role in roleNames)
                {
                    _Context.Clients_Roles.Add(new Clients_Roles()
                    {
                        IdClient_Roles = Guid.NewGuid(),
                        Client = client,
                        RoleName = role
                    });

                }
                _Context.SaveChanges();
            }
        }


        public override void CreateRole(string roleName)
        {
            if (!RoleExists(roleName))
            {

                var r = new Role() { IdRole = Guid.NewGuid(), RoleName = roleName };
                _Context.Role.Add(r);
                _Context.SaveChanges();
            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            var query = from client in _Context.Client
                        join client_role in _Context.Clients_Roles on client.IDClient equals client_role.Client.IDClient
                        where client_role.RoleName == roleName && usernameToMatch == client.UserName
                        select client.UserName;

            return query.ToArray();
        }

        public override string[] GetAllRoles()
        {
            return _Context.Role.Select(r => r.RoleName).ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {

            var query = from client_role in _Context.Clients_Roles
                        where client_role.Client.UserName == username
                        select client_role.RoleName;

            return query.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var query = from client_role in _Context.Clients_Roles
                        where client_role.Client.UserName == username && client_role.RoleName == roleName
                        select client_role;

            return (query.Count() > 0) ? true : false;

        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            bool result;
            try
            {
                result = _Context.Role.First(r => r.RoleName == roleName) != null;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}