using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.UserReference;

namespace MvcApplication1.Models
{
    public class displayAccountModel
    {
        /*
        public int AccountID { get; set; }
        public string AccountFriendlyName { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public string Currency { get; set; }
        public DateTime Renewal { get; set; }
        */

        public IEnumerable<AccountsReference.Account> accountlist { get; set; }
        //list ta account by dak il user

        public displayAccountModel(string username)
        {
            User userid = new MvcApplication1.UserReference.UsersServiceClient().GetUser(username);
            accountlist = new MvcApplication1.AccountsReference.AccountsServiceClient().getAccountsByUserID(userid.UserID);

        }

    }
}