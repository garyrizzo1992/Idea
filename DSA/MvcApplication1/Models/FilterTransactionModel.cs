using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class FilterTransactionModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

      
        public int accid { get; set; }

        public FilterTransactionModel(int myAccID)
        {
            accid = myAccID;
        }
        public FilterTransactionModel()
        {
            
        }
    }
}