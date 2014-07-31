using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class UserRepository : ConnectionClass
    {
        public User GetUser(string username)
        {
            return Entity.Users.SingleOrDefault(u => u.Username == username);
        }
        public User GetUserByID(int id)
        {
            return Entity.Users.SingleOrDefault(u => u.UserID == id);
        }

        public bool Login(string username, string encrypedcode)
        {
            User u = GetUser(username);
            if (u == null)
            {
                return false;
            }
            if (u.Token == null)
            {
                return false;
            }
            string DBencrypt = u.Token.ToString();
            string pin = u.Pin.ToString();

            Decrypt d = new Decrypt();
           string correcttoken = d.DecryptTripleDES(DBencrypt, pin);
           string usertoken = d.DecryptTripleDES(encrypedcode, pin);
           if (correcttoken == null || usertoken == null)
           {
               return false;
           }

           if (correcttoken == usertoken)
           {
               DeleteToken(u.UserID);
               return true;
           }
           else
           {
               return false;
           }
        }

        public void DeleteToken(int userid)
        {
            User u = GetUserByID(userid);
            u.Token = null;
            Entity.SaveChanges();
        }

        public IEnumerable<UserRole> GetRoleByUsername(string username)
        {
            User u1 = GetUser(username);
            return Entity.UserRoles.Where(u => u.UserRoleID == u1.UserRoleID);
        }
    }
}
