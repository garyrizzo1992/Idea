using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class AccountRepository : ConnectionClass
    {
        public IEnumerable<Account> getAccountsByUserID(int userid)
        {
            var list = from a in Entity.Accounts
                       where a.UserID == userid && a.AccountTypeID != null
                       select a;
            return list.AsEnumerable();
        }

        public void AddTransaction(Transaction T)
        {
            Entity.Transactions.AddObject(T);
            Entity.SaveChanges();
        }
        public void AddLog(Log l)
        {
            Entity.Logs.AddObject(l);
            Entity.SaveChanges();
        }
        public IEnumerable<Log> GetLogs()
        {
            return Entity.Logs.AsEnumerable();
        }
        public IEnumerable<Log> GetLogsByDate(DateTime start, DateTime end)
        {
            return Entity.Logs.Where(i => i.Date >= start && i.Date <= end);
        }

        public IEnumerable<Account> getAccountsByUsername(string username)
        {
            User userid = new UserRepository().GetUser(username);
            return Entity.Accounts.Where(i => i.UserID == userid.UserID && i.AccountTypeID != null);
        }
        public IEnumerable<Account> getAccountsByUsernameAndNotFixed(string username)
        {
            User userid = new UserRepository().GetUser(username);
            return Entity.Accounts.Where(i => i.UserID == userid.UserID && i.AccountTypeID == 2 && i.AccountTypeID != null);
        }

        public void UpdateAccount(int accid,int fixedrateid,DateTime renewal,decimal balance)
        {
           Account b =  getAccountByID(accid);
           b.Balance = balance;
           b.renewal = renewal;
           b.FixedRateID = fixedrateid;
               Entity.SaveChanges();
        }

        public FixedRate getDuarationOfAccountById(int fixedid)
        {
            return Entity.FixedRates.SingleOrDefault(i => i.FixedRateID == fixedid);
        }


        public IEnumerable<Account> getAccountsNotFixed()
        {
            return Entity.Accounts.Where(i => i.AccountTypeID == 2 && i.AccountTypeID != null);
        }
        public Account getAccountsByID(int accID)
        {
            return Entity.Accounts.SingleOrDefault(u => u.AccountID == accID && u.AccountTypeID != null);
        }



        public Currency getCurrencyByName(string Currency)
        {
            return Entity.Currencies.SingleOrDefault(u => u.Currency1 == Currency);
        }


        
        public IEnumerable<Currency> GetCurrency()
        {
            return Entity.Currencies.AsEnumerable();
        }


        public Currency GetCurrencyByID(int id)
        {
            return Entity.Currencies.SingleOrDefault(u => u.CurrencyID == id);
        }



        public IEnumerable<AccountType> GetAccountType()
        {
            return Entity.AccountTypes.AsEnumerable();
        }


        public IEnumerable<FixedRate> GetFixedRates()
        {
            return Entity.FixedRates.AsEnumerable();
        }


        public void AddAccount(Account a)
        {
            Entity.Accounts.AddObject(a);
            Entity.SaveChanges();
        }


        public Account getAccountByID(int id)
        {
            return Entity.Accounts.SingleOrDefault(a => a.AccountID == id && a.AccountTypeID != null);
        }


        public void AmmendBalance(int id, decimal value)
        {
            Account b = getAccountByID(id);
            b.Balance = value;
            Entity.SaveChanges();
        }

        public IEnumerable<Transaction> GetTransactionByAccountID(int accid)
        {
            return Entity.Transactions.Where(i => i.FromAccountID == accid);
        }

        public IEnumerable<Transaction> GetTransactionByAccountIDAndDate(int accid,DateTime start, DateTime end)
        {
            IEnumerable<Transaction> allAccountTransection = GetTransactionByAccountID(accid);
            return allAccountTransection.Where(t => t.Date >= start && t.Date <= end);
        }

        public void DisableAccount(int accid)
        {
            Account a = getAccountByID(accid);
            a.AccountTypeID = null;
            Entity.SaveChanges();
        }
        public IEnumerable<Account> GetExpiredAccounts(string username)
        {
            int id = new UserRepository().GetUser(username).UserID;
            var list = from t in Entity.Accounts
                       where t.renewal <= DateTime.Now && t.UserID == id && t.AccountTypeID == 1 
                       select t;
            return list.AsEnumerable();
        }


        public IEnumerable<Account> GetNotFixedAccounts(string username)
        {
            User u = new UserRepository().GetUser(username);
            IEnumerable<Account> AllAccounts = getAccountsByUserID(u.UserID);
            return AllAccounts.Where(t => t.AccountTypeID != 1 );
        }


        public IEnumerable<FixedRate> GetFixedRate()
        {
            return Entity.FixedRates.AsEnumerable();
        }
    }
}
