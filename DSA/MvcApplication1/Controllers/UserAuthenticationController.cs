using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Web.Security;
using System.Net;
using System.IO;

namespace MvcApplication1.Controllers
{
    public class UserAuthenticationController : Controller
    {
        //
        // GET: /UserAuthentication/


        public ActionResult ErrorPage()
        {

            return View(new ErrorModel(TempData["message"].ToString()));
        }

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated == true) {
                return RedirectToAction("CheckAndDisplayExpired");
            }
             
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel data)
        {
            if (new UserReference.UsersServiceClient().Login(data.Username, data.Token) == true)
            {
                //valid login
                FormsAuthentication.RedirectFromLoginPage(data.Username, true);

                return RedirectToAction("CheckAndDisplayExpired");
            }
            //if invalid
            else
            {
                TempData["message"] = "Login invalid";
                return RedirectToAction("ErrorPage");
            }
            

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "UserAuthentication");
        }
       
        
        public ActionResult CheckAndDisplayExpired()
        {
            List<AccountsReference.Account> expiredAccount = new AccountsReference.AccountsServiceClient().GetExpiredAccounts(this.User.Identity.Name);
            var arm1 = new List<AccountRenewModel>();

            foreach (AccountsReference.Account item in expiredAccount)
            {
                AccountRenewModel arm = new AccountRenewModel(this.User.Identity.Name);
                arm.AccountID = item.AccountID;
                arm.AccountFriendlyName = item.AccountFriendlyName;
                arm.Balance = (decimal)item.Balance;

                arm1.Add(arm);
            }

            return View("CheckAndDisplayExpired", arm1);
        }

        [HttpGet]
        public ActionResult TransferInterest()
        {
            AccountRenewModel arm = new AccountRenewModel(this.User.Identity.Name);
            return View(arm);
        }


        [HttpPost]
        public ActionResult TransferInterest(AccountRenewModel rm, int id)
        {
            AccountsReference.Account ac = new AccountsReference.AccountsServiceClient().getAccountsByID(id);
          
            decimal f = 0;


            if (ac.FixedRateID  == 1)
            {
                f = (((decimal)0.25 * (decimal)ac.Balance) / 100);
                f = f / 12;
                f = ((f * 85) / 100);
            }
            if (ac.FixedRateID == 2)
            {
                f = (((decimal)1.65 * (decimal)ac.Balance) / 100);
                f = f / 4;
                f = ((f * 85) / 100);
            }
            if (ac.FixedRateID == 3)
            {
                f = (((decimal)1.75 * (decimal)ac.Balance) / 100);
                f = f / 2;
                f = ((f * 85) / 100);
            }
            if (ac.FixedRateID == 4)
            {
                f = (((decimal)2.00 * (decimal)ac.Balance) / 100);
                f = f / 1;
                f = ((f * 85) / 100);
            }

            AccountsReference.Account Destac = new AccountsReference.AccountsServiceClient().getAccountByID((rm.selectedDestinationAccount));

            ac.Balance += f;

            double tot = 0;

            if (ac.CurrencyID == Destac.CurrencyID)
                tot = (double)ac.Balance;
            else tot = (double)ExchangeRate((double)ac.Balance, ac.Currency.Currency1, Destac.Currency.Currency1);

            double sbal = 0;
            double dbal = tot + (double)Destac.Balance;

            new AccountsReference.AccountsServiceClient().AmmendBalance(ac.AccountID, (decimal)sbal);
            new AccountsReference.AccountsServiceClient().DisableAccount(ac.AccountID);
            new AccountsReference.AccountsServiceClient().AmmendBalance(Destac.AccountID, ((decimal)dbal));


            

            return RedirectToAction("ShowAccounts","Accounts");
           
        }

        [HttpGet]
        public ActionResult RenewAccount()
        {
            AccountRenewModel arm = new AccountRenewModel(this.User.Identity.Name);
            return View(arm);
        }
        [HttpPost]
        public ActionResult RenewAccount(AccountRenewModel rm, int id)
        {
            AccountsReference.Account ac = new AccountsReference.AccountsServiceClient().getAccountsByID(id);
            AccountsReference.FixedRate fixed_rates = new AccountsReference.AccountsServiceClient().getDuarationOfAccountById(rm.selectedDuration);

            decimal f = 0;


            if (ac.FixedRateID == 1)
            {
                f = (((decimal)0.25 * (decimal)ac.Balance) / 100);
                f = f / 12;
                f = ((f * 85) / 100);
            }
            else if (ac.FixedRateID == 2)
            {
                f = (((decimal)1.65 * (decimal)ac.Balance) / 100);
                f = f / 4;
                f = ((f * 85) / 100);
            }
            else if (ac.FixedRateID == 3)
            {
                f = (((decimal)1.75 * (decimal)ac.Balance) / 100);
                f = f / 2;
                f = ((f * 85) / 100);
            }
            else if (ac.FixedRateID == 4)
            {
                f = (((decimal)2.00 * (decimal)ac.Balance) / 100);
                f = f / 1;
                f = ((f * 85) / 100);

            }


            if (rm.selectedDuration == 1)
            {
                ac.FixedRateID = 1;
                ac.Balance = ac.Balance + f;
                ac.renewal = DateTime.Now.AddMonths(1);
            }
            if (rm.selectedDuration == 2)
            {
                ac.FixedRateID = 2;
                ac.Balance = ac.Balance + f;
                ac.renewal = DateTime.Now.AddMonths(3);
            }
            if (rm.selectedDuration == 3)
            {
                ac.FixedRateID = 3;
                ac.Balance = ac.Balance + f;
                ac.renewal = DateTime.Now.AddMonths(6);
            }
            if (rm.selectedDuration == 4)
            {
                ac.FixedRateID = 4; 
                ac.Balance = ac.Balance + f;
                ac.renewal = DateTime.Now.AddMonths(12);
            }

            new AccountsReference.AccountsServiceClient().UpdateAccount((int)ac.AccountID,(int)ac.FixedRateID,(DateTime)ac.renewal,(decimal)ac.Balance);

            return RedirectToAction("ShowAccounts", "Accounts");

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

            string done = almostdone.Substring(0, lastindex2 - 4);

            return double.Parse(done);
        }


    }
}
