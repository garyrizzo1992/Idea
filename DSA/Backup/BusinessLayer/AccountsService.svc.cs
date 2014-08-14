using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataAccess;
using Common;

namespace BusinessLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountsService" in code, svc and config file together.
    public class AccountsService : IAccountsService
    {
        public IEnumerable<Account> getAccountByUsername(string username)
        {
            return new AccountRepository().getAccountsByUsername(username);
        }

        public void DisableAccount(int accid)
        {
            new AccountRepository().DisableAccount(accid);
        }

        public IEnumerable<Log> GetLogs()
        {
            return new AccountRepository().GetLogs();
        }
        public IEnumerable<Log> GetLogsByDate(DateTime start, DateTime end)
        {
            return new AccountRepository().GetLogsByDate(start, end);
        }


        public void UpdateAccount(int accid, int fixedrateid, DateTime renewal, decimal balance)
        {
             new AccountRepository().UpdateAccount(accid,fixedrateid,renewal,balance);
        }

        public IEnumerable<Account> GetNotFixedAccounts(string username)
        {
            return new AccountRepository().GetNotFixedAccounts(username);
        }

        public IEnumerable<Account> GetExpiredAccounts(string username)
        {
            return new AccountRepository().GetExpiredAccounts(username);
        }

        public IEnumerable<Transaction> GetTransactionByAccountIDAndDate(int accid, DateTime start, DateTime end)
        {
            return new AccountRepository().GetTransactionByAccountIDAndDate(accid, start, end);
        }

        public void AddTransaction(Transaction T)
        {
            new AccountRepository().AddTransaction(T);
        }
        public void AddLog(Log l)
        {
            new AccountRepository().AddLog(l);
        }

        public IEnumerable<Account> getAccountsByUsernameAndNotFixed(string username)
        {
            return new AccountRepository().getAccountsByUsernameAndNotFixed(username);
        }
        public IEnumerable<Account> getAccountsNotFixed()
        {
            return new AccountRepository().getAccountsNotFixed();
        }
        public Account getAccountsByID(int accID)
        {
            return new AccountRepository().getAccountsByID(accID);
        }

        public Currency getCurrencyByName(string Currency)
        {
            return new AccountRepository().getCurrencyByName(Currency);
        }
        public Currency GetCurrencyByID(int id)
        {
            return new AccountRepository().GetCurrencyByID(id);
        }
        public IEnumerable<Currency> GetCurrency()
        {
            return new AccountRepository().GetCurrency();
        }
        public void AddAccount(Account a)
        {
            new AccountRepository().AddAccount(a);
        }
        public void AmmendBalance(int id, decimal value)
        {
            new AccountRepository().AmmendBalance(id, value);
        }
        public IEnumerable<AccountType> GetAccountType()
        {
            return new AccountRepository().GetAccountType();
        }
        public IEnumerable<FixedRate> GetFixedRates()
        {
            return new AccountRepository().GetFixedRates();
        }
        public Account getAccountByID(int id)
        {
            return new AccountRepository().getAccountByID(id);
        }


        public IEnumerable<Account> getAccountsByUserID(int userid)
        {
            return new AccountRepository().getAccountsByUserID(userid);
        }
        public IEnumerable<Transaction> GetTransactionByAccountID(int accid)
        {
            return new AccountRepository().GetTransactionByAccountID(accid);
        }


        public FixedRate getDuarationOfAccountById(int fixedid)
        {
            return new AccountRepository().getDuarationOfAccountById(fixedid);
        }
    }
}
