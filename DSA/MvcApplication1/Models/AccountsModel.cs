using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.AccountsReference;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public class AccountsModel
    {
        public Account DisplayAccount { get; set; }
        public string AccountName { get; set; }
        public SelectList FromAccount { get; set; }
        public SelectList Currency { get; set; }
        public decimal ammount { get; set; }
        public SelectList AccountType { get; set; }
        public SelectList Duration { get; set; }
        public DateTime Renewal { get; set; }

        public string token { get; set; }

        public int selectedListAccount { get; set; }
        public int selectedListCurrency { get; set; }
        public int selectedListType { get; set; }
        public int selectedListDuration { get; set; }

        public AccountsModel()
        {

        }

        public AccountsModel(string username)
            : this()
        {
            FromAccount = new SelectList(new AccountsReference.AccountsServiceClient().getAccountByUsername(username), "AccountID", "AccountFriendlyName");
            Currency = new SelectList(new AccountsReference.AccountsServiceClient().GetCurrency(), "CurrencyID", "Currency1");
            AccountType = new SelectList(new AccountsReference.AccountsServiceClient().GetAccountType(), "AccountTypeID", "AccountType1");
            Duration = new SelectList(new AccountsReference.AccountsServiceClient().GetFixedRates(), "FixedRateID", "FixedRate1");
        }

    }
}