using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataAccess;
using Common;

namespace BusinessLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UsersService" in code, svc and config file together.
    public class UsersService : IUsersService
    {
        public bool Login(string username, string encrypedcode)
        {
            return new UserRepository().Login(username, encrypedcode);
        }

        public User GetUser(string username)
        {
            return new UserRepository().GetUser(username);
        }
        public IEnumerable<UserRole> GetRoleByUsername(string username)
        {
            return new UserRepository().GetRoleByUsername(username);
        }

        public User GetUserByID(int id)
        {
            return new UserRepository().GetUserByID(id);
        }
    }
}
