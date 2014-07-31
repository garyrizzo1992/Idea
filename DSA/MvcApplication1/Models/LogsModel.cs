using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class LogsModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int AccountID { get; set;}
        public int UserID { get; set; }
        public bool isDateSorted { get; set; }

        public IEnumerable<AccountsReference.Log> FilteredLogs { get; set; }


        public LogsModel()
        {

        }

    }
}