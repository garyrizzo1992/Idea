using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using MvcApplication1.AccountsReference;
using System.Net;
using System.IO;

namespace MvcApplication1.Controllers
{
    public class AccountsController : Controller
    {
        //
        // GET: /Accounts/

        public ActionResult Accounts()
        {
            return View();
        }

        public ActionResult AddAccount()
        {
            return View(new AccountsModel(this.User.Identity.Name));
        }

        [HttpPost]
        public ActionResult AddAccount(AccountsModel am)
        {
            if (new UserReference.UsersServiceClient().Login(this.User.Identity.Name, am.token) == true)
            {
                try
                {
                    AccountsReference.Account accountref = new AccountsReference.Account();
                    Account SourceAccount = new AccountsReference.AccountsServiceClient().getAccountByID((int)am.selectedListAccount);

                    int currencyid = (int)SourceAccount.CurrencyID;
                    Currency FromCurrency = new AccountsReference.AccountsServiceClient().GetCurrencyByID(currencyid);

                    Currency ToCurrency = new AccountsReference.AccountsServiceClient().GetCurrencyByID(am.selectedListCurrency);
                    if (am.ammount == 0)
                    {
                        TempData["message"] = "Ammount cannot be 0";
                        return RedirectToAction("ErrorPage", "UserAuthentication");
                    }

                    double ammountToAmmend = ExchangeRate(Convert.ToDouble(am.ammount), ToCurrency.Currency1, FromCurrency.Currency1);



                    if (((decimal)SourceAccount.Balance - am.ammount) > 0)
                    {
                        new AccountsReference.AccountsServiceClient().AmmendBalance(SourceAccount.AccountID, ((decimal)SourceAccount.Balance - (decimal)ammountToAmmend));



                        Account NewAccount = new Account();
                        NewAccount.CurrencyID = am.selectedListCurrency;
                        NewAccount.AccountTypeID = am.selectedListType;
                        NewAccount.AccountFriendlyName = am.AccountName;
                        NewAccount.Balance = am.ammount;
                        NewAccount.FixedRateID = am.selectedListDuration;
                        NewAccount.UserID = new UserReference.UsersServiceClient().GetUser(this.User.Identity.Name).UserID;
                        NewAccount.CreationDate = DateTime.Now;
                        if (NewAccount.FixedRateID == 1)
                        {
                            NewAccount.renewal = DateTime.Now.AddMonths(1);
                            NewAccount.FromAccountID = am.selectedListAccount;
                        }
                        else if (NewAccount.FixedRateID == 2)
                        {
                            NewAccount.renewal = DateTime.Now.AddMonths(3);
                            NewAccount.FromAccountID = am.selectedListAccount;
                        }
                        else if (NewAccount.FixedRateID == 3)
                        {
                            NewAccount.renewal = DateTime.Now.AddMonths(6);
                            NewAccount.FromAccountID = am.selectedListAccount;
                        }
                        else if (NewAccount.FixedRateID == 4)
                        {
                            NewAccount.renewal = DateTime.Now.AddMonths(12);
                            NewAccount.FromAccountID = am.selectedListAccount;
                        }
                        else
                        {
                            NewAccount.renewal = null;
                            NewAccount.FromAccountID = am.selectedListAccount;
                        }

                        new AccountsReference.AccountsServiceClient().AddAccount(NewAccount);

                        Log newlog = new Log();
                        newlog.AccountID = NewAccount.AccountID;
                        newlog.UserID = NewAccount.UserID;
                        newlog.Date = DateTime.Now;
                        newlog.Description = "New Account has been added with " + NewAccount.Balance + " " + ToCurrency.Currency1 + ".From "+ SourceAccount.AccountFriendlyName;
                        new AccountsReference.AccountsServiceClient().AddLog(newlog);

                        return RedirectToAction("ShowAccounts", "Accounts");


                    }

                    else
                    {
                        TempData["message"] = "Not enough balance in source account";
                        return RedirectToAction("ErrorPage", "UserAuthentication");
                    }
                    //EUR USD GBP

                }
                catch (Exception ex)
                {

                    return null;
                }

            }
            else
            {
                TempData["message"] = "Token not correct or not generated";
                return RedirectToAction("ErrorPage", "UserAuthentication");
            }
        }

        public double ExchangeRate(double balance, string oldCurrency, string newCurrency)
        {
            WebRequest req = HttpWebRequest.Create(@"https://www.google.com/finance/converter?a=" + balance + "&from=" + oldCurrency + "&to=" + newCurrency);
            WebResponse res = req.GetResponse();

            StreamReader sr = new StreamReader(res.GetResponseStream());
            string str = sr.ReadToEnd();
            int lastindex = str.LastIndexOf("class=bld>");
            string almostdone = str.Substring(lastindex + 10);
            int lastindex2 = almostdone.LastIndexOf("</span>");

            string done = almostdone.Substring(0, lastindex2-4);

            return double.Parse(done);
        }
        [HttpGet]
        public ActionResult ShowAccounts()
        {
            return View(new displayAccountModel(User.Identity.Name));
        }

        [HttpPost]
        public ActionResult ShowAccounts(displayAccountModel dam)
        {
            return View();
            /*
            List<AccountsReference.Account> DisplayAccounts = new AccountsReference.AccountsServiceClient().getAccountByUsername(this.User.Identity.Name);
            var myList = new List<displayAccountModel>();
            foreach (AccountsReference.Account myAccs in DisplayAccounts)
            {
                MvcApplication1.Models.displayAccountModel am = new displayAccountModel();

                am.AccountFriendlyName = myAccs.AccountFriendlyName;
                am.Balance = (decimal)myAccs.Balance;
                am.Renewal = (DateTime)myAccs.renewal;

                myList.Add(am);
            }
            return View(myList);*/
        }


        public ActionResult ShowAccountsWithReport(int accid, string start, string end)
        {
            try
            {
                DateTime.Parse(start.ToString());
                DateTime.Parse(end.ToString());

                List<Transaction> tl = new AccountsReference.AccountsServiceClient().GetTransactionByAccountIDAndDate(accid, DateTime.Parse(start), DateTime.Parse(end));
                Account acc = new AccountsReference.AccountsServiceClient().getAccountByID(accid);
                return View(new ReportModel(tl, acc));

            }
            catch (Exception ex)
            {
                TempData["message"] = "Invalid dates";
                return RedirectToAction("ErrorPage", "UserAuthentication");

            }
        }

        //[HttpPost]
        //public ActionResult ShowAccountsWithReport(int accid, DateTime start, DateTime end,int i)
        //{
        //    List<Transaction> tl = new AccountsReference.AccountsServiceClient().GetTransactionByAccountIDAndDate(accid, start, end);

        //    return View(new ReportModel(tl, accid));

        //}

        public ActionResult showTransections(int accid)
        {
            List<AccountsReference.Transaction> list = new AccountsServiceClient().GetTransactionByAccountID(accid);
            var acclist = new List<TransactionModel>();

            foreach (Transaction item in list)
            {
                TransactionModel tm = new TransactionModel();
                tm.FromAccountID = item.FromAccountID;
                tm.ToAccountID = item.ToAccountID;
                tm.TransactionID = item.TransactionID;
                tm.Ammount = item.Amount;
                tm.Date = item.Date.ToString();

                if (item.CurrencyID == 1)
                {
                    tm.Currency = "EUR";
                }
                else if (item.CurrencyID == 2)
                {
                    tm.Currency = "GBP";
                }
                else
                {
                    tm.Currency = "GBP";
                }
                if (accid == item.FromAccountID)
                {
                    tm.TransactionType = "Withdraw";
                }
                else
                {
                    tm.TransactionType = "Deposit";
                }
                acclist.Add(tm);
            }
            return View(acclist);
        }
        [HttpGet]
        public ActionResult Report(int accid)
        {


            FilterTransactionModel FTM = new FilterTransactionModel(accid);

            return View("FilterTransections", FTM);
        }

        public ActionResult FilterTransections(int accid)
        {
            FilterTransactionModel FTM = new FilterTransactionModel(accid);

            return View("FilterTransections", FTM);
        }

        [HttpPost]
        public ActionResult FilterTransections(FilterTransactionModel tm2)
        {
            try
            {

                if (tm2.StartDate.ToString() == "1/01/0001 12:00:00 AM" || tm2.EndDate.ToString() == "1/01/0001 12:00:00 AM")
                {
                    TempData["message"] = "Invalid dates";
                    return RedirectToAction("ErrorPage", "UserAuthentication");
                }
                List<AccountsReference.Transaction> list = new AccountsServiceClient().GetTransactionByAccountIDAndDate(tm2.accid, tm2.StartDate, tm2.EndDate);
                var acclist = new List<TransactionModel>();




                foreach (Transaction item in list)
                {
                    TransactionModel tm = new TransactionModel();
                    tm.FromAccountID = item.FromAccountID;
                    tm.ToAccountID = item.ToAccountID;
                    tm.TransactionID = item.TransactionID;
                    tm.Ammount = item.Amount;
                    tm.Date = item.Date.ToString();

                    if (item.CurrencyID == 1)
                    {
                        tm.Currency = "EUR";
                    }
                    else if (item.CurrencyID == 2)
                    {
                        tm.Currency = "GBP";
                    }
                    else
                    {
                        tm.Currency = "GBP";
                    }
                    if (tm2.accid == item.FromAccountID)
                    {
                        tm.TransactionType = "Withdraw";
                    }
                    else
                    {
                        tm.TransactionType = "Deposit";
                    }

                    acclist.Add(tm);


                }
                return View("showTransections", acclist);
            }
            catch (Exception ex)
            {
                TempData["message"] = "Invalid dates";
                return RedirectToAction("ErrorPage", "UserAuthentication");

            }



        }



        public ActionResult Transfer()
        {
            return View(new TransferModel(this.User.Identity.Name));
        }

        [HttpPost]
        public ActionResult Transfer(TransferModel tm)
        {
            try
            {


                if (new UserReference.UsersServiceClient().Login(this.User.Identity.Name, tm.token) == true)
                {
                    if (tm.ammount == 0)
                    {
                        TempData["message"] = "ammount was either string or 0";
                        return RedirectToAction("ErrorPage", "UserAuthentication");
                    }
                    Account SourceAccount = new AccountsReference.AccountsServiceClient().getAccountByID((int)tm.selectedListFromAccount);
                    Account ToAccount = new AccountsReference.AccountsServiceClient().getAccountByID((int)tm.selectedListToAccount);

                    int currencyidFROM = (int)SourceAccount.CurrencyID;
                    int currencyidTo = (int)ToAccount.CurrencyID;

                    Currency FromCurrency = new AccountsReference.AccountsServiceClient().GetCurrencyByID(currencyidFROM);
                    Currency ToCurrency = new AccountsReference.AccountsServiceClient().GetCurrencyByID(currencyidTo);

                    double ammountToAmmend = (double)ExchangeRate((double)tm.ammount, ToCurrency.Currency1, FromCurrency.Currency1);

                    if ((decimal)SourceAccount.Balance <= (decimal)ammountToAmmend)
                    {
                        TempData["message"] = "Not enough money in source account";
                        return RedirectToAction("ErrorPage", "UserAuthentication");

                    }

                    new AccountsReference.AccountsServiceClient().AmmendBalance(SourceAccount.AccountID, ((decimal)SourceAccount.Balance - (decimal)ammountToAmmend));
                    new AccountsReference.AccountsServiceClient().AmmendBalance(ToAccount.AccountID, ((decimal)ToAccount.Balance + tm.ammount));

                    Transaction Withdraw = new Transaction();
                    Withdraw.FromAccountID = SourceAccount.AccountID;
                    Withdraw.ToAccountID = ToAccount.AccountID;
                    Withdraw.Amount = tm.ammount;
                    Withdraw.CurrencyID = FromCurrency.CurrencyID;
                    Withdraw.TransactionTypeID = 1;
                    Withdraw.Date = DateTime.Now;


                    Transaction Deposit = new Transaction();
                    Deposit.FromAccountID = ToAccount.AccountID;
                    Deposit.ToAccountID = SourceAccount.AccountID;
                    Deposit.Amount = (decimal)ammountToAmmend;
                    Deposit.TransactionTypeID = 2;
                    Deposit.CurrencyID = ToCurrency.CurrencyID;
                    Deposit.Date = DateTime.Now;


                    Log log = new Log();
                    log.AccountID = SourceAccount.AccountID;

                    Log log2 = new Log();
                    log2.AccountID = ToAccount.AccountID;

                    log.Date = DateTime.Now;
                    log2.Date = DateTime.Now;

                    log.Description = "WITHDRAW: Withdrawed " + tm.ammount + " " + FromCurrency.Currency1 + " To transfer to " + ToAccount.AccountID;
                    log2.Description = "DEPOSIT: Deposited " + ammountToAmmend + " " + ToCurrency.Currency1 + " from account " + SourceAccount.AccountID;

                    new AccountsReference.AccountsServiceClient().AddLog(log);
                    new AccountsReference.AccountsServiceClient().AddLog(log2);

                    new AccountsReference.AccountsServiceClient().AddTransaction(Deposit);
                    new AccountsReference.AccountsServiceClient().AddTransaction(Withdraw);


                    return RedirectToAction("ShowAccounts", "Accounts");
                }
                else
                {
                    TempData["message"] = "Token not correct or not generated";
                    return RedirectToAction("ErrorPage", "UserAuthentication");
                }

            }
            catch (Exception)
            {
                TempData["message"] = "Something went wrong, please try again and double check details";
                return RedirectToAction("ErrorPage", "UserAuthentication");
            }


        }
        public ActionResult TransferExternal()
        {
            return View(new TransferExternalModel());
        }

        [HttpPost]
        public ActionResult TransferExternal(TransferExternalModel tm)
        {
            if (new UserReference.UsersServiceClient().Login(this.User.Identity.Name, tm.token) == true)
            {

                if (tm.ammount == 0)
                {
                    TempData["message"] = "ammount was either string or 0";
                    return RedirectToAction("ErrorPage", "UserAuthentication");
                }

                Account SourceAccount = new AccountsReference.AccountsServiceClient().getAccountByID((int)tm.selectedListFromAccount);
                Account ToAccount = new AccountsReference.AccountsServiceClient().getAccountByID(tm.accountid);

                if (ToAccount == null)
                {
                    TempData["message"] = "Destination Account id was not found";
                    return RedirectToAction("ErrorPage", "UserAuthentication");
                }

                int currencyidFROM = (int)SourceAccount.CurrencyID;
                int currencyidTo = (int)ToAccount.CurrencyID;

                Currency FromCurrency = new AccountsReference.AccountsServiceClient().GetCurrencyByID(currencyidFROM);
                Currency ToCurrency = new AccountsReference.AccountsServiceClient().GetCurrencyByID(currencyidTo);

                double ammountToAmmend = (double)ExchangeRate(Convert.ToDouble(tm.ammount), ToCurrency.Currency1, FromCurrency.Currency1);


                if ((decimal)SourceAccount.Balance <= (decimal)ammountToAmmend)
                {
                    TempData["message"] = "Not enough money in source account";
                    return RedirectToAction("ErrorPage", "UserAuthentication");

                }

                new AccountsReference.AccountsServiceClient().AmmendBalance(SourceAccount.AccountID, ((decimal)SourceAccount.Balance - (decimal)ammountToAmmend));
                new AccountsReference.AccountsServiceClient().AmmendBalance(ToAccount.AccountID, ((decimal)ToAccount.Balance + tm.ammount));

                Transaction Withdraw = new Transaction();
                Withdraw.FromAccountID = SourceAccount.AccountID;
                Withdraw.ToAccountID = ToAccount.AccountID;
                Withdraw.Amount = tm.ammount;
                Withdraw.CurrencyID = FromCurrency.CurrencyID;
                Withdraw.TransactionTypeID = 1;
                Withdraw.Date = DateTime.Now;


                Transaction Deposit = new Transaction();
                Deposit.FromAccountID = ToAccount.AccountID;
                Deposit.ToAccountID = SourceAccount.AccountID;
                Deposit.Amount = (decimal)ammountToAmmend;
                Deposit.TransactionTypeID = 2;
                Deposit.CurrencyID = ToCurrency.CurrencyID;
                Deposit.Date = DateTime.Now;


                Log log = new Log();
                log.AccountID = SourceAccount.AccountID;

                Log log2 = new Log();
                log2.AccountID = ToAccount.AccountID;

                log.Date = DateTime.Now;
                log2.Date = DateTime.Now;

                log.UserID = SourceAccount.UserID;
                log2.UserID = ToAccount.UserID;

                log.Description = "WITHDRAW: Withdrawed " + tm.ammount + " " + FromCurrency.Currency1 + " To transfer to " + ToAccount.AccountID;
                log2.Description = "DEPOSIT: Deposited " + ammountToAmmend + " " + ToCurrency.Currency1 + " from account " + SourceAccount.AccountID;

                new AccountsReference.AccountsServiceClient().AddLog(log);
                new AccountsReference.AccountsServiceClient().AddLog(log2);

                new AccountsReference.AccountsServiceClient().AddTransaction(Deposit);
                new AccountsReference.AccountsServiceClient().AddTransaction(Withdraw);

                return RedirectToAction("ShowAccounts", "Accounts");
            }
            else
            {
                TempData["message"] = "Token not correct or not generated";
                return RedirectToAction("ErrorPage", "UserAuthentication");
            }

        }

        [HttpGet]
        public ActionResult ExchangePage()
        {
            return View(new ExchangeRateModel());
        }
        [HttpPost]
        public ActionResult ExchangePage(ExchangeRateModel am)
        {
            Currency source = new AccountsReference.AccountsServiceClient().GetCurrencyByID(am.SourceCurrency);
            Currency destination = new AccountsReference.AccountsServiceClient().GetCurrencyByID(am.DestinationCurrency);

            double total = ExchangeRate(am.ammount, source.Currency1, destination.Currency1);
            ExchangeRateModel erm = new ExchangeRateModel();
            erm.total = total;
            return View("DisplayResult",erm);
        }
        public ActionResult DisplayResult(ExchangeRateModel am)
        {
            return View(am);
        }
        [HttpGet]
        public ActionResult FilterLogs()
        {
            return View(new LogsModel());
        }

        [HttpPost]
        public ActionResult FilterLogs(LogsModel lm)
        {
            //int clientid,int accountid,DateTime start, DateTime end
            IEnumerable<AccountsReference.Log> alllogs = new AccountsReference.AccountsServiceClient().GetLogs();

            if (lm.UserID != 0)
            {
                alllogs = alllogs.Intersect(alllogs.Where(u => u.UserID == lm.UserID));
            }
            if (lm.StartDate.Year != 0001 && lm.EndDate.Year != 0001)
            {
                alllogs = alllogs.Intersect(alllogs.Where(u => u.Date >= lm.StartDate && u.Date <= lm.EndDate));
            }
            if (lm.AccountID != 0)
            {
                alllogs = alllogs.Intersect(alllogs.Where(u => u.AccountID == lm.AccountID));
            }
            if (lm.isDateSorted == true)
            {
                alllogs = alllogs.OrderBy(d => d.Date);
            }

            LogsModel logsM = new LogsModel();
            logsM.FilteredLogs = alllogs;
            return View(logsM);
        }



    }
}
