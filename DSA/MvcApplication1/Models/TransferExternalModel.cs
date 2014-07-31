using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public class TransferExternalModel
    {
       public decimal ammount { get; set; }
        public SelectList FromAccount { get; set; }
        public SelectList ToAccount { get; set; }
        public string token { get; set; }

        public int accountid { get; set; }

        public int selectedListFromAccount { get; set; }
        public int selectedListToAccount { get; set; }
     

        public TransferExternalModel()
           
        {
            FromAccount = new SelectList(new AccountsReference.AccountsServiceClient().getAccountsNotFixed(), "AccountID", "AccountFriendlyName");
            ToAccount = new SelectList(new AccountsReference.AccountsServiceClient().getAccountsNotFixed(), "AccountID", "AccountFriendlyName");
        }
    }
}