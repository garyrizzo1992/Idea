using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class ErrorModel
    {
        public string message { get; set; }

        public ErrorModel(string error)
        {
            message = error;
        }
    }
}