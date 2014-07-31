using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class AppointmentsController : Controller
    {
        //
        // GET: /Appointments/

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult RequestAppointment()
        {
            return View(new AppointmentModel());
        }
        [HttpPost]
        public ActionResult RequestAppointment(AppointmentModel am)
        {
            AppointmentReference.Appointment newapp = new AppointmentReference.Appointment();
            newapp.AppointmentStatusID = 3;
            newapp.Date = am.Date;
            newapp.Time = am.time;
            newapp.Description = am.Description;
            UserReference.User u = new UserReference.UsersServiceClient().GetUser(this.User.Identity.Name);
            newapp.UserID = u.UserID;

            new AppointmentReference.AppointmentsServiceClient().AddAppointment(newapp);

            return RedirectToAction("ShowAccounts", "Accounts");

        }



        public ActionResult ShowAppointments()
        {
            List<AppointmentReference.Appointment> applist = new AppointmentReference.AppointmentsServiceClient().GetAppointmentsNeedingReview();
            var AppointmentModellocal = new List<AppointmentModel>();

            foreach (AppointmentReference.Appointment item in applist)
            {
                AppointmentModel am = new AppointmentModel();
                am.AppointmentID = item.AppointmentID;
                am.Date = (DateTime)item.Date;
                am.time = item.Time;
                am.Description = item.Description;
                am.userid = (int)item.UserID;
                AppointmentModellocal.Add(am);
            }
            return View("ShowAppointments",AppointmentModellocal);

        }


        [HttpGet]
        public ActionResult AcceptAppointment()
        {
            //AppointmentModel apm = new AppointmentModel();
            //apm.appList = new AppointmentReference.AppointmentsServiceClient().GetAppointmentsNeedingReview();          
            //return View(apm);
            return View(new AppointmentModel());
        }


        [HttpPost]
        public ActionResult AcceptAppointment(AppointmentModel am, int appid)
        {


            AppointmentReference.Appointment ap = new AppointmentReference.AppointmentsServiceClient().GetAppointment(appid);
            UserReference.User u = new UserReference.UsersServiceClient().GetUserByID((int)ap.UserID);
            string body = "";



            body = "Dear " + u.Name + " \n" + "Your appointment has been accepted on the below date and time \n " + ap.Date.ToString() + " " + ap.Time.ToString();
            new AppointmentReference.AppointmentsServiceClient().SendEmail(u.EmailAddress, body);
            new AppointmentReference.AppointmentsServiceClient().ChangeStatus(ap.AppointmentID, 1);



            return RedirectToAction("ShowAccounts", "Accounts");

        }

        [HttpGet]
        public ActionResult RejectAppointment()
        {
            //AppointmentModel apm = new AppointmentModel();
            //apm.appList = new AppointmentReference.AppointmentsServiceClient().GetAppointmentsNeedingReview();          
            //return View(apm);
            return View(new AppointmentModel());
        }


        [HttpPost]
        public ActionResult RejectAppointment(AppointmentModel am, int appid)
        {
          

            AppointmentReference.Appointment ap = new AppointmentReference.AppointmentsServiceClient().GetAppointment(appid);
            UserReference.User u = new UserReference.UsersServiceClient().GetUserByID((int)ap.UserID);
            string body = "";


                    body = "Dear " + u.Name + " \n" + "Your appointment has been Rejected";
                    new AppointmentReference.AppointmentsServiceClient().SendEmail(u.EmailAddress,(body+ ". \n Reason: " + am.Description));
                    new AppointmentReference.AppointmentsServiceClient().ChangeStatus(ap.AppointmentID, 2);

              

            return RedirectToAction("ShowAccounts", "Accounts");

        }

    }
}
