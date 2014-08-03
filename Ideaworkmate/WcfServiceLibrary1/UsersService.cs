using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;
using DataAccess;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UsersService" in both code and config file together.
    public class UsersService : IUsersService
    {
        public void DoWork()
        {

        }
        public IEnumerable<User> Getusers()
        {
            return new UserRepository().Getusers();
        }
    }
}
