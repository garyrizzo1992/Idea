using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ideaworkmate.Models
{
    public class UserModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Locality { get; set; }

        public DateTime JoinDate { get; set; }


    }
}