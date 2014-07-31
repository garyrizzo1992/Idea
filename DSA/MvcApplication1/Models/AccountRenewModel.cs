using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public class AccountRenewModel
    {
        public int AccountID {get;set;} 
        public string AccountFriendlyName { get; set; }
        public decimal Balance { get; set; }

        public SelectList DestinationAccount { get; set; }

        public SelectList Duration { get; set; }

        public int selectedDestinationAccount { get; set; }

        public int selectedDuration { get; set; }

        public AccountRenewModel(string username)
        {
            DestinationAccount = new SelectList(new AccountsReference.AccountsServiceClient().GetNotFixedAccounts(username), "AccountID", "AccountFriendlyName");
            Duration = new SelectList(new AccountsReference.AccountsServiceClient().GetFixedRates(), "FixedRateID", "Duration");
        }

        public AccountRenewModel()
        {
        }
    }
}