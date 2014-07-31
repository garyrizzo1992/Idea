using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class TransactionModel
    {
        public int TransactionID { get; set; }
        public decimal Ammount { get; set; }
        public string Currency { get; set; }
        public int FromAccountID { get; set; }
        public int ToAccountID { get; set; }
        public string Date { get; set; }
        public string TransactionType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate {get;set;}


        //IEnumerable<AccountsReference.Transaction> acclist { get; set; }

        
        //public TransactionModel(int accID)
        //{
        //    acclist = new AccountsReference.AccountsServiceClient().GetTransactionByAccountID(accID);
        //}

    }
}