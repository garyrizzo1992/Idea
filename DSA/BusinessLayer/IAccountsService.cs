using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;

namespace BusinessLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccountsService" in both code and config file together.
    [ServiceContract]
    public interface IAccountsService
    {
        [OperationContract]
        void AddLog(Log l);

        [OperationContract]
        FixedRate getDuarationOfAccountById(int fixedid);

        [OperationContract]
        void DisableAccount(int accid);


        [OperationContract]
        void UpdateAccount(int accid, int fixedrateid, DateTime renewal, decimal balance);

        [OperationContract]
        IEnumerable<Account> GetNotFixedAccounts(string username);

        [OperationContract]
        IEnumerable<Account> GetExpiredAccounts(string username);

        [OperationContract]
        IEnumerable<Transaction> GetTransactionByAccountIDAndDate(int accid, DateTime start, DateTime end);

        [OperationContract]
        void AddTransaction(Transaction T);
        [OperationContract]
        IEnumerable<Account> getAccountByUsername(string username);

        [OperationContract]
        IEnumerable<Account> getAccountsNotFixed();

        [OperationContract]
        IEnumerable<Account> getAccountsByUsernameAndNotFixed(string username);

        [OperationContract]
        Currency getCurrencyByName(string Currency);

        [OperationContract]
        Account getAccountsByID(int accID);

        [OperationContract]
        Currency GetCurrencyByID(int id);

        [OperationContract]
        IEnumerable<Currency> GetCurrency();

        [OperationContract]
        void AddAccount(Account a);

        [OperationContract]
        void AmmendBalance(int id, decimal value);

        [OperationContract]
        IEnumerable<AccountType> GetAccountType();

        [OperationContract]
        IEnumerable<FixedRate> GetFixedRates();

        [OperationContract]
        Account getAccountByID(int id);

        [OperationContract]
        IEnumerable<Account> getAccountsByUserID(int userid);

        [OperationContract]
        IEnumerable<Transaction> GetTransactionByAccountID(int accid);

        [OperationContract]
        IEnumerable<Log> GetLogs();

        [OperationContract]
        IEnumerable<Log> GetLogsByDate(DateTime start, DateTime end);

    }
}
