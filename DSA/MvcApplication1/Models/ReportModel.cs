using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class ReportModel
    {
        //public int accid { get; set; }
        //public int acctypeid { get; set; }
        //public string accfriendlyname { get; set; }
        //public decimal balance { get; set; }
        //public int currencyID { get; set; }

        public AccountsReference.Account accc { get; set; }

        public List<AccountsReference.Transaction> transactionlist { get; set; }

        public ReportModel(List<AccountsReference.Transaction> acclist, AccountsReference.Account acc)
        {
            transactionlist = acclist;
            //AccountsReference.Account acc = new AccountsReference.AccountsServiceClient().getAccountByID(accid);

            accc = acc;

            //accid = acc.AccountID;
            //acctypeid = (int)acc.AccountTypeID;
            //accfriendlyname = acc.AccountFriendlyName;
            //balance = (decimal)acc.Balance;
            //currencyID = (int)acc.CurrencyID;

        }
    }
}