using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;

namespace BusinessLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsersService" in both code and config file together.
    [ServiceContract]
    public interface IUsersService
    {
        [OperationContract]
        bool Login(string username, string encryptedcode);

        [OperationContract]
        User GetUser(string username);

        [OperationContract]
        IEnumerable<UserRole> GetRoleByUsername(string username);

        [OperationContract]
        User GetUserByID(int id);

    }
}
