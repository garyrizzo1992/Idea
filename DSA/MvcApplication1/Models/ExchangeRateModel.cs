using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public class ExchangeRateModel
    {
        public SelectList SelectedSourceCurrency { get; set; }
        public SelectList SelectedDestinationCurrency { get; set; }
        public double ammount { get; set; }
        public double total { get; set; }

        public int SourceCurrency { get; set; }
        public int DestinationCurrency { get; set; }


        public ExchangeRateModel()
        {
            SelectedDestinationCurrency = new SelectList(new AccountsReference.AccountsServiceClient().GetCurrency(), "CurrencyID", "Currency1");
            SelectedSourceCurrency = new SelectList(new AccountsReference.AccountsServiceClient().GetCurrency(), "CurrencyID", "Currency1");


        }
    }
}