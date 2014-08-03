using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataAccess
{
     public class UserRepository : ConnectionClass
    {
         public IEnumerable<User> Getusers()
         {
             return Entity.Users.AsEnumerable();
         }   
    }
}