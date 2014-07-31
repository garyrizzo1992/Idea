using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.AccountsReference;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public class TransferModel
    {
        public decimal ammount { get; set; }
        public SelectList FromAccount { get; set; }
        public SelectList ToAccount { get; set; }
        public string token { get; set; }
       

        public int selectedListFromAccount { get; set; }
        public int selectedListToAccount { get; set; }
     

        public TransferModel()
        {

        }

        public TransferModel(string username)
            : this()
        {
            FromAccount = new SelectList(new AccountsReference.AccountsServiceClient().getAccountsByUsernameAndNotFixed(username), "AccountID", "AccountFriendlyName");
            ToAccount = new SelectList(new AccountsReference.AccountsServiceClient().getAccountsByUsernameAndNotFixed(username), "AccountID", "AccountFriendlyName");
        }

    }
}