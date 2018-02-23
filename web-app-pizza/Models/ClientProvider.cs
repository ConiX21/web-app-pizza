using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;

namespace web_app_pizza.Models
{
    public class ClientProvider : MembershipProvider
    {

        private pizzaDBEntities _Context { get; set; }
        public ClientProvider()
        {
            _Context = new pizzaDBEntities();
        }

        public override bool EnablePasswordRetrieval => throw new NotImplementedException();

        public override bool EnablePasswordReset => throw new NotImplementedException();

        public override bool RequiresQuestionAndAnswer => throw new NotImplementedException();

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int MaxInvalidPasswordAttempts => throw new NotImplementedException();

        public override int PasswordAttemptWindow => throw new NotImplementedException();

        public override bool RequiresUniqueEmail => throw new NotImplementedException();

        public override MembershipPasswordFormat PasswordFormat => throw new NotImplementedException();

        public override int MinRequiredPasswordLength => throw new NotImplementedException();

        public override int MinRequiredNonAlphanumericCharacters => throw new NotImplementedException();

        public override string PasswordStrengthRegularExpression => throw new NotImplementedException();

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            //base.ChangePasswordQuestionAndAnswer(username, password, newPasswordQuestion, newPasswordAnswer);
            return true;
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }
        public MembershipUser CreateUserComplet(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            var client = new Client();
            MembershipUser ms = null; 

            if (GetUser(username, true) == null)
            {
                client.UserName = username;
                client.Password = password;
                client.Email = email;
                client.IDClient = Guid.NewGuid();
                status = MembershipCreateStatus.Success;

                _Context.Client.Add(client);
                ms = new MembershipUser(typeof(ClientProvider).Name, client.UserName, null, client.Email, null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
                _Context.SaveChanges();
            }
            else
            {
                status = MembershipCreateStatus.DuplicateUserName;
            }

            return ms;

        }


        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            totalRecords = _Context.Client.Count();
            var muc = new MembershipUserCollection();

            Action<Client> eachMember = delegate (Client c)
            {
                var ms = new MembershipUser(null, c.UserName, null, c.Email, null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
                muc.Add(ms);
            };

            Func<Client, bool> compare = (c) =>
            {
                return c.UserName.StartsWith(usernameToMatch, StringComparison.OrdinalIgnoreCase);
            };

            _Context.Client
                .Where(compare)
                .ToList()
                .ForEach(eachMember);


            return muc;

        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            totalRecords = _Context.Client.Count();
            var muc = new MembershipUserCollection();


            Action<Client> eachMember = delegate (Client c)
            {
                var ms = new MembershipUser(null, c.UserName, null, c.Email, null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
                muc.Add(ms);
            };

            _Context.Client.ToList().ForEach(eachMember);

            return muc;
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            MembershipUser ms = null;

            try
            {
                var c = _Context.Client.First(u => u.UserName == username && u.IsOnline == userIsOnline);
                ms = new MembershipUser(null, c.UserName, null, c.Email, null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);

            }
            catch (Exception)
            {
                
            }
            
            return ms;

        }

        public override string GetUserNameByEmail(string email)
        {
            return _Context.Client.First(u => u.Email == email).UserName;
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            if (_Context.Client.First(u => u.UserName == username && u.Password == password) != null)
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